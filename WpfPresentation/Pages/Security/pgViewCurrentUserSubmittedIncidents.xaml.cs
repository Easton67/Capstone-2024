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

namespace WpfPresentation.Pages.Security
{
    /// <summary>
    /// Interaction logic for pgViewCurrentUserSubmittedIncidents.xaml
    /// </summary>
    public partial class pgViewCurrentUserSubmittedIncidents : Page
    {
        private MainManager _manager = MainManager.GetMainManager();
        private List<Incident> _incidents = new List<Incident>();
        public pgViewCurrentUserSubmittedIncidents()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/29/2024
        /// Summary: method for Page_Loaded
        /// Last Updated By: Andrew Larson
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _incidents = _manager.IncidentManager.GetCurrentUserIncidents(_manager.LoggedInUser.UserID);
                grdIncidents.ItemsSource = _incidents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to find incidents", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
