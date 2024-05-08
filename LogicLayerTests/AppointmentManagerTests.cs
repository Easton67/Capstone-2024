using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LogicLayerTests
{
    [TestClass]
    public class AppointmentManagerTests
    {
        private AppointmentManager _appointmentManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _appointmentManager = new AppointmentManager(new AppointmentAccessorFake());
        }

        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the Test for the Appointment Logic Layer.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetsAllAppointments()
        {
            const int expectedCount = 4;
            int actualCount = 0;

            actualCount = (_appointmentManager.GetAllAppointments()).Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/26/2024
        ///Summary:            Test method for successfully creating an appointment.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyCreateAppointment()
        {
            AppointmentVM appointmentVM = new AppointmentVM()
            {
                _clientID = "fox@gmail.com",
                _locationName = "Homeless Home",
                _appointmentStartTime = DateTime.Now,
                _appointmentEndTime = DateTime.Now.AddHours(1),
                _appointmentType = "Checkup",
                _status = false,
                _employeeID = "jake@company.com"
            };
            _appointmentManager.CreateAppointment(appointmentVM);
            int newCount = _appointmentManager.GetAllAppointments().Count();
            Assert.AreEqual(newCount, 5);
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/26/2024
        ///Summary:            Test method for failing to create an appointment.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToCreateAppointment()
        {
            AppointmentVM appointmentVM = new AppointmentVM()
            {
                _clientID = "fox@gmail.com",
                _locationName = "Homeless Home",
                _appointmentStartTime = DateTime.Now,
                _appointmentEndTime = DateTime.Now.AddHours(1),
                _appointmentType = "Checkup",
                _status = false,
                _employeeID = "jake@company.com"
            };
            _appointmentManager.CreateAppointment(appointmentVM);
            int newCount = _appointmentManager.GetAllAppointments().Count();
            Assert.AreNotEqual(newCount, 0);
        }

        /// <summary>
        ///Creator:     Miyada AbaS
        ///Created:            03/27/2024
        ///Summary:            This is the Test for the remove Appointment .
        ///Last Updated By:    Miyada Abas
        ///Last Updated:       03/27/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        [TestMethod]
        public void TestRemoveAppointment()
        {

            bool actualCount;
            Appointment appointment = new Appointment();
            appointment._clientID = "b@email.com";
            appointment._locationName = "Location2";
            appointment._appointmentStartTime = DateTime.Now;
            appointment._appointmentEndTime = DateTime.Now.AddHours(3);


            actualCount = _appointmentManager.RemoveAppointment(appointment);

            Assert.IsTrue(actualCount);
        }
    }
}
