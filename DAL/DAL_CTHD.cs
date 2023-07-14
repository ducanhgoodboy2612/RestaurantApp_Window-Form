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
    public class DAL_CTHD: DBconnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        //SqlDataReader re;

        public DataTable getData(string ma, int c)
        {
            _conn.Open();
            if (c == 0)
            {
                da = new SqlDataAdapter("select * from CTHD where maHD = '"+ma+"'", _conn);

            }
            else da = new SqlDataAdapter("select * from CTHD_Nhap where maHD = '" + ma + "'", _conn);
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

        
        public bool update1(CTHD ct)
        {
            string sql = "update CTHD set sluong = N'" + ct.soLuong + "',dongia = N'" + ct.donGia + "' where maHD = '" + ct.maHD + "' and maMon= N'" + ct.maMon + " ' ";
            exec(sql);
            return true;
        }
        public bool update2(CTHDNhap ct)
        {
            string sql = "update CTHD set maNL= N'" + ct.maNL + " ',sluong = N'" + ct.soLuong + "',dongia = N'" + ct.donGia + "' where maHD = '" + ct.maHD + "' ";
            exec(sql);
            return true;
        }
        
        public DataTable loadHD(int c)
        {
            _conn.Open();
            if(c == 0)
            {
                da = new SqlDataAdapter("select * from HDban", _conn);
            }
            else 
                da = new SqlDataAdapter("select * from HDnhap", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        public DataTable loadMa(int c)
        {
            _conn.Open();
            if (c == 0)
            {
                da = new SqlDataAdapter("select * from Menu", _conn);
            }
            else
                da = new SqlDataAdapter("select * from NguyenLieu", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }

        public bool delete(string maHD, string ma, int c)
        {
            string strDel = "";
            if (c == 0)
            {
                strDel = "delete from CTHD where maHD = '" + maHD + "' and maMon = '"+ma+"' ";

            }
            else
                strDel = "delete from CTHDNhap where maHD = '" + maHD + "' and maNL = '" + ma + "' ";
            exec(strDel);
            return true;
        }
    }
}
