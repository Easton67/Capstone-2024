using DataObjects.Kitchen;
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

namespace WpfPresentation.Pages.Menu
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 02/05/2024
    /// Summary: Code behind file for the pgViewFoodMenu.xaml file.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 02/05/2024
    /// What Was Changed: Initial Creation
    /// </summary>    
    public partial class pgViewFoodMenu : Page
    {
        private IWeekFoodMenuManager _weekFoodMenuManager = null;
        private WeekFoodMenuVM foodMenu = null;
        public int _menuID { get; set; }
        public string _menuTitle { get; set; }

        List<Label> _mealLabelList = new List<Label>();
        public pgViewFoodMenu()
        {
            InitializeComponent();
            if (_menuID == 0)
            {
                var retrieveFoodMenuPage = new pgRetrieveFoodMenuWithMenuID();
                retrieveFoodMenuPage.ShowsNavigationUI = true;
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Code behind file for the pgViewFoodMenu.xaml file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public pgViewFoodMenu(WeekFoodMenuVM foodMenu)
        {
            InitializeComponent();
            this.foodMenu = foodMenu;
            _menuTitle = foodMenu.MenuName;
            lblFoodMenuTitle.Content = _menuTitle;
            setUpMealLabels();
            for (int i = 0; i < foodMenu.recipes.Count; i++)
            {
                _mealLabelList[i].Content = foodMenu.recipes[i].RecipeName;
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Code behind file for the pgViewFoodMenu.xaml file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void setUpMealLabels()
        {
            _mealLabelList.Add(lblFoodMenuItemOne);
            _mealLabelList.Add(lblFoodMenuItemTwo);
            _mealLabelList.Add(lblFoodMenuItemThree);
            _mealLabelList.Add(lblFoodMenuItemFour);
            _mealLabelList.Add(lblFoodMenuItemFive);
            _mealLabelList.Add(lblFoodMenuItemSix);
            _mealLabelList.Add(lblFoodMenuItemSeven);
            _mealLabelList.Add(lblFoodMenuItemEight);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the getMenuMeals method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private List<MenuMealVM> getMenuMeals(int menuID)
        {
            try
            {
                return _weekFoodMenuManager.getMenuMeals(menuID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get menu meals \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
                return new List<MenuMealVM>();
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/05/2024
        /// Summary: Creation of the getFoodMenu method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private WeekFoodMenuVM getFoodMenu(int menuID)
        {
            try
            {

                return _weekFoodMenuManager.getWeekFoodMenu(menuID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get food menu \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
                return new WeekFoodMenuVM();
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Getting the exit button in the view menu page to work.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/22/2024
        /// What Was Changed: Exit button navigates to Retrieve food menu with menu ID page.
        /// </summary>
        private void btnExitFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgRetrieveFoodMenuWithMenuID());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Logic for navigation in the pgCreateFoodMenu file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgViewFoodMenu instance = null;
        public static pgViewFoodMenu GetpgViewFoodMenu()
        {
            return instance ?? (instance = new pgViewFoodMenu());
        }
    }
}
