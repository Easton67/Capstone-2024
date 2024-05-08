using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessFakes
{
    public class EventAccessFakes: EventAccessInterface 
    {
        List<Event> events {  get; set; }
        public EventAccessFakes()
        {
            events = new List<Event>();
            Event event1 = new Event { EventID = 1, EventName = "Party", Description = "This my evet"};
            Event event2 = new Event { EventID = 2, EventName = "Party 2", Description = "This my evet" };
            Event event3 = new Event { EventID = 3, EventName = "Party 3", Description = "This my evet" };
            Event event4 = new Event { EventID = 4, EventName = "Party 4", Description = "This my evet" };
            Event event5 = new Event { EventID = 5, EventName = "Party 5", Description = "This my evet" };
            events.Add(event1);
            events.Add(event2);
            events.Add(event3);
            events.Add(event4);
            events.Add(event5);


        }

        public bool CreateEvent(Event @event)
        {
            events.Add(@event);
            return true;
        }
    }
}
