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
    public class DAL_Luong_DiemDanh : DBconnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public DataTable getTable(string ma, string a, string b)
        {
            _conn.Open();
            
            if(ma == "")
            {
                if(a == "all" && b == "all")
                {
                    da = new SqlDataAdapter("select *, (luong + thuong) as tonngLuong from Luong_DiemDanh", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                else if(a == "all")
                {
                    da = new SqlDataAdapter("select * , (luong + thuong) as tonngLuong from Luong_DiemDanh where nam = '" + b + "'", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                else if(b == "all")
                {
                    da = new SqlDataAdapter("select *, (luong + thuong) as tonngLuong from Luong_DiemDanh where thang = '" + a + "' ", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                else
                {
                    da = new SqlDataAdapter("select *, (luong + thuong) as tonngLuong from Luong_DiemDanh where thang = '" + a + "' and nam = '" + b + "'", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                
            }
            else
            {
                if(a == "all" && b == "all")
                {
                    da = new SqlDataAdapter("select * from Luong_DiemDanh where maNV = '"+ma+"'", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                else if(a == "all")
                {
                    da = new SqlDataAdapter("select * from Luong_DiemDanh where nam = '" + b + "' and maNV = '" + ma + "'", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                else if(b == "all")
                {
                    da = new SqlDataAdapter("select * from Luong_DiemDanh where thang = '" + a + "' and maNV = '" + ma + "'", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
                else
                {
                    da = new SqlDataAdapter("select * from Luong_DiemDanh where thang = '" + a + "' and nam = '" + b + "' and maNV = '" + ma + "'", _conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    _conn.Close();
                }
            }
                return dt;


        }

        public DataTable SalStatistic(int c, int a, int b)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@c", SqlDbType.Int);
            parameters[0].Value = c;
            parameters[1] = new SqlParameter("@a", SqlDbType.NVarChar, 10);
            parameters[1].Value = a;
            parameters[2] = new SqlParameter("@b", SqlDbType.NVarChar, 10);
            parameters[2].Value = b;


            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "EmpSalStatistic", parameters);
            DataTable table = new DataTable();

            table.Columns.Add("maNV", typeof(string));
            table.Columns.Add("thang", typeof(int));
            table.Columns.Add("nam", typeof(int));
            table.Columns.Add("luong", typeof(int));
            table.Columns.Add("thuong", typeof(int));
            table.Columns.Add("diemdanh", typeof(int));
            table.Columns.Add("tongLuong", typeof(int));


            while (dra.Read())
            {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maNV"].ToString(), int.Parse(dra["thang"].ToString()), int.Parse(dra["nam"].ToString()), int.Parse(dra["luong"].ToString()), int.Parse(dra["thuong"].ToString()), int.Parse(dra["diemdanh"].ToString()), int.Parse(dra["tongLuong"].ToString()));
            }
            dra.Dispose();
            return table;


        }

        public DataTable RollCallStatistic(int c, int a, int b)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@c", SqlDbType.Int);
            parameters[0].Value = c;
            parameters[1] = new SqlParameter("@a", SqlDbType.NVarChar, 10);
            parameters[1].Value = a;
            parameters[2] = new SqlParameter("@b", SqlDbType.NVarChar, 10);
            parameters[2].Value = b;


            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "EmpRCStatistic", parameters);
            DataTable table = new DataTable();

            table.Columns.Add("maNV", typeof(string));
            table.Columns.Add("thang", typeof(int));
            table.Columns.Add("nam", typeof(int));
            table.Columns.Add("luong", typeof(int));
            table.Columns.Add("thuong", typeof(int));
            table.Columns.Add("diemdanh", typeof(int));
            table.Columns.Add("tongLuong", typeof(int));


            while (dra.Read())
            {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maNV"].ToString(), int.Parse(dra["thang"].ToString()), int.Parse(dra["nam"].ToString()), int.Parse(dra["luong"].ToString()), int.Parse(dra["thuong"].ToString()), int.Parse(dra["diemdanh"].ToString()), int.Parse(dra["tongLuong"].ToString()));
            }
            dra.Dispose();
            return table;

        }
        public string getName(string ma)
        {
            _conn.Open();

            string sql = "select hotenNV from NhanVien where maNV = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            string name = (string)cmd.ExecuteScalar();

            _conn.Close();
            return name;
        }
        void exec(string sql)
        {
            _conn.Open();
            cmd = new SqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
        public bool add(Luong_DiemDanh sal)
        {
            string ma = sal.maNV;
            int th = sal.thang;
            int na = sal.nam;
            int lu = sal.luong;
            int thu = sal.thuong;
            int dd = sal.diemDanh;
            if (ktmatrung(ma, th, na) == 1)
            {
                return false;
            }
            string sql = "insert into Luong_DiemDanh values('" + ma + "',N'" + th + "',N'" + na + "',N'" + lu + "', '" + thu + "',N'" + dd + "') ";
            exec(sql);
            return true;
        }
        public int ktmatrung(string ma, int mo, int ye)
        {
            _conn.Open();

            string sql = "select count(*) from Luong_DiemDanh where maNV = '" + ma.Trim() + "' and thang = '"+mo+ "' and nam = '" + ye + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(Luong_DiemDanh sal)
        {
            string sql = "update Luong_DiemDanh set luong = N'" + sal.luong + "', thuong = ' " + sal.thuong + " ', diemDanh = N' " + sal.diemDanh + " '  where maNV = '" + sal.maNV + "' and thang= N'" + sal.thang + " 'and nam = N'" + sal.nam + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma, int thang, int nam)
        {
            string strDel = "delete from Luong_DiemDanh where maNV = '" + ma + "' and thang= N'" + thang + " 'and nam = N'" + nam + "' ";
            exec(strDel);
            return true;
        }
    }
}
