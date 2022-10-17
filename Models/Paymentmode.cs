using System;
using System.Collections.Generic;

namespace AirWings.Models
{
    public partial class Paymentmode
    {
        public Paymentmode()
        {
            Ticketdetails = new HashSet<Ticketdetail>();
        }

        public int Paymodeid { get; set; }
        public string Paymode { get; set; } = null!;

        public virtual ICollection<Ticketdetail> Ticketdetails { get; set; }
    }
}
