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
using System.Windows.Shapes;

namespace WpfPresentation.Pages.User
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 02/21/2024
    /// Summary: CreateIncidentPage 
    /// Last updated By: Tyler Barz
    /// Last Updated: 02/25/2024
    /// What was changed/updated: Implemented main manager
    /// </summary>
    public partial class CreateIncidentReport : Window
    {
        private List<int> _severityList = new List<int>();
        private MainManager _mainManager;
        //IIncidentManager _incidentManager = new IncidentManager();
        //IEmployeeManager _employeeManager = new EmployeeManager();

        private int _severity = 0;
        private string _description = "";
        private string _reported = "";
        private string _reportedBy = "";

        public CreateIncidentReport()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();

            try
            {
                this.Owner = App.Current.MainWindow;
                _severityList.Add(1);
                _severityList.Add(2);
                _severityList.Add(3);
                _severityList.Add(4);
                _severityList.Add(5);

                cbSeverity.ItemsSource = _severityList;
                cbPartiesInvolved.ItemsSource = _mainManager.UserManager.GetAllEmployeeIDs();


            }
            catch (Exception ex)
            {
                throw new Exception("Incident Page creation error", ex);
            }
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/21/2024
        /// Summary: cbPartiesInvolved_SelectionChanged event 
        /// Last updated By: Tyler Barz
        /// Last Updated: 02/25/2024
        /// What was changed/updated: Removed unused caught exception
        /// </summary>
        private void cbPartiesInvolved_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _reportedBy = (string)cbPartiesInvolved.SelectedItem;
            }
            catch
            {
                throw new Exception("selected item cannot be casted");
            }
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/21/2024
        /// Summary: cbSeverity_SelectionChanged event 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02/21/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void cbSeverity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _severity = cbSeverity.SelectedIndex;
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/21/2024
        /// Summary: btnSubmit_Click event 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02/21/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _description = txtAdditionalInfo.Text;
                _reported = txtFirtName.Text + " " + txtLastName.Text;
                if (txtFirtName.Text != "" || txtLastName.Text != "")
                {
                    if (_description != "Additional Info")
                    {
                        if (_severity != 0)
                        {
                            if (_reportedBy != "")
                            {
                                if (_mainManager.IncidentManager.AddIncident(_description, _reported, _reportedBy, _severity))
                                {
                                    MessageBox.Show("Incident Has Been Succesfully Created!");
                                    txtAdditionalInfo.Text = "Additional Info";
                                    txtFirtName.Text = "";
                                    txtLastName.Text = "";
                                    cbPartiesInvolved.SelectedItem = null;
                                    cbSeverity.SelectedItem = null;

                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select your Employee ID");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a severity");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input a description");
                    }
                }
                else
                {
                    MessageBox.Show("Please Input both a first name and a last name");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Incident Creation has failed", ex);
            }
        }
    }
}
