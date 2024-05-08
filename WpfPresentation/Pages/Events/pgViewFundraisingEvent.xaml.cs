using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfPresentation.Pages.Events
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 04/18/2024
    /// Summary: Interaction logic for pgViewFundraisingEvent
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/18/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public partial class pgViewFundraisingEvent : Page
    {
        private static pgViewFundraisingEvent instance = null;
        public static pgViewFundraisingEvent GetViewFundraisingEventPage()
        {
            return instance ?? (instance = new pgViewFundraisingEvent());
        }

        public pgViewFundraisingEvent()
        {
            InitializeComponent();
        }

        /// <summary>
		/// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: This event handler takes the user to the 
        ///          create fundraising event page.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgCreateFundraisingEvent());
        }

        /// <summary>
		/// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: This event handler lets the user be directed back to
        ///          the Main Window.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: This event handler will load the fundraising 
        ///          content for the datagrid. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgFundraisingEvent.ItemsSource == null) 
                {
                    var fundraisingEventManager = new FundraisingEventManager();
                    dgFundraisingEvent.ItemsSource = fundraisingEventManager.GetFundraisingEvents();

                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                    dgFundraisingEvent.Columns.RemoveAt(7);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
