using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Abdalgader Ibrahim
    /// Created: 02/28/2024
    /// Summary: Create class for EventParticipant.
    /// </summary>
    public class EventParticipant
    {
        public int ParticipantID { get; set; }
        public int EventID { get; set; }
        public string ParticipantName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
