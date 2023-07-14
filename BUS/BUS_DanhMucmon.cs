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
    public class BUS_DanhMucmon
    {
        DAL_DanhMuc dal = new DAL_DanhMuc();
       

        public IList<DanhMucMon> getAll()
        {
            DataTable table = dal.getAll();
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
        public int Insert(DanhMucMon cate)
        {
            if (checkCate_ID(cate.MaLoai) == 0)
                return dal.Insert(cate.MaLoai, cate.TenLoai);
            else return -1;

        }
        public int checkCate_ID(string classID)
        {
            return dal.checkCate_ID(classID);
        }

        public int Update(DanhMucMon cate)
        {
            if (checkCate_ID(cate.MaLoai) != 0)
                return dal.Update(cate.MaLoai, cate.TenLoai);

            else return -1;
            
        }
        public int Delete(string classID)
        {
            if (checkCate_ID(classID) != 0)
                return dal.Delete(classID);
            else return -1;
        }
    }
}
