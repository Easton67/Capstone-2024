using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/12/2024
    /// Summary: This data access interface for RecipeIngredientsManager
    /// lists the required methods to be implemented in the data access.
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/12/2024
    /// What was changed: Initial Creation
    /// </summary>
    public interface IRecipeIngredientsAccessor
    {
        bool InsertNewIngredient(RecipeIngredients ingredient);
        List<RecipeIngredients> GetIngredientsByRecipeID(int recipeID);
    }
}
