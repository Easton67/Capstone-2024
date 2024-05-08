using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Abdalgader Ibrahim
    /// Created:            02/06/2024
    /// Summary:            A model class that allows the system to store data from the Donation table in the database.
    /// </summary>
    public class Donation
    {
        public int DonationID { get; set; }
        public int DonationTypeID { get; set; }
        public int? DonatorID { get; set; }
        [DisplayName("Donator")]
        public string DonationName { get; set; }
        public string Amount { get; set; }
        [DisplayName("Date")]
        public DateTime DonationDate { get; set; }
        public bool Active { get; set; }
    }

    public class DonationVM : Donation
    {
        public DonationType type  { get; set; }
        public Donator donators { get; set; }
    }
}
