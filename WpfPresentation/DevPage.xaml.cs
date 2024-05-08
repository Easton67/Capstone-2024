using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using WpfPresentation.Pages;
using WpfPresentation.Pages.Vendors;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for DevPage.xaml
    /// </summary>
    public partial class DevPage : Page
    {
        // Change DevPage to name of your page
        // Change method name to GetYourPageName(), to keep styling the same
        private static DevPage instance = null;
        public static DevPage GetDevPage()
        {
            return instance ?? (instance = new DevPage());
        }


        private static HousekeepingPage housekeepingPage = null;
        public static HousekeepingPage GetHousekeepingPage() {
            return housekeepingPage ?? (housekeepingPage = new HousekeepingPage());
        }
    }
}
