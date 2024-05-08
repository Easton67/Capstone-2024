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
    /// Interaction logic for pgUpdateDonation.xaml
    /// </summary>
    public partial class pgUpdateDonation : Page
    {
        private IDonationManager donationManager;
        public pgUpdateDonation()
        {
            InitializeComponent();
            donationManager = new DonationManager();
        }
        public pgUpdateDonation(Donation donation)
        {
            InitializeComponent();
            txtDonationID.Text = donation.DonationID.ToString();
            txtDonationTypeID.Text = donation.DonationTypeID.ToString();
            txtDonatorID.Text = donation.DonatorID.ToString();
            txtDonationName.Text = donation.DonationName.ToString();
            txtAmount.Text = donation.Amount.ToString();
            txtDonationDate.Text = donation.DonationDate.ToString();
            txtActive.Text = donation.Active.ToString();
            txtDonationID.IsEnabled = false;

        }

        private void btnSubmitUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Donation donation = new Donation();
                donation.DonationID = Convert.ToInt32(txtDonationID.Text);
                donation.DonationTypeID = Convert.ToInt32(txtDonationTypeID.Text);
                donation.DonatorID = Convert.ToInt32(txtDonatorID.Text);
                donation.DonationName = txtDonationName.Text;
                donation.Amount = txtAmount.Text;
                donation.DonationDate = Convert.ToDateTime(txtDonationDate.Text);
                donation.Active = Convert.ToBoolean(txtActive.Text);
                donationManager = new DonationManager();
                donationManager.UpdateDonation(donation);
                NavigationService.Navigate(new pgDonationManager());
            }
            catch
            {
                MessageBox.Show("Something Went Wrong");
            }


        }

        private static pgUpdateDonation instance = null;
        public static pgUpdateDonation GetpgUpdateDonation()
        {
            return instance ?? (instance = new pgUpdateDonation());
        }
    }
}
