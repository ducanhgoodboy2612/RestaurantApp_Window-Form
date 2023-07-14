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
    public class DAL_CTKM: DBconnect
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
            da = new SqlDataAdapter("select * from ctkm", _conn);
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

        public bool add(ctkm km)
        {
            string ma = km.maCT;
            string ten = km.tenCT;
            float ck = km.chietKhau;
            string nbd = km.ngayBD;
            string nkt = km.ngayKT;
            if (ktmatrung(ma) == 1)
            {
                return false;
            }
            string sql = "insert into CTKM values('" + ma + "',N'" + ten + "','" + ck.ToString().Replace(",", ".") + "','" + nbd + "', '" + nkt + "') ";
            exec(sql);
            return true;
        }


        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from CTKM where maKM = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(ctkm x)
        { 
            string sql = "update CTKM set tenct = N'" + x.tenCT + "',chietKhau = '" + x.chietKhau.ToString().Replace(",",".") + "',ngaybd = '" + x.ngayBD + "', ngaykt = '" + x.ngayKT + "' where maKM = '" + x.maCT + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from CTKM where maKM = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public DataTable ctht()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from ctkm where ngayBD <= CURRENT_TIMESTAMP and ngayKT >= CURRENT_TIMESTAMP", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
    }
}
