using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
	/// <summary> 
	/// Creator:            Sagan DeWald
	/// Created:            03/19/2024
	/// Summary:            An interface for the ClientPriorityAccessor class.
	/// Last Updated By:    Sagan DeWald
	/// Last Updated:       03/19/2024
	/// What Was Changed:   Initial creation.
	/// </summary>
    public interface IClientPriorityAccessor
    {
        List<ClientPriority> SelectAllClientPriorities();
        int UpdateClientPriority(int clientPriorityId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation);
        int AddClientPriority(string clientId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation);
    }
}
