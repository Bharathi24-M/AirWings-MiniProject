using System.ComponentModel.DataAnnotations;

namespace AirWings.Models
{
    public class Bookingdetails
    {
      
        public FlightResult flightResult { get; set; }
        public List<Offer> offers { get; set; }
        public List<Paymentmode> paymentmodes { get; set; }
        public string Passengername { get; set; }
        public string Emailaddress { get; set; }
        public string Passengerpnumber { get; set; }
        public int Offerid { get; set; }
        public int Tripid { get; set; }
        public int Paymodeid { get; set; }
        public double TotalAmount { get; set; }
       
        public double Discount { get; set; }
    }
}
