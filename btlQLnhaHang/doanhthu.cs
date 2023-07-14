using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace btlQLnhaHang
{
    public partial class doanhthu : Form
    {
        public doanhthu()
        {
            InitializeComponent();
        }
        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        void Connect()
        {
            conn = new SqlConnection(strKetNoi);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        void disConnect()
        {
            conn = new SqlConnection(strKetNoi);
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        private void rbDay_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbDay.Checked)
            //{
            //    Connect();
            //    string today = DateTime.Now.ToString("dd-MM-yyyy");
            //    string sql = "select sum(tongTien) from Table_HDBan";
            //    cmd = new SqlCommand(sql, conn);
            //    string dt = cmd.ExecuteScalar().ToString();
            //    decimal so;
            //    so = decimal.Parse(dt, System.Globalization.NumberStyles.Currency);
            //    dt = so.ToString("#,#");
            //    lblResult.Text = "Doanh thu ngày hôm nay (" + today + ") là " ;
            //    lblMo.Text = dt + " VNĐ";
            //    disConnect();
            //}
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbMonth.Checked)
            //{
            //    Connect();
            //    int m = DateTime.Now.Month;
            //    int y = DateTime.Now.Year;
            //    string sql = "select sum( DonGia * SLdaban) as tong from Table_DV ";
            //    cmd = new SqlCommand(sql, conn);
            //    string dt = cmd.ExecuteScalar().ToString();
            //    decimal so;
            //    so = decimal.Parse(dt, System.Globalization.NumberStyles.Currency);
            //    dt = so.ToString("#,#");
            //    lblResult.Text = "Doanh thu trong tháng " + m.ToString() + " năm " + y.ToString() + " là ";
            //    lblMo.Text = dt + " VNĐ";
            //    disConnect();
            //}
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        int dthu, luong, cpnl;
        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            //if (rb1.Checked)
            //{
            //    Connect();
                
            //    string sql = "select sum( DonGia * SLdaban) as tong from Table_DV ";
            //    cmd = new SqlCommand(sql, conn);
            //    string dt = cmd.ExecuteScalar().ToString();
            //    decimal so;
            //    so = decimal.Parse(dt, System.Globalization.NumberStyles.Currency);
            //    dt = so.ToString("#,#");
            //    lblName.Text = "TỔNG DOANH THU: ";
            //    lblMo.Text = dt + " VNĐ";
            //    disConnect();
            //}
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            //if (rb2.Checked)
            //{
            //    Connect();

            //    string sql = "select sum(chiPhiNL * SLdaban) as tong from Table_DV ";
            //    cmd = new SqlCommand(sql, conn);
            //    string dt = cmd.ExecuteScalar().ToString();
            //    decimal so;
            //    so = decimal.Parse(dt, System.Globalization.NumberStyles.Currency);
            //    dt = so.ToString("#,#");
            //    lblName.Text = "TỔNG CHI PHÍ NGUYÊN LIỆU: ";
            //    lblMo.Text = dt + " VNĐ";

            //    disConnect();
            //}

        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            if (rb4.Checked)
            {
                Connect();

                string sql = "select sum(Luong) as tong from Table_NV ";
                cmd = new SqlCommand(sql, conn);
                string dt = cmd.ExecuteScalar().ToString();
                luong = int.Parse(dt);

                sql = "select sum(chiPhiNL * SLdaban) as tong from Table_DV ";
                cmd = new SqlCommand(sql, conn);
                dt = cmd.ExecuteScalar().ToString();
                cpnl = int.Parse(dt);

                sql = "select sum(DonGia * SLdaban) as tong from Table_DV ";
                cmd = new SqlCommand(sql, conn);
                dt = cmd.ExecuteScalar().ToString();
                dthu = int.Parse(dt);
                string tonglai = (dthu - cpnl - luong).ToString();
                for (int i = tonglai.Length - 3; i >= 1; i -= 3)
                    tonglai = tonglai.Insert(i, ".");
                //decimal so;
                //so = decimal.Parse(tonglai, System.Globalization.NumberStyles.Currency);
                //tonglai = so.ToString("#,#");
                lblName.Text = "TỔNG LÃI: ";
                lblMo.Text = tonglai + " VNĐ";
                
                disConnect();
            }
            
        }

        private void doanhthu_Load(object sender, EventArgs e)
        {
           
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;
            lblHe.Text = "Tháng " + m.ToString() + " năm " + y.ToString() + "";
        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3.Checked)
            {
                Connect();

                string sql = "select sum(Luong) as tong from Table_NV ";
                cmd = new SqlCommand(sql, conn);
                string dt = cmd.ExecuteScalar().ToString();
                decimal so;
                so = decimal.Parse(dt, System.Globalization.NumberStyles.Currency);
                dt = so.ToString("#,#");
                lblName.Text = "TỔNG LƯƠNG NHÂN VIÊN: ";
                lblMo.Text = dt + " VNĐ";
                disConnect();
            }
        }
    }
}
