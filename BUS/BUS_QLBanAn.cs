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
    public class BUS_QLBanAn
    {
        DAL_QLBanAn dal_qlB = new DAL_QLBanAn();
        public DataTable getData()
        {
            return dal_qlB.getData();
        }
        public bool add(BanAn x)
        {
            return dal_qlB.add(x);
        }
        public bool upd(BanAn x)
        {
            return dal_qlB.update(x);
        }
        public bool del(string ma)
        {
            return dal_qlB.delete(ma);
        }
    }
}
