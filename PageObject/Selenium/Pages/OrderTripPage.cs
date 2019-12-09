using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using static PageObject.WebTests;

namespace PageObject.Pages
{
    class OrderTripPage
    {
        [FindsBy(How = How.XPath, Using = @"//span[@class = 'from']")]
        private IWebElement departureStation;

        [FindsBy(How = How.XPath, Using = @"//span[@class = 'to']")]
        private IWebElement arrivalStation;
        public OrderTripPage(IWebDriver webDriver)
        {
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
    }
}
