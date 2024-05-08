using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
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
    public class ClientPriorityFakes : IClientPriorityAccessor
    {
        private List<ClientPriority> clientPriorities = new List<ClientPriority>();
        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Default constructor, adds fake data to the clientPriorities List.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
        public ClientPriorityFakes()
        {
            clientPriorities.Add(new ClientPriority
            {
                ClientPriorityID = 100000,
                Client = "john.doe@email.com",
                BasePriority = 1,
                Deductions = 0,
                NotableConvictions = "",
                OtherHousingSituation = ""
            });

            clientPriorities.Add(new ClientPriority
            {
                ClientPriorityID = 100001,
                Client = "jane.smith@email.com",
                BasePriority = 2,
                Deductions = 0,
                NotableConvictions = "Assault",
                OtherHousingSituation = ""
            });

            clientPriorities.Add(new ClientPriority
            {
                ClientPriorityID = 100002,
                Client = "mike.johnson@email.com",
                BasePriority = 3,
                Deductions = 0,
                NotableConvictions = "",
                OtherHousingSituation = ""
            });

            clientPriorities.Add(new ClientPriority
            {
                ClientPriorityID = 100003,
                Client = "emily.brown@email.com",
                BasePriority = 4,
                Deductions = 0,
                NotableConvictions = "",
                OtherHousingSituation = "Fleeing from domestic abuse."
            });

            clientPriorities.Add(new ClientPriority
            {
                ClientPriorityID = 100004,
                Client = "chris.miller@email.com",
                BasePriority = 0,
                Deductions = 0,
                NotableConvictions = "",
                OtherHousingSituation = ""
            });
        }

        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Returns clientPriorities, the List of fake data.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
        public List<ClientPriority> SelectAllClientPriorities()
        {
            return (from c in clientPriorities select c).ToList();
        }

        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Updates a ClientPriority object present in the clientPriorities List, based on the ClientPriorityID.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
        public int UpdateClientPriority(int clientPriorityId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation)
        {
            ClientPriority clientPriority;
            try
            {
                clientPriority = (from c in clientPriorities where c.ClientPriorityID == clientPriorityId select c).Single();
            }
            catch
            {
                return 0;
            }

            clientPriority.BasePriority = basePriority;
            clientPriority.Deductions = deductions;
            clientPriority.NotableConvictions = notableConvictions;
            clientPriority.OtherHousingSituation = otherHousingSituation;

            return 1;
        }

        /*
	        <summary> 
	        Creator:            Sagan DeWald
	        Created:            03/19/2024
	        Summary:            Creates a ClientPriority object, then adds it to the clientPriorities List.
	        Last Updated By:    Sagan DeWald
	        Last Updated:       03/19/2024
	        What Was Changed:   Initial creation.
	        </summary>
        */
        public int AddClientPriority(string clientId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation)
        {
            int currentHighestId;
            try
            {
                currentHighestId = clientPriorities.OrderByDescending(c => c.ClientPriorityID).First().ClientPriorityID;
            }
            catch
            {
                return 0;
            }

            //Client already has a priority set.
            try
            {
                if((from c in clientPriorities where c.Client == clientId select c).Any())
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

            var clientPriority = new ClientPriority()
            {
                ClientPriorityID = currentHighestId + 1,
                BasePriority = basePriority,
                Deductions = deductions,
                NotableConvictions = notableConvictions,
                OtherHousingSituation = otherHousingSituation
            };
            clientPriorities.Add(clientPriority);

            return 1;
        }
    }
}
