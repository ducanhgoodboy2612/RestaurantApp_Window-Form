using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonAn
    {
        public string MaMon { get; set; }
        public string MaLoai { get; set; }
        public string TenMon { get; set; }
        public int DonGia { get; set; }
        public int ChiPhiNL { get; set; }

        public MonAn() { }
        public MonAn(string maMon, string maLoai, string tenMon, int donGia, int chiphiNL)
        {
            this.MaMon = maMon;
            this.MaLoai = maLoai;
            this.TenMon = tenMon;
            this.DonGia = donGia;
            this.ChiPhiNL = chiphiNL;
        }
    }
    
}
