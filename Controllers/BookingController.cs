using AirWings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirWings.Controllers
{

    public class BookingController : Controller
    {
        private readonly AirWingsContext db;
        private readonly ISession session;
        public BookingController(AirWingsContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult BookTicket(int id)
        {
            var Tripdetails = (from Td in db.Tripdetails
                               where Td.TripId == id

                               join Org in db.Citydetails
                               on Td.Origin equals Org.CityId

                               join Des in db.Citydetails
                               on Td.Destination equals Des.CityId

                               join Fli in db.Flightdetails
                               on Td.FlightId equals Fli.FlightId

                               select new FlightResult()
                               {
                                   Origin = Org.Cityname,
                                   Destination = Des.Cityname,
                                   Departuretime = Td.Departuretime,
                                   Arrivaltime = Td.Arrivaltime,
                                   Availableseats = Td.Availableseats,
                                   Businessavailableseats = Td.Businessavailableseats,
                                   Businessfare = Td.Businessfare,
                                   Fare = Td.Fare,
                                   FlightId = Td.FlightId,
                                   FlightName = Fli.FlightName,
                                   Business = Fli.Business,
                                   Economic = Fli.Economic,
                                   TripId = Td.TripId
                               }).FirstOrDefault();

            var offer = (from off in db.Offers
                         where off.IsActive == true
                         select off).ToList();
            var payment = (from pay in db.Paymentmodes
                           select pay).ToList();
            Bookingdetails bookingdetails = new Bookingdetails();
            bookingdetails.paymentmodes = payment;
            bookingdetails.offers = offer;
            bookingdetails.flightResult = Tripdetails;

            return View(bookingdetails);

        }
        [HttpPost]
        public IActionResult ConfirmTicket(Bookingdetails book)
        {
            Ticketdetail ticketdetail = new Ticketdetail();
            ticketdetail.Passengername = book.Passengername;
            ticketdetail.Passengerpnumber = book.Passengerpnumber;
            ticketdetail.Emailaddress = book.Emailaddress;
            ticketdetail.Tripid = book.Tripid;
            ticketdetail.Paymodeid = book.Paymodeid;
            ticketdetail.Netamount = book.TotalAmount;
            ticketdetail.Discount = book.Discount;
            ticketdetail.Offerid = book.Offerid;
            ticketdetail.Ticketstatus = 1;

            var t = db.Ticketdetails.Add(ticketdetail);
            var t1 = db.SaveChanges();
            return View(ticketdetail);
        }
        public IActionResult ConfirmTicket(int id)
        {

            var ticketdetail = (from ticket in db.Ticketdetails
                                where ticket.Pnr == id
                                select ticket).SingleOrDefault();

            return View(ticketdetail);
        }
        public IActionResult CancelTicket(int id)
        {
            var cancelticket = (from ticket in db.Ticketdetails
                                where ticket.Pnr == id
                                select ticket).SingleOrDefault();
            cancelticket.Ticketstatus=0;
            db.Ticketdetails.Update(cancelticket);
            db.SaveChanges();
            return View("ConfirmTicket",cancelticket);
        }
    }
}
