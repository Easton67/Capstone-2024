using DataObjects;
using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer
{
    /// <summary>
    ///Creator:Suliman Adam Suliman
    ///Created: 02/02/2024
    ///Summary: Created a public InterFace for KitchenInventoryItem.
    ///Last Updated By: Ethan McElree
    ///Last Updated: 4/15/2024
    ///What Was Changed: Added ViewKitchenInventoryItemsByCategory.
    /// </summary>
    public interface IKitchenInventoryItemManager
    {

        List<KitchenInventoryItem> GetKitchenInventoryItems();
        List<KitchenInventoryItemVM> ViewKitchenInventoryItemsByCategory(string category);
    }
}
