using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/29/2024
    /// Summary: Event Meal Plan Accessor Fakes class
    /// Last Updated: 03/29/2024
    /// Last Updated By: Kirsten Stage
    /// What Was Changed: Initial Creation
    /// </summary>

    public class EventMealPlanAccessorFakes : IEventMealPlanAccessor
    {
        private List<EventMealPlan> _eventMealPlan = new List<EventMealPlan>();

        public EventMealPlanAccessorFakes() 
        {
            _eventMealPlan.Add(new EventMealPlan
            {
                EventMealID = 1,
                EventID = 1,
                Food = "Sandwich",
                Beverages = "Water",
                EventName = "Name1",
                Date = DateTime.Now,
                Time = DateTime.Now
            });

            _eventMealPlan.Add(new EventMealPlan
            {
                EventMealID = 2,
                EventID = 2,
                Food = "Sandwich",
                Beverages = "Water",
                EventName = "Name2",
                Date = DateTime.Now,
                Time = DateTime.Now
            });

            _eventMealPlan.Add(new EventMealPlan
            {
                EventMealID = 3,
                EventID = 3,
                Food = "Sandwich",
                Beverages = "Water",
                EventName = "Name3",
                Date = DateTime.Now,
                Time = DateTime.Now
            });
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: The implementation of SelectAllEventNames() that is being used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<string> SelectAllEventNames()
        {
            List<string> eventNames = new List<string>();

            foreach (EventMealPlan eventMealPlan in _eventMealPlan)
            {
                eventNames.Add(eventMealPlan.EventName);
            }

            return eventNames;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: The implementation of SelectEventMealsById() that is being used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public EventMealPlan SelectEventMealsByName(string eventName)
        {
            return _eventMealPlan.Find(e => e.EventName == eventName);
        }
    }
}
