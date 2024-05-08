using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/29/2024
    /// Summary: Event Meal Plan Manager class
    /// Last Updated: 03/29/2024
    /// Last Updated By: Kirsten Stage
    /// What Was Changed: Initial Creation
    /// </summary>

    public class EventMealPlanManager : IEventMealPlanManager
    {
        private IEventMealPlanAccessor _eventMealPlanAccessor = null;

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: Created two constructors for dependency inversion.
        ///          The first is for the presentation layer and the second is 
        ///          for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public EventMealPlanManager() 
        {
            _eventMealPlanAccessor = new EventMealPlanAccessor();
        }

        public EventMealPlanManager(IEventMealPlanAccessor eventMealPlanAccessor)
        {
            _eventMealPlanAccessor = eventMealPlanAccessor;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: Created the GetMealPlanById() method. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public EventMealPlan GetMealPlanByName(string eventName)
        {
            EventMealPlan eventMealPlan = null;

            try
            {
                eventMealPlan = _eventMealPlanAccessor.SelectEventMealsByName(eventName);

                if (eventMealPlan == null)
                {
                    throw new ArgumentException("Event Meal Plan Not Found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not Found.", ex);
            }

            return eventMealPlan;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: Created the GetEventNamesForDropDown() method. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<string> GetEventNamesForDropDown()
        {
            List<string> eventNamesList = null;

            try
            {
                eventNamesList = _eventMealPlanAccessor.SelectAllEventNames();

                if (eventNamesList == null || eventNamesList.Count == 0)
                {
                    throw new ArgumentException("Event names not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found", ex);
            }

            return eventNamesList;
        }
    }
}
