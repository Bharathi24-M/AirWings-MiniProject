using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AirWings.Models
{
    public partial class Register
    {
        public int Regid { get; set; }
        public string Username { get; set; } = null!;
       
        [Display(Name = "Password")]
        public string Psword { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
