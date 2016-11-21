using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Model;

namespace POS.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Employee model)
        {
            if (ModelState.IsValid)
            {
                using (POSContext context = new POSContext())
                {
                    Employee item = context.TEmployee.Where(m => m.Email == model.Email).FirstOrDefault();

                }
            }
            return View();
        }
    }
}