using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ibrahim Albashair
    /// Created: 02/10/2024
    /// Summary: Created IVisit interface
    /// Last Updated By: Ibrahim Albashair
    /// Last Updated 02/10/2024
    /// What was changed: Initial Creation.
    /// </summary>
    public interface IVisitManager
    {
        int CreateVisit(Visit visit);
        List<Visit> GetAllVisitsByName(string firstName, string lastName);
        int DeleteVisit(Visit visit);
        int RescheduleVisit(int visitID, DateTime checkIn, DateTime checkOut);
        bool CheckInGuest(int visitID, DateTime oldCheckIn);
        bool CheckOutGuest(int visitID, DateTime oldCheckOut);
        int SearchAppointmentCount(DateTime searchDate);
        List<Visit> SelectVisitWithFromTo(DateTime from, DateTime to);
        Visit GetVisitByVisitID(int visitID);
        List<Visit> GetAllVisits();
    }
}
