using POS.Model;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    public class CategoriesDAL
    {
        // ini digunakan untuk menampilkan list kategorinya
        public static List<CategoriesViewModel> GetData()
        {
            List<CategoriesViewModel> result = new List<CategoriesViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from c in context.TCategories
                          join o in context.TOutlet on c.OutletID equals o.ID
                          select new CategoriesViewModel()
                          {
                              ID = c.ID,
                              Name = c.Name,
                              OutletID = c.OutletID,
                              CreatedBy = c.CreatedBy,
                              CreatedOn = c.CreatedOn,
                              ModifiedBy = c.ModifiedBy,
                              ModifiedOn = c.ModifiedOn,
                          }
                          ).OrderByDescending(x => x.Name).ToList();
            }
            return result;
        }
        //menampilkan list items berdasarkan kategori
        public static List<ItemsViewModel> GetDataByCategoryID(int idCategory)
        {
            // tampilan listnya harus berdasarkan category id yang dipanggil
            List<ItemsViewModel> model = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                model = (from i in context.TItems
                         where i.CategoryID == idCategory
                         select new ItemsViewModel()
                         {
                             ID = i.ID,
                             Name = i.Name,
                             CategoryID = i.CategoryID,
                         }).ToList();
            }
            return model;
        }
        // mengambil list yang nanti akan ditampilkan
        // untuk mengambil list item berdasarkan ID categori
        //===================================================================================Untuk menampilkan List================================================//
        public static List<ItemsViewModel> GetItemsData(int Outletid)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from i in context.TItems
                          join c in context.TCategories on i.CategoryID equals c.ID
                          join o in context.TOutlet on c.OutletID equals o.ID
                          where i.CategoryID == 1059 && c.OutletID == Outletid
                          select new ItemsViewModel
                          {
                              ID = i.ID,
                              Name = i.Name,
                          }).ToList();
            } return result;
        }
        //===============================================================Untuk Menampilkan daftar Uncategorized berdasarkan iD=============================================//
        //public static CategoriesViewModel GetUncategorized(int outletId)
        //{
        //    string Name = "Uncategorized";
        //    CategoriesViewModel result = new CategoriesViewModel();
        //    using (POSContext context = new POSContext())
        //    {
        //        result = (from c in context.TCategories
        //                  join o in context.TOutlet on c.OutletID equals o.ID
        //                  where c.Name == Name && c.OutletID == outletId
        //                  select new CategoriesViewModel()
        //                  {
        //                      ID = c.ID
        //                  }).FirstOrDefault();
        //    }
        //    return result;
        //}
        //=======================================================================================================================================================//
        public static List<ItemsViewModel> GetSearchListItem(string searchkey)
        {
            List<ItemsViewModel> result = new List<ItemsViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from i in context.TItems
                          join c in context.TCategories on i.CategoryID equals c.ID
                          join o in context.TOutlet on c.OutletID equals o.ID
                          where i.Name.Contains(searchkey) || o.OutletName.Contains(searchkey)
                          select new ItemsViewModel()
                          {
                              ID = i.ID,
                              Name = i.Name,
                          }).ToList();
            }
            return result;
        }
        // untuk mengedit  categori yang akan di edit 
        public static CategoriesViewModel GetDataById(int IDCategory)
        {
            CategoriesViewModel result = new CategoriesViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from c in context.TCategories
                          where c.ID == IDCategory
                          select new CategoriesViewModel()
                          {
                              ID = c.ID,
                              Name = c.Name,
                              Name2 = c.Name,
                              CreatedBy = c.CreatedBy,
                              CreatedOn = c.CreatedOn,
                              ModifiedBy = c.ModifiedBy,
                              ModifiedOn = c.ModifiedOn,
                          }).FirstOrDefault();
            }
            return result;
        }

        //public static CategoriesViewModel GetDataByName(string name)
        //{
        //    CategoriesViewModel result = new CategoriesViewModel();
        //    using (POSContext context = new POSContext())
        //    {
        //        result = (from c in context.TCategories
        //                  where c.Name==name                           
        //                  select new CategoriesViewModel()
        //                  {
        //                      ID = c.ID,
        //                      Name = c.Name,
        //                      Name2 = c.Name,
        //                      OutletID = c.OutletID,
        //                      CreatedBy = c.CreatedBy,
        //                      CreatedOn = c.CreatedOn,
        //                      ModifiedBy = c.ModifiedBy,
        //                      ModifiedOn = c.ModifiedOn,
        //                  }).FirstOrDefault();
        //    }
        //    return result;
        //}
        // untuk menampilkan data categories pada masing-masing outlet
        public static List<CategoriesViewModel> GetDataByOutletId(int IDoutlet)
        {
            List<CategoriesViewModel> result = new List<CategoriesViewModel>();
            using (POSContext context = new POSContext())
            {
                result = (from c in context.TCategories
                          join o in context.TOutlet on c.OutletID equals o.ID into oTmp
                          from o in oTmp.DefaultIfEmpty()
                          where c.OutletID == IDoutlet
                          select new CategoriesViewModel()
                          {
                              ID = c.ID,
                              Name = c.Name,
                              OutletID = c.OutletID,
                              CreatedBy = c.CreatedBy,
                              CreatedOn = c.CreatedOn,
                              ModifiedBy = c.ModifiedBy,
                              ModifiedOn = c.ModifiedOn,
                          }).ToList();
            }
            return result;
        }

        //================================Untuk mensearch Kategori yang akan di Search===============================//
        public static List<CategoriesViewModel> GetSearchCategories(string SearchKey)
        {
            List<CategoriesViewModel> result = new List<CategoriesViewModel>();
            using (POSContext context = new POSContext())
            {

                result = (from c in context.TCategories
                          join o in context.TOutlet on c.OutletID equals o.ID
                          where o.OutletName.Contains(SearchKey) || c.Name.Contains(SearchKey)
                          select new CategoriesViewModel()
                          {
                              Name = c.Name
                          }).ToList();
            }
            return result;
        }
    }
}
