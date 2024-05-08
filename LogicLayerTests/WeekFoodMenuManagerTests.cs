using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/1/2024
    /// Summary: Test class for the WeekFoodMenu unit test methods.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/05/2024
    /// What Was Changed: Removed MenuID from the insert new food menu test methods.
    /// </summary>
    [TestClass]
    public class WeekFoodMenuManagerTests
    {
        IWeekFoodMenuManager _weekFoodMenuManager = null;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the TestSetUp method for the week food menu manager.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestInitialize]
        public void TestSetUp()
        {
            _weekFoodMenuManager = new WeekFoodMenuManager(new WeekFoodMenuAccessorFakes());
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/1/2024
        /// Summary:            Creation of test method to successfully insert a new food menu
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyInsertedNewFoodMenu()
        {
            // Arrange
            string DayOfMeal = "Monday";
            string MenuName = "Breakfast Menu";
            string MenuType = "Breakfast";
            DateTime DateLastModified = DateTime.Now;

            // Act
            int rows = _weekFoodMenuManager.InsertFoodMenu(DayOfMeal, MenuName, MenuType, DateLastModified);

            // Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/1/2024
        /// Summary:            Creation of test method to fail to insert a new food menu
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToInsertNewFoodMenu()
        {
            // Arrange
            string DayOfMeal = "Monday";
            string MenuName = "Breakfast Menu";
            string MenuType = "Breakfast";
            DateTime DateLastModified = DateTime.Now;

            // Act
            int rows = _weekFoodMenuManager.InsertFoodMenu(DayOfMeal, MenuName, MenuType, DateLastModified);

            // Assert
            Assert.AreNotEqual(0, rows);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/19/2024
        /// Summary:            Test method that successfully get all menus
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyGetAllMenus()
        {
            // Arrange
            List<WeekFoodMenuVM> actualMenus = new List<WeekFoodMenuVM>();

            // Act
            actualMenus = _weekFoodMenuManager.getWeekFoodMenus();

            // Assert
            Assert.AreEqual(actualMenus.Count, 3);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/19/2024
        /// Summary:            Test method that successfully get all menus
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToGetAllMenus()
        {
            // Arrange
            List<WeekFoodMenuVM> actualMenus = new List<WeekFoodMenuVM>();

            // Act
            actualMenus = _weekFoodMenuManager.getWeekFoodMenus();

            // Assert
            Assert.AreNotEqual(actualMenus.Count, 0);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/27/2024
        /// Summary:            Creation of test method to successfully get all menu ids
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyGetAllMenuIDs()
        {
            // Arrange
            List<int> expectedMenuIDs = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            List<int> actualMenuIDs = _weekFoodMenuManager.getMenuIDs();

            // Assert
            CollectionAssert.AreEqual(expectedMenuIDs, actualMenuIDs);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/27/2024
        /// Summary:            Creation of test method to successfully get all menu ids
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToGetAllMenuIDs()
        {
            // Arrange
            List<int> expectedMenuIDs = new List<int> { 6, 7, 8, 9, 10 };

            // Act
            List<int> actualMenuIDs = _weekFoodMenuManager.getMenuIDs();

            // Assert
            CollectionAssert.AreNotEqual(expectedMenuIDs, actualMenuIDs);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/1/2024
        /// Summary:            Creation of test method to successfully insert a menu meal
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyInsertedMenuMeal()
        {
            // Arrange
            int MenuID = 1;
            int RecipeID = 10000;
            string EmployeeID = "Carl";
            string Category = "Breakfast";

            // Act
            int rows = _weekFoodMenuManager.InsertFoodItemIntoMenu(MenuID, RecipeID, EmployeeID, Category);

            // Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/1/2024
        /// Summary:            Creation of test method to fail to insert a menu meal
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToInsertMenuMeal()
        {
            // Arrange
            int MenuID = 1;
            int RecipeID = 10000;
            string EmployeeID = "Carl";
            string Category = "Breakfast";

            // Act
            int rows = _weekFoodMenuManager.InsertFoodItemIntoMenu(MenuID, RecipeID, EmployeeID, Category);

            // Assert
            Assert.AreNotEqual(0, rows);
        }
    }
}
