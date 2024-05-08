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

namespace WpfPresentation.Pages.Events
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 04/01/2024
    /// Summary: Interaction logic for pgViewEventMeals
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgViewEventMeals : Page
    {
        private static pgViewEventMeals instance = null;
        private IEventMealPlanManager _eventMealPlanManager;

        public static pgViewEventMeals GetViewEventMealsPage()
        {
            return instance ?? (instance = new pgViewEventMeals());
        }

        public pgViewEventMeals()
        {
            InitializeComponent();
            _eventMealPlanManager = new EventMealPlanManager();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: The content that will display upon opening pgViewEventMeals. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var eventMealPlanManager = new EventMealPlanManager();
                cboEventName.ItemsSource = eventMealPlanManager.GetEventNamesForDropDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: Event handler to close the page and go back to the main window.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: When the continue button is clicked, the event meal plan will display.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboEventName.SelectedItem == null)
                {
                    MessageBox.Show("You must select an event.");
                }
                else
                {
                    string eventName = cboEventName.SelectedItem.ToString();
                    EventMealPlan eventMealPlan = _eventMealPlanManager.GetMealPlanByName(eventName);
                    NavigationService.Navigate(new pgEventMealPlan(eventMealPlan));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This event does not yet have a meal plan in place.");
            }
        }
    }
}
