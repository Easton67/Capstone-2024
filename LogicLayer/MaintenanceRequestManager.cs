using DataAccessInterfaces;
using DataObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace LogicLayer
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/08/2024
    ///Summary:            This class contains all the methods for maintenance requests.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/08/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class MaintenanceRequestManager : IMaintenanceRequestManager
    {
        IMaintenanceAccessor _maintenanceAccess;
        public MaintenanceRequestManager() 
        {
            _maintenanceAccess = new MaintenanceRequestAccessor();
        }
        public MaintenanceRequestManager(IMaintenanceAccessor maintenanceAccess)
        {
            _maintenanceAccess = maintenanceAccess;
        }

        /// <summary>
        ///Creator:            Jared Harvey
        ///Created:            03/03/2024
        ///Summary:            Method implementation for CreateMaintenanceRequest.
        ///Last Updated By:    Jared Harvey
        ///Last Updated:       03/03/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest) {
            try {
                return (1 == _maintenanceAccess.InsertMaintenanceRequest(maintenanceRequest));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/08/2024
        ///Summary:            This method gets all maintenance requests.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/08/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public List<MaintenanceRequest> GetMaintenanceRequests()
        {
            return _maintenanceAccess.ViewMaintenanceRequests();
        }


        ///// <summary>
        /////Creator:            Marwa Ibrahim
        /////Created:            02/20/2024
        /////Summary:            This method Create maintenance requests.
        ///// </summary>
        //public bool CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        //{
        //    bool result = true;
        //    try
        //    {
        //        result = _maintenanceAccess.insertMaintenanceRequest(maintenanceRequest);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
       
        //    return result;
        //}

        /// <summary>
        ///Creator:            Kirsten Stage
        ///Created:            03/07/2024
        ///Summary:            This method updates the maintenance request status to completed.
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool UpdateMaintenanceRequestStatusToCompleted(MaintenanceRequest maintenanceRequest)
        {
            var result = false;

            try
            {
                result = (1 == _maintenanceAccess.UpdateMaintenanceRequestStatusToCompleted(maintenanceRequest._requestID));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            02/23/2024
        ///Summary:            This method confirms maintenance request
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        public bool ConfirmMaintenanceRequest(int requestID, string status)
        {
            bool result = false;
            try
            {
                result = (1 == _maintenanceAccess.ConfirmMaintenanceRequest(requestID, status));
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update status", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/01/2024
        /// Summary: Updates maintenance request for suspension
        /// Last Updated By: Matthew Baccam
        /// Last Updated 03/01/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public bool SuspendMaintenanceRequest(int requestID, string oldDescription, string newDescription)
        {
            try
            {
                return _maintenanceAccess.UpdateMaintenanceRequestForSuspension(requestID, oldDescription, newDescription);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to suspend request", ex);
            }
        }
        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Adds a scheduled repair
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public bool ScheduleRepair(int requestID, string employeeID, DateTime repairDate)
        {
            try
            {
                return _maintenanceAccess.ScheduleRepair(requestID, employeeID, repairDate);
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to schedule repair", ex);
            };
        }


        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/15/2024
        /// Summary:            This method gets all scheduled repairs.
        /// Last Updated By:    Seth Nerney
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<ScheduledRepairs> GetScheduledRepairs(string status)
        {
            return _maintenanceAccess.ViewScheduledRepairs(status);
        }
    }
}
