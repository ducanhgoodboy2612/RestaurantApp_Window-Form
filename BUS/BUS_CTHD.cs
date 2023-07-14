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
    public class BUS_CTHD
    {
        DAL_CTHD dal_ct = new DAL_CTHD();
        public DataTable getData(string ma, int c)
        {
            return dal_ct.getData(ma, c);
        }
        public DataTable loadHD(int c)
        {
            return dal_ct.loadHD(c);
        }
        public DataTable loadMa(int c)
        {
            return dal_ct.loadMa(c);
        }
       

       
     
        public bool upd(CTHD ct)
        {
            return dal_ct.update1(ct);
        }
        public bool upd(CTHDNhap ct)
        {
            return dal_ct.update2(ct);
        }
        public bool del(string maHD, string ma, int c)
        {
            return dal_ct.delete(maHD,ma, c);
        }
    }
}
