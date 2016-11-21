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
    public class AJAXController : Controller
    {
        // GET: AJAX
        public ActionResult GetItem()
        {
            List<ItemIventoryViewModel> model =  ItemIventoryDAL.GetData();
            return PartialView("_ListItem",model);
        }

        public ActionResult GetItemSearch(string searchKey)
        {
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataBySearch(searchKey);
            return PartialView("_ListItem",model);
        }

        public ActionResult GetOutlet()
        {
            List<Outlet> model = OutletDAL.GetData();
            return PartialView("_ListOutlet", model);
        }

        public ActionResult GetOutletSearch(string searchKey)
        {
            List<Outlet> model = OutletDAL.GetDataBySearchKey(searchKey);
            return PartialView("_ListOutlet", model);
        }

        public ActionResult LoadTable()
        {
            List<EmployeViewModel> model = EmployeeDAL.GetDataTable();
            return PartialView("_LoadTable", model);
        }

    }
}