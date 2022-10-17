using System;
using System.Collections.Generic;

namespace AirWings.Models
{
    public partial class Ticketdetail
    {
        public int Pnr { get; set; }
        public int Tripid { get; set; }
        public int Offerid { get; set; }
        public int Paymodeid { get; set; }
        public double Fare { get; set; }
        public double Discount { get; set; }
        public double Taxamount { get; set; }
        public double Netamount { get; set; }
        public int Ticketstatus { get; set; }
        public string Passengername { get; set; } = null!;
        public string Emailaddress { get; set; } = null!;
        public string Passengerpnumber { get; set; } = null!;

        public virtual Offer Offer { get; set; } = null!;
        public virtual Paymentmode Paymode { get; set; } = null!;
        public virtual Tripdetail Trip { get; set; } = null!;
    }
}
