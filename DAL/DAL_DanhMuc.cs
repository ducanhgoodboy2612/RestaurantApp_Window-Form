using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DTO;
namespace DAL
{
    public class DAL_DanhMuc:DBconnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        private const string PARM_CATEID = "@maloai";
        private const string PARM_CATENAME = "@tenLoai";

        void exec(string sql)
        {
            _conn.Open();
            cmd = new SqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Cate_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("maLoai", typeof(string));
            table.Columns.Add("tenLoai", typeof(string));
           
            while (dra.Read())
            {
                table.Rows.Add(dra["maLoai"].ToString(), dra["tenLoai"].ToString());
            }
            dra.Dispose();
            return table;
        }
        public int Insert(string maloai, string tenloai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_CATEID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_CATENAME,SqlDbType.NVarChar,50),
            };
            parm[0].Value = maloai;
            parm[1].Value = tenloai;
            
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Cate_Ins", parm);
        }
        public int checkCate_ID(string classID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_CATEID,SqlDbType.NVarChar)
            };
            parm[0].Value = classID;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Cate_CheckID", parm);
        }
        public int Update(string maLoai, string tenLoai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
               new SqlParameter(PARM_CATEID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_CATENAME,SqlDbType.NVarChar,50),
            };
            parm[0].Value = maLoai;
            parm[1].Value = tenLoai;
           
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Cate_Upd", parm);
        }
        public int Delete(string maloai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_CATEID,SqlDbType.NVarChar,10)
            };
            parm[0].Value = maloai;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Category_Del", parm);
        }
    }
}
