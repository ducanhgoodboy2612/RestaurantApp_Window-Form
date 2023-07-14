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
    public partial class GUI_CTKM : Form
    {
        public GUI_CTKM()
        {
            InitializeComponent();
        }
        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        BUS_CTKM bus_km = new BUS_CTKM();
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

            dgvKM.DataSource = bus_km.getData();
            dgvKM.Columns[0].HeaderText = "Mã CTKM";
            dgvKM.Columns[1].HeaderText = "Tên CTKM";
            dgvKM.Columns[2].HeaderText = "Chiết khấu";
            dgvKM.Columns[3].HeaderText = "Ngày bắt đầu";
            dgvKM.Columns[4].HeaderText = "Ngày kết thúc";


            for (int i = 0; i < 5; ++i)
            {
                dgvKM.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


            dgvKM.EnableHeadersVisualStyles = false;

            dgvKM.Columns[1].Width = 250;

           
        }
        SqlCommand cmd;
        void exec(string strSQL)
        {
            Connect();

            cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();

            disConnect();
        }
       

        private void GUI_CTKM_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            float ck = float.Parse(txtCK.Text);
            string ngaybd = dtStart.Value.ToString("yyyy-MM-dd");
            string ngaykt = dtEnd.Value.ToString("yyyy-MM-dd");

           
            ctkm km = new ctkm(ma, ten, ck, ngaybd, ngaykt);
            if (bus_km.add(km) == true)
            {
                MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKM.DataSource = bus_km.getData();
            }
            else
            {
                MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvKM[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvKM[1, e.RowIndex].Value.ToString();
            txtCK.Text = dgvKM[2, e.RowIndex].Value.ToString();
            dtStart.Value = DateTime.Parse(dgvKM[3, e.RowIndex].Value.ToString());
            dtEnd.Value = DateTime.Parse(dgvKM[4, e.RowIndex].Value.ToString());
            txtMa.Enabled = false;
            int index = e.RowIndex;
            dgvKM.Rows[index].Selected = true;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            float ck = float.Parse(txtCK.Text);
            string ngaybd = dtStart.Value.ToString("yyyy-MM-dd");
            string ngaykt = dtEnd.Value.ToString("yyyy-MM-dd");


            ctkm km = new ctkm(ma, ten, ck, ngaybd, ngaykt);
            if (bus_km.upd(km) == true)
            {
                MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKM.DataSource = bus_km.getData();
            }
            else
            {
                MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btDel_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                string maHD = txtMa.Text;
                if (bus_km.del(maHD) == true)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKM.DataSource = bus_km.getData();
                }

            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }

       

        private void ckbNow_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbNow.Checked) dgvKM.DataSource = bus_km.ctht();
            else dgvKM.DataSource = bus_km.getData();
        }
    }
}
