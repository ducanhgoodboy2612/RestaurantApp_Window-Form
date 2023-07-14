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
    public class DAL_KhachHang: DBconnect
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
            da = new SqlDataAdapter("select * from KhachHang", _conn);
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

        public bool add(KhachHang kh)
        {
            string ma = kh.maKH;
            string ten = kh.tenKH;
            string sdt = kh.sdt;
            string email = kh.email;
            int dtl = kh.diemtl;
            if (ktmatrung(ma) == 1)
            {
                return false;
            }
            string sql = "insert into KhachHang values('" + ma + "',N'" + ten + "','" + sdt + "','" + email + "', '" + dtl + "') ";
            exec(sql);
            return true;
        }


        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from KhachHang where maKH = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(KhachHang x)
        {
            string sql = "update KhachHang set tenKH = N'" + x.tenKH + "',sdtKH = '" + x.sdt + "',emailKH = '" + x.email + "', diemTichLuy = '" + x.diemtl + "' where maKH = '" + x.maKH + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from KhachHang where maKH = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public DataTable find(string fi, int c)
        {
            _conn.Open();
            if (c == 0)
            {
                da = new SqlDataAdapter("select * from KhachHang where tenKH like N'%" + fi.Trim() + "%' ", _conn);

            }
            else
                da = new SqlDataAdapter("select * from KhachHang where sdtKH like N'%" + fi.Trim() + "%' ", _conn);

            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
    }
}
