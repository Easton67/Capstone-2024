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
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: Created HoursOfOperation data class to hold appropriate
    /// data regarding the Location objects.
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </summary>
    public class HoursOfOperation
    {
        [DisplayName("ID")]
        public int HoursOfOperationID { get; set; }
        [Required]
        [DisplayName("Hours of Opertaion")]
        public string HoursOfOperationString { get; set; }
        [Required]
        [DisplayName("Location ID")]
        public int LocationID { get; set; }
        public Location location { get; set; }

    }
}
