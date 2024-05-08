using DataObjects;
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
using System.Windows.Shapes;
using LogicLayer;
using System.Text.RegularExpressions;

namespace WpfPresentation.Pages.Visitation
{
    /// <summary>
    ///Creator:            Ibrahim Albashair
    ///Created:            02/13/2024
    ///Summary:            This contains the interaction logic for pgEditVisit
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgEditVisit : Window
    {
        VisitManager _visitManager;
        Visit _visit;

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            Contructor
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public pgEditVisit(Visit visit)
        {
            _visitManager = new VisitManager();
            _visit = visit;
            InitializeComponent();
        }


        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for close button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for window load
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_visit != null)
            {
                // Populate Data
                lblVisitIdData.Content = _visit.VisitID.ToString();
                lblFirstNameData.Content = _visit.FirstName;
                lblLastNameData.Content = _visit.LastName;
                lblCheckInData.Content = _visit.CheckIn;
                lblCheckOutData.Content = _visit.CheckOut;
                lblVisitReasonData.Content = _visit.VisitReason;

            }
            else
            {
                MessageBox.Show("Unable to find visit", "Error");
            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for Delete button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // create and capture warning result
            string visitID = _visit.VisitID.ToString();
            var result = MessageBox.Show("Delete Visit " + visitID + "?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
            {
                try
                {
                    _visitManager.DeleteVisit(_visit);
                    MessageBox.Show("Record Deleted!", "Success");
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Record could not be deleted", "Error");
                }
            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            Reschudle Ui change
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void ChangeUIForReschedule()
        {
            // Make inputs visible and hide labels
            txtCheckInMinute.Visibility = Visibility.Visible;
            txtCheckInHours.Visibility = Visibility.Visible;
            txtCheckOutHours.Visibility = Visibility.Visible;
            txtCheckOutMinutes.Visibility = Visibility.Visible;
            txtSemiColon.Visibility = Visibility.Visible;
            txtSemiColon2.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            btnDone.Visibility = Visibility.Visible;
            lblAM.Visibility = Visibility.Visible;
            lblAM3.Visibility = Visibility.Visible;
            lblPM.Visibility = Visibility.Visible;
            lblPM3.Visibility = Visibility.Visible;
            radAM.Visibility = Visibility.Visible;
            radAM2.Visibility = Visibility.Visible;
            radPM.Visibility = Visibility.Visible;
            radPM2.Visibility = Visibility.Visible;

            lblCheckInData.Visibility = Visibility.Hidden;
            lblCheckOutData.Visibility = Visibility.Hidden;
            btnDelete.Visibility = Visibility.Hidden;
            btnReschedule.Visibility = Visibility.Hidden;
            btnClose.Visibility = Visibility.Hidden;

            radAM.IsChecked = false; ;
            radPM.IsChecked = false;
            radAM2.IsChecked = false;
            radPM2.IsChecked = false;
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            Listing Ui Change
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void ChangeUIForListing()
        {
            // Make inputs visible and hide labels
            txtCheckInMinute.Visibility = Visibility.Hidden;
            txtCheckInHours.Visibility = Visibility.Hidden;
            txtCheckOutHours.Visibility = Visibility.Hidden;
            txtCheckOutMinutes.Visibility = Visibility.Hidden;
            txtSemiColon.Visibility = Visibility.Hidden;
            txtSemiColon2.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Hidden;
            btnDone.Visibility = Visibility.Hidden;
            lblAM.Visibility = Visibility.Hidden;
            lblAM3.Visibility = Visibility.Hidden;
            lblPM.Visibility = Visibility.Hidden;
            lblPM3.Visibility = Visibility.Hidden;
            radAM.Visibility = Visibility.Hidden;
            radAM2.Visibility = Visibility.Hidden;
            radPM.Visibility = Visibility.Hidden;
            radPM2.Visibility = Visibility.Hidden;

            lblCheckInData.Visibility = Visibility.Visible;
            lblCheckOutData.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
            btnReschedule.Visibility = Visibility.Visible;
            btnClose.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for Reschedule button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnReschedule_Click(object sender, RoutedEventArgs e)
        {
            ChangeUIForReschedule();
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for Cancel button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ChangeUIForListing();
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckInHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtCheckInHours.Text);
                if (number > 12)
                {
                    txtCheckInHours.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckOutHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtCheckOutHours.Text);
                if (number > 12)
                {
                    txtCheckOutHours.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckInMinute_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtCheckInMinute.Text);
                if (number > 59)
                {
                    txtCheckInMinute.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckInHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckOutHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckOutMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtCheckInMinute.Text);
                if (number > 59)
                {
                    txtCheckInMinute.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckOutMinutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCheckInMinute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for Done button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if (txtCheckInHours.Text != "" && txtCheckInMinute.Text != "" && txtCheckOutHours.Text != "" && txtCheckOutMinutes.Text != ""
                && (radAM.IsChecked == true || radPM.IsChecked == true) &&
                (radAM2.IsChecked == true || radPM2.IsChecked == true))
            {
                string checkInText, checkOutText;
                // convert bool? to bool
                bool radio1 = radAM.IsChecked ?? false;
                bool radio2 = radAM2.IsChecked ?? false;

                // visit ID
                int visitId = _visit.VisitID;

                // if statements to check radio buttons
                if (radio1)
                {
                    checkInText = txtCheckInHours.Text + ":" + txtCheckInMinute.Text + "am";
                }
                else
                {
                    checkInText = txtCheckInHours.Text + ":" + txtCheckInMinute.Text + "pm";
                }

                if (radio2)
                {
                    checkOutText = txtCheckOutHours.Text + ":" + txtCheckOutMinutes.Text + "am";
                }
                else
                {
                    checkOutText = txtCheckOutHours.Text + ":" + txtCheckOutMinutes.Text + "pm";
                }

                DateTime checkIn = DateTime.Parse(checkInText);
                DateTime checkOut = DateTime.Parse(checkOutText);

                try
                {
                    _visitManager.RescheduleVisit(visitId, checkIn, checkOut);
                    MessageBox.Show("Visit Rescheduled!", "Success");
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Could not reschedule visit", "Failed");
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled");
            }
        }
    }
}
