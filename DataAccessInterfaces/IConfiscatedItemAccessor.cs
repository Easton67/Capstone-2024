using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IConfiscatedItemAccessor
    {
        List<ConfiscatedItem> GetAllConfiscatedItems();
        int AddConfiscatedItem(string itemConfiscated, string reasonForConfiscation);
    }
}
