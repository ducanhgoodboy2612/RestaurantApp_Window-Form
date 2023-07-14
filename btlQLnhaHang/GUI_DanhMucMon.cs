using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;
namespace btlQLnhaHang
{
    public partial class GUI_DanhMucMon : Form
    {
        BUS_DanhMucmon bus = new BUS_DanhMucmon();
        public GUI_DanhMucMon()
        {
            InitializeComponent();
        }

        private void GUI_DanhMucMon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgvCate.DataSource = bus.getAll();
            dgvCate.Columns[0].HeaderText = "Mã danh mục";
            dgvCate.Columns[1].HeaderText = "Tên danh mục";
            


            for (int i = 0; i < 2; ++i)
            {
                dgvCate.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


            dgvCate.EnableHeadersVisualStyles = false;

            dgvCate.Columns[1].Width = 250;
            txtMa.Focus();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
           
                if (txtMa.Text == "" || txtName.Text == "")
                    MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    //try
                    //{
                        int val = bus.Insert(new DanhMucMon(txtMa.Text, txtName.Text));
                        LoadData();
                        if (val == -1)
                            MessageBox.Show("Thêm dữ liệu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show("Đã thêm dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         
                        }
                    
                    //catch
                    //{
                    //    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                
            }
        }

        private void dgvCate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvCate[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvCate[1, e.RowIndex].Value.ToString();
           
            txtMa.Enabled = false;
            int index = e.RowIndex;
            dgvCate.Rows[index].Selected = true;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            
            try
            {
                int val = bus.Update(new DanhMucMon(txtMa.Text, txtName.Text));
                LoadData();
                if (val == -1)
                    MessageBox.Show("Sửa dữ liệu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Đã sửa dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                try
                {
                    int val = bus.Delete(txtMa.Text);
                    LoadData();
                    if (val == -1)
                        MessageBox.Show("Xóa dữ liệu không thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMa.Text = "";
                        txtName.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Không xóa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
