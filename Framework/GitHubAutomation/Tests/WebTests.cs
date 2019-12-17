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
        private const string TranslatedButton = "FIND TICKETS";
        private const string ReviewOrder = "5. Review order";
        private const string MessageToolTip = "We are currently processing your question.Thank you for your patience!";

        [Test]
        public void SearchTrips()
        {
            TripInfo trip = TripInfoCreator.SetAllProperties();
            OrderTripPage orderTripPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton();
            Assert.AreEqual(trip.DepartureStation, orderTripPage.DepartureStationInfo());
            Assert.AreEqual(trip.ArrivalStation, orderTripPage.ArrivalStationInfo());
        }


        [Test]
        public void SameStationError()
        {
            TripInfo trip = TripInfoCreator.SetSameStationInfo();
            OrderTripPage mainPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton();
            Assert.AreEqual(ErrorMessage, mainPage.GetErrorText());
        }

        [Test]
        public void PastDateTest()
        {
            TripInfo trip = TripInfoCreator.SetPastDateInfo();
            OrderTripPage mainPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton();
            Assert.AreEqual(BookingURL, Driver.Url);
        }

        [Test]
        public void FalsePassengerInfo()
        {
            TripInfo trip = TripInfoCreator.SetAllProperties();
            TravelerInfoPage travelerInfoPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton()
                .ClickSelectCarriageButton()
                .SelectWagonAndSeat()
                .ClickConfirmButton()
                .InputPassengerInfo(PassengerInfoCreator.SetInvalidInfo())
                .ClickHotelsButton();
            Assert.IsTrue(travelerInfoPage.ErrorTooltip.Displayed);
        }

        [Test]
        public void ChangeSiteLanguage()
        {
            MainPage mainPage = new MainPage(Driver)
                .ChangeSiteLanguage();
            Assert.AreEqual(mainPage.sendRequestButton.Text, TranslatedButton);
        }

        [Test]
        public void CheckSumOfTickets()
        {
            TripInfo trip = TripInfoCreator.SetAllProperties();
            TravelerInfoPage travelerInfoPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton()
                .ClickSelectCarriageButton()
                .SelectWagonAndSeat()
                .ChangePassenger()
                .SelectWagonAndSeat()
                .ClickConfirmButton();
            Assert.IsTrue(travelerInfoPage.ArePricesEqual());
        }

        [Test]
        public void SearchTripsWithReturnOption()
        {
            TripInfo trip = TripInfoCreator.SetAllProperties();
            OrderTripPage orderTripPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .InputReturnDate(trip)
                .ClickSendRequestButton();
            Assert.AreEqual(orderTripPage.CountOfRoutes(), 2);
        }

        [Test]
        public void ChooseReservedSeat()
        {
            TripInfo trip = TripInfoCreator.SetAllProperties();
            CarriagePage carriagePage = new MainPage(Driver)
                .InputTripInfo(trip)
                .InputReturnDate(trip)
                .ClickSendRequestButton()
                .ClickSelectCarriageButton()
                .ChooseReservedSeat();
            Assert.IsFalse(carriagePage.TravelerInformationButton.Enabled);
        }

        [Test]
        public void SuccessBookingTest()
        {
            TripInfo trip = TripInfoCreator.SetAllProperties();
            BookingPage bookingPage = new MainPage(Driver)
                .InputTripInfo(trip)
                .CancelReturnTrip()
                .ClickSendRequestButton()
                .ClickSelectCarriageButton()
                .SelectWagonAndSeat()
                .ClickConfirmButton()
                .InputPassengerInfo(PassengerInfoCreator.SetNormalInfo())
                .ClickBookingButton();
            Assert.AreEqual(bookingPage.GetReviewOrder(), ReviewOrder);
        }

        [Test]
        public void SubmitAQuestion()
        {
            QuestionPage questionPage = new MainPage(Driver)
                .ClickContactsButton()
                .InputQuestion(QuestionInfoCreator.SetNormalInfo())
                .ClickSendQuestionButton();
            Assert.AreEqual(questionPage.MessageTooltip, MessageToolTip);
        }
    }
}
