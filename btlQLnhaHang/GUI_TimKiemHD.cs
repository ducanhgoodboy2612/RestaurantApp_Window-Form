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
using BUS;
using DTO;
namespace btlQLnhaHang
{
    public partial class GUI_TimKiemHD : Form
    {
        public GUI_TimKiemHD()
        {
            InitializeComponent();
        }
       
      
        BUS_HD bus = new BUS_HD();
        int billTy = 0;

        void loadData()
        {
            int c = billTy;
            //dgvBill.DataSource = bus_hd.getData(c);

            if (c == 0)
            {
               
                dgvFind.DataSource = bus.getAllHDB();

                for (int i = 0; i < 8; ++i)
                {
                    dgvFind.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvFind.EnableHeadersVisualStyles = false;
                dgvFind.Columns[0].HeaderText = "Mã HĐ";
                dgvFind.Columns[1].HeaderText = "Nhân viên lập";
                dgvFind.Columns[2].HeaderText = "Tên Khách hàng";
                dgvFind.Columns[3].HeaderText = "SĐT Khách hàng";
                dgvFind.Columns[4].HeaderText = "Bàn";
                dgvFind.Columns[5].HeaderText = "Ngày lập";
                dgvFind.Columns[6].HeaderText = "Mã khuyến mãi";
                dgvFind.Columns[7].HeaderText = "Tổng hóa đơn";


                dgvFind.Columns[2].Width = 150;
                dgvFind.Columns[1].Width = 150;
                dgvFind.Columns[5].Width = 80;
                dgvFind.Columns[0].Width = 80;



            }
            else
            {
                dgvFind.DataSource = bus.getAllHDN();
                for (int i = 0; i < 5; ++i)
                {
                    dgvFind.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                //dgvBill.EnableHeadersVisualStyles = false;
                //dgvBill.Columns[0].HeaderText = "Mã hóa đơn";
                //dgvBill.Columns[1].HeaderText = "Nhân viên lập";
                //dgvBill.Columns[2].HeaderText = "Nhà cung cấp";
                //dgvBill.Columns[3].HeaderText = "Ngày lập";
                //dgvBill.Columns[4].HeaderText = "Tổng Hóa đơn";

                //dgvBill.Columns[2].Width = 280;

            }

        }
        private void TimKiemHD_Load(object sender, EventArgs e)
        {
            loadData();
        }



        private void btFind_Click(object sender, EventArgs e)
        {

            string ma = txtMa.Text.Trim();

            if (txtMa.Text == "") ma = "all";

            string ten = txtName.Text.Trim();

            if (txtName.Text == "") ten = "all";

            int fPri = 0;
            if (txtFrom.Text != "")
                fPri = int.Parse(txtFrom.Text.Replace(".","").Trim());
            int tPri = 1000000000;
            if (txtTo.Text != "")
                tPri = int.Parse(txtTo.Text.Replace(".", "").Trim());

            dgvFind.DataSource = bus.SearchBill(ma, ten, fPri, tPri);





        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            if (txtFrom.Text == "" || txtFrom.Text == "0") return;
            decimal so;
            so = decimal.Parse(txtFrom.Text, System.Globalization.NumberStyles.Currency);
            txtFrom.Text = so.ToString("#,#");
            txtFrom.SelectionStart = txtFrom.Text.Length;
        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {
            if (txtTo.Text == "" || txtTo.Text == "0") return;
            decimal so;
            try
            {
                so = decimal.Parse(txtTo.Text, System.Globalization.NumberStyles.Currency);
                txtTo.Text = so.ToString("#,#");
                txtTo.SelectionStart = txtTo.Text.Length;
            }
            catch { }
        }

        private void TimKiemHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Exit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btLoadAll_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
