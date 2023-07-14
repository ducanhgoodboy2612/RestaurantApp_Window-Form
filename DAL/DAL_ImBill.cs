using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class DAL_ImBill:DBconnect
    {
        private const string PARM_BILLID = "@maHD";
        private const string PARM_EMPID = "@maNV";

        private const string PARM_SUPID = "@maNCC";
        private const string PARM_DATE = "@ngayNhap";
        private const string PARM_TOTAL = "@TongHD";




        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[ImBill_Sel_All]", null);
            DataTable table = new DataTable();
            //if (c == 0)
            //{
            table.Columns.Add("maHD", typeof(string));
            table.Columns.Add("hotenNV", typeof(string));
            table.Columns.Add("tenNCC", typeof(string));
            table.Columns.Add("ngayNhap", typeof(string));
            table.Columns.Add("tongHD", typeof(int));


            while (dra.Read())
            {
                table.Rows.Add(dra["maHD"].ToString(), dra["hotenNV"].ToString(), dra["tenNCC"].ToString(), dra["ngayNhap"].ToString(), int.Parse(dra["tongHD"].ToString()));
            }
            dra.Dispose();
            return table;
        }

        public DataTable getEmp()
        {

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Chef_Sel_All]", null);
            DataTable table = new DataTable();

            table.Columns.Add("maNV", typeof(string));
            table.Columns.Add("hotenNV", typeof(string));


            while (dra.Read())
            {
                table.Rows.Add(dra["maNV"].ToString(), dra["hotenNV"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(HoaDonNhap x)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_SUPID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_DATE,SqlDbType.Date),
            };
            parm[0].Value = x.MaHD;
            parm[1].Value = x.MaNV;
            parm[2].Value = x.MaNCC;
            parm[3].Value = x.NgayLap;
       

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[ImBill_Ins]", parm);
        }
        public int check_ID(string mahd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar)
            };
            parm[0].Value = mahd;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[ImBill_CheckID]", parm);
        }
        public int Update(string maHD, string maNV, string maNCC, string ngayLap)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_SUPID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_DATE,SqlDbType.Date),
          
            };
            parm[0].Value = maHD;
            parm[1].Value = maNV;
            parm[2].Value = maNCC;
            parm[3].Value = ngayLap;
      

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[ImBill_Upd]", parm);
        }
        public int Delete(string maHD)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15)
            };
            parm[0].Value = maHD;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[ImBill_Del]", parm);
        }





        public DataTable getData()
        {
            _conn.Open();
            string sql = "select hd.maHD, nv.hotenNV, ncc.tenNCC, ngayNhap, sum(ct.soLuong*ct.giaNhap) as [TongHD] from HDNhap hd, NhaCungCap ncc, NhanVien nv, CTHD_Nhap ct where hd.maNV = nv.maNV and hd.maNCC = ncc.maNCC and hd.maHD = ct.maHD group by hd.maHD, nv.hotenNV, ncc.tenNCC, ngayNhap";
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
    }
}
