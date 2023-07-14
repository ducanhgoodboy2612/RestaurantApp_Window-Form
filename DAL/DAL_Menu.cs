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
    public class DAL_Menu : DBconnect
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
        public DataTable findEmp(int c, string cont)
        {
            Connect();
            da = new SqlDataAdapter("select * from Table_NV", _conn);
            dt = new DataTable();
            DataView dv = new DataView();
            da.Fill(dt);
            dv = dt.DefaultView;
            if (c == 1)
            {

                dv.RowFilter = "hotenNV like '%" + cont.Trim() + "%' ";
                //dgvNhanvien.DataSource = dv;
            }
            else
            {
                dv.RowFilter = "maNV like '%" + cont.Trim() + "%' ";
                //dgvNhanvien.DataSource = dv;
            }
            disConnect();
            return dt;

        }
        public DataTable loadCbb()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from LoaiMon", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
        public DataTable getData()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from Menu", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public DataTable find(string fi, int c)
        {
            _conn.Open();
            if(c == 0)
            {
                da = new SqlDataAdapter("select * from Menu where tenMon like N'%" + fi.Trim() + "%' ", _conn);

            }
            else 
                da = new SqlDataAdapter("select * from Menu where maMon like N'%" + fi.Trim() + "%' ", _conn);

            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public DataTable findwPrice(int a, int b)
        {
            _conn.Open();
            if (a == 0 && b != 0)
            {
                da = new SqlDataAdapter("select * from Menu where dongia <= '"+b+"'", _conn);

            }
            else if(a != 0 && b == 0)
                da = new SqlDataAdapter("select * from Menu where dongia >= '"+a+"'", _conn);
            else
                da = new SqlDataAdapter("select * from Menu where dongia >= '" + a + "' and dongia <= '" + b + "' ", _conn);
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

        public bool add(MonAn me)
        {
            string maMon = me.MaMon;
            string maLoai = me.MaLoai;
            string tenMon = me.TenMon;
            int dongia = me.DonGia;
            int chiPhiNL = me.ChiPhiNL;
            if (ktmatrung(maMon) == 1)
            {
                return false;
            }
            string sql = "insert into Menu values('" + maMon + "',N'" + maLoai + "',N'" + tenMon + "',N'" + dongia + "', '"+chiPhiNL+"') ";
            exec(sql);
            return true;
        }
        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from Menu where maMon = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(MonAn me)
        {
            string sql = "update Menu set maLoai= N'" + me.MaLoai + " ',tenMon = N'" + me.TenMon + "',donGia = N'" + me.DonGia + "',chiphiNL = '"+me.ChiPhiNL+"' where maMon = '" + me.MaMon + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from Menu where maMon = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public DataTable FoodStatistic1(int c,string a, string b)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@c", SqlDbType.Int);
            parameters[0].Value = c;
            parameters[1] = new SqlParameter("@a", SqlDbType.NVarChar, 10);
            parameters[1].Value = a;
            parameters[2] = new SqlParameter("@b", SqlDbType.NVarChar, 10);
            parameters[2].Value = b;


            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "FoodStatistic1", parameters);
            DataTable table = new DataTable();
            
            table.Columns.Add("maMon", typeof(string));
            table.Columns.Add("tenMon", typeof(string));
            table.Columns.Add("donGia", typeof(int));
            table.Columns.Add("tongSoluong", typeof(int));


            while (dra.Read())
            {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maMon"].ToString(), dra["tenMon"].ToString(), int.Parse(dra["donGia"].ToString()), int.Parse(dra["tongSoluong"].ToString()));
            }
            dra.Dispose();
            return table;


        }
        public DataTable FoodStatistic2(int c)
        {
            string sql;
            if(c == 0)
            {
                _conn.Open();
                sql = "select maMon, tenMon, donGia from Menu order by dongia";
                da = new SqlDataAdapter(sql, _conn);
                dt = new DataTable();
                da.Fill(dt);
                _conn.Close();
            }
            else
            {
                _conn.Open();
                sql = "select maMon, tenMon, donGia from Menu order by dongia desc";
                da = new SqlDataAdapter(sql, _conn);
                dt = new DataTable();
                da.Fill(dt);
                _conn.Close();
            }
            return dt;
        }
    }
}
