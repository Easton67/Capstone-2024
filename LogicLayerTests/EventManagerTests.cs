using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass]
    public class EventManagerTests
    {
        private IEventManager _eventManager = null;


        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Create TestSetUp method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       1/31/2024
        /// What Was Changed:   Initial Creation  
        /// </summary>
        [TestInitialize]
        public void TestSetUp()
        {
            _eventManager = new LogicLayer.EventManager(new EventAccessorFakes());
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Create TestCreateANewEvent() to create a new event and add it to the event table
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/07/2024
        /// What Was Changed:   updated the method to test update  
        /// </summary>
        [TestMethod]
        public void TestCreateANewVolunteerEvent()
        {
            int eventID = 4;
            int oldVol = 0;
            int newVol = 5;
            bool expectedCount = true;
            bool actualCount = false;

            actualCount = _eventManager.addVolunteerEvent(eventID, oldVol, newVol);



            Assert.AreEqual(expectedCount, actualCount);
        }


         
        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Create TestGetListOfAllEvents() to get a list of all the events from the event table
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       01/23/2024
        /// What Was Changed:   Initial creation  
        /// </summary>
        [TestMethod]
        public void TestGetListOfAllEvents()
        {

            int expectedCount = 4;
            int actualCount = 0;


            actualCount = _eventManager.getAllEvents().Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            ???
        /// Created:            ???
        /// Summary:            initial creation
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Changed test to take bool instead of int for expected and actual
        /// </summary>
        [TestMethod]
        public void TestToCreateANewEvent()
        {
            Event eventParameter = new Event
            {
                EventName = "Party",
                Description = "Test",
                VolunteersNeeded = 5
            };

            bool expected = true;

            bool actual = _eventManager.CreateEvent(eventParameter);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create TestGetAllEvents() Method to test EventVM.
        /// </summary>

        [TestMethod]
        public void TestGetAllEvents()
        {
            List<EventVM> events = new List<EventVM>();
            events = _eventManager.getAllEvents();

            Assert.AreEqual(events.Count, 4);
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create TestGetAllEvents() Method to test EventVM.
        /// </summary>

        [TestMethod]
        public void TestGetParticipantName()
        {
            List<string> names = new List<string>();
            names = _eventManager.GetParticipant(1);

            Assert.AreEqual(3, names.Count);
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create TestGetAllEvents() Method to test.
        /// </summary>

        [TestMethod]
        public void TestGetVolunteerName()
        {
            List<string> names = new List<string>();
            names = _eventManager.GetVolunteer(1);

            Assert.AreEqual(names.Count, 2);
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Tests the functionality of removing a volunteer from an Event.
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestRemovingVolunteerFromEvent()
        {
            List<Event> fakeEvents = new List<Event>();
            List<EventVolunteer> volunteers = new List<EventVolunteer>();

            fakeEvents.Add(new Event()
            {
                EventID = 1,
                EventName = "Fake Event Tname",
                Description = "Fake Description.",
                VolunteersNeeded = 5
            });

            volunteers.Add(new EventVolunteer()
            {
                EventID = 1,
                VolunteerID = "test@email1.com",
            });
            volunteers.Add(new EventVolunteer()
            {
                EventID = 1,
                VolunteerID = "christine@hotmail.com",
            });

            IEventManager eventManager = new EventManager(new EventAccessorFakes());

            int eventID = 1;
            string volunteerID = "christine@hotmail.com";

            int initialCount = volunteers.Count;

            eventManager.RemoveVolunteerFromEvent(volunteerID, eventID);
            int rowsAffected = 1;
            int updatedCount = initialCount - rowsAffected;

            Assert.AreEqual(initialCount - 1, updatedCount);
        }


        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Tests the functionality of removing a volunteer from an Event.
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestingValuesFromVolunteers()
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            IEventManager eventManager = new EventManager(new EventAccessorFakes());

            volunteers.Add(new Volunteer()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                UserID = "TestUserID"
            });

            Assert.AreEqual("FirstName", volunteers[0].FirstName);
            Assert.AreEqual("LastName", volunteers[0].LastName);
            Assert.AreEqual("TestUserID", volunteers[0].UserID);
		}

        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create TestInsertEventRequest() Method to test the fake data.
        /// </summary>
        [TestMethod]
        public void TestInsertEventRequest()
        {
            EventRequestVM request = new EventRequestVM();
            request.RequestID = 6;
            request.ClientID = "test6@company.com";
            request.EventTypeID = "type6";
            request.Information = "text";
            _eventManager.InsertEventRequest(request);

            Assert.AreEqual(_eventManager.GetEventRequests().Count, 6);
        }

        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            03/11/2024
        /// Summary:            Create event participant Test.
        /// </summary>
        [TestMethod]
        public void eventParticipantsTest()
        {
            EventParticipant eventParticipants = new EventParticipant();
            eventParticipants.ParticipantID = 6;
            eventParticipants.EventID = 1;
            eventParticipants.ParticipantName = "Test";
            eventParticipants.Email = "Test";
            eventParticipants.RegistrationDate = DateTime.Now;
            bool result = _eventManager.AddEventParticipants(eventParticipants);
            Assert.IsTrue(result);
		}

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 01/23/2024
        /// Summary: Create TestUpdateEvent() Method to test the fake data.
        /// </summary>
        [TestMethod]
        public void UpdateEventTest()
        {
            Event @event = new Event();
            @event.EventID = 1;
            @event.EventName = "test1000";
            @event.Description = "descriptionTest";

            bool result = _eventManager.UpdateEvent(@event);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 04/18/2024
        /// Summary: initial creation of TestSelectEventByEventIDWorksCorrectly
        /// </summary>
        [TestMethod]
        public void TestSelectEventByEventIDWorksCorrectly()
        {
            Event thisEvent = new Event()
            {
                EventID = 1,
                EventName = "Fight Club in The Parking Lot",
                Description = "Everyone stops whatever they are doing and starts fighting in the parking lot.",
                VolunteersNeeded = 10
            };

            int expectedEvent = thisEvent.EventID;
            int actualEvent = _eventManager.SelectEventByEventID(1).EventID;

            Assert.AreEqual(expectedEvent, actualEvent);
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/28/2024
        /// Summary: Delete event
        /// </summary>
        /// 

        [TestMethod]
        public void DeleteEventTest()
        {
            EventVM @event = new EventVM
            {
                EventID = 1,
                EventName = "Fight Club in The Parking Lot",
                Description = "Everyone stops wahtever they are doing and starts fighting in the parking lot.",
                VolunteersNeeded = 10
            };
            bool result = _eventManager.DeleteEvent(@event);
            Assert.IsTrue(result);
        }
        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/28/2024
        /// Summary: Delete event
        /// </summary>
        /// 

        [TestMethod]
        public void CancelSignUpTest()
        {

            string ParticipantName = "Marwa";
            EventVM @event = new EventVM
            {
                EventID = 1,
            };



            bool result = _eventManager.CancelSignUp( ParticipantName, @event.EventID);
            Assert.IsTrue(result);
        }

        ///</summary>
        ///Creator:            Matthew Baccam
        ///Created:            04/26/2024
        ///Summary:            Created SelectEventVMByID
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/26/2024
        ///What Was Changed:   Initial creation
        ///</summary>
        
        [TestMethod]
        public void SelectEventVMByIDTest()
        {
            int expectedID = 1;
            Assert.AreEqual(_eventManager.SelectEventVMByID(expectedID).EventID, expectedID);
        }
    }
}
