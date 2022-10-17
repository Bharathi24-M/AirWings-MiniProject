using AirWings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirWings.Controllers
{
    public class LoginController : Controller
    {
        private readonly AirWingsContext db;
        private readonly ISession session;
        public LoginController(AirWingsContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Index(Register t)
        {
            var result = (from i in db.Registers
                          where i.Username == t.Username && i.Psword == t.Psword
                          select i).SingleOrDefault();

            if (result != null)
            {
                HttpContext.Session.SetString("Username", result.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginError = "Unable to login..! Try again";
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register reg)
        {
            try
            {
                var result = (from i in db.Registers
                              where i.Username == reg.Username
                              select i).ToList();

                if (result.Count > 0)
                {
                    ViewBag.Registrationstatus = "User already exists..!";
                    return View();
                }
                var t = db.Registers.Add(reg);
                var t1 = db.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.Registrationstatus = "Unable to process..!";
                return View();
            }
            ViewBag.Registrationstatus = "User registration successful..!";
            return View();
        }

    }
}
