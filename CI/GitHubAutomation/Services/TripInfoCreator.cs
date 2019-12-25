using LdzTravelAutomation.Models;

namespace LdzTravelAutomation.Services
{
    public static class TripInfoCreator
    {
        public static TripInfo SetAllProperties()
        {
            return new TripInfo(InvalidTestDataReader.GetData("DepartureStation"), InvalidTestDataReader.GetData("ArrivalStation"),
                InvalidTestDataReader.GetData("DepartureDate"), InvalidTestDataReader.GetData("ReturnDate"));
        }
        public static TripInfo SetPastDateInfo()
        {
            return new TripInfo(InvalidTestDataReader.GetData("DepartureStation"), InvalidTestDataReader.GetData("ArrivalStation"),
                InvalidTestDataReader.GetData("PastDate"), InvalidTestDataReader.GetData("ReturnDate"));
        }
        public static TripInfo SetSameStationInfo()
        {
            return new TripInfo(InvalidTestDataReader.GetData("DepartureStation"), InvalidTestDataReader.GetData("DepartureStation"),
                InvalidTestDataReader.GetData("PastDate"), InvalidTestDataReader.GetData("ReturnDate"));
        }

    }
}
