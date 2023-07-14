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
    public class BUS_FoodMenu
    {
        DAL_FoodMenu dal = new DAL_FoodMenu();


        public IList<MonAn> getAll()
        {
            DataTable table = dal.getAll();
            IList<MonAn> list = new List<MonAn>();
            foreach (DataRow row in table.Rows)
            {
                MonAn x = new MonAn();
                x.MaMon = row.Field<string>(0);
                x.TenMon = row.Field<string>(1);
                x.MaLoai = row.Field<string>(2);
                x.DonGia = row.Field<int>(3);
                x.ChiPhiNL = row.Field<int>(4);

                list.Add(x);
            }
            return list;
        }

        public IList<MonAn> findInMenu(string maMon, string tenMon, int gia1, int gia2)
        {
            DataTable table = dal.findInMenu(maMon, tenMon, gia1, gia2);
            IList<MonAn> list = new List<MonAn>();
            foreach (DataRow row in table.Rows)
            {
                MonAn x = new MonAn();
                x.MaMon = row.Field<string>(0);
                x.TenMon = row.Field<string>(1);
                x.MaLoai = row.Field<string>(2);
                x.DonGia = row.Field<int>(3);
                x.ChiPhiNL = row.Field<int>(4);

                list.Add(x);
            }
            return list;
        }

        public IList<MonAn> getAllbyNV(string maloai)
        {
            DataTable table = dal.getAllbyNV(maloai);
            IList<MonAn> list = new List<MonAn>();
            foreach (DataRow row in table.Rows)
            {
                MonAn x = new MonAn();
                x.MaMon = row.Field<string>(0);
                x.TenMon = row.Field<string>(1);
                x.MaLoai = row.Field<string>(2);
                x.DonGia = row.Field<int>(3);
                

                list.Add(x);
            }
            return list;
        }
        public IList<DanhMucMon> getFoodCate()
        {
            DataTable table = dal.getFoodCate();
            IList<DanhMucMon> list = new List<DanhMucMon>();
            foreach (DataRow row in table.Rows)
            {
                DanhMucMon cls = new DanhMucMon();
                cls.MaLoai = row.Field<string>(0);
                cls.TenLoai = row.Field<string>(1);

                list.Add(cls);
            }
            return list;
        }
        public IList<MonAn> SearchLinq(MonAn dis, int fPrice, int tPrice)
        {
            return getAll().Where(x => (string.IsNullOrEmpty(dis.MaMon) || x.MaMon.Contains(dis.MaMon))
           && (string.IsNullOrEmpty(x.TenMon) || x.TenMon.ToLower().Contains(dis.TenMon.ToLower()))
            && (x.DonGia >= fPrice)
            && (x.DonGia <= tPrice)).ToList();
        }
        public IList<MonAn> SearchLinq(MonAn emp)
        {
            return getAll().Where(x => (string.IsNullOrEmpty(emp.MaMon) || x.MaMon.ToLower().Contains(emp.MaMon.ToLower()))
            && (string.IsNullOrEmpty(x.TenMon) || x.TenMon.ToLower().Contains(emp.TenMon.ToLower()))).ToList();
        }
        public int Insert(MonAn dis)
        {
            if (check_ID(dis.MaMon) == 0)
                return dal.Insert(dis.MaMon, dis.TenMon, dis.MaLoai, dis.DonGia, dis.ChiPhiNL);
            else return -1;

        }
        public int check_ID(string maMon)
        {
            return dal.check_ID(maMon);
        }

        public int Update(MonAn dis)
        {
            if (check_ID(dis.MaMon) != 0)
                return dal.Update(dis.MaMon, dis.TenMon, dis.MaLoai, dis.DonGia, dis.ChiPhiNL);

            else return -1;

        }
        public int Delete(string classID)
        {
            if (check_ID(classID) != 0)
                return dal.Delete(classID);
            else return -1;
        }

      
    }
}
