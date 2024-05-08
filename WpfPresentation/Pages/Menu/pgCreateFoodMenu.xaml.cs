using DataObjects.Kitchen;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfPresentation.Pages.Stats;

namespace WpfPresentation.Pages.Menu
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: Code behind file for the pgCreateFoodMenu.xaml file.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/1/2024
    /// What Was Changed: Adding the getRecipeByName method
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       04/11/2024
    ///What Was changed:   Added try catch
    /// </summary>
    public partial class pgCreateFoodMenu : Page
    {
        private IWeekFoodMenuManager _weekFoodMenuManager = null;
        private IRecipeManager _recipeManager = null;
        List<RecipeVM> recipes = null;
        public pgCreateFoodMenu()
        {
            _weekFoodMenuManager = new WeekFoodMenuManager();
            _recipeManager = new RecipeManager();
            InitializeComponent();
            try
            {
                recipes = _recipeManager.GetRecipes();
                List<String> RecipeNames = new List<String>();
                foreach (RecipeVM recipe in recipes)
                {
                    RecipeNames.Add(recipe.RecipeName);
                }
                var UniqueRecipeNames = new HashSet<String>(RecipeNames);
                cboFoodMenuItemOne.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemTwo.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemThree.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemFour.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemFive.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemSix.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemSeven.ItemsSource = UniqueRecipeNames;
                cboFoodMenuItemEight.ItemsSource = UniqueRecipeNames;
                cboMenuType.ItemsSource = new List<string> { "Dinner", "Breakfast", "Lunch", "Supper", "Desert" };
                cboMenuDay.ItemsSource = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get recipes \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 01/31/2024
        /// Summary: Code for the save button to save the food menu and save menu meals.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/05/2024
        /// What Was Changed: Made the fields required inorder to save a food menu.
        /// </summary>
        private void btnSaveFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cboMenuDay.Text) ||
                    string.IsNullOrEmpty(txtMenuName.Text) ||
                    string.IsNullOrEmpty(cboMenuType.Text) ||
                    (string.IsNullOrEmpty(cboFoodMenuItemOne.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemTwo.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemThree.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemFour.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemFive.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemSix.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemSeven.Text) &&
                     string.IsNullOrEmpty(cboFoodMenuItemEight.Text)))
                {
                    MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; // Exit the method
                }

                string DayOfMeal = cboMenuDay.Text;
                string MenuName = txtMenuName.Text;
                string MenuType = cboMenuType.Text;
                DateTime DateLastModified = DateTime.Now;
                int id = _weekFoodMenuManager.InsertFoodMenu(DayOfMeal, MenuName, MenuType, DateLastModified);

                if (id == 0)
                {
                    MessageBox.Show("We're having trouble saving the food menu.", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Exit the method
                }
                else
                {
                    MessageBox.Show("Successfully saved food menu.", "Save Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                List<RecipeVM> mealRecipes = new List<RecipeVM>();
                AddRecipeIfNotEmpty(cboFoodMenuItemOne.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemTwo.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemThree.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemFour.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemFive.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemSix.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemSeven.Text, mealRecipes);
                AddRecipeIfNotEmpty(cboFoodMenuItemEight.Text, mealRecipes);

                cboMenuDay.SelectedItem = null;
                txtMenuName.Text = string.Empty;
                cboMenuType.SelectedItem = null;
                cboFoodMenuItemOne.SelectedItem = null;
                cboFoodMenuItemTwo.SelectedItem = null;
                cboFoodMenuItemThree.SelectedItem = null;
                cboFoodMenuItemFour.SelectedItem = null;
                cboFoodMenuItemFive.SelectedItem = null;
                cboFoodMenuItemSix.SelectedItem = null;
                cboFoodMenuItemSeven.SelectedItem = null;
                cboFoodMenuItemEight.SelectedItem = null;

                foreach (RecipeVM recipe in mealRecipes)
                {
                    int foodRows = _weekFoodMenuManager.InsertFoodItemIntoMenu(id, recipe.RecipeID, "bill@company.com", recipe.Category);
                    recipe.MenuID = id;
                    int recipeRows = _weekFoodMenuManager.InsertNewRecipeForMenu(recipe);
                    if (foodRows != 1 || recipeRows != 1)
                    {
                        MessageBox.Show("We're having trouble saving the food item/s to the menu.", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Successfully saved food item to menu.", "System Update", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

                NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem saving the menu. Check your inputs.\n{ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/05/2024
        /// Summary: Method that checks if a recipe is not empty.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void AddRecipeIfNotEmpty(string recipeName, List<RecipeVM> mealRecipes)
        {
            if (!string.IsNullOrEmpty(recipeName))
            {
                mealRecipes.Add(getRecipeByName(recipeName));
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Method for geting the name of a recipe to be inserted into the food menu.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private RecipeVM getRecipeByName(string mealName)
        {
            foreach (RecipeVM me in recipes)
            {
                if (me.RecipeName.Equals(mealName))
                {
                    return me;
                }
            }
            return null;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Method for getting the cancel button to work.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/22/2024
        /// What Was Changed: Cancel button now navigates to Home.
        /// </summary>
        private void btnCancelFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Logic for navigation in the pgCreateFoodMenu file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgCreateFoodMenu instance = null;
        public static pgCreateFoodMenu GetpgCreateFoodMenu()
        {
            return instance ?? (instance = new pgCreateFoodMenu());
        }
    }
}
