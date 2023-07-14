using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class QLTaiKhoan
    {
        public string userID { get; set; }
        public string pass { get; set; }
        public int per { get; set; }
        public string maUser { get; set; }


        public QLTaiKhoan() { }
        //public QLTaiKhoan(string userID, string pass, int per, string maUser)
        //{
        //    this.userID = maBan;
        //    this.pass = tenBan;
        //    this.per = sdt;
        //    this.maUser = email;
        //    this.diemtl = dtl;
        //}
    }
}
