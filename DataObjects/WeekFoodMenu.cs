using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: WeekFoodMenu data object class for storage.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class WeekFoodMenu
    {
        public int MenuID { get; set; }
        public string DayOfMeal { get; set; }
        public string MenuName { get; set; }
        public string MenuType { get; set; }
        public DateTime DateLastModified { get; set; }
    }

    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: Creation of the WeekFoodMenu view model.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/06/2024
    /// What Was Changed: Added a recipe list.
    /// </summary>
    public class WeekFoodMenuVM : WeekFoodMenu
    {
        public List<Recipe> recipes {  get; set; }
    }
}
