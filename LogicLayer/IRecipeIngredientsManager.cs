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
    /// Summary: This interface for RecipeIngredientsManager lists 
    /// the required methods to be implemented.
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/12/2024
    /// What was changed: Added GetIngredientsByRecipeID for the Details/Instructions button.
    /// </summary>
    public interface IRecipeIngredientsManager
    {
        bool CreateNewIngredient(RecipeIngredients ingredient);
        List<RecipeIngredients> GetIngredientsByRecipeID(int recipeID);
    }
}
