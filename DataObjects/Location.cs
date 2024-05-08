using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: Created Location data class to hold appropriate
    /// data regarding the Location objects.
    /// Last Updated By: Andrew Larson
    /// Last Updated 01/29/2024
    /// What was changed: Initial Creation.
    /// </summary>
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName {  get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public List<HoursOfOperation> HoursOfOperation { get; set; }
    }
}
