using DataAccessInterfaces;
using DataObjects;
using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/1/2024
    /// Summary: Creation of the fake recipe data for the unit tests.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/1/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RecipeAccessorFakes : IRecipeAccessor
    {
        public List<RecipeVM> _recipeVM = new List<RecipeVM>();

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/01/2024
        /// Summary: Creation of the RecipeAccessorFakes method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public RecipeAccessorFakes()
        {
            _recipeVM.Add(new RecipeVM()
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
                RecipeImage = "TestImage1",
                RecipeSteps = "Recipe1Steps"
            });

            _recipeVM.Add(new RecipeVM()
            {
                RecipeID = 2,
                RecipeName = "Trash",
                RecipeDescription = "This will make you sick",
                Calories = 5,
                Allergens = "Lots",
                Vegen = true,
                PrepTime = 2,
                MenuID = 2,
                Category = "Ceremony",
                KitchenItemID = 2,
                RecipeImage = "TestImage2",
                RecipeSteps = "Recipe2Steps"
            });

            _recipeVM.Add(new RecipeVM()
            {
                RecipeID = 3,
                RecipeName = "Junk",
                RecipeDescription = "You won't like this",
                Calories = 3,
                Allergens = "Undetermined",
                Vegen = false,
                PrepTime = 1,
                MenuID = 3,
                Category = "Birthday",
                KitchenItemID = 3,
                RecipeImage = "TestImage3",
                RecipeSteps = "Recipe3Steps"
            });
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/19/2024
        /// Summary: Creation of the delete recipe fake data method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int deleteRecipeByName(string recipeName)
        {
            foreach (var recipe in _recipeVM)
            {
                if (recipeName.Equals(recipe.RecipeName))
                {
                    _recipeVM.Remove(recipe);
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/01/2024
        /// Summary: Creation of the SelectRecipes method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RecipeVM> SelectRecipes()
        {
            return _recipeVM;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/06/2024
        /// Summary: Returns the list of fake recipes.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/06/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<RecipeVM> GetAllRecipes()
        {
            return _recipeVM;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Gets all details and instructions for a specified recipe.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        public Recipe GetRecipeDetailsAndInstructionsByRecipeID(int recipeID)
        {
            Recipe fakeRecipe = _recipeVM.FirstOrDefault(r => r.RecipeID == recipeID); // FirstOrDefault source: https://www.tutorialspoint.com/chash-linq-firstordefault-method#:~:text=Use%20the%20FirstorDefault()%20method,if%20element%20isn't%20there.&text=List%20val%20%3D%20new,to%20display%20the%20default%20value.
            if (fakeRecipe == null)
            {
                throw new ApplicationException("Recipe not found.");
            }
            return fakeRecipe;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Inserts a new recipe by validating if its a new recipe or not and returns true if is
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changes: ???
        /// </summary>
        public int InsertRecipe(Recipe recipe)
        {
            try
            {
                if (recipe.GetType() == typeof(Recipe))
                {
                    return recipe.RecipeID;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/18/2024
        /// Summary: Method for filtering the recipes by their categories.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/18/2024
        /// What Was changes: Initial Creation
        /// </summary>
        public List<RecipeVM> SelectRecipesByCategory(string category)
        {
            List<RecipeVM> recipeVMs = new List<RecipeVM>();
            foreach(var recipe in _recipeVM) 
            {
                if (recipe.Category.Equals(category))
                {
                    recipeVMs.Add(recipe);
                }
            }
            return recipeVMs;
        }
    }
}
