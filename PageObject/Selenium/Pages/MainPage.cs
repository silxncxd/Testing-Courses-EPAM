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
    class MainPage
    {

        [FindsBy(How = How.Name, Using = "from")]
        private IWebElement departureStation;

        [FindsBy(How = How.Name, Using = "to")]
        private IWebElement arrivalStation;

        [FindsBy(How = How.Name, Using = "departure")]
        private IWebElement departureDate;

        [FindsBy(How = How.XPath, Using = "//span[@class='dotted-link js-book-tickets-oneway-trigger']")]
        private IWebElement cancelReturnTripButton;

        [FindsBy(How = How.CssSelector, Using = @".button.with-outlines")]
        private IWebElement sendRequestButton;

        [FindsBy(How = How.Id, Using = "error_placeholder")]
        private IWebElement errorMessage;

        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public MainPage SendRequest(TripInfo trip)
        {
            departureStation.SendKeys(trip.departureStation);
            arrivalStation.SendKeys(trip.arrivalStation);
            departureDate.SendKeys(trip.todayDate);
            cancelReturnTripButton.Click();
            sendRequestButton.Click();
            return this;
        }

        public string GetErrorText()
        {
            return errorMessage.Text;
        }
    }
}
