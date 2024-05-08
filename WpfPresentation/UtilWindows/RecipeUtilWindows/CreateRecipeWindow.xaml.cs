using DataObjects;
using DataObjects.Kitchen;
using LogicLayer;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Matthew Baccam
    /// Created: 01/30/2024
    /// Summary: Initial Creation.
    /// Last Updated By: Matthew Baccam
    /// Last Updated: 01/30/2024
    /// What Was changed: ???
    /// </summary>
    public partial class CreateRecipeWindow : Window
    {
        private MainManager _mainManager = null;
        private IRecipeManager _recipeManager;
        private IRecipeIngredientsManager _recipeIngredientsManager;

        public CreateRecipeWindow()
        {
            _mainManager = MainManager.GetMainManager();
            _recipeManager = _mainManager.RecipeManager;
            _recipeIngredientsManager = _mainManager.RecipeIngredientsManager;
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to delete the watermark text when the user clicks on it.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxIngredients_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxIngredients.Text.ToLower().Contains("list any important details here or any unordinary steps here."))
            {
                txtBoxIngredients.Text = string.Empty;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to repopulate the watermark text when the user clicks out of it if no changed occur.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxIngredients_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxIngredients.Text.Replace(" ", string.Empty) == string.Empty)
            {
                txtBoxIngredients.Text = "List any important details here or any unordinary steps here.";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to delete the watermark text when the user clicks on it.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxInstructions_GotFocus(object sender, RoutedEventArgs e)
        {
            var text = new TextRange(txtBoxInstructions.Document.ContentStart, txtBoxInstructions.Document.ContentEnd);
            if (text.Text.ToLower().Contains("list the instruction steps here."))
            {
                txtBoxInstructions.Document.Blocks.Clear();
                txtBoxInstructions.Document.Blocks.Add(new Paragraph(new Run("")));
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to repopulate the watermark text when the user clicks out of it if no changed occur.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxInstructions_LostFocus(object sender, RoutedEventArgs e)
        {
            var text = new TextRange(txtBoxInstructions.Document.ContentStart, txtBoxInstructions.Document.ContentEnd);
            if (text.Text.Replace(" ", string.Empty) == string.Empty)
            {
                txtBoxInstructions.Document.Blocks.Clear();
                txtBoxInstructions.Document.Blocks.Add(new Paragraph(new Run("List the instruction steps here.")));
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to delete the watermark text when the user clicks on it.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxCalories_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxCalories.Text.ToLower().Contains("whole number"))
            {
                txtBoxCalories.Text = string.Empty;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to repopulate the watermark text when the user clicks out of it if no changed occur.
        ///     Also checks if the user has inputed a int.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxCalories_LostFocus(object sender, RoutedEventArgs e)
        {
            int r;
            if (txtBoxCalories.Text.Replace(" ", string.Empty) == string.Empty || !Int32.TryParse(txtBoxCalories.Text, out r))
            {
                txtBoxCalories.Text = "Whole numbers";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to delete the watermark text when the user clicks on it.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxAllergens_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxAllergens.Text.ToLower().Contains("list each allergen that may appear in the recipe here."))
            {
                txtBoxAllergens.Text = string.Empty;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to repopulate the watermark text when the user clicks out of it if no changed occur.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxAllergens_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxAllergens.Text.Replace(" ", string.Empty) == string.Empty)
            {
                txtBoxAllergens.Text = "List each allergen that may appear in the recipe here.";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to save the data inputed for a new recipe.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// Last Updated By:    Matthew Baccam
        /// Last Updated:       04/24/2024
        /// What Was Changed:   Added a return value so we can insert ingredients
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var txtBoxInstructionsInput = new TextRange(txtBoxInstructions.Document.ContentStart, txtBoxInstructions.Document.ContentEnd);
            if (txtBoxCalories.Text.ToLower().Contains("whole number") || string.IsNullOrWhiteSpace(txtBoxCalories.Text) ||
                txtBoxDescription.Text.ToLower().Contains("enter a brief description about the recipe.") || string.IsNullOrWhiteSpace(txtBoxDescription.Text) ||
                txtBoxAllergens.Text.ToLower().Contains("list each allergen that may appear in the recipe here.") || string.IsNullOrWhiteSpace(txtBoxCalories.Text) ||
                txtBoxPrepTime.Text.ToLower().Contains("whole number") || string.IsNullOrWhiteSpace(txtBoxPrepTime.Text) ||
                string.IsNullOrWhiteSpace(cboRecipeCategory.Text) ||
                txtBoxInstructionsInput.Text.ToLower().Contains("list the instruction steps here.") || string.IsNullOrWhiteSpace(txtBoxInstructionsInput.Text))
            {
                MessageBox.Show("Invalid form please redo and submit again.", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    var recipeID = _recipeManager.CreateRecipe(new Recipe()
                    {
                        RecipeName = txtBoxRecipeName.Text,
                        RecipeDescription = txtBoxDescription.Text,
                        Calories = Convert.ToInt32(txtBoxCalories.Text),
                        Allergens = txtBoxAllergens.Text,
                        Vegen = (bool)chkBoxVegan.IsChecked,
                        Category = cboRecipeCategory.Text,
                        RecipeImage = imgRecipe.Source != null ? imgRecipe.Source.ToString() : "",
                        RecipeSteps = txtBoxInstructionsInput.Text,
                        PrepTime = int.Parse(txtBoxPrepTime.Text)
                    });
                    if (recipeID != -1)
                    {
                        if (!txtBoxIngredients.Text.ToLower().Contains("list any important details here or any unordinary steps here.") || !string.IsNullOrWhiteSpace(txtBoxIngredients.Text))
                        {
                            if (_recipeIngredientsManager.CreateNewIngredient(new RecipeIngredients() { IngredientID = txtBoxIngredients.Text, RecipeID = recipeID }))
                            {
                                this.Close();
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Creation failed", "Failed to create the recipe", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to create recipe", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to cancel the recipe creation proccess and take us back to whichever page we were at previously.
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Cancel changed", "Are you sure you want to discard the current changed", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method allows us to choose a image from a url for the recipe image
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void btnInsertImage_Click(object sender, RoutedEventArgs e)
        {
            string imageSource = Interaction.InputBox("Please paste a image url ", "Recipe Image", "Image URL");
            try
            {
                var imageSourceUri = new Uri(imageSource); //Creating new uri obj from the text from imageSource
                IPHostEntry ipHost = Dns.GetHostEntry(imageSourceUri.DnsSafeHost); // Testing the validity of the url
                imgRecipe.Source = new BitmapImage(imageSourceUri);// Converting the URI to a BitmapImage so we can set the imgRecipe source to the image url provided by the user
            }
            catch (Exception)
            {
                MessageBox.Show("URL provided is invalid", "Invalid image url provided", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method removes the sample text
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxPrepTime_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxPrepTime.Text.Contains("Whole number"))
            {
                txtBoxPrepTime.Text = "";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 01/30/2024
        /// Summary: Initial Creation, This method adds the sample text if needed
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 01/30/2024
        /// What Was changed: ???
        /// </summary>
        private void txtBoxPrepTime_LostFocus(object sender, RoutedEventArgs e)
        {
            int r;
            if (txtBoxPrepTime.Text.Replace(" ", string.Empty) == string.Empty || !Int32.TryParse(txtBoxPrepTime.Text, out r))
            {
                txtBoxPrepTime.Text = "Whole numbers";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/04/2024
        /// Summary: Initial Creation, grabs the future menus so we can assign recipes to the menu
        /// Last Updated By: Matthew Baccam
        /// Created: 03/04/2024
        /// What Was changed: ???
        /// </summary>

        private void txtBoxDescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxPrepTime.Text.Replace(" ", string.Empty) == string.Empty)
            {
                txtBoxPrepTime.Text = "Whole numbers";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/04/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Created: 03/04/2024
        /// What Was changed: ???
        /// </summary>

        private void txtBoxDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxDescription.Text.Contains("Enter a brief description about the recipe"))
            {
                txtBoxDescription.Text = "";
            }
        }
    }
}
