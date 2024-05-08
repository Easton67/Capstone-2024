using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: This class represents the resources needed by our shelters.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary> 

    public class ResourcesNeeded
    {
        public string ResourceID { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
    }
}
