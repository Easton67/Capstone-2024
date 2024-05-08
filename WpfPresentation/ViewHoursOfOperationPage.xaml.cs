using DataObjects;
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

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for ViewHoursOfOperationPage.xaml
    /// </summary>
    public partial class ViewHoursOfOperationPage : Page
    {
        private readonly IHoursOfOperationManager _hoursOfOperationManager;
        public ViewHoursOfOperationPage()
        {
            InitializeComponent();
            _hoursOfOperationManager = new HoursOfOperationManager();
            zipCodeTextBox.KeyDown += zipCodeTextBox_KeyDown; // Ties zipCodeTextBox_KeyDown to KeyDown. https://stackoverflow.com/questions/3356400/operator-with-events#:~:text=%2B%3D%20subscribes%20to%20an%20event,the%20list%20will%20be%20called.
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/29/2024
        /// Summary: Method responsible for taking the users input (in the zipCodeTextBox)
        /// and using that data to search against our database for matching locations with that zipCode
        /// and returning them if they have appropriate relations to HoursOfOperations
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/29/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void SearchForShelterBasedOnZipCode()
        {
            try 
            { 
                if (int.TryParse(zipCodeTextBox.Text, out int zipCode))
                {
                        List<Location> locations = _hoursOfOperationManager.GetLocationsByZipCode(zipCode);
                    if (locations.Count > 0)
                    {
                        UpdateUIWithLocations(locations);
                    }
                    else
                    {
                        MessageBox.Show("No shelters found for the entered ZIP code.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                        // You can also clear previous results, update UI, or take other appropriate action
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid ZIP code.", "Invalid ZIP Code", MessageBoxButton.OK, MessageBoxImage.Warning);
                    // You can handle invalid ZIP code input here (e.g., clear previous results, update UI, or take other appropriate action)
                }
            }   
            catch
            {
                MessageBox.Show("Unable to find shelter in that zip code", "Invalid zip code", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/31/2024
        /// Summary: Methods responsible for the visuals (xaml) given to the user for
        /// the ViewHoursOfOperation.xaml.cs    
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Had to use GetFormattedHoursOfOperation to format both
        /// Location object and HoursOfOperation object as a string.
        /// </summary>
        private void UpdateUIWithLocations(List<Location> locations)
        {
            var textBlockNames = new List<string> { "hoursOfOperationResult1", "hoursOfOperationResult2", "hoursOfOperationResult3", "hoursOfOperationResult4" };

            for (int i = 0; i < textBlockNames.Count; i++)
            {
                var textBlock = (TextBlock)FindName(textBlockNames[i]);
                var border = (Border)FindName($"borderResult{i + 1}"); // Updated border name

                if (i < locations.Count)
                {
                    var location = locations[i];
                    string locationDetails = $"{location.Address}, {location.City}, {location.State} {location.ZipCode}";

                    textBlock.Text = $"Name: {location.LocationName}\nLocation: {locationDetails}\nHours of Operation: {GetFormattedHoursOfOperation(location.HoursOfOperation)}";

                    // Set visibility to visible if there is data
                    textBlock.Visibility = Visibility.Visible;
                    border.Visibility = Visibility.Visible;
                }
                else
                {
                    // Set visibility to collapsed if there is no data
                    textBlock.Visibility = Visibility.Collapsed;
                    border.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/31/2024
        /// Summary: Checks if the "Enter" key is pressed and runs SearchForShelterBasedOnZipCode
        /// if true
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void zipCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchForShelterBasedOnZipCode();
                e.Handled = true; // tells the program that the event handler 
                                  // has done it's job (prevents multiple error messages from popping up)
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/31/2024
        /// Summary: Formats the HoursOfOperation object as a string to be used to display
        /// data in UpdateUIWithLocations method.
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Initial Creation
        /// </summary>
        private string GetFormattedHoursOfOperation(List<HoursOfOperation> hoursOfOperationList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hoursOfOperation in hoursOfOperationList)
            {
                sb.AppendLine($"{hoursOfOperation.HoursOfOperationString}");
            }

            return sb.ToString();
        }
    }
}
