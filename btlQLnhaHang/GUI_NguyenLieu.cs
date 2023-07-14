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
    public partial class GUI_NguyenLieu : Form
    {
        public GUI_NguyenLieu()
        {
            InitializeComponent();
        }
        BUS_NguyenLieu bus_nl = new BUS_NguyenLieu();

       
        void loadData()
        {
            dgvNguyenLieu.DataSource = bus_nl.getData();

            dgvNguyenLieu.Columns[0].HeaderText = "Mã NL";
            dgvNguyenLieu.Columns[1].HeaderText = "Tên NL";
            dgvNguyenLieu.Columns[2].HeaderText = "Đơn vị tính";
            dgvNguyenLieu.Columns[3].HeaderText = "SL còn";
            dgvNguyenLieu.Columns[4].HeaderText = "Tình trạng";

            for (int i = 0; i < 5; ++i)
            {
                dgvNguyenLieu.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvNguyenLieu.EnableHeadersVisualStyles = false;

            dgvNguyenLieu.Columns[1].Width = 200;

            
        }
        SqlCommand cmd;
       
        private void NguyenLieu_Load(object sender, EventArgs e)
        {
            loadData();
            Loadcbb();
        }

        private void dgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvNguyenLieu[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvNguyenLieu[1, e.RowIndex].Value.ToString();
            txtDV.Text = dgvNguyenLieu[2, e.RowIndex].Value.ToString();
            
            txtSLcon.Text = dgvNguyenLieu[3, e.RowIndex].Value.ToString();
            cbbTT.Text = dgvNguyenLieu[4, e.RowIndex].Value.ToString();
            txtMa.Enabled = false;

            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            dgvNguyenLieu.Rows[index].Selected = true;

        }
        void Loadcbb()
        {

            cbbNCC.DataSource = bus_nl.loadCbb();
            cbbNCC.DisplayMember = "tenNCC";
            cbbNCC.ValueMember = "maNCC";
        }
      

        private void btAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            string dvtinh = txtDV.Text;
            string ttBaoquan = cbbTT.Text;
            int slcon = int.Parse(txtSLcon.Text);
            
           

            NguyenLieu nl = new NguyenLieu(ma, ten, dvtinh, slcon, ttBaoquan);
            if(bus_nl.add(nl) == true)
            {
                MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNguyenLieu.DataSource = bus_nl.getData();
            }
            else
            {
                MessageBox.Show("Mã nguyên liệu đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string ten = txtName.Text;
            string dvtinh = txtDV.Text;
            string ttBaoquan = cbbTT.Text;
            int slcon = int.Parse(txtSLcon.Text);



            NguyenLieu nl = new NguyenLieu(ma, ten, dvtinh, slcon, ttBaoquan);
            if (bus_nl.upd(nl) == true)
            {
                MessageBox.Show("Sửa thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNguyenLieu.DataSource = bus_nl.getData();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            //string strDel = "delete from Table_NL where maNL = '" + txtMa.Text + "' ";
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            try
            {
                if (r == DialogResult.Yes)
                {
                    string manl = txtMa.Text;
                    if (bus_nl.del(manl) == true)
                    {
                        MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvNguyenLieu.DataSource = bus_nl.getData();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xoá không thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvNguyenLieu.DataSource = bus_nl.find(txtFind.Text, 0);
            }
            else
                dgvNguyenLieu.DataSource = bus_nl.find(txtFind.Text, 1);
            //Connect();
            //da = new SqlDataAdapter("select * from Table_NL", conn);
            //dt = new DataTable();
            //DataView dv = new DataView();
            //da.Fill(dt);
            //dv = dt.DefaultView;
            //if (rbten.Checked)
            //{

            //    dv.RowFilter = "tenNL like '%" + txtFind.Text.Trim() + "%' ";
            //    dgvNguyenLieu.DataSource = dv;
            //}
            //else
            //{
            //    dv.RowFilter = "maNL like '%" + txtFind.Text.Trim() + "%' ";
            //    dgvNguyenLieu.DataSource = dv;
            //}
            //disConnect();
        }

        private void brReturn_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSLcon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
