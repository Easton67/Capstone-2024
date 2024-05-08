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
    /// Creator:            Ethan McElree
    /// Created:            03/25/2024
    /// Summary:            Creation of the Location manager class
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       03/25/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    public class LocationManager : ILocationManager
    {
        ILocationAccessor _locationAccessor;
        public LocationManager()
        {
            _locationAccessor = new LocationAccessor();
        }
        public LocationManager(ILocationAccessor locationAccessor)
        {
            _locationAccessor = locationAccessor;
        }
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            03/25/2024
        /// Summary:            Manager interface method for getting all locations
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/25/2024
        /// What Was Changed:   Inital creation
        /// </summary>
        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();
            try
            {
                locations = _locationAccessor.GetLocations();
                return locations;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error while trying to get locations.", ex);
            }
        }
    }
}
