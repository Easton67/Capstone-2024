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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.Events
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/29/2024
    /// Summary: Interaction logic for pgEventMealPlan
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 03/29/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgEventMealPlan : Page
    {
        private static pgEventMealPlan instance = null;
        private EventMealPlan _eventMealPlan = null;

        public static pgEventMealPlan GetEventMealPlanPage()
        {
            return instance ?? (instance = new pgEventMealPlan());
        }

        public pgEventMealPlan(EventMealPlan eventMealPlan)
        {
            _eventMealPlan = eventMealPlan;
            InitializeComponent();
        }

        public pgEventMealPlan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: Event handler to close the event meal plan page 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Events.pgViewEventMeals());
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: The content that will display upon opening pgEventMealPlan
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = _eventMealPlan.EventName;
            txtDate.Text = _eventMealPlan.Date.ToShortDateString();
            txtTime.Text = _eventMealPlan.Time.ToShortTimeString();
            txtFood.Text = _eventMealPlan?.Food?.ToString();
            txtBeverages.Text = _eventMealPlan?.Beverages?.ToString();

            txtName.IsReadOnly = true;
            txtDate.IsReadOnly = true;
            txtTime.IsReadOnly = true;
            txtFood.IsReadOnly = true;
            txtBeverages.IsReadOnly = true;
        }
    }
}
