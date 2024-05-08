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
    ///Creator:   Abdalgader Ibrahim
    ///Created:   02/06/2024
    ///Summary:   Donation Accessor class that implements IDonationAccessor interface
    ///Last Updated By:  Abdalgader Ibrahim  
    ///Last Updated:     02/12/2024
    ///What Was Changed:  Initial Creation 
    /// </summary>
    public class DonationAccessor : IDonationsAccessor
    {
        public DonationAccessor() { }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/06/2024
        /// Summary: The GetDonations() method will run the stored procedure
        ///          sp_donations_select_all & will submit the changes to the database. 
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation 
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/24/2024
        /// What Was Changed: changed how the amount is gotten to allow for 
        ///                   different donation types
        /// </summary>
        public List<Donation> GetDonations()
        {
            List<Donation> donations = new List<Donation>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_donations_select_all";
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
                        Donation donation = new Donation();
                        donation.DonationID = reader.GetInt32(0);
                        donation.DonationTypeID = reader.GetInt32(1);
                        donation.DonatorID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        donation.DonationName = reader.GetString(3);
                        string originalAmount = reader.GetString(4);
                        bool hasNumber = int.TryParse(originalAmount, out _);
                        donation.Amount = hasNumber ? "$" + originalAmount : originalAmount;
                        // donation.Amount = reader.GetString(4).StartsWith("$") ? reader.GetString(4) : "$" + reader.GetString(4);
                        donation.DonationDate = reader.GetDateTime(5);
                        donation.Active = reader.GetBoolean(6);
                        donations.Add(donation);
                    }
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
            return donations;
        
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/06/2024
        /// Summary: The GetDonations() method will run the stored procedure
        ///          sp_donations_select_all & will submit the changes to the database. 
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<DonationType> GetDonationsType()
        {
            List<DonationType> donationTypes = new List<DonationType>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_donationtype_select_all";
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
                        DonationType donationType = new DonationType();
                        donationType.DonationTypeID = reader.GetInt32(0);
                        donationType.TypeName = reader.GetString(1);
                        donationTypes.Add(donationType);
                    }
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
            return donationTypes;

        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/06/2024
        /// Summary: The GetDonators() method will run the stored procedure
        ///          sp_donators_select_all & will submit the changes to the database. 
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Donator> GetDonators()
        {
            List<Donator> donators = new List<Donator>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_donators_select_all";
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
                        Donator donator = new Donator();
                        donator.DonatorID = reader.GetInt32(0);
                        donator.FamilyName = reader.GetString(1);
                        donator.PhoneNumber = reader.GetString(2);
                        donator.Email = reader.GetString(3);
                        donator.Address = reader.GetString(4);
                        donators.Add(donator);
                    }
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
            return donators;

        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/06/2024
        /// Summary: The UpdateDonation() method will run the stored procedure
        ///          sp_Update_donations & will submit the changes to the database. 
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public Donation UpdateDonation(Donation donation)
        {
            int rows = 0;
 
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_Update_donations";
            var cmd = new SqlCommand(@cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DonationID", donation.DonationID);
            cmd.Parameters.AddWithValue("@DonationTypeID", donation.DonationTypeID);
            cmd.Parameters.AddWithValue("@DonatorID", donation.DonatorID);
            cmd.Parameters.AddWithValue("@DonationName", donation.DonationName);
            cmd.Parameters.AddWithValue("@Amount", donation.Amount);
            cmd.Parameters.AddWithValue("@DonationsDate", donation.DonationDate);
            cmd.Parameters.AddWithValue("@Active", donation.Active);

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
            if(rows != 0) 
            {
                return donation;
            }else { return null; }
            
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 04/23/2024
        /// Summary: Create Donations
        /// </summary>
        public int CreateDonation(Donation donation)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_create_donation";
            var cmd = new SqlCommand(@cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DonationTypeID", donation.DonationTypeID);
            cmd.Parameters.AddWithValue("@DonationName", donation.DonationName);
            cmd.Parameters.AddWithValue("@Amount", donation.Amount);
            cmd.Parameters.AddWithValue("@DonationsDate", donation.DonationDate);
            cmd.Parameters.AddWithValue("@Active", donation.Active);

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
    }
}
