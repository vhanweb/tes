using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;

namespace POS.DAL
{
    public class SuppliersDAL
    {
        public static List<Suppliers> GetData()
        {
            List<Suppliers> result = new List<Suppliers>();
            using (POSContext context = new POSContext())
            {
                result = context.TSuppliers.ToList();
            }
            return result;
        }
    }
}
