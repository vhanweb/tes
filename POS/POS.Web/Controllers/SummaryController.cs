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
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataSum();
            using (POSContext context = new POSContext())

                foreach (var item in model)
                {
                    ItemsIventory data = context.TItemsIventory.Where(m => m.ID == item.ID).FirstOrDefault();
                    data.Ending = item.Beginning + item.PurchaseOrder + item.Adjusment - item.Sales - item.Transfer;
                    context.SaveChanges();
                }


            return View(model);
        }
    }
}