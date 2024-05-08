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
    /// Summary:            Creation of the Location manager interface
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       03/25/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    public interface ILocationManager
    {
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            03/25/2024
        /// Summary:            Manager interface method for getting all locations
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/25/2024
        /// What Was Changed:   Inital creation
        /// </summary>
        List<Location> GetLocations();
    }
}
