using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Kitchen
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: WeekFoodMenu data object class for storage.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class MenuMeal
    {
        public int MealID { get; set; }
        public int MenuID { get; set; }
        public int RecipeID { get; set; }
        public string EmployeeID { get; set; }
        public string Category {  get; set; }
    }

    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: Creation of the MenuMeal view model.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class MenuMealVM : MenuMeal
    {
        public WeekFoodMenu Menu { get; set; }
        public List<Recipe> Recipes { get; set; }
        public Employee Employee { get; set; }
    }
}
