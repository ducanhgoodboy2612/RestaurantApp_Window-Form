using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HotenNV { get; set; }
        public string GioiTinh { get; set; }
        public string MaLoai { get; set; }
        public int NamSinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
      
        public NhanVien() { }
        public NhanVien(string code, string name, string gen, string tyCo, int yob,  string add, string phone)
        {
            this.MaNV = code;
            this.HotenNV = name;
            this.GioiTinh = gen;
            this.MaLoai = tyCo;
            this.NamSinh = yob;
            this.DiaChi = add;
            this.Sdt = phone;
          
        }

    }
    
}
