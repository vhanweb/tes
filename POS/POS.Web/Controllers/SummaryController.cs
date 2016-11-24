using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.Model;
using POS.DAL;

namespace POS.Web.Controllers
{
    [Authorize]
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
           
            return View(ItemIventoryDAL.GetDataSum());
        }
    }
}