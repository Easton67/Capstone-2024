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
    public class VolunteerQuestionnaireAccessor : IVolunteerQuestionnaireAccessor
    {
        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: createVolunteerQuestionnaire method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public int createVolunteerQuestionnaire(string volunteerID, string skillList, string vehicles, bool priorExperience, bool studentCheck, string schoolName, bool groupWork)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();



            var cmdText = "sp_create_volunteer_questionnaire";


            var cmd = new SqlCommand(cmdText, conn);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SkillList", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Vehicles", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PriorExperience", SqlDbType.Bit);
            cmd.Parameters.Add("@StudentCheck", SqlDbType.Bit);
            cmd.Parameters.Add("@SchoolName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GroupWork", SqlDbType.Bit);

            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@SkillList"].Value = skillList;
            cmd.Parameters["@Vehicles"].Value = vehicles;
            cmd.Parameters["@PriorExperience"].Value = priorExperience;
            cmd.Parameters["@StudentCheck"].Value = studentCheck;
            cmd.Parameters["@SchoolName"].Value = schoolName;
            cmd.Parameters["@GroupWork"].Value = groupWork;


            try
            {

                conn.Open();


                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {

                    throw new ArgumentException("Volunteer Questionnaire was not created");
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
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: SelectAllVolunteerQuestionnaires method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<VolunteerQuestionnaire> SelectAllVolunteerQuestionnaires()
        {
            List<VolunteerQuestionnaire> volunteerQuestionnaires = new List<VolunteerQuestionnaire>();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_all_volunteer_questionnaires";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {

                conn.Open();


                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        volunteerQuestionnaires.Add(new VolunteerQuestionnaire()
                        {
                            QuestionnaireID = reader.GetInt32(0),
                            volunteerID = reader.GetString(1),
                            skillList = reader.GetString(2),
                            Vehicles = reader.GetString(3),
                            PriorExperience = reader.GetBoolean(4),
                            StudentCheck = reader.GetBoolean(5),
                            SchoolName = reader.GetString(6),
                            GroupWork = reader.GetBoolean(7)
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("List of Volunteer Questionnaires not found.");
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

            return volunteerQuestionnaires;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: SelectVolunteerQuestionnaireByID method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public VolunteerQuestionnaire SelectVolunteerQuestionnaireByID(string volunteerID)
        {
            VolunteerQuestionnaire volunteerQuestionnaire = null;

            var conn = DatabaseConnection.GetConnection();


            var cmdText = "sp_get_volunteer_questionnaire_by_volunteer_ID";


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
                        volunteerQuestionnaire = new VolunteerQuestionnaire()
                        {
                            QuestionnaireID = reader.GetInt32(0),
                            volunteerID= reader.GetString(1),
                            skillList = reader.GetString(2),
                            Vehicles = reader.GetString(3),
                            PriorExperience = reader.GetBoolean(4),
                            StudentCheck = reader.GetBoolean(5),
                            SchoolName = reader.GetString(6),
                            GroupWork = reader.GetBoolean(7),
                            DateApplied = reader.GetDateTime(8)
                        };
                    }
                }
                else
                {
                    throw new ArgumentException("No Volunteer Questionnaires found.");
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

            return volunteerQuestionnaire;
        }
    }
}
