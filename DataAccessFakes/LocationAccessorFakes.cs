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
    /// Creator: Ethan McElree
    /// Created: 03/26/2024
    /// Summary: Accessor fakes file for the location class.
    /// Last Updated By: Ethan McElree
    /// Last Updated By: 03/26/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class LocationAccessorFakes : ILocationAccessor
    {
        private List<Location> _locations = null;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/26/2024
        /// Summary: Accessor fakes file for the location class.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public LocationAccessorFakes()
        {
            _locations = new List<Location>()
            {
                new Location()
                {
                    LocationID = 1,
                    LocationName = "FakeShelter",
                    Address = "111 Fake Ave",
                    City = "New Fake City",
                    State = "New Fake",
                    ZipCode = 22222,
                },
                new Location()
                {
                    LocationID = 2,
                    LocationName = "FictionalShelter",
                    Address = "222 Fake Ave",
                    City = "Las Fakes",
                    State = "Califake",
                    ZipCode = 33333,
                },
                new Location()
                {
                    LocationID = 3,
                    LocationName = "NotExistentShelter",
                    Address = "333 Fake Ave",
                    City = "Las Fakes2",
                    State = "Fakago",
                    ZipCode = 44444,
                },
            };
        }
        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/26/2024
        /// Summary: Accessor fake method for getting locations.
        /// Last Updated By: Ethan McElree
        /// Last Updated By: 03/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Location> GetLocations()
        {
            return _locations;
        }
    }
}
