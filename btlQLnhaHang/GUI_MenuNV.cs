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
    public partial class GUI_MenuNV : Form
    {
        BUS_FoodMenu bus = new BUS_FoodMenu();
        public GUI_MenuNV()
        {
            InitializeComponent();
        }

        private void GUI_MenuNV_Load(object sender, EventArgs e)
        {
            

            cbbType.DataSource = bus.getFoodCate();
            cbbType.DisplayMember = "tenLoai";
            cbbType.ValueMember = "maLoai";

            dgvMenu.DataSource = bus.getAllbyNV("");
            dgvMenu.Columns[4].Visible = false;

            dgvMenu.Columns[0].HeaderText = "Mã món";
            dgvMenu.Columns[1].HeaderText = "Tên món";
            dgvMenu.Columns[2].HeaderText = "Loại";
            dgvMenu.Columns[3].HeaderText = "Đơn giá";


            for (int i = 0; i < 4; ++i)
            {
                dgvMenu.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvMenu.DataSource = bus.getAllbyNV("");

            dgvMenu.DataSource = bus.getAllbyNV(cbbType.SelectedValue.ToString());
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dgvMenu.DataSource = bus.getAllbyNV("");

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
