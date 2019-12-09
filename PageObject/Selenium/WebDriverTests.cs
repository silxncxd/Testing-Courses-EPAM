using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace PageObject
{
    [TestClass]
    public class WebTests
    {
        private IWebDriver webDriver;
        private static string HomePage = "https://travel.ldz.lv/";

        public class TripInfo
        {
            public string departureStation = "RĪGA PASAŽIERU";
            public string arrivalStation = "MINSKA PASAŽIERU";
            public string todayDate = DateTime.Now.ToShortDateString();
        }

        private TripInfo tripInfo = new TripInfo();

        private string errorMessage = "Notikusi sistēmas kļūda. Lūdzu, mēģiniet vēlreiz!"; 

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(HomePage);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void QuitDriver()
        {
            if (webDriver != null)
                webDriver.Quit();
        }

        [Test]
        //test 1
        public void SearchTrips()
        {
            MainPage mainPage = new MainPage(webDriver).SendRequest(tripInfo);
            OrderTripPage orderTripPage = new OrderTripPage(webDriver);
            NUnit.Framework.Assert.AreEqual(tripInfo.departureStation, orderTripPage.DepartureStationInfo());
            NUnit.Framework.Assert.AreEqual(tripInfo.arrivalStation, orderTripPage.ArrivalStationInfo());
        }

        [Test]
        //test 2
        public void SameStationError()
        {
            TripInfo sameStationTrip = new TripInfo();
            sameStationTrip.arrivalStation = sameStationTrip.departureStation;
            MainPage mainPage = new MainPage(webDriver).SendRequest(sameStationTrip);
            NUnit.Framework.Assert.AreEqual(errorMessage, mainPage.GetErrorText());
        }
    }
}
