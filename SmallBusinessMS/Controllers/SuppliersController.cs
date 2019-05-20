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
    public class SuppliersController : Controller
    {
        private SBMSDbContext db = new SBMSDbContext();
        SupplierManager _supplierManager = new SupplierManager();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {

            try
            {
                if (supplier.UploadFiles != null && supplier.UploadFiles[0] != null)
                {
                    var supplierFiles = new List<SupplierFile>();
                    foreach (var uploadFile in supplier.UploadFiles)
                    {
                        var supplierFile = new SupplierFile();
                        var fileByte = new byte[uploadFile.ContentLength];
                        uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                        supplierFile.File = fileByte;
                        supplierFile.FileName = uploadFile.FileName;

                        supplierFiles.Add(supplierFile);
                    }

                    supplier.SupplierFiles = supplierFiles;

                }
                var isSaved = _supplierManager.Save(supplier);

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

            return View();

        }
        //public ActionResult ShowSuppliers(Supplier supplier)
        //{
        //    var datalist = _supplierManager.GetAll();
        //    return View(datalist);
        //}
        public ActionResult ShowSuppliers(string search)
        {
            return View(db.Suppliers.Where(c => c.Email.Contains(search) || search == null).ToList());
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Code,Name,Address,Email,Contact,ContactPerson,SupplierFile")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var isUpdate = _supplierManager.Update(supplier);

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

        //// GET: Suppliers
        //public ActionResult Index()
        //{
        //    return View(db.Suppliers.ToList());
        //}

        //// GET: Suppliers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Supplier supplier = db.Suppliers.Find(id);
        //    if (supplier == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(supplier);
        //}

        //// GET: Suppliers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Suppliers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Code,Name,Address,Email,Contact,ContactPerson")] Supplier supplier)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Suppliers.Add(supplier);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(supplier);
        //}

        //// GET: Suppliers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Supplier supplier = db.Suppliers.Find(id);
        //    if (supplier == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(supplier);
        //}

        //// POST: Suppliers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Code,Name,Address,Email,Contact,ContactPerson")] Supplier supplier)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(supplier).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(supplier);
        //}

        //// GET: Suppliers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Supplier supplier = db.Suppliers.Find(id);
        //    if (supplier == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(supplier);
        //}

        //// POST: Suppliers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Supplier supplier = db.Suppliers.Find(id);
        //    db.Suppliers.Remove(supplier);
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
