using NUnitFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace NUnitFramework.Pages
{
    class GmailPage
    {
		IWebDriver driver;
		ProgressLogger logger;

		public GmailPage(ProgressLogger logger)
		{
			this.logger = logger;
			driver = NUnitWebDriver.GetInstanceOfNUnitWebDriver();
		}

        By googleAccount = By.XPath("//a[contains(@aria-label,'Google Account')]");
        By signOutButton = By.XPath("//a[text()='Sign out']");
        By userNameField = By.CssSelector("input[id='identifierId']");
        By userNameNextButton = By.CssSelector("div#identifierNext content>span.RveJvd.snByac");
        By passwordField = By.CssSelector("input[name='password']");
        By passwordNextButton = By.CssSelector("div#passwordNext content span.RveJvd.snByac");
        public bool Gmail(string gmailUserName, string password)
        {
            try
            {
                string url = TestData.GetData("GmailURL");
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                // ********** For Normal execution ************** //

                driver.FindElement(userNameField).SendKeys(gmailUserName);
                driver.FindElement(userNameNextButton).Click();
                driver.FindElement(passwordField).SendKeys(password);
                Thread.Sleep(2000);
                driver.FindElement(passwordNextButton).Click();
                Thread.Sleep(5000);
                if (driver.Title.Contains(Const.GmailUserName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void GmailLogout(IWebDriver driver)
        {
            try
            {
                driver.FindElement(googleAccount).Click();
                driver.FindElement(signOutButton).Click();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
