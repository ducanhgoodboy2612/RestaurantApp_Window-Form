using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ctkm
    {
        public string maCT { get; set; }
        public string tenCT { get; set; }
        public float chietKhau { get; set; }
        public string ngayBD { get; set; }
        public string ngayKT { get; set; }


        public ctkm() { }
        public ctkm(string maKM, string tenCT, float ck, string nbd, string nkt)
        {
            this.maCT = maKM;
            this.tenCT = tenCT;
            this.chietKhau = ck;
            this.ngayBD = nbd;
            this.ngayKT = nkt;
        }
    }
}
