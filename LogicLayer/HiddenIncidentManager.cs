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
    public class HiddenIncidentManager : IHiddenIncidentManager
    {
        private IHiddenIncidentAccessor _hiddenIncidentAccessor;

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Default constructor, accessor connects to the database.
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public HiddenIncidentManager()
        {
            _hiddenIncidentAccessor = new HiddenIncidentAccessor();
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Constructor that sets the object to use your own data accessor.
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public HiddenIncidentManager(IHiddenIncidentAccessor hiddenIncidentAccessor)
        {
            _hiddenIncidentAccessor = hiddenIncidentAccessor;
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Gets a selection of which incidents are hidden to the given user, stores them in HiddenIncident objects, and returns them in a list.
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public List<HiddenIncident> GetHiddenIncidentsByUserId(string targetUser)
        {
            List<HiddenIncident> hiddenIncidents = new List<HiddenIncident>();

            try
            {
                hiddenIncidents = _hiddenIncidentAccessor.GetHiddenIncidentsByUserId(targetUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hiddenIncidents;
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Given a user ID and incident ID, add a row to the HiddenIncident database table.
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public int AddHiddenIncident(string userId, int incidentId)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _hiddenIncidentAccessor.AddHiddenIncident(userId, incidentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowsAffected;
        }
    }
}
