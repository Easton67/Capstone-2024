using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: VolunteerSkillAccessor.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public class VolunteerSkillAccessor : IVolunteerSkillAccessor
    {
        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: deleteSkill method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public int deleteSkill(string volunteerID, int skillID)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();

            var commandText = "sp_delete_Volunteer_Skill";


            var cmd = new SqlCommand(commandText, conn);


            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SkillID", SqlDbType.Int);


            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@SkillID"].Value = skillID;



            try
            {

                conn.Open();


                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {

                    throw new ArgumentException("Volunteer Skill not deleted");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }

            return rows;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: insertSkill method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public int insertSkill(string volunteerID, int skillID)
        {
            int rows = 0;



            var conn = DatabaseConnection.GetConnection();


            var commandText = "sp_insert_Volunteer_Skill";


            var cmd = new SqlCommand(commandText, conn);


            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SkillID", SqlDbType.Int);


            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@SkillID"].Value = skillID;



            try
            {

                conn.Open();


                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {

                    throw new ArgumentException("Volunteer Skill not added");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }

            return rows;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: SelectAllSkillsAssigned method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<Skills> SelectAllSkillsAssigned(string volunteerID)
        {
            List<Skills> skills = new List<Skills>();


            var conn = DatabaseConnection.GetConnection();



            var cmdText = "sp_select_volunteer_skills_by_volunteer_ID";


            var cmd = new SqlCommand(cmdText, conn);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);

            cmd.Parameters["@VolunteerID"].Value = volunteerID;


            try
            {

                conn.Open();


                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        skills.Add(new Skills()
                        {
                            SkillID = reader.GetInt32(0),
                            SkillName = reader.GetString(1)
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("No extra Skills to be removed.");
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



            return skills;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: SelectAllSkillsNotAssigned method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<Skills> SelectAllSkillsNotAssigned(string volunteerID)
        {
            List<Skills> skills = new List<Skills>();


            var conn = DatabaseConnection.GetConnection();



            var cmdText = "sp_select_all_Volunteer_Skills_not_assigned";


            var cmd = new SqlCommand(cmdText, conn);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);

            cmd.Parameters["@VolunteerID"].Value = volunteerID;



            try
            {

                conn.Open();


                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        skills.Add(new Skills()
                        {
                            SkillID = reader.GetInt32(0),
                            SkillName = reader.GetString(1),
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("No extra skills to be added.");
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



            return skills;
        }
    }
}
