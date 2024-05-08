using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IConfiscatedItemManager
    {
        List<ConfiscatedItem> GetAllConfiscatedItems();
        bool AddConfiscatedItem(string itemConfiscated, string reasonForConfiscation);
    }
}
