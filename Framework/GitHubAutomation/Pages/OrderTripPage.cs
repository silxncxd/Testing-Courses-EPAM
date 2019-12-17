using LdzTravelAutomation.Models;
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
        }

        public string DepartureStationInfo()
        {
            return departureStation.Text.ToUpper();
        }
        public string ArrivalStationInfo()
        {
            return arrivalStation.Text.ToUpper();
        }
        public CarriagePage ClickSelectCarriageButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='button submit-train-selection with-arrow with-large-spacer']")));
            SelectCarriageButton.Click();
            return new CarriagePage(driver);
        }

        public string GetErrorText()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("error_placeholder")));
            return errorMessage.Text;
        }

        public int CountOfRoutes()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("route-title")));
            return Routes.Count;
        }
    }
}
