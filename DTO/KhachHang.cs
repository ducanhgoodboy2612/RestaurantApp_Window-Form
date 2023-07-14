using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string maKH { get; set; }
        public string tenKH { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public int diemtl { get; set; }


        public KhachHang() { }
        public KhachHang(string maBan, string tenBan, string sdt, string email, int dtl)
        {
            this.maKH = maBan;
            this.tenKH = tenBan;
            this.sdt = sdt;
            this.email = email;
            this.diemtl = dtl;
        }
    }
}
