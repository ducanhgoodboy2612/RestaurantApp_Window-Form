using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }

        public NhaCungCap() { }
        public NhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.Sdt = sdt;
            this.Diachi = diaChi;
        }
    }
}
