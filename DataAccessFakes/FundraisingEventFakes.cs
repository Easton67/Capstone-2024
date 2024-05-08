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
    /// Created: 04/11/2024
    /// Summary: Fundraising Event Fakes class to help with testing. It implements
    ///          the IFundraisingEventAccessor interface. 
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public class FundraisingEventFakes : IFundraisingEventAccessor
    {
        public List<FundraisingEvent> fakeFundraisingEvents = new List<FundraisingEvent>();

        public FundraisingEventFakes()
        {
            fakeFundraisingEvents.Add(new FundraisingEvent()
            {
                FundraisingId = 1,
                EventName = "Name1",
                FundraisingGoal = 100m,
                EventAddress = "Online",
                EventDate = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                EventDescription = "Description1"
            });

            fakeFundraisingEvents.Add(new FundraisingEvent()
            {
                FundraisingId = 2,
                EventName = "Name2",
                FundraisingGoal = 100m,
                EventAddress = "Online",
                EventDate = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                EventDescription = "Description2"
            });

            fakeFundraisingEvents.Add(new FundraisingEvent()
            {
                FundraisingId = 3,
                EventName = "Name3",
                FundraisingGoal = 100m,
                EventAddress = "Online",
                EventDate = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                EventDescription = "Description3"
            });
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: The implementation of InsertFundraisingEvent() used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public int InsertFundraisingEvent(FundraisingEvent fundraisingEvent)
        {
            int rows = 0;

            for (int i = 0; i < fakeFundraisingEvents.Count; i++)
            {
                if (fakeFundraisingEvents[i].FundraisingId.GetType() == typeof(int) &&
                    fakeFundraisingEvents[i].EventName.GetType() == typeof(string) &&
                    fakeFundraisingEvents[i].FundraisingGoal.GetType() == typeof(decimal) &&
                    fakeFundraisingEvents[i].EventAddress.GetType() == typeof(string) &&
                    fakeFundraisingEvents[i].EventDate.GetType() == typeof(DateTime) &&
                    fakeFundraisingEvents[i].StartTime.GetType() == typeof(DateTime) &&
                    fakeFundraisingEvents[i].EndTime.GetType() == typeof(DateTime) &&
                    fakeFundraisingEvents[i].EventDescription.GetType() == typeof(string))
                {
                    rows = 1;
                }
            }

            return rows;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: The implementation of GetFundraisingEvents() used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<FundraisingEvent> RetrieveFundraisingEvents()
        {
            List<FundraisingEvent> events = new List<FundraisingEvent>();

            foreach(FundraisingEvent fe in fakeFundraisingEvents)
            {
                events.Add(fe);
            }

            return events;
        }
    }
}
