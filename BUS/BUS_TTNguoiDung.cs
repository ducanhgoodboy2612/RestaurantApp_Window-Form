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
    public class BUS_TTNguoiDung
    {
        DAL_TTNguoiDung dal = new DAL_TTNguoiDung();
        public int passchange(string maNV, string currPass, string newPass, string rePass)
        {
            return dal.check(maNV, currPass, newPass, rePass);
        }

        public List<string> getInfo(string maNV)
        {
            return dal.getInfo(maNV);
        }
    }
}
