using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessInterfaces;
using DataAccessFakes;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            ClientPriority data fakes. Identical to the sample data in the database, but does not actually access it.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
    public class ClientPriorityManager : IClientPriorityManager
    {
        private IClientPriorityAccessor _clientPriorityAccessor;
        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Default constructor, for use in "production".
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
        public ClientPriorityManager()
        {
            _clientPriorityAccessor = new ClientPriorityAccessor();
        }
        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Alternative constructor for inputting the data fake class.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
        public ClientPriorityManager(IClientPriorityAccessor clientPriorityAccessor)
        {
            _clientPriorityAccessor = clientPriorityAccessor;
        }

        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Returns a List of ClientPriority objects, representing rows from the ClientPriority table in the database.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
	        </summary>
        */
        public List<ClientPriority> SelectAllClientPriorities()
        {
			try
			{

                return _clientPriorityAccessor.SelectAllClientPriorities();
            }
			catch (Exception ex)
			{

				throw new ApplicationException("Unable to get client priorities", ex);
			}
        }
        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Modifies a row in the ClientPriority table in the database, based on the ClientPriorityID.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
	        </summary>
        */
        public int UpdateClientPriority(int clientPriorityId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation)
        {
			try
            {
                return _clientPriorityAccessor.UpdateClientPriority(clientPriorityId, basePriority, deductions, notableConvictions, otherHousingSituation);
            }
			catch (Exception ex)
			{
				throw new ApplicationException("Unable to update client priority", ex);
			}
        }
        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Adds a row to the ClientPriority table in the database.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
	        </summary>
        */
        public int AddClientPriority(string clientId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation)
        {
			try
			{
                return _clientPriorityAccessor.AddClientPriority(clientId, basePriority, deductions, notableConvictions, otherHousingSituation);
            }
			catch (Exception ex)
			{

				throw new ApplicationException("Unable to add client priority", ex);
			}
        }
    }
}
