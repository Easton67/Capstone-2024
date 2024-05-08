using DataObjects;
using LogicLayer;
using System;
using System.CodeDom;
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

namespace WpfPresentation.UtilWindows {
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window {
        private MainManager mainManager;
        private Event _event;
        public EditEvent(Event eventInput) {
            _event = eventInput;
            mainManager = MainManager.GetMainManager();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            txtEventName.Text = _event.EventName;
            txtDescription.Text = _event.Description;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            if(txtEventName.Text == "") {
                MessageBox.Show("You must provide a name for this event.");
                return;
            }
            if(txtDescription.Text == "") {
                MessageBox.Show("You must provide a description for this event.");
                return;
            }

            try {
                _event.EventName = txtEventName.Text;
                _event.Description = txtDescription.Text;
                if(mainManager.EventManager.UpdateEvent(_event)) {
                    DialogResult = true;
                } else {
                    MessageBox.Show("Something went wrong when updating this event.");
                    return;
                }
            } catch (Exception ex) {
                MessageBox.Show("Something went wrong when updating this event.", ex.Message);
                return;
            }
        }
    }
}
