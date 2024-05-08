using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /* 
       <summary>
           Creator:            Mitchell Stirmel
           Created:            02/07/2024
           Summary:            IMaintenanceItemManager.cs
           Last Updated By:    Darryl Shirley
           Last Updated:       02/07/2024
           What Was Changed:   Updated 
       </summary>
       */
    public interface IPartsInventoryManager
    {
        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            01/31/2024
        ///Summary:            This method calls the data access layer in order to retrive the list of maintenance inventory objects.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/01/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<PartsInventory> GetPartsInventory();

        DateTime GetUpdatedDate();

        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/22/2024
        ///Summary:            This method calls the data access layer in order to add a part to the PartsInventory.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        bool AddPartsInventory(PartsInventory partsInventory);

        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/22/2024
        ///Summary:            This method calls the data access layer in order to remove a part from PartsInventory.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        bool RemovePartsInventory(PartsInventory partsInventory);

        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/22/2024
        ///Summary:            This method calls the data access layer in order to get stock types of a part from PartsInventory.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<String> GetStockTypeForDropDown();

        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/22/2024
        ///Summary:            This method calls the data access layer in order to get categories of a part from PartsInventory.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<String> GetCategoriesForDropDown();
    }
}
