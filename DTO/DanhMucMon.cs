using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhMucMon
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
       

        public DanhMucMon() { }
        public DanhMucMon(string maL, string tenL)
        {
            this.MaLoai = maL;
            this.TenLoai = tenL;
          
        }
    }
}
