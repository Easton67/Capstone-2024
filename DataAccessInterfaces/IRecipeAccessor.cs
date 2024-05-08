using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects.Kitchen;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/31/2024
    /// Summary: Creation of the Recipe access interface.
    /// Last Updated By: Ethan McElree
    /// Last Updated 03/18/2024
    /// What was changed: Added SelectRecipesByCategory.
    /// </summary>
    public interface IRecipeAccessor
    {
        int InsertRecipe(Recipe recipe);
        int deleteRecipeByName(string recipeName);
        List<RecipeVM> SelectRecipes();
        List<RecipeVM> SelectRecipesByCategory(string category);
        Recipe GetRecipeDetailsAndInstructionsByRecipeID(int recipeID);
    }
}
