using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.Model;
using POS.DAL;
using Microsoft.AspNet.Identity;

namespace POS.Web.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            List<CategoriesViewModel> model = CategoriesDAL.GetData();
            // karena kita mau menampilkan list category berdasarkan outlet iD maka kita membuat ViewBag untuk outlet ID
            // jadi prosesnya : kita menginstansiasi select list baru dari method GetData pada OUtletDAL yang nanti kita ambil nilai ID dan Name nya
            ViewBag.ListOutlet = new SelectList(OutletDAL.GetData(), "ID", "OutletName");
            return View(model);
        }
        //==================================================Membuat fungsi load======================================================================//
        public ActionResult Load()
        {
            List<CategoriesViewModel> model = CategoriesDAL.GetData();
            return PartialView("_index", model);
        }
        //================================Mendefinisikan method baru untuk menampilkan list categories berdasarkan outlet yang akan kita pilih========================//
        public ActionResult GetCategory(int idOutlet)
        {
            List<CategoriesViewModel> model = CategoriesDAL.GetDataByOutletId(idOutlet);
            return PartialView("_index", model);
        }
        //==================================================================================//
        //pada penambahan Categories kita tambahkan berdasarkan outlet Id
        //==================================================================================//
        public ActionResult Add()
        {
            CategoriesViewModel model = new CategoriesViewModel();
            return PartialView("Add", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoriesViewModel model)
        {
            int UserId = User.Identity.GetUserId<int>();
            if (ModelState.IsValid)
                using (POSContext context = new POSContext())
                {
                    bool isSave = false;
                    var VOutlet = context.TOutlet.ToList();
                    foreach (var item in VOutlet)
                    {
                        Categories Kategori = new Categories()
                        {
                            Name = model.Name,
                            OutletID = item.ID,
                            CreatedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = UserId,
                            ModifiedOn = DateTime.Now,
                        };
                        context.TCategories.Add(Kategori);
                        try
                        {
                            context.SaveChanges();
                            isSave = true;

                        }
                        catch (Exception)
                        {
                            isSave = false;
                        }
                    }
                    if (isSave == true) { return RedirectToAction("Index"); }

                }
            return PartialView("Add", model);
        }

        //menampilkan list items yang akan kita tampilkan
        public ActionResult GetItems(int categoryID, int outletId)
        {
            CategoriesViewModel model = CategoriesDAL.GetDataById(categoryID);
            model.ID = categoryID;
            ViewBag.ListItems = CategoriesDAL.GetItemsData(outletId);
            return PartialView("ListItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // ListItems yang akan diambil ini disesuaikan dengan kategori ID
        public ActionResult UpdateItems(CategoriesViewModel models)
        {

            using (POSContext context = new POSContext())
            {
                int i = 0;
                //var userId = User.Identity.GetUserId<int>();
                //int OutletId = 0;

                foreach (var item in models.ItemID)
                {
                    Items data = context.TItems.Where(x => x.ID == item).FirstOrDefault();
                    if (data != null)
                    {
                        data.CategoryID = models.ID;
                    }
                    i++;
                }
                try
                {
                    context.SaveChanges();
                    return RedirectToAction("Index"); ;
                }
                catch (Exception) { throw; };
            }
        }

        //==================================================================Untuk Mengedit Kategori====================================================//
        public ActionResult Edit(int id)
        {
            CategoriesViewModel model = CategoriesDAL.GetDataById(id);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesViewModel model)
        {
            int UserId = User.Identity.GetUserId<int>();
            if (ModelState.IsValid)
                using (POSContext context = new POSContext())
                {
                    bool isSave = false;
                    var VOutlet = context.TOutlet.ToList();
                    foreach (var item in VOutlet)
                    {
                        Categories Kategori = context.TCategories.Where(m => m.Name == model.Name).FirstOrDefault();

                        Kategori.Name = model.Name2;
                        Kategori.CreatedBy = UserId;
                        Kategori.CreatedOn = DateTime.Now;
                        Kategori.ModifiedBy = UserId;
                        Kategori.ModifiedOn = DateTime.Now;

                        try
                        {
                            context.SaveChanges();
                            isSave = true;

                        }
                        catch (Exception)
                        {
                            isSave = false;
                        }
                    }
                    if (isSave == true) { return RedirectToAction("Index"); }

                }
            return PartialView("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            CategoriesViewModel model = CategoriesDAL.GetDataById(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriesViewModel model)
        {
            if (ModelState.IsValid)
                using (POSContext context = new POSContext())
                {
                    bool isSave = false;
                    var VOutlet = context.TOutlet.ToList();
                    foreach (var item in VOutlet)
                    {
                        Categories Kategori = context.TCategories.Where(m => m.Name == model.Name).FirstOrDefault();
                        context.TCategories.Remove(Kategori);
                        try
                        {
                            context.SaveChanges();
                            isSave = true;

                        }
                        catch (Exception)
                        {
                            isSave = false;
                        }
                    }
                    if (isSave == true) { return RedirectToAction("Index"); }

                }
            return PartialView("Delete", model);
        }
    }
}