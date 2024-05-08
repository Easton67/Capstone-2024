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
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: HoursOfOperationManager extends IHoursOfOperations and
    /// is responsible for all methods regarding the 
    /// HoursOfOpertaion object.
    /// Last Updated By: Andrew Larson
    /// Last Updated 01/31/2024
    /// What was changed: Changed default constructor because it
    /// was incorrect.
    /// </summary>
    public class HoursOfOperationManager : IHoursOfOperationManager
    {
        private IHoursOfOperationAccessor _hoursOfOperationAccessor = null;

        public HoursOfOperationManager()
        { 
            _hoursOfOperationAccessor= new HoursOfOperationAccessor();
        }

        public HoursOfOperationManager(IHoursOfOperationAccessor hoursOfOperationAccessor)
        { 
            _hoursOfOperationAccessor = hoursOfOperationAccessor;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/29/2024
        /// Summary: This method will retrieve all valid HoursOfOperation objects
        /// as a list, based on the users zipCode input.
        /// Last Updated By: Andrew Larson
        /// Last Updated 02/01/2024
        /// What was changed: Updated variable names to coding standards
        /// </summary>
        public List<Location> GetLocationsByZipCode(int zipCode)
        {
            List<HoursOfOperation> hoursOfOperationList = new List<HoursOfOperation>();
            try
            {
                hoursOfOperationList = _hoursOfOperationAccessor.SelectHoursOfOperation(zipCode);
                List<Location> locations = ChangeHoursOfOperationToLocations(hoursOfOperationList);
                return locations;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/29/2024
        /// Summary: This method will retrieve all valid HoursOfOperation objects
        /// as a list, based on the users zipCode input.
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Initialize empty list if nothing is found,
        /// so we don't crash but can still inform user of result
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<Location> ChangeHoursOfOperationToLocations(List<HoursOfOperation> hoursOfOperationList)
        {
            try
            {
                List<Location> locations = new List<Location>();

                foreach (var hoursOfOperation in hoursOfOperationList)
                {
                    Location location = hoursOfOperation.location;


                    if (location.HoursOfOperation == null) // initialize HoursOfOperation list if it's null.
                    {
                        location.HoursOfOperation = new List<HoursOfOperation>();
                    }

                    location.HoursOfOperation.Add(hoursOfOperation);

                    locations.Add(location);
                }

                return locations;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Not able to change hours of operation", ex);
            }

        }
    }
}
