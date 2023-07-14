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
    public class DAL_CTNguyenLieu: DBconnect
    {
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
        public DataTable getData(string ma)
        {
            _conn.Open();
            da = new SqlDataAdapter("select ct.maMon, nl.tenNL, luong, ct.dvTinh from ChiTietMon ct, NguyenLieu nl where ct.maNL = nl.maNL and maMon = '"+ma+"'", _conn);
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

        public bool add(CTNguyenLieu ct)
        {
            string mamon = ct.maMon;
            string manl = ct.maNL;
            int luong = ct.luong;
            string dv = ct.donVi;
            if (ktmatrung(mamon, manl) == 1)
            {
                return false;
            }
            string sql = "insert into ChiTietMon values('" + mamon + "',N'" + manl + "','" + luong + "',N'" + dv + "') ";
            exec(sql);
            return true;
        }


        public int ktmatrung(string mamon, string manl)
        {
            _conn.Open();

            string sql = "select count(*) from ChiTietMon where maMon = '" + mamon.Trim() + "' and maNL = '" + manl.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(CTNguyenLieu x)
        {
            string sql = "update ChiTietMon set luong = N'" + x.luong + "',dvtinh = '" + x.donVi + "' where mamon = '" + x.maMon + "' and maNL = '"+x.maNL+"' ";
            exec(sql);
            return true;
        }
        public bool delete(string mamon, string manl)
        {
            string strDel = "delete from ChiTietMon where maMon = '" + mamon + "' and maNL = '"+manl+"' ";
            exec(strDel);
            return true;
        }

        public DataTable loadcbb(int c)
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
    }
}

