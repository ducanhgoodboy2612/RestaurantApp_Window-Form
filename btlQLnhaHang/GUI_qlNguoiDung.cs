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
    public partial class GUI_qlNguoiDung : Form
    {
        BUS_TTNguoiDung bus = new BUS_TTNguoiDung();
        public GUI_qlNguoiDung()
        {
            InitializeComponent();
        }
       
        void loadData()
        {
            List<string> lst = new List<string>(); 
            lst = bus.getInfo(Program.maLogin);

            txtMa.Text = Program.maLogin;

            txtName.Text = lst[1];
            cbbGen.Text = lst[2];
            txtType.Text = lst[3];
            txtYoB.Text = lst[4];
            txtAdd.Text = lst[5];
            txtPhone.Text = lst[6];

            txtType.Enabled = false;
            txtMa.Enabled = false;

            
            lblUN.Text = txtName.Text;

            //disConnect();
        }
        private void qlNguoiDung_Load(object sender, EventArgs e)
        {
            loadData();
        }

       

        BUS_NhanVien bus_emp = new BUS_NhanVien();
        NhanVien e = new NhanVien();
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtName.Text;
            string loai = txtType.Text;
            string gioiTinh = cbbGen.Text;
            int namSinh = int.Parse(txtYoB.Text);
            string dc = txtAdd.Text;
            string sdt = txtPhone.Text;

            NhanVien emp = new NhanVien(ma, ten, gioiTinh, loai , namSinh, dc, sdt);

            if (bus_emp.Update(emp) == 1)
            {
                MessageBox.Show("Cập nhật thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //string strUpdate = "update NhanVien set hotenNV= N'" + ten + " ',gioiTinh = N'" + gioiTinh + "', ngaysinh = ' " + ngaysinh + " ', diaChi = N' " + dc + " ', sdt = '" + sdt + "' where maNV = '" + ma + "' ";
            //exec(strUpdate);
            //loadData();
            //MessageBox.Show("Cập nhật thành công.");
        }
    }
}
