using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Api
{
  public static class PropellerAdsHelper
  {

    public static Campaign GetCampaignFromJson(dynamic json)
    {
      try
      {
        Campaign result = new Campaign();
        result.ID = json.id;
        result.Name = json.name;

        if (json.is_archived.ToString().Equals("1")) // deleted campaign
          return null;

        result.Status = (CampaignStatus)json.status;

        return result;
      }
      catch(Exception e)
      {
        return null;
      }
    }

  }
}
