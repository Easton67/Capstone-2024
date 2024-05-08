using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    ///Creator:            Abdalgader Ibrahim
	///Created:            02/06/2024
    ///Summary:            Test data for the Donation Accessor
    ///Last Updated By:    Abdalgader Ibrahim
    ///Last Updated:       02/09/2024
	///What Was Changed:   Add comment
    /// </summary>
    public class DonationAccessorFakes : IDonationsAccessor
    {
        List<Donation> donations = new List<Donation>();
        List<DonationType> donationsType = new List<DonationType>();
        List<Donator> donators = new List<Donator>();

        public DonationAccessorFakes()
        {
            
            donations.Add(new Donation
            {
                DonationID = 100000,
                DonationTypeID = 100001,
                DonatorID = 100002,
                DonationName = "Adam",
                Amount = "85",
                DonationDate = DateTime.Now,
                Active = true,
            });
            donations.Add(new Donation
            {
                DonationID = 100013,
                DonationTypeID = 100014,
                DonatorID = 100015,
                DonationName = "Tony",
                Amount = "95",
                DonationDate = DateTime.Now,
                Active = true,
            });
            donations.Add(new Donation
            {
                DonationID = 100009,
                DonationTypeID = 100011,
                DonatorID = 100012,
                DonationName = "Myada",
                Amount = "55",
                DonationDate = DateTime.Now,
                Active = true,
            });
            donations.Add(new Donation
            {
                DonationID = 100006,
                DonationTypeID = 100007,
                DonatorID = 100008,
                DonationName = "Amina",
                Amount = "105",
                DonationDate = DateTime.Now,
                Active = true,
            });
            donations.Add(new Donation
            {
                DonationID = 100003,
                DonationTypeID = 100004,
                DonatorID = 100005,
                DonationName = "Dana",
                Amount = "115",
                DonationDate = DateTime.Now,
                Active = true,
            });

            donationsType.Add(new DonationType
            {
                DonationTypeID = 100000,
                TypeName = "Cash",
            });
            donationsType.Add(new DonationType
            {
                DonationTypeID = 100006,
                TypeName = "Credit Card",
            });
            donationsType.Add(new DonationType
            {
                DonationTypeID = 100007,
                TypeName = "Clothing",
            });
            donationsType.Add(new DonationType
            {
                DonationTypeID = 100008,
                TypeName = "Furnture",
            });
            donationsType.Add(new DonationType
            {
                DonationTypeID = 100009,
                TypeName = "Other",
            });

            donators.Add(new Donator
            { 
                DonatorID = 100000,
                FamilyName = "Adams",
                PhoneNumber = "3195552525",
                Email = "test12@companey.com",
                Address = "222 westgate St, iowa city, IA, 52245" 
            });

            donators.Add(new Donator
            {
                DonatorID = 100001,
                FamilyName = "Adams",
                PhoneNumber = "3195552524",
                Email = "test121@companey.com",
                Address = "2224 westgate St, iowa city, IA, 52245"
            });

            donators.Add(new Donator
            {
                DonatorID = 100002,
                FamilyName = "Adams",
                PhoneNumber = "3195552523",
                Email = "test122@companey.com",
                Address = "2223 westgate St, iowa city, IA, 52245"
            });

            donators.Add(new Donator
            {
                DonatorID = 100003,
                FamilyName = "Adams",
                PhoneNumber = "3195552522",
                Email = "test123@companey.com",
                Address = "2222 westgate St, iowa city, IA, 52245"
            });

            donators.Add(new Donator
            {
                DonatorID = 100004,
                FamilyName = "Adams",
                PhoneNumber = "3195552521",
                Email = "test124@companey.com",
                Address = "2221 westgate St, iowa city, IA, 52245"
            });
        }

        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This method allows the fake data to be accessed by the DonationTest class.
        ///Last Updated By:    Abdalgader Ibrahim
        ///Last Updated:       02/09/2024
        ///What Was Changed:   Initial Creation
        /// </summary>

        public List<Donation> GetDonations()
        {
            return donations;
        }
        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This method allows the fake data to be accessed by the DonationTest class.
        ///Last Updated By:    Abdalgader Ibrahim
        ///Last Updated:       02/09/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<DonationType> GetDonationsType()
        {
            return donationsType;
        }

        /// <summary>
        ///Creator:            Abdalgader Ibrahim
        ///Created:            02/06/2024
        ///Summary:            This method allows the fake data to be accessed by the DonationTest class.
        ///Last Updated By:    Abdalgader Ibrahim
        ///Last Updated:       02/09/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<Donator> GetDonators()
        {
            return donators;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/06/2024
        /// Summary: The implementation of UpdateDonation() used for testing.
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public Donation UpdateDonation(Donation donation)
        {
            bool isupdated = false;
            foreach(Donation dbDonation in donations)
            {
                if(dbDonation.DonationID==donation.DonationID)
                {
                    dbDonation.DonationTypeID = donation.DonationTypeID;
                    dbDonation.DonatorID = donation.DonatorID;
                    dbDonation.DonationName = donation.DonationName;
                    dbDonation.Amount = donation.Amount;
                    dbDonation.DonationDate = donation.DonationDate;
                    dbDonation.Active = donation.Active;
                    isupdated = true;
                }
            }
            if (isupdated)
            {
                return donation;
            }
            else { return null; }
        }
        public int CreateDonation(Donation donation)
        {
            donations.Add(new Donation
            {
                DonationID = donation.DonationID,
                DonationTypeID = donation.DonationTypeID,
                DonatorID = donation.DonatorID,
                DonationName = donation.DonationName,
                Amount = donation.Amount,
                DonationDate = DateTime.Now,
                Active = true,
            });

            return 1;
        }
    }
}
