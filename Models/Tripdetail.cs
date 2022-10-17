using System;
using System.Collections.Generic;

namespace AirWings.Models
{
    public partial class Tripdetail
    {
        public Tripdetail()
        {
            Ticketdetails = new HashSet<Ticketdetail>();
        }

        public int TripId { get; set; }
        public int FlightId { get; set; }
        public int Origin { get; set; }
        public int Destination { get; set; }
        public DateTime Arrivaltime { get; set; }
        public DateTime Departuretime { get; set; }
        public int Availableseats { get; set; }
        public int Businessavailableseats { get; set; }
        public double Fare { get; set; }
        public double Businessfare { get; set; }

        public virtual Flightdetail Flight { get; set; } = null!;
        public virtual ICollection<Ticketdetail> Ticketdetails { get; set; }
    }
}
