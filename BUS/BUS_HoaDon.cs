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
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_hd = new DAL_HoaDon();
        public DataTable getData(int c)
        {
            return dal_hd.getData(c);
        }
        public DataTable loadNV(int c)
        {
            return dal_hd.loadNV(c);
        }
        public DataTable loadKM()
        {
            return dal_hd.loadCTKM();
        }
        public DataTable loadBan(int c)
        {
            return dal_hd.loadBan(c);
        }
        public DataTable loadDetail(string ma)
        {
            return dal_hd.loadDetail(ma);
        }


        public bool add(HoaDon bill)
        {
            return dal_hd.add(bill);
        }
        public bool add2(HoaDonNhap bill)
        {
            return dal_hd.add2(bill);
        }
        public bool upd(HoaDon bill)
        {
            return dal_hd.update1(bill);
        }
        public bool upd(HoaDonNhap bill)
        {
            return dal_hd.update2(bill);
        }
        public bool del(string ma, int c)
        {
            return dal_hd.delete(ma, c);
        }
        public DataTable BillStatistic(int c, string a, string b)
        {
            return dal_hd.BillStatistic(c, a, b);
        }
        public DataTable ImBillStatistic(int c, string a, string b)
        {
            return dal_hd.ImBillStatistic(c, a, b);
        }

        public DataTable DailyBill()
        {
            return dal_hd.DailyBill();
        }

        public int tongHD()
        {
            return dal_hd.tongHD();
        }
    }
}
