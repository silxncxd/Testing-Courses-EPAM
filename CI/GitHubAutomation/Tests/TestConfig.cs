using LdzTravelAutomation.Driver;
using NUnit.Framework;
using LdzTravelAutomation.Services;
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
            Logger.InitLogger();
            Driver = DriverSingleton.GetDriver();
            Logger.Log.Info("Browser initialized");
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotCreator.SaveScreenShot(Driver);
                Logger.Log.Info("Error acquired, screenshot done");
            }
            DriverSingleton.CloseDriver();
        }
    }
}
