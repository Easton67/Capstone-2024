using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator:            Darryl Shirley
    /// Created:            01/31/2024
    /// Summary:            IEventAccessor.cs
    /// Last Updated By:    Darryl Shirley
    /// Last Updated:       01/23/2024
    /// What Was Changed:   Initial creation  
    /// </summary>
    public interface IEventAccessor
    {
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/18/2024
        /// Summary:            initial creation
        /// </summary>
        Event SelectEventByEventID(int eventID);
        EventVM SelectEventVMByID(int eventID);
        int CreateVolunteerEvent(int eventID, int oldVounteersNeeded, int NewVolunteersNeeded);

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 01/23/2024
        /// Summary: Create list of selectAllEvent.
        /// </summary>
        List<Event> SelectAllEvents();

        int CreateEvent(Event eventParameter);

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create  list of EventVM return AllEvents.
        /// </summary>
        
        List<EventVM> getAllEvents();

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create  list of eventParticipants  return string.
        /// </summary>
        List<string> eventParticipants(int EventID);

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create  list of eventVolunteers  return string.
        /// </summary>
        
        List<string> eventVolunteers(int EventID);
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create  list of GetEventTypeIDs.
        /// </summary>

        int RemoveVolunteerFromEvent(string volunteerID, int eventID);

        List<Volunteer> GetEventVolunteerDetails(int eventID);

        List<string> GetEventTypeIDs();
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create  list of GetClientIDs.
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
        /// Summary: Create  list of GetAllEventRequests.
        /// </summary>
        List<EventRequestVM> GetAllEventRequests();

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/02/2024
        /// Summary: Create Event participant.
        /// </summary>
        int CreateEventParticipants(EventParticipant eventParticipants);

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 01/23/2024
        /// Summary: UpdateEvent.
        /// </summary>

        bool UpdateEvent(Event newEvent);

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/23/2024
        /// Summary: update Event.
        /// </summary>

        bool DeleteEvent(EventVM @event);

        bool CancelSignUp(string participantName, int eventID);
    }
}
