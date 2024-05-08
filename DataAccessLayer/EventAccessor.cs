using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace DataAccessLayer
{
    public class EventAccessor : IEventAccessor
    {

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/16/2024
        /// Summary: Create CreateEvent Method to implement the add_volunteer_event_field stored procedure to project  
        /// Creator: Liam Easton
        /// Created: 4/18/2024
        /// Summary: Added the if rows == 0 check to catch if the event isn't created by the sp
        /// </summary>
        public int CreateEvent(Event eventParameter)
        {
            int rows = 0;
            SqlConnection conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_Create_Event", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventName", eventParameter.EventName);
            cmd.Parameters.AddWithValue("@Description", eventParameter.Description);
            cmd.Parameters.AddWithValue("@VolunteersNeeded", eventParameter.VolunteersNeeded);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Unable to create event");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Create CreateVolunteerEvent Method to implement the add_volunteer_event_field stored procedure to project
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/07/2024
        /// What Was Changed:   Changed to an update 
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Changed name of sp from Add_Volunteer_Event to sp_add_volunteer_event to look more uniform
        /// </summary>
        public int CreateVolunteerEvent(int eventID, int oldVolunteersNeeded, int newVolunteersNeeded)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_add_volunteer_event";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters.Add("@NewVolunteersNeeded", SqlDbType.Int);
            cmd.Parameters.Add("@OldVolunteersNeeded", SqlDbType.Int);

            cmd.Parameters["@EventID"].Value = eventID;
            cmd.Parameters["@NewVolunteersNeeded"].Value = newVolunteersNeeded;
            cmd.Parameters["@OldVolunteersNeeded"].Value = oldVolunteersNeeded;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Fields not updated");
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
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create of eventParticipants() Method.
        /// </summary>
        public List<string> eventParticipants(int EventID)
        {
            List<string> participants = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_event_participants";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = EventID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    participants.Add(reader.GetString(0));
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
            return participants;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create of eventVolunteers() Method .
        /// </summary>
        public List<string> eventVolunteers(int EventID)
        {
            List<string> volunteers = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_event_volunteers";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = EventID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Fname = reader.GetString(0);
                        string Lname = reader.GetString(1);
                        string volunteerID = reader.GetString(2);
                        volunteers.Add(Fname + " " + Lname);
                    }
                }
                else
                {
                    throw new ArgumentException("Events not found");
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
            return volunteers;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetAllEventRequests() Method .
        /// </summary>
        public List<EventRequestVM> GetAllEventRequests()
        {
            return null;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create getAllEvents() Method .
        /// </summary>
        public List<EventVM> getAllEvents()
        {
            List<EventVM> events = new List<EventVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_Select_Event_VM";
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
                        events.Add(new EventVM()
                        {
                            EventID = reader.GetInt32(0),
                            EventName = reader.GetString(1),
                            Description = reader.GetString(2),
                            VolunteersNeeded = reader.GetInt32(3),
                            StartTime = reader.GetDateTime(4),
                            EndTime = reader.GetDateTime(5),
                            EventDay = reader.GetDateTime(6),
                            Address = reader.GetString(7),
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Events not found");
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
            return events;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetClientIDs() Method .
        /// </summary>
        public List<string> GetClientIDs()
        {
            List<string> clientIDs = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_Client_IDs";
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
                        clientIDs.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Events not found");
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
            return clientIDs;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create GetEventTypeIDs() Method .
        /// </summary>
        public List<string> GetEventTypeIDs()
        {
            List<string> eventTypeIDs = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_EventType_IDs";
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
                        eventTypeIDs.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Events not found");
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
            return eventTypeIDs;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/05/2024
        /// Summary: Create InsertEventRequest() Method .
        /// </summary>
        public void InsertEventRequest(EventRequestVM eventRequestVM)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_insert_event_request";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ClientID", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@EventTypeID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Information", SqlDbType.Text);
            cmd.Parameters["@ClientID"].Value = eventRequestVM.ClientID;
            cmd.Parameters["@EventTypeID"].Value = eventRequestVM.EventTypeID;
            cmd.Parameters["@Information"].Value = eventRequestVM.Information;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Removes an existing volunteer from a specified event.
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        public int RemoveVolunteerFromEvent(string volunteerID, int eventID)
        {
            int rows = 0;
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_Remove_VolunteerFromEvents";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@EventID", SqlDbType.Int);

            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@EventID"].Value = eventID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new ArgumentException("No rows affected. Volunteer not removed.");
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
        /// Created: 03/19/2024
        /// Summary: Gets a list of Volunteer objects based off of a specific eventID
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<Volunteer> GetEventVolunteerDetails(int EventID)
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_event_volunteers";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = EventID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Volunteer volunteer = new Volunteer
                        {
                            FirstName = reader.GetString(0),
                            LastName = reader.GetString(1),
                            UserID = reader.GetString(2),
                        };
                        volunteers.Add(volunteer);
                    }
                }
                else
                {
                    throw new ArgumentException("Events not found");
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
            return volunteers;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            Create SelectAllEvents() Method to implement the sp_Select_All_Volunteer_Events stored procedure to project
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       01/23/2024
        /// What Was Changed:   Initial creation  
        /// </summary>
        public List<Event> SelectAllEvents()
        {
            List<Event> events = new List<Event>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_Select_All_Volunteer_Events";
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
                        events.Add(new Event()
                        {
                            EventID = reader.GetInt32(0),
                            EventName = reader.GetString(1),
                            Description = reader.GetString(2),
                            VolunteersNeeded = reader.GetInt32(3)

                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Events not found");
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
            return events;
        }

        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            02/22/2024
        /// Summary:            Create CreateEvent participant Method
        /// </summary>
        public int CreateEventParticipants(EventParticipant eventParticipants)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_create_EventParticipants";
            var cmd = new SqlCommand(@cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventParticipants.EventID);
            cmd.Parameters.AddWithValue("@ParticipantName", eventParticipants.ParticipantName);
            cmd.Parameters.AddWithValue("@Email", eventParticipants.Email);
            cmd.Parameters.AddWithValue("@RegistrationDate", eventParticipants.RegistrationDate);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
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
        /// Creator: Marwa Ibrahim
        /// Created: 01/23/2024
        /// Summary: UpdateEvent
        /// </summary>
        public bool UpdateEvent(Event newEvent)
        {
            bool result = false;

            SqlConnection conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_Update_Event", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", newEvent.EventID);
            cmd.Parameters.AddWithValue("@EventName", newEvent.EventName);
            cmd.Parameters.AddWithValue("@Description", newEvent.Description);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        /// <summary>
        /// Created By: Liam Easton
        /// Created On: 4/18/2024
        /// Summary: creation of the SelectEventByEventID method
        /// </summary>
        public Event SelectEventByEventID(int eventID)
        {
            Event currentEvent = new Event();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_event_by_EventID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = eventID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    currentEvent.EventID = reader.GetInt32(0);
                    currentEvent.EventName = reader.GetString(1);
                    currentEvent.Description = reader.GetString(2);
                    currentEvent.VolunteersNeeded = reader.GetInt32(3);
                }
                else
                {
                    throw new ArgumentException("Song not found");
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
            return currentEvent;
        }

        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            02/27/2024
        /// Summary:            Delete Event
        /// </summary>
        public bool DeleteEvent(EventVM @event)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_Delete_Event";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = @event.EventID;
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }

            return result;
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/18/2024
        /// Summary: CancelEventSignUP
        /// </summary>
        /// 
        public bool CancelSignUp(string participantName, int eventID)
        {
            bool result = false;
            SqlConnection conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_Cancel_Event_Signup", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventID);
            cmd.Parameters.AddWithValue("@ParticipantName", participantName);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        ///</summary>
        ///Creator:            Matthew Baccam
        ///Created:            04/26/2024
        ///Summary:            Created SelectEventVMByID
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/26/2024
        ///What Was Changed:   Initial creation
        ///</summary>
        public EventVM SelectEventVMByID(int eventID)
        {
            var eventVM = new EventVM();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_eventVM_by_ID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventVM.EventID = reader.GetInt32(0);
                        eventVM.EventName = reader.GetString(1);
                        eventVM.Description = reader.GetString(2);
                        eventVM.VolunteersNeeded = reader.GetInt32(3);
                        eventVM.StartTime = reader.GetDateTime(4);
                        eventVM.EndTime = reader.GetDateTime(5);
                        eventVM.EventDay = reader.GetDateTime(6);
                        eventVM.Address = reader.GetString(7);
                    }
                }
                else
                {
                    throw new ArgumentException("Event not found");
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
            return eventVM;
        }
    }
}
