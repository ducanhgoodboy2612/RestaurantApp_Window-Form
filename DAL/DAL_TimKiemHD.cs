using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_TimKiemHD
    {

        public DataTable SearchBill(string maHD, string tenKH, int gia1, int gia2)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@maHD", SqlDbType.NVarChar, 10);
            parameters[0].Value = maHD;
            parameters[1] = new SqlParameter("@tenKH", SqlDbType.NVarChar, 150);
            parameters[1].Value = tenKH;
            parameters[2] = new SqlParameter("@gia1", SqlDbType.Int);
            parameters[2].Value = gia1;
            parameters[3] = new SqlParameter("@gia2", SqlDbType.Int);
            parameters[3].Value = gia2;

            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "[SearchBill]", parameters);
            DataTable table = new DataTable();
            table.Columns.Add("maHD", typeof(string));
            table.Columns.Add("hotenNV", typeof(string));
            table.Columns.Add("tenKH", typeof(string));

            table.Columns.Add("sdtKH", typeof(string));
            table.Columns.Add("tenBan", typeof(string));
            table.Columns.Add("ngayLap", typeof(string));
            table.Columns.Add("maKM", typeof(string));
            //table.Columns.Add("thanhToan", typeof(int));
            table.Columns.Add("tongHD", typeof(int));

            while (dra.Read())
            {
                //DateTime ngayLap = Convert.ToDateTime(dra["ngayLap"]);
                //string ngayLapFormatted = ngayLap.ToString("dd/MM/yyyy");
                table.Rows.Add(dra["maHD"].ToString(), dra["maNV"].ToString(), dra["tenKH"].ToString(), dra["sdtKH"].ToString(), dra["maBan"].ToString(), dra["ngayLap"].ToString(), dra["maKM"].ToString(), int.Parse(dra["tongHD"].ToString()));
            }
            dra.Dispose();
            return table;
        }
    }
}
