using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ibrahim Albashair
    /// Created: 02/10/2024
    /// Summary: Created VisitAccessorFake to add fake data for testing
    /// Last Updated By: Ibrahim Albashair
    /// Last Updated 02/10/2024
    /// What was changed: Initial Creation.
    /// Last Updated By: Matthew Baccam
    /// Last Updated 02/28/2024
    /// What was changed: Fixed the fake visits to have a datetime object instead of just a time thats a string
    /// </summary>
    public class VisitAccessorFake : IVisitAccessor
    {
        //Creating fake data 
        private List<Visit> _visits = new List<Visit>();


        public VisitAccessorFake()
        {
            _visits.Add(new Visit
            {
                VisitID = 1,
                FirstName = "Frank",
                LastName = "Johnson",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            });

            _visits.Add(new Visit
            {
                VisitID = 2,
                FirstName = "Gale",
                LastName = "Johnson",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            });

            _visits.Add(new Visit
            {
                VisitID = 3,
                FirstName = "Jerry",
                LastName = "Johnson",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            });

            _visits.Add(new Visit
            {
                VisitID = 4,
                FirstName = "Tommy",
                LastName = "Johnson",
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now,
                VisitReason = "VisitClient"
            });

            _visits.Add(new Visit
            {
                VisitID = 5,
                FirstName = "Frank",
                LastName = "Johnson",
                CheckIn = new DateTime(2023-04-15),
                CheckOut = new DateTime(2023 - 04 - 15),
                VisitReason = "VisitClient"
            });

        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created createViist 
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated By: Matthew Baccam
        /// Last Updated 02/28/2024
        /// What was changed: I made the CreateVisit pass a object in the param instead of the individual properties of that obj
        /// </summary>
        public int CreateVisit(Visit visit)
        {
            int i = 0;
            try
            {
                _visits.Add(new Visit
                {
                    VisitID = 6,
                    FirstName = visit.FirstName,
                    LastName = visit.LastName,
                    CheckIn = visit.CheckIn,
                    CheckOut = visit.CheckOut,
                    VisitReason = visit.VisitReason
                });
                i = 1;
            }
            catch (Exception)
            {

                throw;
            }

            return i;


        }


        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Delete a visit using visit ID
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 04/04/2024
        /// Last Updated By: Matthew Baccam
        /// What was changed: Removed the "dupList" that was created because it was not needed since we already have a list called _visits that stores all the visits for testing
        ///                 DIDNT do check in and check out since the seconds are going to be different with the _visits list being created a little after the one thats created in the test
        /// </summary>
        public int DeleteVisit(Visit visit)
        {
            int result = 0;
            Visit visitToDelete = null;
            foreach (Visit v in _visits)
            {
                if (visit.VisitID == v.VisitID &&
                    visit.FirstName == v.FirstName &&
                    visit.LastName == v.LastName &&
                    visit.VisitReason == v.VisitReason &&
                    visit.Status == v.Status)
                {
                    visitToDelete = v; //cant delete from a list while itterating over it
                }
            }
            if (visitToDelete != null)
            {
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created getAllVisitsByName 
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public List<Visit> GetAllVisitsByName(string firstName, string lastName)
        {
            List<Visit> visits = new List<Visit>();

            foreach (Visit v in _visits)
            {
                if (v.FirstName.Equals(firstName) && v.LastName.Equals(lastName))
                {
                    visits.Add(v);
                }
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
        /// Last Updated By: Matthew Baccam
        /// Last Updated 02/28/2024
        /// What was changed: Fixed the visits to have a datetime object instead of just a time thats a string
        /// </summary>
        public int RescheduleVisit(int visitID, DateTime checkIn, DateTime checkOut)
        {
            int result = 0;
            foreach (Visit v in _visits)
            {
                if (v.VisitID == visitID)
                {
                    v.CheckIn = checkIn;
                    v.CheckOut = checkOut;
                    result = 1;
                }
            }
            return result;
        }

        //<Summary>
        //Creator: Matthew Baccam
        //Created: 02/08/2024
        //Summary: Initial Creation
        //Last Updated By: Matthew Baccam
        //Last Updated: 02/08/2024
        //What Was Changed: Initial Creation
        //<Summary>
        public int VisitCount(DateTime searchDate)
        {
            return _visits.Where(v => v.CheckIn.Date == searchDate.Date).Count();
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool UpdateVisitForCheckInByVisitID(int visitID, DateTime oldCheckIn)
        {
            var test = _visits.Where(x => x.VisitID == visitID && x.CheckIn == oldCheckIn);
            return test.Count() == 1;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool UpdateVisitForCheckOutByVisitID(int visitID, DateTime oldCheckOut)
        {
            var test = _visits.Where(x => x.VisitID == visitID && x.CheckOut == oldCheckOut);
            return test.Count() == 1;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public List<Visit> SelectVisitWithFromTo(DateTime from, DateTime to)
        {
            var list = new List<Visit>();
            _visits.ForEach(v =>
            {
                if (v.CheckIn.Date >= from.Date && v.CheckIn.Date <= to.Date)
                {
                    list.Add(v);
                }
            });
            return list;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public Visit SelectVisitByVisitID(int visitID)
        {
            return _visits.First(v => v.VisitID == visitID);
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 04/17/2024
        /// Summary: Created getAllVisits
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 04/17/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public List<Visit> GetAllVisits()
        {
            List<Visit> visits = new List<Visit>();

            foreach (Visit v in _visits)
            {
                visits.Add(v);
            }

            return visits;
        }
    }
}
