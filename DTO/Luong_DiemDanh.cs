using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Luong_DiemDanh
    {
        public string maNV { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public int luong { get; set; }
        public int thuong { get; set; }
        public int diemDanh { get; set; }

        public Luong_DiemDanh() { }
        public Luong_DiemDanh(string ma, int m, int y, int lu, int th, int c)
        {
            this.maNV = ma;
            this.thang = m;
            this.nam = y;
            this.luong = lu;
            this.thuong = th;
            this.diemDanh = c;
        }
    }
    
}
