using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Marwa Ibrahim
    /// Created: 02/15/2024
    /// Summary: Reminder Accessor class  implements IReminderAccessor interface
    /// Last Updated By: Marwa Ibrahim
    /// Last Updated: 3/6/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ReminderAccessor : IReminderAccessor
    {
        public bool insertReminder(Reminder reminder)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();

            var commandText = "sp_insert_reminder";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@EmailTo", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@EmailFrom", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Message", SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@Frequency", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@Date", SqlDbType.Date);
            cmd.Parameters.Add("@Read", SqlDbType.Bit);
            cmd.Parameters.Add("@Deactivate", SqlDbType.Bit);
         
            cmd.Parameters["@EmailTo"].Value = reminder.EmailTo;
            cmd.Parameters["@EmailFrom"].Value = reminder.EmailFrom;
            cmd.Parameters["@Title"].Value = reminder.Title;
            cmd.Parameters["@Message"].Value = reminder.Message;
            cmd.Parameters["@Frequency"].Value = reminder.Frequency;
            cmd.Parameters["@Date"].Value = reminder.Date;
            cmd.Parameters["@Read"].Value = reminder.Read;
            cmd.Parameters["@Deactivate"].Value = reminder.Deactivate;
         
            try
            {
           conn.Open();
             result =    cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {conn.Close() ;}


            return result;
        }
    }
}
