using DataAccessFakes;
using DataAccessInterfaces;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DataObjects;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/13/2024
    /// Summary: All the test methods for RecipeIngredientsManagerTests 
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/13/2024
    /// What was changed: Initial Creation
    /// </summary>
    [TestClass]
    public class RecipeIngredientsManagerTests
    {
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Tests if a valid list of RecipesIngredients(with at least one recipe)
        /// has a count of at least 1.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void CheckRecipeIngredientsListIsNotNullWithValidRecipeID()
        {
            IRecipeIngredientsAccessor accessor = new RecipeIngredientsAccessorFakes();
            IRecipeIngredientsManager manager = new RecipeIngredientsManager(accessor);
            int validRecipeID = 1;

            List<RecipeIngredients> ingredientsList = manager.GetIngredientsByRecipeID(validRecipeID);

            Assert.IsNotNull(ingredientsList);
            Assert.IsTrue(ingredientsList.Count > 0);
            Assert.IsFalse(ingredientsList == null);
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Tests the exception being thrown assuming an invalid RecipeID
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CheckRecipeIngredientsListThrowsExceptionWithInvalidRecipeID()
        {
            IRecipeIngredientsAccessor accessor = new RecipeIngredientsAccessorFakes();
            IRecipeIngredientsManager manager = new RecipeIngredientsManager(accessor);
            int invalidRecipeID = -1;

            List<RecipeIngredients> ingredientsList = manager.GetIngredientsByRecipeID(invalidRecipeID);
        }

        /// <summary>
        /// Creator:            Matthew Baccam
        /// Created:            04/24/2024
        /// Summary:            Creation test
        /// Last Updated By:    Matthew Baccam
        /// Last Updated:       04/24/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void CreateIngredientTest()
        {
            IRecipeIngredientsAccessor accessor = new RecipeIngredientsAccessorFakes();
            IRecipeIngredientsManager manager = new RecipeIngredientsManager(accessor);
            var ingredients = new List<RecipeIngredients>();
            var ingredient = new RecipeIngredients()
            {
                IngredientID = "Test Ingredient 1",
                RecipeID = 1
            };
            var result = manager.CreateNewIngredient(ingredient);
            Assert.IsTrue(result);
        }
    }
}
