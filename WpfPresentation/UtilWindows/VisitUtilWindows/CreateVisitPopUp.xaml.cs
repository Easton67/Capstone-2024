using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.Visitation
{
    /// <summary>
    /// Interaction logic for CreateVisitPopUp.xaml
    /// </summary>
    public partial class CreateVisitPopUp : Window
    {
        VisitManager _visitManager;
        public CreateVisitPopUp()
        {
            InitializeComponent();
            _visitManager = new VisitManager();
        }
        /// <summary>
        /// Creator: Ibrhaim Albashair
        /// Created: 02/10/2024
        /// Summary: Method responsilble for handling button click, validates inputs and adds new visit
        /// What was changed: Initial Creation
        /// Last updated By: Tyler Barz
        /// Last Updated: 02/25/2024
        /// What was changed/updated: Removed unused caught exception
        /// </summary>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtHours.Text != "" && txtHours2.Text != "" && txtMintues.Text != ""
                && txtMintues2.Text != "" && (radAM.IsChecked == true || radPM.IsChecked == true) &&
                (radAM2.IsChecked == true || radPM2.IsChecked == true) )
            {

                DateTime checkInText, checkOutText;
                // convert bool? to bool
                bool radio1 = radAM.IsChecked ?? false;
                bool radio2 = radAM2.IsChecked ?? false;

                // if statements to check radio buttons
                if (radio1)
                {
                    checkInText = DateTime.Parse(txtHours.Text + ":" + txtMintues.Text + "am");
                }
                else
                {
                    checkInText = DateTime.Parse(txtHours.Text + ":" + txtMintues.Text + "pm");
                }

                if (radio2)
                {
                     checkOutText = DateTime.Parse(txtHours2.Text + ":" + txtMintues2.Text + "am");
                }
                else
                {
                    checkOutText = DateTime.Parse(txtHours2.Text + ":" + txtMintues2.Text + "pm");
                }


                // try to create visit
                try
                {
                    var visit = new Visit()
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        CheckIn = checkInText,
                        CheckOut = checkOutText,
                        VisitReason = cbx.Text
                    };
                    _visitManager.CreateVisit(visit);
                    MessageBox.Show("Visit Added!", "Success");
                    this.Close();
                }
                catch
                {

                    MessageBox.Show("Could not add visit", "Failed");
                }
            }
            else 
            {
                MessageBox.Show("All fields must be filled");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtHours_GotFocus(object sender, RoutedEventArgs e)
        {
            txtHours.SelectAll();
        }

        private void txtMintues_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtHours2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtHours2.Text);
                if (number > 12)
                {
                    txtHours2.Clear();
                }
            }
            catch (Exception)
            {

            }


        }

        private void txtHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtHours.Text);
                if (number > 12)
                {
                    txtHours.Clear();
                }
            }
            catch (Exception)
            {

            }

        }

        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            
        }

        private void txtHours2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMintues_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMintues2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMintues_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtMintues.Text);
                if (number > 59)
                {
                    txtMintues.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtMintues2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtMintues2.Text);
                if (number > 59)
                {
                    txtMintues2.Clear();
                }
            }
            catch (Exception)
            {               
            }
        }
    }
}
