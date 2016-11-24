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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetItems()
        {
            List<ItemsViewModel> model = ItemsDAL.GetData();
            return PartialView("_ListItems", model);
        }

        public ActionResult GetItemsSearch(string searchKey)
        {
            List<ItemsViewModel> models = ItemsDAL.GetDataSearch(searchKey);
            return PartialView("_ListItems", models);
        }


        public ActionResult GetCustomers()
        {
            List<CustomersViewModel> model = CustomersDAL.GetData();
            return PartialView("_ListCustomers", model);
        }

        public ActionResult GetCustomersSearch(string searchKey)
        {
            List<CustomersViewModel> models = CustomersDAL.GetDataSearch(searchKey);
            return PartialView("_ListCustomers", models);
        }


        public JsonResult GetRegion(int provinceId)
        {
            return Json(RegionDAL.GetDataByProvinceId(provinceId),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrict(int regionId)
        {
            return Json(DistrictDAL.GetDataByRegionId(regionId),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVariant()
        {
            List<TransferViewModel> model = TransferDAL.GetData();
            return PartialView("_Variant", model);
        }
        public ActionResult GetVariantSearch(string SearchKey)
        {
            List<TransferViewModel> model = TransferDAL.GetDataSearch(SearchKey);
            return PartialView("_Variant", model);
        }
        public ActionResult GetItemVariant()
        {
            List<AdjustmentViewModel> model = AdjustmentDAL.GetData();
            return PartialView("_Add", model);
        }
    }
}