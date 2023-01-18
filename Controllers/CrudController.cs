using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class CrudController : Controller
    {
        CruddbEntities1 dbobj = new CruddbEntities1();
        // GET: Crud
        public ActionResult Create()  //for display
        {
            return View();
        }
        [HttpPost]
        public ActionResult StoreData(tblcrud Model)  // for storing data into db 
        {
            tblcrud tblobj= new tblcrud(); // table object
            tblobj.First_Name = Model.First_Name;
            tblobj.Last_Name= Model.Last_Name;
            tblobj.Mobile_No= Model.Mobile_No;
            tblobj.Email_Id=Model.Email_Id;
            tblobj.Gender= Model.Gender;
            tblobj.City= Model.City;
            tblobj.Hobbies= Model.Hobbies;
            tblobj.About= Model.About;

            dbobj.tblcruds.Add(tblobj);
            dbobj.SaveChanges();
            return View("Read");
        }

        public ActionResult Read()// this is for select operation
        {
            var data = dbobj.tblcruds.ToList();
            return View(data);
        }

        public ActionResult Update(int id)
        {
            var data = dbobj.tblcruds.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id,tblcrud Model)
        {
            var data = dbobj.tblcruds.FirstOrDefault(x => x.Id == id);
            if(data!=null)
            {
                data.First_Name = Model.First_Name;
                data.Last_Name=Model.Last_Name;
                data.Mobile_No = Model.Last_Name;
                data.Email_Id = Model.Email_Id;
                data.Gender = Model.Gender;
                data.City = Model.City;
                data.Hobbies = Model.Hobbies;
                data.About = Model.About;
                dbobj.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var data = dbobj.tblcruds.FirstOrDefault(x => x.Id == id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var data = dbobj.tblcruds.FirstOrDefault(x => x.Id == id);
            if(data!=null)
            {
                dbobj.tblcruds.Remove(data);
                dbobj.SaveChanges();
                return RedirectToAction("Read");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var data=dbobj.tblcruds.FirstOrDefault(x=>x.Id== id);
            return View(data);
        }

    }

    
}