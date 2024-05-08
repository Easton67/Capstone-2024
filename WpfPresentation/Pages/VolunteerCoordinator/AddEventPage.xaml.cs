using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LogicLayer;
using DataObjects;

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 01/22/2024
    /// Summary: AddEventPage.xaml.cs
    /// Last updated By: Darryl Shirley
    /// Last Updated: 2/07/2024
    /// What was changed/updated: Initial Creation
    /// </summary>
    /// 

    public partial class AddEventPage : Window
    {


        LogicLayer.EventManager _eventManager = null;
        int _eventID = 0;
        int _oldVol= 0;

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: AddEventPage() Constructor
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        public AddEventPage()
        {
            InitializeComponent();

            try
            {
                this.Owner = App.Current.MainWindow;
                _eventManager = new LogicLayer.EventManager();
                List<Event> needVolunteerList = new List<Event>();
                foreach(Event e in _eventManager.getAllEvents())
                {
                    if(e.VolunteersNeeded == 0)
                    {
                        needVolunteerList.Add(e);
                    }
                }
                noVolunteerList.ItemsSource = null;
                if(needVolunteerList.Count > 0) {
                    noVolunteerList.ItemsSource = needVolunteerList;
                    
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: Back button method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: Submit Button method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _eventManager = new LogicLayer.EventManager();
            int volNeeded = 0;
            if (!txtVolunteersNeeded.Text.Equals("")){
                if (int.TryParse(txtVolunteersNeeded.Text, out volNeeded) == true)
                {
                    volNeeded = int.Parse(txtVolunteersNeeded.Text);
                }

            }
            try
            {
                if (volNeeded > 0)
                {
                    if (_eventManager.addVolunteerEvent(_eventID, _oldVol, volNeeded) == true)
                    {

                        this.DialogResult = true;

                        List<Event> needVolunteerList = new List<Event>();
                        foreach (Event eve in _eventManager.getAllEvents())
                        {
                            if (eve.VolunteersNeeded == 0)
                            {
                                needVolunteerList.Add(eve);
                            }
                        }
                        noVolunteerList.ItemsSource = null;
                        if (needVolunteerList.Count > 0)
                        {
                            noVolunteerList.ItemsSource = needVolunteerList;

                        }

                        MessageBox.Show("Event Has been created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please input a correct amount of volunteers");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Event Creation Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: Datagrid SelectionChanged Method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void noVolunteerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _eventManager = new LogicLayer.EventManager();

                if (noVolunteerList.SelectedItems.Count != 0)
                {

                    var _event = noVolunteerList.SelectedItem as Event;
                    _eventID = _event.EventID;
                    _oldVol = _event.VolunteersNeeded;
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }
    }
}
