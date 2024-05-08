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
using System.Linq.Expressions;

namespace WpfPresentation.UtilWindows
{
    /// <summary>
    /// Interaction logic for AddInventoryItem.xaml
    /// </summary>
    public partial class AddInventoryItem : Window
    {
        ItemManager _itemManager = new ItemManager();

        public AddInventoryItem()
        {
            InitializeComponent();
        }


        private static AddInventoryItem instance = null;

        public static AddInventoryItem GetAddInventoryItemWindow()
        {
            return instance ?? (instance = new AddInventoryItem());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Item item = new Item()
                {
                    ItemName = txtItemName.Text,
                    ItemDescription = txtItemDescription.Text,
                    QtyOnHand = Int32.Parse(txtQtyOnHand.Text),
                    NormalStockQty = Int32.Parse(txtNormalStockQty.Text),
                    ReorderPoint = Int32.Parse(txtReorderPoint.Text),
                    OnOrder = Int32.Parse(txtOnOrder.Text)
                };


                try
                {
                    int itemsAdded = _itemManager.AddItem(item);
                    if (itemsAdded > 0)
                    {
                        MessageBox.Show("Item added!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unable to add item, please try again", ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add item, please try again", ex.Message);
            }

        }
    }
}

