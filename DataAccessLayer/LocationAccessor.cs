using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            03/25/2024
    /// Summary:            Creation of the Location accessor class
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       03/25/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    public class LocationAccessor : ILocationAccessor
    {
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            03/25/2024
        /// Summary:            Method that gets all locations
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/25/2024
        /// What Was Changed:   Inital creation
        /// </summary>
        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_all_locations";
            var cmd = new SqlCommand(commandText, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Location location = new Location()
                        {
                            LocationID = reader.GetInt32(0),
                            LocationName = reader.GetString(1),
                            Address = reader.GetString(2),
                            City = reader.GetString(3),
                            State = reader.GetString(4),
                            ZipCode = reader.GetInt32(5)
                        };
                        locations.Add(location);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return locations;
        }
    }
}
