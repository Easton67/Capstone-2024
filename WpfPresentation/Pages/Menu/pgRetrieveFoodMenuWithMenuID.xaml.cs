using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfPresentation.Pages.Stats;

namespace WpfPresentation.Pages.Menu
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/08/2024
    /// Summary: Creation of the retrieve food menu with menu ID page.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgRetrieveFoodMenuWithMenuID : Page
    {
        WeekFoodMenuManager _weekFoodMenuManager;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/08/2024
        /// Summary: Creation of the pgRetrieveFoodMenuWithMenuID constructor method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public pgRetrieveFoodMenuWithMenuID()
        {
            InitializeComponent();
            _weekFoodMenuManager = new WeekFoodMenuManager();
            PopulateMenuIDs();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/27/2024
        /// Summary: Method for populating the menuIDComboBox.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/27/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void PopulateMenuIDs()
        {
            try
            {
                List<string> menuNames = new List<string>();
                List<WeekFoodMenuVM> weekFoodMenuVMs = _weekFoodMenuManager.getWeekFoodMenus();
                foreach (var menu in weekFoodMenuVMs)
                {
                    menuNames.Add(menu.MenuName);
                }
                menuNameComboBox.ItemsSource = menuNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading menu names: " + ex.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/08/2024
        /// Summary: Code for the submit button.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/05/2024
        /// What Was Changed: Fixing an issue where an exception is thrown when no menu is selected.
        /// </summary>
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (menuNameComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a food menu to view.");
                }
                else
                {
                    string menuName = menuNameComboBox.SelectedValue.ToString();
                    List<WeekFoodMenuVM> weekFoodMenuVMs = _weekFoodMenuManager.getWeekFoodMenus();
                    WeekFoodMenuVM weekFoodMenuVM = new WeekFoodMenuVM();
                    foreach (var menu in weekFoodMenuVMs)
                    {
                        if (menu.MenuName == menuName)
                        {
                            weekFoodMenuVM = menu;
                        }
                    }
                    menuNameComboBox.SelectedItem = null;
                    NavigationService.Navigate(new pgViewFoodMenu(weekFoodMenuVM));
                }
            }
            catch
            {
                MessageBox.Show("There was a problem retrieveing the food menu.");
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/08/2024
        /// Summary: Creation of the getFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private WeekFoodMenuVM getFoodMenu(int menuID)
        {
            _weekFoodMenuManager = new WeekFoodMenuManager();
            return _weekFoodMenuManager.getWeekFoodMenu(menuID);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Code for the cancel button.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/22/2024
        /// What Was Changed: Cancel button now navigates to Home.
        /// </summary>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Logic for navigation in the pgRetrieveFoodMenuWithMenuID file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgRetrieveFoodMenuWithMenuID instance = null;
        public static pgRetrieveFoodMenuWithMenuID GetpgRetrieveFoodMenuWithMenuID()
        {
            return new pgRetrieveFoodMenuWithMenuID();
        }
    }
}
