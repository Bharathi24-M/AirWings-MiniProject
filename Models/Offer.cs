using System;
using System.Collections.Generic;

namespace AirWings.Models
{
    public partial class Offer
    {
        public Offer()
        {
            Ticketdetails = new HashSet<Ticketdetail>();
        }

        public int Offerid { get; set; }
        public string Offername { get; set; } = null!;
        public int Offerprice { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Ticketdetail> Ticketdetails { get; set; }
    }
}
