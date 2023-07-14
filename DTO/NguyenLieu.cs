using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieu
    {
        public string maNL { get; set; }
        public string tenNL { get; set; }
        public string dviTinh { get; set; }
        public int slCon { get; set; }
        public string ttBaoQuan { get; set; }


        public NguyenLieu() { }
        public NguyenLieu(string maNL, string tenNL, string dvitinh, int slCon, string ttBaoquan)
        {
            this.maNL = maNL;
            this.tenNL = tenNL;
            this.dviTinh = dvitinh;
            this.slCon = slCon;
            this.ttBaoQuan = ttBaoquan;
        }
    }
}

