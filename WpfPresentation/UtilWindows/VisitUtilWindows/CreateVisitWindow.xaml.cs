using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfPresentation
{
    //<Summary>
    //Creator: Matthew Baccam
    //Created: 02/08/2024
    //Summary: Initial Creation
    //Last Updated By: Matthew Baccam
    //Last Updated: 02/08/2024
    //What Was Changed: Initial Creation
    //<Summary>
    public partial class CreateVisitWindow : Window
    {
        private MainManager _mainManager;

        //TO DO: Pass in the current signed in user here so we can log it into the create statement
        public CreateVisitWindow()
        {
            _mainManager = MainManager.GetMainManager();
            InitializeComponent();
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValidForm())
                {
                    var x = dateTimePickerCheckIn.Value;
                    var y = DateTime.Now.Date;
                    if (x < y)
                    {
                        MessageBox.Show("Invalid date", "Incorrect date selection", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (_mainManager.VisitManager.CreateVisit(new Visit()
                    {
                        FirstName = txtBoxFirstName.Text,
                        LastName = txtBoxLastName.Text,
                        CheckIn = (DateTime)dateTimePickerCheckIn.Value,
                        CheckOut = (DateTime)dateTimePickerCheckOut.Value,
                        VisitReason = txtBoxReason.Text
                    }) == 1)
                    {
                        MessageBox.Show("Successfully created the Visit", "Created Visit", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save visit, error occured somewhere with the save", "Failed to Save", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.DialogResult = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to Save Visit", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 04/23/2024
        //Summary: Validates the form
        //Last Updated By: Matthew Baccam
        //Last Updated: 04/23/2024
        //What Was Changed: Initial Creation
        //<Summary>
        private bool IsValidForm()
        {
            var formError = "";
            if (string.IsNullOrWhiteSpace(txtBoxFirstName.Text))
            {
                formError += " first name,";
            }
            if (string.IsNullOrWhiteSpace(txtBoxLastName.Text))
            {
                formError += " last name,";
            }
            if (dateTimePickerCheckIn.Value == null)
            {
                formError += " check in,";
            }
            if (dateTimePickerCheckOut.Value == null)
            {
                formError += " check out,";
            }
            if (string.IsNullOrEmpty(formError))
            {
                return true;
            }
            else
            {
                throw new Exception($"Form has the following errors in{formError} please fix and resubmit");
            }
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
