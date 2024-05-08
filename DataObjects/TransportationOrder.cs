using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Liam Easton
    /// Created:            04/03/2024
    /// Summary:            Initial creation of the TransportationOrder DataObject.
    /// Last Updated By:    Liam Easton
    /// Last Updated:       04/03/2024
    /// What Was Changed:   Initial creation of the TransportationOrder DataObject.
    /// </summary>
    public class TransportationOrder
    {
		public int TransportItemID { get; set; }
        public string ClientID { get; set; }
        public int LocationID { get; set; }
        [DisplayName("Day Posted")]
        public DateTime DayPosted { get; set; }
        [DisplayName("Day To Pick Up")]
        public DateTime DayToPickUp { get; set; }
        [DisplayName("Day Dropped Off")]
        public DateTime? DayDroppedOff { get; set; }
        [DisplayName("Driver")]
        public string AssignedDriver { get; set; }
        public bool Fulfilled { get; set; }
    }
    /// <summary>
    /// Creator:            Liam Easton
    /// Created:            04/03/2024
    /// Summary:            Initial creation of the TransportationOrderVM DataObject.
    /// Last Updated By:    Liam Easton
    /// Last Updated:       04/03/2024
    /// What Was Changed:   Initial creation of the TransportationOrderVM DataObject.
    /// </summary>
    public class TransportationOrderVM : TransportationOrder
    {
        public int TransportLineID { get; set; }
        [DisplayName("Amount")]
        public decimal LineItemAmount { get; set; }
        public string Vendor { get; set; }
        [DisplayName("Item")]
        public string TransportItem { get; set; }
        public string Location { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
    }
}
