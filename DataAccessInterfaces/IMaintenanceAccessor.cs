using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/08/2024
    ///Summary:            This interface contains all the methods that are to be implemented by the fakes or accessors.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/08/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public interface IMaintenanceAccessor
    {
        List<MaintenanceRequest> ViewMaintenanceRequests();
        /// <summary>
        ///Creator:            Jared Harvey
        ///Created:            03/03/2024
        ///Summary:            Method definition for InsertMaintenanceRequest.
        ///Last Updated By:    Jared Harvey
        ///Last Updated:       03/03/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        int InsertMaintenanceRequest(MaintenanceRequest maintenanceRequest);

        /// <summary>
        ///Creator:            Marwa Ibrahim
        ///Created:            02/20/2024
        ///Summary:            This interface contains all the methods that are to be implemented by the fakes or accessors.sssss
        ///What Was Changed:   Initial Creation
        /// </summary>

        bool insertMaintenanceRequest(MaintenanceRequest maintenanceRequest);

        /// <summary>
        ///Creator:            Kirsten Stage
        ///Created:            03/07/2024
        ///Summary:            This interface method updates the maintenance request status to completed
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        int UpdateMaintenanceRequestStatusToCompleted(int requestID);
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            02/23/2024
        ///Summary:            This interface method updates the maintenance request status to "in progress"
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        int ConfirmMaintenanceRequest(int requestID, string status);

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/01/2024
        /// Summary: Updates maintenance request for suspension
        /// Last Updated By: Matthew Baccam
        /// Last Updated 03/01/2024
        /// What was changed: Initial Creation.
        /// </summary>
        bool UpdateMaintenanceRequestForSuspension(int requestID, string oldDescription, string newDescription);

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Adds a scheduled repair.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>
        bool ScheduleRepair(int requestID, string employeeID, DateTime repairDate);

        /// <summary>
        /// Creator:Seth Nerney
        /// Created: 4/25/2024
        /// Summary: view scheduled repairs
        /// Last Updated By: Seth Nerney
        /// Last Updated: 4/25/2024
        /// What was Changed: Inital Creation
        /// </summary>
        /// 
        List<ScheduledRepairs> ViewScheduledRepairs(string status);
    }
}



