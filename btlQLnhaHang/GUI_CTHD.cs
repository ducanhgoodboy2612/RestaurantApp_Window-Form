using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;
namespace btlQLnhaHang
{
    public partial class GUI_CTHD : Form
    {
        public GUI_CTHD()
        {
            InitializeComponent();
        }
        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        BUS_CTHD bus_ct = new BUS_CTHD();
        int billTy = 0;
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
        void loadData()
        {
            int c = billTy;
            dgvDetail.DataSource = bus_ct.getData(cbbBill.Text, c);

            if (c == 0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    dgvDetail.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvDetail.EnableHeadersVisualStyles = false;
                dgvDetail.Columns[0].HeaderText = "Mã HĐ";
                dgvDetail.Columns[1].HeaderText = "Mã món";
                dgvDetail.Columns[2].HeaderText = "Số lượng";
                dgvDetail.Columns[3].HeaderText = "Đơn giá";
                
            }
            else
            {
                for (int i = 0; i < 4; ++i)
                {
                    dgvDetail.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvDetail.EnableHeadersVisualStyles = false;
                dgvDetail.Columns[0].HeaderText = "Mã HĐ";
                dgvDetail.Columns[1].HeaderText = "Mã nguyên liệu";
                dgvDetail.Columns[2].HeaderText = "Số lượng";
                dgvDetail.Columns[3].HeaderText = "Đơn giá";

            }

        }
        void loadHD()
        {
            cbbBill.DataSource = bus_ct.loadHD(billTy);
            cbbBill.DisplayMember = "maHD";
            cbbBill.ValueMember = "maHD";
        }

        private void GUI_CTHD_Load(object sender, EventArgs e)
        {
            //loadData();
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            billTy = 0;
            //loadData();
            loadHD();
            label6.Text = "Giá bán";
            lblTen.Text = "Tên món";


            cbbTen.DataSource = bus_ct.loadMa(0);
            cbbTen.DisplayMember = "tenMon";
            cbbTen.ValueMember = "maMon";
        }

        private void tb2_CheckedChanged(object sender, EventArgs e)
        {
            billTy = 1;
            label6.Text = "Giá nhập";
            //loadData();
            loadHD();
            cbbTen.DataSource = bus_ct.loadMa(1);
            cbbTen.DisplayMember = "tenNL";
            cbbTen.ValueMember = "maNL";
            lblTen.Text = "Nguyên liệu";
        }

        private void cbbBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = billTy;
            dgvDetail.DataSource = bus_ct.getData(cbbBill.Text, c);

            if (c == 0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    dgvDetail.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvDetail.EnableHeadersVisualStyles = false;
                dgvDetail.Columns[0].HeaderText = "Mã HĐ";
                dgvDetail.Columns[1].HeaderText = "Mã món";
                dgvDetail.Columns[2].HeaderText = "Số lượng";
                dgvDetail.Columns[3].HeaderText = "Đơn giá";

            }
            else
            {
                for (int i = 0; i < 4; ++i)
                {
                    dgvDetail.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvDetail.EnableHeadersVisualStyles = false;
                dgvDetail.Columns[0].HeaderText = "Mã HĐ";
                dgvDetail.Columns[1].HeaderText = "Mã nguyên liệu";
                dgvDetail.Columns[2].HeaderText = "Số lượng";
                dgvDetail.Columns[3].HeaderText = "Đơn giá";

            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvDetail[0, e.RowIndex].Value.ToString();
            cbbTen.SelectedValue = dgvDetail[1, e.RowIndex].Value.ToString();
            numSl.Value = int.Parse(dgvDetail[2, e.RowIndex].Value.ToString());
            txtGia.Text = dgvDetail[3, e.RowIndex].Value.ToString();
            txtMa.Enabled = false;
            txtGia.Enabled = false;

            if (billTy == 0)
            {

                lblTen.Text = "Tên món";
            }
            else
            {
                lblTen.Text = "Tên nguyên liệu";

            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string maHD = txtMa.Text;
            string ma = cbbTen.SelectedValue.ToString();
            int sl = int.Parse(numSl.Value.ToString());
            int gia = int.Parse(txtGia.Text);

            if (billTy == 0)
            {
               

                CTHD ct = new CTHD(maHD, ma, sl, gia);
                if (bus_ct.upd(ct) == true)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDetail.DataSource = bus_ct.getData(cbbBill.Text, billTy);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                CTHDNhap ct = new CTHDNhap(maHD, ma, sl, gia);
                if (bus_ct.upd(ct) == true)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDetail.DataSource = bus_ct.getData(cbbBill.Text, billTy);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
      
        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btDel_Click_1(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                string maHD = txtMa.Text;
                string ma = cbbTen.SelectedValue.ToString();
                if (bus_ct.del(maHD, ma, billTy) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDetail.DataSource = bus_ct.getData(cbbBill.Text, billTy);
                }

            }
        }

        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox) (ctrl as TextBox).Text = "";
                if (ctrl is ComboBox) (ctrl as ComboBox).Text = "";
            }
            txtMa.Enabled = true;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
