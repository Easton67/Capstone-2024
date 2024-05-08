using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static DataObjects.Enums;

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Tyler Barz          
    /// Created: 02/24/2024
    /// Summary: Moved to perms class
    /// Last Updated By: Tyler Barz
    /// Last Updated: 02/24/2024
    /// What Was Changed: Inital creation
    /// </summary>
    public static class Perms
    {
        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/19/2024
        /// Summary: Associate user roles with permissions
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/03/2024
        /// What Was Changed: Added more roles, and permissions per role
        /// </summary>
        private static Dictionary<string, List<Permissions>> _rolePermissions;
        public static void InitalizePermissions()
        {
            // Role permissions are a work-in-progress as we add more menu items over time
            // Currently displaying expanders based on user roles, instead of individual menu items

            _rolePermissions = new Dictionary<string, List<Permissions>>()
            {
                {
                    "CEO", new List<Permissions>()
                    {
                        Permissions.AccountMenu,
                        Permissions.EventMenu,
                        Permissions.ScheduleMenu,
                        Permissions.AnalyticMenu,
                        Permissions.KitchenMenu,
                        Permissions.MaintenanceMenu,
                        Permissions.HousekeepingMenu,
                        Permissions.KitchenMenu,
                        Permissions.InventoryMenu,
                        Permissions.SupplierMenu,
                        Permissions.VolunteerMenu,
                        Permissions.SecurityMenu,
                        Permissions.DonationMenu,
                        Permissions.VisitationMenu,
                        Permissions.TransportationMenu,
                        Permissions.AppointmentMenu,
                        Permissions.MembershipMenu
                    }
                },
                {
                    "Maintenance Manager", new List<Permissions>()
                    {
                        Permissions.MaintenanceMenu,
                        Permissions.InventoryMenu,
                        Permissions.AnalyticMenu,
                    }
                },
                {
                    "Inventory Manager", new List<Permissions>()
                    {
                        Permissions.KitchenMenu,
                        Permissions.InventoryMenu,
                        Permissions.MaintenanceMenu,
                        Permissions.AnalyticMenu
                    }
                },
                {
                    "Cook", new List<Permissions>()
                    {
                        Permissions.KitchenMenu,
                        Permissions.InventoryMenu,
                        Permissions.AnalyticMenu
                    }
                },
                {
                    "Maintenance Technician", new List<Permissions>()
                    {
                        Permissions.MaintenanceMenu,
                        Permissions.InventoryMenu,
                        Permissions.AnalyticMenu
                    }
                },
                {
                    "Kitchen Manager", new List<Permissions>()
                    {
                        Permissions.KitchenMenu,
                        Permissions.InventoryMenu,
                        Permissions.SupplierMenu,
                        Permissions.TransportationMenu,
                        Permissions.AnalyticMenu
                    }
                },
                {
                    "Security Manager", new List<Permissions>()
                    {
                        Permissions.AnalyticMenu,
                        Permissions.SecurityMenu
                    }
                }
            };
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/19/2024
        /// Summary: Determine what menu item controls the user role has access to
        ///          return a Visibility enum so you can one-line set the visibility in SetMenuVisibility()
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/19/2024
        /// What Was Changed: Inital creation
        /// </summary>
        public static Visibility HasPermissions(string role, Permissions permission)
        {
            if (_rolePermissions.ContainsKey(role))
            {
                return _rolePermissions[role].Contains(permission) ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}
