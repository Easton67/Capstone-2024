using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Miyada Abas
    /// Created:            03/01/2024
    /// Summary:            Creation of HouseKeepingManager class
    /// Last Updated By:    Miyada Abas
    /// Last Updated:       01/30/2024
    /// What Was Changed:    Creation of HouseKeepingManager class
    /// </summary>
    public class HouseKeepingManager : IHouseKeepingManager
    {
        private IHouseKeepingAccessor housekeepingaccessor;
        public HouseKeepingManager() { 
            housekeepingaccessor = new HouseKeepingAccessor();
        }

        public HouseKeepingManager(IHouseKeepingAccessor houseKeepingAccessor)
        {
            this.housekeepingaccessor = houseKeepingAccessor;
        }
        public List<HouseKeepingTask> GetAllHouseKeepingTasks()
        {
           List<HouseKeepingTask> houseKeepingTasks = new List<HouseKeepingTask>();
            try
            {
                houseKeepingTasks = housekeepingaccessor.SelectAllHouseKeepingTasks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return houseKeepingTasks;
        }
    }


}
