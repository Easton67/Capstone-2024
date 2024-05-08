using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Sagan Dewald
    /// Created:            03/29/2024
    /// Summary:            Data object for Client Priority.
    /// Last Updated By:    Sagan DeWald
    /// Last Updated:       03/29/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class ClientPriority
    {
        public int ClientPriorityID { get; set; }
        public string Client { get; set; }
        public int BasePriority { get; set; }
        public int Deductions { get; set; }
        public string NotableConvictions { get; set; }
        public string OtherHousingSituation { get; set; }
    }
}
