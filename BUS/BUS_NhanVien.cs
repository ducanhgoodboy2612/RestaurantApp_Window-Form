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
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_emp = new DAL_NhanVien();

        DAL_NhanVien dal = new DAL_NhanVien();


        public IList<NhanVien> getAll()
        {
            DataTable table = dal.getAll();
            IList<NhanVien> list = new List<NhanVien>();
            foreach (DataRow row in table.Rows)
            {
                NhanVien x = new NhanVien();
                x.MaNV = row.Field<string>(0);
                x.HotenNV = row.Field<string>(1);
                x.GioiTinh = row.Field<string>(2);
                x.MaLoai = row.Field<string>(3);
                x.NamSinh = row.Field<int>(4);
                x.DiaChi = row.Field<string>(5);
                x.Sdt = row.Field<string>(6);

                list.Add(x);
            }
            return list;
        }

        public int check_ID(string maNV)
        {
            return dal.check_ID(maNV);
        }

        public int Insert(NhanVien emp)
        {
            if (check_ID(emp.MaNV) == 0)
                return dal.Insert(emp);
            else return -1;

        }

        public int Update(NhanVien emp)
        {
            if (check_ID(emp.MaNV) != 0)
                return dal.Update(emp);

            else return -1;

        }
        public int Delete(string manv)
        {
            if (check_ID(manv) != 0)
                return dal.Delete(manv);
            else return -1;
        }

        public IList<NhanVien> SearchLinq(NhanVien emp)
        {
            return getAll().Where(x => (string.IsNullOrEmpty(emp.MaNV) || x.MaNV.ToLower().Contains(emp.MaNV.ToLower()))
            && (string.IsNullOrEmpty(x.HotenNV) || x.HotenNV.ToLower().Contains(emp.HotenNV.ToLower()))).ToList();
        }

        //public DataTable getEmp()
        //{
        //    return dal_emp.getEmp();
        //}
        public DataTable getAllType()
        {
            return dal_emp.getAllType();
        }
        public string getType(string ma)
        {
            return dal_emp.getType(ma);
        }
        //public bool addEmp(NhanVien emp)
        //{
        //    return dal_emp.addEmp(emp);
        //}
        //public bool updEmp(NhanVien emp)
        //{
        //    return dal_emp.updEmp(emp);
        //}
        //public bool delEmp(string ma)
        //{
        //    return dal_emp.delEmp(ma);
        //}
        //public DataTable find(string fi, int c)
        //{
        //    return dal_emp.find(fi, c);
        //}


    }
}
