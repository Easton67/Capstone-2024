using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{

    /// <Summary>
    /// Creator: Darryl Shirley
    /// created: 01/22/2024
    /// Summary: EventAccessorFakes
    /// Last updated By: Darryl Shirley
    /// Last Updated: 1-26-2024
    /// What was changed/updated: Initial Creation
    /// </Summary>

    public class EventAccessorFakes : IEventAccessor
    {
        private List<Event> _fakeEvents = new List<Event>();
        private List<EventVM> _fakeEventsVM = new List<EventVM>();

        private List<int> _volNeeded = new List<int>();
        private List<EventParticipant> _eventParticipants = new List<EventParticipant>();
        private List<EventVolunteer> _volunteers = new List<EventVolunteer>();
        private List<string> clientIDs = new List<string>();
        private List<string> eventTypeIDs = new List<string>();
        private List<EventRequestVM> eventRequestVMs = new List<EventRequestVM>();
        private IEnumerable<Event> events;

        /// <Summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: EventAccessorFakes() Contructor
        /// Last updated By: Darryl Shirley
        /// Last Updated: 1-26-2024
        /// What was changed/updated: Initial Creation
        /// </Summary>

        public EventAccessorFakes()
        {
            _fakeEventsVM.Add(new EventVM()
            {
                EventID = 1,
                EventDay = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Address = "street street at street street"

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 1,
                ParticipantName = "Test",

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 2,
                ParticipantName = "Test",

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 1,
                ParticipantName = "Test",

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 1,
                ParticipantName = "Test",

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 2,
                ParticipantName = "Test",

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 3,
                ParticipantName = "Test",

            });
            _eventParticipants.Add(new EventParticipant()
            {
                EventID = 4,
                ParticipantName = "Test",

            });

            _volunteers.Add(new EventVolunteer()
            {
                EventID = 1,
                VolunteerID = "christine@hotmail.com",

            });
            _volunteers.Add(new EventVolunteer()
            {
                EventID = 1,
                VolunteerID = "jimmy@yahoo.com",

            });
            _volunteers.Add(new EventVolunteer()
            {
                EventID = 2,
                VolunteerID = "jimmy@yahoo.com",

            });
            _volunteers.Add(new EventVolunteer()
            {
                EventID = 3,
                VolunteerID = "christine@hotmail.com",

            });
            _volunteers.Add(new EventVolunteer()
            {
                EventID = 4,
                VolunteerID = "tommy@gmail.com",

            });

            _fakeEvents.Add(new Event()
            {
                EventID = 1,
                EventName = "Fight Club in The Parking Lot",
                Description = "Everyone stops whatever they are doing and starts fighting in the parking lot.",
                VolunteersNeeded = 10
            });
            _fakeEvents.Add(new Event()
            {
                EventID = 2,
                EventName = "Game Night",
                Description = "Johnny hooks up his Nintendo 64 to the tv, and all the clients play a super smash bros tournament.",
                VolunteersNeeded = 5
            });
            _fakeEvents.Add(new Event()
            {
                EventID = 3,
                EventName = "Jim's Coding Academy",
                Description = "Jim Glasgow holds a coding academy for the under-privileged.",
                VolunteersNeeded = 15
            });
            _fakeEvents.Add(new Event()
            {
                EventID = 4,
                EventName = "Reading Rainbow",
                Description = "Free books are given out to the clients.",
                VolunteersNeeded = 0
            });

            _volNeeded.Add(10);
            _volNeeded.Add(5);
            _volNeeded.Add(15);
            _volNeeded.Add(0);

            clientIDs.Add("test1@company.com");
            clientIDs.Add("test2@company.com");
            clientIDs.Add("test3@company.com");
            clientIDs.Add("test4@company.com");
            clientIDs.Add("test5@company.com");

            eventTypeIDs.Add("type1");
            eventTypeIDs.Add("type2");
            eventTypeIDs.Add("type3");
            eventTypeIDs.Add("type4");
            eventTypeIDs.Add("type5");

            eventRequestVMs.Add(new EventRequestVM()
            {
                RequestID = 1,
                ClientID = "test1@company.com",
                EventTypeID = "type1",
                Information = "Info1"
            });
            eventRequestVMs.Add(new EventRequestVM()
            {
                RequestID = 2,
                ClientID = "test2@company.com",
                EventTypeID = "type2",
                Information = "Info2"
            });
            eventRequestVMs.Add(new EventRequestVM()
            {
                RequestID = 3,
                ClientID = "test3@company.com",
                EventTypeID = "type3",
                Information = "Info3"
            });
            eventRequestVMs.Add(new EventRequestVM()
            {
                RequestID = 4,
                ClientID = "test4@company.com",
                EventTypeID = "type4",
                Information = "Info4"
            });
            eventRequestVMs.Add(new EventRequestVM()
            {
                RequestID = 5,
                ClientID = "test5@company.com",
                EventTypeID = "type5",
                Information = "Info5"
            });
        }

        public int CreateEvent(Event eventParameter)
        {
            int result = 0;
            int oldCount = _fakeEvents.Count;

            _fakeEvents.Add(eventParameter);

            result = _fakeEvents.Count - oldCount;

            return result;
        }

        /*<Summary>
        Creator: Darryl Shirley
        created: 01/22/2024
        Summary: Create Volunteer Event Method
        Last updated By: Darryl Shirley
        Last Updated: 1-26-2024
        What was changed/updated: Initial Creation
        </Summary>*/

        public int CreateVolunteerEvent(int eventID, int oldVolunteersNeeded, int newVolunteersNeeded)
        {
            int rows = 0;
            for (int i = 0; i < _fakeEvents.Count; i++)
            {
                if (_fakeEvents[i].VolunteersNeeded == 0)
                {
                    if (_volNeeded[i] == 0)
                    {
                        _volNeeded[i] = newVolunteersNeeded;
                        rows += 1;
                    }
                }
            }
            if (rows != 1) // no one found
            {
                throw new ApplicationException("Event volunteers not added!");
            }

            return rows;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create eventParticipants() Method.
        /// </summary>
        public List<string> eventParticipants(int EventID)
        {
            List<string> names = new List<string>();
            foreach (EventParticipant eventParticipant in _eventParticipants)
            {
                if (eventParticipant.EventID == EventID)
                {
                    names.Add(eventParticipant.ParticipantName);
                }
            }
            return names;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create eventVolunteers() Method.
        /// </summary>
        public List<string> eventVolunteers(int EventID)
        {
            List<string> names = new List<string>();
            foreach (EventVolunteer eventVolunteer in _volunteers)
            {
                if (eventVolunteer.EventID == EventID)
                {
                    names.Add(eventVolunteer.FullName);
                }
            }
            return names;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetAllEventRequests() Method.
        /// </summary>
        public List<EventRequestVM> GetAllEventRequests()
        {
            return eventRequestVMs;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create GetAllEvents() Method.
        /// </summary>
        public List<EventVM> getAllEvents()
        {
            List<EventVM> events = new List<EventVM>();
            foreach (Event e in _fakeEvents)
            {
                EventVM eventVM = new EventVM();
                eventVM.EventID = e.EventID;
                eventVM.EventName = e.EventName;
                eventVM.Description = e.Description;
                eventVM.VolunteersNeeded = e.VolunteersNeeded;
                events.Add(eventVM);
            }

            return events;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetClientIDs() Method.
        /// </summary>
        public List<string> GetClientIDs()
        {
            return clientIDs;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetEventTypeIDs() Method.
        /// </summary>
        public List<string> GetEventTypeIDs()
        {
            return eventTypeIDs;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create InsertEventRequest() Method.
        /// </summary>
        public void InsertEventRequest(EventRequestVM eventRequestVM)
        {
            eventRequestVMs.Add(eventRequestVM);

        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Gets a list of Volunteer objects based off of a specific eventID
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<Volunteer> GetEventVolunteerDetails(int eventID)
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            volunteers.Add(new Volunteer()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                UserID = "TestUserID"
            });


            return volunteers;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Removes an existing volunteer from a specified event.
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        public int RemoveVolunteerFromEvent(string volunteerID, int eventID)
        {
            int rowsAffected = 0;

            EventVolunteer volunteerToRemove = _volunteers.Find(v => v.VolunteerID == volunteerID && v.EventID == eventID);
            if (volunteerToRemove != null)
            {
                _volunteers.Remove(volunteerToRemove);
                rowsAffected = 1;
            }
            return rowsAffected;
        }

        /// <Summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: Select All Events method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 1-26-2024
        /// What was changed/updated: Initial Creation
        /// </Summary>
        public List<Event> SelectAllEvents()
        {
            return _fakeEvents.FindAll(e => e.EventName != "");
        }

        public List<EventVolunteer> allEventVolunteers()
        {
            return _volunteers;
        }

        /// <Summary>
        /// Creator: Marwa Ibrahim
        /// created: 03/2/2024
        /// Summary: Create  Event participant Method
        /// What was changed/updated: Initial Creation
        /// </Summary>
        public int CreateEventParticipants(EventParticipant eventParticipants)
        {
            int rowsBeforeAdd = _eventParticipants.Count;

            _eventParticipants.Add(eventParticipants);
            int rowsAfterAdd = _eventParticipants.Count;

            return rowsAfterAdd - rowsBeforeAdd;
        }

        /// <Summary>
        /// Creator: Marwa Ibrahim
        /// created: 01/22/2024
        /// Summary: update Events method
        /// Last updated By: Marwa Ibrahim
        /// Last Updated: 1-22-2024
        /// What was changed/updated: Initial Creation
        /// </Summary>
        public bool UpdateEvent(Event newEvent)
        {
            bool result = false;
            foreach (Event @event in _fakeEvents)
            {
                if (@event.EventID == newEvent.EventID)
                {
                    @event.EventName = newEvent.EventName;
                    @event.Description = newEvent.Description;
                    result = true;
                }
            }
            return result;
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 04/18/2024
        /// Summary: Selects the Event by Event ID
        /// </Summary>
        public Event SelectEventByEventID(int eventID)
        {
            return _fakeEvents.FirstOrDefault(x => x.EventID == eventID);
        }

        /*<Summary>
       Creator: Marwa Ibrahim
       created: 01/28/2024
       Summary: Delete Events method
       What was changed/updated: Initial Creation
       </Summary>*/
        public bool DeleteEvent(EventVM @event)
        {
            bool result = false;
            List<Event> events = new List<Event>();
            foreach (Event Event in _fakeEvents)
            {

                if (@event.EventID == Event.EventID) result = true;
                else events.Add(Event);
            }
            _fakeEvents = events;
            return result;
        }

        /*<Summary>
       Creator: Marwa Ibrahim
       created: 01/28/2024
       Summary: Delete Events method
       What was changed/updated: Initial Creation
       </Summary>*/
        public bool CancelSignUp(string participantName, int eventID)
        {
            bool result = false;
            foreach (var item in _fakeEvents)
            {
                if (item.EventID == eventID )
                {
                    item.VolunteersNeeded--;
                    return true;
                }

            }
            return result;
        }

        ///</summary>
        ///Creator:            Matthew Baccam
        ///Created:            04/26/2024
        ///Summary:            Created SelectEventVMByID
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/26/2024
        ///What Was Changed:   Initial creation
        ///</summary>
        public EventVM SelectEventVMByID(int eventID)
        {
            return _fakeEventsVM.First(e => e.EventID == eventID);
        }
    }
}
