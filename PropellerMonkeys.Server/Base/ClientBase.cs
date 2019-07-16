using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PropellerMonkeys.Sockets.Core.Base
{
  public abstract class ClientBase : SocketCore
  {
    private SocketRegistrationModel _registrationModel = null;
    private bool _clientWasConnected = false;
    protected Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


    public ClientBase(string ip, int port, string username) : base(ip, port)
    {
      this._registrationModel = new SocketRegistrationModel() { Username = username };
      LoopConnect();
    }

    public ClientBase(string ip, string port, string username) : base(ip, port)
    {
      this._registrationModel = new SocketRegistrationModel() { Username = username };
      if (!KeepConnectionInSeparateThread)
        LoopConnect();
      else
        new Thread(() => { LoopConnect(); }).Start();
    }

    public void LoopConnect()
    {
      Console.WriteLine("Trying to connect...");
      if (_clientWasConnected)
      {
        ClientSocket.Shutdown(SocketShutdown.Both);
        ClientSocket.Disconnect(true);
        ClientSocket.Close();
        ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.OnDisconnection();
      }

      while (!ClientSocket.Connected)
      {
        try
        {
          ClientSocket.Connect(new IPEndPoint(IPAddress.Parse(this.IP), this.PORT));
        }
        catch (Exception e) { }
        System.Threading.Thread.Sleep(1000);
      }

      this.OnConnection();
      _clientWasConnected = true;
      this.SendModel(this._registrationModel.Instantiate());

      Console.WriteLine("Connected..");

      ClientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
    }

    protected override void OnReceive(SocketDistributionModel data, Socket socket)
    {

    }

    protected override void OnSocketFatalDisconection(Exception e, Socket socket)
    {
      throw new NotImplementedException();
    }

    //
    // ABSTRACT
    //
    protected abstract void OnConnection();
    protected abstract void OnDisconnection();



    // SUMMARY: Send model to server
    public void SendModel(SocketDistributionModel model)
    {
      try
      {
        byte[] data = SocketDistributionManager.GetBytesFromObj(model);
        ClientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), ClientSocket);
      }
      catch (Exception e) { }
    }


  }
}
