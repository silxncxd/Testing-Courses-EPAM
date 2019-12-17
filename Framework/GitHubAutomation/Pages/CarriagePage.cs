using LdzTravelAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace LdzTravelAutomation.Pages
{
    public class CarriagePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "cld-type")]
        private IList<IWebElement> Wagons;

        [FindsBy(How = How.CssSelector, Using = ".button.place")]
        private IList<IWebElement> PassengerSeats;

        [FindsBy(How = How.ClassName, Using = "button.with-arrow.next-step-button")]
        public IWebElement TravelerInformationButton;

        [FindsBy(How = How.ClassName, Using = "psm-add-button.js-add-passenger")]
        private IWebElement AddPassengerButton;

        [FindsBy(How = How.ClassName, Using = "ws-action.wsa-next")]
        private IWebElement NextPassengerButton;

        [FindsBy(How = How.ClassName, Using = "button.place.reserved")]
        private IWebElement ReservedSeat;
        
        [FindsBy(How = How.Id, Using = "selected_price")]
        private IWebElement Price;

        public double TotalPrice = 0;
        
        public CarriagePage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public CarriagePage SelectWagonAndSeat()
        {
            foreach (var wagon in Wagons)
            {
                wagon.Click();
                foreach (var seat in PassengerSeats)
                {
                    if (seat.Enabled)
                    {
                        seat.Click();
                        PassengerSeats.Remove(seat);
                        TotalPrice += Convert.ToDouble(Price.Text);
                        break;
                    }
                }
            }
            return this;
        }
        
        public TravelerInfoPage ClickConfirmButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(By.ClassName("button.with-arrow.next-step-button")));
            TravelerInformationButton.Click();
            return new TravelerInfoPage(driver, TotalPrice);
        }
        public CarriagePage ChooseReservedSeat()
        {
            foreach (var wagon in Wagons)
            {
                wagon.Click();
                ReservedSeat.Click();
            }
            return this;
        }
        public CarriagePage ClickAddPassengerButton()
        {
            AddPassengerButton.Click();
            return this;
        }
        public CarriagePage ChangePassenger()
        {
            NextPassengerButton.Click();
            return this;
        }

        
    }

}
