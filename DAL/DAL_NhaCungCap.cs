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
    public class DAL_NhaCungCap:DBconnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader re;

        public DataTable getData()
        {
            _conn.Open();
            da = new SqlDataAdapter("select * from NhaCungCap", _conn);
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

        public bool add(NhaCungCap ncc)
        {
            string maNCC = ncc.MaNCC;
            string tenNCC = ncc.TenNCC;
            string sdt = ncc.Sdt;
            string diaChi = ncc.Diachi;
           
            if (ktmatrung(maNCC) == 1)
            {
                return false;
            }
            string sql = "insert into NhaCungCap values('" + maNCC + "',N'" + tenNCC + "',N'" + sdt + "',N'" + diaChi + "') ";
            exec(sql);
            return true;
        }
        public int ktmatrung(string ma)
        {
            _conn.Open();

            string sql = "select count(*) from NhaCungCap where maNCC = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, _conn);
            int i = (int)cmd.ExecuteScalar();

            _conn.Close();
            return i;
        }
        public bool update(NhaCungCap ncc)
        {
            string sql = "update NhaCungCap set tenNCC= N'" + ncc.TenNCC + " ',sdtNCC = N'" + ncc.Sdt + "',dcNCC = N'" + ncc.Diachi + "' where maNCC = '" + ncc.MaNCC + "' ";
            exec(sql);
            return true;
        }
        public bool delete(string ma)
        {
            string strDel = "delete from NhaCungCap where maNCC = '" + ma + "' ";
            exec(strDel);
            return true;
        }
        public DataTable getNL(string mancc)
        {
            _conn.Open();
            string sql = "select ct.maHD, hd.ngayNhap,  nl.TenNL, ct.soLuong, ct.giaNhap " +
                "from HDNhap hd, CTHD_Nhap ct, NhaCungCap ncc, NguyenLieu nl " +
                "where hd.maNCC = '" + mancc + "' and ct.maHD = hd.maHD and ct.maNL = nl.MaNL and hd.maNCC = ncc.maNCC";
            da = new SqlDataAdapter(sql, _conn);
            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
        public DataTable find(string fi, int c)
        {
            _conn.Open();
            if (c == 0)
            {
                da = new SqlDataAdapter("select * from NhaCungCap where tenNCC like N'%" + fi.Trim() + "%' ", _conn);

            }
            else
                da = new SqlDataAdapter("select * from NhaCungCap where maNCC like N'%" + fi.Trim() + "%' ", _conn);

            dt = new DataTable();
            da.Fill(dt);
            _conn.Close();
            return dt;

        }
    }
}
