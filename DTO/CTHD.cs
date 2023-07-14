using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHD
    {
        public string maHD { get; set; }
        public string maMon { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }


        public CTHD() { }
        public CTHD(string maHD, string maMon, int sl, int gia)
        {
            this.maHD = maHD;
            this.maMon = maMon;
            this.soLuong = sl;
            this.donGia = gia;
        }
    }
    public class CTHDNhap
    {
        public string maHD { get; set; }
        public string maNL { get; set; }
        public int soLuong { get; set; }
        public int donGia { get; set; }


        public CTHDNhap() { }
        public CTHDNhap(string maHD, string maNL, int sl, int gia)
        {
            this.maHD = maHD;
            this.maNL = maNL;
            this.soLuong = sl;
            this.donGia = gia;
        }
    }
}
