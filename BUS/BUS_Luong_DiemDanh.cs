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
    public class BUS_Luong_DiemDanh
    {
        DAL_Luong_DiemDanh dal_sal = new DAL_Luong_DiemDanh();
        public DataTable getTable(string ma,string a, string b)
        {
            return dal_sal.getTable(ma, a, b);
        }
        public string getName(string ma)
        {
            return dal_sal.getName(ma);
        }
        public bool add(Luong_DiemDanh sal)
        {
            return dal_sal.add(sal);
        }
        public bool upd(Luong_DiemDanh sal)
        {
            return dal_sal.update(sal);
        }
        public bool del(string ma, int thang, int nam)
        {
            return dal_sal.delete(ma, thang, nam);
        }
        public DataTable SalStatistic(int c, int mon, int ye)
        {
            return dal_sal.SalStatistic(c, mon, ye);
        }
        public DataTable RollCallStatistic(int c, int mon, int ye)
        {
            return dal_sal.RollCallStatistic(c, mon, ye);
        }

    }
}
