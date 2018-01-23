using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management.Controllers
{
    public class AdminController : Controller
    {
        private EmployeeRepository empRepo = new EmployeeRepository();
        private UserRepository userRepo = new UserRepository();
        private RoomRepository roomRepo = new RoomRepository();
        public ActionResult Index()
        {
            return View();
        }


        // Employee Start -------------------------------------------------------------------
        public ActionResult Employees()
        {
            return View(this.empRepo.GetAll());
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                this.empRepo.Insert(emp);
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
            return View(this.empRepo.Get(id));
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                this.empRepo.Update(emp);
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
            return View(this.empRepo.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            return View(this.empRepo.Get(id));
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmedEmployee(int id)
        {
            this.empRepo.Delete(id);
            return RedirectToAction("Employees");
        }
        // Employee End -------------------------------------------------------------------

        





        //*********************************************************************************//







        // Room Start -------------------------------------------------------------------
        public ActionResult Rooms()
        {
            return View(this.roomRepo.GetAll());
        }

        [HttpGet]
        public ActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                this.roomRepo.Insert(room);
                return RedirectToAction("Index");
            }
            else
            {
                return View(room);
            }
        }

        [HttpGet]
        public ActionResult EditRoom(int id)
        {
            return View(this.roomRepo.Get(id));
        }

        [HttpPost]
        public ActionResult EditRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                this.roomRepo.Update(room);
                return RedirectToAction("Index");
            }
            else
            {
                return View(room);
            }
        }

        [HttpGet]
        public ActionResult DetailsRoom(int id)
        {
            return View(this.roomRepo.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteRoom(int id)
        {
            return View(this.roomRepo.Get(id));
        }

        [HttpPost, ActionName("DeleteRoom")]
        public ActionResult DeleteConfirmedRoom(int id)
        {
            this.roomRepo.Delete(id);
            return RedirectToAction("Index");
        }
        // Room End -------------------------------------------------------------------







        //*********************************************************************************//







        // User Start -------------------------------------------------------------------
        public ActionResult Users()
        {
            return View(this.userRepo.GetAll());
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User User)
        {
            if (ModelState.IsValid)
            {
                this.userRepo.Insert(User);
                return RedirectToAction("Index");
            }
            else
            {
                return View(User);
            }
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            return View(this.userRepo.Get(id));
        }

        [HttpPost]
        public ActionResult EditUser(User User)
        {
            if (ModelState.IsValid)
            {
                this.userRepo.Update(User);
                return RedirectToAction("Index");
            }
            else
            {
                return View(User);
            }
        }

        [HttpGet]
        public ActionResult DetailsUser(int id)
        {
            return View(this.userRepo.Get(id));
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View(this.userRepo.Get(id));
        }

        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteConfirmedUser(int id)
        {
            this.userRepo.Delete(id);
            return RedirectToAction("Index");
        }
        // User End -------------------------------------------------------------------
    }
}