
namespace LdzTravelAutomation.Models
{
    public class PassengerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }

        public PassengerInfo(string firstName, string lastName, string passport)
        {
            FirstName = firstName;
            LastName = lastName;
            Passport = passport;
        }
    }
}
