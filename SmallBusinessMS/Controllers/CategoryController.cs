using System;
using System.Linq;
using System.Web.Mvc;
using SmallBussinessMS.BLL;
using SmallBussinessMS.DatabaseContext;
using SmallBussinessMS.Models;


namespace SmallBussinessMS.Controllers
{
    public class CategoryController : Controller
    {
        SBMSDbContext db = new SBMSDbContext();

        CategoryManager _categoryManager = new CategoryManager();
        
        

        [HttpGet]
        public ActionResult Create()
        {
            var datalist=_categoryManager.GetAll();
            return View(datalist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            try
            {
                         
                if (ModelState.IsValid)
                {

                    var isAdded = _categoryManager.Create(model);
                  
                    if (isAdded)
                    {
                        ViewBag.SMsg = "Save Successfully";
                    }

                    else
                    {
                        ViewBag.FMsg = "Save Failed";
                    }
                }
             

                return View(_categoryManager.GetAll());
              

            }
            catch (Exception e)
            {

                ViewBag.FMsg = e.Message;
            }

            
            return View(_categoryManager.GetAll());

        }
        //public JsonResult CheckCode(string code)
        //{
        //    System.Threading.Thread.Sleep(200);
        //    var SearchCode = db.Categories.Where(c => c.Code == code).SingleOrDefault();

        //    if (SearchCode != null)
        //    {
        //        return Json(1);
        //    }
        //    else
        //    {
        //        return Json(0);
        //    }
        //}
        public ActionResult Delete(int id )
        {
            bool isDeleted = false;
           Category  category = _categoryManager.GetCategoryById(id);
            if (category != null)
            {
                isDeleted = _categoryManager.Delete(category);
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

        [HttpGet]
        public ActionResult Update(int? id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Code,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                var isUpdate = _categoryManager.Update(category);

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


       
    }
}