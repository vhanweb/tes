using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.DAL;
using POS.Model;
using POS.ViewModel;
using Microsoft.AspNet.Identity;

namespace POS.Web.Controllers
{
    [Authorize]
    public class PurchaseOrderController : Controller
    {
        // GET: PurchaseOrder
        public ActionResult Index()
        {
            List<PurchaseOrderViewModel> model = PurchaseOrderDAL.GetData();
            return View(model);
        }

        public ActionResult Add()
        {
            var UserId = User.Identity.GetUserId();
            ViewBag.ListOutlet = new SelectList(EmployeeOutletDAL.GetDataByID(int.Parse(UserId)), "ID", "OutletName");
            ViewBag.ListSupplier = new SelectList(SuppliersDAL.GetData(), "ID", "Name");
            return PartialView("Add");
        }

        public ActionResult Add(PurchaseOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        int UserId = User.Identity.GetUserId<int>();
                        string OrderNo = PurchaseOrderDAL.OrderNo();
                        PurchaseOrder order = new PurchaseOrder()
                        {
                            OutletID = model.OutletID,
                            OrderNo = OrderNo,
                            StatusID = 1,
                            SupplierID = model.SupplierID,
                            Notes = model.Notes,
                            Total = model.Total,
                            CreatedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = UserId,
                            ModifiedOn = DateTime.Now
                        };
                        context.TPurchaseOrder.Add(order);
                        context.SaveChanges();


                        PurchaseOrderHistory orderhis = new PurchaseOrderHistory()
                        {

                            HeaderID = order.ID,
                            StatusID = 1,
                            CreatedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = UserId,
                            ModifiedOn = DateTime.Now
                        };
                        context.TPurchaseOrderHistory.Add(orderhis);
                        context.SaveChanges();
                        foreach (var item in model.VariantID)
                        {
                            PurchaseOrderDetail orderdetail = new PurchaseOrderDetail()
                            {

                                HeaderID = order.ID,
                                Quantity = model.Quantity,
                                SubTotal = model.SubTotal,
                                VariantID = item,
                                UnitCost = model.UnitCost,
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now
                            };
                            context.TPurchaseOrderDetail.Add(orderdetail);
                        }
                        context.SaveChanges();


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

        public ActionResult OrderDetail()
        {
            return PartialView("OrderDetail");
        }

        public ActionResult Edit(int Id)
        {
            ListPurchaseOrderViewModel model = PurchaseOrderDAL.GetDataByIdPO(Id);
            return PartialView("Edit", model);
        }
    }
}