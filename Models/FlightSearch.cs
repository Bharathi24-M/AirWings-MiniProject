using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirWings.Models
{
    public class FlightSearch
    {
        public int Origin { get; set; }
        public int Destination { get; set; }

        public DateTime TravelDate { get; set; }

        public List<SelectListItem> CityList { get; set; }

    }
    public class FlightResult
    {
        [Key]
        public int TripId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int FlightId { get; set; }
        public DateTime Arrivaltime { get; set; }
        public DateTime Departuretime { get; set; }
        public int Availableseats { get; set; }
        public int Businessavailableseats { get; set; }
        public double Fare { get; set; }
        public double Businessfare { get; set; }
        public string FlightName { get; set; }
        public bool? Economic { get; set; }
        public bool? Business { get; set; }

    }
}
