using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/12/2024
    /// Summary: This is the manager class for RecipeIngredients.
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/12/2024
    /// What was changed: Initial Creation
    /// </summary> 
    public class RecipeIngredientsManager : IRecipeIngredientsManager
    {
        private IRecipeIngredientsAccessor _recipeIngredientsAccessor = null;

        public RecipeIngredientsManager() 
        {
            _recipeIngredientsAccessor = new RecipeIngredientsAccessor();
        }

        public RecipeIngredientsManager(IRecipeIngredientsAccessor recipeIngredientsAccessor)
        {
            _recipeIngredientsAccessor = recipeIngredientsAccessor;
        }


        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            02/13/2024
        /// Summary:            Creation of GetIngredientsByRecipeID method
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of GetIngredientsByRecipeID method
        /// </summary>
        public List<RecipeIngredients> GetIngredientsByRecipeID(int recipeID)
        {
            List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
            try
            {
                recipeIngredients = _recipeIngredientsAccessor.GetIngredientsByRecipeID(recipeID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to find recipe ingredients. ", ex);
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
        public bool CreateNewIngredient(RecipeIngredients ingredient)
        {
            var result = false;
            try
            {
                result = _recipeIngredientsAccessor.InsertNewIngredient(ingredient);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}
