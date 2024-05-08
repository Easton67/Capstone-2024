using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects {

    /// <summary>
    /// Creator:            Jared Harvey
    /// Created:            02/19/2024
    /// Summary:            Creation of Stay class
    /// Last Updated By:    Jared Harvey
    /// Last Updated:       02/19/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class Stay {
        public int StayID { get; set; }
        [Required]
        [DisplayName("Client Email")]
        public string ClientID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        public DateTime InDate { get; set; }
        [Required]
        public DateTime OutDate { get; set; }
        [Required]
        public bool CheckedOut { get; set; }
    }

    /// <summary>
    /// Creator:            Jared Harvey
    /// Created:            02/19/2024
    /// Summary:            Creation of StayVM class
    /// Last Updated By:    Jared Harvey
    /// Last Updated:       02/19/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class StayVM : Stay {
        [DisplayName("Room #")]
        public int RoomNumber { get; set; }
    }
}
