using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Abdalgader Ibrahim
    /// Created: 02/06/2024
    /// Summary: Donation Accessor Interface
    /// Last Updated By: Abdalgader Ibrahim
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IDonationsAccessor
    {
        List<Donation> GetDonations();
        List<DonationType> GetDonationsType();
        List<Donator> GetDonators();
        Donation UpdateDonation(Donation donation);
        int CreateDonation(Donation donation);
    }
}
