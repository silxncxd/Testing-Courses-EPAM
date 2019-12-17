
namespace LdzTravelAutomation.Models
{
    public class PassengerInfo
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Passport { get; }

        public PassengerInfo(string firstName, string lastName, string passport)
        {
            FirstName = firstName;
            LastName = lastName;
            Passport = passport;
        }
    }
}
