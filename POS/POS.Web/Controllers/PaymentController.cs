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
                        int empID = 0;
                        empID = (int)PaymentDAL.GetDataById(UserId).EmployeeID;
                       Payment item = new Payment()
                        {
                            CustomerID = model.CustomerID,
                            EmployeeID = empID,
                            GrandTotal = model.GrandTotal,
                            CreatedBy = UserId,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = UserId,
                            ModifiedOn = DateTime.Now,
                        };
                        context.TPayment.Add(item);
                        context.SaveChanges();
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
                                CreatedBy = UserId,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = UserId,
                                ModifiedOn = DateTime.Now,
                            };
                            context.TPaymentDetail.Add(vDetail);
                            ItemsIventory item2 = context.TItemsIventory.Where(m => m.VariantID == detail).FirstOrDefault();
                            item2.Sales = model.Quantity[i];

                            i++;
                        }
                        context.SaveChanges();

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