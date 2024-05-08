using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
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
using LogicLayer;
using DataObjects;
using WpfPresentation.Pages.Donations;

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/08/2024
    /// Summary: Interaction logic for pgViewResourcesNeeded.xaml
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// Last Updated By: Andrew Larson
    /// Last Updated: 02/19/2024
    /// What Was Changed: Added btnAdd_Click functionality 
    /// </summary>

    public partial class pgViewResourcesNeeded : Page
    {
        private static pgViewResourcesNeeded instance = null;

        public static pgViewResourcesNeeded GetViewResourcesNeededPage()
        {
            return instance ?? (instance = new pgViewResourcesNeeded());
        }


        private ResourcesNeeded _resourcesNeeded = null;

        public pgViewResourcesNeeded(ResourcesNeeded rn)
        {
            _resourcesNeeded = rn;
            InitializeComponent();
        }

        public pgViewResourcesNeeded()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: The content that will display upon opening pgViewResourcesNeeded. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataRN.ItemsSource == null)
                {
                    var resourcesNeededManager = new ResourcesNeededManager();
                    dataRN.ItemsSource = resourcesNeededManager.GetActiveResourcesNeeded();

                    dataRN.Columns.RemoveAt(2);

                    dataRN.Columns[0].Width = 400;
                    dataRN.Columns[1].Width = 300;

                    dataRN.Columns[0].Header = "Items Needed";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: If a resource item is doubled-clicked, the edit window will open. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/23/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void dataRN_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataRN.SelectedItems.Count != 0)
            {
                var rn = dataRN.SelectedItem as ResourcesNeeded;

                var editPage = new editResourcesNeeded(rn);
                if (editPage.ShowDialog() == true)
                {
                    dataRN.ItemsSource = new ResourcesNeededManager().GetActiveResourcesNeeded();
                    
                    dataRN.Columns.RemoveAt(2);

                    dataRN.Columns[0].Width = 400;
                    dataRN.Columns[1].Width = 300;

                    dataRN.Columns[0].Header = "Items Needed";
                }

            }
            else
            {
                MessageBox.Show("You need to choose something to view.");
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: If the filter button is clicked, the filter window will open. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/23/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            var filterPage = new filterCategory();
            if (filterPage.ShowDialog() == true)
            {
                dataRN.ItemsSource = new ResourcesNeededManager().GetResourcesByCategory(filterPage.cboCategory.Text);

                dataRN.Columns.RemoveAt(2);

                dataRN.Columns[0].Width = 400;
                dataRN.Columns[1].Width = 300;

                dataRN.Columns[0].Header = "Items Needed";
            }
            else
            {
                MessageBox.Show("No items found.");
            }
        }
        
		/// <summary>
		/// Creator: Andrew Larson
        /// Created: 02/19/2024
        /// Summary: this event handler lets the user be directed to
        ///          the add page for NeededResources
        /// Last Updated By: Andrew Larson
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Donations.pgAddResourcesNeeded());
        }

        /// <summary>
		/// Creator: Kirsten Stage
        /// Created: 02/29/2024
        /// Summary: This event handler lets the user be directed back to
        ///          the Main Window.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        /// <summary>
		/// Creator: Kirsten Stage
        /// Created: 03/08/2024
        /// Summary: This event handler removes any filters that may have been applied.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnRemoveFilters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    var resourcesNeededManager = new ResourcesNeededManager();
                    dataRN.ItemsSource = resourcesNeededManager.GetActiveResourcesNeeded();

                    dataRN.Columns.RemoveAt(2);

                    dataRN.Columns[0].Width = 400;
                    dataRN.Columns[1].Width = 300;

                    dataRN.Columns[0].Header = "Items Needed";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
