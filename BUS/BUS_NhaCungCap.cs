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
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dal_ncc = new DAL_NhaCungCap();
        public DataTable getData()
        {
            return dal_ncc.getData();
        }
        public bool add(NhaCungCap ncc)
        {
            return dal_ncc.add(ncc);
        }
        public bool upd(NhaCungCap ncc)
        {
            return dal_ncc.update(ncc);
        }
        public bool del(string ma)
        {
            return dal_ncc.delete(ma);
        }
        public DataTable getNL(string ma)
        {
            return dal_ncc.getNL(ma);
        }
        public DataTable find(string fi, int c)
        {
            return dal_ncc.find(fi, c);
        }
    }
}
