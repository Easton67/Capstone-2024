using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Liam Easton
    /// Created:            04/03/2024
    /// Summary:            Initial creation of the TransportationOrder Accessor.
    /// Last Updated By:    Liam Easton
    /// Last Updated:       04/03/2024
    /// What Was Changed:   Initial creation of the TransportationOrder Accessor.
    /// </summary>
    public class TransportationOrderAccessor : ITransportationOrderAccessor
    {
        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the CreateTransportOrder Accessor Method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the CreateTransportOrder Accessor Method.
        /// </summary>
        public int CreateTransportOrder(TransportationOrder order)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_create_transportation_order";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientID", order.ClientID);
            cmd.Parameters.AddWithValue("@LocationID", order.LocationID);
            cmd.Parameters.AddWithValue("@DayPosted", order.DayPosted);
            cmd.Parameters.AddWithValue("@DayToPickUp", order.DayToPickUp);
            cmd.Parameters.AddWithValue("@DayDroppedOff", order.DayDroppedOff);
            cmd.Parameters.AddWithValue("@AssignedDriver", order.AssignedDriver);
            cmd.Parameters.AddWithValue("@Fulfilled", order.Fulfilled); ;


            try
            {
                connection.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Invalid Inputs");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
            return rows;
        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the DeleteTransportOrder Accessor Method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the DeleteTransportOrder Accessor Method.
        /// </summary>
        public int DeleteTransportOrder(int orderID)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_delete_transportation_order";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderID);


            try
            {
                connection.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Invalid Inputs");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { connection.Close(); }
            return rows;
        }

        public List<TransportationOrderVM> ViewAllTransportationOrders()
        {
            List<TransportationOrderVM> orders = new List<TransportationOrderVM>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_view_all_transportation_orders";
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
                            LocationName = reader.GetString(8),
                            Address = reader.GetString(9),
                            City = reader.GetString(10),
                            State = reader.GetString(11),
                            ZipCode = reader.GetInt32(12)
                        };

                        TransportationOrderVM order = new TransportationOrderVM()
                        {
                            DayPosted = reader.GetDateTime(0).Date,
                            DayToPickUp = reader.GetDateTime(1).Date,
                            DayDroppedOff = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2).Date,
                            AssignedDriver = reader.GetString(3),
                            Fulfilled = reader.GetBoolean(4),
                            LineItemAmount = reader.GetDecimal(5),
                            Vendor = reader.GetString(6),
                            TransportItem = reader.GetString(7),
                            Location = location.Address + ", " +
                                       location.City + ", " +
                                       location.State + ", " +
                                       location.ZipCode,

                            // Show only the city until you are assigned so you don't get full address
                            city = location.City
                        };

                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return orders;
        }

        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            04/20/2024
        /// Summary:            Initial creation of the SectAllItemsAccessor.
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/20/2024
        /// What Was Changed:   Initial creation of the SectAllItems Accessor.
        /// </summary>
        public List<Item> selectAllItems()
        {
            List<Item> items = new List<Item>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_all_items";
            var cmd = new SqlCommand(commandText, conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Item item = new Item();
                        item.ItemID = reader.GetInt32(0);
                        item.ItemName = reader.GetString(1);
                        item.ItemDescription = reader.GetString(2);
                        item.QtyOnHand = reader.GetInt32(3);
                        item.NormalStockQty = reader.GetInt32(4);
                        item.ReorderPoint = reader.GetInt32(5);
                        item.OnOrder = reader.GetInt32(6);
                        items.Add(item);
                    }
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
            return items;
        }

        /// <summary>
        /// Creator:        Miyada Abas
        /// Created:            04/11/2024
        /// Summary:            Initial creation of the DeleteTransportationOrder Accessor.
        /// Last Updated By:   Miyada Abas
        /// Last Updated:       04/11/2024
        /// What Was Changed:   Initial creation of the DeleteTransportationOrder Accessor.
        /// </summary>
        public bool DeleteOrder(TransportationOrderVM transportation)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_delete_transportation_orders";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LineItemAmount", transportation.LineItemAmount);
            // cmd.Parameters.AddWithValue("@TransportLineID", transportation.TransportLineID);
            cmd.Parameters.AddWithValue("@Vendor", transportation.Vendor);
            cmd.Parameters.AddWithValue("@TransportItem", transportation.TransportItem);
            // cmd.Parameters.AddWithValue("@Location", transportation.Location);
            //cmd.Parameters.AddWithValue("@city", transportation.city);
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
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the ViewTranportationOrdersByDriver Accessor Method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the ViewTranportationOrdersByDriver Accessor Method.
        /// </summary>

        public List<TransportationOrder> ViewTransportationOrderByDriver(string driverID)
        {
            List<TransportationOrder> orders = new List<TransportationOrder>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_view_orders_by_driver";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AssignedDriver", SqlDbType.NVarChar, 100);
            cmd.Parameters["@AssignedDriver"].Value = driverID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var order = new TransportationOrder()
                        {
                            TransportItemID = reader.GetInt32(0),
                            ClientID = reader.GetString(1),
                            LocationID = reader.GetInt32(2),
                            DayPosted = reader.GetDateTime(3),
                            DayToPickUp = reader.GetDateTime(4),
                            DayDroppedOff = reader.GetDateTime(5),
                            AssignedDriver = reader.GetString(6),
                            Fulfilled = reader.GetBoolean(7)
                        };
                        orders.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return orders;
        }
    }
}
