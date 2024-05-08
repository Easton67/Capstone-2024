using DataAccessInterfaces;
using DataAccessLayer;
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
    /// Summary: Creation of the RecipeManager class.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 03/18/2024
    /// What Was Changed: Created the SelectRecipesByCategory method.
    /// </summary>
    public class RecipeManager : IRecipeManager
    {
        private IRecipeAccessor _recipeAccessor = null;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the Recipe Constructor.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public RecipeManager()
        {
            _recipeAccessor = new RecipeAccessor();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the second Recipe Constructor with parameters.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public RecipeManager(IRecipeAccessor recipeAccessor)
        {
            _recipeAccessor = recipeAccessor;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/19/2024
        /// Summary: Creation of the deleteRecipeByName method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int deleteRecipeByName(string recipeName)
        {
            int rows = 0;
            try
            {
                rows = _recipeAccessor.deleteRecipeByName(recipeName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't delete recipe", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the GetRecipes method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RecipeVM> GetRecipes()
        {
            List<RecipeVM> recipe = new List<RecipeVM>();
            try
            {
                recipe = _recipeAccessor.SelectRecipes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't get recipes", ex);
            }
            return recipe;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/18/2024
        /// Summary: Creation of the SelectRecipesByCategory method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RecipeVM> SelectRecipesByCategory(string category)
        {
            List<RecipeVM> recipe = new List<RecipeVM>();
            try
            {
                recipe = _recipeAccessor.SelectRecipesByCategory(category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't get recipes in that category", ex);
            }
            return recipe;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: GetRecipeDetailsAndInstructionsByRecipeID retrieves
        ///          all the details and instructions for a specific recipe
        /// recipes from the database.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        public Recipe GetRecipeDetailsAndInstructionsByRecipeID(int recipeID)
        {
            Recipe recipe = null;

            try
            {
                recipe = _recipeAccessor.GetRecipeDetailsAndInstructionsByRecipeID(recipeID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to find recipe details and instructions. ", ex);
            }
            return recipe;
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        public int CreateRecipe(Recipe recipe)
        {
            try
            {
                return _recipeAccessor.InsertRecipe(recipe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
