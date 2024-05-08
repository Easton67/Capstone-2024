using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ibrahim Albashair
    /// Created: 02/10/2024
    /// Summary: Created IVistAccessor interface 
    /// Last Updated By: Ibrahim Albashair
    /// Last Updated 02/10/2024
    /// What was changed: Initial Creation.
    /// </summary>
    public interface IVisitAccessor
    {
        int CreateVisit(Visit visit);

        List<Visit> GetAllVisitsByName(string firstName, string lastName);

        int DeleteVisit(Visit visit);

        int RescheduleVisit(int visitID, DateTime checkIn, DateTime checkOut);

        int VisitCount(DateTime searchDate);

        bool UpdateVisitForCheckInByVisitID(int visitID, DateTime oldCheckIn);

        bool UpdateVisitForCheckOutByVisitID(int visitID, DateTime oldCheckOut);

        List<Visit> SelectVisitWithFromTo(DateTime from, DateTime to);

        Visit SelectVisitByVisitID(int visitID);
        List<Visit> GetAllVisits();
    }
}
