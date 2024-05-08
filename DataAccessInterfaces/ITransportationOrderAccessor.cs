using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface ITransportationOrderAccessor
    {
        List<Item> selectAllItems();
        bool DeleteOrder(TransportationOrderVM transportation);
        List<TransportationOrderVM> ViewAllTransportationOrders();

        List<TransportationOrder> ViewTransportationOrderByDriver(string driverID);

        int DeleteTransportOrder(int orderID);

        int CreateTransportOrder(TransportationOrder order);
    }
}
