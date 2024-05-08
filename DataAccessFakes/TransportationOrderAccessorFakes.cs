using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class TransportationOrderAccessorFakes : ITransportationOrderAccessor
    {
        public List<TransportationOrderVM> fakeOrders = new List<TransportationOrderVM>();
        public List<TransportationOrder> _fakeOrders = new List<TransportationOrder>();
        public List<Location> fakeLocations = new List<Location>();
        private List<Item> fakeItems = new List<Item>();

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/03/2024
        /// Summary:            Initial creation of the TransportationOrderAccessorFakes.
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/25/2024
        /// What Was Changed:   Add fake data for fake Items.
        /// </summary>
        public TransportationOrderAccessorFakes()
        {
            // Locations
            fakeLocations.Add(new Location()
            {
                LocationID = 1,
                LocationName = "Location1",
                Address = "123 Test St",
                City = "City1",
                State = "State1",
                ZipCode = 12345
            });
            fakeLocations.Add(new Location()
            {
                LocationID = 2,
                LocationName = "Location2",
                Address = "987 Fake Ct",
                City = "City2",
                State = "State2",
                ZipCode = 98765
            });
            fakeLocations.Add(new Location()
            {
                LocationID = 1,
                LocationName = "Location3",
                Address = "893 Fake Bvld",
                City = "Seattle",
                State = "West Dakota",
                ZipCode = 99980
            });
            fakeLocations.Add(new Location()
            {
                LocationID = 2,
                LocationName = "Location2",
                Address = "987 Fake Ct",
                City = "Washington City",
                State = "Oregon",
                ZipCode = 53402
            });

            // Orders
            _fakeOrders.Add(new TransportationOrder()
            {
                TransportItemID = 1,
                ClientID = "ClientID1",
                LocationID = 2,
                DayDroppedOff = DateTime.Today.AddDays(1),
                DayPosted = DateTime.Today.AddDays(1),
                DayToPickUp = DateTime.Today.AddDays(1),
                AssignedDriver = "DriverID1",
                Fulfilled = true,


            });
            // OrdersVM
            fakeOrders.Add(new TransportationOrderVM()
            {
                TransportItemID = 1,
                DayPosted = DateTime.Today.AddDays(3),
                DayToPickUp = DateTime.Today.AddDays(4),
                DayDroppedOff = DateTime.Today.AddDays(4),
                AssignedDriver = "Jane Doe",
                Fulfilled = true,
                LineItemAmount = 100000,
                Vendor = "Kay Jewelers",
                TransportItem = "Ring",
                Location = fakeLocations[0].Address + " , " +
                           fakeLocations[0].City + " , " +
                           fakeLocations[0].State + " , " +
                           fakeLocations[0].ZipCode,
            });
            fakeOrders.Add(new TransportationOrderVM()
            {
                TransportItemID = 2,
                DayPosted = DateTime.Today.AddDays(3),
                DayToPickUp = DateTime.Today.AddDays(4),
                DayDroppedOff = DateTime.Today.AddDays(4),
                AssignedDriver = "John Doe",
                Fulfilled = true,
                LineItemAmount = 100000,
                Vendor = "Kmart",
                TransportItem = "Trash Bags",
                Location = fakeLocations[1].Address + " , " +
                           fakeLocations[1].City + " , " +
                           fakeLocations[1].State + " , " +
                           fakeLocations[1].ZipCode,
            });
            fakeOrders.Add(new TransportationOrderVM()
            {
                TransportItemID = 3,
                DayPosted = DateTime.Today.AddDays(4),
                DayToPickUp = DateTime.Today.AddDays(5),
                DayDroppedOff = DateTime.Today.AddDays(5),
                AssignedDriver = "Shawn Cee",
                Fulfilled = false,
                LineItemAmount = 4300,
                Vendor = "Target",
                TransportItem = "Mattress",
                Location = fakeLocations[2].Address + " , " +
                           fakeLocations[2].City + " , " +
                           fakeLocations[2].State + " , " +
                           fakeLocations[2].ZipCode,
            });
            fakeOrders.Add(new TransportationOrderVM()
            {
                TransportItemID = 4,
                DayPosted = DateTime.Today.AddDays(34),
                DayToPickUp = DateTime.Today.AddDays(35),
                DayDroppedOff = DateTime.Today.AddDays(35),
                AssignedDriver = "Jean Doe",
                Fulfilled = false,
                LineItemAmount = 2900,
                Vendor = "Walmart",
                TransportItem = "Sheets",
                LocationID = 100000,
                Location = fakeLocations[3].Address + " , " +
                           fakeLocations[3].City + " , " +
                           fakeLocations[3].State + " , " +
                           fakeLocations[3].ZipCode,
            });
            fakeItems.Add(new Item()
            {
                ItemID = 1,
                ItemName = "Test1",
                ItemDescription = "Test1",
                QtyOnHand = 1,
                NormalStockQty = 1,
                ReorderPoint = 1,
                OnOrder = 1

            });
            fakeItems.Add(new Item()
            {
                ItemID = 2,
                ItemName = "Test2",
                ItemDescription = "Test2",
                QtyOnHand = 2,
                NormalStockQty = 2,
                ReorderPoint = 2,
                OnOrder = 2

            });
            fakeItems.Add(new Item()
            {
                ItemID = 3,
                ItemName = "Test3",
                ItemDescription = "Test3",
                QtyOnHand = 3,
                NormalStockQty = 3,
                ReorderPoint = 3,
                OnOrder = 3

            });
        }

        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            04/202024
        /// Summary:            Initial creation of the  selectAllItems Fakes.
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/20/2024
        /// What Was Changed:   Initial creation of the selectAllItems Fakes.
        /// </summary>
        public List<Item> selectAllItems()
        {
            return fakeItems;
        }
        public bool DeleteOrder(TransportationOrderVM transportation)
        {
            foreach (var order in fakeOrders)
            {
                if (DateTime.Compare(transportation.DayPosted, order.DayPosted) == 0
                    && DateTime.Compare(transportation.DayToPickUp, order.DayToPickUp) == 0
                 && transportation.AssignedDriver == order.AssignedDriver
                 && transportation.Fulfilled == order.Fulfilled
                 && transportation.LineItemAmount == order.LineItemAmount
                 && transportation.Vendor == order.Vendor
                 && transportation.TransportItem == order.TransportItem
                 && transportation.LocationID == order.LocationID
                 && transportation.Location == order.Location)



                {
                    fakeOrders.Remove(order);
                    return true;

                }
            }
            return false;
        }


        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the CreateTransportOrder method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the CreateTransportOrder method.
        /// </summary>
        public int CreateTransportOrder(TransportationOrder order)
        {
            int rows = 0;
            if (order != null)
            {
                _fakeOrders.Add(order);
                rows++;
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the CreateTransportOrder method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the CreateTransportOrder method.
        /// </summary>
        public int DeleteTransportOrder(int orderID)
        {
            List<TransportationOrder> newList = new List<TransportationOrder>(_fakeOrders);
            int rows = 0;
            foreach (var o in newList)
            {
                if (orderID == o.TransportItemID)
                {
                    rows++;
                }
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the ViewAllTransportationOrders.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the ViewAllTransportationOrders.
        /// </summary>
        public List<TransportationOrderVM> ViewAllTransportationOrders()
        {
            List<TransportationOrderVM> orders = new List<TransportationOrderVM>();

            foreach (var order in fakeOrders)
            {
                orders.Add(order);
            }

            return orders;
        }


        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/18/2024
        /// Summary:            Initial creation of the ViewTransportationOrderByDriver method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial creation of the ViewTransportationOrderByDriver method.
        /// </summary>
        public List<TransportationOrder> ViewTransportationOrderByDriver(string driverID)
        {
            List<TransportationOrder> orders = new List<TransportationOrder>();

            foreach (var order in fakeOrders)
            {
                if (order.AssignedDriver.Equals(driverID))
                {
                    orders.Add(order);
                }
            }
            return orders;
        }
    }
}
