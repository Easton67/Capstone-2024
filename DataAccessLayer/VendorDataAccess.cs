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
    ///Creator:            Mitchell Stirmel
    ///Created:            02/13/2024
    ///Summary:            This contains all methods for vendor data accessing.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VendorDataAccess : IVendorDataAccess
    {
        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            This adds a vendor into the database.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool AddVendor(Vendor vendor)
        {
            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_vendor");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConn;

            cmd.Parameters.Add("@VendorName", SqlDbType.NVarChar);
            cmd.Parameters.Add("@VendorAddress", SqlDbType.NVarChar);
            cmd.Parameters.Add("@VendorEmail", SqlDbType.NVarChar);
            cmd.Parameters.Add("@VendorContactPhone", SqlDbType.NVarChar);
            cmd.Parameters.Add("@VendorContactName", SqlDbType.NVarChar);

            cmd.Parameters["@VendorName"].Value = vendor.Name;
            cmd.Parameters["@VendorAddress"].Value = vendor.Address;
            cmd.Parameters["@VendorEmail"].Value = vendor.Email;
            cmd.Parameters["@VendorContactPhone"].Value = vendor.PhoneNumber;
            cmd.Parameters["@VendorContactName"].Value = vendor.ContactName;

            try
            {
                sqlConn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally { sqlConn.Close(); }
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/27/2024
        /// Summary:            Retrieves the supplier and its information.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Vendor> RetrieveSupplier(string supplierName)
        {
            List<Vendor> suppliers = new List<Vendor>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_retrieve_supplier";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar, 100).Value = supplierName;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Vendor vendor = new Vendor();
                        vendor.Name = reader.GetString(0);
                        vendor.ContactName = reader.GetString(1);
                        vendor.Address = reader.GetString(2);
                        vendor.PhoneNumber = reader.GetString(3);
                        vendor.Email = reader.GetString(4);
                        suppliers.Add(vendor);
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

            return suppliers;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/27/2024
        /// Summary:            Updates the supplier.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public void UpdateSupplierInformation(string supplierName, string newSupplierAddress, string newSupplierEmail, string newSupplierContactPhone, string newSupplierContactName)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_update_supplier";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar, 100).Value = supplierName;
            cmd.Parameters.Add("@NewSupplierAddress", SqlDbType.NVarChar, 100).Value = newSupplierAddress;
            cmd.Parameters.Add("@NewSupplierEmail", SqlDbType.NVarChar, 255).Value = newSupplierEmail;
            cmd.Parameters.Add("@NewSupplierContactPhone", SqlDbType.NVarChar, 11).Value = newSupplierContactPhone;
            cmd.Parameters.Add("@NewSupplierContactName", SqlDbType.NVarChar, 50).Value = newSupplierContactName;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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
        /// Creator:            Ethan McElree
        /// Created:            03/01/2024
        /// Summary:            Gets supplier names
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> getSupplierNames()
        {
            List<string> supplierNames = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_supplier_names";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string supplierName = reader.GetString(0);
                    supplierNames.Add(supplierName);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return supplierNames;
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/07/2024
        /// Summary: Retrieves a list of all vendors from the database by executing the stored procedure 
        /// "sp_select_all_vendors". The method maps the retrieved data to Vendor objects and returns a list of vendors.
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Vendor> SelectAllVendors()
        {
            List<Vendor> vendors = new List<Vendor>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_vendors";
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
                        vendors.Add(new Vendor()
                        {
                            VendorId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Email = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            ContactName = reader.GetString(5),
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Vendors not found");
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
            return vendors;
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/04/2024
        /// Summary: Deletes a vendor and all associated references to the vendor in the database given the vendor's ID.
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool DeleteVendor(int vendorId)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_delete_vendor_by_vendorid";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = vendorId;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteNonQuery();
                if (reader != 0)
                {
                    return true;
                }
                return false;
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
    }
}
