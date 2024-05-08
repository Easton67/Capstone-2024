using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Kitchen
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: WeekFoodMenu data object class for storage.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/31/2024
    /// What Was Changed: Adding ToString method to the Recipe class
    /// </summary>
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set;}
        public int Calories { get; set; }
        public string Allergens { get; set; }
        public bool Vegen { get; set; }
        public int PrepTime { get; set; }
        public int MenuID { get; set; }
        public string Category { get; set; }
        public int KitchenItemID { get; set; }
        public string RecipeImage { get; set; }
        public string RecipeSteps { get; set; }
        public override string ToString()
        {
            return RecipeName;
        }
    }

    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: Creation of the Recipe view model.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/19/2024
    /// What Was Changed: Added SelectedRecipe.
    /// </summary>
    public class RecipeVM : Recipe
    {
        public WeekFoodMenu Menu { get; set; }
        public KitchenInventoryItem KitchenInventoryItem { get; set; }
        public List<RecipeVM> Recipes { get; set; }
        public bool SelectedRecipe { get; set; }
    }
}
