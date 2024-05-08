using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
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

namespace WpfPresentation.Pages.Donations
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/23/2024
    /// Summary: Interaction logic for editResourcesNeeded.xaml
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Added main manager
    /// </summary>

    public partial class editResourcesNeeded : Window
    {
        private ResourcesNeeded _resourcesNeeded = null;
        private MainManager mainManager;

        public editResourcesNeeded(ResourcesNeeded rn)
        {
            _resourcesNeeded = rn;
            mainManager = MainManager.GetMainManager();
            InitializeComponent();
        }


        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: The content that will display upon opening pgEditResourcesNeeded. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/23/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cboCategory.ItemsSource = mainManager.ResourcesNeededManager.GetResourceCategoriesForDropDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

            txtResourceID.Text = _resourcesNeeded.ResourceID;
            cboCategory.Text = _resourcesNeeded.Category;
            chkActive.IsChecked = _resourcesNeeded.Active;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: When the cancel button is clicked, the edit window will be closed
        ///             and no changes will be saved. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/23/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: When the update button is clicked, changes will be saved. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/23/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var newResourceNeeded = new ResourcesNeeded()
            {
                ResourceID = txtResourceID.Text,
                Category = cboCategory.Text,
                Active = (bool)chkActive.IsChecked
            };

            try
            {
                bool result = mainManager.ResourcesNeededManager.EditResourceNeeded(_resourcesNeeded, newResourceNeeded);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
