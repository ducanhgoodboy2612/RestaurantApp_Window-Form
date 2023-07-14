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
    public class DAL_NhanVien : DBconnect
    {

        private const string PARM_EMPID = "@maNV";
        private const string PARM_EMPNAME = "@hotenNV";

        private const string PARM_SEX = "@gioiTinh";
        private const string PARM_EMPCATE = "@maLoai";
        private const string PARM_YOB = "@namSinh";
        private const string PARM_EMPADD = "@diaChi";
        private const string PARM_EMPPHONE = "@sdt";

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Emp_Sel_All]", null);
            DataTable table = new DataTable();
            table.Columns.Add("maNV", typeof(string));
            table.Columns.Add("hotenNV", typeof(string));
            table.Columns.Add("gioiTinh", typeof(string));

            table.Columns.Add("maLoai", typeof(string));
            table.Columns.Add("namSinh", typeof(int));
            table.Columns.Add("diaChi", typeof(string));
            table.Columns.Add("sdt", typeof(string));

            while (dra.Read())
            {
                table.Rows.Add(dra["maNV"].ToString(), dra["hotenNV"].ToString(), dra["gioiTinh"].ToString(), dra["maLoai"].ToString(), int.Parse(dra["namSinh"].ToString()), dra["diaChi"].ToString(), dra["Sdt"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(NhanVien nv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
       
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_EMPNAME, SqlDbType.NVarChar,50),
                new SqlParameter(PARM_SEX, SqlDbType.NVarChar,10),

                new SqlParameter(PARM_EMPCATE,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_YOB,SqlDbType.Int),
                new SqlParameter(PARM_EMPADD,SqlDbType.NVarChar,150),
                new SqlParameter(PARM_EMPPHONE,SqlDbType.NVarChar,15),
            };
            parm[0].Value = nv.MaNV;
            parm[1].Value = nv.HotenNV;
            parm[2].Value = nv.GioiTinh;
            parm[3].Value = nv.MaLoai;
            parm[4].Value = nv.NamSinh;
            parm[5].Value = nv.DiaChi;
            parm[6].Value = nv.Sdt;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Emp_Ins]", parm);
        }
        public int check_ID(string manv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar)
            };
            parm[0].Value = manv;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Emp_CheckID]", parm);
        }

        public int Update(NhanVien nv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_EMPNAME, SqlDbType.NVarChar,50),
                new SqlParameter(PARM_SEX, SqlDbType.NVarChar,10),

                new SqlParameter(PARM_EMPCATE,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_YOB,SqlDbType.Int),
                new SqlParameter(PARM_EMPADD,SqlDbType.NVarChar,150),
                new SqlParameter(PARM_EMPPHONE,SqlDbType.NVarChar,15),
            };
            parm[0].Value = nv.MaNV;
            parm[1].Value = nv.HotenNV;
            parm[2].Value = nv.GioiTinh;
            parm[3].Value = nv.MaLoai;
            parm[4].Value = nv.NamSinh;
            parm[5].Value = nv.DiaChi;
            parm[6].Value = nv.Sdt;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Emp_Upd", parm);
        }
        public int Delete(string maNV)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10)
            };
            parm[0].Value = maNV;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Emp_Del]", parm);
        }

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
       
       
        public DataTable getAllType()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from LoaiNV", _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public string getType(string ma)
        {
            _conn.Open();
            string sql = "select tenLoai from loaiNV where maLoai = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            string name = (string)cmd.ExecuteScalar();
            _conn.Close();
            return name;

        }
    }
}
