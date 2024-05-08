using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            02/08/2024
    ///Summary:            This interface contains all the methods that are to be implemented by the fakes or accessors.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/08/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public interface IMaintenanceRequestManager
    {

        /// <summary>
        ///Creator:            Marwa Ibrahim
        ///Created:            02/20/2024
        ///Summary:            This interface contains all the methods that are to be implemented by the fakes or accessors.
        /// </summary>

        bool CreateMaintenanceRequest(MaintenanceRequest maintenanceRequest);

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/08/2024
        ///Summary:            This interface method gets all the maintenance requests.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<MaintenanceRequest> GetMaintenanceRequests();

        /// <summary>
        ///Creator:            Kirsten Stage
        ///Created:            03/07/2024
        ///Summary:            This interface method updates the status of a maintenance request to completed
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        bool UpdateMaintenanceRequestStatusToCompleted(MaintenanceRequest maintenanceRequest);

        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            02/23/2024
        ///Summary:            This interface method confirms the maintenance request
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        bool ConfirmMaintenanceRequest(int requestID, string status);

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/01/2024
        /// Summary: Updates maintenance request for suspension
        /// Last Updated By: Matthew Baccam
        /// Last Updated 03/01/2024
        /// What was changed: Initial Creation.
        /// </summary>
        bool SuspendMaintenanceRequest(int requestID, string oldDescription, string newDescription);


        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 04/019/2024
        /// Summary: Adds a scheduled repair
        /// Last Updated By: Andres Garcia
        /// Last Updated 04/19/2024
        /// What was changed: Initial Creation.
        /// </summary>
        bool ScheduleRepair(int requestID, string employeeID, DateTime repairDate);

        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/13/2024
        /// Summary:            Gets all scheduled repairs
        /// Last Updated By:    Seth Nerney
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        List<ScheduledRepairs> GetScheduledRepairs(string status);
        

    }
}
