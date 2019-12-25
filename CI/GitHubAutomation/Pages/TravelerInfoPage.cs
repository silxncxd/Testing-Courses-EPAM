using LdzTravelAutomation.Models;
using LdzTravelAutomation.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LdzTravelAutomation.Pages
{
    public class TravelerInfoPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "fgs-icon.fgs-male")]
        private IWebElement PassengerSex;

        [FindsBy(How = How.ClassName, Using = "first_name")]
        private IWebElement PassengerFirstName;

        [FindsBy(How = How.ClassName, Using = "last_name")]
        private IWebElement PassengerLastName;

        [FindsBy(How = How.ClassName, Using = "passport")]
        private IWebElement PassengerPassport;

        [FindsBy(How = How.ClassName, Using = "button.plain")]
        private IWebElement ContinueBookingButton;

        [FindsBy(How = How.ClassName, Using = "button.with-arrow")]
        private IWebElement HotelsButton;

        [FindsBy(How = How.Id, Using = "qtip-0-content")]
        public IWebElement ErrorTooltip;

        [FindsBy(How = How.Id, Using = "total")]
        public IWebElement CurrentTotalPrice;

        public double PreviousTotalPrice;

        public TravelerInfoPage(IWebDriver webDriver, double totalPrice)
        {
            driver = webDriver;
            PreviousTotalPrice = totalPrice;
            PageFactory.InitElements(webDriver, this);
            Logger.Log.Info("Traveler info page initialized");
        }

        public TravelerInfoPage InputPassengerInfo(PassengerInfo passenger)
        {
            PassengerSex.Click();
            PassengerFirstName.SendKeys(passenger.FirstName);
            PassengerLastName.SendKeys(passenger.LastName);
            PassengerPassport.SendKeys(passenger.Passport);
            Logger.Log.Info($"Passenger info input:" + passenger.FirstName + "/" + passenger.LastName + "/" + passenger.Passport);
            return this;
        }

        public TravelerInfoPage ClickHotelsButton()
        {
            HotelsButton.Click();
            Logger.Log.Info("Hotels button clicked");
            return this;
        }

        public BookingPage ClickBookingButton()
        {
            ContinueBookingButton.Click();
            Logger.Log.Info("Continue booking button clicked");
            return new BookingPage(driver);
        }

        public bool ArePricesEqual()
        {
            bool result = Convert.ToDouble(CurrentTotalPrice.Text) == PreviousTotalPrice;
            Logger.Log.Info("Boolean result of compare returned");
            return result;
        }
    }
}
