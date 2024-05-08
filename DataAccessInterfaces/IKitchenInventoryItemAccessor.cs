using DataObjects;
using DataObjects.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///Creator:Suliman Adam Suliman
///Created: 02/02/2024
///Summary: Created a DataAccessInterfaces for kitchenInventoryItem.
///Last Updated By:
///Last Updated:
///What Was Changed: No changes.
/// </summary>
namespace DataAccessInterfaces
{

    /// <summary>
    ///Creator:Suliman Adam Suliman
    ///Created: 02/02/2024
    ///Summary: Created an InterFace for IKitchenInventoryAccessor.
    ///Last Updated By: Ethan McElree
    ///Last Updated: 4/15/2024
    ///What Was Changed: Added ViewKitchenInventoryItemsByCategory.
    /// </summary>
    public interface IKitchenInventoryItemAccessor
    {
        List<KitchenInventoryItem> ViewKitchenInventoryItem();
        List<KitchenInventoryItemVM> ViewKitchenInventoryItemsByCategory(string category);

    }
}
