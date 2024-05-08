using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TransportationOrderManager : ITransportationOrderManager
    {
        private ITransportationOrderAccessor _transportationOrderAccessor = null;
       

        public TransportationOrderManager()
        {
            _transportationOrderAccessor = new TransportationOrderAccessor();
        }
        public TransportationOrderManager(ITransportationOrderAccessor transportationOrderAccessor)
        {
            _transportationOrderAccessor = transportationOrderAccessor;
        } 
		
		/// <summary>
		/// Creator:           Miyada Abas
		/// Created:            04/11/2024
		/// Summary:            Initial creation of the DeleteTransportationOrders method.
		/// Last Updated By:    Miyada Abas
		/// Last Updated:       04/011/2024
		/// What Was Changed:   Initial creation of the DeleteTransportationOrders method.
		/// </summary>
        public bool deleteOrder(TransportationOrderVM transportation)
        {
            bool result = false;
			
			try
            {
                result = _transportationOrderAccessor.DeleteOrder(transportation);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not Create order", ex);
            }
            
            return result;
        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the CreateTransportOrder method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the CreateTransportOrder method.
        /// </summary>
        public int CreateTransportOrder(TransportationOrder order)
        {
            int rows = 0;

            try
            {
                rows = _transportationOrderAccessor.CreateTransportOrder(order);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not Create order", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the DeleteTransportOrder method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the DeleteTransportOrder method.
        /// </summary>
        public int DeleteTransportOrder(int orderID)
        {
            int rows = 0;

            try
            {
                rows = _transportationOrderAccessor.DeleteTransportOrder(orderID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not Delete order", ex);
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the ViewAllTransportationOrders method.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the ViewAllTransportationOrders method.
        /// </summary>
        public List<TransportationOrderVM> ViewAllTransportationOrders()
        {
            List<TransportationOrderVM> orders = new List<TransportationOrderVM>();

            try
            {
                orders = _transportationOrderAccessor.ViewAllTransportationOrders();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occured finding the orders from the database", ex);
            }

            return orders;
        }

		/// <summary>
		/// Creator:           Miyada Abas
		/// Created:            04/11/2024
		/// Summary:            Initial creation of the DeleteTransportationOrders method.
		/// Last Updated By:    Miyada Abas
		/// Last Updated:       04/011/2024
		/// What Was Changed:   Initial creation of the DeleteTransportationOrders method.
		/// </summary>
        public List<Item> GetAllItemes()
        {
            List<Item> items = new List<Item>();
			
			try
			{
				items = _transportationOrderAccessor.selectAllItems();
			}
			catch(Exception ex)
			{
				throw new ApplicationException("An error occured finding the orders from the database", ex);
			}
            return items;
        }


        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the ViewTransportationOrdersByDriver method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the ViewTransportationOrdersByDriver method.
        /// </summary>
        public List<TransportationOrder> ViewTransportationOrdersByDriver(string driverID)
        {
            List<TransportationOrder> orders = new List<TransportationOrder>();

            try
            {
                orders = _transportationOrderAccessor.ViewTransportationOrderByDriver(driverID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occured finding the orders from the database", ex);
            }

            return orders;
        }
    }
}
