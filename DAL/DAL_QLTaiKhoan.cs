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
    public class DAL_QLTaiKhoan: DBconnect
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
            da = new SqlDataAdapter("select * from Users where UserID != 'NV09'", _conn);
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

        public bool add(string id, string pass, string per)
        {
            
            if (ktmatrung(id) == 1)
            {
                return false;
            }
            string sql = "insert into Users values('" + id + "',N'" + pass + "', '"+per+"') ";
            exec(sql);
            return true;
        }


        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from Users where UserID = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(string id, string pass, string per)
        {
            string sql = "update Users set pass = '" + pass + "', per = '"+per+"' where UserID = N'" + id + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string id)
        {
            string strDel = "delete from Users where UserID = N'" + id + "' ";
            exec(strDel);
            return true;
        }
    }
}
