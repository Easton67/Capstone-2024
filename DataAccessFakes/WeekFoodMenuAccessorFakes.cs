using DataAccessInterfaces;
using DataObjects;
using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/1/2024
    /// Summary: Creation of the fake week food menu data for the unit tests.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/1/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class WeekFoodMenuAccessorFakes : IWeekFoodMenuAccessor
    {
        public List<WeekFoodMenuVM> fakeMenus = new List<WeekFoodMenuVM>();
        public List<MenuMealVM> fakeMeals = new List<MenuMealVM>();

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the WeekFoodMenuAccessorFakes method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public WeekFoodMenuAccessorFakes() 
        {
            fakeMenus.Add(new WeekFoodMenuVM()
            {
                MenuID = 1,
                DayOfMeal = "Well",
                MenuName = "FakeMenu",
                MenuType = "Birthday",
                DateLastModified = DateTime.MaxValue
            });

            fakeMenus.Add(new WeekFoodMenuVM()
            {
                MenuID = 2,
                DayOfMeal = "Never",
                MenuName = "FakeMenuTwo",
                MenuType = "Holiday",
                DateLastModified = DateTime.MaxValue
            });

            fakeMenus.Add(new WeekFoodMenuVM()
            {
                MenuID = 3,
                DayOfMeal = "Forever",
                MenuName = "FakeMenuThree",
                MenuType = "Ceremony",
                DateLastModified = DateTime.MaxValue
            });
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the getMenuMeals method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<MenuMealVM> getMenuMeals(int menuID)
        {
            return fakeMeals;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the getWeekFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public WeekFoodMenuVM getWeekFoodMenu(int menuID)
        {
            foreach (var weekFoodMenu in fakeMenus)
            {
                if(weekFoodMenu.MenuID == menuID)
                {
                    return weekFoodMenu;
                }
            }
            return null;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the InsertFoodItemIntoMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertFoodItemIntoMenu(int MenuID, int RecipeID, string EmployeeID, string Category)
        {
            fakeMeals.Add(new MenuMealVM()
            {
                MenuID = MenuID,
                RecipeID = RecipeID,
                EmployeeID = EmployeeID,
                Category = Category
            });
            return 1;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the InsertNewRecipeForMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertNewRecipeForMenu(RecipeVM recipe)
        {
            return 1;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the InsertFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertFoodMenu(string DayOfMeal, string MenuName, string MenuType, DateTime DateLastModified)
        {
            fakeMenus.Add(new WeekFoodMenuVM()
            {
                DayOfMeal = DayOfMeal,
                MenuName = MenuName,
                MenuType = MenuType,
                DateLastModified = DateLastModified
            });
            return 1;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/27/2024
        /// Summary: Get the menu IDs.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/27/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<int> getMenuIDs()
        {
            return new List<int> { 1, 2, 3, 4, 5 };
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/19/2024
        /// Summary: Accessor fake method for getting all week food menus.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<WeekFoodMenuVM> getWeekFoodMenus()
        {
            return fakeMenus;
        }
    }
}
