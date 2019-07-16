using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PropellerMonkeys.Sockets.Core.Base
{
  public abstract class SocketCore
  {
    protected string IP = string.Empty;
    public int PORT = -1;

    protected object LockObj = new object();
    protected byte[] _buffer = new byte[25600];
    public SocketConsoleManager Console = new SocketConsoleManager();
    protected virtual bool KeepConnectionInSeparateThread { get; } = false;

    public SocketCore(string IP, int PORT)
    {
      this.IP = IP;
      this.PORT = PORT;
    }

    public SocketCore(string IP, string PORT)
    {
      if (!int.TryParse(PORT, out this.PORT))
        throw new Exception("WRONG string to int conversion");

      this.IP = IP;
    }

    // SUMMARY: On receive message from client
    protected virtual void ReceiveCallback(IAsyncResult AR)
    {
      Socket socket = (Socket)AR.AsyncState;
      try
      {
        int received = socket.EndReceive(AR);
        byte[] dataBuf = new byte[received];
        Array.Copy(_buffer, dataBuf, received);

        SocketDistributionModel modelReceived = SocketDistributionManager.ConvertToModel(dataBuf);

        if (modelReceived != null)
          this.OnReceive(modelReceived, socket);

        socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
      }
      catch (Exception e)
      {
        OnSocketFatalDisconection(e, socket);
      }
    }

    protected abstract void OnReceive(SocketDistributionModel data, Socket socket);
    protected abstract void OnSocketFatalDisconection(Exception e, Socket socket);

    // SUMMARY: On data sent to client
    protected void SendCallback(IAsyncResult AR)
    {
      Socket socket = (Socket)AR.AsyncState;
      socket.EndSend(AR);
    }

  }
}
