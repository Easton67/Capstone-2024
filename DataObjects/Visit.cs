using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Ibrahim Albashair
    /// Created: 02/10/2024
    /// Summary: Created Visit Class to hold details for Visit Table
    /// Last Updated By: Ibrahim Albashair
    /// Last Updated 02/10/2024
    /// What was changed: Initial Creation.
    /// Last Updated By: Matthew Baccam
    /// Last Updated 02/28/2024
    /// What was changed: Fixed check in and check out being string (converted them to date time)
    /// , added a status field so we know if the current visit is check in yet or not
    /// , added a method in here that returns the check in and check out in a friendlier display manner
    /// </summary>
    public class Visit
    {
        public int VisitID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DisplayName("Check In")]
        public DateTime CheckIn { get; set; }
        [DisplayName("Check Out")]
        public DateTime CheckOut { get; set; }
        [DisplayName("Visit Reason")]
        public string VisitReason { get; set; }

        public bool Status { get; set; }

        [DisplayName("Checkin Date")]
        public string GetCheckIn
        {
            get => $"{CheckIn.ToString("MMM dd")} {CheckIn.ToString("hh:mm tt")}";
        }

        [DisplayName("Checkout Date")]
        public string GetCheckOut
        {
            get => $"{CheckOut.ToString("MMM dd")} {CheckOut.ToString("hh:mm tt")}";
        }

        [DisplayName("Full Name")]
        public string Name
        {
            get => $"{FirstName} {LastName}";
        }

        [DisplayName("Visit Status")]
        public string VisitStatus
        {
            get => $"{(Status == true ? "In" : "Out")}";
        }
    }
}
