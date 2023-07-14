using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QL_BanAn
    {
        public string maBan { get; set; }
        public string tenBan { get; set; }
        public int soCho { get; set; }
        public int giaBan { get; set; }
        public int tinhTrang { get; set; }


        public QL_BanAn() { }
        public QL_BanAn(string maBan, string tenBan, int soCho, int giaBan, int tinhTrang)
        {
            this.maBan = maBan;
            this.tenBan = tenBan;
            this.soCho = soCho;
            this.giaBan = giaBan;
            this.tinhTrang = tinhTrang;
        }
    }
}
