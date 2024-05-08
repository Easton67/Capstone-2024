using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/1/2024
    /// Summary: Creation of the WeekFoodMenuManager class.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/05/2024
    /// What Was Changed: Added getMenuMeals and getWeekFoodMenu.
    /// </summary>
    public class WeekFoodMenuManager : IWeekFoodMenuManager
    {
        private IWeekFoodMenuAccessor _weekFoodMenuAccessor;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the Constructor method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public WeekFoodMenuManager()
        {
            _weekFoodMenuAccessor = new WeekFoodMenuAccessor();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the second Constructor with parameters.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public WeekFoodMenuManager(IWeekFoodMenuAccessor weekFoodMenuAccessor)
        {
            _weekFoodMenuAccessor = weekFoodMenuAccessor;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the WeekFoodMenuManager class.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public List<MenuMealVM> getMenuMeals(int menuID)
        {
            List<MenuMealVM> menuMeals = new List<MenuMealVM>();
            try
            {
                menuMeals = _weekFoodMenuAccessor.getMenuMeals(menuID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No meals found", ex);
            }
            return menuMeals;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the WeekFoodMenuManager class.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public WeekFoodMenuVM getWeekFoodMenu(int menuID)
        {
            WeekFoodMenuVM foodMenu = new WeekFoodMenuVM();
            try
            {
                foodMenu = _weekFoodMenuAccessor.getWeekFoodMenu(menuID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No food menus found", ex);
            }
            return foodMenu;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/27/2024
        /// Summary: Creation of the getMenuIDs method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/27/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public List<int> getMenuIDs()
        {
            List<int> menuIDs = new List<int>();
            try
            {
                menuIDs = _weekFoodMenuAccessor.getMenuIDs();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't retrieve list of menu ids", ex);
            }
            return menuIDs;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the InsertFoodItemIntoMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public int InsertFoodItemIntoMenu(int MenuID, int RecipeID, string EmployeeID, string Category)
        {
            int rows = 0;
            try
            {
                rows = _weekFoodMenuAccessor.InsertFoodItemIntoMenu(MenuID, RecipeID, EmployeeID, Category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't insert food item into menu", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the InsertFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public int InsertFoodMenu(string DayOfMeal, string MenuName, string MenuType, DateTime DateLastModified)
        {
            int rows = 0;
            try
            {
                rows = _weekFoodMenuAccessor.InsertFoodMenu(DayOfMeal, MenuName, MenuType, DateLastModified);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't insert food menu", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the InsertNewRecipeForMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public int InsertNewRecipeForMenu(RecipeVM recipe)
        {
            int rows = 0;
            try
            {
                rows = _weekFoodMenuAccessor.InsertNewRecipeForMenu(recipe);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't insert recipe for the menu", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/19/2024
        /// Summary: Creation of the getWeekFoodMenus manager method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/19/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public List<WeekFoodMenuVM> getWeekFoodMenus()
        {
            List<WeekFoodMenuVM> rows = new List<WeekFoodMenuVM>();
            try
            {
                rows = _weekFoodMenuAccessor.getWeekFoodMenus();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get all food menus.", ex);
            }
            return rows;
        }
    }
}
