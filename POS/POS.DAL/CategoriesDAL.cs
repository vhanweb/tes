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
                          join i in context.TItems on c.ID equals i.CategoryID into iTmp
                          from i in iTmp.DefaultIfEmpty()
                          select new CategoriesViewModel()
                          {
                              ID = c.ID,
                              Name = c.Name,
                          }
                          ).OrderByDescending(x => x.Name).ToList();
            }
            return result;
        }

        //// digunakan untuk mengedit kategori satu per satu
        public static CategoriesViewModel GetDataById(int id)
        {
            CategoriesViewModel result = new CategoriesViewModel();
            using (POSContext context = new POSContext())
            {
                result = (from c in context.TCategories
                          join i in context.TItems on c.ID equals i.CategoryID into iTmp
                          from i in iTmp.DefaultIfEmpty()
                          where c.ID == id
                          select new CategoriesViewModel()
                          {
                              ID = c.ID,
                              Name = c.Name,
                          }
                          ).FirstOrDefault();
            }
            return result;
        }

    }
}
