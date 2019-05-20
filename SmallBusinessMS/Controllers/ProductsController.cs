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
    public class ProductsController : Controller
    {
        private SBMSDbContext db = new SBMSDbContext();

        ProductManager _productManager = new ProductManager();
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");

            var datalist = _productManager.GetAll();
            return View(datalist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
                
                if (ModelState.IsValid)
                {
                    if (product.UploadFiles != null && product.UploadFiles[0] != null)
                    {
                        var productFiles = new List<ProductFile>();
                        foreach (var uploadFile in product.UploadFiles)
                        {
                            var productFile = new ProductFile();
                            var fileByte = new byte[uploadFile.ContentLength];
                            uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                            productFile.File = fileByte;
                            productFile.FileName = uploadFile.FileName;

                            productFiles.Add(productFile);
                        }

                        product.ProductFiles = productFiles;

                    }

                    var isAdded = _productManager.Create(product);

                    if (isAdded)
                    {
                        ViewBag.SMsg = "Save Successfully";
                    }

                    else
                    {
                        ViewBag.FMsg = "Save Failed";
                    }
                }


                return View(_productManager.GetAll());


            }
            catch (Exception e)
            {

                ViewBag.FMsg = e.Message;
            }


            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);

            return View(product);

        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            Product product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Code,Name,CategoryId,ReoderLevel,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                var isUpdate = _productManager.Update(product);

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
        public ActionResult Delete(int id)
        {
            bool isDeleted = false;
            Product product = _productManager.GetProductById(id);
            if (product != null)
            {
                isDeleted = _productManager.Delete(product);
            }
            if (isDeleted)
            {
                ViewBag.DMsg = "Deleted";
            }
            else
            {
                ViewBag.FMsg = "not deleted";
            }

            return RedirectToAction("Create");

        }

        // GET: Products
        //public ActionResult Index()
        //{
        //    var products = db.Products.Include(p => p.Category);
        //    return View(products.ToList());
        //}

        // GET: Products/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        // GET: Products/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
        //    return View();
        //}

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Code,Name,CategoryId,ReoderLevel,Description")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
        //    return View(product);
        //}

        // GET: Products/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Code,Name,CategoryId,ReoderLevel,Description")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", product.CategoryId);
        //    return View(product);
        //}

        // GET: Products/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
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
