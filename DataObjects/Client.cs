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
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </summary>

    public class Client : User
    {
        //public string ShelterID { get; set; }
        [Required]
        public string Accomadations { get; set; }
        public int ClientPriority { get; set; }

        #region Date Properties

        [Required]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Exit Date")]
        public DateTime? ExitDate { get; set; }

        [DisplayName("Date Registered")]
        public string DisplayDate => RegistrationDate.ToShortDateString();
        #endregion
    }

    /// <summary>
    /// Last Updated By:    Matthew Baccam
    /// Last Updated:       03/24/2024
    /// What Was Changed:   initial creation of the ClientVM
    /// </summary>
    public class ClientVM : Client
    {
        public StayVM Stay { get; set; }
        public Room Room { get; set; }
    }

}


