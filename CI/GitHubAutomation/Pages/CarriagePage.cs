using LdzTravelAutomation.Models;
using OpenQA.Selenium;
using LdzTravelAutomation.Services;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

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
            Logger.Log.Info("Carriage page initialized");
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
            Logger.Log.Info("Wagon and seat selected");
            return this;
        }
        
        public TravelerInfoPage ClickConfirmButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(By.ClassName("button.with-arrow.next-step-button")));
            TravelerInformationButton.Click();
            Logger.Log.Info("Traveler information button clicked");
            return new TravelerInfoPage(driver, TotalPrice);
        }
        public bool ChooseReservedSeat()
        {
            foreach (var wagon in Wagons)
            {
                wagon.Click();
                Logger.Log.Info("Reserved seat clicked");
                return false;
            }
            return true;
        }
        public CarriagePage ClickAddPassengerButton()
        {
            AddPassengerButton.Click();
            Logger.Log.Info("Add passenger button clicked");

            return this;
        }
        public bool State()
        {
            return !Price.Displayed;
        }
        public CarriagePage ChangePassenger()
        {
            NextPassengerButton.Click();
            Logger.Log.Info("Next passenger button clicked");
            return this;
        }
        
    }

}
