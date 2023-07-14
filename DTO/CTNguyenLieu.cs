using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTNguyenLieu
    {
        public string maMon { get; set; }
        public string maNL { get; set; }
        public int luong { get; set; }
        public string donVi { get; set; }


        public CTNguyenLieu() { }
        public CTNguyenLieu(string maMon, string maNL, int luong, string dv)
        {
            this.maMon = maMon;
            this.maNL = maNL;
            this.luong = luong;
            this.donVi = dv;
           
        }
    }
}
