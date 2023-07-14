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
namespace btlQLnhaHang
{
    public partial class PassChange : Form
    {
        BUS_TTNguoiDung bus = new BUS_TTNguoiDung();
        public PassChange()
        {
            InitializeComponent();
        }
       

        private void PassChange_Load(object sender, EventArgs e)
        {

        }
       

        private void btAcc_Click(object sender, EventArgs e)
        {
            if(txtCur.Text == "" || txtNew.Text == "" || txtche.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đủ các thông tin.");
            }
            else
            {
                int i = bus.passchange(Program.maLogin, txtCur.Text, txtNew.Text, txtche.Text);
                if(i == 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.");
                }
                else if(i == 1)
                {
                    MessageBox.Show("Xin kiểm tra lại mật khẩu mới.");
                }
                else
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng.");
                }
                //Connect();
                //string sql = "select pass from Users where maUser = '" + Program.maLogin + "'";
                //cmd = new SqlCommand(sql, conn);
                //string curPass = (string)cmd.ExecuteScalar();
                //disConnect();

                //if (txtCur.Text == curPass)
                //{
                //    if (txtNew.Text == txtche.Text)
                //    {
                //        string strUpdate = "update Users set pass = '" + txtNew.Text + " ' where maUser = '" + Program.maLogin + "' ";
                //        exec(strUpdate);
                //        MessageBox.Show("Cập nhật thành công.");
                //    }
                //    else MessageBox.Show("Xin kiểm tra lại mật khẩu mới.");
                //}
                //else MessageBox.Show("Mật khẩu hiện tại không đúng.");
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRe_Click(object sender, EventArgs e)
        {
            txtCur.Clear();
            txtNew.Clear();
            txtche.Clear();
            txtCur.Focus();
        }

        private void ckbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShow.Checked)
            {
                txtCur.PasswordChar = (char)0;
                txtNew.PasswordChar = (char)0;
                txtche.PasswordChar = (char)0;
            }
            else
            {
                txtCur.PasswordChar = '*';
                txtNew.PasswordChar = '*';
                txtche.PasswordChar = '*';
            }
            }
    }
}
