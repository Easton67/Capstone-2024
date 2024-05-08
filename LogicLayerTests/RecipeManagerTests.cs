using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects.Kitchen;
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
    /// Summary: Test class for the Recipe unit test methods.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/1/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class RecipeManagerTests
    {
        IRecipeManager _recipeManager = null;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the TestSetUp method for recipe manager.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestInitialize]
        public void TestSetUp()
        {
            _recipeManager = new RecipeManager(new RecipeAccessorFakes());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the test method that successfully retrieves a recipe.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyRetrieveRecipes()
        {
            // Act
            List<RecipeVM> recipes = _recipeManager.GetRecipes();

            // Assert
            Assert.AreEqual(3, recipes.Count);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the test method that fails to retrieve a recipe.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToRetrieveRecipes()
        {
            // Act
            List<RecipeVM> recipes = _recipeManager.GetRecipes();

            // Assert
            Assert.AreNotEqual(0, recipes.Count);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/18/2024
        /// Summary: Creation of the test method that successfully filters the recipes by a category.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyRetrieveRecipesByCategory()
        {
            // Act
            List<RecipeVM> recipes = _recipeManager.SelectRecipesByCategory("Birthday");

            // Assert
            Assert.AreEqual(1, recipes.Count);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/18/2024
        /// Summary: Creation of the test method that fails to filter the recipes by a category.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToRetrieveRecipesByCategory()
        {
            // Act
            List<RecipeVM> recipes = _recipeManager.SelectRecipesByCategory("Birthday");

            // Assert
            Assert.AreNotEqual(0, recipes.Count);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/20/2024
        /// Summary: Creation of the test method that tests if it successfully removes a recipe.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyRemovingRecipe()
        {
            // Act
            int rows = _recipeManager.deleteRecipeByName("Garbage");

            // Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/20/2024
        /// Summary: Creation of the test method that tests if it fails to removes a recipe.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToRemovARecipe()
        {
            // Act
            int rows = _recipeManager.deleteRecipeByName("Fresh");

            // Assert
            Assert.AreNotEqual(1, rows);
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/05/2024
        /// Summary: Tests if a valid list of Recipes(with at least one recipe)
        /// has a count of 1
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/05/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void CheckRecipeListIsNotNullWhenValidRecipesExist()
        {
            IRecipeAccessor fakeAccessor = new RecipeAccessorFakes();
            IRecipeManager recipeManager = new RecipeManager(fakeAccessor);

            List<RecipeVM> recipes = recipeManager.GetRecipes();


            Assert.IsNotNull(recipes);
        }


        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/05/2024
        /// Summary: Tests exact count of Recipes against the corresponding
        /// correct number, and a corresponding incorrect number.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/05/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void CheckRecipeListCountEqualsActualCountOfRecipes()
        {
            IRecipeAccessor fakeAccessor = new RecipeAccessorFakes();
            IRecipeManager recipeManager = new RecipeManager(fakeAccessor);

            List<RecipeVM> recipes = recipeManager.GetRecipes();


            Assert.AreEqual(3, recipes.Count);
            Assert.AreNotEqual(10, recipes.Count);
        }


        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/05/2024
        /// Summary: Tests exact count of Recipes against the corresponding
        /// correct number, and a corresponding incorrect number.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/05/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void CheckIndividualValuesInRecipeList()
        {
            List<Recipe> testRecipes = new List<Recipe>();
            Recipe recipe1 = new Recipe
            {                
                RecipeID = 1,
                RecipeName = "Garbage",
                RecipeDescription = "Do not eat this",
                Calories = 0,
                Allergens = "Nothing at all",
                Vegen = false,
                PrepTime = 0,
                MenuID = 1,
                Category = "Holiday",
                KitchenItemID = 1,
            };
            testRecipes.Add(recipe1);


            IRecipeAccessor fakeAccessor = new RecipeAccessorFakes();
            IRecipeManager recipeManager = new RecipeManager(fakeAccessor);

            List<RecipeVM> recipes = recipeManager.GetRecipes();

            Assert.AreEqual(testRecipes[0].RecipeID, recipes[0].RecipeID);
            Assert.AreEqual(testRecipes[0].RecipeName, recipes[0].RecipeName);
            Assert.AreEqual(testRecipes[0].RecipeDescription, recipes[0].RecipeDescription);
            Assert.AreEqual(testRecipes[0].Calories, recipes[0].Calories);
            Assert.AreEqual(testRecipes[0].Allergens, recipes[0].Allergens);
            Assert.AreEqual(testRecipes[0].Vegen, recipes[0].Vegen);
            Assert.AreEqual(testRecipes[0].MenuID, recipes[0].MenuID);
            Assert.AreEqual(testRecipes[0].Category, recipes[0].Category);
            Assert.AreEqual(testRecipes[0].KitchenItemID, recipes[0].KitchenItemID);
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Making sure Recipe isn't null when a valid RecipeID
        ///          is used.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void CheckRecipeIsNotNullWithValidRecipeID()
        {
            IRecipeAccessor accessor = new RecipeAccessorFakes();
            IRecipeManager manager = new RecipeManager(accessor);
            int validRecipeID = 1;

            Recipe recipe = manager.GetRecipeDetailsAndInstructionsByRecipeID(validRecipeID);

            Assert.IsNotNull(recipe);
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Making sure exception is being thrown when RecipeID
        ///          is invalid.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CheckRecipeThrowsExceptionWithInvalidRecipeID()
        {
            IRecipeAccessor accessor = new RecipeAccessorFakes();
            IRecipeManager manager = new RecipeManager(accessor);
            int invalidRecipeID = -1;

            Recipe recipe = manager.GetRecipeDetailsAndInstructionsByRecipeID(invalidRecipeID);
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Checking exact values against hard coded values.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void CheckRecipeImageAndStepsWithValidRecipeID()
        {
            IRecipeAccessor accessor = new RecipeAccessorFakes();
            IRecipeManager manager = new RecipeManager(accessor);
            int validRecipeID = 1;
            string expectedImage = "TestImage1";
            string expectedSteps = "Recipe1Steps";

            Recipe recipe = manager.GetRecipeDetailsAndInstructionsByRecipeID(validRecipeID);

            Assert.IsNotNull(recipe);
            Assert.AreEqual(expectedSteps, recipe.RecipeSteps);
            Assert.AreEqual(expectedImage, recipe.RecipeImage);
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Tests the create recipe 
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        [TestMethod]
        public void CreateRecipeTest()
        {
            var testRecipe = new Recipe()
            {
                RecipeID = 0,
                RecipeName = "Test",
                RecipeDescription = "Test",
                Calories = 0,
                Allergens = "test",
                Vegen = false,
                Category = "Test",
                RecipeImage = "Test"
            };

            var actualResult = _recipeManager.CreateRecipe(testRecipe);

            Assert.AreEqual(actualResult, testRecipe.RecipeID);
        }
    }
}
