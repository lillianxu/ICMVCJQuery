using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICMVCJQuery.Models;

namespace ICMVCJQuery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StaffManagement()
        {
            return View();
        }

        public ActionResult GetStaffList()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var staffList = db.People.Select(x => new StaffData { staffId = x.PersonId, firstName = x.FirstName.Trim(), lastName = x.LastName.Trim(),address1=x.Address1.Trim(), address2 = x.Address2.Trim(),personTypeID=x.PersonTypeId }).ToList();
            return View(staffList);

        }

        public ActionResult UpdateStaff(StaffData staffData)
        {

            // add code here to update the database with the changed staffid data
            IC_MotersEntities db = new IC_MotersEntities();
            var newStaff = db.People.Find(staffData.staffId);
          
                newStaff.PersonId = staffData.staffId;
                newStaff.FirstName = staffData.firstName.Trim();
                newStaff.LastName = staffData.lastName.Trim();
                newStaff.Address1 = staffData.address1.Trim();
                
            
            db.SaveChanges();
            return Json(new { success = true });
        }


        public ActionResult AddStaff()
        {
            return View();
        }
        public ActionResult AddSaveStaff(StaffData staffData)
        {

            // add code here to update the database with the changed staffid data
            IC_MotersEntities db = new IC_MotersEntities();
            Person newStaff = new Person();
            newStaff.PersonId = staffData.staffId;
            newStaff.FirstName = staffData.firstName.Trim();
            newStaff.LastName = staffData.lastName.Trim();
            newStaff.Address1 = staffData.address1.Trim();
            newStaff.PersonTypeId = staffData.personTypeID;
            //newStaff.PersonTypeId = 2;
            newStaff.SuburbId = 3;
            newStaff.PhoneNumber = "0291267788";
            db.People.Add(newStaff);
            db.SaveChanges();
            return Json(new { success = true });
        }

        public ActionResult CustomerManagement()
        {
            return View();
        }
        public ActionResult GetCustomerList()
        {
            IC_MotersEntities db = new IC_MotersEntities();
            var customerList = db.People.Where(c=>c.PersonTypeId!=4).Select(x => new StaffData { staffId = x.PersonId, firstName = x.FirstName.Trim(), lastName = x.LastName.Trim(), address1 = x.Address1.Trim(), address2 = x.Address2.Trim() }).ToList();
            return View(customerList);

        }

        // for search function
        public ActionResult SearchAct()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SearchAct(string nameToFind)
        {
            ViewBag.SearchKey = nameToFind;

            IC_MotersEntities db = new IC_MotersEntities();

            var selectedStaff1 = db.People.Where(x => x.LastName == nameToFind).Select(x => new StaffData
            {
                firstName = x.FirstName,
                lastName = x.LastName,
                staffId = x.PersonId,
               address1 = x.Address1,
                address2 = x.Address2,
                
            }).ToList();
            return View(selectedStaff1);
        }

    }
}