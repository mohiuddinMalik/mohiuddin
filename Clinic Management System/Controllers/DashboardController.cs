using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard



        Database1Entities db = new Database1Entities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin_login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_login(Admin a)
        {
            var list = db.Admins.Where(x => x.User_Name == a.User_Name && x.Password == a.Password).FirstOrDefault();
            if (list != null)
            {
                Session["AdminId"] = list.Id;
                Session["AdminName"] = list.Name;
                return View("Index");

            }
            else
            {
                ViewBag.msg = "Login Failed!";
                return View(a);
            }

        }

        public ActionResult Admin_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_Create(Admin a)
        {

            if (ModelState.IsValid)
            {

                db.Admins.Add(a);

                db.SaveChanges();

                return RedirectToAction("Admin_Create");

            }

            return View(a);
        }


        public ActionResult Admin_Edit()
        {
            int Admin_id = int.Parse(Session["AdminId"].ToString());
            Admin a = db.Admins.Find(Admin_id);

            if (a == null)
            {

                return HttpNotFound();

            }

            return View(a);
        }

        [HttpPost]
        public ActionResult Admin_Edit(Admin a)
        {
            if (ModelState.IsValid)
            {

                db.Entry(a).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(a);
        }


        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Admin_login");
        }

        ////Contact Starts From Here

        public ActionResult Contact_List()
        {
            return View(db.Contacts.ToList());
        }

        ////Feedback Starts From Here

        public ActionResult Feedback_List()
        {
            return View(db.Feedbacks.ToList());
        }

        ////User Starts From Here 

        public ActionResult User_List()
        {
            return View(db.Users.ToList());
        }

        ////Education Starts From Here        

        public ActionResult Education_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Education_Create(Education a)
        {
            if (ModelState.IsValid)
            {

                db.Educations.Add(a);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(a);
        }

        public ActionResult Education_Delete(int? id)
        {
            Education e = db.Educations.Find(id);

            if (e == null)
            {

                return HttpNotFound();

            }

            return View(e);
        }

        [HttpPost]
        public ActionResult Education_Delete(int id, Education e)
        {
            e = db.Educations.Find(id);

            db.Educations.Remove(e);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Education_Edit(int? id)
        {
            Education e = db.Educations.Find(id);

            if (e == null)
            {

                return HttpNotFound();

            }

            return View(e);
        }

        [HttpPost]
        public ActionResult Education_Edit(Education e)
        {
            if (ModelState.IsValid)
            {

                db.Entry(e).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(e);
        }
        public ActionResult Education_List()
        {
            return View(db.Educations.ToList());
        }

        ////Seminar Starts From Here

        public ActionResult Seminar_Create()
        {
            ViewBag.E = new SelectList(db.Educations, "Id", "Type");
            ViewBag.S = new SelectList(db.Staffs, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Seminar_Create(Seminar s)
        {
            if (ModelState.IsValid)
            {

                db.Seminars.Add(s);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            else
            {
                ViewBag.E = new SelectList(db.Educations, "Id", "Id");
                ViewBag.S = new SelectList(db.Staffs, "Id", "Id");
                return View(s);
            }
        }

        public ActionResult Seminar_Delete(int? id)
        {
            Seminar s = db.Seminars.Find(id);

            if (s == null)
            {

                return HttpNotFound();

            }

            return View(s);
        }

        [HttpPost]
        public ActionResult Seminar_Delete(int? id, Seminar s)
        {
            s = db.Seminars.Find(id);

            db.Seminars.Remove(s);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Seminar_Edit(int? id)
        {
            Seminar s = db.Seminars.Find(id);

            if (s == null)
            {

                return HttpNotFound();

            }

            return View(s);
        }

        [HttpPost]
        public ActionResult Seminar_Edit(Seminar s)
        {
            if (ModelState.IsValid)
            {

                db.Entry(s).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(s);
        }

        public ActionResult Seminar_List()
        {
            //var z = db.Seminars.Include(x => x.Education).Include(x => x.Staff);

            return View(db.Seminars.ToList());
        }


        ////Lectures Start From Here

        public ActionResult Lecture_Create()
        {
            ViewBag.E = new SelectList(db.Educations, "Id", "Type");
            ViewBag.S = new SelectList(db.Staffs, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Lecture_Create(Lecture l)
        {
            if (ModelState.IsValid)
            {

                db.Lectures.Add(l);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            else
            {
                ViewBag.E = new SelectList(db.Educations, "Id", "Id");
                ViewBag.S = new SelectList(db.Staffs, "Id", "Id");
                return View(l);
            }
        }

        public ActionResult Lecture_Delete(int? id)
        {
            Lecture l = db.Lectures.Find(id);

            if (l == null)
            {

                return HttpNotFound();

            }

            return View(l);
        }

        [HttpPost]
        public ActionResult Lecture_Delete(int? id, Lecture l)
        {
            l = db.Lectures.Find(id);

            db.Lectures.Remove(l);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Lecture_Edit(int? id)
        {
            Lecture l = db.Lectures.Find(id);

            if (l == null)
            {

                return HttpNotFound();

            }

            return View(l);
        }

        [HttpPost]
        public ActionResult Lecture_Edit(Lecture l)
        {
            if (ModelState.IsValid)
            {

                db.Entry(l).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(l);
        }

        public ActionResult Lecture_List()
        {
            var z = db.Lectures.Include(x => x.Education).Include(x => x.Staff);
            return View(db.Lectures.ToList());
        }

        ////Pratical Conducted Starts from here

        public ActionResult Practical_Create()
        {
            ViewBag.E = new SelectList(db.Educations, "Id", "Type");
            ViewBag.S = new SelectList(db.Staffs, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Practical_Create(Practical_Conducted p)
        {
            if (ModelState.IsValid)
            {

                db.Practical_Conducted.Add(p);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            else
            {
                ViewBag.E = new SelectList(db.Educations, "Id", "Id");
                ViewBag.S = new SelectList(db.Staffs, "Id", "Id");
                return View(p);
            }
        }


        public ActionResult Practical_Delete(int? id)
        {
            Practical_Conducted p = db.Practical_Conducted.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Practical_Delete(int? id, Practical_Conducted p)
        {
            p = db.Practical_Conducted.Find(id);

            db.Practical_Conducted.Remove(p);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Practical_Edit(int? id)
        {
            Practical_Conducted p = db.Practical_Conducted.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }



        [HttpPost]
        public ActionResult Practical_Edit(Practical_Conducted p)
        {
            if (ModelState.IsValid)
            {

                db.Entry(p).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(p);
        }

        public ActionResult Practical_List()
        {
            var z = db.Practical_Conducted.Include(x => x.Education).Include(x => x.Staff);
            return View(db.Practical_Conducted.ToList());
        }

        ////Booking Starts From Here

        public ActionResult Lecture_Booking_List()
        {
            return View(db.Lecture_Booking.ToList());
        }

        public ActionResult Practical_Booking_List()
        {
            return View(db.Practical_Booking.ToList());
        }

        public ActionResult Seminar_Booking_List()
        {
            return View(db.Seminar_Booking.ToList());
        }


        //Invoice Starts From Here

        public ActionResult Invoice()
        {
            return View();
        }

        //Contact List Starts From Here

        //public ActionResult Contact_List()
        //{
        //    return View(db.Contacts.ToList());
        //}


        //Feedback List Starts From Here

        //public ActionResult Feedback_List()
        //{
        //    return View(db.Feedbacks.ToList());
        //}



        //Product Types Starts From Here

        public ActionResult Product_Type_Create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Product_Type_Create(Product_Type p)
        {
            if (ModelState.IsValid)
            {

                db.Product_Type.Add(p);

                db.SaveChanges();

                return RedirectToAction("Index");

            }



            return View(p);

        }


        public ActionResult Product_Type_Delete(int? id)
        {
            Product_Type p = db.Product_Type.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Product_Type(int? id, Product_Type p)
        {
            p = db.Product_Type.Find(id);

            db.Product_Type.Remove(p);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Product_Type_Edit(int? id)
        {
            Product_Type p = db.Product_Type.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }



        [HttpPost]
        public ActionResult Product_Type_Edit(Product_Type p)
        {
            if (ModelState.IsValid)
            {

                db.Entry(p).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(p);
        }

        public ActionResult Product_Type_List()
        {
            return View(db.Product_Type.ToList());
        }

        //Product Starts From Here

        public ActionResult Products_Create()
        {
            ViewBag.P = new SelectList(db.Product_Type, "Id", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Products_Create(Product p)
        {
            if (ModelState.IsValid)
            {

                db.Products.Add(p);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            else
            {
                ViewBag.P = new SelectList(db.Product_Type, "Id", "Id");

                return View(p);
            }
        }


        public ActionResult Products_Delete(int? id)
        {
            Product p = db.Products.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Products_Delete(int? id, Product p)
        {
            p = db.Products.Find(id);

            db.Products.Remove(p);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Products_Edit(int? id)
        {
            Product p = db.Products.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }



        [HttpPost]
        public ActionResult Products_Edit(Product p)
        {
            if (ModelState.IsValid)
            {

                db.Entry(p).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(p);
        }

        public ActionResult Products_List()
        {
            return View(db.Products.ToList());
        }


        //Purchases Starts From Here

        public ActionResult Purchases_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Purchases_Create(Purchase p)
        {
            if (ModelState.IsValid)
            {

                db.Purchases.Add(p);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(p);
        }


        public ActionResult Purchases_Delete(int? id)
        {
            Purchase p = db.Purchases.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }

        [HttpPost]
        public ActionResult Purchases_Delete(int? id, Purchase p)
        {
            p = db.Purchases.Find(id);

            db.Purchases.Remove(p);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Purchases_Edit(int? id)
        {
            Purchase p = db.Purchases.Find(id);

            if (p == null)
            {

                return HttpNotFound();

            }

            return View(p);
        }



        [HttpPost]
        public ActionResult Purchases_Edit(Purchase p)
        {
            if (ModelState.IsValid)
            {

                db.Entry(p).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(p);
        }

        public ActionResult Purchases_List()
        {
            return View(db.Purchases.ToList());
        }


        //Sales Starts Form Here

        public ActionResult Sales_List()
        {
            return View(db.Sales.ToList());
        }


        //Staff Starts From Here

        public ActionResult Staff_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Staff_Create(Staff a)
        {
            if (ModelState.IsValid)
            {

                db.Staffs.Add(a);

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(a);
        }

        public ActionResult Staff_Delete(int? id)
        {
            Staff e = db.Staffs.Find(id);

            if (e == null)
            {

                return HttpNotFound();

            }

            return View(e);
        }

        [HttpPost]
        public ActionResult Staff_Delete(int id, Staff e)
        {
            e = db.Staffs.Find(id);

            db.Staffs.Remove(e);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Staff_Edit(int? id)
        {
            Staff e = db.Staffs.Find(id);

            if (e == null)
            {

                return HttpNotFound();

            }

            return View(e);
        }

        [HttpPost]
        public ActionResult Staff_Edit(Staff e)
        {
            if (ModelState.IsValid)
            {

                db.Entry(e).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(e);
        }
        public ActionResult Staff_List()
        {
            return View(db.Staffs.ToList());
        }


        //Stock List Starts From Here

        public ActionResult Stocks_List()
        {
            return View(db.Stocks.ToList());
        }


       




    }
}