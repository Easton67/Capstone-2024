using DataObjects;
using LogicLayer;
using MvcPresentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace MvcPresentation.Controllers
{
    [Authorize(Roles = "Admin,CEO")]
    public class AnalyticsController : Controller
    {
        private MainManager _manager = MainManager.GetMainManager();
        private DonationCalculations calc = DonationCalculations.GetDonationCalculations();

        public ActionResult Dashboard()
        {
            DashboardVM dashboard;

			DateTime ThreeMonthsAgo = DateTime.Now.AddMonths(-3);
            List<Donation> threeMonthDonations = calc.MonthDonations(ThreeMonthsAgo.Month, ThreeMonthsAgo.Year);
            List<Donation> lastMonthDonations = calc.MonthDonations(ThreeMonthsAgo.AddMonths(1).Month, ThreeMonthsAgo.AddMonths(1).Year);
            List<Donation> currentDonations = calc.MonthDonations(ThreeMonthsAgo.AddMonths(2).Month, ThreeMonthsAgo.AddMonths(2).Year);

            var calculations = calc.DonationCalculate();
            try
            {
                dashboard = new DashboardVM()
                { // start
                    UserCount = calc.TotalUserCount().ToString("N0"),
                    InventoryCount = calc.TotalInventoryCount().ToString("N0"),
                    VenderCount = calc.TotalVendorCount().ToString("N0"),
                    CEO = calc.GetEmployeeByRole("CEO"),
                    Security = calc.GetEmployeeByRole("Security"),
                    DonationAmount = calculations.profit,
                    DonationCount = calculations.donations,
                    ChartData = new ChartVM()
                    {
                        Labels = new List<string> { "Last 3 months" },
                        Datasets = new List<ChartDS> {
                            new ChartDS()
                            {
                                Label = ThreeMonthsAgo.AddMonths(2).ToString("MM/yy"),
                                BGColor = "rgba(0, 128, 255, 0.4)",
                                BRColor = "rgb(0, 128, 255)",
                                Data = currentDonations.Select(d => calc.GetInt(d.Amount)).ToList()
                            },
                            new ChartDS()
                            {
                                Label = ThreeMonthsAgo.AddMonths(1).ToString("MM/yy"),
                                BGColor = "rgba(0, 255, 128, 0.4)",
                                BRColor = "rgb(0, 255, 128)",
                                Data = lastMonthDonations.Select(d => calc.GetInt(d.Amount)).ToList()
                            },
                            new ChartDS()
                            {
                                Label = ThreeMonthsAgo.ToString("MM/yy"),
                                BGColor = "rgba(255, 99, 132, 0.4)",
                                BRColor = "rgb(255, 99, 132)",
                                Data = threeMonthDonations.Select(d => calc.GetInt(d.Amount)).ToList()
                            }
                        } 
                    } 
                }; // end
            }
            catch
            {
                dashboard = new DashboardVM()
                {
                    UserCount = "???",
                    InventoryCount = "???",
                    VenderCount = "???",
                    CEO = new Employee(),
                    Security = new Employee(),
                    DonationAmount = "0",
                    DonationCount = 0,
                    ChartData = new ChartVM()
                    {
                        Labels = new List<string> { "???" },
                        Datasets = new List<ChartDS> {
                            new ChartDS()
                            {
                                Label = "???",
                                BGColor = "rgba(0,0,0,0)",
                                BRColor = "rgb(0,0,0)",
                                Data = new List<int>()
                            }
                        }
                    }
                };
            }
            return View(dashboard);
		}
			
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/21/2024
        /// Summary: Returns a view containing the list of stays for this shelter
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/21/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ActionResult Stays() {
            List<StayVM> stays = new List<StayVM>();
            try {
                stays = _manager.StayManager.GetAllStaysForShelter("Test Homeless Shelter");
                PopulateStayDropDowns();
                return View(stays);
            } catch (Exception) {
                throw;
            }
        }

        private void PopulateStayDropDowns() {
            try {
                ViewBag.ClientList = _manager.UserManager.GetAllClients().Select(x => x.UserID);
                ViewBag.RoomList = _manager.RoomManager.GetRoomsByShelterID("Test Homeless Shelter").Select(x => x.RoomID);
            } catch (Exception) {
                ViewBag.ClientList = new List<string>();
                ViewBag.RoomList = new List<string>();
            }
        }

        public ActionResult CreateStay() {
            PopulateStayDropDowns();
            return View();
        }

        // POST: Analytics/Create
        [HttpPost]
        public ActionResult CreateStay(Stay inputStay) {
            try {
                if(ModelState.IsValid) {
                    _manager.StayManager.AddStay(inputStay.ClientID, inputStay.RoomID);
                }
                return RedirectToAction("Stays");
            } catch {
                PopulateStayDropDowns();
                return View(inputStay);
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/22/2024
        /// Summary: Returns the EditStay view with fields populated
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ActionResult EditStay(int stayID) {
            Stay stay;
            try {
                stay = _manager.StayManager.GetStay(stayID);
                Session["oldStay"] = stay;
            } catch (Exception) {
                throw;
            }
            PopulateStayDropDowns();
            return View(stay);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/22/2024
        /// Summary: Post request that updates record in database
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [HttpPost]
        public ActionResult EditStay(Stay inputStay) {
            try {
                if (ModelState.IsValid) {
                    Stay oldStay = _manager.StayManager.GetStay(inputStay.StayID);
                    _manager.StayManager.EditStay((Stay)Session["oldStay"], inputStay);
                }
                return RedirectToAction("Stays");
            } catch {
                PopulateStayDropDowns();
                return View(inputStay);
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/29/2024
        /// Summary: Get method for delete stay
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ActionResult DeleteStay(int stayID) {
            Stay stay;
            try {
                stay = _manager.StayManager.GetStay(stayID);
            } catch (Exception) {
                throw;
            }
            return View(stay);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/29/2024
        /// Summary: Post method for delete stay
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [HttpPost]
        public ActionResult DeleteStay(string stayID) {
            try {
                _manager.StayManager.RemoveStay(Convert.ToInt32(stayID));
                return RedirectToAction("Stays");
            } catch(Exception) {
                throw;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/21/2024
        /// Summary: Returns a view containing the list of rooms for this shelter
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/21/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ActionResult Rooms() {
            List<RoomVM> rooms = new List<RoomVM>();
            try {
                rooms = _manager.RoomManager.GetRoomsByShelterID("Test Homeless Shelter");
                return View(rooms);
            } catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/29/2024
        /// Summary: Get method for create room
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ActionResult CreateRoom() {
            try {
                ViewBag.statusList = _manager.RoomManager.GetRoomStatusForDropDown();
            } catch (Exception) {

                throw;
            }
            return View();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/29/2024
        /// Summary: Post method for create room
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [HttpPost]
        public ActionResult CreateRoom(Room room) {
            try {
                if(!ModelState.IsValid) {
                    if (_manager.RoomManager.GetRoomByRoomNumber(room.RoomNumber, "Test Homeless Shelter") != null) {
                        ViewBag.Error = "Room with this number already exists.";
                    }
                    ViewBag.statusList = _manager.RoomManager.GetRoomStatusForDropDown();
                    return View(room);
                } else {
                    if (_manager.RoomManager.AddRoom(room)) {
                        return RedirectToAction("Rooms");
                    }
                    ViewBag.statusList = _manager.RoomManager.GetRoomStatusForDropDown();
                    return View(room);
                }
            }
            catch (Exception ex) {
                ViewBag.Error = "Failed to add room." + ex.Message;
                ViewBag.statusList = _manager.RoomManager.GetRoomStatusForDropDown();
                return View(room);
            }
        }
    }
}
