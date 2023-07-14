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
    public class BUS_BanAn
    {
        DAL_BanAn dal_tb = new DAL_BanAn();
        DAL_Bill dal_bill = new DAL_Bill();

        public int check_foodID(string maHD, string maMon)
        {
            return dal_bill.check_foodID(maHD, maMon);
        }
        public DataTable getData()
        {
            return dal_tb.getData();
        }
        public DataTable getDetail(string ma)
        {
            return dal_tb.getDetail(ma);
        }
        public DataTable loadCbbBan()
        {
            return dal_tb.loadCbbBan();
        }

        public DataTable loadCbbLoai()
        {
            return dal_tb.loadCbbLoai();
        }
        public DataTable loadCbbMon(string maloai)
        {
            return dal_tb.loadCbbMon(maloai);
        }
        public DataTable loadKM()
        {
            return dal_tb.loadCTKM();
        }
        //public bool add(BanAn x)
        //{
        //    return dal_tb.add(x);
        //}

        public int ktmaHD(string maHD)
        {
            return dal_tb.ktmaHD(maHD);
        }
        public bool addHD(HoaDon x)
        {
            return dal_tb.addHD(x);
        }
        public bool updBill(HoaDon x)
        {
            return dal_tb.update(x);
        }
        public int foDel(string maHD, string tenMon)
        {
            return dal_tb.FoodDelete(maHD, tenMon);
        }
        public bool foodDel(string maHD, string maMon)
        {
            return dal_tb.foodDel(maHD, maMon);
        }
        public string getMaHD(string maBan)
        {
            return dal_tb.getMaHD(maBan);
        }
        public string getPrice(string ma, int c)
        {
            return dal_tb.getPrice(ma, c);
        }
        public int addToBill(string maMon, string maBan, int num)
        {
            return dal_tb.addtoBill(maMon, maBan, num);
        }
        public string getBillInfo(string maHD, int c)
        {
            return dal_tb.getBillInfo(maHD, c);
        }
        public double tinhTongHD(string maHD, string maBan, string maKM)
        {
            return dal_tb.tinhTongHD(maHD, maBan, maKM);
        }
        //public bool creBill(HoaDon bill, string maMon,  int num)
        //{
        //    return dal_tb.creBill(bill, maMon, num);
        //}
    }
}
