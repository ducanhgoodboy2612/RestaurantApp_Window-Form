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
    public class DAL_QLBanAn:DBconnect
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
            da = new SqlDataAdapter("select * from BanAn", _conn);
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
      
        
        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from BanAn where maban = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(BanAn x)
        {
            string sql = "update BanAn set tenBan = N'" + x.tenBan + "',soCho = '" + x.soCho + "',giaban = '" + x.giaBan + "', tinhtrang = '" + x.tinhTrang + "' where maban = '" + x.maBan + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from BanAn where maban = '" + ma + "' ";
            exec(strDel);
            return true;
        }   
    }
}
