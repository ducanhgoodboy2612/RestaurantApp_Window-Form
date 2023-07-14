using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_FoodMenu
    {
        private const string PARM_FOODID = "@maMon";
        private const string PARM_CATEID = "@maLoai";
        private const string PARM_CATENAME = "@tenLoai";

        private const string PARM_FOODNAME = "@tenMon";
        private const string PARM_PRICE = "@donGia";
        private const string PARM_MCOST = "@chiphiNL";

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Menu_Sel_All]", null);
            DataTable table = new DataTable();
            table.Columns.Add("maMon", typeof(string));
            table.Columns.Add("maLoai", typeof(string));
            table.Columns.Add("tenMon", typeof(string));
            
            table.Columns.Add("donGia", typeof(int));
            table.Columns.Add("chiphiNL", typeof(int));

            while (dra.Read())
            {
                table.Rows.Add(dra["maMon"].ToString(),  dra["maLoai"].ToString(), dra["tenMon"].ToString(), int.Parse(dra["donGia"].ToString()), int.Parse(dra["chiphiNL"].ToString()));
            }
            dra.Dispose();
            return table;
        }

        public DataTable getAllbyNV(string maLoai)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@maLoai", SqlDbType.NVarChar, 10);
            parameters[0].Value = maLoai;

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Menu2_Sel_All]", parameters);
            DataTable table = new DataTable();
            table.Columns.Add("maMon", typeof(string));
            table.Columns.Add("tenLoai", typeof(string));
            table.Columns.Add("tenMon", typeof(string));

            table.Columns.Add("donGia", typeof(int));
            

            while (dra.Read())
            {
                table.Rows.Add(dra["maMon"].ToString(), dra["tenLoai"].ToString(), dra["tenMon"].ToString(), int.Parse(dra["donGia"].ToString()));

            }
            dra.Dispose();
            return table;
        }

        public DataTable findInMenu(string maMon, string tenMon, int gia1, int gia2)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@maMon", SqlDbType.NVarChar, 10);
            parameters[0].Value = maMon;
            parameters[1] = new SqlParameter("@tenMon", SqlDbType.NVarChar, 150);
            parameters[1].Value = tenMon;
            parameters[2] = new SqlParameter("@gia1", SqlDbType.Int);
            parameters[2].Value = gia1;
            parameters[3] = new SqlParameter("@gia2", SqlDbType.Int);
            parameters[3].Value = gia2;

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[SearchMenu]", parameters);
            DataTable table = new DataTable();
            table.Columns.Add("maMon", typeof(string));
            table.Columns.Add("maLoai", typeof(string));
            table.Columns.Add("tenMon", typeof(string));

            table.Columns.Add("donGia", typeof(int));
            table.Columns.Add("chiphiNL", typeof(int));

            while (dra.Read())
            {
                table.Rows.Add(dra["maMon"].ToString(), dra["maLoai"].ToString(), dra["tenMon"].ToString(), int.Parse(dra["donGia"].ToString()), int.Parse(dra["chiphiNL"].ToString()));
            }
            dra.Dispose();
            return table;
        }

        public DataTable getFoodCate()
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
        public int Insert(string mamon, string maloai, string tenmon, int dongia, int chiphiNL)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_CATEID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_FOODNAME,SqlDbType.NVarChar,150),
                
                new SqlParameter(PARM_PRICE,SqlDbType.Int),
                new SqlParameter(PARM_MCOST,SqlDbType.Int),
            };
            parm[0].Value = mamon;
            parm[1].Value = tenmon;
            parm[2].Value = maloai;
            parm[3].Value = dongia;
            parm[4].Value = chiphiNL;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Menu_Ins]", parm);
        }
        public int check_ID(string mamon)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar)
            };
            parm[0].Value = mamon;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Menu_CheckID]", parm);
        }
        public int find_with_ID(string mamon)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar)
            };
            parm[0].Value = mamon;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Menu_CheckID]", parm);
        }
        public int Update(string mamon, string maloai, string tenmon, int dongia, int chiphiNL)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_FOODNAME,SqlDbType.NVarChar,150),
                new SqlParameter(PARM_CATEID,SqlDbType.NVarChar,10),
                new SqlParameter(PARM_PRICE,SqlDbType.Int),
                new SqlParameter(PARM_MCOST,SqlDbType.Int),
            };
            parm[0].Value = mamon;
            parm[1].Value = maloai;
            parm[2].Value = tenmon;
            parm[3].Value = dongia;
            parm[4].Value = chiphiNL;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "Menu_Upd", parm);
        }
        public int Delete(string mamon)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_FOODID,SqlDbType.NVarChar,10)
            };
            parm[0].Value = mamon;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Menu_Del]", parm);
        }
    }
}
