using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btlQLnhaHang
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NhanVien frmNV = new GUI_NhanVien();
            frmNV.ShowDialog();
        }

        private void quảnLýDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_Menu f = new GUI_Menu();
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_qlNguoiDung f = new GUI_qlNguoiDung();
            f.ShowDialog();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            if (Program.code == 0)
            {

                chứcNăngQLToolStripMenuItem.Enabled = false;
                chucnangnvToolStripMenuItem.Enabled = true;
                báoCáoThốngKêToolStripMenuItem.Enabled = false;
            }
            else
            {
                chứcNăngQLToolStripMenuItem.Enabled = true;
                chucnangnvToolStripMenuItem.Enabled = true;
                báoCáoThốngKêToolStripMenuItem.Enabled = true;

            }

        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NCC f = new GUI_NCC();
            f.ShowDialog();
        }

        private void thôngTinNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NguyenLieu nl = new GUI_NguyenLieu();
            nl.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PassChange f = new PassChange();
            f.ShowDialog();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_KhachHang f = new GUI_KhachHang();
            f.ShowDialog();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gioiThieu f = new gioiThieu();
            f.ShowDialog();
        }

        private void thôngTinBànĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDon f = new GUI_HoaDon();
            f.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_HoaDon f = new GUI_HoaDon();
            f.ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ThongKe f = new GUI_ThongKe();
            f.ShowDialog();
        }

 

        //private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    reportDSNV f = new reportDSNV();
        //    f.ShowDialog();
        //}

        private void tìmKiếmThôngTinKHToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI_KhachHang f = new GUI_KhachHang();
            f.ShowDialog();
        }

       
        private void bànĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_QLBanAn f = new GUI_QLBanAn();
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string t = DateTime.Now.ToString();
            lblTime.Text = t;
        }

        //private void danhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    reportHD f = new reportHD();
        //    f.ShowDialog();
        //}

        

        private void quảnLýChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_CTHD f = new GUI_CTHD();
            f.ShowDialog();
        }

        private void quảnLýChươngTrìnhKhuyếnMạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_CTKM f = new GUI_CTKM();
            f.ShowDialog();
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýBànĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_QLBanAn f = new GUI_QLBanAn();
            f.ShowDialog();
        }

        private void GhiHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_BanAn f = new GUI_BanAn();
            f.ShowDialog();
        }

        private void ThôngTinNLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_NguyenLieu f = new GUI_NguyenLieu();
            f.ShowDialog();
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_ThongKe f = new GUI_ThongKe();
            f.ShowDialog();
        }

        private void TimKiemHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_TimKiemHD f = new GUI_TimKiemHD();
            f.ShowDialog();
        }

        private void timkiemNVMenutoolstrip_Click(object sender, EventArgs e)
        {
            GUI_MenuNV f = new GUI_MenuNV();
            f.ShowDialog();
        }

        private void tàiKhoảnĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_QLTaiKhoan f = new GUI_QLTaiKhoan();
            f.ShowDialog();
        }
    }
}
