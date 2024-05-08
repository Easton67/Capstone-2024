namespace DataObjects
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/14/2024
    /// Summary:            Enum class to store for easier user identification
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/19/2024
    /// What Was Changed:   Added UserRoles and Permissions, to manage roles and menu items more seemlessly
    /// </summary>
    public class Enums
    {
        public enum AuthenticationType
        {
            Unauthorized = 0,
            Employee,
            Volunteer,
            Client
        }

        public enum Permissions
        {
            AccountMenu,
            HousekeepingMenu,
            ScheduleMenu,
            EventMenu,
            InventoryMenu,
            DonationMenu,
            AnalyticMenu,
            KitchenMenu,
            SupplierMenu,
            MaintenanceMenu,
            SecurityMenu,
            VolunteerMenu,
            VisitationMenu,
            TransportationMenu,
            VolunteeringMenu,
            AppointmentMenu,
            MembershipMenu
        }
    }
}
