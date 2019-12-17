using LdzTravelAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace LdzTravelAutomation.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "from")]
        private IWebElement departureStation;

        [FindsBy(How = How.Name, Using = "to")]
        private IWebElement arrivalStation;

        [FindsBy(How = How.Name, Using = "departure")]
        private IWebElement departureDate;

        [FindsBy(How = How.Id, Using = "book_tickets_return")]
        private IWebElement returnDate;
   
        [FindsBy(How = How.XPath, Using = "//span[@class='dotted-link js-book-tickets-oneway-trigger']")]
        private IWebElement cancelReturnTripButton;

        [FindsBy(How = How.CssSelector, Using = @".button.with-outlines")]
        public IWebElement sendRequestButton;

        [FindsBy(How = How.ClassName, Using = "en")]
        private IWebElement SetEnglishLanguage;

        [FindsBy(How = How.ClassName, Using = "cookie-close")]
        private IWebElement CloseCookieButton;

        [FindsBy(How = How.XPath, Using = "//div[1]/div[7]/div/ul/li[3]/a")]
        private IWebElement ContactsButton;

        public MainPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public MainPage InputTripInfo(TripInfo trip)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Name("departure")));
            CloseCookieButton.Click();
            departureStation.SendKeys(trip.DepartureStation);
            arrivalStation.SendKeys(trip.ArrivalStation);
            departureDate.SendKeys(trip.DepartureDate + "\n");
            return this;
        }

        public MainPage CancelReturnTrip()
        {
            cancelReturnTripButton.Click();
            return this;
        }
        public MainPage InputReturnDate(TripInfo trip)
        {
            returnDate.SendKeys(trip.ReturnDate + "\n");
            return this;
        }

        public OrderTripPage ClickSendRequestButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".button.with-outlines")));
            sendRequestButton.Click();
            return new OrderTripPage(driver);
        }

        public MainPage ChangeSiteLanguage()
        {
            SetEnglishLanguage.Click();
            return this;
        }

        public QuestionPage ClickContactsButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Name("departure")));
            CloseCookieButton.Click();
            ContactsButton.Click();
            return new QuestionPage(driver);
        }
    }
}
