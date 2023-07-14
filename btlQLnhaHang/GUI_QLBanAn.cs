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
using DTO;
using BUS;
namespace btlQLnhaHang
{
    public partial class GUI_QLBanAn : Form
    {
        public GUI_QLBanAn()
        {
            InitializeComponent();
        }
        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;

        BUS_QLBanAn bus_qlB = new BUS_QLBanAn();

      
        void loadData()
        {
            dgvBanAn.DataSource = bus_qlB.getData();


            for (int i = 0; i < 5; ++i)
            {
                dgvBanAn.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvBanAn.EnableHeadersVisualStyles = false;

            dgvBanAn.Columns[0].HeaderText = "Mã Bàn";
            dgvBanAn.Columns[1].HeaderText = "Tên Bàn";
            dgvBanAn.Columns[2].HeaderText = "SL Khách";
            dgvBanAn.Columns[3].HeaderText = "Giá";
            dgvBanAn.Columns[4].HeaderText = "Tình trạng";

            txtMa.Enabled = false;


        }
       

        private void GUI_QLBanAn_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMa.Text;
                string ten = txtName.Text;
                int slCho = int.Parse(cbbSlK.Text);
                int giaBan = int.Parse(txtGia.Text);
                int tinhTrang = int.Parse(cbbTT.Text);


                BanAn ban = new BanAn(ma, ten, slCho, giaBan, tinhTrang);
                if (bus_qlB.add(ban) == true)
                {
                    MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBanAn.DataSource = bus_qlB.getData();
                }
                else
                {
                    MessageBox.Show("Mã bàn đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBanAn_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvBanAn[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvBanAn[1, e.RowIndex].Value.ToString();
            cbbSlK.Text = dgvBanAn[2, e.RowIndex].Value.ToString();
            txtGia.Text = dgvBanAn[3, e.RowIndex].Value.ToString();
            cbbTT.Text = dgvBanAn[4, e.RowIndex].Value.ToString();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                string ma = txtMa.Text;
                string ten = txtName.Text;
                int slCho = int.Parse(cbbSlK.Text);
                int giaBan = int.Parse(txtGia.Text);
                int tinhTrang = int.Parse(cbbTT.Text);


                BanAn ban = new BanAn(ma, ten, slCho, giaBan, tinhTrang);
                if (bus_qlB.upd(ban) == true)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBanAn.DataSource = bus_qlB.getData();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string maNCC = txtMa.Text;
                if (bus_qlB.del(maNCC) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBanAn.DataSource = bus_qlB.getData();
                }
                else
                {
                    MessageBox.Show("Xoá thông tin không thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
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
    }
}
