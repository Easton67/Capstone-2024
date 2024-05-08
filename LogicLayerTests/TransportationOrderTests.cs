using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static DataObjects.Enums;

namespace LogicLayerTests
{
    [TestClass]
    public class TransportationOrderTests
    {
        private TransportationOrderManager _transporationOrderManager;


        [TestInitialize]
        public void TestInit()
        {
            _transporationOrderManager = new TransportationOrderManager(new TransportationOrderAccessorFakes());
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the ViewAllTransportationOrdersWorksCorrectly test.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the ViewAllTransportationOrdersWorksCorrectly test.
        /// </summary>
        [TestMethod]
        public void ViewAllTransportationOrdersWorksCorrectly()
        {
            int expected = 4;
            int actual = _transporationOrderManager.ViewAllTransportationOrders().Count;
            Assert.AreEqual(expected, actual);
        }
		
        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            04/20/2024
        /// Summary:            Initial creation of the GetAllItemes test.
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/20/2024
        /// What Was Changed:   Initial creation of the GetAllItemes test.
        /// </summary>
        [TestMethod]
        public void testGetAllItems()
        {
            int expected = 3;
            int actual = _transporationOrderManager.GetAllItemes().Count;
            Assert.AreEqual(expected, actual);
        }			

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the ViewTransportationordersByDiverWorksCorrectly test.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the ViewTransportationordersByDiverWorksCorrectlytest.
        /// </summary>
        [TestMethod]
        public void ViewTransportationordersByDiverWorksCorrectly()
        {
            int expected = 1;
            int actual = _transporationOrderManager.ViewTransportationOrdersByDriver("Jane Doe").Count;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            04/17/2024
        /// Summary:            Initial creation of the delete Order test.
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/17/2024
        /// What Was Changed:   Initial creation creation of the delete Order test.
        /// </summary>
        [TestMethod]
        public void TestdeleteOrder()
        {
            Location location = new Location();
            location.LocationID = 1;
            location.LocationName = "Location1";
            location.Address = "123 Test St";
            location.City = "City1";
            location.State = "State1";
            location.ZipCode = 12345;
            TransportationOrderVM transportation = new TransportationOrderVM();
            transportation.DayPosted = DateTime.Today.AddDays(3);
            transportation.DayToPickUp = DateTime.Today.AddDays(4);
            transportation.DayDroppedOff = DateTime.Today.AddDays(4);
            transportation.AssignedDriver = "Jane Doe";
            transportation.Fulfilled = true;
            transportation.LineItemAmount = 100000;
            transportation.Vendor = "Kay Jewelers";
            transportation.TransportItem = "Ring";
            transportation.Location = location.Address + " , " +
                       location.City + " , " +
                       location.State + " , " +
                       location.ZipCode;
            bool result = _transporationOrderManager.deleteOrder(transportation);
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the DeleteOrderWorksCorrectly test.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the DeleteOrderWorksCorrectly.
        /// </summary>
        [TestMethod]
        public void DeleteOrderWorksCorrectly()
        {
            int expected = 1;
            int actual = _transporationOrderManager.DeleteTransportOrder(1);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the CreateOrderWorksCorrectly test.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the CreateOrderWorksCorrectly.
        /// </summary>
        [TestMethod]
        public void CreateOrderWorksCorrectly()
        {
            TransportationOrder order = new TransportationOrder()
            {
                TransportItemID = 10,
                ClientID = "client@gmail.com",
                LocationID = 10,
                DayPosted = DateTime.Now,
                DayDroppedOff = DateTime.Now,
                DayToPickUp = DateTime.Now,
                AssignedDriver = "AssignedDriver@gmail.com",
                Fulfilled = false
            };
            int expected = 1;

            int actual = _transporationOrderManager.CreateTransportOrder(order);
            Assert.AreEqual(expected, actual);
        }
    }
}
