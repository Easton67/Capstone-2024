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

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 02/27/2024
    /// Summary: DeleteVolunteerEventPage
    /// Last updated By: Darryl Shirley
    /// Last Updated: 2/27/2024
    /// What was changed/updated: Initial Creation
    /// </summary>
    public partial class DeleteVolunteerEventPage : Window
    {
        LogicLayer.EventManager _eventManager = null;
        EventVM _eventVM = null;

        public DeleteVolunteerEventPage(EventVM eventVM)
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
            _eventVM = eventVM;
            lbldeleteQuestion.Content += " " + _eventVM.EventName;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/27/2024
        /// Summary: btnCancel_Click 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/27/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/27/2024
        /// Summary: btnSubmit_Click Method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/27/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _eventManager = new LogicLayer.EventManager();
            try
            {
                if (_eventManager.addVolunteerEvent(_eventVM.EventID, _eventVM.VolunteersNeeded, 0) == true)
                {
                    this.DialogResult = true;
                    MessageBox.Show("Event Has been Deleted from the list!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
