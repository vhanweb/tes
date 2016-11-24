using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.DAL;
using POS.Model;
using Microsoft.AspNet.Identity;

namespace POS.Web.Controllers
{
    [Authorize]
    public class TransferController : Controller
    {
        // GET: TransferStock
        public ActionResult Index()
        {
            ViewBag.ListOutlet = new SelectList(OutletDAL.GetData(), "ID", "OutletName");
            var UserId = User.Identity.GetUserId();

            ViewBag.Transfer = new SelectList(EmployeeOutletDAL.GetDataByID(int.Parse(UserId)), "ID", "OutletName");
            return View();
        }

        //untuk input data ke dua tabelnabelnya
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TransferViewModel model) //tambahin kodingan utk rollback
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
                        TransferStock item = new TransferStock()
                            {
                                ID = model.ID,
                                FromOutlet = OutletId,
                                ToOutlet = model.ToOutlet,
                                Note = model.Note,
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now,
                            };
                        context.TTransferStock.Add(item);
                        try { context.SaveChanges(); }
                        catch (Exception) { }

                        foreach (var detail in model.VariantID) //pakai Sku hasil null, pakai Variant ID hasil null
                        {
                            TransferStockDetail vDetail = new TransferStockDetail()
                            {
                                HeaderID = item.ID,
                                VariantID = detail,
                                InStock = model.InStock,
                                Quantity = model.Quantity,
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now,
                            };
                            context.TTransferStockDetail.Add(vDetail);

                            ItemsIventory vInv = new ItemsIventory()
                            {
                                VariantID = detail,
                                Transfer = vDetail.Quantity,
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now,
                            };
                            context.TItemsIventory.Add(vInv);
                        }
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
            return View("Index", model);
        }
    }
}