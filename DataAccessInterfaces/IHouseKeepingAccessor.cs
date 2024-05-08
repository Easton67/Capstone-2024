using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Miyada Abas
    /// Created: 03/01/2024
    /// Summary: This data access interface for HouseKeepingTasks.
    /// Last Updated By: Miyada Abas
    /// Last Updated 03/01/2024
    /// What was changed: Initial Creation
    /// </summary>
    public interface IHouseKeepingAccessor
    {
        List<HouseKeepingTask> SelectAllHouseKeepingTasks();
    }
}
