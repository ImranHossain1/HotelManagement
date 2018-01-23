using Service;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management.Controllers
{
    public class AdminController : Controller
    {
        private AdminService adminService = new AdminService();
        private EmployeeService empService = new EmployeeService();
        private RoomService roomService = new RoomService();
        private RoomAvService roomavService = new RoomAvService();
        private BookingService bookingService = new BookingService();
        private UserBalanceService UserBalanceService = new UserBalanceService();
        private CustomerService cusService = new CustomerService();
        private NotificationService notiService = new NotificationService();
        private MessageService msgService = new MessageService();
        public static int tempId = 0;
        public ActionResult Index()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View();
        }
        //admin signup and details
        public ActionResult AdminProfile()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(adminService.GetAll());
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {

            return View();
        }
        public JsonResult AdminUsernameAvailability(string userdata)
        {
            DataContext db = new DataContext();
            System.Threading.Thread.Sleep(200);
            var SeachData = db.Admins.Where(x => x.UserName == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(Admin admin)
        {

            if (ModelState.IsValid)
            {

                this.adminService.Insert(admin);
                return RedirectToAction("AdminProfile");
            }
            else
            {
                return View(admin);
            }
        }
        [HttpGet]
        public ActionResult AdminProfileEdit(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.adminService.Get(id));
        }

        [HttpPost]
        public ActionResult AdminProfileEdit(Admin admin)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }

            this.adminService.Update(admin);
            return RedirectToAction("AdminProfile");


        }

        [HttpGet]
        public ActionResult AdminProfileDetails(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.adminService.Get(id));
        }

        [HttpGet]
        public ActionResult AdminProfileDelete(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.adminService.Get(id));
        }

        [HttpPost, ActionName("AdminProfileDelete")]
        public ActionResult AdminProfileConfirmDelete(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            this.adminService.Delete(id);
            return RedirectToAction("AdminProfile");
        }
        [HttpGet]
        public ActionResult BookCustomer(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            tempId = id;
            Customer cs = this.cusService.Get(id);

            var avRoom = from item in this.roomavService.GetAll()
                         where item.Availability == true && item.Room.Catagory == cs.Catagory
                         select item.RoomAvId;
            ViewBag.avRoom = avRoom;

            return View(cs);
        }

        public float TotalCost(int id)
        {
            float TotalCost = 0;

            var cus = from item in this.bookingService.GetAll()
                      where item.CustomerId == id
                      select item.TotalCost;

            foreach (var item in cus)
            {
                TotalCost = (float)(TotalCost + item);
            }

            return TotalCost;
        }

        [HttpPost]
        public ActionResult BookCustomer()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            Customer cs = this.cusService.Get(tempId);

            Booking b = new Booking()
            {
                CustomerId = cs.CustomerId,
                RoomAvId = Int32.Parse(Request["room"]),
                TotalCost = this.roomService.Get(cs.Catagory).Rent * cs.Nights
            };

            this.bookingService.Insert(b);

            RoomAv rav = this.roomavService.Get(b.RoomAvId);
            rav.Availability = false;
            this.roomavService.Update(rav);

            UserBalance xyz = new UserBalance();
            xyz = this.UserBalanceService.GetByCustomer(cs.CustomerId);

            var ubc = from item in this.UserBalanceService.GetAll()
                      where item.CustomerId == cs.CustomerId
                      select item.CustomerId;

            try
            {
                if (xyz.CustomerId == 0)
                {
                    UserBalance balance = new UserBalance()
                    {
                        CustomerId = cs.CustomerId,
                        UserBalanceAmount = TotalCost(cs.CustomerId),
                        Paid = 0,
                        RemainingAcount = TotalCost(cs.CustomerId)
                    };
                    this.UserBalanceService.Insert(balance);
                }
                else
                {
                    UserBalance balance = this.UserBalanceService.GetByCustomer(cs.CustomerId);
                    balance.UserBalanceAmount = TotalCost(cs.CustomerId);
                    balance.RemainingAcount = TotalCost(cs.CustomerId);
                    this.UserBalanceService.Update(balance);
                }
            }
            catch (Exception ex)
            {
                UserBalance balance = new UserBalance()
                {
                    CustomerId = cs.CustomerId,
                    UserBalanceAmount = TotalCost(cs.CustomerId),
                    Paid = 0,
                    RemainingAcount = TotalCost(cs.CustomerId)
                };
                Console.WriteLine(ex.ToString());
                this.UserBalanceService.Insert(balance);
            }
            

            return View("Index");
        }
        
        public ActionResult Bookings()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.bookingService.GetAll());
        }
        
        public ActionResult DetailsBooking(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.cusService.Get(id));
        }

        [HttpGet]
        public ActionResult Balancesheet(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.UserBalanceService.GetByCustomer(id));
        }

        public ActionResult UserBalances()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.UserBalanceService.GetAll());
        }

        [HttpGet]
        public ActionResult EditUserBalance(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.UserBalanceService.Get(id));
        }

        [HttpPost]
        public ActionResult EditUserBalance(UserBalance ub)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            ub.Paid = ub.Paid;
            ub.RemainingAcount = ub.UserBalanceAmount - ub.Paid;
            this.UserBalanceService.Update(ub);
            return Redirect("/Admin/DetailsUserBalance?id=" + ub.CustomerId);
        }

        public ActionResult DetailsUserBalance(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.UserBalanceService.Get(id));
        }

        //Customer Start -------------------------------------------------------------------
        public ActionResult Customers()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.cusService.GetAll());
        }


        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.cusService.Get(id));
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.cusService.Update(customer);
                return RedirectToAction("Customers");
            }
            else
            {
                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult DetailsCustomer(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.cusService.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.cusService.Get(id));
        }

        [HttpPost, ActionName("DeleteCustomer")]
        public ActionResult DeleteConfirmedCustomer(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            this.cusService.Delete(id);
            return RedirectToAction("Customers");
        }
        // Customer End -------------------------------------------------------------------


        public ActionResult Notifications()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.notiService.GetAll());
        }

        [HttpGet]
        public ActionResult DetailsNotification(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }

            Notification n = this.notiService.Get(id);
            n.Seen = true;
            this.notiService.Update(n);

            return View(this.cusService.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteNotification(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.notiService.Get(id));
        }

        [HttpPost, ActionName("DeleteNotification")]
        public ActionResult DeleteConfirmedNotification(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            this.notiService.Delete(id);
            return RedirectToAction("Notifications");
        }


        
        public ActionResult GetNotifications()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            var noti = from item in this.notiService.GetAll()
                       where item.Seen == false
                       select item.NotificationId.ToString();
            return Json(new { result = noti }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMessages()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            var msg = from item in this.msgService.GetAll()
                       where item.Seen == false
                       select item.MessageId.ToString();
            return Json(new { result = msg }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Messages()
        {
            return View(this.msgService.GetAll());
        }

        public ActionResult DetailsMessage(int id)
        {
            Message msg = this.msgService.Get(id);
            msg.Seen = true;
            this.msgService.Update(msg);
            return View(msg);
        }

        [HttpGet]
        public ActionResult DeleteMessage(int id)
        {
            return View(this.msgService.Get(id));
        }

        [HttpPost, ActionName("DeleteMessage")]
        public ActionResult ConfirmDeleteMessage(int id)
        {
            this.msgService.Delete(id);
            return RedirectToAction("Messages");
        }

        // Notification End -------------------------------------------------------------------

        //Room av-----------------------------------------------

        [HttpGet]
        public ActionResult AvailableRoom()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            //DataContext db = new DataContext();
            List<RoomAv> roomlist = roomavService.GetAll();
            RoomAvModel roomAvModel = new RoomAvModel();
            List<RoomAvModel> roomMList = roomlist.Select
                (x => new RoomAvModel
                {
                    RoomAvId = x.RoomAvId,
                    RoomId = x.RoomId,
                    Catagory = x.Room.Catagory ,
                    Rent =x.Room.Rent}).ToList();
            

            return View(roomMList);
        }
        [HttpGet]
        public ActionResult CreateRoomAv()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
           // DataContext db = new DataContext();
            List<Room> roomList = roomService.GetAll();
            ViewBag.RoomList = new SelectList(roomList,"RoomId","Catagory");
            
            return View();
            
        }
        [HttpPost]
        public ActionResult CreateRoomAv(RoomAv roomAv)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.roomavService.Insert(roomAv);
                return RedirectToAction("AvailableRoom");
            }
            else
            {
                return View(roomAv);
            }
        }
        [HttpGet]
        public ActionResult EditRoomAv(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }

            //DataContext db = new DataContext();


            return View(this.roomavService.Get(id));


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRoomAv(RoomAv roomAv)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.roomavService.Update(roomAv);
                return RedirectToAction("AvailableRoom");
            }
            else
            {
                return View(roomAv);
            }
        }
        [HttpGet]
        public ActionResult DetailsRoomAv(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            DataContext db = new DataContext();
            RoomAv roomlist = db.Roomavs.SingleOrDefault(x => x.RoomAvId == id);
            RoomAvModel roomAvModel = new RoomAvModel();
            roomAvModel.RoomAvId = roomlist.RoomAvId;
            roomAvModel.Catagory = roomlist.Room.Catagory;
            roomAvModel.Rent = roomlist.Room.Rent;
            return View(roomAvModel);
        }

     [HttpGet]
        public ActionResult DeleteRoomAv(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.roomavService.Get(id));
        }

        [HttpPost, ActionName("DeleteRoomAv")]
        public ActionResult DeleteConfirmedRoomAv(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            this.roomavService.Delete(id);
            return RedirectToAction("AvailableRoom");
        }


        // Employee Start -------------------------------------------------------------------
        public ActionResult Employees()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.empService.GetAll());
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.empService.Insert(emp);
                return RedirectToAction("Employees");
            }
            else
            {
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.empService.Get(id));
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.empService.Update(emp);
                return RedirectToAction("Employees");
            }
            else
            {
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult DetailsEmployee(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.empService.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.empService.Get(id));
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmedEmployee(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            this.empService.Delete(id);
            return RedirectToAction("Employees");
        }
        // Employee End -------------------------------------------------------------------

        





        //*********************************************************************************//*/







        // Room Start -------------------------------------------------------------------*/
        public ActionResult Rooms()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.roomService.GetAll());
        }

        [HttpGet]
        public ActionResult CreateRoom()
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoom(Room room)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.roomService.Insert(room);
                return RedirectToAction("Rooms");
            }
            else
            {
                return View(room);
            }
        }

        [HttpGet]
        public ActionResult EditRoom(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.roomService.Get(id));
        }

        [HttpPost]
        public ActionResult EditRoom(Room room)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            if (ModelState.IsValid)
            {
                this.roomService.Update(room);
                return RedirectToAction("Rooms");
            }
            else
            {
                return View(room);
            }
        }

        [HttpGet]
        public ActionResult DetailsRoom(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.roomService.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteRoom(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            return View(this.roomService.Get(id));
        }

        [HttpPost, ActionName("DeleteRoom")]
        public ActionResult DeleteConfirmedRoom(int id)
        {
            if (Session["logedIn"] == null)
            {
                return Redirect("/unauthorized");
            }
            this.roomService.Delete(id);
            return RedirectToAction("Rooms");
        }
       
        // Room End -------------------------------------------------------------------

        public ActionResult UpdateCustomerBalance(int paid, int cid)
        {
            float remaining = 0;

            UserBalance ub = this.UserBalanceService.GetByCustomer(cid);
            remaining = ub.UserBalanceAmount - paid;


            return Json(new { result = remaining }, JsonRequestBehavior.AllowGet);
        }

       
    }
}