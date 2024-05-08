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
    ///Creator:            Mitchell Stirmel
    ///Created:            02/08/2024
    ///Summary:            Test data for the Inventory Accessor
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/08/2024
    ///What Was Changed:   Initial Creation
    ///Last Updated By:    Seth Nerney
    ///Last Updated        04/25/2024
    ///What Was Changed:   Test data for the scheduled repairs
    /// </summary>
    public class MaintenanceAccessorFake : IMaintenanceAccessor
    {
        List<MaintenanceRequest> _maintenanceRequestList = new List<MaintenanceRequest>();
        List<ScheduledRepairs> _scheduledRepairsList = new List<ScheduledRepairs>();
        List<Repair> _repairList = new List<Repair>();


        public MaintenanceAccessorFake()
        {
            _maintenanceRequestList.Add(new MaintenanceRequest
            {
                _requestID = 100000,
                _status = "Pending",
                _requestor = "Joe",
                _phone = "3192471283",
                _dateCreated = DateTime.Now,
                _description = "Description",
                _roomID = 1
            });
            _maintenanceRequestList.Add(new MaintenanceRequest
            {
                _requestID = 100002,
                _status = "Pending",
                _requestor = "Joet",
                _phone = "3192471283",
                _dateCreated = new DateTime(),
                _description = "Description",
                _roomID = 3
            });
            _maintenanceRequestList.Add(new MaintenanceRequest
            {
                _requestID = 100003,
                _status = "Pending",
                _requestor = "Jaod",
                _phone = "3192471283",
                _dateCreated = DateTime.MaxValue,
                _description = "Description",
                _roomID = 34
            });

            _scheduledRepairsList.Add(new ScheduledRepairs
            {
                _repairID = 100000,
                _employeeID = "s@email.com",
                _requestID = 100000,
                _status = "Scheduled for repair"
            });

            _scheduledRepairsList.Add(new ScheduledRepairs
            {
                _repairID = 100001,
                _employeeID = "a@email.com",
                _requestID = 100001,
                _status = "Scheduled for repair"
            });

            _scheduledRepairsList.Add(new ScheduledRepairs
            {
                _repairID = 100002,
                _employeeID = "d@email.com",
                _requestID = 100002,
                _status = "Scheduled for repair"
            });

        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/05/2024
        /// Summary:            Fake InsertMaintenanceRequest accessor method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int InsertMaintenanceRequest(MaintenanceRequest maintenanceRequest) {
            int preCount = _maintenanceRequestList.Count;
            try {
                _maintenanceRequestList.Add(maintenanceRequest);
                return _maintenanceRequestList.Count - preCount;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        ///Creator:           Marwa Ibrahim
        ///Created:            02/20/2024
        ///Summary:            insert fake maintenance request  
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool insertMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            int sizeOfListBeforeAdd = _maintenanceRequestList.Count;
            _maintenanceRequestList.Add(maintenanceRequest);
            int sizeOfListAfterAdd = _maintenanceRequestList.Count;
            return sizeOfListAfterAdd - sizeOfListBeforeAdd == 1;

        }

        /// <summary>
        ///Creator:            Kirsten Stage
        ///Created:            03/07/2024
        ///Summary:            This fake method allows us to return fake data for the specified method.
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public int UpdateMaintenanceRequestStatusToCompleted(int requestID)
        {
            int rows = 0;
            requestID = 100000;

            for (int i = 0; i < _maintenanceRequestList.Count; i++)
            {
                if (_maintenanceRequestList[i]._requestID == requestID)
                {
                    _maintenanceRequestList[i]._status = "Completed";
                    rows += 1;
                }
            }
            if (rows != 1)
            {
                throw new ApplicationException("Status not updated.");
            }

            return rows;
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/08/2024
        ///Summary:            This fake method allows us to return fake data for the specified method.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<MaintenanceRequest> ViewMaintenanceRequests() {
            return _maintenanceRequestList;
        }

        List<MaintenanceRequest> IMaintenanceAccessor.ViewMaintenanceRequests() {
            return _maintenanceRequestList;
		}
		
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            02/23/2024
        ///Summary:            This fake method allows us to confirm maintenance request for the specified method
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        public int ConfirmMaintenanceRequest(int requestID, string status)
        {
            int result = 0;
            foreach (var MaintenanceRequest in _maintenanceRequestList)
            {
                if (MaintenanceRequest._requestID == requestID && MaintenanceRequest._status == status)
                {
                    MaintenanceRequest._status = status;
                    result++;
                }
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
        public bool UpdateMaintenanceRequestForSuspension(int requestID, string oldDescription, string newDescription)
        {
            var response = false;
            var status = "Suspended";
            _maintenanceRequestList.ForEach(r =>
            {
                if (r._requestID == requestID)
                {
                    r._status = status;
                    response = true;
                }
            });
            return response;
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: This fake method adds a repair to the fake repairs list.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public bool ScheduleRepair(int requestID, string employeeID, DateTime repairDate)
        { 
            int repairCount = _repairList.Count;
            var response = false;
            _repairList.Add(new Repair
            {
                RequestID = requestID,
                EmployeeID = employeeID,
                RepairDate = repairDate
            });

            int updatedRepairCount = _repairList.Count;
            if (repairCount < updatedRepairCount)
            {
                response = true;
            }
            return response;
        }

        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/13/2024
        /// Summary:            This fake method returns the list of schedule repairs
        /// Last Updated By:    Seth Nerney
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>

        public List<ScheduledRepairs> ViewScheduledRepairs(string status)
        {
            return _scheduledRepairsList.FindAll(s => s._status == status);
        }
    }
}
