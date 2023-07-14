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
    public class BUS_CTNguyenLieu
    {
        DAL_CTNguyenLieu dal_ctnl = new DAL_CTNguyenLieu();
        public DataTable getData(string mamon)
        {
            return dal_ctnl.getData(mamon);
        }
        public bool add(CTNguyenLieu x)
        {
            return dal_ctnl.add(x);
        }
        public bool upd(CTNguyenLieu x)
        {
            return dal_ctnl.update(x);
        }
        public bool del(string maMon, string maNL)
        {
            return dal_ctnl.delete(maMon, maNL);
        }
        public DataTable loadCbb(int c)
        {
            return dal_ctnl.loadcbb(c);
        }
    }
}
