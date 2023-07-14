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
    public class DAL_TTNguoiDung:DBconnect
    {
        private const string PARM_EMPID = "@maNV";
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

        void exec(string sql)
        {
            _conn.Open();
            cmd = new SqlCommand(sql, _conn);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public List<string> getInfo(string maNV)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

                new SqlParameter("@maNV",SqlDbType.NVarChar,10)
            };
            parm[0].Value = maNV;
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[Emp_Sel_info]", parm);
            List<string> nhanVienInfo = new List<string>();

            if (dra.Read())
            {
                nhanVienInfo.Add(dra["maNV"].ToString());
                nhanVienInfo.Add(dra["hotenNV"].ToString());
                nhanVienInfo.Add(dra["gioiTinh"].ToString());
                nhanVienInfo.Add(dra["maLoai"].ToString());
                nhanVienInfo.Add(dra["namSinh"].ToString());
                nhanVienInfo.Add(dra["diaChi"].ToString());
                nhanVienInfo.Add(dra["Sdt"].ToString());
            }

            dra.Dispose();
            return nhanVienInfo;
        }

        public int check(string maNV, string currPass, string newPass, string rePass)
        {
            Connect();
            string sql = "select pass from Users where userID = '" + maNV + "'";
            cmd = new SqlCommand(sql, _conn);
            string curPass = (string)cmd.ExecuteScalar();
            disConnect();

            if (currPass == curPass)
            {
                if (newPass == rePass)
                {
                    string strUpdate = "update Users set pass = '" + newPass + " ' where userID = '" + maNV + "' ";
                    exec(strUpdate);
                    return 0;
                }
                else return 1;
            }
            else return 2;
        }
    }
}
