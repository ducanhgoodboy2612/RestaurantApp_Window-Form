using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_QLTaiKhoan
    {
        DAL_QLTaiKhoan dal = new DAL_QLTaiKhoan();
        public DataTable getData()
        {
            return dal.getData();
        }
        public bool add(string id, string pass, string per)
        {
            return dal.add(id, pass, per);
        }
        public bool upd(string id, string pass, string per)
        {
            return dal.update(id, pass, per);
        }
        public bool del(string ma)
        {
            return dal.delete(ma);
        }
    }
}
