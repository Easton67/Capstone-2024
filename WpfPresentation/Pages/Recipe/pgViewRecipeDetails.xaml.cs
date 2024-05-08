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
using DataObjects;
using DataAccessInterfaces;
using System.IO;
using System.Net;

namespace WpfPresentation.Pages.Recipe
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/13/2024
    /// Summary: Responsible for displaying Recipe details
    /// Last Updated By: Andrew Larson
    /// Last Updated 02/13/2024
    /// What was changed: Initial Creation
    /// </summary>
    public partial class pgViewRecipeDetails : Page
    {
        private IRecipeManager _recipeManager;
        private DataObjects.Kitchen.Recipe _selectedRecipe;
        private IRecipeIngredientsManager _recipeIngredientsManager = new RecipeIngredientsManager();

        public pgViewRecipeDetails(int selectedRecipeID)
        {
            InitializeComponent();
            _recipeManager = new RecipeManager();
            LoadRecipeDetails(selectedRecipeID);

        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Will display, using other methods in this class, the details 
        ///          about the appropriate recipe by using the selectedRecipeID from the users input (button press)
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void LoadRecipeDetails(int recipeID)
        {
            try
            {
                _selectedRecipe = _recipeManager.GetRecipeDetailsAndInstructionsByRecipeID(recipeID);
                DisplayRecipeDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipe details", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Changes appropriate attributes to values from the database.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void DisplayRecipeDetails() 
        {
            txtblkRecipeName.Text = _selectedRecipe.RecipeName;
            txtblkIngredients.Text = GetIngredientsText(_selectedRecipe.RecipeID);
            txtblkDirections.Document.Blocks.Clear();
            txtblkDirections.Document.Blocks.Add(new Paragraph(new Run(_selectedRecipe.RecipeSteps)));

            // Attempt to display image
            DisplayImage();

        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/16/2024
        /// Summary: Displays the image if it exists
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/16/2024
        /// What was changed: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated 04/24/2024
        /// What was changed: Made this check for a image being present via url in the db thats valid
        /// </summary>
        private void DisplayImage()
        {
            try
            {
                if(!Uri.IsWellFormedUriString(_selectedRecipe.RecipeImage, UriKind.Absolute))//Checks if its a Absolute URI
                {
                    string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images", "RecipeImages", _selectedRecipe.RecipeImage);

                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        Uri ImageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                        BitmapImage bitmap = new BitmapImage(ImageUri);
                        imgRecipeImage.Source = bitmap;
                    }
                    else
                    {
                        imgRecipeImage.Source = null;
                    }
                }
                else
                {
                    var imageSourceUri = new Uri(_selectedRecipe.RecipeImage); //Creating new uri obj from the text from imageSource
                    IPHostEntry ipHost = Dns.GetHostEntry(imageSourceUri.DnsSafeHost); // Testing the validity of the url
                    imgRecipeImage.Source = new BitmapImage(imageSourceUri);// Converting the URI to a BitmapImage so we can set the imgRecipe source to the image url provided by the user
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to display image");
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Makes the list of ingredients look cleaner by adding a
        ///          new line after each ingredient and placing a bullet point
        ///          before each ingredient
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private string GetIngredientsText(int recipeID)
        {
            try
            {
                var ingredients = _recipeIngredientsManager.GetIngredientsByRecipeID(recipeID);
                if(ingredients != null)
                {
                    string ingredientsText = string.Join("\n", ingredients.Select(ingredient => "• " + ingredient.IngredientID));
                    return ingredientsText;
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get ingredients \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
                return "";
            }

        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/13/2024
        /// Summary: Redirects the user back to the pgViewRecipeList
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/13/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
