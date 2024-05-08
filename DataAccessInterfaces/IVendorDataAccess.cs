using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{

    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/13/2024
    ///Summary:            This is the interface containing all data access methods for vendors.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public interface IVendorDataAccess
    {
        bool AddVendor(Vendor vendor);

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Accessor interface method for retrieving a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<Vendor> RetrieveSupplier(string supplierName);

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Accessor interface method for updating a supplier's information.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        void UpdateSupplierInformation(string supplierName, string newSupplierAddress, string newSupplierEmail, string newSupplierContactPhone, string newSupplierContactName);

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Accessor interface method for getting all of the suppliers' names.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<string> getSupplierNames();

        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/25/2024
        ///Summary:            Accessor interface method for selecting all vendors
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/25/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<Vendor> SelectAllVendors();

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            03/04/2024
        ///Summary:            Accessor interface method for deleting a vendor
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       03/04/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        bool DeleteVendor(int vendorId);
    }
}
