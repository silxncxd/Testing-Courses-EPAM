
namespace LdzTravelAutomation.Models
{
    public class TripInfo
    {
        public string DepartureStation { get; }
        public string ArrivalStation { get; }
        public string DepartureDate { get; }
        public string ReturnDate { get; }

        public TripInfo (string departureStation, string arrivalStation, string departureDate, string returnDate)
        {
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
        }        
    }
}
