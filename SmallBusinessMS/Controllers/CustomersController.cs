using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmallBussinessMS.BLL;
using SmallBussinessMS.DatabaseContext;
using SmallBussinessMS.Models;

namespace SmallBusinessMS.Controllers
{
    public class CustomersController : Controller
    {
        private SBMSDbContext db = new SBMSDbContext();

        CustomerManager _customerManager = new CustomerManager();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {

            try
            {
                if (customer.UploadFiles != null && customer.UploadFiles[0] != null)
                {
                    var customerFiles = new List<CustomerFile>();
                    foreach (var uploadFile in customer.UploadFiles)
                    {
                        var customerFile = new CustomerFile();
                        var fileByte = new byte[uploadFile.ContentLength];
                        uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                        customerFile.File = fileByte;
                        customerFile.FileName = uploadFile.FileName;

                        customerFiles.Add(customerFile);
                    }

                    customer.CustomerFiles = customerFiles;

                }
                var isSaved = _customerManager.Save(customer);

                if (isSaved)
                {
                    ViewBag.SMsg = "Saved Successful";
                }
                else
                {
                    ViewBag.FMsg = "Save Failed";
                }

            }
            catch (Exception e)
            {
                ViewBag.FMsg = e.Message;

            }

            return RedirectToAction("ShowCustomers");

        }
        //public ActionResult ShowCustomers(Customer customer)
        //{
        //    var datalist = _customerManager.GetAll();
        //    return View(datalist);
        //}

        public ActionResult ShowCustomers(string search)
        {
            return View(db.Customers.Where(c=>c.Email.Contains(search) || search == null).ToList());
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Code,Name,Address,Email,Contact,LoyalityPoint,CustomerFiles")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var isUpdate = _customerManager.Update(customer);

                if (isUpdate)
                {
                    ViewBag.SMsg = "Updated Successful";
                }
                else
                {
                    ViewBag.FMsg = "Update Failed";
                }
            }
            return RedirectToAction("Create");
        }
        //public ActionResult Create(Customer customer)
        //{
        //    if (ModelState.IsValid && customer.CustomerDetailses != null && customer.CustomerDetailses.Count > 0)
        //    {
        //        if (customer.UploadFiles != null && customer.UploadFiles[0] != null)
        //        {
        //            var customerFiles = new List<CustomerFile>();
        //            foreach (var uploadFile in customer.UploadFiles)
        //            {
        //                var customerFile = new CustomerFile();
        //                var fileByte = new byte[uploadFile.ContentLength];
        //                uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
        //                customerFile.File = fileByte;
        //                customerFile.FileName = uploadFile.FileName;

        //                customerFiles.Add(customerFile);
        //            }

        //            customer.CustomerFiles = customerFiles;

        //        }



        //        var isSaved = _customerManager.Save(customer);
        //        if (isSaved)
        //        {
        //            return View(customer);
        //        }
        //    }
        //    return View();

        //}




        //[HttpPost]
        //public ActionResult Update(Customer model)
        //{

        //    try
        //    {
        //        var isUpdate = _customerManager.Update(model);

        //        if (isUpdate)
        //        {
        //            ViewBag.SMsg = "Updated Successful";
        //        }
        //        else
        //        {
        //            ViewBag.FMsg = "Update Failed";
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.FMsg = e.Message;

        //    }

        //    return View();

        //}



        //[HttpPost]
        //public ActionResult Delete(Customer model)
        //{

        //    try
        //    {
        //        var isDelete = _customerManager.Delete(model);

        //        if (isDelete)
        //        {
        //            ViewBag.SMsg = "Deleted Successful";
        //        }
        //        else
        //        {
        //            ViewBag.FMsg = "Deletion Failed";
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.FMsg = e.Message;

        //    }

        //    return View();

        //}

        //// GET: Customers
        //public ActionResult Index()
        //{
        //    return View(db.Customers.ToList());
        //}

        // GET: Customers/Details/5


        //// GET: Customers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Customers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Code,Name,Address,Email,Contact,LoyalityPoint,File")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Customers.Add(customer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(customer);
        //}

        //// GET: Customers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        //// POST: Customers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Code,Name,Address,Email,Contact,LoyalityPoint,File")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(customer);
        //}

        //// GET: Customers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    db.Customers.Remove(customer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
