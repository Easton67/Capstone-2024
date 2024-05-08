using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataObjects.Kitchen;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/31/2024
    /// Summary: Creation of the WeekFoodMenu access interface.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/05/2024
    /// What Was Changed: Added two more methods
    /// </summary>
    public interface IWeekFoodMenuAccessor
    {
        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Creation of the InsertFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        int InsertFoodMenu(string DayOfMeal, string MenuName, string MenuType, DateTime DateLastModified);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Creation of the InsertFoodItemIntoMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        int InsertFoodItemIntoMenu(int MenuID, int RecipeID, string EmployeeID, string Category);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Creation of the getMenuMeals method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<MenuMealVM> getMenuMeals(int menuID);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Creation of the getWeekFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        WeekFoodMenuVM getWeekFoodMenu(int menuID);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Creation of the InsertNewRecipeForMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 01/31/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        int InsertNewRecipeForMenu(RecipeVM recipe);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/27/2024
        /// Summary: Creation of the getMenuIDs method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/27/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<int> getMenuIDs();

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/19/2024
        /// Summary: Creation of the getWeekFoodMenus accessor interface method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<WeekFoodMenuVM> getWeekFoodMenus();
    }
}
