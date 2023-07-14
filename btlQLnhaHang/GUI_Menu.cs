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
    public partial class GUI_Menu : Form
    {
        public GUI_Menu()
        {
            InitializeComponent();
        }

        BUS_Menu menu = new BUS_Menu();

        BUS_FoodMenu bus = new BUS_FoodMenu();
        //string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        //SqlConnection conn;
        //SqlCommand cmd;
        //SqlDataReader re;
        //SqlDataAdapter da;
        DataTable dt;
      
        void loadData()
        {

            dgvMenu.DataSource = bus.getAll();
            //dgvService.DataSource = menu.getData();

            dgvMenu.Columns[0].HeaderText = "Mã món";
            dgvMenu.Columns[1].HeaderText = "Tên món";
            dgvMenu.Columns[2].HeaderText = "Mã loại";
            dgvMenu.Columns[3].HeaderText = "Đơn giá";
            dgvMenu.Columns[4].HeaderText = "Chi phí nguyên liệu";

            dgvMenu.Columns[1].Width = 150;

            for (int i = 0; i < 5; ++i)
            {
                dgvMenu.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvMenu.EnableHeadersVisualStyles = false;


            
        }
        
        void Loadcbb()
        {
        
            cbbType.DataSource = bus.getFoodCate();
            cbbType.DisplayMember = "tenloai";
            cbbType.ValueMember = "maloai";
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            loadData();
            Loadcbb();
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvMenu[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvMenu[1, e.RowIndex].Value.ToString();
            cbbType.SelectedValue = dgvMenu[2, e.RowIndex].Value.ToString();
            txtPrice.Text = dgvMenu[3, e.RowIndex].Value.ToString();
            txtMCost.Text = dgvMenu[4, e.RowIndex].Value.ToString();

            txtMa.Enabled = false;
            int index = e.RowIndex;
            dgvMenu.Rows[index].Selected = true;

            Program.maMonGetNL = txtMa.Text;
        }
        //int ktmatrung(string ma)
        //{
        //    Connect();

        //    string sql = "select count(*) from Table_DV where maDV = '" + txtMa.Text.Trim() + "' ";
        //    cmd = new SqlCommand(sql, conn);
        //    int i = (int)cmd.ExecuteScalar();

        //    disConnect();
        //    return i;
        //}
        //void exec(string strSQL)
        //{
        //    Connect();

        //    cmd = new SqlCommand(strSQL, conn);
        //    cmd.ExecuteNonQuery();

        //    disConnect();
        //}

        private void btUpdate_Click(object sender, EventArgs e)
        {
            //string ma = txtMa.Text;
            //string ten = txtName.Text;
            //string loai = cbbType.SelectedValue.ToString();
            //int gia = int.Parse(txtPrice.Text);
            //int chiphiNL = int.Parse(txtMCost.Text);
            //MonAn me = new MonAn(ma, loai, ten, gia, chiphiNL);

            //if (menu.upd(me) == true)
            //{
            //    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dgvService.DataSource = menu.getData();
            //}
            //else
            //{
            //    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            try
            {
                string ma = txtMa.Text;
                string ten = txtName.Text;
                string loai = cbbType.SelectedValue.ToString();
                int gia = int.Parse(txtPrice.Text);
                int chiphiNL = int.Parse(txtMCost.Text);
                int val = bus.Update(new MonAn(ma, loai, ten, gia, chiphiNL));
                loadData();
                if (val == -1)
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {
                MessageBox.Show("Không sửa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    private void button1_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "" || txtName.Text == "" || cbbType.Text == "" || txtPrice.Text == "" || txtMCost.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string ma = txtMa.Text;
                    string ten = txtName.Text;
                    string loai = cbbType.SelectedValue.ToString();
                    int gia = int.Parse(txtPrice.Text);
                    int chiphiNL = int.Parse(txtMCost.Text);
                    int val = bus.Insert(new MonAn(ma, loai, ten, gia, chiphiNL));
                    loadData();
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

                catch
                {
                    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }


           
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            string strDel = "delete from Table_DV where maDV = '" + txtMa.Text + "' ";
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
                    loadData();
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

        private void btFind_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoldN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btFind_Click_1(object sender, EventArgs e)
        {
            
            string ma = txtFindID.Text.Trim();

            if (txtFindID.Text == "") ma = "all";

            string ten = txtFindwName.Text.Trim();

            if (txtFindwName.Text == "") ten = "all";
            int fPri = 0;
            if(txtFrom.Text != "") 
                fPri = int.Parse(txtFrom.Text.Trim());
            int tPri = 1000000000;
            if(txtTo.Text != "")
                tPri= int.Parse(txtTo.Text.Trim());
            dgvMenu.DataSource = bus.findInMenu(ma, ten, fPri, tPri);

            

            //if (rbten.Checked)
            //{
            //    dgvService.DataSource = menu.find(txtFind.Text, 0);
            //}
            //else if (rbma.Checked)
            //    dgvService.DataSource = menu.find(txtFind.Text, 1);
            //else
            //{
            //    if (txtTo.Text == "" && txtFrom.Text == "") loadData();
            //    else if(txtFrom.Text == "")
            //    {
            //        dgvService.DataSource = menu.findwPrice(0, int.Parse(txtTo.Text));
            //    }
            //    else if(txtTo.Text == "")
            //    {
            //        dgvService.DataSource = menu.findwPrice(int.Parse(txtFrom.Text),0);
            //    }
            //    else dgvService.DataSource = menu.findwPrice(int.Parse(txtFrom.Text), int.Parse(txtTo.Text));
            //}

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            loadData();
        }

        

        private void btShowDetail_Click(object sender, EventArgs e)
        {
            GUI_CTNguyenLieu ctnl = new GUI_CTNguyenLieu();
            ctnl.ShowDialog();
        }

        private void rbPrice_CheckedChanged(object sender, EventArgs e)
        {
            txtFindID.Enabled = false;
            txtFrom.Enabled = true;
            txtTo.Enabled = true;
        }

        private void rbma_CheckedChanged(object sender, EventArgs e)
        {
            txtFindID.Enabled = true;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
        }

        private void rbten_CheckedChanged(object sender, EventArgs e)
        {
            txtFindID.Enabled = true;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
        }
    }
}
