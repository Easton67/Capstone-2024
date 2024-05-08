using DataAccessInterfaces;
using DataAccessFakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataObjects;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace LogicLayerTests
{

    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/13/2024
    ///Summary:            Test class for the vendor manager.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class VendorManagerTests
    {
        VendorDataManager _vendorManager = new VendorDataManager();
        [TestInitialize]
        public void TestSetUp()
        {
            _vendorManager = new VendorDataManager(new VendorAccessorFakes());
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Tests valid input being sent to the manager.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VendorManagerValidInputToData()
        {

            Vendor vendor = new Vendor
            {
                Name = "Test",
                Address = "Test",
                Email = "Test",
                ContactName = "Test",
                PhoneNumber = "Test",
            };

            
            bool result = _vendorManager.AddVendor(vendor);

            Assert.IsTrue(result);
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Tests invalid input being sent to the manager.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VendorManagerInvalidInputToData()
        {

            Vendor vendor = new Vendor
            {
                Name = string.Empty,
                Address = string.Empty,
                Email = string.Empty,
                ContactName = string.Empty,
                PhoneNumber = string.Empty,
            };

            bool result = _vendorManager.AddVendor(vendor);

            Assert.IsFalse(result);
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Test method for successfully retrieving a list of supplier names.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyRetrieveSupplierNames()
        {
            // Arrange
            List<string> expectedSupplierNames = new List<string> { "FakeSupplier", "IsNotReal", "FromAStory", "DoesNotExist" };


            List<string> actualSupplierNames = _vendorManager.getSupplierNames();

            // Assert
            Assert.IsTrue(expectedSupplierNames.All(actualSupplierNames.Contains));
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Test method for failing to retrieve a list of supplier names.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToRetrieveSupplierNames()
        {
            // Arrange
            List<string> expectedSupplierNames = new List<string> { "RealSupplier", "IsReal", "NotFromAStory", "DoesExist" };


            List<string> actualSupplierNames = _vendorManager.getSupplierNames();

            // Assert
            Assert.IsFalse(expectedSupplierNames.All(actualSupplierNames.Contains));
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Test method for successfully retrieving a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyRetrievedSupplier()
        {
            // Arrange
            Vendor expectedSupplier = new Vendor
            {
                VendorId = 1,
                Name = "FictionalName",
                ContactName = "ContactNameFaker",
                Address = "FakeStreat",
                PhoneNumber = "1234567890",
                Email = "Fake@fictional.com"
            };


            List<Vendor> actualSuppliers = _vendorManager.RetrieveSupplier("FictionalName");
            Vendor actualSupplier = actualSuppliers.FirstOrDefault();
            // Assert
            Assert.IsTrue(actualSupplier.Name.Equals(expectedSupplier.Name));
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Test method for failing to retrieve a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToRetrieveSupplier()
        {
            // Arrange
            Vendor expectedSupplier = new Vendor
            {
                VendorId = 1,
                Name = "FictionalName",
                ContactName = "ContactNameFaker",
                Address = "FakeStreat",
                PhoneNumber = "1234567890",
                Email = "Fake@fictional.com"
            };

            // Act
            IVendorDataAccess fakeAccessor = new VendorAccessorFakes();
            VendorDataManager vendorManager = new VendorDataManager(fakeAccessor);
            List<Vendor> actualSuppliers = _vendorManager.RetrieveSupplier("RealName");

            // Assert
            Assert.IsFalse(actualSuppliers.Contains(expectedSupplier));
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Test method for successfully updating a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyUpdateSupplier()
        {
            // Arrange
            Vendor expectedSupplier = new Vendor
            {
                VendorId = 1,
                Name = "FictionalName",
                ContactName = "UpdatedContactName",
                Address = "FakeStreat",
                PhoneNumber = "1234567890",
                Email = "Fake@fictional.com"
            };

            _vendorManager.UpdateSupplierInformation(expectedSupplier.Name, expectedSupplier.Address, expectedSupplier.Email, expectedSupplier.PhoneNumber, expectedSupplier.ContactName);
            List<Vendor> actualSuppliers = _vendorManager.RetrieveSupplier("FictionalName");
            Vendor actualSupplier = actualSuppliers.FirstOrDefault();

            // Assert
            Assert.IsTrue(actualSupplier.ContactName.Equals("UpdatedContactName"));
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Test method for failing to updating a supplier.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToUpdateSupplier()
        {
            // Arrange
            Vendor expectedSupplier = new Vendor
            {
                VendorId = 1,
                Name = "FictionalName",
                ContactName = "UpdatedContactName",
                Address = "FakeStreat",
                PhoneNumber = "1234567890",
                Email = "Fake@fictional.com"
            };

            _vendorManager.UpdateSupplierInformation(expectedSupplier.Name, expectedSupplier.Address, expectedSupplier.Email, expectedSupplier.PhoneNumber, expectedSupplier.ContactName);
            List<Vendor> actualSuppliers = _vendorManager.RetrieveSupplier("FictionalName");
            Vendor actualSupplier = actualSuppliers.FirstOrDefault();

            // Assert
            Assert.IsFalse(actualSupplier.ContactName.Equals("FakeContactName"));
		}
        ///Creator:            Anthony Talamantes
        ///Created:            02/07/2024
        ///Summary:            Unit test for the VendorDataManager class to ensure the GetAllVendors method returns a valid list of vendors.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VendorReturnsValidResult()
        {

            // Act
            List<Vendor> vendors = _vendorManager.GetAllVendors();

            // Assert
            Assert.IsNotNull(vendors);
            Assert.AreEqual(3, vendors.Count);

            Assert.AreEqual("FictionalName", vendors[0].Name);
            Assert.AreEqual("NonExistantName", vendors[1].Name);
            Assert.AreEqual("FakeName", vendors[2].Name);
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/04/2024
        /// Summary: Test that returns true given a proper vendor ID, to mock successful vendor object deletion.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void DeleteVendorReturnsTrue()
        {

            bool result = _vendorManager.DeleteVendor(2);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/04/2024
        /// Summary: Test that returns false given vendor ID, to mock unsuccessful vendor object deletion
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void DeleteVendorReturnsFalse()
        {

            bool result = _vendorManager.DeleteVendor(0);

            Assert.IsFalse(result);
        }
    }
}
