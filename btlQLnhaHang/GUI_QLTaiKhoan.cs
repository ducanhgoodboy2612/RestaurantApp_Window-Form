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
    public partial class GUI_QLTaiKhoan : Form
    {
        public GUI_QLTaiKhoan()
        {
            InitializeComponent();
        }
        BUS_QLTaiKhoan bus = new BUS_QLTaiKhoan();

        private void GUI_QLTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvUser.DataSource = bus.getData();

            dgvUser.Columns[0].HeaderText = "Mã nhân viên";
            dgvUser.Columns[1].HeaderText = "Password";
            dgvUser.Columns[2].HeaderText = "Quyền truy cập";
         


            for (int i = 0; i < 3; ++i)
            {
                dgvUser.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


            dgvUser.EnableHeadersVisualStyles = false;
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvUser[0, e.RowIndex].Value.ToString();
            txtPass.Text = dgvUser[1, e.RowIndex].Value.ToString();
            cbbPer.Text = dgvUser[2, e.RowIndex].Value.ToString();

            txtMa.Enabled = false;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string pass = txtPass.Text;
            string per = cbbPer.Text;
            
            if (bus.add(ma, pass, per) == true)
            {
                MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvUser.DataSource = bus.getData();
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox) (ctrl as TextBox).Text = "";
                if (ctrl is ComboBox) (ctrl as ComboBox).Text = "";
            }
            txtMa.Enabled = true;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string pass = txtPass.Text;
            string per = cbbPer.Text;

            if (bus.upd(ma, pass, per) == true)
            {
                MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvUser.DataSource = bus.getData();
            }
            else
            {
                MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                string id = txtMa.Text;
                if (bus.del(id) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUser.DataSource = bus.getData();
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
