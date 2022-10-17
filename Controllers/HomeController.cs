using AirWings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace AirWings.Controllers
{
    public class HomeController : Controller
    {
        private readonly AirWingsContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AirWingsContext _db)
        {
            _logger = logger;
            db = _db;

        }

        public IActionResult Index()
        {
            FlightSearch flightSearch = new FlightSearch();
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Login");
            }
            var CityList = (from i in db.Citydetails
                            select i).Select(x => new SelectListItem
                            {
                                Text = x.Cityname,
                                Value = x.CityId.ToString()
                            }).ToList();

            flightSearch.TravelDate = DateTime.Now;

            flightSearch.CityList = CityList;
            return View(flightSearch);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public ActionResult Search(FlightSearch Search)
        {

            var result = from Td in db.Tripdetails
                         where Td.Origin == Search.Origin && Td.Destination == Search.Destination && Td.Departuretime.Date == Search.TravelDate.Date
                         
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
                         };
            return View(result);

        }
       
        
    }
}