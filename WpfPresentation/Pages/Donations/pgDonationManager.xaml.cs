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

namespace WpfPresentation.Pages.Donations
{
    /// <summary>
    /// Creator:            Abdalgader Ibrahim
    /// Created:            02/22/2024
    /// Summary:            Manages donations
    /// Last Updated By:    Mitchell Stirmel
    /// Last Updated:       04/11/2024
    /// What Was changed:   Code cleanup
    /// </summary>
    public partial class pgDonationManager : Page
    {
        IDonationManager _donationManager = null;
        List<Donation> _donations = new List<Donation>();
        public pgDonationManager()
        {
            InitializeComponent();
            _donationManager = new DonationManager();
            GetDonations();
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            dgDonationManager.RowStyle = rowStyle;
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/11/2024
        ///Summary:            Added this to allow flexibility if the donations need to be regotten at some point, instead of filling the item source in the constructor.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Initial Creation
        /// </summary>
        private void GetDonations()
        {
            _donations.Clear();
            try
            {
                dgDonationManager.ItemsSource = _donationManager.GetDonations();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to get donations \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            var donation = (Donation)row.DataContext;
            NavigationService.Navigate(new pgUpdateDonation(donation));
        }

        private static pgDonationManager instance = null;
        public static pgDonationManager GetpgDonationManager()
        {
            return instance ?? (instance = new pgDonationManager());
        }
    }
}
