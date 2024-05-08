using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Darryl Shirley
    /// Created:            01/31/2024
    /// Summary:            IEventManager
    /// Last Updated By:    Darryl Shirley
    /// Last Updated:       02/07/2024
    /// What Was Changed:   updated method with new parameters  
    /// </summary>
    public interface IEventManager
    {
        EventVM SelectEventVMByID(int eventID);
        bool addVolunteerEvent(int eventID, int oldVounteersNeeded, int NewVolunteersNeeded);

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create getAllEvents() Method .
        /// </summary>
        List<EventVM> getAllEvents();

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 04/18/2024
        /// Summary: implemented the SelectAllEvents() method into the interface
        /// </summary>
        List<Event> SelectAllEvents();

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 04/18/2024
        /// Summary: implemented the SelectEventByEventID() method into the interface
        /// </summary>
        Event SelectEventByEventID(int eventID);


        bool CreateEvent(Event @event);
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create GetParticipant() Method .
        /// </summary>
        List<string> GetParticipant(int EventID);

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create GetVolunteer() Method .
        /// </summary>
        List<string> GetVolunteer(int EventID);

        int RemoveVolunteerFromEvent(string volunteerID, int eventID);

        List<Volunteer> GetEventVolunteerDetails(int eventID);
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create  list of GetEventTypeIDs  return string.
        /// </summary>

        List<string> GetEventTypeIDs();
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create  list of GetClientIDs  return string.
        /// </summary>

        List<string> GetClientIDs();
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create  list of InsertEventRequest.
        /// </summary>

        void InsertEventRequest(EventRequestVM eventRequestVM);

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create  list of GetEventRequests.
        /// </summary>
        List<EventRequestVM> GetEventRequests();

        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            03/11/2024
        /// Summary:            IEventManager  
        /// </summary>
        bool AddEventParticipants(EventParticipant eventParticipants);

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 01/23/2024
        /// Summary: Edit  list of Event.
        /// </summary>
        bool UpdateEvent(Event newEvent);

        bool DeleteEvent(EventVM @event);


        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/14/2024
        /// Summary: 
        /// </summary>
        
        bool CancelSignUp(string participantName, int eventID);
        bool EditEvent(Event newEvent);
        List<Event> EditEvent();
    }
}