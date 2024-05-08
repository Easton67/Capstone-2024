using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Ibrahim Albashair
    /// Created: 02/10/2024
    /// Summary: Created VisitManager Class
    /// Last Updated By: Ibrahim Albashair
    /// Last Updated 02/10/2024
    /// What was changed: Initial Creation.
    /// </summary>
    public class VisitManager : IVisitManager
    {
        private IVisitAccessor _visitAccessor;

        public VisitManager()
        {
            _visitAccessor = new VisitAccessor();
        }

        public VisitManager(IVisitAccessor visitAccessor)
        {
            _visitAccessor = visitAccessor;
        }


        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Creates a visit
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public int CreateVisit(Visit visit)
        {
            int rows = 0;
            try
            {
                rows = _visitAccessor.CreateVisit(visit);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Deletes a visit 
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 04/04/2024
        /// Last Updated By: Matthew Baccam <summary>
        /// What Was changed: Madet the delete method pass the whole object selected rather than the visit id
        /// </summary>
        public int DeleteVisit(Visit visit)
        {
            int result = 0;

            try
            {
                result = _visitAccessor.DeleteVisit(visit);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Returns list of Visits, searched by full name (first namd + last name)
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public List<Visit> GetAllVisitsByName(string firstName, string lastName)
        {
            List<Visit> visits = new List<Visit>();
            try
            {
                visits = _visitAccessor.GetAllVisitsByName(firstName, lastName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return visits;
        }


        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/20/2024
        /// Summary: Returns int, Reschules visit by visit ID
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public int RescheduleVisit(int visitID, DateTime checkIn, DateTime checkOut)
        {
            int result = 0;
            try
            {
                _visitAccessor.RescheduleVisit(visitID, checkIn, checkOut);
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/15/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/15/2024
        //What Was Changed: Initial Creation
        //<Summary>
        public bool CheckInGuest(int visitID, DateTime oldCheckIn)
        {
            try
            {
                return _visitAccessor.UpdateVisitForCheckInByVisitID(visitID, oldCheckIn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/15/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/15/2024
        //What Was Changed: Initial Creation
        //<Summary>
        public bool CheckOutGuest(int visitID, DateTime oldCheckOut)
        {
            try
            {
                return _visitAccessor.UpdateVisitForCheckOutByVisitID(visitID, oldCheckOut);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        public int SearchAppointmentCount(DateTime searchDate)
        {
            try
            {
                return _visitAccessor.VisitCount(searchDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/15/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/22/2024
        //What Was Changed: Added the clientManager = null param so that the test uses a fake clientaccessor to create a vm in testing otherwise it will use the real accessor
        //<Summary>
        public List<Visit> SelectVisitWithFromTo(DateTime from, DateTime to)
        {
            try
            {
                return _visitAccessor.SelectVisitWithFromTo(from, to);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/15/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/22/2024
        //What Was Changed: Added the clientManager = null param so that the test uses a fake clientaccessor to create a vm in testing otherwise it will use the real accessor
        //<Summary>
        public Visit GetVisitByVisitID(int visitID)
        {
            try
            {
                return _visitAccessor.SelectVisitByVisitID(visitID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/20/2024
        /// Summary: Returns list of all visits
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 04/17/2024
        /// What was changed: Initial Creation.
        /// </summary>

        public List<Visit> GetAllVisits()
        {
            List<Visit> visits = new List<Visit>();
            try
            {
                visits = _visitAccessor.GetAllVisits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return visits;
        }
    }
}
