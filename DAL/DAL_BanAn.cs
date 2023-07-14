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
    public class DAL_BanAn: DBconnect
    {
        private const string PARM_BILLID = "@maHD";
        private const string PARM_FOODID = "@maMon";

        private const string PARM_NUM = "@sluong";
        private const string PARM_PRICE = "@donGia";
        private const string PARM_FOODNAME = "@tenMon";
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader re;
        public void Connect()
        {

            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
            //MessageBox.Show("Success connection.");
        }
        public void disConnect()
        {

            if (_conn.State == ConnectionState.Open)
                _conn.Close();
        }
        public DataTable getData()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from BanAn", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public DataTable LoadDetail(string maHD)
        {
            // Khởi tạo đối tượng kết nối SqlConnection
            using (SqlConnection connection = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True"))
            {
                // Khởi tạo đối tượng SqlCommand để thực hiện stored procedure
                using (SqlCommand cmd = new SqlCommand("dbo.BillDetail_Sel_All", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@maHD", maHD);

                    // Khởi tạo đối tượng SqlDataAdapter để lấy dữ liệu từ stored procedure
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Khởi tạo đối tượng DataTable để chứa dữ liệu
                        DataTable dt = new DataTable();

                        // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                        adapter.Fill(dt);

                        // Gán dữ liệu từ DataTable vào DataGridView
                        return dt;
                    }
                }
            }
        }
        public DataTable BillDetail(string maHD)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15)
            };
            parm[0].Value = maHD;
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[BillDetail_Sel_All]", parm);
            DataTable table = new DataTable();

            table.Columns.Add("maHD", typeof(string));
            table.Columns.Add("tenMon", typeof(string));
            table.Columns.Add("sluong", typeof(int));
            table.Columns.Add("donGia", typeof(int));


            while (dra.Read())
            {
                table.Rows.Add(dra["maHD"].ToString(), dra["tenMon"].ToString(), int.Parse(dra["sluong"].ToString()), int.Parse(dra["donGia"].ToString()));
            }
            dra.Dispose();
            return table;
        }
        public DataTable getDetail(string maBan)
        {
            _conn.Open();
            cmd = new SqlCommand("select hd.maHD from HDBan hd, BanAn b where hd.maBan = b.maBan and b.maBan = '" + maBan + "' and hd.thanhtoan = 0", _conn);
            string maHD = (string)cmd.ExecuteScalar();
            //da = new SqlDataAdapter("select ct.maMon, me.tenMon, ct.sluong,ct.donGia from Menu me, CTHD ct, HDBan hd, BanAn b where me.maMon = ct.maMon and ct.maHD = hd.maHD and hd.maBan = b.maBan and hd.thanhToan = 0 and b.maBan = '"+ma+"'", _conn);
            string sql = "select m.tenMon, ct.sluong, ct.donGia, ct.sluong*ct.donGia from CTHD ct, Menu m where maHD = '"+maHD+"' and ct.maMon = m.maMon";
            da = new SqlDataAdapter(sql, _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public string getMaHD(string maBan)
        {
            _conn.Open();
            cmd = new SqlCommand("select hd.maHD from HDBan hd, BanAn b where hd.maBan = b.maBan and b.maBan = '" + maBan + "' and hd.thanhtoan = 0",_conn);
            string maHD = (string)cmd.ExecuteScalar();
            _conn.Close();
            return maHD;
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
        public DataTable loadCbbBan()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from BanAn ", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        public DataTable loadCbbLoai()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from LoaiMon", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }

        public int Insert(CTHD x)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_NUM,SqlDbType.Int),
                new SqlParameter(PARM_PRICE,SqlDbType.Int),
            
            };
            parm[0].Value = x.maHD;
            parm[1].Value = x.maMon;
            parm[2].Value = x.soLuong;
            parm[3].Value = x.donGia;
            

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[BillDetail_Ins]", parm);
        }

        public int addtoBill( string maMon, string maBanAn, int num)
        {
            string maHD = this.getMaHD(maBanAn);

            _conn.Open();
            string sql1 = "select dongia from Menu where maMon = '" + maMon + "' ";
            cmd = new SqlCommand(sql1, _conn);
            int gia = (int)cmd.ExecuteScalar();
            _conn.Close();
            string sql = "";

            CTHD ct = new CTHD(maHD, maMon, num, gia);
            if (maHD != null)
            {
                return Insert(ct);
                //sql = "insert into CTHD values('" + maHD + " ','" + maMon + " ', '" + num + " ', '" + gia.ToString() + "')";
            } 
            else
            {
                //HoaDon bi = new HoaDon();
                //addHD(bi);
                //sql = "insert into CTHD values('" + bi.MaHD + " ','" + maMon + " ', '" + num + " ', '" + gia.ToString() + "')";
                return -1;
            }
            
            //try { exec(sql); } catch
            //{
            //    return false;
            //}

            //return true;
        }
        public void creBill(HoaDon bi, string maMon, int num)
        {
            //string maHD = hd.MaHD;
            //string maNV = hd.MaNV;
            //string tenKH = hd.TenKH;
            //string sdtKH = hd.SdtKH;
            //string maBan = hd.MaBan;
            //string ngayLap = hd.NgayLap;
            //string maKM = hd.MaKM;
            //int thanhToan = hd.ThanhToan;
            //if (ktmatrung(maHD, 0) == 1)
            //{
            //    return false;
            //}
            //string sql = "insert into HDBan values('" + maHD + "',N'" + maNV + "',N'" + tenKH + "',N'" + sdtKH + "', '" + maBan + "', '" + ngayLap + "', '" + maKM + "', '" + thanhToan + "') ";
            //exec(sql);
            //return true;


            //string maHD = this.getMaHD(bi.MaBan);

            //_conn.Open();
            //string sql1 = "select dongia from Menu where maMon = '" + maMon + "' ";
            //cmd = new SqlCommand(sql1, _conn);
            //int gia = (int)cmd.ExecuteScalar();
            //_conn.Close();
            //string sql = "";
            //if (maHD != null)
            //{
            //    sql = "insert into CTHD values('" + maHD + " ','" + maMon + " ', '" + num + " ', '" + gia.ToString() + "')";
            //}
            //else
            //{
                
            //    addHD(bi);
            //    sql = "insert into CTHD values('" + bi.MaHD + " ','" + maMon + " ', '" + num + " ', '" + gia.ToString() + "')";
            //}

            //exec(sql);

            //return true;
        }
        public DataTable loadCbbMon(string maLoai)
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from Menu where maLoai = '"+maLoai+"'", _conn);
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
        //public bool addtoBill()

        public bool add(BanAn tb)
        {
            string maBan = tb.maBan;
            string tenBan = tb.tenBan;
            int soCho = tb.soCho;
            int giaBan = tb.giaBan;
            int tinhTrang = tb.tinhTrang;
            if (ktmatrung(maBan) == 1)
            {
                return false;
            }
            string sql = "insert into BanAn values('" + maBan + "',N'" + tenBan + "','" + soCho + "','" + giaBan + "', '" + tinhTrang + "') ";
            exec(sql);
            return true;
        }
        public bool addHD(HoaDon hd)
        {
            string maHD = hd.MaHD;
            string maNV = hd.MaNV;
            string tenKH = hd.TenKH;
            string sdtKH = hd.SdtKH;
            string maBan = hd.MaBan;
            string ngayLap = hd.NgayLap;
            //DateTime currentDate = DateTime.Now;
            //string ngayLap = currentDate.ToString("yyyy-MM-dd"); 
            //string ngayLap = hd.NgayLap;
            string maKM = hd.MaKM;
            int thanhToan = hd.ThanhToan;
            if (ktmaHD(maHD) == 0)
            {
                string sql = "insert into HDBan values('" + maHD + "',N'" + maNV + "',N'" + tenKH + "',N'" + sdtKH + "', '" + maBan + "', '" + ngayLap + "', '" + maKM + "', '" + thanhToan + "') ";
                exec(sql);
                return true;
            }
            else return false;
        }
        public int ktmaHD(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from HDBan where maHD = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from BanAn where maban = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(HoaDon hd)
        {
            string sql = "update HDBan set maNV= N'" + hd.MaNV + " ',tenKH = N'" + hd.TenKH + "',sdtKH = N'" + hd.SdtKH + "',maBan = '" + hd.MaBan + "', ngayLap = '" + hd.NgayLap + "', maKM = '" + hd.MaKM + "', thanhtoan = '" + hd.ThanhToan + "' where maHD = '" + hd.MaHD + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from BanAn where maban = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public string getPrice(string ma, int c)
        {
            _conn.Open();
            if(c == 0)
            {
                cmd = new SqlCommand("select giaban from BanAn  where maBan = '" + ma + "'", _conn);
            }
            else
            {
                cmd = new SqlCommand("select donGia from Menu  where maMon = '" + ma + "'", _conn);
            }
            
            int gia = (int)cmd.ExecuteScalar();
            _conn.Close();
            return gia.ToString();
        }

        public int FoodDelete(string maHD, string tenMon)
        {
            Connect();
            string sql = "select maMon from Menu where tenMon = N'" + tenMon + "'";
            cmd = new SqlCommand(sql, _conn);
            string maMon = (string)cmd.ExecuteScalar();
            disConnect();
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar,10),
            };
            parm[0].Value = maHD;
            parm[1].Value = maMon;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[BillDetail_Del]", parm);
        }

        public bool foodDel(string mahd, string tenmon)
        {
            Connect();
            string sql = "select maMon from Menu where tenMon = N'" + tenmon+ "'";
            cmd = new SqlCommand(sql, _conn);
            string maMon = (string)cmd.ExecuteScalar();
            disConnect();
            string strDel = "delete from CTHD where maHD = '" + mahd + "' and maMon = '"+maMon+"' ";
            exec(strDel);
            return true;
        }
        public string getBillInfo(string maHD, int c)
        {
            _conn.Open();
            string sql = "";
            if(c == 0)
            {
                sql = "select tenKH from HDBan where maHD = '" + maHD.Trim() + "' ";
            }
            else if(c == 1)
            {
                sql = "select sdtKH from HDBan where maHD = '" + maHD.Trim() + "' ";
            }
            else sql = "select maKM from HDBan where maHD = '" + maHD.Trim() + "' ";

            cmd = new SqlCommand(sql, _conn);
            string res = "";
            try
            {
                 res = (string)cmd.ExecuteScalar();

            }
            catch { }
            _conn.Close();
            return res;
        }
        public double tinhTongHD(string maHD, string maBan, string maKM)
        {
            //try
            {
                _conn.Open();

                
                string sql = "select sum(DonGia * sLuong) from CTHD where maHD = '" + maHD + "' ";
                cmd = new SqlCommand(sql, _conn);
                int tonghd = (int)cmd.ExecuteScalar();

                sql = "select giaban from BanAn where maBan = '" +maBan+ "' ";
                cmd = new SqlCommand(sql, _conn);
                int giaBan = (int)cmd.ExecuteScalar();
                double ck = 0;
                if (maKM != "")
                {
                    sql = "select chietKhau from CTKM where maKM = '" + maKM + "' ";
                    cmd = new SqlCommand(sql, _conn);
                    ck = (double)cmd.ExecuteScalar();
                }


                _conn.Close();

                return (giaBan + tonghd) * (1-ck);
            }
            //catch
            //{
            //    _conn.Close();

            //    return 0;

            //}
        }
    }
}
