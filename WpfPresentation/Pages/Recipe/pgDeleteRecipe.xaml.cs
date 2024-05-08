using DataObjects.Kitchen;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.Recipe
{
    /// <summary>
    ///Creator:            Ethan McElree
    ///Created:            02/17/2024
    ///Summary:            Page for deleting recipes
    ///Last Updated By:    Ethan McElree
    ///Last Updated:       02/17/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgDeleteRecipe : Page
    {
        List<RecipeVM> Recipes = null;
        IRecipeManager recipeManager = null;

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/19/2024
        ///Summary:            Creation of pgDeleteRecipe constructor without parameters.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/19/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        public pgDeleteRecipe()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();
            try
            {
                List<RecipeVM> recipes = recipeManager.GetRecipes();
                List<String> recipeNames = new List<String>();
                Recipes = new List<RecipeVM>();
                foreach (RecipeVM recipe in recipes)
                {
                    if (!recipeNames.Contains(recipe.RecipeName))
                    {
                        recipeNames.Add(recipe.RecipeName);
                        Recipes.Add(recipe);
                    }
                }
                listBoxDeleteRecipe.ItemsSource = Recipes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get recipes \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/20/2024
        ///Summary:            Creation of the delete recipes button functionality.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/20/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnDeleteRecipes_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipes = Recipes.Where(recipe => recipe.SelectedRecipe).ToList();

            if (selectedRecipes.Count == 0)
            {
                MessageBox.Show("Please select at least one recipe to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected recipes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var recipe in selectedRecipes)
                    {
                        int rows = recipeManager.deleteRecipeByName(recipe.RecipeName);
                    }
                    NavigationService.Navigate(new pgViewRecipeList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete recipe \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/20/2024
        ///Summary:            Creation of the functionality for the cancel button on the delete recipes page.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/22/2024
        ///What Was Changed:   Cancel button now goes to the pgViewRecipeList page.
        /// </summary>
        private void btnCancelDeleteRecipes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgViewRecipeList());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Logic for navigation in the pgCreateFoodMenu file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgDeleteRecipe instance = null;
        public static pgDeleteRecipe GetpgDeleteRecipe()
        {
            return instance ?? (instance = new pgDeleteRecipe());
        }
    }
}
