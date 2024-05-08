using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class PartsInventoryManager : IPartsInventoryManager
    {
        private IPartsInventoryAccessor _maintenanceItemAccessor;


        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            MaintenanceItemManager() Constructor 
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   Initial Creation 
            </summary>
        */
        public PartsInventoryManager()
        {
            _maintenanceItemAccessor = new PartsInventoryAccessor();
        }


        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            MaintenanceItemManager() Constructor with parameters
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   Initial Creation  
            </summary>
        */
        public PartsInventoryManager(IPartsInventoryAccessor maintenanceItemAccessor)
        {
            _maintenanceItemAccessor = maintenanceItemAccessor;
        }


        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            GetAllMaintenanceItems() method
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   Initial Creation 
            </summary>
        */
        public List<PartsInventory> GetPartsInventory()
        {
            List<PartsInventory> maintenanceItems = null;

            try
            {
                maintenanceItems = _maintenanceItemAccessor.SelectAllMaintenanceItems();
                if (maintenanceItems == null || maintenanceItems.Count == 0)
                {
                    throw new ArgumentException("Maintenance Items not Found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not Found", ex);
            }


            return maintenanceItems;
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/07/2024
        ///Summary:            This method gets the updated date from the data accessing class.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/07/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public DateTime GetUpdatedDate()
        {
            try
            {
                return _maintenanceItemAccessor.ViewLastUpdatedTime();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get updated date", ex);
            }
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/14/2024
        /// Summary:            Method to add a part into PartsInventory.
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool AddPartsInventory(PartsInventory partsInventory)
        {
            bool result = false;
            try
            {
                result = (1 == _maintenanceItemAccessor.InsertPartsInventory(partsInventory));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Part not added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/14/2024
        /// Summary:            Method to get categories of a part from PartsInventory to use to populate a dropdown.
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<String> GetCategoriesForDropDown()
        {
            List<string> _categories = null;

            try
            {
                _categories = _maintenanceItemAccessor.SelectAllCategory();

                if (_categories == null || _categories.Count == 0)
                {
                    throw new ArgumentException("Categories not found.");
                }
                _categories = _categories.Distinct(StringComparer.Ordinal).OrderBy(category => category).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found.", ex);
            }
            return _categories;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/14/2024
        /// Summary:            Method to get stock types of a part from PartsInventory to use to populate a dropdown.
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<String> GetStockTypeForDropDown()
        {
            List<string> _stockType = null;

            try
            {
                _stockType = _maintenanceItemAccessor.SelectAllStockType();

                if (_stockType == null || _stockType.Count == 0)
                {
                    throw new ArgumentException("Stock Types not found");
                }
                //https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparer.ordinal?view=net-8.0
                _stockType = _stockType.Distinct(StringComparer.Ordinal).OrderBy(sType => sType).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found", ex);
            }
            return _stockType;
        }

        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/22/2024
        ///Summary:            Method to remove a part from PartsInventory.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool RemovePartsInventory(PartsInventory partsInventory)
        {
            bool result = false;
            try
            {
                result = (1 == _maintenanceItemAccessor.DeletePartsInventory(partsInventory._itemID));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Part Not Deleted", ex);
            }
            return result;
        }
    }
}
