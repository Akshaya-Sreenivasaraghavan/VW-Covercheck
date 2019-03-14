using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gerkins_Selenium_Test.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        public IWebDriver browser;

        [Given(@"I have loaded the site '(.*)' in browser")]
        public void GivenIHaveLoadedTheSiteInBrowser(string url)
        {
            browser = new ChromeDriver();
            browser.Url = url;
            browser.Manage().Window.Maximize();
        }

        [When(@"I enter the registration number (.*) in the text box")]
        public void WhenIEnterTheRegistrationNumberInTheTextBox(string regNum)
        {
            browser.FindElement(By.Id("vehicleReg")).SendKeys(regNum);
        }


        [When(@"I also click find vehical button")]
        public void WhenIAlsoClickFindVehicalButton()
        {
            browser.FindElement(By.ClassName("track-search")).Click();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
        }

        [Then(@"the result (.*) should be displayed")]
        public void ThenTheResultShouldBeDisplayed(string message)
        {
            string result = browser.FindElement(By.ClassName("result")).Text;
            Assert.IsTrue((result.ToLower().Contains(message)) || (result.ToLower() == message));
        }

        [Then(@"the browser is closed")]
        public void ThenTheBrowserIsClosed()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            browser.Close();
        }

    }
}
