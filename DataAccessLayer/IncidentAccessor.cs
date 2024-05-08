using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public class IncidentAccessor : IIncidentAccessor
    {
        /// <Summary>
        /// Creator: Darryl Shirley
        /// created: 02/21/2024
        /// Summary: Create CreateIncidentReport Method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02-21-2024
        /// What was changed/updated: Initial Creation
        /// </Summary>
        public int createIncidentReport(string description, string reported, string reportedBy, int severity)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_Add_Incident_Report";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 1000);
            cmd.Parameters.Add("@Reported", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ReportedBy", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Severity", SqlDbType.Int);

            cmd.Parameters["@Description"].Value = description;
            cmd.Parameters["@Reported"].Value = reported;
            cmd.Parameters["@ReportedBy"].Value = reportedBy;
            cmd.Parameters["@Severity"].Value = severity;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new ArgumentException("Incident Report not created");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/03/2024
        /// Summary: accessor for GetCurrentUserIncidents
        /// Last Updated By: Andrew Larson
        /// Last Updated: 03/03/2024
        /// What Was Changed: accessor for GetCurrentUserIncidents
        /// </summary>
        public List<Incident> GetCurrentUserIncidents(string reportedBy)
        {
            List<Incident> incidents = new List<Incident>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_all_submitted_incident_reports";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@employeeID", SqlDbType.NVarChar, 100);
            cmd.Parameters["@employeeID"].Value = reportedBy;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    var incident = new Incident()
                    {
                        incidentID = reader.GetInt32(0),
                        description = reader.GetString(1),
                        incidentStatus = reader.GetString(2),
                        reported = reader.GetString(3),
                        reportedBy = reader.GetString(4),
                        feedBack = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        severity = reader.GetInt32(6),
                    };
                    incidents.Add(incident);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                conn.Close();
            }
            return incidents;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/25/2024
        /// Summary: accessor for SelectAllIncidents
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/25/2024
        /// What Was Changed: accessor for SelectAllIncidents
        /// </summary>
        public List<Incident> SelectAllIncidents()
        {
            List<Incident> incidents = new List<Incident>();

            var conn = DatabaseConnection.GetConnection();

            var commandText = "sp_select_all_incident_reports";

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var incident = new Incident()
                    {
                        incidentID = reader.GetInt32(0),
                        description = reader.GetString(1),
                        incidentStatus = reader.GetString(2),
                        reported = reader.GetString(3),
                        reportedBy = reader.GetString(4),
                        feedBack = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        severity = reader.GetInt32(6),
                    };
                    incidents.Add(incident);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return incidents;
        }
    }
}
