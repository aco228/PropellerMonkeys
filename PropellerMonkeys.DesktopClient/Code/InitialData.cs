using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerMonkeys.DesktopClient.Code
{
  public class InitialData
  {
    public Dictionary<string, string> Data = new Dictionary<string, string>();

    public string this[string input] => Data.ContainsKey(input) ? Data[input] : string.Empty;

    public InitialData()
    {
      if (!File.Exists(Program.Hosting.WebRootPath + @"\data\input.txt"))
        return;

      string[] lines = File.ReadAllLines(Program.Hosting.WebRootPath + @"\data\input.txt");
      foreach(string line in lines)
      {
        string[] split = line.Split('#')[0].Split(':');
        if (split.Length != 2)
          continue;

        if(!Data.ContainsKey(split[0].Trim()))
          Data.Add(split[0].Trim(), split[1].Trim());
      }
    }

  }
}
