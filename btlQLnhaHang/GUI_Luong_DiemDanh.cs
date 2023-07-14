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
    public partial class GUI_Luong_DiemDanh : Form
    {
        public string maNhanVien { get; set; }

        public GUI_Luong_DiemDanh()
        {
            InitializeComponent();
        }

        BUS_Luong_DiemDanh bus_sal = new BUS_Luong_DiemDanh();
        BUS_NhanVien bus_nv = new BUS_NhanVien();

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string mon, yea;
            if (cbbMo.SelectedIndex == 12 || cbbMo.Text == "")
            {
                mon = "all";
            }
            else mon = cbbMo.Text;
            if (cbbYear.SelectedIndex == 2 || cbbYear.Text == "")
            {
                yea = "all";
            }
            else yea = cbbYear.Text;
            if (cbbNV.Text == "")
            {
                if (cbbMo.Text == "" || cbbYear.Text == "")
                {
                    MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                else
                {
                    //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                    dgvLuong.DataSource = bus_sal.getTable("",mon, yea);
                }
            }
            else
            {
                dgvLuong.DataSource = bus_sal.getTable(cbbNV.Text, mon, yea);


            }

        }

        private void cbbMo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbNV.Text = dgvLuong[0, e.RowIndex].Value.ToString();
            //txtName.Text = dgvLuong[1, e.RowIndex].Value.ToString();
            txtName.Text = bus_sal.getName(cbbNV.Text);
            txtLu.Text = dgvLuong[3, e.RowIndex].Value.ToString();
            txtTh.Text = dgvLuong[4, e.RowIndex].Value.ToString();

            txtDiemDanh.Text = dgvLuong[5, e.RowIndex].Value.ToString();
            cbbMo.Text = dgvLuong[1, e.RowIndex].Value.ToString();
            cbbYear.Text = dgvLuong[2, e.RowIndex].Value.ToString();

            //cbbMo.Enabled = false;
            //cbbYear.Enabled = false;
            //txtMa.Enabled = false;

            int index = e.RowIndex;
            dgvLuong.Rows[index].Selected = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = cbbNV.Text;
                int th = int.Parse(cbbMo.Text);
                int na = int.Parse(cbbYear.Text);
                int lu = int.Parse(txtLu.Text);
                int thu = int.Parse(txtTh.Text);
                int dd = int.Parse(txtDiemDanh.Text);

                Luong_DiemDanh sal = new Luong_DiemDanh(ma, th, na, lu, thu, dd);
                if (bus_sal.add(sal) == true)
                {
                    MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLuong.DataSource = bus_sal.getTable(ma, "all", "all");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại lương!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                string ma = cbbNV.Text;
                int thang = int.Parse(cbbMo.Text);
                int nam = int.Parse(cbbYear.Text);
                int luong = int.Parse(txtLu.Text);
                int diemdanh = int.Parse(txtDiemDanh.Text);
                int thuong = int.Parse(txtTh.Text);
                Luong_DiemDanh sal = new Luong_DiemDanh(ma, thang, nam, luong, thuong, diemdanh);
                if (bus_sal.upd(sal) == true)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLuong.DataSource = bus_sal.getTable(ma, "all", "all");
                }
            }
            catch
            {
                MessageBox.Show("Sửa không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            //string strDel = "delete from Luong_DiemDanh where maNV = '" + txtMa.Text + "' ";
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                try
                {
                    string manv = cbbNV.Text;
                    int thang = int.Parse(cbbMo.Text);
                    int nam = int.Parse(cbbYear.Text);
                    if (bus_sal.del(manv, thang, nam) == true)
                    {
                        MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvLuong.DataSource = bus_sal.getTable(cbbNV.Text, "all", "all");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Xoá không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cbbNV.Enabled = true;
            cbbMo.Enabled = true;
            cbbYear.Enabled = true;
        }

        private void GUI_Luong_DiemDanh_Load(object sender, EventArgs e)
        {
            cbbNV.DataSource = bus_nv.getAll();
            cbbNV.DisplayMember = "maNV";
            cbbNV.ValueMember = "maNV";

            cbbNV.Text = maNhanVien;

            dgvLuong.DataSource = bus_sal.getTable(cbbNV.Text, "all", "all");
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
