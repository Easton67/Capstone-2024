using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/08/2024
    ///Summary:            This is the model class for maintenance requests.
    ///Last Updated By:    Jared Harvey
    ///Last Updated:       03/03/2024
    ///What Was Changed:   Changed naming scheme to follow what everyone else has been using
	///Last Updated By:    Liam Easton
    ///Last Updated:       03/15/2024
    ///What Was Changed:   Added display names
    /// </summary>
    public class MaintenanceRequest
    {
		[DisplayName("Request ID")]
        public int _requestID { get; set; }
		[DisplayName("Room ID")]
        public int _roomID { get; set; }
        [DisplayName("Urgency:")]
        public string _urgency { get; set; }
        [DisplayName("Status:")]
        public string _status { get; set; }
		[DisplayName("Requester:")]
        public string _requestor { get; set; } // british spelling innit
		[DisplayName("Phone Number:")]
        public string _phone { get; set; }
		[DisplayName("Date Created:")]
        public DateTime _dateCreated { get; set; }
        [DisplayName("Description:")]
        public string _description { get; set; }
	}
}
