using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: RecipeIngredients data object class for storage.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RecipeIngredients
    {
        public string IngredientID { get; set; }
        public int RecipeID { get; set; }
        public float Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
    }

    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: Creation of the RecipeIngredients view model.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RecipeIngredientsVM : RecipeIngredients 
    { 
        public Recipe Recipe { get; set; }
    }
}
