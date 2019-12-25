using LdzTravelAutomation.Models;
using OpenQA.Selenium;
using LdzTravelAutomation.Services;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LdzTravelAutomation.Pages
{
    public class BookingPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "page-content-header")]
        private IWebElement ReviewOrder;

        public BookingPage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(webDriver, this);
            Logger.Log.Info("Booking page initialized");
        }

        public string GetReviewOrder()
        {
            Logger.Log.Info("Review got");
            return ReviewOrder.Text;

        }
    }

}
