using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.ViewModel;
using POS.Model;
using POS.DAL;
using Microsoft.AspNet.Identity;

namespace POS.Web.Controllers
{
    public class AJAXController : Controller
    {
        // GET: AJAX
        public ActionResult GetItem()
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletid(OutletId);
            return PartialView("_ListItem",model);
        }

        public ActionResult GetItemSearch(string searchKey)
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletSearch(searchKey, OutletId);
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
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemsViewModel> model = ItemsDAL.GetData(OutletId);
            return PartialView("_ListItems", model);
        }

        public ActionResult GetItemsSearch(string searchKey)
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemsViewModel> models = ItemsDAL.GetDataSearch(searchKey, OutletId);
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
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletid(OutletId);
            return PartialView("_Variant", model);
        }
        public ActionResult GetVariantSearchTransfer(string SearchKey)
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletSearch(SearchKey, OutletId);
            return PartialView("_Variant", model);
        }
        public ActionResult GetItemVariant()
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletid(OutletId);
            return PartialView("_Add", model);
        }
        public ActionResult GetVariantSearchAdj(string SearchKey)
        {
            int UserId = User.Identity.GetUserId<int>();
            int OutletId = 0;
            OutletId = (int)EmployeeOutletDAL.GetDataOutletByUserId(UserId).OutletID;
            List<ItemIventoryViewModel> model = ItemIventoryDAL.GetDataByOutletSearch(SearchKey, OutletId);
            return PartialView("_Add", model);
        }

        public ActionResult SearchCategories(string searchkey)
        {
            List<CategoriesViewModel> result = CategoriesDAL.GetSearchCategories(searchkey);
            return PartialView("_ListCategories", result);
        }

        public ActionResult SearchSuppliers(string searchkey)
        {
            List<SuppliersViewModel> result = SuppliersDAL.GetSearch(searchkey);
            return PartialView("_ListSuppliers", result);
        }

        public ActionResult SearchItemsinCategories(string searchkey)
        {
            List<ItemsViewModel> result = CategoriesDAL.GetSearchListItem(searchkey);
            return PartialView("_ListItems1", result);
        }
    }
}