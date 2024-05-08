using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;

namespace LogicLayer
{
    public class EventManager : IEventManager
    {
        private IEventAccessor _eventAccessInterface;
        public EventManager()
        {
            _eventAccessInterface = new EventAccessor();
        }
        public EventManager(IEventAccessor eventAccessor)
        {
            _eventAccessInterface = eventAccessor;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Create addVolunteerEvent to add an event to the list of Events from the EventAcessor
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/07/2024
        /// What Was Changed:   updated method with new parameters  
        /// </summary>
        public bool addVolunteerEvent(int eventID, int oldVounteersNeeded, int NewVolunteersNeeded)
        {
            bool result = false;

            try
            {
                if (_eventAccessInterface.CreateVolunteerEvent(eventID, oldVounteersNeeded, NewVolunteersNeeded) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event not created", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            Marwa Ibrahim
        /// Summary:            initial creation
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/18/2024
        /// What Was Changed:   changed the method to return bool and catch the result for validation purposes
        /// </summary>
        public bool CreateEvent(Event eventParameter)
        {
            bool result = false;

            try
            {
                if (_eventAccessInterface.CreateEvent(eventParameter) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event not created", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 4/18/2024
        /// Summary: Implemented the SelectAllEvents into the logic layer
        /// </summary>
        public List<Event> SelectAllEvents()
        {
            try
            {
                return _eventAccessInterface.SelectAllEvents();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get events", ex);
            }
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 4/18/2024
        /// Summary: initial creation of SelectEventByEventID method
        /// </summary>
        public Event SelectEventByEventID(int eventID)
        {
            Event currentEvent = new Event();

            try
            {
                currentEvent = _eventAccessInterface.SelectEventByEventID(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to find your event", ex);
            }

            return currentEvent;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create getAllEvents() Method .
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>

        public List<EventVM> getAllEvents()
        {
            try
            {
                return _eventAccessInterface.getAllEvents();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get events", ex);
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/29/2024
        /// Summary: Gets event volunteer details
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<Volunteer> GetEventVolunteerDetails(int eventID)
        {
            try
            {
                return _eventAccessInterface.GetEventVolunteerDetails(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get event volunteer details", ex);
            }
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetClientIDs() Method .
        /// </summary>
        public List<string> GetClientIDs()
        {
            try
            {
                return _eventAccessInterface.GetClientIDs();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("ClientIDs not retreived", ex);
            }
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetEventRequests() Method .
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<EventRequestVM> GetEventRequests()
        {
            try
            {
                return _eventAccessInterface.GetAllEventRequests();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get event requests", ex);
            }
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetEventTypeIDs() Method .
        /// </summary>
        public List<string> GetEventTypeIDs()
        {
            try
            {
                return _eventAccessInterface.GetEventTypeIDs();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("EventTypeIDs not retreived", ex);
            }
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create GetParticipant() Method .
        /// </summary>
        public List<string> GetParticipant(int EventID)
        {
            try
            {
                var participants = _eventAccessInterface.eventParticipants(EventID);
                if (participants == null)
                {
                    participants = new List<string>();
                }
                return participants;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Participant not retreived", ex);
            }

        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create GetVolunteer() Method .
        /// </summary>
        public List<string> GetVolunteer(int EventID)
        {
            try
            {
                return _eventAccessInterface.eventVolunteers(EventID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Volunteer not retreived", ex);
            }

        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Removes an existing volunteer from a specified event.
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Intial Creation
        /// </summary>
        public int RemoveVolunteerFromEvent(string volunteerID, int eventID)
        {
            int rows = 0;
            try
            {
                rows = _eventAccessInterface.RemoveVolunteerFromEvent(volunteerID, eventID);
                if (rows == 1)
                {
                    return rows;
                }
                else
                {
                    throw new ApplicationException("Error removing volunteer. Rows affected: " + rows);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error removing volunteer", ex);
            }
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create InsertEventRequest() Method .
        /// </summary>
        public void InsertEventRequest(EventRequestVM eventRequestVM)
        {
            try
            {
                _eventAccessInterface.InsertEventRequest(eventRequestVM);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Event Request not created", ex);
            }
        }

        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            02/16/2024
        /// Summary:            initial creation
        /// </summary>
        public bool AddEventParticipants(EventParticipant eventParticipants)
        {
            bool result = false;
            try
            {

                result = (1 == _eventAccessInterface.CreateEventParticipants(eventParticipants));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 01/23/2024
        /// Summary: Create UpdateEvent() Method .
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public bool UpdateEvent(Event newEvent)
        {
            try
            {
                return _eventAccessInterface.UpdateEvent(newEvent);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update event", ex);
            }
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/27/2024
        /// Summary: Delete Event() Method .
        /// </summary>
        public bool DeleteEvent(EventVM @event)
        {
            bool result = false;
            result = _eventAccessInterface.DeleteEvent(@event);
            return result;
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/18/2024
        /// Summary: Cancel Event SignUp() Method .
        /// </summary>

        public bool CancelSignUp(string participantName, int eventID)
        {
            try
            {
                return _eventAccessInterface.CancelSignUp(participantName, eventID);
            }
            catch (Exception)
            {

                throw new ApplicationException(" Fail to Cancel SignUp");
            }
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
            try
            {
                return _eventAccessInterface.SelectEventVMByID(eventID);
            }
            catch (Exception)
            {
                throw new ApplicationException("Failed to select EventVM");
            }
        }

        //Marwa Ibrahim
        public bool EditEvent(Event newEvent)
        {
            bool result = false;

            result = _eventAccessInterface.UpdateEvent(newEvent);
            return result;
        }

        public List<Event> EditEvent()
        {
            throw new NotImplementedException();
        }
    }
}