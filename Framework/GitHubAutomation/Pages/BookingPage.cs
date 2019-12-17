using LdzTravelAutomation.Models;
using OpenQA.Selenium;
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
        }

        public string GetReviewOrder()
        {
            return ReviewOrder.Text;
        }
    }

}
