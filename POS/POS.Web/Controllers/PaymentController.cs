using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using POS.DAL;
using POS.Model;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        // GET: Payment

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(PaymentDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        int UserId = User.Identity.GetUserId<int>();
                        Payment item = new Payment()
                        {
                            CustomerID = model.CustomerID,
                            EmployeeID = 31,
                            GrandTotal = model.GrandTotal,
                            CreatedBy = 1,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = 1,
                            ModifiedOn = DateTime.Now,
                        };
                        context.TPayment.Add(item);
                        try{context.SaveChanges();}
                        catch (Exception){}
                        int i = 0;
                        foreach(var detail in model.VariantID)
                        {
                            PaymentDetail vDetail = new PaymentDetail()
                            {
                                HeaderID = item.ID,
                                VariantID = detail,
                                Quantity = model.Quantity[i],
                                UnitPrice = model.UnitPrice[i],
                                SubTotal = model.SubTotal[i],
                                CreatedBy = 1,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = 1,
                                ModifiedOn = DateTime.Now,
                            };
                            context.TPaymentDetail.Add(vDetail);
                            i++;
                        }
                        try{ context.SaveChanges();}
                        catch (Exception){ }

                        try
                        {
                            dbTransaction.Commit();
                            return RedirectToAction("Add");

                        }
                        catch (Exception)
                        {
                            dbTransaction.Rollback();
                            throw;
                        }
                    }

                }
            }
            return View();
        }

    }
}