using POS.DAL;
using POS.Model;
using POS.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Web.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            //list Category
            ViewBag.listCategories = new SelectList(CategoriesDAL.GetData(), "ID", "Name");
            //list Inventory
            ViewBag.listInventory = new SelectList(ItemsIventoryDAL.GetData(), "ID", "VariantName");

            List<ListItemViewModel> models = ItemDAL.GetData();
            return View(models);
        }

        public ActionResult Load()
        {
            List<ListItemViewModel> models = ItemDAL.GetData();
            return PartialView("_Index", models);
        }
        public ActionResult Add()
        {
            ViewBag.listCategories = new SelectList(CategoriesDAL.GetData(), "ID", "Name");
            ItemsViewModel models = new ItemsViewModel();
            return PartialView("Add", models);
        }

        public ActionResult AddVariant()
        {
            ItemsVariantViewModel model = new ItemsVariantViewModel();
            return PartialView("AddVariant", model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddVariant(ItemsVariantViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (POSContext db= new POSContext())
        //        {
        //            Model.ItemsVariant item = new ItemsVariant() { 
        //                ItemID = model.ItemID,
        //                VariantName = model.VariantName,
        //                SKU = model.SKU,
        //                Price = model.Price,
        //                OutletID = 1, // ganti
        //                ModifiedBy = 1, // ganti
        //                ModifiedOn = DateTime.Now,
        //                CreatedBy = 1,
        //                CreatedOn = DateTime.Now,
        //            };
        //        }
        //    }
        //    return PartialView("AddVariant", model);
        //}

        public ActionResult MngInventory()
        {
            ItemsIventoryViewModel model = new ItemsIventoryViewModel();
            return PartialView("MngInventory", model);
        }
        public ActionResult GetItem(int categoryID)
        {
            List<ItemsViewModel> models = ItemDAL.GetDataByCategoryID(categoryID);
            return PartialView("_Index", models);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ItemsViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        int UserId = User.Identity.GetUserId<int>();
                        int OutletId = 0;
                        OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
                        Items data = new Items()
                        {
                            Name = model.Name,
                            CategoryID = model.CategoryID,
                            Description = model.Description,
                            CreatedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = UserId,
                            ModifiedOn = DateTime.Now
                        };
                        context.TItems.Add(data);
                        try { context.SaveChanges(); }
                        catch (Exception) { }
                        int i = 0;
                        foreach (var detail in model.VariantNameList)
                        {
                            ItemsVariant data2 = new ItemsVariant()
                            {
                                ItemID = data.ID,
                                VariantName = detail,
                                OutletID = OutletId,
                                SKU = model.VariantSKU[i],
                                Price = model.VariantPrice[i],
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now
                            };
                            context.TItemsVariant.Add(data2);
                            try { context.SaveChanges(); }
                            catch (Exception) { }

                            ItemsIventory data3 = new ItemsIventory()
                            {
                                VariantID = data2.ID,
                                Beginning = model.Beginning[i],
                                PurchaseOrder = 0,
                                Sales = 0,
                                Transfer = 0,
                                Adjusment = 0,
                                Ending = model.Beginning[i],
                                AlertAt = model.AlertAt[i],
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now
                            };
                            context.TItemsIventory.Add(data3);
                            try { context.SaveChanges(); }
                            catch (Exception) { }

                            i++;
                        }

                        try
                        {
                            dbTransaction.Commit();
                            return RedirectToAction("Index");
                        }
                        catch (Exception)
                        {
                            dbTransaction.Rollback();
                        }

                    }
                }
            }
            return PartialView("Add", model);
        }

        public ActionResult Edit(int Id)
        {
            //list Category
            ViewBag.listCategories = new SelectList(CategoriesDAL.GetData(), "ID", "Name");
            //list Inventory
            ViewBag.listInventory = new SelectList(ItemsIventoryDAL.GetData(), "ID", "VariantName");

            ListItemViewModel model = ItemDAL.GetDataById(Id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ListItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        int UserId = User.Identity.GetUserId<int>();
                        int OutletId = 0;
                        OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
                        Items data = context.TItems.Where(x => x.ID == model.ID).FirstOrDefault();
                        if (data != null)
                        {
                            data.Name = model.Name;
                            data.CategoryID = model.CategoryId;
                            data.Description = model.Description;
                            data.CreatedBy = UserId;
                            data.CreatedOn = DateTime.Now;
                            data.ModifiedBy = UserId;
                            data.ModifiedOn = DateTime.Now;
                        }

                        try { context.SaveChanges(); }
                        catch (Exception) { }
                        int i = 0;
                        foreach (var item in model.VariantId)
                        {
                            ItemsVariant data2 = context.TItemsVariant.Where(x => x.ID == item).FirstOrDefault();
                            if(data2!=null)
                            {
                                data2.VariantName = model.VariantName[i];
                                data2.Price = model.VariantPrice[i];
                                data2.SKU = model.VariantSKU[i];
                                data2.CreatedBy = UserId;
                                data2.CreatedOn = DateTime.Now;
                                data2.ModifiedBy = UserId;
                                data2.ModifiedOn = DateTime.Now;
                            };
                            try { context.SaveChanges(); }
                            catch (Exception) { }
                           
                            i++;
                        }
                         i = 0;
                        foreach (var item in model.InventoryId)
                        {
                             ItemsIventory data3 = context.TItemsIventory.Where(x => x.ID == item).FirstOrDefault();
                            if(data3!=null)
                            {
                                data3.Beginning = model.Beginning[i];
                                data3.AlertAt = model.AlertAt[i];
                                data3.CreatedBy = UserId;
                                data3.CreatedOn = DateTime.Now;
                                data3.ModifiedBy = UserId;
                                data3.ModifiedOn = DateTime.Now;
                            }
                            try { context.SaveChanges(); }
                            catch (Exception) { }
                            i++;
                        }
                        try
                        {
                            dbTransaction.Commit();
                            return RedirectToAction("Index");
                        }
                        catch (Exception)
                        {
                            dbTransaction.Rollback();
                        }

                    }
                }
            }
            return PartialView("Edit", model);
        }

    }
}