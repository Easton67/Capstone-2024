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
using DataObjects.Kitchen;
using LogicLayer;
namespace WpfPresentation.Pages.Inventory
{
    /// <summary>
    /// Interaction logic for PgKitchenInventoryItem.xaml
    /// </summary>
    public partial class PgKitchenInventoryItem : Page
    {
        MainManager mainManager;
        public PgKitchenInventoryItem()
        {
            mainManager = MainManager.GetMainManager();
            InitializeComponent();

            cboKitchenInventory.ItemsSource = new List<string> { "All", "Food", "Supplies", "Ingredient" };
        }

        /// <summary>
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/24/2024
        /// What Was Changed:   Added try-catch, main manager, tasked msg box
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgKitchenInventoryItemtList.ItemsSource = mainManager.KitchenManager.GetKitchenInventoryItems();
            }
            catch
            {
                Task.Run(() => MessageBox.Show("Unable to load kitchen inventory items"));
                dgKitchenInventoryItemtList.Items.Clear();
            }
        }              

        private static PgKitchenInventoryItem pgKitchenInventoryItem = null;
        public static PgKitchenInventoryItem GetPgKitchenInventoryItemPage()
        {
            return pgKitchenInventoryItem ?? (pgKitchenInventoryItem = new PgKitchenInventoryItem());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/15/2024
        /// Summary: Method for filtering the kitchen inventory items by their category.
        /// Last Updated By: Ethan McElree
        /// Last Updated 04/15/2024
        /// What was changed: Initial Creation
        /// </summary>
        private void cboKitchenInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedKitchenInventoryItemCategory = cboKitchenInventory.SelectedItem.ToString();
                KitchenInventoryItemManager kitchenInventoryItemManager = new KitchenInventoryItemManager();
                if (selectedKitchenInventoryItemCategory == "All")
                {
                    dgKitchenInventoryItemtList.ItemsSource = kitchenInventoryItemManager.GetKitchenInventoryItems();
                }
                else
                {
                    dgKitchenInventoryItemtList.ItemsSource = kitchenInventoryItemManager.GetKitchenInventoryItems().Where(item => item.Category == selectedKitchenInventoryItemCategory);
                }               
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to filter kitchen inventory items");
            }
        }
    }
}
