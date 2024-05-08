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
    /// Summary:            A model class that allows the system to store data from the Donator table in the database.
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </summary>
    public class Donator
    {
        [DisplayName("Donator ID")]
        public int DonatorID { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string FamilyName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set;}

        [Required]
        public string Address { get; set; }
    }
}
