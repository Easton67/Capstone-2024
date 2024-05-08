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
    [TestClass]
    public class VisitManagerTests
    {
        IVisitManager _visitManager;

        public VisitManagerTests()
        {
            _visitManager = new VisitManager(new VisitAccessorFake());
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created TestCreateVisitWorksCorrectly
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 02/28/2024
        /// What was changed: I made DateTime for check in and check out rather than a string
        /// </summary>
        /// </summary>
        [TestMethod]
        public void TestCreateVisitWorksCorrectly()
        {

            // arange
            Visit visit = new Visit()
            {
                VisitID = 6,
                FirstName = "Foo",
                LastName = "Bar",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            };

            int expectedResult = 1;
            int actualResult = 0;

            // act
            actualResult = _visitManager.CreateVisit(visit);

            // assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created TestGetAllVisitsByNameWorksCorrecty
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 02/28/2024
        /// What was changed: I made DateTime for check in and check out rather than a string
        /// </summary>
        [TestMethod]
        public void TestGetAllVisitsByNameWorksCorrectly()
        {
            //arange
            string firstName = "Frank";
            string lastName = "Johnson";
            int expectedResult = 2;
            int actualResult = 0;

            //act
            actualResult = _visitManager.GetAllVisitsByName(firstName, lastName).Count();

            //assert         
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created TestDeleteAVisitByVisitIDWorksCorrectly
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 02/28/2024
        /// What was changed: I made DateTime for check in and check out rather than a string
        /// </summary>
        [TestMethod]
        public void TestDeleteAVisitByVisitWorksCorrectly()
        {
            // arrange
            var visit = new Visit
            {
                VisitID = 1,
                FirstName = "Frank",
                LastName = "Johnson",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            };
            int expectedResult = 1;
            int actualResult = 0;

            // act
            actualResult = _visitManager.DeleteVisit(visit);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/20/2024
        /// Summary: Returns int, Reschules visit by visit ID
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 02/28/2024
        /// What was changed: I made DateTime for check in and check out rather than a string
        /// </summary>
        [TestMethod]
        public void TestRescheduleVisitReturnsCorrecrtValue()
        {
            //arrange
            int id = 3;
            DateTime checkIn = DateTime.Now;
            DateTime checkOut = DateTime.Now;
            int expectedResult = 1;
            int actualResult = 0;
            //act
            actualResult = _visitManager.RescheduleVisit(id, checkIn, checkOut);

            //assert

            Assert.AreEqual(expectedResult, actualResult);
        }


        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        [TestMethod]
        public void AppointmentCountTest()
        {
            var actualCount = 0;
            var expectedCount = 1;
            actualCount = _visitManager.SearchAppointmentCount(new DateTime(2023 - 04 - 15));
            Assert.AreEqual(expectedCount, actualCount);
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        [TestMethod]
        public void SelectVisitsTest()
        {
            var test = _visitManager.SelectVisitWithFromTo(new DateTime(2023 - 03 - 15), new DateTime(2023 - 04 - 16));

            Assert.AreEqual(test.Count, 1);
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        [TestMethod]
        public void TestCheckIn()
        {
            var visit = new Visit
            {
                VisitID = 5,
                FirstName = "Frank",
                LastName = "Johnson",
                CheckIn = new DateTime(2023 - 04 - 15),
                CheckOut = new DateTime(2023 - 04 - 15),
                VisitReason = "VisitClient"
            };
            var test = _visitManager.CheckInGuest(visit.VisitID, visit.CheckIn);

            Assert.IsTrue(test);
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        [TestMethod]
        public void TestCheckOut()
        {
            var visit = new Visit
            {
                VisitID = 5,
                FirstName = "Frank",
                LastName = "Johnson",
                CheckIn = new DateTime(2023 - 04 - 15),
                CheckOut = new DateTime(2023 - 04 - 15),
                VisitReason = "VisitClient"
            };
            var test = _visitManager.CheckOutGuest(visit.VisitID, visit.CheckOut);

            Assert.IsTrue(test);
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/22/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/22/2024
        //What Was Changed: Initial Creation
        //<Summary>
        [TestMethod]
        public void TestSelectAppointmentByID()
        {
            var actual = new Visit
            {
                VisitID = 1,
                FirstName = "Frank",
                LastName = "Johnson",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            };
            var test = _visitManager.GetVisitByVisitID(actual.VisitID);
            Assert.AreEqual(test.FirstName, actual.FirstName);
        }


        //<Summary>
        //Creator: Ibrahim Albashair
        //Created: 02/22/2024
        //Summary: Initial Creation
        //Last Updated By: Ibrahim Albashair
        //Last Updated: 02/22/2024
        //What Was Changed: Initial Creation
        //<Summary>
        [TestMethod]
        public void TestGetAllVisitsWorksCorrectly()
        {
            //arange            
            int expectedResult = 5;
            int actualResult = 0;

            //act
            actualResult = _visitManager.GetAllVisits().Count();

            //assert         
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
