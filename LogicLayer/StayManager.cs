using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/19/2024
    /// Summary: Creation of StayManager class
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/19/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class StayManager : IStayManager
    {
        private IStayAccessor _stayAccessor = null;

        public StayManager() {
            _stayAccessor = new StayAccessor();
        }

        public StayManager(IStayAccessor stayAccessor) {
            _stayAccessor = stayAccessor;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/19/2024
        /// Summary: Creation of AddStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool AddStay(string clientID, int roomID) {
            try {
                return (2 == _stayAccessor.InsertStay(clientID, roomID));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/19/2024
        /// Summary: Creation of EditStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool EditStay(Stay oldStay, Stay newStay) {
            try {
                return (0 != _stayAccessor.UpdateStay(oldStay, newStay));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/29/2024
        /// Summary: Creation of RemoveStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool RemoveStay(int stayID) {
            try {
                return (1 == _stayAccessor.DeleteStay(stayID));
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/29/2024
        /// Summary: Implementation of GetAllStaysForShelter method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<StayVM> GetAllStaysForShelter(string shelterID) {
            List<StayVM> result = new List<StayVM>();
            try {
                result = _stayAccessor.SelectAllStaysForShelter(shelterID);
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        public Stay GetStay(int stayID) {
            Stay result = new Stay();
            try {
                result = _stayAccessor.SelectStayByStayID(stayID);
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }
    }
}
