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
            ViewBag.ListOutlet = new SelectList(OutletDAL.GetData(), "ID", "OutletName");
            ViewBag.ListSupplier = new SelectList(SuppliersDAL.GetData(), "ID", "Name");
            return PartialView("Add");
        }

        public ActionResult OrderDetail()
        {
            return PartialView("OrderDetail");
        }
    }
}