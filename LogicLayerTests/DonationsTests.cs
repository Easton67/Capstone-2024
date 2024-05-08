using DataAccessFakes;
using DataAccessInterfaces;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerTests
{
    /// <summary>
    ///Creator:            Abdalgader Ibrahim
    ///Created:            02/06/2024
    ///Summary:            This is the class for Donations logic testing.
    ///Last Updated By:    
    ///Last Updated:       
    ///What Was Changed:   
    /// </summary>
    [TestClass]
    public class DonationsTests
    {
        private IDonationManager _donationManager;

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/23/2024
        /// Summary:            Create TestSetUp method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/23/2024
        /// What Was Changed:   Initial creation  
        /// </summary>

        [TestInitialize]
        public void TestSetUp()
        {
            _donationManager = new DonationManager(new DonationAccessorFakes());
        }

        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This test method returns true if the donations is not null, and contains 5 objects.
        ///Last Updated By:    
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        [TestMethod]
        public void DonationsReturnsValid()
        {
            IDonationsAccessor accessor = new DonationAccessorFakes();
            IDonationManager manager = new DonationManager(accessor);
            List<Donation> donations = manager.GetDonations();
            Assert.AreEqual(donations.Count,5);
        }
        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This test method returns true if the donationsType is not null, and contains 5 objects.
        ///Last Updated By:    
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        [TestMethod]
        public void DonationsTypeReturnsValid()
        {
            IDonationsAccessor accessor = new DonationAccessorFakes();
            IDonationManager manager = new DonationManager(accessor);
            List<DonationType> donations = manager.GetDonationsType();
            Assert.AreEqual(donations.Count, 5);
        }
        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This test method returns true if the donator is not null, and contains 5 objects.
        ///Last Updated By:    
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        [TestMethod]
        public void DonatorReturnsValid()
        {
            IDonationsAccessor accessor = new DonationAccessorFakes();
            IDonationManager manager = new DonationManager(accessor);
            List<Donator> donations = manager.GetDonators();
            Assert.AreEqual(donations.Count, 5);
        }

        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This test method returns true if the Donation Updated is not null.
        ///Last Updated By:    
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        [TestMethod]
        public void UpdateDonationReturnUpdeted() 
        {
            IDonationsAccessor accessor = new DonationAccessorFakes();
            IDonationManager manager = new DonationManager(accessor);
            Donation donation = new Donation
            {
                DonationID = 100003,
                DonationTypeID = 100004,
                DonatorID = 100005,
                DonationName = "Dana",
                Amount = "115",
                DonationDate = DateTime.Now,
                Active = true,
            };
            donation.DonationName = "Sam";
            Donation updatedDonation = manager.UpdateDonation(donation);
            Assert.AreEqual("Sam", updatedDonation.DonationName);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/23/2024
        /// Summary:            creation of TestCreateDonationWorksCorrectly test method 
        /// </summary>
        [TestMethod]
        public void TestCreateDonationWorksCorrectly()
        {
            Donation donation = new Donation
            {
                DonationID = 100003,
                DonationTypeID = 100004,
                DonatorID = 100005,
                DonationName = "Dana",
                Amount = "115",
                DonationDate = DateTime.Now,
                Active = true,
            };

            bool expectedResult = true;

            bool actualResult = _donationManager.CreateDonation(donation);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
