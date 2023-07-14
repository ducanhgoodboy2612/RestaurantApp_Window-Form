using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class BUS_CTKM
    {
        DAL_CTKM dal_km = new DAL_CTKM();
        public DataTable getData()
        {
            return dal_km.getData();
        }
        public DataTable ctht()
        {
            return dal_km.ctht();
        }
        public bool add(ctkm x)
        {
            return dal_km.add(x);
        }
        public bool upd(ctkm x)
        {
            return dal_km.update(x);
        }
        public bool del(string ma)
        {
            return dal_km.delete(ma);
        }
    }
}
