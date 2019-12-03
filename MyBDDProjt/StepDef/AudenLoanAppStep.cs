using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using TechTalk.SpecFlow;

namespace MyBDDProjt
{
    [Binding]
    public sealed class AudenLoanAppStep
    {
        //Verify landing on home page:
        [Given(@"I am on Auden website")]
        public void GivenIAmOnAudenWebsite()

        {
            Thread.Sleep(1000);
            Util.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("Website")); 
        }

        [Then(@"I should see home link")]
        public bool ThenIShouldSeeHomeLink()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(Util.driver.FindElement(By.LinkText("Home")).Displayed);
            return true;
        }
        [Then(@"I scroll the slider bar to home and end")]
        public void ThenIScrollTheSliderBarToHomeAndEnd()
        {

            //scrollSliderBar to £200
            IWebElement sliderBar = Util.driver.FindElement(By.XPath("//input[@type='range'][1]"));
            Actions move = new Actions(Util.driver);
            move.ClickAndHold(sliderBar).Build();
            move.SendKeys(Keys.Home).Build().Perform();
            Thread.Sleep(5000);

            //scrollSliderBar to £1000
            move.ClickAndHold(sliderBar).Build();
            move.SendKeys(Keys.End).Build().Perform();
            Thread.Sleep(5000);
        }

        [Then(@"I should see the coresponding amount on the page")]
        public bool ThenIShouldSeeTheCorespondingAmountOnThePage()
        {
            Thread.Sleep(2000);
            //Assert £200 displayed:
             Assert.IsTrue(Util.driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/div/div/section[1]/header/div[2]/span")).Displayed);
            return true;

            //Assert £1000 displayed:
            Assert.IsTrue(Util.driver.FindElement(By.CssSelector("#root > div > div > div:nth-child(1)")).Displayed);
             return true;
        }
        [When(@"I scroll the slider bar to the last monthly instalments")]
        public void WhenIScrollTheSliderBarToTheLastMonthlyInstalments()
        {
            
            IWebElement sliderBarInstal = Util.driver.FindElement(By.XPath(".//input[@id='monthly']"));
            Actions move = new Actions(Util.driver);
            move.ClickAndHold(sliderBarInstal).Build();
            move.SendKeys(Keys.End).Build().Perform();
            Thread.Sleep(3000);
        }

        [Then(@"I should see the corresponding instalment period")]
        public bool ThenIShouldSeeTheCorrespondingInstalmentPeriod()
        {
            Thread.Sleep(2000);
            //Assert 12 displayed:
            Assert.IsTrue(Util.driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/div/div/section[2]/div/div/header/div[2]/span")).Displayed);
            return true;
        }
        [Then(@"I scroll to view the calendar")]
        public void ThenIScrollToViewTheCalendar()
        {
            IJavaScriptExecutor js = Util.driver as IJavaScriptExecutor;
           
            js.ExecuteScript("window.scrollBy(0,400);");
            Thread.Sleep(5000);
            // ((IJavaScriptExecutor)Util.driver).ExecuteScript("scroll(0,400)");

        }
        [Then(@"I click on the repayment calendar button")]
        public void ThenIClickOnTheRepaymentCalendarButton()
        {
            Thread.Sleep(2000);
            Util.driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/div/div/section[2]/div/div/div[2]/header/button/span[3]")).Click();
        }

        [Then(@"I select a repayment weekend date form the calendar")]
        public void ThenISelectARepaymentWeekendDateFormTheCalendar()
        {
            //Thread.Sleep(1000);
            Util.driver.FindElement(By.XPath(".//button[@value= '7']")).Click();
        }

        [Then(@"I should see a previous working date as default")]
        public void ThenIShouldSeeAPreviousWorkingDateAsDefault()
        {
            Thread.Sleep(1000);

            ITakesScreenshot Scrn = Util.driver as ITakesScreenshot;

            Screenshot Scrnshot = Scrn.GetScreenshot();

            Scrnshot.SaveAsFile(@"C:\Users\olatu\Documents\Visual Studio 2017\Projects\MyBDDProjt\MyBDDProjt\ScreenShots\screenshot.png", ScreenshotImageFormat.Png);
            Thread.Sleep(500);
        }

        [Then(@"I close the browser")]
        public void ThenICloseTheBrowser()
        {

            Thread.Sleep(1000);
            Util.driver.Close();
        }







    }
}