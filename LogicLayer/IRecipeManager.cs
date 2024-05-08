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
    /// Summary: Creation of the IRecipeManagerClass.
    /// Last Updated By: Ethan McElree
    /// Last Updated 03/18/2024
    /// What was changed: Added the SelectRecipesByCategory method.
    /// </summary>
    public interface IRecipeManager
    {
        int CreateRecipe(Recipe recipe);
        int deleteRecipeByName(string recipeName);
        List<RecipeVM> GetRecipes();
        List<RecipeVM> SelectRecipesByCategory(string category);
        Recipe GetRecipeDetailsAndInstructionsByRecipeID(int recipeID);
    }
}
