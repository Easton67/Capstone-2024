using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/01/2024
    /// Summary: Class used to represent an item in the inventory of the Homeless Shelter. 
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </summary>
    public class Item
    {
        public int ItemID {  get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        [DisplayName("Quanity")]
        public int QtyOnHand { get; set; }

        [DisplayName("Normal Stock Quantity")]
        public int NormalStockQty {  get; set; }

        [DisplayName("When to reorder")]
        public int ReorderPoint {  get; set; }

        [DisplayName("Is Ordered")]
        public int OnOrder {  get; set; }
    }
}
