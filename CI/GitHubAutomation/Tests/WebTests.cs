using LdzTravelAutomation.Pages;
using LdzTravelAutomation.Services;
using LdzTravelAutomation.Models;
using NUnit.Framework;
using System;

namespace LdzTravelAutomation.Tests
{
    public class LDZTravelTests : TestConfig
    {
        private const string ErrorMessage = "Notikusi sistēmas kļūda. Lūdzu, mēģiniet vēlreiz!";
        private const string BookingURL = "https://travel.ldz.lv/lv/booking/booking-1";
        private const string ContactsURL = "https://travel.ldz.lv/lv/kontakti";
        private const string TranslatedButton = "FIND TICKETS";
        private const string ReviewOrder = "5. Review order";
        private const string MessageToolTip = "We are currently processing your question.Thank you for your patience!";
        private const string URL = "https://travel.ldz.lv/";

        [Test]
        public void SearchTrips()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            TripInfo trip = TripInfoCreator.SetAllProperties();
            OrderTripPage orderTripPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton();
            Assert.AreEqual(trip.DepartureStation, orderTripPage.DepartureStationInfo());
            Assert.AreEqual(trip.ArrivalStation, orderTripPage.ArrivalStationInfo());
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void SameStationError()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            OrderTripPage mainPage = new MainPage(Driver)
                .InputTripInfo(TripInfoCreator.SetSameStationInfo())
                .CancelReturnTrip()
                .ClickSendRequestButton();
            Assert.AreEqual(ErrorMessage, mainPage.GetErrorText());
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void PastDateTest()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            OrderTripPage mainPage = new MainPage(Driver)
                .InputTripInfo(TripInfoCreator.SetPastDateInfo())
                .CancelReturnTrip()
                .ClickSendRequestButton();
            Assert.AreEqual(BookingURL, Driver.Url);
            Logger.Log.Info("Test complete successfully");

        }

        [Test]
        public void FalsePassengerInfo()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            CarriagePage travelerInfoPage = new MainPage(Driver)
                .InputTripInfo(TripInfoCreator.SetAllProperties())
                .CancelReturnTrip()
                .ClickSendRequestButton()
                .ClickSelectCarriageButton();
            Assert.IsTrue(travelerInfoPage.State());
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void ChangeSiteLanguage()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            MainPage mainPage = new MainPage(Driver)
                .ChangeSiteLanguage();
            Assert.AreEqual(mainPage.sendRequestButton.Text, TranslatedButton);
            Logger.Log.Info("Test complete successfully");

        }

        [Test]
        public void CheckSumOfTickets()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            TravelerInfoPage travelerInfoPage = new MainPage(Driver)
                .InputTripInfo(TripInfoCreator.SetAllProperties())
                .CancelReturnTrip()
                .ClickSendRequestButton()
                .ClickSelectCarriageButton()
                .SelectWagonAndSeat()
                .ChangePassenger()
                .SelectWagonAndSeat()
                .ClickConfirmButton();
            Assert.IsTrue(travelerInfoPage.ArePricesEqual());
            Logger.Log.Info("Test complete successfully");

        }

        [Test]
        public void SearchTripsWithReturnOption()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            TripInfo trip = TripInfoCreator.SetAllProperties();
            OrderTripPage orderTripPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .InputReturnDate(trip)
                .ClickSendRequestButton();
            Assert.AreEqual(orderTripPage.CountOfRoutes(), 2);
            Logger.Log.Info("Test complete successfully");

        }

        [Test]
        public void ChooseReservedSeat()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            TripInfo trip = TripInfoCreator.SetAllProperties();
            CarriagePage carriagePage = new MainPage(Driver)
                .InputTripInfo(trip)
                .InputReturnDate(trip)
                .ClickSendRequestButton()
                .ClickSelectCarriageButton();
            Assert.IsFalse(carriagePage.ChooseReservedSeat());
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void SuccessBookingTest()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            BookingPage bookingPage = new MainPage(Driver)
                .InputTripInfo(TripInfoCreator.SetAllProperties())
                .CancelReturnTrip()
                .ClickSendRequestButton()
                .ClickSelectCarriageButton()
                .SelectWagonAndSeat()
                .ClickConfirmButton()
                .InputPassengerInfo(PassengerInfoCreator.SetNormalInfo())
                .ClickBookingButton();
            Assert.AreEqual(bookingPage.GetReviewOrder(), ReviewOrder);
            Logger.Log.Info("Test complete successfully");
        }

        [Test]
        public void SubmitAQuestion()
        {
            Logger.InitLogger();
            Driver.Navigate().GoToUrl(URL);
            Logger.Log.Info("Go to " + URL);
            QuestionPage questionPage = new MainPage(Driver)
                .ClickContactsButton()
                .InputQuestion(QuestionInfoCreator.SetNormalInfo());
            Assert.AreEqual(ContactsURL, Driver.Url);
            Logger.Log.Info("Test complete successfully");

        }
    }
}
