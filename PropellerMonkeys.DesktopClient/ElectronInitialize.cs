using ElectronNET.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerMonkeys.DesktopClient
{
  public class ElectronInitialize
  {

    public ElectronInitialize()
    {
      Electron.WindowManager.CreateWindowAsync();
      ListenForMessages();
    }

    public void ListenForMessages()
    {
      try
      {
        var mainWindow = Electron.WindowManager.BrowserWindows.First();
        Electron.IpcMain.On("init", (args) =>
        {
          Electron.IpcMain.Send(mainWindow, "sendData", "Hello IPC World!");
        });
      }
      catch(Exception e)
      {

      }
    }

  }
}
