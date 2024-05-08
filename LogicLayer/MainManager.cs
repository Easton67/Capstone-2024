using DataObjects;
using System;
using System.Runtime.CompilerServices;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Tyler Barz          
    /// Created: 02/03/2024
    /// Summary: Central store/accessor for all manager classes 
    /// Updated By: Tyler
    /// Updated: 04/22/2024
    /// What was updated:
    ///     Converted to lazy instantiation
    /// </summary>
    public class MainManager
    {
        private static MainManager instance = null;
        public User LoggedInUser { get; set; }

        private readonly Lazy<IDonationManager> _donationManager = new Lazy<IDonationManager>(() => new DonationManager());
        private readonly Lazy<IAppointmentManager> _appointmentManager = new Lazy<IAppointmentManager>(() => new AppointmentManager());
        private readonly Lazy<IHousekeepingTaskManager> _housekeepingManager = new Lazy<IHousekeepingTaskManager>(() => new HousekeepingTaskManager());
        private readonly Lazy<IHoursOfOperationManager> _hoursOfOperation = new Lazy<IHoursOfOperationManager>(() => new HoursOfOperationManager());
        private readonly Lazy<IRoomManager> _roomManager = new Lazy<IRoomManager>(() => new RoomManager());
        private readonly Lazy<IShiftManager> _shiftManager = new Lazy<IShiftManager>(() => new ShiftManager());
        private readonly Lazy<IDepartmentManager> _departmentManager = new Lazy<IDepartmentManager>(() => new DepartmentManager());
        private readonly Lazy<IStayManager> _stayManager = new Lazy<IStayManager>(() => new StayManager());
        private readonly Lazy<IMessageManager> _messageManager = new Lazy<IMessageManager>(() => new MessageManager());
        private readonly Lazy<IKitchenInventoryItemManager> _kitchenManager = new Lazy<IKitchenInventoryItemManager>(() => new KitchenInventoryItemManager());
        private readonly Lazy<IUserManager> _userManager = new Lazy<IUserManager>(() => new UserManager());
        private readonly Lazy<IEventManager> _eventManager = new Lazy<IEventManager>(() => new EventManager());
        private readonly Lazy<IFundraisingEventManager> _fundraisingEventManager = new Lazy<IFundraisingEventManager>(() => new FundraisingEventManager());
        private readonly Lazy<IPartsInventoryManager> _partsManager = new Lazy<IPartsInventoryManager>(() => new PartsInventoryManager());
        private readonly Lazy<IItemManager> _itemManager = new Lazy<IItemManager>(() => new ItemManager());
        private readonly Lazy<IMaintenanceRequestManager> _maintenanceManager = new Lazy<IMaintenanceRequestManager>(() => new MaintenanceRequestManager());
        private readonly Lazy<IRecipeManager> _recipeManager = new Lazy<IRecipeManager>(() => new RecipeManager());
        private readonly Lazy<IRecipeIngredientsManager> _recipeIngredients = new Lazy<IRecipeIngredientsManager>(() => new RecipeIngredientsManager());
        private readonly Lazy<IResourcesNeededManager> _resourcesManager = new Lazy<IResourcesNeededManager>(() => new ResourcesNeededManager());
        private readonly Lazy<IVendorDataManager> _vendorManager = new Lazy<IVendorDataManager>(() => new VendorDataManager());
        private readonly Lazy<IIncidentManager> _incidentManager = new Lazy<IIncidentManager>(() => new IncidentManager());
        private readonly Lazy<IVisitManager> _visitManager = new Lazy<IVisitManager>(() => new VisitManager());
        private readonly Lazy<ILocationManager> _locationManager = new Lazy<ILocationManager>(() => new LocationManager());
        private readonly Lazy<IVolunteerApplicationManager> _volunteerManager = new Lazy<IVolunteerApplicationManager>(() => new VolunteerApplicationManager());
        private readonly Lazy<ITransportationOrderManager> _transporationManager = new Lazy<ITransportationOrderManager>(() => new TransportationOrderManager());
        private readonly Lazy<IConfiscatedItemManager> _confiscatedManager = new Lazy<IConfiscatedItemManager>(() => new ConfiscatedItemManager());
        private readonly Lazy<IMembershipApplicationsManager> _membershipManager = new Lazy<IMembershipApplicationsManager>(() => new MembershipApplicationsManager());
        private readonly Lazy<IVolunteerManager> _volunteeringManager = new Lazy<IVolunteerManager>(() => new VolunteerManager());
        private readonly Lazy<IClientPriorityManager> _clientPriorityManager = new Lazy<IClientPriorityManager>(() => new ClientPriorityManager());
        private readonly Lazy<IHiddenIncidentManager> _hiddenIncidentManager = new Lazy<IHiddenIncidentManager>(() => new HiddenIncidentManager());

        public IDonationManager DonationManager => _donationManager.Value;
        public IHousekeepingTaskManager HousekeepingTaskManager => _housekeepingManager.Value;
        public IAppointmentManager AppointmentManager => _appointmentManager.Value;
        public IHoursOfOperationManager HoursOfOperation => _hoursOfOperation.Value;
        public IRoomManager RoomManager => _roomManager.Value;
        public IShiftManager ShiftManager => _shiftManager.Value;
        public IDepartmentManager DepartmentManager => _departmentManager.Value;
        public IStayManager StayManager => _stayManager.Value;
        public IMessageManager messageManager => _messageManager.Value;
        public IKitchenInventoryItemManager KitchenManager => _kitchenManager.Value;
        public IUserManager UserManager => _userManager.Value;
        public IEventManager EventManager => _eventManager.Value;
        public IFundraisingEventManager FundraisingEventManager => _fundraisingEventManager.Value;
        public IPartsInventoryManager PartsInventoryManager => _partsManager.Value;
        public IItemManager ItemManager => _itemManager.Value;
        public IMaintenanceRequestManager MaintenanceRequestManager => _maintenanceManager.Value;
        public IRecipeManager RecipeManager => _recipeManager.Value;
        public IRecipeIngredientsManager RecipeIngredientsManager => _recipeIngredients.Value;
        public IResourcesNeededManager ResourcesNeededManager => _resourcesManager.Value;
        public IVendorDataManager VendorDataManager => _vendorManager.Value;
        public IIncidentManager IncidentManager => _incidentManager.Value;
        public IVisitManager VisitManager => _visitManager.Value;
        public ILocationManager LocationManager => _locationManager.Value;
        public IVolunteerApplicationManager VolunteerApplicationManager => _volunteerManager.Value;
        public ITransportationOrderManager TransportationOrderManager => _transporationManager.Value;
        public IConfiscatedItemManager ConfiscatedItemManager => _confiscatedManager.Value;
        public IMembershipApplicationsManager MembershipApplicationsManager => _membershipManager.Value;
        public IVolunteerManager VolunteerManager => _volunteeringManager.Value;
        public IClientPriorityManager ClientPriorityManager => _clientPriorityManager.Value;
        public IHiddenIncidentManager HiddenIncidentManager => _hiddenIncidentManager.Value;

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/03/2024
        /// Summary: Getter for management of the MainManager instance
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/03/2024
        /// What Was Changed: Inital creation
        /// </summary>
        public static MainManager GetMainManager()
        {
            return instance ?? (instance = new MainManager());
        }

        public void CleanManager()
        {
            instance = null;
            LoggedInUser = null;
        }
    }
}