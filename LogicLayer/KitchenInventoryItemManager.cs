using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects.Kitchen;

namespace LogicLayer
{

    /// <summary>
    /// Creator: Suliman Suliman
    /// Created: 02/02/2024
    /// Summary: Created a public class KitchenInventoryItemManager and 
    /// implemented IKitchenInventoryItemManager interface.
    /// Last Updated By:
    /// Last Updated: 
    /// What Was Changed: 
    /// </summary>
    public class KitchenInventoryItemManager : IKitchenInventoryItemManager
    {
        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 02/02/2024
        /// Summary: Created an object from IKitchenInventoryItemAccessor.
        /// Last Updated By:
        /// Last Updated: 
        /// What Was Changed: 
        /// </summary>
        private IKitchenInventoryItemAccessor _itemAccessor;

        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 02/02/2024
        /// Summary: Created a Constructor for KitchenInventoryItemManager and 
        /// pass no parameter.
        /// Last Updated By:
        /// Last Updated: 
        /// What Was Changed: 
        /// </summary>
        public KitchenInventoryItemManager()
        {
            _itemAccessor = new KitchenInventoryItemAccessor();
        }

        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 02/02/2024
        /// Summary: Created a Constructor for KitchenInventoryItemManager.
        /// Last Updated By:
        /// Last Updated: 
        /// What Was Changed: 
        /// </summary>
        public KitchenInventoryItemManager(IKitchenInventoryItemAccessor kitchenInventoryItemAccessor)
        {
            _itemAccessor = kitchenInventoryItemAccessor;
        }

        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 02/02/2024
        /// Summary: Created a public try catch for KitchenInventoryItem.
        /// Last Updated By:
        /// Last Updated: 
        /// What Was Changed: 
        /// </summary>
        public List<KitchenInventoryItem> GetKitchenInventoryItems()
        {

            try
            {
                return _itemAccessor.ViewKitchenInventoryItem();
            }
            catch (Exception )
            {

                throw;
            }

            
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/15/2024
        /// Summary: Manager method for filtering kitchen inventory items.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/15/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public List<KitchenInventoryItemVM> ViewKitchenInventoryItemsByCategory(string category)
        {
            try
            {
                return _itemAccessor.ViewKitchenInventoryItemsByCategory(category);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get kitcehn items by their category.", ex);
            }
        }
    }
}
