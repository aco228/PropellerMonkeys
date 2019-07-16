using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Sockets.Core
{
  public class SocketConsoleManager
  {
    public Action<string> OnNewLine = null;

    public void WriteLine(string line)
    {
      Console.WriteLine(line);
      OnNewLine?.Invoke(line);
    }

  }
}
