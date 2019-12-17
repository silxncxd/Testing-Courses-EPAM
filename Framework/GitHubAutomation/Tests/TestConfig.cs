using LdzTravelAutomation.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using LdzTravelAutomation.Utils;

namespace LdzTravelAutomation.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void StartDriver()
        {
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://travel.ldz.lv/");
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotCreator.SaveScreenShot(Driver);
            }
            DriverSingleton.CloseDriver();
        }
    }
}
