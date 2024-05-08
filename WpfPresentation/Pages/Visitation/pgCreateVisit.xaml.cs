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
using DataObjects;

namespace WpfPresentation.Pages.Visitation
{
    /// <summary>
    ///Creator:            Ibrahim Albashair
    ///Created:            02/13/2024
    ///Summary:            Contains Logic for pgCreateVisit
    ///Last Updated By:    Ibrahim Albashair
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgCreateVisit : Window
    {
        VisitManager _visitManager;

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            Contsructor
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public pgCreateVisit()
        {
            InitializeComponent();
            _visitManager = new VisitManager();
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            04/11/2024
        ///Summary:            logic for creating a visit object
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       04/11/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public Visit VisitCreator() 
        {
            string checkInText, checkOutText;
            // convert bool? to bool
            bool radio1 = radAM.IsChecked ?? false;
            bool radio2 = radAM2.IsChecked ?? false;

            // if statements to check radio buttons
            if (radio1)
            {
                checkInText = txtHours.Text + ":" + txtMintues.Text + "am";
            }
            else
            {
                checkInText = txtHours.Text + ":" + txtMintues.Text + "pm";
            }

            if (radio2)
            {
                checkOutText = txtHours2.Text + ":" + txtMintues2.Text + "am";
            }
            else
            {
                checkOutText = txtHours2.Text + ":" + txtMintues2.Text + "pm";
            }

            Visit visit = new Visit()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                CheckIn = DateTime.Parse(checkInText),
                CheckOut = DateTime.Parse(checkOutText),
                VisitReason = cbx.Text,
                Status = true
            };
            return visit;
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for Create button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtHours.Text != "" && txtHours2.Text != "" && txtMintues.Text != ""
                && txtMintues2.Text != "" && (radAM.IsChecked == true || radPM.IsChecked == true) &&
                (radAM2.IsChecked == true || radPM2.IsChecked == true) )
            {      
                
                Visit visit = VisitCreator();
                // try to create visit
                try
                {
                    _visitManager.CreateVisit(visit);
                    MessageBox.Show("Visit Added!", "Success");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not add visit", "Failed");
                }
            }
            else 
            {
                MessageBox.Show("All fields must be filled");
            }
        }
        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Cancel button
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Regex/Validator Methods
        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
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
        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
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
        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void txtHours2_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void txtMintues_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        private void txtMintues2_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic Textbox
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
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
        #endregion
    }
}
