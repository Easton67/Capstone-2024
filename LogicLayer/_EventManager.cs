using DataAccessLayer;
using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class _EventManager : IEventManager
    {
        private IEventAccessor _eventAccessor;


        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            _EventManager Constructor Method without parameters
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   updated method with new parameters  
            </summary>
        */
        public _EventManager()
        {
            _eventAccessor = new EventAccessor();
        }


        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            _EventManager Constructor with parameters
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   updated method with new parameters  
            </summary>
        */
        public _EventManager(IEventAccessor eventAccessor)
        {
            _eventAccessor = eventAccessor;
        }


        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            Create addVolunteerEvent to add an event to the list of Events from the EventAcessor
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   updated method with new parameters  
            </summary>
        */
        public bool addVolunteerEvent(int eventID, int oldVounteersNeeded, int NewVolunteersNeeded)
        {
            bool result = false;

            try
            {
                if (_eventAccessor.CreateVolunteerEvent(eventID, oldVounteersNeeded, NewVolunteersNeeded) == 1)
                {
                    result = true;
                }
            }
            catch(Exception ex)
            {
                result = false;
                throw new ApplicationException("Event not created", ex);
            }

            return result;
        }

        public int CreateEvent(Event @event)
        {
            try
            {
                return _eventAccessor.CreateEvent(@event);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditEvent(Event newEvent)
        {
            bool result = false;
            try
            {
                result = _eventAccessor.UpdateEvent(newEvent);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<Event> EditEvent()
        {
            throw new NotImplementedException();
        }

        //public List<Event> EditEvent()
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create getAllEvent() Method .
        /// </summary>
        public List<EventVM> getAllEvents()
        {
            return _eventAccessor.getAllEvents();
        }
    }

    
}
