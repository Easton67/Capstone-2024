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
using WpfPresentation.Pages.Inventory;

namespace WpfPresentation.Pages.Memberships
{
    /// <summary>
    /// Interaction logic for pgViewMembershipApplications.xaml
    /// </summary>
    public partial class pgViewMembershipApplications : Page
    {
        private static pgViewMembershipApplications instance = null;
        public static pgViewMembershipApplications GetMembershipApplicationsPage()
        {
            return instance ?? (instance = new pgViewMembershipApplications());
        }
        private MainManager _mainManager;

        public pgViewMembershipApplications()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();

             GetMembershipApplications();
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            This is the xaml.cs for Membership Applications.
        /// Last Updated By:   Donald Winchester
        /// Last Updated:       04/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public void GetMembershipApplications()
        {
            try
            {
                dgdMembershipApplications.ItemsSource = _mainManager.MembershipApplicationsManager.GetAllMembershipApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get membership applications \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }
        
    }
}
