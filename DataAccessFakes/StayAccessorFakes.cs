using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 03/02/2024
    /// Summary: This class accesses the fake stay records for testing
    /// Last Updated By: Jared Harvey
    /// Last Updated: 03/02/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class StayAccessorFakes : IStayAccessor {
        public List<StayVM> fakeStays = new List<StayVM>();
        private RoomAccessorFakes roomAccessorFakes;
        private List<RoomVM> fakeRooms = new List<RoomVM>();

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/02/2024
        /// Summary: This constructor creates a list of fake stays for testing
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/02/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public StayAccessorFakes() {
            fakeStays.Add(new StayVM() {
                StayID = 100000,
                ClientID = "tess@company.com",
                RoomID = 100000,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = false
            });
            fakeStays.Add(new StayVM() {
                StayID = 100001,
                ClientID = "gary-vogt@company.com",
                RoomID = 100001,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = false
            });
            fakeStays.Add(new StayVM() {
                StayID = 100002,
                ClientID = "marc-haus@company.com",
                RoomID = 100002,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = true
            });
            fakeStays.Add(new StayVM() {
                StayID = 100003,
                ClientID = "jim-glasgow@company.com",
                RoomID = 100003,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = false
            });
            fakeStays.Add(new StayVM() {
                StayID = 100004,
                ClientID = "bob-trapp@company.com",
                RoomID = 100004,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = false
            });
            // gets fakeRooms for testing
            roomAccessorFakes = new RoomAccessorFakes();
            fakeRooms = roomAccessorFakes.fakeRooms;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: Fake accessor for InsertStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertStay(string clientID, int roomID) {
            int result = 0;
            int preCount = fakeStays.Count();
            // insert stay
            try {
                StayVM stay = new StayVM() {
                    StayID = fakeStays.Count + 1,
                    ClientID = clientID,
                    RoomID = roomID,
                    InDate = DateTime.Now,
                    OutDate = DateTime.Now.AddDays(1),
                    CheckedOut = false
                };
                fakeStays.Add(stay);
                int postCount = fakeStays.Count();
                result += postCount - preCount;
                //update room status
                fakeRooms[fakeRooms.IndexOf(fakeRooms.Find(x => x.RoomID == stay.RoomID))].Status = "Occupied";
                result += 1;
            } catch (Exception ex) {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: Fake accessor for UpdateStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int UpdateStay(Stay oldStay, Stay newStay) {
            int result = 0;
            try {
                fakeStays[fakeStays.IndexOf(fakeStays.Find(x => x.StayID == oldStay.StayID))] = (StayVM)newStay;
                result += 1;
            } catch (Exception ex) {
                throw ex; 
            }
            return result;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: Fake accessor for DeleteStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int DeleteStay(int stayID) {
            int preCount = fakeStays.Count;
            int result = 0;
            try {
                fakeStays.RemoveAt(fakeStays.FindIndex(x => x.StayID == stayID));
                result = preCount - fakeStays.Count;
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: Fake accessor for SelectAllStaysForShelter method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<StayVM> SelectAllStaysForShelter(string shelterID) {
            return fakeStays;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/22/2024
        /// Summary: Fake accessor for SelectStayByStayID method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public Stay SelectStayByStayID(int stayID) {
            return fakeStays.Find(x => x.StayID == stayID);
        }
    }
}
