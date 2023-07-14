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
    public partial class GUI_NCC : Form
    {
        public GUI_NCC()
        {
            InitializeComponent();
        }
       
        BUS_NhaCungCap bus_cc = new BUS_NhaCungCap();
       
        void loadData()
        {
            dgvNCC.DataSource = bus_cc.getData();



            for (int i = 0; i < 4; ++i)
            {
                dgvNCC.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvNCC.EnableHeadersVisualStyles = false;
            dgvNCC.Columns[0].HeaderText = "Mã NCC";
            dgvNCC.Columns[1].HeaderText = "Tên NCC";
            dgvNCC.Columns[2].HeaderText = "SĐT";
            dgvNCC.Columns[3].HeaderText = "Địa chỉ";

            dgvNCC.Columns[1].Width = 200;
            dgvNCC.Columns[3].Width = 200;

        }
        void LoadNL()
        {
           
            dgvNL.DataSource = bus_cc.getNL(txtMa.Text);
            dgvNL.Columns[0].HeaderText = "Mã nguyên liệu";
            dgvNL.Columns[1].HeaderText = "Mã nguyên liệu";
            dgvNL.Columns[2].HeaderText = "Số lượng còn";
            dgvNL.Columns[1].Width = 200;

        }
        SqlCommand cmd;
      
        private void NCC_Load(object sender, EventArgs e)
        {
            loadData();

        }

    

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvNCC[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvNCC[1, e.RowIndex].Value.ToString();
            txtPhone.Text = dgvNCC[2, e.RowIndex].Value.ToString();
            txtAdd.Text = dgvNCC[3, e.RowIndex].Value.ToString();
            txtMa.Enabled = false;
            int index = e.RowIndex;
            dgvNCC.Rows[index].Selected = true;

            dgvNL.DataSource = bus_cc.getNL(txtMa.Text);

            dgvNL.Columns[0].HeaderText = "Mã HĐN";
            dgvNL.Columns[1].HeaderText = "Ngày nhập";
            dgvNL.Columns[2].HeaderText = "Nguyên liệu";
            dgvNL.Columns[3].HeaderText = "Số lượng";
            dgvNL.Columns[4].HeaderText = "Đơn giá";


            for (int i = 0; i < 5; ++i)
            {
                dgvNL.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvNL.EnableHeadersVisualStyles = false;

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            //LoadNL();

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
            string dc = txtAdd.Text;



            NhaCungCap ncc = new NhaCungCap(ma, ten, sdt, dc);
            if (bus_cc.add(ncc) == true)
            {
                MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNCC.DataSource = bus_cc.getData();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            string sdt = txtPhone.Text;
            string dc = txtAdd.Text;



            NhaCungCap ncc = new NhaCungCap(ma, ten, sdt, dc);
            if (bus_cc.upd(ncc) == true)
            {
                MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNCC.DataSource = bus_cc.getData();
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
                string maNCC = txtMa.Text;
                if (bus_cc.del(maNCC) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNCC.DataSource = bus_cc.getData();
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
                dgvNCC.DataSource = bus_cc.find(txtFind.Text, 0);
            }
            else
                dgvNCC.DataSource = bus_cc.find(txtFind.Text, 1);
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
