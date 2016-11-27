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
            return View("Index", model);
        }

        public ActionResult load()
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletid(OutletId);
            return PartialView("_ListAdj", model);
        }

        public ActionResult Add()
        {
            var UserId = User.Identity.GetUserId();

            ViewBag.Transfer = new SelectList(EmployeeOutletDAL.GetDataByID(int.Parse(UserId)), "OutletID", "OutletName");
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
                        int UserId = User.Identity.GetUserId<int>();
                        int OutletId = 1;
                        //OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
                        AdjusmentStock item = new AdjusmentStock()
                        {
                            ID = model.ID,
                            OutletID = OutletId,
                            Note = model.Note,
                            CreatedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = UserId,
                            ModifiedOn = DateTime.Now,
                        };
                        context.TAdjusmentStock.Add(item);
                        context.SaveChanges();

                        int i = 0;
                        foreach (var detail in model.VariantID)
                        {
                            AdjusmentStockDetail item2 = new AdjusmentStockDetail()
                            {
                                HeaderID = item.ID,
                                VariantID = detail,
                                ActualStock = model.ActualStock[i],
                                InStock = model.InStock[i],
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now,
                            };
                            context.TAdjusmentStockDetail.Add(item2);
                            context.SaveChanges();

                            ItemsIventory vInv = context.TItemsIventory.Where(t => t.VariantID == detail).FirstOrDefault();
                            if (vInv != null)
                            {
                                vInv.VariantID = detail;
                                vInv.Beginning = model.InStock[i];
                                vInv.Adjusment = model.AdjusmentList[i];
                                vInv.CreatedBy = UserId;
                                vInv.CreatedOn = DateTime.Now;
                                vInv.ModifiedBy = UserId;
                                vInv.ModifiedOn = DateTime.Now;
                            };
                            context.SaveChanges();
                            i++;                                //masih kurang satu tabel lagi buat save
                        }                                           //yaitu tabel tabel ItemsInventory di adjustment dgn rumus actual-instock


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
    }
}