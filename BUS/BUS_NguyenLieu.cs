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
    public class BUS_NguyenLieu
    {
        DAL_NguyenLieu dal_nl = new DAL_NguyenLieu();
        public DataTable getData()
        {
            return dal_nl.getData();
        }

        public DataTable loadCbb()
        {
            return dal_nl.loadCbb();
        }
        public DataTable find(string fi, int c)
        {
            return dal_nl.find(fi, c);
        }
        public bool add(NguyenLieu x)
        {
            return dal_nl.add(x);
        }
        public bool upd(NguyenLieu x)
        {
            return dal_nl.update(x);
        }
        public bool del(string ma)
        {
            return dal_nl.delete(ma);
        }
    }
}
