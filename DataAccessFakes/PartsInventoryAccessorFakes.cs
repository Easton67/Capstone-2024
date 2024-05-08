using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessFakes
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
	///Created:            01/31/2024
    ///Summary:            Test data for the Inventory Accessor
    ///Last Updated By:    Darryl Shirley
    ///Last Updated:       02/01/2024
	///What Was Changed:   Updated
    /// </summary>
    public class PartsInventoryAccessorFakes : IPartsInventoryAccessor
    {
        List<PartsInventory> _fakeMaintenanceItems = new List<PartsInventory>();

        DateTime _dateUpdated = new DateTime();
		/* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            MaintenanceItemAccessorFake() constructor
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   updated method with new parameters  
            </summary>
        */
        public PartsInventoryAccessorFakes() 
        {

            _fakeMaintenanceItems.Add(new PartsInventory()
            {
                _category = "Tools",
                _itemID = "drill",
                _quantity = 0,
                _stockType = "Out of Stock"

            });
            _fakeMaintenanceItems.Add(new PartsInventory()
            {
                _category = "Tools",
                _itemID = "hammer",
                _quantity = 5,
                _stockType = "In Stock"
            });
            _fakeMaintenanceItems.Add(new PartsInventory()
            {
                _category = "Cleaning Supplies",
                _itemID = "Industrial Soap",
                _quantity = 3,
                _stockType = "In stock"
            });
            _fakeMaintenanceItems.Add(new PartsInventory()
            {
                _category = "Safety Equipment",
                _itemID = "Fire Blanket",
                _quantity = 1,
                _stockType = "Almost out of Stock"
            });
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Method for testing deleting a part from parts inventory.
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int DeletePartsInventory(string partId)
        {
            foreach (var part in _fakeMaintenanceItems)
            {
                if (part._itemID == partId)
                {
                    _fakeMaintenanceItems.Remove(part);
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Method for testing fake insert data to the parts inventory 
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int InsertPartsInventory(PartsInventory partsInventory)
        {
            _fakeMaintenanceItems.Add(partsInventory); return 1;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Method for testing part category fake type data 
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> SelectAllCategory()
        {
            List<string> category = new List<string>();

            foreach (PartsInventory c in _fakeMaintenanceItems)
            {
                category.Add(c._stockType);
            }

            return category;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Method for testing stock fake type data 
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> SelectAllStockType()
        {
            List<string> stockTypes = new List<string>();

            foreach (PartsInventory sType in _fakeMaintenanceItems)
            {
                stockTypes.Add(sType._stockType);
            }
            return stockTypes;
        }

        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            SelectAllMaintenanceItems Method
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   Initial Creation  
            </summary>
        */
        public List<PartsInventory> SelectAllMaintenanceItems()
        {
            return _fakeMaintenanceItems.FindAll(m => m._itemID != "");
		}


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/07/2024
        ///Summary:            This method allows a fake datetime to be accessed for testing purposes.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public DateTime ViewLastUpdatedTime()
        {
            return _dateUpdated;
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/01/2024
        ///Summary:            This method allows the fake data to be accessed by the InventoryLogicTest class.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/01/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<PartsInventory> ViewPartsInventory()
        {
            return _fakeMaintenanceItems;
        }
    }
}
