using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{

    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/14/2024
    ///Summary:            This is the accessor fake class for vendors. All vendor fake data should be instantiated here.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/14/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VendorAccessorFakes : IVendorDataAccess
    {
        List<bool> _addVendorList = new List<bool>();
        List<Vendor> _vendors = new List<Vendor>();        


        public VendorAccessorFakes()
        {
            _addVendorList.Add(true);
            _addVendorList.Add(false);

            _vendors.Add(new Vendor()
            {
                VendorId = 1,
                Name = "FictionalName",
                ContactName = "ContactNameFaker",
                Address = "FakeStreat",
                PhoneNumber = "1234567890",
                Email = "Fake@fictional.com"
            });

            _vendors.Add(new Vendor()
            {
                VendorId = 2,
                Name = "NonExistantName",
                ContactName = "FictionalContactName",
                Address = "FictionalStreat",
                PhoneNumber = "1122334455",
                Email = "NotReal@fictional.com"
            });

            _vendors.Add(new Vendor()
            {
                VendorId = 3,
                Name = "FakeName",
                ContactName = "FakeContactName",
                Address = "FakeAddress",
                PhoneNumber = "0987654321",
                Email = "Fictional@fake.com"
            });
        }



        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/14/2024
        ///Summary:            This fake method returns true when there is data present and false when there is not. Since we do all validation checks in the presentation layer, there is no need to do them logically.
        ///                     We also do not check for vendorID, for even if it is part of the model, it is assigned as an identity field in the database, and therefore does not exist when being added.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/14/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool AddVendor(Vendor vendor)
        {
            if (!vendor.Address.Equals(string.Empty) && !vendor.Email.Equals(string.Empty) &&
                !vendor.PhoneNumber.Equals(string.Empty) && !vendor.ContactName.Equals(string.Empty)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Accessor fake method for getting all of the suppliers' names.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<string> getSupplierNames()
        {
            return new List<string> { "FakeSupplier", "IsNotReal", "FromAStory", "DoesNotExist"};
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Accessor fake method for retrieving a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<Vendor> RetrieveSupplier(string supplierName)
        {
            return _vendors;
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Accessor fake method for updating a supplier's information.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void UpdateSupplierInformation(string supplierName, string newSupplierAddress, string newSupplierEmail, string newSupplierContactPhone, string newSupplierContactName)
        {
            foreach (var vendor in _vendors)
            {
                if (vendor.Name == supplierName)
                {
                    vendor.Address = newSupplierAddress;
                    vendor.Email = newSupplierEmail;
                    vendor.PhoneNumber = newSupplierContactPhone;
                    vendor.ContactName = newSupplierContactName;
                }
            }
		}
        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/09/2024
        ///Summary:            Method for select all vendors fake data
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/09/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<Vendor> SelectAllVendors()
        {
            return _vendors;
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/04/2024
        /// Summary: Data fake for vendor deletion.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool DeleteVendor(int vendorId)
        {
            int count = _vendors.Count; 

            foreach(var vendor in _vendors)
            {
                if (vendor.VendorId == vendorId) 
                {
                    _vendors.Remove(vendor);
                    break;
                }
            }

            if (_vendors.Count != count)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
