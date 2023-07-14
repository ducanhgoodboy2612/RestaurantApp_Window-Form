using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_HoaDon: DBconnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //SqlDataReader re;

        public DataTable getData(int c)
        {
            _conn.Open();
            if(c == 0)
            {
                da = new SqlDataAdapter("select * from HDBan", _conn);

            }
            else da = new SqlDataAdapter("select * from HDNhap", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }

        void exec(string sql)
        {
            _conn.Open();
            cmd = new SqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
     
        public bool add(HoaDon hd)
        {
            string maHD = hd.MaHD;
            string maNV = hd.MaNV;
            string tenKH = hd.TenKH;
            string sdtKH = hd.SdtKH;
            string maBan = hd.MaBan;
            string ngayLap = hd.NgayLap;
            string maKM = hd.MaKM;
            int thanhToan = hd.ThanhToan;
            if (ktmatrung(maHD, 0) == 1)
            {
                return false;
            }
            string sql = "insert into HDBan values('" + maHD + "',N'" + maNV + "',N'" + tenKH + "',N'" + sdtKH + "', '" + maBan + "', '" + ngayLap + "', '" + maKM + "', '" + thanhToan + "') ";
            exec(sql);
            return true;
        }
        public bool add2(HoaDonNhap hd)
        {
            string maHD = hd.MaHD;
            string maNV = hd.MaNV;
            string maNCC = hd.MaNCC;
            string ngaylap = hd.NgayLap;
           
            if (ktmatrung(maHD, 1) == 1)
            {
                return false;
            }
            string sql = "insert into HDNhap values('" + maHD + "',N'" + maNV + "',N'" + maNCC + "',N'" + ngaylap + "') ";
            exec(sql);
            return true;
        }
        public bool update1(HoaDon hd)
        {
            string sql = "update HDBan set maNV= N'" + hd.MaNV + " ',tenKH = N'" + hd.TenKH + "',sdtKH = N'" + hd.SdtKH + "',maBan = '" + hd.MaBan + "', ngayLap = '" + hd.NgayLap + "', maKM = '" + hd.MaKM + "', thanhtoan = '" + hd.ThanhToan + "' where maHD = '" + hd.MaHD + "' ";
            exec(sql);
            return true;
        }
        public bool update2(HoaDonNhap hd)
        {
            string sql = "update HDNhap set maNV= N'" + hd.MaNV + " ',maNCC = N'" + hd.MaNCC + "',ngayNhap = N'" + hd.NgayLap + "' where maHD = '" + hd.MaHD + "' ";
            exec(sql);
            return true;
        }
        public int ktmatrung(string ma, int c)
        {
            _conn.Open();
            string sql = "";
            if(c == 0) sql = "select count(*) from HDBan where maHD = '" + ma.Trim() + "' ";
            else sql = "select count(*) from HDNhap where maHD = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public DataTable loadNV(int c)
        {
            _conn.Open();
            if(c == 0)
            {
                da = new SqlDataAdapter("select * from NhanVien where maLoai = 'L02'", _conn);
            }
            else da = new SqlDataAdapter("select * from NhanVien where maLoai = 'L03'", _conn);

            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        public DataTable loadCTKM()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from CTKM", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        public DataTable loadBan(int c)
        {
            _conn.Open();
            if(c == 0)
            {
                da = new SqlDataAdapter("select * from BanAn", _conn);
            }
            else
            {
                da = new SqlDataAdapter("select * from NhaCungCap", _conn);
            }
            
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        public DataTable loadDetail(string ma)
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from CTHD where maHD = '"+ma+"'", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        
        public bool delete(string ma, int c)
        {
            string strDel = "";
            if(c == 0)
            {
                strDel = "delete from HDBan where maHD = '" + ma + "' ";
                
            }
            else 
                strDel = "delete from HDNhap where maHD = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public int tongHD()
        {
            _conn.Open();
            string sql = "select sum(dongia*sluong) from CTHD";
            cmd = new SqlCommand(sql, _conn);
            int sum = (int)cmd.ExecuteScalar();
            _conn.Close();

            return sum;
        }

        public DataTable DailyBill()
        {
            _conn.Open();

            DateTime currentDate = DateTime.Now;
            string curdate = currentDate.ToString("yyyy-MM-dd");

            string sql = "select hd.MaHD, hd.MaNV, hd.maBan, hd.sdtKH, hd.maKM, hd.ngayLap , sum(ct.dongia * ct.sluong) as tongHoaDon " +
                        "from CTHD ct, HDBan hd where ct.maHD = hd.MaHD and ngayLap = '" + curdate + "' " +
                        "group by hd.MaHD, hd.maNV, hd.maBan,  hd.sdtKH, hd.maKM, hd.ngayLap order by tongHoaDon";
            da = new SqlDataAdapter(sql , _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }

        public DataTable BillStatistic(int c, string a, string b)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@c", SqlDbType.Int);
            parameters[0].Value = c;
            parameters[1] = new SqlParameter("@a", SqlDbType.NVarChar, 10);
            parameters[1].Value = a;
            parameters[2] = new SqlParameter("@b", SqlDbType.NVarChar, 10);
            parameters[2].Value = b;
            

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "BillStatistic", parameters);
            DataTable table = new DataTable();
            //if (c == 0)
            //{
            table.Columns.Add("maHD", typeof(string));
            table.Columns.Add("hotenNV", typeof(string));
            table.Columns.Add("tenKH", typeof(string));

            table.Columns.Add("sdtKH", typeof(string));
            table.Columns.Add("tenBan", typeof(string));
            table.Columns.Add("ngayLap", typeof(string));
            
            table.Columns.Add("tong HD", typeof(int));

            while (dra.Read())
            {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maHD"].ToString(), dra["hotenNV"].ToString(), dra["tenKH"].ToString(), dra["sdtKH"].ToString(), dra["tenBan"].ToString(), dra["ngayLap"].ToString(), int.Parse(dra["tong HD"].ToString()));
            }
            dra.Dispose();
            return table;
        }



        public DataTable ImBillStatistic(int c, string a, string b)
        {

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@c", SqlDbType.Int);
            parameters[0].Value = c;
            parameters[1] = new SqlParameter("@a", SqlDbType.NVarChar, 10);
            parameters[1].Value = a;
            parameters[2] = new SqlParameter("@b", SqlDbType.NVarChar, 10);
            parameters[2].Value = b;


            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "GetHDNhapData", parameters);
            DataTable table = new DataTable();
            //if (c == 0)
            //{
            table.Columns.Add("maHD", typeof(string));
            table.Columns.Add("hotenNV", typeof(string));
            table.Columns.Add("tenNCC", typeof(string));
            table.Columns.Add("ngayNhap", typeof(string));

            table.Columns.Add("tongHD", typeof(int));

            while (dra.Read())
            {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maHD"].ToString(), dra["hotenNV"].ToString(), dra["tenNCC"].ToString(), dra["ngayNhap"].ToString(), int.Parse(dra["tongHD"].ToString()));
            }
            dra.Dispose();
            return table;

        }
    }
}
