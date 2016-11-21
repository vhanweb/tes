using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;
using POS.ViewModel;
using POS.DAL;

namespace POS.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: RegisterStaf
        public ActionResult AddStaff()
        {
            ViewBag.ListRole = new SelectList(RoleDAL.GetData(), "ID", "RoleName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStaff(EmployeViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        Employee item = new Employee()
                        {
                            Email = model.Email,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Title = model.Title,
                            CreatedBy = 1,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = 1,
                            ModifiedOn = DateTime.Now
                        };
                        context.TEmployee.Add(item);
                        //try { context.SaveChanges(); }
                        //catch (Exception) { }

                        EmployeeOutlet vEOutlet = new EmployeeOutlet()
                            {
                                EmployeeID = item.ID,
                                OutletID = model.OutletID,
                                RoleID = model.RoleID,
                                CreatedBy = 1,
                                CreatedOn = DateTime.Now,
                                ModifiedBy = 1,
                                ModifiedOn = DateTime.Now
                            };
                        context.TEmployeeOutlet.Add(vEOutlet);
                        context.SaveChanges();
                       

                        try
                        {
                            dbTransaction.Commit();
                            return RedirectToAction("AddStaff");
                        }
                        catch (Exception)
                        {
                            dbTransaction.Rollback();
                        }
                    }
                }
            }
            return View();
        }


    }
}