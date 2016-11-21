using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.ViewModel;

namespace POS.DAL
{
    public class OutletDAL
    {
        public static List<Outlet> GetData()
        {
            List<Outlet> result = new List<Outlet>();
            using (POSContext context = new POSContext())
            {
                result = context.TOutlet.ToList();
            }
            return result;
        }

        public static List<Outlet> GetDataBySearchKey(string searchKey)
        {
            List<Outlet> result = new List<Outlet>();
            using (POSContext context = new POSContext())
            {
                result = context.TOutlet.Where(m => m.OutletName.Contains(searchKey))
                    
                    .ToList();
            }
            return result;
        }
    }
}
