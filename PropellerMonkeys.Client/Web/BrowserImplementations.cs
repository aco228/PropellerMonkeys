using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Client.Web
{
  public partial class Browser
  {

    public void Login()
    {
      LoadPage("https://partners.propellerads.com/#/app/auth", By.Id("username"));
      Driver.FindElementById("username").SendKeys(Program.InitialData["username"]);
      Driver.FindElementById("password").SendKeys(Program.InitialData["password"]);
      Driver.FindElementsByClassName("button_primary")[0].Click();
    }

    public string GetCurrentBalance()
    {
      try
      {
        Driver.Navigate().Refresh();
        WaitToLoad(By.ClassName("balance-widget__value"));
        return Driver.FindElementByClassName("balance-widget__value").Text;
      }
      catch (Exception e)
      {
        return string.Empty;
      }
    }





  }
}
