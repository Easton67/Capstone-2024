using DataObjects;
using LogicLayer;
using System;
using System.Collections;
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

namespace WpfPresentation.Pages.Schedule
{
    /// <summary>
    /// Creator:            Abdalgader Ibrahim
    /// Created:            03/19/2024
    /// Summary:            Creation of the pgViewSchedule page code behind file.
    /// </summary>

    /// <summary>
    /// Interaction logic for pgViewSchedule.xaml
    /// </summary>
    public partial class pgViewSchedule : Page
    {
        private IShiftManager _shiftManager;
        private IScheduleManager _scheduleManager;
        public pgViewSchedule(int scheduleID)
        {
            InitializeComponent();
            _shiftManager = new ShiftManager();
            _scheduleManager = new ScheduleManager();
            SetUpShifts(scheduleID);

        }

        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/19/2024
        /// Summary:            Creation of the SetUpShifts method.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void SetUpShifts(int scheduleID)
        {
            try
            {
                ScheduleVM scheduleVM = _scheduleManager.GetAllSchedules().Find(item => item.ScheduleID == scheduleID);
                List<ShiftVM> shiftVMs = _shiftManager.SelectShiftByScheduleID(scheduleID);
                DateTime scheduleStartDate = scheduleVM.ScheduleStartDate;
                DateTime scheduleEndDate = scheduleVM.ScheduleEndDate;
                if (shiftVMs.Count > 0)
                {


                    List<ShiftVM> dayOneShifts = new List<ShiftVM>();
                    List<ShiftVM> dayTwoShifts = new List<ShiftVM>();
                    List<ShiftVM> dayThreeShifts = new List<ShiftVM>();
                    List<ShiftVM> dayFourShifts = new List<ShiftVM>();
                    List<ShiftVM> dayFiveShifts = new List<ShiftVM>();
                    List<ShiftVM> daySixShifts = new List<ShiftVM>();
                    List<ShiftVM> daySevenShifts = new List<ShiftVM>();
                    foreach (ShiftVM shiftVM in shiftVMs)
                    {
                        // var dayone = shiftVM.StartTime.Day;
                        if (shiftVM.StartTime.Day == scheduleStartDate.Day)
                        {
                            dayOneShifts.Add(shiftVM);
                        }
                        else if (shiftVM.StartTime.Day == scheduleStartDate.AddDays(1).Day)
                        {
                            dayTwoShifts.Add(shiftVM);
                        }
                        else if (shiftVM.StartTime.Day == scheduleStartDate.AddDays(2).Day)
                        {
                            dayThreeShifts.Add(shiftVM);
                        }
                        else if (shiftVM.StartTime.Day == scheduleStartDate.AddDays(3).Day)
                        {
                            dayFourShifts.Add(shiftVM);
                        }
                        else if (shiftVM.StartTime.Day == scheduleStartDate.AddDays(4).Day)
                        {
                            dayFiveShifts.Add(shiftVM);
                        }
                        else if (shiftVM.StartTime.Day == scheduleStartDate.AddDays(5).Day)
                        {
                            daySixShifts.Add(shiftVM);
                        }
                        else if (shiftVM.StartTime.Day == scheduleStartDate.AddDays(6).Day)
                        {
                            daySevenShifts.Add(shiftVM);
                        }
                    }

                    dgDayOne.ItemsSource = GetStringList(dayOneShifts);
                    dgDayTwo.ItemsSource = GetStringList(dayTwoShifts);
                    dgDayThree.ItemsSource = GetStringList(dayThreeShifts);
                    dgDayFour.ItemsSource = GetStringList(dayFourShifts);
                    dgDayFive.ItemsSource = GetStringList(dayFiveShifts);
                    dgDaySix.ItemsSource = GetStringList(daySixShifts);
                    dgDaySeven.ItemsSource = GetStringList(daySevenShifts);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to get shifts \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
            
        }

        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/19/2024
        /// Summary:            Creation of the GetStringList list.
        /// </summary>
        private List<ShiftData> GetStringList(List<ShiftVM> dayOneShifts)
        {
            List<ShiftData> result = new List<ShiftData>();
            foreach (var shiftVM in dayOneShifts)
            {
                string str = shiftVM.employee.FullName + " " + shiftVM.StartTime.ToString() + "-" +
                    shiftVM.EndTime.ToString();
                ShiftData shiftData = new ShiftData();
                shiftData.Shift = str;
                result.Add(shiftData);
            }
            return result;
        }
        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/28/2024
        /// Summary:            Creation of the Cancel_Click hundler.
        /// </summary>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgViewAllSchedules());
        }
    }

}