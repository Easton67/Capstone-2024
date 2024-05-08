using System;
using DataObjects;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MvcPresentation.Models
{
    public class DonationVM
    {
        public int DonationID { get; set; }
        public int DonationTypeID { get; set; }
        public int DonatorID { get; set; }
        [DisplayName("Donator")]
        public string DonationName { get; set; }
        public string Amount { get; set; }
        public DateTime DonationDate { get; set; }
        public bool Active { get; set; }
        public string donationType { get; set; }
    }
}