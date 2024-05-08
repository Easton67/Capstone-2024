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
    /// Summary: Interaction logic for filterCategory.xaml
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/23/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public partial class filterCategory : Window
    {
        private IResourcesNeededManager _resourcesNeededManager;

        public filterCategory()
        {
            InitializeComponent();
            _resourcesNeededManager = new ResourcesNeededManager();
        }


        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: The content that will display upon opening filterCategory. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/23/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var resourcesNeededManager = new ResourcesNeededManager();
                cboCategory.ItemsSource = resourcesNeededManager.GetResourceCategoriesForDropDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/23/2024
        /// Summary: When the cancel button is clicked, the filter window will be closed
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
        /// Created: 02/29/2024
        /// Summary: When the apply button is clicked, the resources will be displayed
        ///             based upon the selected category. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cboCategory.SelectedItem == null) 
                {
                    MessageBox.Show("You must select a category to filter by.");
                } 
                else
                {
                    string category = cboCategory.SelectedItem.ToString();
                    _resourcesNeededManager.GetResourcesByCategory(category);
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
