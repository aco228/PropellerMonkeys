using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PropellerMonkeys.Sockets.Core.Base
{
  public abstract class ServerBase : SocketCore
  {
    protected List<SocketObject> ClientSockets { get; set; } = new List<SocketObject>();
    protected Socket ServerSocket { get; set; } = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    public SocketObject this[Socket socket] => (from sc in this.ClientSockets where sc.Socket == socket select sc).FirstOrDefault();
    public SocketObject this[string socketID] => (from sc in this.ClientSockets where sc.Identifier.Equals(socketID) select sc).FirstOrDefault();

    public ServerBase(int PORT) : base(string.Empty, PORT)
    {
      if (!KeepConnectionInSeparateThread)
        SetupServer();
      else
        new Thread(() => { SetupServer(); }).Start();
    }

    // SUMMARY: Start server listening
    protected virtual void SetupServer()
    {
      Console.WriteLine("Setting up server, with PORT=" + PORT + "...");
      Console.WriteLine("On IP: " + GetLocalIPAddress());
      ServerSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
      ServerSocket.Listen(1);
      ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
    }

    protected string GetLocalIPAddress()
    {
      var host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (var ip in host.AddressList)
      {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
          return ip.ToString();
        }
      }
      throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    // SUMMARY: On client connected
    protected virtual void AcceptCallback(IAsyncResult AR)
    {
      Socket socket = ServerSocket.EndAccept(AR);
      try
      {
        lock (this.LockObj)
          ClientSockets.Add(new SocketObject(socket));
        Console.WriteLine("Client connected");

        socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        this.OnClientConnected(this[socket].Identifier);
      }
      catch (Exception e)
      {
        this.OnClientDisconnected(this[socket].Identifier);
        lock (this.LockObj)
          OnSocketFatalDisconection(e, socket);
      }
    }


    protected override void OnReceive(SocketDistributionModel data, Socket socket)
    {
      if (data.Type == SocketDistributionModelType.LOGIN)
      { 
        this[socket].Identifier = data.Convert<SocketRegistrationModel>().Username;
        Console.WriteLine($"User '{this[socket].Identifier}' connected!");
        return;
      }

      SocketObject socketObj = this[socket];
      if (socketObj != null && data.Type == SocketDistributionModelType.DEFAULT)
        OnReceiveFromClient(data, socketObj);
    }

    // ABSTRACT::
    public abstract void OnReceiveFromClient(SocketDistributionModel data, SocketObject socket);

    protected override void OnSocketFatalDisconection(Exception e, Socket socket)
    {
      Console.WriteLine($"Client '{this[socket].Identifier}' has disconnected");
      OnClientDisconnected(this[socket].Identifier);
      lock (this.LockObj)
        ClientSockets.Remove(this[socket]);
    }

    // ABSTRACT::
    public abstract void OnClientConnected(string identifier);
    public abstract void OnClientDisconnected(string identifier);

    // SUMMARY: Send model to client
    public void SendModel(SocketDistributionModel model)
    {
      if (ClientSockets.Count == 0)
        return;

      lock (this.LockObj)
      {
        foreach (SocketObject socket in this.ClientSockets)
          try
          {
            byte[] data = SocketDistributionManager.GetBytesFromObj(model);
            socket.Socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
          }
          catch (Exception e) { }
      }
    }

  }
}
