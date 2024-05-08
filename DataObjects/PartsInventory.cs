using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <Summary>
    /// Creator: Mitchell Stirmel
    /// created: 02/07/2024
    /// Summary: MaintenanceItem.cs
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </Summary>
    public class PartsInventory
    {
        [DisplayName("Item ID")]
        public string _itemID { get; set; }
        [DisplayName("Category")]
        public string _category {  get; set; }
        [DisplayName("Quantity")]
        public int _quantity {  get; set; }
        [DisplayName("Stock Type")]
        public string _stockType {  get; set; }

    }
}
