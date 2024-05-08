using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/13/2024
    /// Summary: The RecipeIngredientsAccessorFakes class holds all the fake data
    /// for testing purposes.
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/13/2024
    /// What was changed: Initial Creation
    /// </summary>
    public class RecipeIngredientsAccessorFakes : IRecipeIngredientsAccessor
    {
        private List<RecipeIngredients> _fakeRecipeIngredients = new List<RecipeIngredients>();


        public RecipeIngredientsAccessorFakes() 
        {
            _fakeRecipeIngredients.Add(new RecipeIngredients()
            {
                IngredientID = "Test Ingredient 1",
                RecipeID = 1
            }); ;
            _fakeRecipeIngredients.Add(new RecipeIngredients()
            {
                IngredientID = "Test Ingredient 2",
                RecipeID = 1
            }); ;
            _fakeRecipeIngredients.Add(new RecipeIngredients()
            {
                IngredientID = "Test Ingredient 2",
                RecipeID = 1
            }); ;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: The GetIngredientsByRecipeID method retrieves all
        ///          ingredients from a specified recipe.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<RecipeIngredients> GetIngredientsByRecipeID(int recipeID)
        {
            List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
            for (int i = 0; i < _fakeRecipeIngredients.Count; i++)
            {
                if (_fakeRecipeIngredients[i].RecipeID == recipeID)
                {
                    recipeIngredients.Add(_fakeRecipeIngredients[i]);
                }
            }
            if (recipeIngredients.Count == 0)
            {
                throw new ApplicationException("Bad RecipeID");
            }
            return recipeIngredients;
        }

        /// <summary>
        /// Creator:            Matthew Baccam
        /// Created:            04/24/2024
        /// Summary:            Creation fake
        /// Last Updated By:    Matthew Baccam
        /// Last Updated:       04/24/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool InsertNewIngredient(RecipeIngredients ingredient)
        {
            var expectedAmount = 1 + _fakeRecipeIngredients.Count;

            _fakeRecipeIngredients.Add (ingredient);

            return expectedAmount == _fakeRecipeIngredients.Count;
        }
    }
}
