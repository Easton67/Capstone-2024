using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataObjects.Kitchen;

namespace WpfPresentation.Pages.Recipe
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/06/2024
    /// Summary: Responsible for displaying
    /// the list of Recipes using ViewRecipeListPage
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/06/2024
    /// What was changed: Initial Creation
    /// Last Updated By: Ethan McElree
    /// Last Updated 03/18/2024
    /// What was changed: Adding functionality to filter by category.
    /// </summary>
    public partial class pgViewRecipeList : Page
    {
        private RecipeVM _recipeViewModel = null;
        private MainManager _mainManager;

        private static pgViewRecipeList instance = null;
        public static pgViewRecipeList GetRecipeListPage()
        {
            return instance ?? (instance = new pgViewRecipeList());
        }

        public pgViewRecipeList()
        {
            InitializeComponent();
            datRecipeList.Items.Clear();

            _mainManager = MainManager.GetMainManager();

            _recipeViewModel = new RecipeVM()
            {
                Recipes = new List<DataObjects.Kitchen.RecipeVM>() //explicitly saying where Recipe is because VS was getting it confused with the namespace.
            };
            cboFilterCategory.ItemsSource = new List<string> { "All", "Breakfast", "Dinner", "Lunch", "Dessert" };
            lblLastUpdated.Content = DateTime.Now;
        }
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/06/2024
        /// Summary: Method responsible for fetching
        /// a list of all current recipes
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/06/2024
        /// What was changed: Initial Creation
        /// </summary>
        public void ViewRecipeListViewModel()
        {
            try
            {
                _recipeViewModel.Recipes = _mainManager.RecipeManager.GetRecipes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/06/2024
        /// Summary: The event handler that deals with 
        /// the actual button push of the "Recipe List"
        /// button and displays the recipes.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/06/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void btnRecipeList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewRecipeListViewModel();
                datRecipeList.ItemsSource = _recipeViewModel.Recipes;
            }
            catch
            {
                MessageBox.Show("No recipes to display.", "Unable to retrieve recipes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: This method will change the page for the user when
        ///          they click on the "Details/Instructions" button
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void btnMealDetailsAndInstructions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataObjects.Kitchen.Recipe selectedRecipe = (DataObjects.Kitchen.Recipe)datRecipeList.SelectedItem;
                DataObjects.Kitchen.Recipe recipeDetailsAndInstructions = _mainManager.RecipeManager.GetRecipeDetailsAndInstructionsByRecipeID(selectedRecipe.RecipeID);
                List<RecipeIngredients> ingredients = _mainManager.RecipeIngredientsManager.GetIngredientsByRecipeID(selectedRecipe.RecipeID);

                if ( recipeDetailsAndInstructions != null)
                {
                    NavigationService.Navigate(new pgViewRecipeDetails(selectedRecipe.RecipeID));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading recipe Details", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/05/2024
        /// Summary: This is a method that creates a recipe window
        /// </summary>
        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow();
            createRecipeWindow.ShowDialog();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/18/2024
        /// Summary: Method that filters the recipes by their categories.
        /// Last Updated By: Ethan McElree
        /// Last Updated 03/18/2024
        /// What was changed: Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void cboFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedCategory = cboFilterCategory.SelectedItem.ToString();
                RecipeManager recipeManager = new RecipeManager();
                datRecipeList.ItemsSource = recipeManager.SelectRecipesByCategory(selectedCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to filter recipes \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/21/2024
        /// Summary: Button that takes the user to the delete recipes page.
        /// Last Updated By: Ethan McElree
        /// Last Updated 03/21/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgDeleteRecipe());
        }
    }
}
