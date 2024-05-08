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
    /// Summary:            A model class that allows the system to store data from the DonationTaype table in the database.
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </summary>
    public class DonationType
    {
        [DisplayName("ID")]
        public int DonationTypeID { get; set; }

        [Required]
        [DisplayName("Type")]
        public string TypeName { get; set; }

    }
    public class DonationTypeVM: DonationType 
    { 
    }
}
