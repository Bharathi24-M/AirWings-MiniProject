using System;
using System.Collections.Generic;

namespace AirWings.Models
{
    public partial class Flightdetail
    {
        public Flightdetail()
        {
            Tripdetails = new HashSet<Tripdetail>();
        }

        public int FlightId { get; set; }
        public string FlightName { get; set; } = null!;
        public bool Economic { get; set; }
        public bool Business { get; set; }

        public virtual ICollection<Tripdetail> Tripdetails { get; set; }
    }
}
