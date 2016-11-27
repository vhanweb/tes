using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.DAL;
using POS.Model;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CustomersController : Controller
    {
         //GET: NewCustomer
        public ActionResult Add()
        {
            ViewBag.listProvince = new SelectList(ProvinceDAL.GetData(), "ID", "ProvinceName");
            ViewBag.listRegion = new SelectList(String.Empty,"","");
            ViewBag.listDistrict = new SelectList(String.Empty, "", "");
            CustomersViewModel model = new CustomersViewModel();
            return PartialView("Add", model);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Add(CustomersViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    Customers item = new Customers()
                    {
                        ID = model.ID,
                        CustomerName = model.CustomerName,
                        Email = model.Email,
                        Phone = model.Phone,
                        Address = model.Address,
                        BirthDate = model.BirthDate,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedOn = DateTime.Now,
                        ProvinceID = model.ProvinceID,
                        RegionID = model.RegionID,
                        DistrictID = model.DistrictID,

                    };
                    context.TCustomers.Add(item);
                    try
                    {
                        context.SaveChanges();
                        return RedirectToAction("Add", "Payment");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return PartialView("Add", model);
        }
    }
}