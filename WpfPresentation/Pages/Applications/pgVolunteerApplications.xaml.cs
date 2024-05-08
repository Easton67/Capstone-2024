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

namespace WpfPresentation.Pages.Applications
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/07/2024
    ///Summary:            C# code for the volunteer applications page
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/07/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgVolunteerApplications : Page
    {
        private MainManager _mainManager;
        private VolunteerApplication _volunteerApplication;
        private VolunteerApplicationInfo _volunteerInfo;
        public pgVolunteerApplications()
        {
            InitializeComponent();
            HideInfoLabels();
            _mainManager = MainManager.GetMainManager();
            GetVolunteerApplications();
            PopulateFilter();

        }

        private static pgVolunteerApplications _instance = null;
        public static pgVolunteerApplications GetPgVolunteerApplications()
        {
            return _instance ?? (_instance = new pgVolunteerApplications());
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            03/20/2024
        ///Summary:            Returns the list of volunteer applications
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       03/20/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        public void GetVolunteerApplications()
        {
            try
            {
                datVolunteerApplications.ItemsSource = _mainManager.VolunteerApplicationManager.GetVolunteerApplications();
            }
            catch (Exception ex)  
            {
                MessageBox.Show("An error occured while getting applications. exception: " + ex.Message);
            }
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            03/22/2024
        ///Summary:            datVolunteerApplications_SelectionChanged method
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Added FillVolunteerInfo method
        /// </summary>
        private void datVolunteerApplications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
                if (datVolunteerApplications.SelectedItems.Count != 0)
                {
                    _volunteerApplication = datVolunteerApplications.SelectedItem as VolunteerApplication;
                    ShowInfoLabels();
                    FillVolunteerInfo();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            03/22/2024
        ///Summary:            btnHoldApplication_Click method
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       03/27/2024
        ///What Was Changed:   added data grid refresh
        /// </summary>
        private void btnHoldApplication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_volunteerApplication != null)
                {
                    if (_volunteerApplication.Status != "On Hold")
                    {
                        VolunteerApplicationOnHold volunteerApplicationOnHold = new VolunteerApplicationOnHold(_volunteerApplication);
                        volunteerApplicationOnHold.ShowDialog();
                        if (datVolunteerApplications.ItemsSource != null)
                        {
                            datVolunteerApplications.ItemsSource = null;
                            datVolunteerApplications.ItemsSource = _mainManager.VolunteerApplicationManager.GetVolunteerApplications();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Application is already on hold.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a volunteer application from the list.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("We were unable to bring up the onHold page" , ex.Message);
            }
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            Fills volunteer info 
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>

        private void FillVolunteerInfo()
        {
            try
            {
                _volunteerInfo = _mainManager.VolunteerApplicationManager.GetApplicationInfo(_volunteerApplication.ApplicationID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get volunteer info. \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
            if (_volunteerInfo.GivenName == null)
            {
                //Prevent nullreferenceexception
                MessageBox.Show("Unable to pull back application information.", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            tbkVolunteerConerns.Text = _volunteerInfo.VolunteerConcerns;
            tbkVolunteerReason.Text = _volunteerInfo.ApplicationReason;
            lblVolunteerEmail.Content = _volunteerInfo.Email;
            lblVolunteerName.Content = _volunteerInfo.GivenName + " " + _volunteerInfo.FamilyName;
            lblVolunteerPhone.Content = _volunteerInfo.PhoneNumber;
            lblVolunteerHours.Content = _volunteerInfo.HoursDesired;
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            Shows all the info labels, this happens when the focus is shifted to an actual application.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void ShowInfoLabels()
        {
            //Labels 1-7 are just text labels and don't need any changing, so they don't have special names
            lblInfo0.Visibility = Visibility.Visible;
            lblInfo1.Visibility = Visibility.Visible;
            lblInfo2.Visibility = Visibility.Visible;
            lblInfo3.Visibility = Visibility.Visible;
            lblInfo4.Visibility = Visibility.Visible;
            lblInfo5.Visibility = Visibility.Visible;
            lblInfo6.Visibility = Visibility.Visible;
            lblInfo7.Visibility = Visibility.Visible;
            tbkVolunteerConerns.Visibility = Visibility.Visible;
            tbkVolunteerReason.Visibility = Visibility.Visible;
            lblVolunteerEmail.Visibility = Visibility.Visible;
            lblVolunteerName.Visibility = Visibility.Visible;
            lblVolunteerPhone.Visibility = Visibility.Visible;
            lblVolunteerHours.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            Hides all the info labels, this happens on startup, so they are hidden when no application is actually selected. 
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void HideInfoLabels()
        {
            //Labels 1-7 are just text labels and don't need any changing, so they don't have special names
            lblInfo0.Visibility = Visibility.Hidden;
            lblInfo1.Visibility = Visibility.Hidden;
            lblInfo2.Visibility = Visibility.Hidden;
            lblInfo3.Visibility = Visibility.Hidden;
            lblInfo4.Visibility = Visibility.Hidden;
            lblInfo5.Visibility = Visibility.Hidden;
            lblInfo6.Visibility = Visibility.Hidden;
            lblInfo7.Visibility = Visibility.Hidden;
            tbkVolunteerConerns.Visibility = Visibility.Hidden;
            tbkVolunteerReason.Visibility = Visibility.Hidden;
            lblVolunteerEmail.Visibility = Visibility.Hidden;
            lblVolunteerName.Visibility = Visibility.Hidden;
            lblVolunteerPhone.Visibility = Visibility.Hidden;
            lblVolunteerHours.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///Creator:            Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:            btnAcceptApplication_Click() This method is Accepting the volunteer                          Application Button and return void. 
        ///Last Updated By:   
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        private void btnAcceptApplication_Click(object sender, RoutedEventArgs e)
        {
            VolunteerApplication volunteerApplication = null;

            volunteerApplication = (VolunteerApplication)datVolunteerApplications.SelectedItem;

            if (volunteerApplication != null)
            {
                volunteerApplication.Status = "Accepted";
                bool result = _mainManager.VolunteerApplicationManager.AcceptVolunteerApplication(volunteerApplication);
                if (result)
                {
                    GetVolunteerApplications();
                }
                else
                {
                    MessageBox.Show("Accepting is not done!");
                }
            }
            else
            {
                MessageBox.Show("Please Select a row");
            }
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            04/10/2024
        ///Summary:            btnDenyApplication_Click method
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       04/10/2024
        ///What Was Changed:   added data grid refresh
        /// </summary>
        private void btnDenyApplication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_volunteerApplication != null)
                {
                    if (_volunteerApplication.Status != "Rejected")
                    {
                        pgRejectVolunteerApplication rejectVolunteerApplication = new pgRejectVolunteerApplication(_volunteerApplication);
                        rejectVolunteerApplication.ShowDialog();
                        if (datVolunteerApplications.ItemsSource != null)
                        {
                            datVolunteerApplications.ItemsSource = null;
                            datVolunteerApplications.ItemsSource = _mainManager.VolunteerApplicationManager.GetVolunteerApplications();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Application is already rejected.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a volunteer application from the list.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("We were unable to bring up the deny page", ex.Message);
            }
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            04/05/2024
        /// Summary:            Method used to filter the volunteer applications
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       04/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void PopulateFilter()
        {
            try
            {
                List<string> volunteerApplicationList = new List<string> { "All Applications" };
                volunteerApplicationList.AddRange(selectionOptions);
                cboFilter.ItemsSource = volunteerApplicationList;
                cboFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating filter: " + ex.Message);

            }
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            04/05/2024
        /// Summary:            Event used to filter the volunteer applications
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       04/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private List<string> selectionOptions = new List<string>() { "Awaiting Review", "On Hold", "Accepted", "Rejected" };
        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<VolunteerApplication> volunteerApplications = _mainManager.VolunteerApplicationManager.GetVolunteerApplications();
                string selection = cboFilter.SelectedItem.ToString();

                if (selectionOptions.Contains(selection))
                {
                    datVolunteerApplications.ItemsSource = volunteerApplications.Where(m => m.Status == selection).ToList();
                }
                else
                {
                    datVolunteerApplications.ItemsSource = volunteerApplications;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }
    }
}
