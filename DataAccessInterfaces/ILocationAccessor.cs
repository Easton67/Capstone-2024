using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            03/25/2024
    /// Summary:            Creation of the Location accessor interface
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       03/25/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    public interface ILocationAccessor
    {
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            03/25/2024
        /// Summary:            Accessor interface method for getting all locations
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/25/2024
        /// What Was Changed:   Inital creation
        /// </summary>
        List<Location> GetLocations();
    }
}
