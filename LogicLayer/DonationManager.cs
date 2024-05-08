using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Abdalgader Ibrahim          
    /// Created: 02/06/2024
    /// Summary: Create donation manager class.
    /// </summary>
    public class DonationManager : IDonationManager
    {
        public IDonationsAccessor _donationAccessor;
        public DonationManager() 
        {
            _donationAccessor = new DonationAccessor();
        }
        public DonationManager(IDonationsAccessor donationAccessor)
        {
            _donationAccessor = donationAccessor;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim          
        /// Created: 02/06/2024
        /// Summary: GetDonations() method.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<Donation> GetDonations()
        {
            try
            {
                return _donationAccessor.GetDonations();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("unable to get donations", ex);
            }
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim          
        /// Created: 02/06/2024
        /// Summary: GetDonationsType() method.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<DonationType> GetDonationsType()
        {
            try
            {
                return _donationAccessor.GetDonationsType();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to get donation types", ex);
            }
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim          
        /// Created: 02/06/2024
        /// Summary: GetDonators() method.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<Donator> GetDonators()
        {
            try
            {
                return _donationAccessor.GetDonators();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to get donators", ex);
            }
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim          
        /// Created: 02/06/2024
        /// Summary: UpdateDonators() method.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public Donation UpdateDonation(Donation donation)
        {
            try
            {
                return _donationAccessor.UpdateDonation(donation);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update donation", ex);
            }
        }
        /// <summary>
        /// Creator: Liam Easton        
        /// Created: 04/23/2024
        /// Summary: CreateDonation() method.
        /// Last Updated By: Liam Easton
        /// Last Updated 04/23/2024
        /// What was changed: initial creation
        /// </summary>
        public bool CreateDonation(Donation donation)
        {
            bool result = false;

            try
            {
                result = (1 == _donationAccessor.CreateDonation(donation));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add donation", ex);
            }

            return result;
        }
    }
}
