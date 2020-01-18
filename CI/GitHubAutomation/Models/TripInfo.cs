
namespace LdzTravelAutomation.Models
{
    public class TripInfo
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }

        public TripInfo (string departureStation, string arrivalStation, string departureDate, string returnDate)
        {
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
        }        
    }
}
