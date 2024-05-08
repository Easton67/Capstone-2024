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
using System.Windows.Shapes;
using DataObjects;

namespace WpfPresentation.UtilWindows
{ /// <summary>
  /// Creator: Andres Garcia
  /// Created: 02/13/2024
  /// Summary: Interaction logic for pgEditInventoryItem.xaml
  /// Last Updated By: Andres Garcia
  /// Last Updated: 02/13/2024
  /// What Was Changed: Initial Creation
  /// </summary>
    public partial class EditInventoryItem : Window
    {
        private static Item _item = null;

        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 02/13/2024
        /// Summary: Sets the item passed to the window to the class level variable
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public EditInventoryItem(Item item)
        {
            _item = item;
            InitializeComponent();
        }
        private static EditInventoryItem instance = null;

        public static EditInventoryItem GetEditInventoryItemWindow()
        {
            return instance ?? (instance = new EditInventoryItem(_item));
        }

        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 02/13/2024
        /// Summary: When the window is loaded the properties of the items
        /// passed to the window will be auto loaded in the text boxes
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var _itemManager = new ItemManager();
                _item = _itemManager.GetItemByItemId(_item.ItemID);

                txtItemName.Text = _item.ItemName;
                txtItemDescription.Text = _item.ItemDescription;
                txtQtyOnHand.Text = _item.QtyOnHand.ToString();
                txtNormalStockQty.Text = _item.NormalStockQty.ToString();
                txtReorderPoint.Text = _item.ReorderPoint.ToString();
                txtOnOrder.Text = _item.OnOrder.ToString();


            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 02/13/2024
        /// Summary: Allows user to close the window without updating an item
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 02/13/2024
        /// Summary: Calls the editItem method to update an item in the database. saves the item and closes the window
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Item updatedItem = new Item()
            {
                ItemID = _item.ItemID,
                ItemName = txtItemName.Text,
                ItemDescription = txtItemDescription.Text,
                QtyOnHand = int.Parse(txtQtyOnHand.Text),
                NormalStockQty = int.Parse(txtNormalStockQty.Text),
                ReorderPoint = int.Parse(txtReorderPoint.Text),
                OnOrder = int.Parse(txtOnOrder.Text)
            };


            try
            {
                var inventoryManager = new ItemManager();
                inventoryManager.EditItem(_item.ItemID, updatedItem);
                MessageBox.Show("Item updated!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to update item, please try again", ex.Message);
            }

            this.Close();

        }

        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Delete item button deletes item from inventory
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var inventoryManager = new ItemManager();
                inventoryManager.DeleteItem(_item.ItemID);
                MessageBox.Show("Item has been deleted from the inventory");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to delete item, please try again later",ex.Message);
            }

        }
    }
}
