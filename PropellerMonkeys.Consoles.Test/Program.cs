using PropellerMonkeys.Api;
using PropellerMonkeys.Core.Sockets;
using PropellerMonkeys.Sockets.Core;
using System;
using System.Collections.Generic;

namespace PropellerMonkeys.Consoles.TestClient
{


  class Program
  {
    static void Main(string[] args)
    {
      PropellerAdsApi api = new PropellerAdsApi("mediamonkeys", "52JEL72Cs:1^6WN");
      List<Campaign> campaigns = api.GetCampaignsList();
      CampaignStats stat = api.GetCurrentStats(campaigns[0]);

      




      Console.WriteLine("Hello World!");
      Console.ReadKey();
    }
  }
}
