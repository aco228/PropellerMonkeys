using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Sockets.Core
{
  public enum SocketDistributionModelType
  {
    DEFAULT,
    INTERNAL,
    LOGIN
  }
  
  [Serializable()]
  public class SocketDistributionModel
  {
    public SocketDistributionModelType Type { get; set; } = SocketDistributionModelType.DEFAULT;
    public byte[] Data { get; set; } = null;

    public SocketDistributionModel(object data, SocketDistributionModelType type)
    {
      Data = SocketDistributionManager.GetBytesFromObj(data);
      this.Type = type;
    }

    public SocketDistributionModel(object data)
    {
      Data = SocketDistributionManager.GetBytesFromObj(data);
    }
    
  }
}
