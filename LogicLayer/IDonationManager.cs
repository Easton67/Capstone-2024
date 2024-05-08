using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Abdalgader Ibrahim
    /// Created:            02/06/2024
    /// Summary:            This is the interface for DonationMananger logic.
    /// Last Updated By:    
    /// Last Updated:       
    /// What Was Changed:   
    /// </summary>
    public interface IDonationManager
    {
        List<Donation> GetDonations();
        List<Donator> GetDonators();
        List<DonationType> GetDonationsType();
        Donation UpdateDonation(Donation donation);
        bool CreateDonation(Donation donation);
    }
}
