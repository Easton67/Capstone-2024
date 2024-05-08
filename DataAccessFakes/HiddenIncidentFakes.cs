using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class HiddenIncidentFakes : IHiddenIncidentAccessor
    {
        private List<HiddenIncident> hiddenIncidents = new List<HiddenIncident>();
        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/29/2024
        //Summary: Generates fake HiddenIncident objects for unit tests to use.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public HiddenIncidentFakes()
        {
            hiddenIncidents.AddRange(
                new List<HiddenIncident>()
                {
                    new HiddenIncident
                    (
                        100000,
                        "john@company.com",
                        100000
                    ),
                    new HiddenIncident
                    (
                        100001,
                        "john@company.com",
                        100001
                    ),
                    new HiddenIncident
                    (
                        100002,
                        "john@company.com",
                        100002
                    ),
                    new HiddenIncident
                    (
                        100003,
                        "john@company.com",
                        100003
                    )
                }
            );
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/29/2024
        //Summary: Returns a list of data fakes that match the entered target user ID.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public List<HiddenIncident> GetHiddenIncidentsByUserId(string targetUser)
        {
            var query = from hiddenIncident in hiddenIncidents where hiddenIncident.TargetUser == targetUser select hiddenIncident;
            return query.ToList();
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/29/2024
        //Summary: Adds a new data fake to the hiddenIncidents list.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public int AddHiddenIncident(string userId, int incidentId)
        {
            int oldCount = hiddenIncidents.Count;

            //TODO: Viewing Incidents has not been implemented yet, so this will have to be put in place of checking if the incident exists for now.
            //The actual data accessor method will fail if there is not matching incident, as there is a foreign key constraint.
            int incidents = (from hiddenIncident in hiddenIncidents where hiddenIncident.IncidentId == incidentId select hiddenIncident).Count();
            if (incidents < 1)
            {
                throw new ArgumentException("No incident with this ID found.");
            }

            var latestIncident = (from hiddenIncident in hiddenIncidents select hiddenIncident).OrderByDescending(i => i.HiddenIncidentId).First();
            HiddenIncident newHiddenIncident = new HiddenIncident(latestIncident.HiddenIncidentId + 1, userId, incidentId);
            hiddenIncidents.Add(newHiddenIncident);

            return hiddenIncidents.Count - oldCount; //If the item didn't get added somehow, the math will return 0.
        }
    }
}
