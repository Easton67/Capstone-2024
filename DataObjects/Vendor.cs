using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{

    /// <summary>
    /// Creator:            Mitchell Stirmel
    /// Created:            02/13/2024
    /// Summary:            Class used to represent a Vendor in the Homeless Shelter.
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </summary>
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name {  get; set; }
        public string ContactName {  get; set; }
        public string Address {  get; set; }
        public string PhoneNumber { get; set; }
        public string Email {  get; set; }
    }
}
