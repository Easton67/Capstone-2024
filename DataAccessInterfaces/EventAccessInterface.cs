using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface EventAccessInterface
    {
        bool CreateEvent(Event @event);
    }
}
