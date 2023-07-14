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
    public class DAL_Bill
    {
        private const string PARM_BILLID = "@maHD";
        private const string PARM_EMPID = "@maNV";
        private const string PARM_EMPNAME = "@hotenNV";

        private const string PARM_CUSNAME = "@tenKH";
        private const string PARM_CUSPHONE = "@sdtKH";
        private const string PARM_TABID = "@maBan";
        private const string PARM_TABNAME = "@tenBan";
        private const string PARM_DATE = "@ngayLap";
        private const string PARM_SALEID = "@maKM";
        private const string PARM_STATE = "@thanhToan"; 
        private const string PARM_FOODID = "@maMon";

        private const string PARM_TOTAL = "@Tong HD";

        //private const string PARM_SUPID = "@maNCC";

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Bill_Sel_Full]", null);
            DataTable table = new DataTable();
            //if (c == 0)
            //{
                table.Columns.Add("maHD", typeof(string));
                table.Columns.Add("hotenNV", typeof(string));
                table.Columns.Add("tenKH", typeof(string));

                table.Columns.Add("sdtKH", typeof(string));
                table.Columns.Add("tenBan", typeof(string));
                table.Columns.Add("ngayLap", typeof(string));
                table.Columns.Add("maKM", typeof(string));
                //table.Columns.Add("thanhToan", typeof(int));
                table.Columns.Add("tong HD", typeof(int));

            while (dra.Read())
                {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maHD"].ToString(), dra["hotenNV"].ToString(), dra["tenKH"].ToString(), dra["sdtKH"].ToString(), dra["tenBan"].ToString(), dra["ngayLap"].ToString(), dra["maKM"].ToString(), int.Parse(dra["tong HD"].ToString()));
                }
                dra.Dispose();
                return table;

            

        }

        public DataTable getEmp()
        {

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Recep_Sel_All]", null);
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

        public DataTable getTab()
        {

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Table_Sel_All]", null);
            DataTable table = new DataTable();

            table.Columns.Add("maBan", typeof(string));
            table.Columns.Add("tenBan", typeof(string));


            while (dra.Read())
            {
                table.Rows.Add(dra["maBan"].ToString(), dra["tenBan"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public DataTable getSale()
        {

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Sale_Sel_All]", null);
            DataTable table = new DataTable();

            table.Columns.Add("maKM", typeof(string));
            table.Columns.Add("tenCT", typeof(string));


            while (dra.Read())
            {
                table.Rows.Add(dra["maKM"].ToString(), dra["tenCT"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public DataTable getSup()
        {

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Sup_Sel_All]", null);
            DataTable table = new DataTable();

            table.Columns.Add("maNCC", typeof(string));
            table.Columns.Add("tenNCC", typeof(string));


            while (dra.Read())
            {
                table.Rows.Add(dra["maNCC"].ToString(), dra["tenNCC"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(HoaDon x)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_CUSNAME,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_CUSPHONE,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_TABID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_DATE,SqlDbType.Date),
                new SqlParameter(PARM_SALEID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_STATE,SqlDbType.Int),
            };
            parm[0].Value = x.MaHD;
            parm[1].Value = x.MaNV;
            parm[2].Value = x.TenKH;
            parm[3].Value = x.SdtKH;
            parm[4].Value = x.MaBan;
            parm[5].Value = x.NgayLap;
            parm[6].Value = x.MaKM;
            parm[7].Value = x.ThanhToan;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Bill_Ins]", parm);
        }
        public int check_ID(string mahd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar)
            };
            parm[0].Value = mahd;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Bill_CheckID]", parm);
        }

        public int check_foodID(string mahd, string maMon)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar,10)
            };
            parm[0].Value = mahd;
            parm[1].Value = maMon;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Food_CheckID_inDetail]", parm);
        }

        public int Update(string maHD, string maNV, string tenKH, string sdtKH, string maBan, string ngayLap, string maKM, int thanhToan)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_EMPID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_CUSNAME,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_CUSPHONE,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_TABID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_DATE,SqlDbType.Date),
                new SqlParameter(PARM_SALEID,SqlDbType.NVarChar,15),
                new SqlParameter(PARM_STATE,SqlDbType.Int),
            };
            parm[0].Value = maHD;
            parm[1].Value = maNV;
            parm[2].Value = tenKH;
            parm[3].Value = sdtKH;
            parm[4].Value = maBan;
            parm[5].Value = ngayLap;
            parm[6].Value = maKM;
            parm[7].Value = thanhToan;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Bill_Upd]", parm);
        }
        public int Delete(string maHD)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_BILLID,SqlDbType.NVarChar,15)
            };
            parm[0].Value = maHD;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Bill_Del]", parm);
        }

        
    }
}
