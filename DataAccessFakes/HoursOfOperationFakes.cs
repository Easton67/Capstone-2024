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
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: The HoursOfOperationFakes class holds all the fake data
    /// for testing purposes.
    /// Last Updated By: Andrew Larson
    /// Last Updated 01/31/2024
    /// What was changed: Implemented SelectHoursOfOperation();
    /// </summary>
    public class HoursOfOperationFakes : IHoursOfOperationAccessor
    {
        // creating fake data for testing
        private List<HoursOfOperation> _fakeHoursOfOperation = new List<HoursOfOperation>();

        public HoursOfOperationFakes()
        {
            Location location1 = new Location
            {
                LocationID = 1,
                LocationName = "Location1",
                Address = "123 Test St",
                City = "City1",
                State = "State1",
                ZipCode = 12345
            };
            Location location2 = new Location
            {
                LocationID = 2,
                LocationName = "Location2",
                Address = "987 Fake Ct",
                City = "City2",
                State = "State2",
                ZipCode = 98765
            };

            _fakeHoursOfOperation.Add(new HoursOfOperation
            {
                HoursOfOperationID = 1,
                HoursOfOperationString = "8:00AM - 5:00PM",
                LocationID = 1,
                location = location1,
            });

            _fakeHoursOfOperation.Add(new HoursOfOperation
            {
                HoursOfOperationID = 2,
                HoursOfOperationString = "9:00AM - 6:00PM",
                LocationID = 2,
                location = location2
            });
        }


        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/31/2024
        /// Summary: This method will retrieve all valid HoursOfOperation objects
        /// as a list, based on the users zipCode input.
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<HoursOfOperation> SelectHoursOfOperation(int zipCode)
        {
            List<HoursOfOperation> filteredHours = new List<HoursOfOperation>();
            foreach (var hour in _fakeHoursOfOperation)
            {
                if (hour.location.ZipCode == zipCode)
                {
                    filteredHours.Add(hour);
                }
            }
            return filteredHours;
        }
    }
}
