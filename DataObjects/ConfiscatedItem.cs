using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    //<Summary>
    //Creator: Andrew Larson
    //created: 04/07/2024
    //Summary: Data object for confiscated items.
    //Last updated By: Andrew Larson
    //Last Updated: 4/07/2024
    //What was changed/updated: Initial Creation
    //</Summary>
    public class ConfiscatedItem
    {
        public int LogConfiscatedItemsID {  get; set; }
        public string ItemsConfiscated { get; set; }
        public DateTime ConfiscationDate { get; set; }
        public string ReasonForConfiscation { get; set; }
    }
}
