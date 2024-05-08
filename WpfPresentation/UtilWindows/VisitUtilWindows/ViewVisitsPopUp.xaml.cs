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
    /// Interaction logic for ViewVisitsPopUp.xaml
    /// </summary>
    public partial class ViewVisitsPopUp : Window
    {
        VisitManager _visitManager;

        string _employeeFirstName;
        string _employeelastName;

        public ViewVisitsPopUp(string EmployeeFirstName, string EmployeeLastName)
        {
            _visitManager = new VisitManager();
            _employeeFirstName = EmployeeFirstName;
            _employeelastName = EmployeeLastName;
            InitializeComponent();

            // Change Lable
            lblUser.Content = "Logged in as: " + EmployeeFirstName + "" + EmployeeLastName;  

        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void LoadDataGrid()
        {
            // Fill Data
            List<Visit> visits = new List<Visit>();
            try
            {
                visits = _visitManager.GetAllVisitsByName(_employeeFirstName, _employeelastName);
                dgVisits.ItemsSource = visits;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Finding Vists");

            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {            
            LoadDataGrid();            
        }

        private void dgVisits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            var visit = dgVisits.SelectedItem as Visit;

            if (visit != null) 
            {
                EditVisitPopUp window = new EditVisitPopUp(visit);
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    LoadDataGrid();
                }
            }


        }
    }
}
