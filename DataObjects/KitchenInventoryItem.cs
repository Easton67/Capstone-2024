using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Kitchen
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: WeekFoodMenu data object class for storage.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class KitchenInventoryItem
    {
        public int KitchenItemID {  get; set; }
        public string ItemName { get; set; }
        public int QuantityInStock { get; set; }
        public string Category {  get; set; }
        public decimal UnitCost { get; set; }
        public string Supplier {  get; set; }
        public int ReorderQuantity { get; set; }
    }

    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 01/30/2024
    /// Summary: Creation of the MenuMeal view model.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 01/30/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class KitchenInventoryItemVM : KitchenInventoryItem
    {
    }
}
