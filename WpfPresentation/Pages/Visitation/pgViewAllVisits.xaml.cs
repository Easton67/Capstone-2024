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
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Pages.Visitation
{
    /// <summary>
    ///Creator:            Ibrahim Albashair
    ///Created:            02/13/2024
    ///Summary:            This contains the interaction logic for pgAddVendors
    ///Last Updated By:    Ibrahim Albashair
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>

    public partial class pgViewAllVisits : Window
    {
        VisitManager _visitManager;

        string _employeeFirstName;
        string _employeelastName;
        private static pgViewAllVisits instance = null;

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            Constructor
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        /// 
        public static pgViewAllVisits GetViewAllVisitsPage(string firstName, string lastName)
        {
            return instance ?? (instance = new pgViewAllVisits(firstName, lastName));

        }
        public pgViewAllVisits(string EmployeeFirstName, string EmployeeLastName)
        {
            _visitManager = new VisitManager();
            _employeeFirstName = EmployeeFirstName;
            _employeelastName = EmployeeLastName;
            InitializeComponent();

            // Change Lable
            lblUser.Content = "Logged in as: " + EmployeeFirstName + " " + EmployeeLastName;

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
            this.Close();
        }
        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            loads info into datagrid
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void LoadDataGrid()
        {
            // Fill Data
            List<Visit> visits = new List<Visit>();
            try
            {
                visits = _visitManager.GetAllVisits();
                dgVisits.ItemsSource = visits;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Finding Vists");

            }
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for grid load
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        /// <summary>
        ///Creator:            Ibrahim Albashair
        ///Created:            02/13/2024
        ///Summary:            logic for double click on data grid
        ///Last Updated By:    Ibrahim Albashair
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void dgVisits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var visit = dgVisits.SelectedItem as Visit;

            if (visit != null)
            {
                pgEditVisit window = new pgEditVisit(visit);
                window.ShowDialog();
                if (window.DialogResult == true || window.DialogResult == false)
                {
                    LoadDataGrid();
                }
            }


        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            pgCreateVisit window = new pgCreateVisit();
            window.ShowDialog();
            LoadDataGrid();
        }
    }
}
