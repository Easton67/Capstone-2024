using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Mitchell Stirmel
    /// Created: 01/26/2024
    /// Summary: Created a database class with a connection string object.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Added GetConnection() method
    /// Last Updated By: Andrew Larson
    /// Last Updated: 01/29/2024
    /// What Was Changed: Added the GetConnection Method and change the _connectionString to the appropriate string.
    /// Last Updated By: Tyler Barz
    /// Last Updated: 02/14/2024
    /// What Was Changed: Added NewCommand to save from creating a new command eachtime
    /// </summary>
    public static class DatabaseConnection
    {
        private static string _connectionString = @"Data Source=E67\SQLEXPRESS;Initial Catalog=masterhomelessdb;Integrated Security=True";


        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Created GetConnection method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       01/23/2024
        /// What Was Changed:   Initial creation  
        /// </summary>
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            NewCommand Method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial creation  
        /// </summary>
        public static SqlCommand NewCommand(string text, SqlConnection connection, CommandType type)
        {
            SqlCommand command = new SqlCommand(text, connection);
            command.CommandType = type;
            return command;
        }
    }
}
