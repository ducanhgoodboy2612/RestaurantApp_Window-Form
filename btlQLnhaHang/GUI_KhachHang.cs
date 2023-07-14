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
    public partial class GUI_KhachHang : Form
    {
        public GUI_KhachHang()
        {
            InitializeComponent();
        }
        //string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        //SqlConnection conn;
        //SqlDataAdapter da;
        //DataTable dt;
        BUS_KhachHang bus_kh = new BUS_KhachHang();
      
        void loadData()
        {
            
            dgvKH.DataSource = bus_kh.getData();
            dgvKH.Columns[0].HeaderText = "Mã KH";
            dgvKH.Columns[1].HeaderText = "Tên KH";
            dgvKH.Columns[2].HeaderText = "SĐT";
            dgvKH.Columns[3].HeaderText = "Email";
            dgvKH.Columns[4].HeaderText = "Điểm tích lũy";


            for (int i = 0; i < 5; ++i)
            {
                dgvKH.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


            dgvKH.EnableHeadersVisualStyles = false;

            dgvKH.Columns[1].Width = 170;

            
        }
        SqlCommand cmd;
      


        private void KhachHang_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvKH[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvKH[1, e.RowIndex].Value.ToString();
            txtPhone.Text = dgvKH[2, e.RowIndex].Value.ToString();
            txtEmail.Text = dgvKH[3, e.RowIndex].Value.ToString();
            txtDtl.Text = dgvKH[4, e.RowIndex].Value.ToString();
            txtMa.Enabled = false;
            int index = e.RowIndex;
            dgvKH.Rows[index].Selected = true;
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

        private void btAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            string sdt = txtPhone.Text;
            string email = txtEmail.Text;
            int dtl = int.Parse(txtDtl.Text);


            KhachHang kh = new KhachHang(ma, ten, sdt, email, dtl);
            if (bus_kh.add(kh) == true)
            {
                MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKH.DataSource = bus_kh.getData();
            }
            else
            {
                MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            string sdt = txtPhone.Text;
            string email = txtEmail.Text;
            int dtl = int.Parse(txtDtl.Text);


            KhachHang kh = new KhachHang(ma, ten, sdt, email, dtl);
            if (bus_kh.upd(kh) == true)
            {
                MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKH.DataSource = bus_kh.getData();
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
                string maKH = txtMa.Text;
                if (bus_kh.del(maKH) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKH.DataSource = bus_kh.getData();
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            if (rbten.Checked)
            {
                dgvKH.DataSource = bus_kh.find(txtFind.Text, 0);
            }
            else
                dgvKH.DataSource = bus_kh.find(txtFind.Text, 1);
        }

        private void brReturn_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

       
    }
}
