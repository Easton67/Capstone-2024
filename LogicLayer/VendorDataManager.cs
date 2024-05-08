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

    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/13/2024
    ///Summary:            This contains all methods for vendor data accessing.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VendorDataManager : IVendorDataManager
    {
        IVendorDataAccess _vendorDataAccess = null;

        public VendorDataManager() 
        {
            _vendorDataAccess = new VendorDataAccess();
        }
        public VendorDataManager(IVendorDataAccess vendorDataAccess) 
        {
            _vendorDataAccess = vendorDataAccess;
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            This sends the vendor model to the data layer to be added to the DB.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public bool AddVendor(Vendor vendor)
        {
            try
            {
                return _vendorDataAccess.AddVendor(vendor);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to add vendor", ex);
            }
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Gets all of the suppliers' names.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<string> getSupplierNames()
        {
            List<string> supplierNames = new List<string>();
            try
            {
                supplierNames = _vendorDataAccess.getSupplierNames();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error getting all of the suppliers' names", ex);
            }
            return supplierNames;
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Retrieves a specific supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<Vendor> RetrieveSupplier(string supplierName)
        {
            List<Vendor> suppliers = new List<Vendor>();
            try
            {
                suppliers = _vendorDataAccess.RetrieveSupplier(supplierName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error retrieving the supplier", ex);
            }
            return suppliers;
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Updates the information of a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void UpdateSupplierInformation(string supplierName, string newSupplierAddress, string newSupplierEmail, string newSupplierContactPhone, string newSupplierContactName)
        {
            try
            {
                _vendorDataAccess.UpdateSupplierInformation(supplierName, newSupplierAddress, newSupplierEmail, newSupplierContactPhone, newSupplierContactName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error updating the supplier", ex);
            }
		}
        /// Creator: Anthony Talamantes
        /// Created: 02/07/2024
        /// Summary: Method to get all vendors with checks to ensure not null or 0.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Vendor> GetAllVendors()
        {
            List<Vendor> allVendors = null;

            try
            {
                allVendors = _vendorDataAccess.SelectAllVendors();

                if (allVendors == null || allVendors.Count == 0)
                {
                    throw new ArgumentException("Vendors not found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving vendors", ex);
            }
            return allVendors;
        }


        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/04/2024
        /// Summary: Deletes a vendor and all associated references to the vendor in the database given the vendor's ID.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public bool DeleteVendor(int vendorId)
        {
            try
            {
                return _vendorDataAccess.DeleteVendor(vendorId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to delete vendor", ex);
            }
        }
    }
}
