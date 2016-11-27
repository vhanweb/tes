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
            ViewBag.ListStatus = new SelectList(PurchaseOrderDAL.GetStatus(),"ID","StatusName");
            return View(model);
        }

        public ActionResult Load()
        {
            List<PurchaseOrderViewModel> model = PurchaseOrderDAL.GetData();
            return PartialView("_Index",model);
        }

        public ActionResult GetDataByStatus(int id) 
        {
            List<PurchaseOrderViewModel> model = PurchaseOrderDAL.GetDataByStatus(id);
            return PartialView("_Index", model);
        
        }

        public ActionResult GetDataSearch(string searchKey)
        {
            List<PurchaseOrderViewModel> model = PurchaseOrderDAL.GetDataBySearch(searchKey);
            return PartialView("_Index", model);
        }

        public ActionResult Add()
        {
            var UserId = User.Identity.GetUserId();
            ViewBag.ListOutlet = new SelectList(EmployeeOutletDAL.GetDataByID(int.Parse(UserId)), "OutletID", "OutletName");
            ViewBag.ListSupplier = new SelectList(SuppliersDAL.GetData(), "ID", "Name");
            return PartialView("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

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

        public ActionResult Detail(int Id)
        {
            ListPurchaseOrderViewModel model = PurchaseOrderDAL.GetDataByIdPO(Id);
            return PartialView("Detail", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(ListPurchaseOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransacyion = context.Database.BeginTransaction())
                    {
                        int UserId = User.Identity.GetUserId<int>();
                        PurchaseOrder item = context.TPurchaseOrder.Where(m => m.ID == model.ID).FirstOrDefault();
                        item.StatusID = model.StatusID;
                        item.ModifiedBy = UserId;
                        item.ModifiedOn = DateTime.Now;
                        context.SaveChanges();

                        PurchaseOrderHistory item2 = new PurchaseOrderHistory()
                        {
                            HeaderID = item.ID,
                            StatusID = model.StatusID,
                            CreatedBy = UserId,
                            ModifiedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedOn = DateTime.Now
                        };
                        context.TPurchaseOrderHistory.Add(item2);
                        context.SaveChanges();

                        if (model.StatusID == 2)
                        {
                            int i = 0;
                            foreach (var data in model.VariantID)
                            {
                                int variantid = data;
                                ItemsIventory item3 = context.TItemsIventory.Where(m => m.VariantID == variantid).FirstOrDefault();
                                item3.PurchaseOrder = model.Quantity[i];
                                i++;
                            }
                            context.SaveChanges();
                        }

                        try
                        {
                            dbTransacyion.Commit();
                            return RedirectToAction("Index");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
            return PartialView("Detail", model);
        }


        public ActionResult Edit(int Id)
        {
            var UserId = User.Identity.GetUserId();

            ViewBag.ListOutlet = new SelectList(EmployeeOutletDAL.GetDataByID(int.Parse(UserId)), "OutletID", "OutletName");
            ViewBag.ListSupplier = new SelectList(SuppliersDAL.GetData(), "ID", "Name");
            ListPurchaseOrderViewModel model = PurchaseOrderDAL.GetDataByIdPO(Id);
            return PartialView("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(ListPurchaseOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        int UserId = User.Identity.GetUserId<int>();
                        string OrderNo = PurchaseOrderDAL.OrderNo();
                        PurchaseOrder order = context.TPurchaseOrder.Where(m => m.ID == model.ID).FirstOrDefault();
                        if (order != null)
                        {
                            order.OutletID = model.OutletID;
                            order.SupplierID = model.SupplierID;
                            order.Notes = model.Notes;
                            order.Total = model.Total;
                            order.ModifiedBy = UserId;
                            order.ModifiedOn = DateTime.Now;
                        }

                        context.SaveChanges();

                        int i = 0;
                        foreach (var item in model.VariantID)
                        {
                            int POid = model.PODetailID[i];
                            PurchaseOrderDetail orderdetail = context.TPurchaseOrderDetail.Where(m => m.ID == POid).FirstOrDefault();
                            if (orderdetail != null)
                            {
                                orderdetail.HeaderID = order.ID;
                                orderdetail.Quantity = model.Quantity[i];
                                orderdetail.SubTotal = model.SubTotal[i];
                                orderdetail.VariantID = item;
                                orderdetail.UnitCost = model.UnitCost[i];
                                orderdetail.ModifiedBy = UserId;
                                orderdetail.ModifiedOn = DateTime.Now;
                            }
                            else
                            {
                                PurchaseOrderDetail orderdetail2 = new PurchaseOrderDetail()
                                {
                                    HeaderID = order.ID,
                                    Quantity = model.Quantity[i],
                                    SubTotal = model.SubTotal[i],
                                    VariantID = item,
                                    UnitCost = model.UnitCost[i],
                                    CreatedBy = UserId,
                                    CreatedOn = DateTime.Now,
                                    ModifiedBy = UserId,
                                    ModifiedOn = DateTime.Now
                                };
                                context.TPurchaseOrderDetail.Add(orderdetail2);
                            }
                            i++;
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
            return PartialView("Edit", model);
        }
    }
}