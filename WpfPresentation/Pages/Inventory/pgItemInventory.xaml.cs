using DataObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfPresentation.Pages
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/01/2024
    /// Summary: Interaction logic for pgItemInventory.xaml
    /// Last Updated By: Tyler Barz
    /// Last Updated: 02/24/2024
    /// What Was Changed: Implemented main manager
    /// </summary>
    public partial class pgItemInventory : Page
    {
        Item _selectedItem = new Item();
        private MainManager _mainManager;
        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: Constructor for pgItemInventory.xaml
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public pgItemInventory()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }

        private static pgItemInventory instance = null;
        public static pgItemInventory GetPgItemInventory()
        {
            return instance ?? (instance = new pgItemInventory());
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: This method is for populating the datInventory DataGrid with items retrieved from the ItemManager.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                datItemInventory.ItemsSource = _mainManager.ItemManager.GetItems();

                if (datItemInventory.ItemsSource == null)
                {
                    MessageBox.Show("No inventory items found. Add an item to create an inventory");
                }
            }
            catch
            {
                MessageBox.Show("No inventory items found. Add an item to create an inventory.", "No items found");
            }
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 02/20/2024
        /// Summary: This method sets the selected item to the class level variable to be used for updating.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Added try catch
        /// </summary>
        private void datItemInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _selectedItem = (Item)datItemInventory.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a valid inventory item");
            }
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 02/20/2024
        /// Summary: This method grabs the new order quantity with the selected item and calls the logic layer
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnUpdateQty_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItem.ItemID == 0)
            {
                MessageBox.Show("Please select an item.", "Invalid selection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _selectedItem.QtyOnHand = int.Parse(tbxUpdateQty.Text);

                try
                {
                    _mainManager.ItemManager.UpdateQtyOnHand(_selectedItem);
                }
                catch
                {
                    MessageBox.Show("Database failed to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Please input a quantity.", "Invalid number", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            datItemInventory.ItemsSource = _mainManager.ItemManager.GetItems();
            tbxUpdateQty.Text = string.Empty;
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: When a item in the grid is selected, a edit item window will pop up
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Initial Creation
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Added check if the selected index was out of bounds
        /// </summary>
        private void datItemInventory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(datItemInventory.SelectedIndex < 0)
            {
                return;
            }
            var item = datItemInventory.SelectedItem as Item;


            var editWindow = new UtilWindows.EditInventoryItem(item);
            editWindow.ShowDialog();
            editWindow = null;

            if (editWindow == null)
            {
                datItemInventory.ItemsSource = _mainManager.ItemManager.GetItems();
            }

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: edit item click function
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            var item = datItemInventory.SelectedItem as Item;

            if (item == null)
            {
                MessageBox.Show("Please select an item to edit");
            }
            else
            {
                var editWindow = new UtilWindows.EditInventoryItem(item);
                editWindow.ShowDialog();
                editWindow = null;

                if (editWindow == null)
                {
                    datItemInventory.ItemsSource = _mainManager.ItemManager.GetItems();
                }
            }
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: add item click function
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var addItemWindow = new UtilWindows.AddInventoryItem();
            addItemWindow.ShowDialog();
            addItemWindow = null;
            if (addItemWindow == null)
            {
                //add try catch
                datItemInventory.ItemsSource = _mainManager.ItemManager.GetItems();
            }
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: delete inventory click function
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        private void btnDeleteInventory_Click(object sender, RoutedEventArgs e)
        {
            //try catch
            var result = MessageBox.Show("Deleting the inventory will set the on stock quantity of all items to 0. Are you sure you want to delete the inventory?", "Delete Inventory", button: MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes
                    _mainManager.ItemManager.DeleteInventory();
                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    break;
            }
            datItemInventory.ItemsSource = _mainManager.ItemManager.GetItems();
        }
    }
}
