using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <Summary>
    /// Creator: Ethan McElree
    /// created: 02/13/2024
    /// Summary: Creation of Schedule data objects.
    /// Last updated By: Ethan McElree
    /// Last Updated: 02/13/2024
    /// What was changed/updated: Initial Creation
    /// </Summary>
    public class Schedule
    {
        public int ScheduleID { get; set; }
        [DisplayName("Month")]
        public string ScheduleMonth { get; set; }
        [DisplayName("Week")]
        public int ScheduleWeek { get; set; }
        [DisplayName("Year")]
        public int ScheduleYear {  get; set; }
        [DisplayName("Start Date")]
        public DateTime ScheduleStartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime ScheduleEndDate { get; set; }
    }

    /// <Summary>
    /// Creator: Ethan McElree
    /// created: 02/13/2024
    /// Summary: Creation of Schedule view model.
    /// Last updated By: Ethan McElree
    /// Last Updated: 02/13/2024
    /// What was changed/updated: Initial Creation
    /// </Summary>
    public class ScheduleVM : Schedule 
    { 
    }
}
