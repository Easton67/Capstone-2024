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

namespace WpfPresentation.Pages.Security
{
    //<Summary>
    //Creator: Andrew Larson
    //created: 04/09/2024
    //Summary: xaml.cs for ViewConfiscatedItems
    //Last updated By: Andrew Larson
    //Last Updated: 4/09/2024
    //What was changed/updated: Initial Creation
    //</Summary>
    public partial class pgViewConfiscatedItems : Page
    {
        MainManager _mainManager;
        private static pgViewConfiscatedItems instance = null;

        //<Summary>
        //Creator: Andrew Larson
        //created: 04/09/2024
        //Summary: constructor for pgViewConfiscatedItems
        //Last updated By: Andrew Larson
        //Last Updated: 4/09/2024
        //What was changed/updated: Initial Creation
        //</Summary>
        public pgViewConfiscatedItems()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            try
            {
                datConfiscatedItemsList.ItemsSource = _mainManager.ConfiscatedItemManager.GetAllConfiscatedItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException?.Message);
            }
        }

        //<Summary>
        //Creator: Andrew Larson
        //created: 04/09/2024
        //Summary: Navigation static class for pgViewConfiscatedItems
        //Last updated By: Andrew Larson
        //Last Updated: 4/09/2024
        //What was changed/updated: Initial Creation
        //</Summary>
        public static pgViewConfiscatedItems GetConfiscatedItems()
        {
            return instance ?? (instance = new pgViewConfiscatedItems());
        }

        //<Summary>
        //Creator: Andrew Larson
        //created: 04/16/2024
        //Summary: Navigation static class for pgAddConfiscatedItems
        //Last updated By: Andrew Larson
        //Last Updated: 4/16/2024
        //What was changed/updated: Initial Creation
        //</Summary>
        private void btnAddConfiscatedItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgAddConfiscatedItem());
        }


        //<Summary>
        //Creator: Andrew Larson
        //created: 04/16/2024
        //Summary: Method to refresh the data grid
        //Last updated By: Andrew Larson
        //Last Updated: 4/16/2024
        //What was changed/updated: Initial Creation
        //</Summary>
        private void Refresh()
        {
            try
            {
                datConfiscatedItemsList.ItemsSource = _mainManager.ConfiscatedItemManager.GetAllConfiscatedItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException?.Message);
            }
        }

        //<Summary>
        //Creator: Andrew Larson
        //created: 04/16/2024
        //Summary: Refresh the information when the page is loaded
        //Last updated By: Andrew Larson
        //Last Updated: 4/16/2024
        //What was changed/updated: Initial Creation
        //</Summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
