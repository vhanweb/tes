using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.DAL;
using POS.ViewModel;
using POS.Model;
using Microsoft.AspNet.Identity;

namespace POS.Web.Controllers
{
    [Authorize]
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        // membuat tampilan index
        public ActionResult Index()
        {
            List<SuppliersViewModel> model = SuppliersDAL.GetData();
            return View(model);
        }
        // membuat fungsi load 
        public ActionResult Load()
        {
            List<SuppliersViewModel> model = SuppliersDAL.GetData();
            return PartialView("_index", model);
        }
        // membuat fung add
        public ActionResult Add()
        {
            ViewBag.ListProvince = new SelectList(ProvinceDAL.GetData(), "ID", "ProvinceName");
            ViewBag.ListRegion = new SelectList(string.Empty, "", "");
            ViewBag.ListDistrict = new SelectList(string.Empty, "", "");
            SuppliersViewModel model = new SuppliersViewModel();
            return PartialView("Add", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(SuppliersViewModel model)
        {
            var userId = User.Identity.GetUserId<int>();
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    Suppliers item = new Suppliers()
                    {
                        ID = model.ID,
                        Name=model.Name,
                        Address = model.Address,
                        ProvinceID = model.ProvinceID,
                        RegionID = model.RegionID,
                        DistrictID = model.DistrictID,
                        PostalCode = model.PostalCode,
                        Phone = model.Phone,
                        Email = model.Email,
                        CreatedBy = userId,
                        CreatedOn= DateTime.Now,
                        ModifiedBy=userId,     
                        ModifiedOn=DateTime.Now,     
                    };
                    context.TSuppliers.Add(item);
                    try
                    {
                        context.SaveChanges();
                        return Json(new { success = "true" });
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return PartialView("Add", model);
        }
        // ini diguunakan untuk edit

        public ActionResult Edit(int Id)
        {
            SuppliersViewModel model = SuppliersDAL.GetDataByID(Id);
            ViewBag.ListProvince = new SelectList(ProvinceDAL.GetData(), "ID", "ProvinceName");
            ViewBag.ListRegion = new SelectList(string.Empty, "", "");
            ViewBag.ListDistrict = new SelectList(string.Empty, "", "");
            
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersViewModel model)
        {
            int UserId = User.Identity.GetUserId<int>();
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    Suppliers item = context.TSuppliers.Where(x => x.ID == model.ID).FirstOrDefault();

                    item.ID = model.ID;
                    item.Name = model.Name;
                    item.Address = model.Address;
                    item.ProvinceID = model.ProvinceID;
                    item.RegionID = model.RegionID;
                    item.DistrictID = model.DistrictID;
                    item.Email = model.Email;
                    item.Phone = model.Phone;
                    item.CreatedOn = DateTime.Now;
                    item.CreatedBy = UserId;
                    item.ModifiedOn = DateTime.Now;
                    item.ModifiedBy = UserId;

                    try
                    {
                        context.SaveChanges();
                        return Json(new { success = true });
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return PartialView("Edit", model);
        }
        public ActionResult Detail(int id)
        {
            SuppliersViewModel model = SuppliersDAL.GetDataByID(id);
            return PartialView("Detail", model);
        }

        public ActionResult Delete (int id)
        {
            SuppliersViewModel model = SuppliersDAL.GetDataByID(id);
            return PartialView("Delete", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (SuppliersViewModel model)
        {
            using (POSContext context = new POSContext())
            {
                Suppliers item = context.TSuppliers.Where(x => x.ID == model.ID).FirstOrDefault();
                context.TSuppliers.Remove(item);

                try
                {
                    context.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}