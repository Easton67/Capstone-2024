using DataObjects;
using LogicLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPresentation.Pages.VolunteerCoordinator;

namespace WpfPresentation.Pages.Transportation
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PageViewAllItems : Page
    {
        private ITransportationOrderManager transportationOrderManager = new TransportationOrderManager();
        public PageViewAllItems()
        {
            InitializeComponent();
            List<Item> items = new List<Item>();
            items = transportationOrderManager.GetAllItemes();
            dgItems.ItemsSource = items;
        }
        private static PageViewAllItems instance = null;
        public static PageViewAllItems GetPageViewAllItems()
        {
            return instance ?? (instance = new PageViewAllItems());
        }
    }
}
