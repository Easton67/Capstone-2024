using DataObjects;
using LogicLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfPresentation.Pages;
using WpfPresentation.Pages.Admin;
using WpfPresentation.Pages.Applications;
using WpfPresentation.Pages.Appointments;
using WpfPresentation.Pages.Donations;
using WpfPresentation.Pages.Events;
using WpfPresentation.Pages.Housekeeping;
using WpfPresentation.Pages.Inventory;
using WpfPresentation.Pages.Login;
using WpfPresentation.Pages.Maintenance;
using WpfPresentation.Pages.Memberships;
using WpfPresentation.Pages.Menu;
using WpfPresentation.Pages.Messaging;
using WpfPresentation.Pages.Recipe;
using WpfPresentation.Pages.Room;
using WpfPresentation.Pages.Rooms;
using WpfPresentation.Pages.Schedule;
using WpfPresentation.Pages.Security;
using WpfPresentation.Pages.Stats;
using WpfPresentation.Pages.Stay;
using WpfPresentation.Pages.Transportation;
using WpfPresentation.Pages.Vendors;
using WpfPresentation.Pages.Visitation;
using WpfPresentation.Pages.VolunteerCoordinator;
using WpfPresentation.UtilWindows.AdminUtilWindows;
using static DataObjects.Enums;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainManager _mainManager;
        private List<Expander> _expanders;
        private Dictionary<Permissions, Control> _permissionControls;
        private string _shelterID = "Test Homeless Shelter"; // temp for testing
        InternalUser user;
        /// <summary>
        /// 
        /// Creator: Tyler Barz          
        /// Created: ??
        /// Summary: MainWindow Constructor.
        ///          Added methods to initalize role management
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/02/2024
        /// What Was Changed: Added role display to profile menu
        ///                   Added tooltip to role display, to show entire roles
        ///                     instead of just the cut-off method
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitalizeExpanders();
            InitalizePermissionControls();
            Perms.InitalizePermissions();

            _mainManager = MainManager.GetMainManager();
            user = _mainManager.LoggedInUser as InternalUser;

            #region UI Display code
            SetMenuVisibility(user.Roles);

            lblUserRoles.Content = user.RoleDisplay.Length >= 25 ? user.RoleDisplay.Substring(0, 21) + "..." : user.RoleDisplay;
            lblRoleDisplayTT.Text = user.RoleDisplay;
            lblNavigationUserID.Content = $"Homeless Shelter | Logged in as: {_mainManager.LoggedInUser.FullName}";
            lblProfileUserID.Content = _mainManager.LoggedInUser.UserID;

            FrameLoad.Navigate(PgShelterDashboard.GetPgShelterDashboard()); // MAIN DASHBOARD PAGE
            #endregion
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/19/2024
        /// Summary: Dynamically add all expanders within menu listbox to list, and add event
        ///          this allows for other contributors to add menu items without having to worry about
        ///          event handling
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial creation
        /// </summary>
        private void InitalizeExpanders()
        {
            _expanders = new List<Expander>();
            foreach (var child in lboxMenu.Items)
            {
                if (child is ListBoxItem lbi)
                {
                    Expander exp = (Expander)lbi.Content;
                    if (exp != null)
                    {
                        exp.Expanded += MenuExpander_Expanded;
                        _expanders.Add(exp);
                    }
                }
            }
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/19/2024
        /// Summary: Collapse all expanders, except the one that was selected, bool to prevent infinite loop
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/19/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private bool _handling = false;
        private void MenuExpander_Expanded(object sender, RoutedEventArgs e)
        {
            if (_handling) // If currently in collapse process
            {
                return;
            }

            _handling = true;
            foreach (Expander expander in _expanders)
            {
                expander.IsExpanded = false;
            }

            // Cast sender as Expander, to change properties
            ((Expander)sender).IsExpanded = true;
            _handling = false;
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/19/2024
        /// Summary: Associate permissions with menu items
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/02/2024
        /// What Was Changed: Updated to include new menu items
        /// </summary>
        private void InitalizePermissionControls()
        {
            _permissionControls = new Dictionary<Permissions, Control>()
            {
                { Permissions.AccountMenu, btnMenuItemAccount },
                { Permissions.HousekeepingMenu, btnMenuItemHousekeeping },
                { Permissions.ScheduleMenu, btnMenuItemSchedule },
                { Permissions.EventMenu, btnMenuItemEvent },
                { Permissions.AnalyticMenu, btnMenuItemAnalytics },
                { Permissions.MaintenanceMenu, btnMenuItemMaintenance },
                { Permissions.KitchenMenu, btnMenuItemKitchen },
                { Permissions.VolunteerMenu, btnMenuItemVolunteerCoordinator },
                { Permissions.SecurityMenu, btnMenuItemSecurity },
                { Permissions.DonationMenu, btnMenuItemDonation },
                { Permissions.SupplierMenu, btnMenuItemSupplier },
                { Permissions.VisitationMenu, btnMenuItemVisitations },
                { Permissions.TransportationMenu, btnMenuItemTransportation },
                { Permissions.MembershipMenu, btnMenuItemMemberships },
                { Permissions.AppointmentMenu, btnMenuItemAppointment }
            };
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/19/2024
        /// Summary: Change menu item visibility based on permission calculation from HasPermissions()
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/20/2024
        /// What Was Changed: Changed functionality to work with multiple userroles
        /// </summary>
        public void SetMenuVisibility(List<Role> roles)
        {
            Dictionary<Control, Visibility> backstore = new Dictionary<Control, Visibility>();

            foreach (KeyValuePair<Permissions, Control> permission in _permissionControls)
            {
                Control menuItem = permission.Value;
                Permissions perm = permission.Key;
                Visibility save = Visibility.Collapsed;

                foreach (Role role in roles)
                {
                    save = Perms.HasPermissions(role.RoleID, perm);
                    if (save == Visibility.Visible)
                    {
                        break;
                    }
                }
                backstore.Add(menuItem, save);
            }

            // Since we're saving for multiple roles
            foreach (var stored in backstore)
            {
                stored.Key.Visibility = stored.Value;
            }
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/04/2024
        /// Summary: Adding draggablity to the window, as I removed the default windows border
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/04/2024
        /// What Was Changed: Inital creation
        /// </summary>
        #region Minimize, Close, Drag
        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion
        #region Home navigation, menu display
        private void imgHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // This most likely will navigate to some sort of analytics page
            FrameLoad.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }

        private void imgHamburgerMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Expand/collapse navigation menu
            DisplayMenu(stackMainMenu);
        }

        private void imgProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Expand/collaspe profile menu
            DisplayMenu(stackProfileMenu);
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/12/2024
        /// Summary: Basic display to prevent menu overlapping
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/12/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void DisplayMenu(StackPanel panel)
        {
            Visibility visibility = panel.Visibility;

            stackMainMenu.Visibility = Visibility.Collapsed;
            stackProfileMenu.Visibility = Visibility.Collapsed;

            // Open/close
            panel.Visibility = visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        private void btnProfileLogout_Click(object sender, RoutedEventArgs e)
        {
            _mainManager.CleanManager();
            new LoginWindow().Show();
            this.Close();
        }

        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        private void btnItemInventory_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgItemInventory.GetPgItemInventory());
        }

        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        private void btnHousekeepingTasks_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(ViewHousekeepingTasks.GetViewHouseKeepingTasksPage());
        }

        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        private void btnHousekeepingSchedule_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(ViewHousekeepingSchedule.GetViewHousekeepingSchedulePage());
        }

        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        private void btnKitchenItemInventory_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(PgKitchenInventoryItem.GetPgKitchenInventoryItemPage());
        }

        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(PgViewRooms.GetViewRoomsPage());
        }

        /// <summary>
        /// Creator: Jared Harvey      
        /// Created: 03/05/2024
        /// Summary: This method navigates to the page for viewing stays
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/05/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnViewStays_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewStays.GetViewStaysPage(_shelterID));
        }

        /// <summary>
        /// Creator: Ethan McElree       
        /// Created: 02/15/2024
        /// Summary: Click handler for navigating to the create a food menu page.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Inital creation
        /// </summary>
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnCreateFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgCreateFoodMenu.GetpgCreateFoodMenu());
        }

        /// <summary>
        /// Creator: Ethan McElree       
        /// Created: 02/15/2024
        /// Summary: Click handler for navigating to the view a food menu page.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Inital creation
        /// </summary>
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        private void btnViewFoodMenu_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgRetrieveFoodMenuWithMenuID.GetpgRetrieveFoodMenuWithMenuID());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel        
        /// Created: 02/27/2024
        /// Summary: This method navigates to the page for scheduling
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 02/27/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnViewScheduling_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(new pgViewAllSchedules());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel        
        /// Created: 02/27/2024
        /// Summary: This method navigates to the page for viewing maintenance requests
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnMaintenanceRequests_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgMaintenanceRequests.GetPgMaintenanceRequests());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel        
        /// Created: 02/27/2024
        /// Summary: This method navigates to the page for parts
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnPartsInventory_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgPartsInventory.GetPartsInventoryPage());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel        
        /// Created: 02/27/2024
        /// Summary: This method navigates to the page for kitchen inventory
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnKitchenInventory_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(PgKitchenInventoryItem.GetPgKitchenInventoryItemPage());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel        
        /// Created: 02/27/2024
        /// Summary: This method navigates to the page for viewing events
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnViewEvents_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewAllEvents.GetViewAllEvents());
        }

        private void btnDonationManager_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgDonationManager.GetpgDonationManager());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel        
        /// Created: 02/27/2024
        /// Summary: This method navigates to the page for creating events
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnCreateEvents_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgCreateEvent.GetPgCreateEvent());
        }

        /// <summary>
        /// Creator: Liam Easton       
        /// Created: 02/27/2024
        /// Summary: btnSecurity_Click dropdown event navigation
        /// Last Updated By: Liam Easton 
        /// Last Updated: 02/27/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewSubmittedIncidents.GetPgViewSubmittedIncidents());
        }

        /// <summary>
        /// Creator: Kirsten Stage       
        /// Created: 02/29/2024
        /// Summary: btnViewResourcesNeeded_Click event navigation
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Called instance management
        /// </summary>
        private void btnViewResourcesNeeded_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewResourcesNeeded.GetViewResourcesNeededPage());
        }

        /// <summary>
        /// Creator: Darryl Shirley       
        /// Created: 03/01/2024
        /// Summary: This method navigates to the page for creating volunteer events
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Added instance management
        /// </summary>
        private void btnVolunteerEvents_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(VolunteerEventPage.GetVolunteerEventPage());
        }

        /// <summary>
        /// Creator: Liam Easton      
        /// Created: 03/05/2024
        /// Summary: btnAdmin_Click event added
        /// Last Updated By: Liam Easton
        /// Last Updated: 03/05/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewUserAccounts.GetpgViewUserAccounts());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel      
        /// Created: 03/04/2024
        /// Summary: This method navigates to the page for viewing suppliers/vendors
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 03/04/2024
        /// What Was Changed: Inital creation
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 03/05/2024
        /// What Was Changed: Implement PageManager
        /// </summary>
        private void btnViewSupplier_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgVendors.GetVendorsPage());
        }

        private void Reminder_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgCreateReminder.GetpgCreateReminder());
        }
        private void btnViewAppointment_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(ViewAppointment.GetViewAppointmentPage());
        }

        /// <summary>
        /// Creator: Matthew Baccam       
        /// Created: 02/28/2024
        /// Summary: This method navigates to the page for visitation
        /// Creator: Matthew Baccam       
        /// Created: 02/28/2024
        /// Summary: Initial Creation
        /// </summary>
        private void btnViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewRecipeList.GetRecipeListPage());
        }


        /// <summary>
        /// Creator: Matthew Baccam       
        /// Created: 02/28/2024
        /// Summary: This method navigates to the page for visitation
        /// Creator: Matthew Baccam       
        /// Created: 02/28/2024
        /// Summary: Initial Creation
        /// Creator: Ibrahim Albashair       
        /// Created: 04/18/2024
        /// Summary: Added If statemenet to determine which UI to use
        /// </summary>
        private void btnMenuViewVisitations_Click(object sender, RoutedEventArgs e)
        {
            if (!user.RoleDisplay.Equals("Front Desk Rep"))
            {
                FrameLoad.Navigate(pgVisitations.GetVisitationPage());
            }
            else
            {
                var pg = new pgViewAllVisits(user.FirstName, user.LastName);
                pg.ShowDialog();
            }

        }

        private void btnVolunteerApplications_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgVolunteerApplications.GetPgVolunteerApplications());
        }

        private void btnUpdateRoomStatus_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgUpdateRoomStatus.GetPgUpdateRoomStatus());
        }

        /// <summary>
        /// Creator: Matthew Baccam       
        /// Created: 03/21/2024
        /// Summary: This method navigates to the page for create new user
        /// Creator: Matthew Baccam       
        /// Created: 03/21/2024
        /// Summary: Initial Creation
        /// </summary>
        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgCreateUser.GetCreateClientPage());
        }

        /// <summary>
        /// Creator: Kirsten Stage  
        /// Created: 04/01/2024
        /// Summary: This method navigates to the page for viewing event meals
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnViewEventMeals_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewEventMeals.GetViewEventMealsPage());
        }

        /// <summary>
        /// Creator: Ethan McElree    
        /// Created: 04/1/2024
        /// Summary: Navigation method that takes a user to the view volunteers page.
        /// Creator: Ethan McElree       
        /// Created: 04/1/2024
        /// Summary: Initial Creation
        /// </summary>
        private void btnViewVolunteer_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(ViewVolunteers.GetViewVolunteers());
        }

        /// Creator: Andrew Larson       
        /// Created: 03/23/2024
        /// Summary: btnAddSupplier_Click event navigation
        /// Last Updated By: Andrew Larson
        /// Last Updated: 03/23/2024
        /// What Was Changed: Initial creation
        /// </summary>
        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(new pgAddSuppliers());
        }

        private void btnYourIncidents_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(new pgViewCurrentUserSubmittedIncidents());
        }

        /// <summary>
        /// Creator: Liam Easton      
        /// Created: 04/04/2024
        /// Summary: btnMenuTransportation_Click event navigation
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Initial creation 
        /// </summary>                        
        private void btnMenuTransportation_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(new pgTransportationOrders());
        }
        private void btnEditEvents_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(new pgEditEvent());
        }

        private void btnMassEmail_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(PgEmailAlert.GetPgEmailAlert());
        }

        /// <summary>
        /// Creator: Matthew Baccam       
        /// Created: 04/04/2024
        /// Summary: btnAddSupplier_Click event navigation
        /// Last Updated By: Matthew Baccam       
        /// Created: 04/04/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void backArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FrameLoad.CanGoBack)
            {
                FrameLoad.GoBack();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam       
        /// Created: 04/04/2024
        /// Summary: btnAddSupplier_Click event navigation
        /// Last Updated By: Matthew Baccam       
        /// Created: 04/04/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void forwardArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (FrameLoad.CanGoForward)
            {
                FrameLoad.GoForward();
            }
        }

        private void btnVolunteerAssessment_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgAssessVolunteerStrengthsAndWeaknesses.GetVolunteerAssessStrengthsAndWeaknessesPage());
        }

        private void btnConfiscatedItems_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewConfiscatedItems.GetConfiscatedItems());
        }
        private void FrameLoad_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (stackMainMenu.Visibility == Visibility.Visible)
            {
                stackMainMenu.Visibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// Creator: Matthew Baccam      
        /// Created: 04/11/2024
        /// Summary: Button_Click_1 event navigation
        /// Last Updated By: Matthew Baccam 
        /// Created: 04/11/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var editwindow = new EditUserWindow(_mainManager.LoggedInUser);
            editwindow.ShowDialog();
        }

        /// <summary>
        /// Creator: Kirsten Stage       
        /// Created: 04/11/2024
        /// Summary: btnCreateFundraisingEvent_Click event navigation
        /// Last Updated By: Kirsten Stage     
        /// Created: 04/11/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnCreateFundraisingEvent_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgCreateFundraisingEvent.GetCreateFundraisingEventPage());
        }

        private void btnViewMembershipApplications_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewMembershipApplications.GetMembershipApplicationsPage());
        }

        /// <summary>
        /// Creator: Kirsten Stage       
        /// Created: 04/18/2024
        /// Summary: btnViewFundraisingEvent_Click event navigation
        /// Last Updated By: Kirsten Stage     
        /// Created: 04/18/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnViewFundraisingEvent_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewFundraisingEvent.GetViewFundraisingEventPage());
		}

        /// <summary>
        /// Creator: Darryl Shirley      
        /// Created: 04/17/2024
        /// Summary: btnVolunteerQuestionnaire_Click event navigation
        /// Last Updated By: Darryl Shirley     
        /// Created: 04/17/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnVolunteerQuestionnaire_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgVolunteerQuestionnaire.GetPgVolunteerQuestionnaire());
        }

        private void btnScheduledRepairs_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgViewScheduledRepairs.GetpgViewScheduledRepairs());
        }

        private void btnMenuViewAllItems_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(PageViewAllItems.GetPageViewAllItems());

        }

        private void btnHouseKeepingTask_Click(object sender, RoutedEventArgs e)
        {
            FrameLoad.Navigate(pgHousekeepingTask.GetViewHousekeepingTasksPage());
        }
    }
}