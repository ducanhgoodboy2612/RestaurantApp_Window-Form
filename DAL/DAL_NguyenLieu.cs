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
    public class DAL_NguyenLieu : DBconnect
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
        public DataTable getData()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from NguyenLieu", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public DataTable loadCbb()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from NhaCungCap", _conn);
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

        public bool add(NguyenLieu nl)
        {
            string maNL = nl.maNL;
            string tenNL = nl.tenNL;
            string dviTinh = nl.dviTinh;
            int slCon = nl.slCon;
            string ttBaoquan = nl.ttBaoQuan;
            if (ktmatrung(maNL) == 1)
            {
                return false;
            }
            string sql = "insert into NguyenLieu values('" + maNL + "',N'" + tenNL + "',N'" + dviTinh + "','" + slCon + "', N'" + ttBaoquan + "') ";
            exec(sql);
            return true;
        }
        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from NguyenLieu where maNL = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(NguyenLieu x)
        {
            string sql = "update NguyenLieu set tenNL = N'" + x.tenNL + "',dvTinh = N'" + x.dviTinh + "',slcon = '" + x.slCon + "', tinhTrangBQ = N'"+x.ttBaoQuan+"' where maNL = '" + x.maNL + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from NguyenLieu where maNL = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public DataTable find(string fi, int c)
        {
            _conn.Open();
            if (c == 0)
            {
                da = new SqlDataAdapter("select * from NguyenLieu where tenNL like N'%" + fi.Trim() + "%' ", _conn);

            }
            else
                da = new SqlDataAdapter("select * from NguyenLieu where maNL like N'%" + fi.Trim() + "%' ", _conn);

            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
    }
}
