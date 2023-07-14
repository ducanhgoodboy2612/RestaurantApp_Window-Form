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
    public class DAL_ThongKe: DBconnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader re;

        public DataTable sxTheoLuong(int x)
        {
            _conn.Open();
            string sql = "select maNV, hoTenNV, ngaysinh, luong, namBD from Table_NV order by luong";
            if (x == 1) sql += " desc";
            da = new SqlDataAdapter(sql, _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;
        }
    }
}
