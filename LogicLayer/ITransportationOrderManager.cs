using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ITransportationOrderManager
    {
        List<Item> GetAllItemes();
        bool deleteOrder(TransportationOrderVM transportation);
        List<TransportationOrderVM> ViewAllTransportationOrders();

        List<TransportationOrder> ViewTransportationOrdersByDriver(string driverID);

        int DeleteTransportOrder(int orderID);

        int CreateTransportOrder(TransportationOrder order);
    }
}
