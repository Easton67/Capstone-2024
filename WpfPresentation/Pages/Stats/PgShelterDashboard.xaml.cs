using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace WpfPresentation.Pages.Stats
{
    /// <summary>
    /// Interaction logic for PgShelterDashboard.xaml
    /// </summary>
    public partial class PgShelterDashboard : Page
    {
        private List<Donation> donations;
        private ObservableCollection<Point> monthOne;
        private ObservableCollection<Point> monthTwo;
        private ObservableCollection<Point> monthThree;

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Constructor to load all dashboard data
        ///         Load all counts
        ///         Load Employee Contacts
        ///         Find donations from last 3 months
        ///         Initalize list of points
        ///         Add list of points to canvas
        ///          - May refactor to take this chunk out of construtor
        ///          - and do a few function calls instead        
        /// Updated By:     Tyler Barz
        /// Last Updated:   04/23/2024
        /// What changed:   Changed to DonationCalculator
        /// </summary>s
        private PgShelterDashboard()
        {
            InitializeComponent();
            var calc = new DonationCalculations();

            lblTotalUsers.Content = calc.TotalUserCount().ToString("N0");
            lblTotalInventory.Content = calc.TotalInventoryCount().ToString("N0");
            lblVendorCount.Content = calc.TotalVendorCount().ToString("N0");

            var calculations = calc.DonationCalculate();
            tblMaxDonation.Text = calculations.max;
            lblProfit.Content = calculations.profit;
            lblDonationCount.Content = calculations.donations;

            try
            {
                Employee ceo = calc.GetEmployeeByRole("CEO");
                lblEmployeeOneName.Content = $"Name: {ceo.EmployeeID}";
                lblEmployeeOneNumber.Content = $"Number: {ceo.PhoneNumber}";
                lblEmployeeOneRole.Content = $"Roles: {ceo.RoleDisplay.Split(',')[0]}...";
                lblEmployeeOneTitle.Content = "CEO";

                Employee security = calc.GetEmployeeByRole("Security");
                lblEmployeeTwoName.Content = $"Name: {security.EmployeeID}";
                lblEmployeeTwoRole.Content = $"Roles: {security.RoleDisplay.Split(',')[0]}...";
                lblEmployeeTwoNumber.Content = $"Number: {security.PhoneNumber}";
                lblEmployeeTwoTitle.Content = "Security";
            }
            catch 
            {
                lblEmployeeOneName.Content = "N/A";
                lblEmployeeTwoName.Content = "N/A";
            }

            DateTime ThreeMonthsAgo = DateTime.Now.AddMonths(-3);
            List<Donation> threeMonthDonations = calc.MonthDonations(ThreeMonthsAgo.Month, ThreeMonthsAgo.Year);
            List<Donation> lastMonthDonations = calc.MonthDonations(ThreeMonthsAgo.AddMonths(1).Month, ThreeMonthsAgo.AddMonths(1).Year);
            List<Donation> currentDonations = calc.MonthDonations(ThreeMonthsAgo.AddMonths(2).Month, ThreeMonthsAgo.AddMonths(2).Year);

            monthOne = new ObservableCollection<Point>(
                currentDonations.Select(d => new Point(d.DonationDate.Day, calc.GetInt(d.Amount) - 20))
            );
            monthTwo = new ObservableCollection<Point>(
                lastMonthDonations.Select(d => new Point(d.DonationDate.Day, calc.GetInt(d.Amount) + 20))
            );
            monthThree = new ObservableCollection<Point>(
                threeMonthDonations.Select(d => new Point(d.DonationDate.Day, calc.GetInt(d.Amount) + 40))
            );

            lblMonthOne.Text = ThreeMonthsAgo.AddMonths(2).ToString("MM/yy");
            lblMonthTwo.Text = ThreeMonthsAgo.AddMonths(1).ToString("MM/yy");
            lblMonthThree.Text = ThreeMonthsAgo.ToString("MM/yy");

            AddEllipsesToCanvas(monthOne, Colors.Blue);
            AddEllipsesToCanvas(monthTwo, Colors.Red);
            AddEllipsesToCanvas(monthThree, Colors.Orange);
        }

        /// <summary>
        /// Written By: Tyler Barz
        /// Written: 04/13/2024
        /// Summary: Draw a makeshift chart on canvas based on
        ///          X,Y of the current donation
        ///          - Draws as trendlines instead of points
        /// Updated By:
        /// Last Updated: 
        /// What changed: 
        /// </summary>
        private void AddEllipsesToCanvas(ObservableCollection<Point> points, Color color)
        {
            double xGap = 450/(points.Count + 1);

            Polyline trend = new Polyline
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = 2.5
            };

            foreach (Point point in points)
            {
                double x = (points.IndexOf(point) + 1) * xGap;
                trend.Points.Add(new Point(x, point.Y+30));
            }

            cvsDonations.Children.Add(trend);
        }

        private static PgShelterDashboard instance;
        public static PgShelterDashboard GetPgShelterDashboard()
        {
            return instance ?? (instance = new PgShelterDashboard());
        }
    }
}
