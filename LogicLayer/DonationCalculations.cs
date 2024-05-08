using DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Written By:     Tyler Barz
    /// Written:        04/23/2024
    /// Summary:        Ported WPF code into a helper so I don't repeat
    ///                                                 code on the web
    /// </summary>
    public class DonationCalculations
    {
        private MainManager manager;
        private List<Donation> allDonos;
        private static DonationCalculations instance;
        public DonationCalculations() 
        { 
            manager = MainManager.GetMainManager();
            allDonos = GetDonations();
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Quick replacement of the $ since donations
        ///          are being stored as strings..
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        public int GetInt(string amount)
        {
            int output = 0;
            int.TryParse(amount.Replace("$", ""), out output);
            return output;
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Update donation labels
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        public (string max, string profit, int donations) DonationCalculate()
        {
            // If logic was proper, I wouldn't need these long method chains to select something
            // Don't want to change logic fullstack for many current features.
            string max = allDonos.OrderByDescending(d => GetInt(d.Amount)).FirstOrDefault().Amount;
            string profit = allDonos.Sum(d => { int amt; return int.TryParse(GetInt(d.Amount).ToString(), out amt) ? amt : 0; }).ToString("C");
            int donations = allDonos.Count;

            return (max, profit, donations);
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Find list of donations based off a MM/YYYY
        /// Updated By: Tyler Barz
        /// Last Updated: 04/13/2024
        /// What changed: intial
        /// </summary>
        public List<Donation> MonthDonations(int month, int year)
        {
            return allDonos.FindAll(d => d.DonationDate.Month == month && d.DonationDate.Year == year);
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Calculate and display total user count
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        public int TotalUserCount()
        {
            int total = 0;
            try
            {
                total += manager.UserManager.SelectAllEmployees().Count;
                total += manager.UserManager.GetAllClients().Count;
                total += manager.UserManager.GetAllVolunteers().Count;
            }
            catch { /* Do nothing just return 0 */ }
            return total;
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Calculate and display total inventory count
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        public int TotalInventoryCount()
        {
            int total = 0;
            try
            {
                total += manager.PartsInventoryManager.GetPartsInventory().Count;
                total += manager.KitchenManager.GetKitchenInventoryItems().Count;
            }
            catch { /* Do nothing just return 0 */ }
            return total;
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Calculate and display total vendor count
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        public int TotalVendorCount()
        {
            int total = 0;
            try
            {
                total += manager.VendorDataManager.GetAllVendors().Count;
            }
            catch { /* Do nothing just return 0 */ }
            return total;
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Select employee by role
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        public Employee GetEmployeeByRole(string role)
        {
            try
            {
                return manager.UserManager.SelectAllEmployeesWithRoles().FirstOrDefault(e => e.RoleDisplay.Contains(role));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Save a list of all donations
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        private List<Donation> GetDonations()
        {
            try
            {
                return manager.DonationManager.GetDonations();
            }
            catch
            {
                return new List<Donation>();
            }
        }

        public static DonationCalculations GetDonationCalculations()
        {
            return instance ?? (instance = new DonationCalculations());
        }
    }
}
