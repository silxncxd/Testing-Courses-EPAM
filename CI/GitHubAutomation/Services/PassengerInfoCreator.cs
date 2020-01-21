using LdzTravelAutomation.Models;


namespace LdzTravelAutomation.Services
{
    public class PassengerInfoCreator
    {
        public static PassengerInfo SetInvalidInfo()
        {
            return new PassengerInfo(InvalidTestDataReader.GetData("PassengerFirstName"), InvalidTestDataReader.GetData("PassengerLastName"),
                InvalidTestDataReader.GetData("PassengerPassport"));
        }
        public static PassengerInfo SetNormalInfo()
        {
            return new PassengerInfo(NormalTestDataReader.GetData("PassengerFirstName"), NormalTestDataReader.GetData("PassengerLastName"),
                NormalTestDataReader.GetData("PassengerPassport"));
        }
    }

}
