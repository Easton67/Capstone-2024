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
using WpfPresentation.Pages.Stats;

namespace WpfPresentation.Pages.Appointments
{
    /// <summary>
    /// Interaction logic for ViewAppointment.xaml
    /// </summary>
    public partial class ViewAppointment : Page
    {
        private static ViewAppointment instance = null;

        private MainManager mainManager;

        public static ViewAppointment GetViewAppointmentPage()
        {
            return instance ?? (instance = new ViewAppointment());
        }

        public ViewAppointment()
        {
            InitializeComponent();
            mainManager = MainManager.GetMainManager();
            GetListOfAppointments();
        }

        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the xaml.cs for Appointments.
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/24/2024
        /// What Was Changed:   Added main manager
        /// </summary>
        public void GetListOfAppointments()
        {
            try
            {
                datAppointment.ItemsSource = mainManager.AppointmentManager.GetAllAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


        /// <summary>
        ///Creator:            Miyada Absas
        ///Created:            03/14/2024
        ///Summary:            This is the xaml.cs for Remove Appointments.
        ///Last Updated By:     Miyada Absas
        ///Last Updated:       03/14/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)datAppointment.SelectedItem;
            if (appointment == null)
            {
                MessageBox.Show("Please Select An Appointment");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Are you sure? This cannot be undone.", "Caution", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            
            try
            {
                if(result == MessageBoxResult.Yes)
                {
                    bool deleted = mainManager.AppointmentManager.RemoveAppointment(appointment);
                    if (deleted)
                    {
                        GetListOfAppointments();
                    }
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/25/2024
        ///Summary:            Click handler for the create appointment button on the view appointments page.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/25/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void CreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgCreateAppointment());
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/25/2024
        ///Summary:            Click handler for the cancel button on the view appointments page.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/25/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void ExitAppointment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }
    }
}
