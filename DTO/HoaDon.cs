using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string TenKH { get; set; }
        public string SdtKH { get; set; }
        public string MaBan { get; set; }
        public string NgayLap { get; set; }
        public string MaKM { get; set; }
        public int ThanhToan { get; set; }

        public HoaDon() { }
        public HoaDon(string maHD, string maNV, string tenKH, string sdtKH, string maBan, string ngayLap, string maKM, int thanhToan)
        {
            this.MaHD = maHD;
            this.MaNV = maNV;
            this.TenKH = tenKH;
            this.SdtKH = sdtKH;
            this.MaBan = maBan;
            this.NgayLap = ngayLap;
            this.MaKM = maKM;
            this.ThanhToan = thanhToan;
        }
    }
    public class HoaDonNhap
    {
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string MaNCC { get; set; }
        public string NgayLap { get; set; }
        

        public HoaDonNhap() { }
        public HoaDonNhap(string maHD, string maNV, string maNCC, string ngayLap)
        {
            this.MaHD = maHD;
            this.MaNV = maNV;
            this.MaNCC = maNCC;
            this.NgayLap = ngayLap;
        }
    }
}
