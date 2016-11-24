using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.DAL;

namespace POS.Web.Controllers
{
    [Authorize]
    public class ItemsVariantController : Controller
    {
        // GET: ItemsVariant
        public ActionResult Index()
        {
           List<ItemsVariantViewModel> model=ItemsVariantDAL.GetData();
           
            return View();
        }
    }
}