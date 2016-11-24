using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;

namespace POS.DAL
{
    public class RoleDAL
    {
        public static List<Role> GetData()
        {
            List<Role> result = new List<Role>();
            using (POSContext context = new POSContext())
            {
                result = context.TRole.ToList();
            }
            return result;
        }
    }
}
