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
    public class AdjustmentController : Controller
    {
        // GET: Adjustment
        public ActionResult Index()
        {
            List<AdjustmentViewModel> model = AdjustmentDAL.GetData();
            return View(model);
        }

        public ActionResult Add()
        {
            var UserId = User.Identity.GetUserId();
            ViewBag.Transfer = new SelectList(EmployeeOutletDAL.GetDataByID(int.Parse(UserId)), "ID", "OutletName");
            AdjustmentViewModel model = new AdjustmentViewModel();
            return PartialView("Add", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AdjustmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        AdjusmentStock item = new AdjusmentStock()
                        {
                            ID = model.ID,
                            OutletID = 1,
                            Note = model.Note,
                            CreatedBy = 1,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = 1,
                            ModifiedOn = DateTime.Now,
                        };
                        context.TAdjusmentStock.Add(item);
                        try { context.SaveChanges(); }
                        catch (Exception) { }

                        int i = 0;
                        foreach (var detail in model.VariantName)
                        {
                            AdjusmentStockDetail item2 = new AdjusmentStockDetail() 
                            {
                                HeaderID=item.ID,
                                ActualStock=model.ActualStock,
                                InStock=model.InStock,
                                CreatedBy = 1,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = 1,
                                ModifiedOn = DateTime.Now,
                            };
                            context.TAdjusmentStockDetail.Add(item2);
                            i++;                                    //masih kurang satu tabel lagi buat save
                        }                                           //yaitu tabel tabel ItemsInventory di adjustment dgn rumus actual-instock
                        try { context.SaveChanges(); }
                        catch (Exception) { }

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
            return PartialView("Add",model);
        }
    }
}