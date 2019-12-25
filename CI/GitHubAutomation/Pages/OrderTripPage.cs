using LdzTravelAutomation.Models;
using LdzTravelAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace LdzTravelAutomation.Pages
{
    public class OrderTripPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "from")]
        private IWebElement departureStation;

        [FindsBy(How = How.ClassName, Using = "to")]
        private IWebElement arrivalStation;

        [FindsBy(How = How.XPath, Using = @"//button[@class='button submit-train-selection with-arrow with-large-spacer']")]
        private IWebElement SelectCarriageButton;

        [FindsBy(How = How.Id, Using = "error_placeholder")]
        private IWebElement errorMessage;

        [FindsBy(How = How.ClassName, Using = "route-title")]
        public IList<IWebElement> Routes;

        public OrderTripPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
            Logger.Log.Info("Order trip page initialized");
        }

        public string DepartureStationInfo()
        {
            var info = departureStation.Text.ToUpper();
            Logger.Log.Info("Departure station info returned");
            return info;
        }
        public string ArrivalStationInfo()
        {
            var info = arrivalStation.Text.ToUpper();
            Logger.Log.Info("Arrival station info returned");
            return info;
        }
        public CarriagePage ClickSelectCarriageButton()
        {
            SelectCarriageButton.Click();
            Logger.Log.Info("Carriage button clicked");
            return new CarriagePage(driver);
        }

        public string GetErrorText()
        {
            var error = errorMessage.Text;
            Logger.Log.Info("Error message returned");
            return error;
        }

        public int CountOfRoutes()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("route-title")));
            var count = Routes.Count;
            Logger.Log.Info("Routes count returned");
            return Routes.Count;
        }
    }
}
