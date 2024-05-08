using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/01/2024
    /// Summary: Created the RoomVM Manager unit tests.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    [TestClass]
    public class RoomManagerTests
    {
        private RoomManager _roomManager = null;

        [TestInitialize]

        public void TestSetup()
        {
            _roomManager = new RoomManager(new RoomAccessorFakes());
        }
		
		/// <summary>
        /// Creator: Jared Harvey
        /// Created: 01/29/2024
        /// Summary: This method tests the GetRoomsByShelterID manager method.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 01/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetRoomVMs() {
            // arrange
            int expected = 4;
            int actual = 0;

            // act
            actual = _roomManager.GetRoomsByShelterID("Test Homeless Shelter").Count;

            // assert
            Assert.AreEqual(expected, actual);
		}

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/01/2024
        /// Summary: This method tests the GetAvailableRooms manager method.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetAvailableRooms() {
            // arrange
            int expected = 0;
            int actual = 0;

            // act
            actual = _roomManager.GetAvailableRooms("Test Homeless Shelter").Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Testing the AddRoom() method using the RoomAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestAddRoomWorksCorrectly()
        {
            // arrange
            RoomVM room = new RoomVM()
            {
                RoomID = 1,
                ShelterID = "Shelter 1",
                RoomNumber = 1,
                Status = "Available"
            };

            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _roomManager.AddRoom(room);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Testing the GetShelterIDForDropDown() method 
        ///          using the RoomAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetShelterIDForDropDownWorksCorrectly() 
        {
            // arrange
            int expectedCount = 10;
            int actualCount = 0;

            // act
            actualCount = (_roomManager.GetShelterIDForDropDown()).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Testing the GetRoomStatusForDropDown() method 
        ///          using the RoomAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetRoomStatusForDropDownWorksCorrectly()
        {
            // arrange
            int expectedCount = 10;
            int actualCount = 0;

            // act
            actualCount = (_roomManager.GetRoomStatusForDropDown()).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Created an Arrange, Act and Assert for UnitTesting.
        ///Last Updated By: Suliman Suliman
        ///Last Updated: 01/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetRoomList()
        {

            // Arrange
            List<RoomVM> SelectRooms;
            //IRoomManger roomManager = new RoomManager(_fakeRoomManagerAccessor);
            // Act
            SelectRooms = _roomManager.GetRoomList();
            // Assert
            Assert.AreEqual(10, SelectRooms.Count);

        }
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Created an Arrange, Act and Assert for UnitTesting.
        ///Last Updated By: Suliman Suliman
        ///Last Updated: 01/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestEditRoom()
        {
            bool result = false;
            RoomVM newRoom = new RoomVM();
            newRoom.RoomID = 1;
            newRoom.ShelterID = "Test";
            newRoom.RoomNumber = 2;
            newRoom.Status = "avalible";

            //IRoomManger roomManager = new RoomManager(_fakeRoomManagerAccessor);
            result = _roomManager.EditRoom(newRoom);
            Assert.AreEqual(result, true);

        }
		
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Test Deactivate Room method.
        ///Last Updated By:NA
        ///Last Updated: NA
        ///What Was Changed:NA
        [TestMethod]
        public void TestDeactivateRoom()
        {
            bool result = false;
            RoomVM newRoom = new RoomVM();
            newRoom.RoomID = 1;
            newRoom.ShelterID = "Test";
            newRoom.RoomNumber = 2;
            newRoom.Status = "avalible";

            result = _roomManager.DeactivateRoom(newRoom);
            Assert.AreEqual(result, true);
        }
        /// <summary>
        ///Creator:Miyada Abas
        ///Created: 03/22/2024
        ///Summary: Test Update Room status.
        ///Last Updated By
        ///Last Updated: 
        ///What Was Changed:
        [TestMethod]
        public void TestUpdateStatus()
        {
            // arrange
            bool expected = true;
            bool actual = true;
            RoomVM room = new RoomVM();

            room.ShelterID = "Test Homeless Shelter #2";
            room.RoomNumber = 203;
            room.Status = "Under Maintenance";

            // act

            actual = _roomManager.UpdateRoomstatus(room);

            // assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///Creator:Miyada Abas
        ///Created: 03/22/2024
        ///Summary: Test get all Room status.
        ///Last Updated By
        ///Last Updated: 
        ///What Was Changed:
        [TestMethod]
        public void Testget_all_room_status()
        {
            // arrange
            int expected = 5;
            int actual;
           
            // act

            actual = _roomManager.get_all_room_status().Count();    

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
