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
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_kh = new DAL_KhachHang();
        public DataTable getData()
        {
            return dal_kh.getData();
        }
        public bool add(KhachHang x)
        {
            return dal_kh.add(x);
        }
        public bool upd(KhachHang x)
        {
            return dal_kh.update(x);
        }
        public bool del(string ma)
        {
            return dal_kh.delete(ma);
        }
        public DataTable find(string fi, int c)
        {
            return dal_kh.find(fi, c);
        }
    }
}
