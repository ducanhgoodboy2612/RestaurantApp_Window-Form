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
    public partial class GUI_CTNguyenLieu : Form
    {
        public GUI_CTNguyenLieu()
        {
            InitializeComponent();
        }
        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        BUS_CTNguyenLieu bus_ctnl = new BUS_CTNguyenLieu();

        void LoadMon()
        {

            cbbMon.DataSource = bus_ctnl.loadCbb(0);
            cbbMon.DisplayMember = "tenMon";
            cbbMon.ValueMember = "maMon";
        }
        void LoadNL()
        {

            cbbNL.DataSource = bus_ctnl.loadCbb(1);
            cbbNL.DisplayMember = "tenNL";
            cbbNL.ValueMember = "maNL";
        }


        private void cbbMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCTNL.DataSource = bus_ctnl.getData(cbbMon.SelectedValue.ToString());

            dgvCTNL.Columns[0].HeaderText = "Mã món";
            dgvCTNL.Columns[1].HeaderText = "Nguyên liệu";
            dgvCTNL.Columns[2].HeaderText = "Định lượng";
            dgvCTNL.Columns[3].HeaderText = "Đơn vị";

            dgvCTNL.Columns[1].Width = 150;

            for (int i = 0; i < 4; ++i)
            {
                dgvCTNL.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvCTNL.EnableHeadersVisualStyles = false;

            cbbNL.Text = "";
            txtLuong.Text = "";
            txtDV.Text = "";
        }

        private void CTNguyenLieu_Load(object sender, EventArgs e)
        {
            dgvCTNL.DataSource = bus_ctnl.getData(Program.maMonGetNL);
            LoadMon();
            LoadNL();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {


                string mamon = cbbMon.SelectedValue.ToString();
                string maNL = cbbNL.SelectedValue.ToString();
                int luong = int.Parse(txtLuong.Text);
                string dv = txtDV.Text;


                CTNguyenLieu ct = new CTNguyenLieu(mamon, maNL, luong, dv);
                if (bus_ctnl.add(ct) == true)
                {
                    MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCTNL.DataSource = bus_ctnl.getData(mamon);
                }
                else
                {
                    MessageBox.Show("Dữ liệu đã tồn tại. Vui lòng kiểm tra lại dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCTNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMon.SelectedValue = dgvCTNL[0, e.RowIndex].Value.ToString();
            cbbNL.Text = dgvCTNL[1, e.RowIndex].Value.ToString();
            txtLuong.Text = dgvCTNL[2, e.RowIndex].Value.ToString();
            txtDV.Text = dgvCTNL[3, e.RowIndex].Value.ToString();
            int index = e.RowIndex;
            dgvCTNL.Rows[index].Selected = true;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string mamon = cbbMon.SelectedValue.ToString();
            string maNL = cbbNL.SelectedValue.ToString();
            int luong = int.Parse(txtLuong.Text);
            string dv = txtDV.Text;


            CTNguyenLieu ct = new CTNguyenLieu(mamon, maNL, luong, dv);
            if (bus_ctnl.upd(ct) == true)
            {
                MessageBox.Show("Cập nhật thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCTNL.DataSource = bus_ctnl.getData(mamon);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string maMon = cbbMon.SelectedValue.ToString();
                string maNL = cbbNL.SelectedValue.ToString();
                if (bus_ctnl.del(maMon, maNL) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCTNL.DataSource = bus_ctnl.getData(cbbMon.SelectedValue.ToString());
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
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
