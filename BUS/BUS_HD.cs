using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_HD
    {
        DAL_Bill dal = new DAL_Bill();
        DAL_ImBill dal2 = new DAL_ImBill();
        DAL_TimKiemHD dal_find = new DAL_TimKiemHD();

        public IList<HoaDon> getAllHDB()
        {
            DataTable table = dal.getAll();
            //if (c == 0)
            //{
            IList<HoaDon> list = new List<HoaDon>();
            foreach (DataRow row in table.Rows)
            {
                HoaDon x = new HoaDon();
                x.MaHD = row.Field<string>(0);
                x.MaNV = row.Field<string>(1);
                x.TenKH = row.Field<string>(2);
                x.SdtKH = row.Field<string>(3);
                x.MaBan = row.Field<string>(4);
                x.NgayLap = row.Field<string>(5);
                x.MaKM = row.Field<string>(6);
                x.ThanhToan = row.Field<int>(7);

                list.Add(x);
            }
            return list;
        }

        public IList<HoaDonNhap> getAlLHDN()
        {
            DataTable table = dal2.getAll();
            IList<HoaDonNhap> list = new List<HoaDonNhap>();
            foreach (DataRow row in table.Rows)
            {
                HoaDonNhap x = new HoaDonNhap();
                x.MaHD = row.Field<string>(0);
                x.MaNV = row.Field<string>(1);
                x.MaNCC = row.Field<string>(2);
                x.NgayLap = row.Field<string>(3);
                //x.NgayLap = row.Field<string>(4);


                list.Add(x);
            }
            return list;
        }

        public IList<HoaDon> SearchBill(string mahd, string tenKH, int tong1, int tong2)
        {
            DataTable table = dal_find.SearchBill(mahd, tenKH, tong1, tong2);
            //if (c == 0)
            //{
            IList<HoaDon> list = new List<HoaDon>();
            foreach (DataRow row in table.Rows)
            {
                HoaDon x = new HoaDon();
                x.MaHD = row.Field<string>(0);
                x.MaNV = row.Field<string>(1);
                x.TenKH = row.Field<string>(2);
                x.SdtKH = row.Field<string>(3);
                x.MaBan = row.Field<string>(4);
                x.NgayLap = row.Field<string>(5);
                x.MaKM = row.Field<string>(6);
                x.ThanhToan = row.Field<int>(7);

                list.Add(x);
            }
            return list;
        }

        public IList<NhanVien> getEmp1()
        {
      
            DataTable table = dal.getEmp();
            IList<NhanVien> list = new List<NhanVien>();
            foreach (DataRow row in table.Rows)
            {
                NhanVien x = new NhanVien();
               
                x.MaNV = row.Field<string>(0);
                x.HotenNV = row.Field<string>(1);
                list.Add(x);
            }
            return list;
        }

        public IList<NhanVien> getEmp2()
        {

            DataTable table = dal2.getEmp();
            IList<NhanVien> list = new List<NhanVien>();
            foreach (DataRow row in table.Rows)
            {
                NhanVien x = new NhanVien();

                x.MaNV = row.Field<string>(0);
                x.HotenNV = row.Field<string>(1);
                list.Add(x);
            }
            return list;
        }

        public IList<BanAn> getTab()
        {

            DataTable table = dal.getTab();
            IList<BanAn> list = new List<BanAn>();
            foreach (DataRow row in table.Rows)
            {
                BanAn x = new BanAn();

                x.maBan = row.Field<string>(0);
                x.tenBan = row.Field<string>(1);
                list.Add(x);
            }
            return list;
        }

        public IList<NhaCungCap> getSup()
        {

            DataTable table = dal.getSup();
            IList<NhaCungCap> list = new List<NhaCungCap>();
            foreach (DataRow row in table.Rows)
            {
                NhaCungCap x = new NhaCungCap();

                x.MaNCC = row.Field<string>(0);
                x.TenNCC = row.Field<string>(1);
                list.Add(x);
            }
            return list;
        }

        public IList<ctkm> getSale()
        {

            DataTable table = dal.getSale();
            IList<ctkm> list = new List<ctkm>();
            foreach (DataRow row in table.Rows)
            {
                ctkm x = new ctkm();

                x.maCT = row.Field<string>(0);
                x.tenCT = row.Field<string>(1);
                list.Add(x);
            }
            return list;
        }

        public int Insert(HoaDon bill)
        {
            if (check_ID(bill.MaHD, 0) == 0)
                return dal.Insert(bill);
            else return -1;

        }
        public int Insert2(HoaDonNhap bill)
        {
            if (check_ID(bill.MaHD, 1) == 0)
                return dal2.Insert(bill);
            else return -1;

        }
        public int check_ID(string mahd, int c)
        {
            if(c == 0)
                return dal.check_ID(mahd);
            else
                return dal2.check_ID(mahd);

        }

        public int Update(HoaDon bill)
        {
            //if (check_ID(dis.MaMon) != 0)
            try
            {
                return dal.Update(bill.MaHD, bill.MaNV, bill.TenKH, bill.SdtKH, bill.MaBan, bill.NgayLap, bill.MaKM, bill.ThanhToan);
            }
            catch
            {
                return -1;

            }

        }

        public int Update(HoaDonNhap bill)
        {
            //if (check_ID(dis.MaMon) != 0)
            try
            {
                return dal2.Update(bill.MaHD, bill.MaNV, bill.MaNCC, bill.NgayLap);
            }
            catch
            {
                return -1;

            }

        }
        public int Delete(string maHD, int c)
        {
            try
            {
                if(c == 0)
                    return dal.Delete(maHD);
                else
                    return dal2.Delete(maHD);
            }
            catch
            {
                return -1;

            }
            
          
        }
        public DataTable getAllHDN()
        {
            return dal2.getData();
        }
    }
}
