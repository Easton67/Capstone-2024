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

namespace WpfPresentation.UtilWindows.AdminUtilWindows
{
    /// <summary>
    /// Creator: Matthew Baccam
    /// Created: 03/21/2024
    /// Summary: Window for Selecting a user
    /// Last Updated By: Matthew Baccam
    /// Last Updated: 03/21/2024
    /// What Was changed: Initial creation
    /// </summary>
    public partial class SelectUserTypeWindow : Window
    {
        private User _user;
        public User UserType { get => _user; set => _user = value; }

        public SelectUserTypeWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Sets the data to pass to the page a employee
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            _user = new Employee();
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Sets the data to pass to the page a client
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            _user = new Client();
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Sets the data to pass to the page a volunteer
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCreateVolunteer_Click(object sender, RoutedEventArgs e)
        {
            _user = new Volunteer();
            this.DialogResult = true;
            this.Close();
        }
    }
}
