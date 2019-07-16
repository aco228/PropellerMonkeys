using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerMonkeys.WebServer.Models
{
  public class ConsoleModel
  {
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedString { get => string.Format("{0}:{1}.{2}",
      (Created.Hour < 10 ? "0" + Created.Hour.ToString() : Created.Hour.ToString()),
      (Created.Minute < 10 ? "0" + Created.Minute.ToString() : Created.Minute.ToString()),
      (Created.Second < 10 ? "0" + Created.Second.ToString() : Created.Second.ToString()));
    }
    public string Text { get; set; } = string.Empty;
  }
}
