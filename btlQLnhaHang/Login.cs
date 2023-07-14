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
namespace btlQLnhaHang
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
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
        private void cbb1_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbLogin.Checked)
                txtPass.PasswordChar = (char)0;
            else txtPass.PasswordChar = '*';
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Thoát ứng dụng ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes) Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult r;
            //r = MessageBox.Show("Thoát ứng dụng ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //                     MessageBoxDefaultButton.Button1);
            //if (r == DialogResult.No) e.Cancel = true;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuserName.Text))
            {
                errorProvider1.SetError(txtuserName, "Tên đăng nhập không được để trống");
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                errorProvider1.SetError(txtPass, "Mật khẩu không được để trống");
            }
            else
            {
                errorProvider1.Clear();
                Connect();
                cmd = new SqlCommand();
                cmd.CommandText = "AuthoLogin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Username", txtuserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                int i = (int)cmd.ExecuteScalar();
                switch (i)
                {
                    case 1:
                        MessageBox.Show("Chào mừng Admin đăng nhập hệ thống");
                        Program.code = 1;
                        Program.maLogin = txtuserName.Text;
                        //string sql = "select maUser from Users where userID = '" + txtuserName.Text + "'";
                        //cmd = new SqlCommand(sql, conn);
                        //Program.maLogin = (string)cmd.ExecuteScalar();
                        frmMainMenu f = new frmMainMenu();
                        f.ShowDialog();

                        break;
                    case 0:
                        MessageBox.Show("Chào mừng bạn đăng nhập hệ thống");
                        Program.code = 0;
                        Program.maLogin = txtuserName.Text;

                        //sql = "select maUser from Users where userID = '" + txtuserName.Text + "'";
                        //cmd = new SqlCommand(sql, conn);
                        //Program.maLogin = (string)cmd.ExecuteScalar();
                        frmMainMenu f1 = new frmMainMenu();
                        f1.ShowDialog();
                        break;
                    case 2:
                        MessageBox.Show("Nhập sai tên tài khoản hoặc mật khẩu.");
                        txtuserName.Focus();
                        txtuserName.Text = "";
                        txtPass.Text = "";
                        break;
                    default:
                        MessageBox.Show("Tài khoản không tồn tại");
                        txtuserName.Focus();
                        txtuserName.Text = "";
                        txtPass.Text = "";
                        break;
                }
                disConnect();
            }
        }

        private void txtuserName_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtuserName.Text))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtuserName, "Tên đăng nhập không được để trống");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.Clear();
            //}
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtPass.Text))
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtuserName, "Mật khẩu không được để trống");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.Clear();
            //}
        }

        private void txtuserName_TextChanged(object sender, EventArgs e)
        {
            if (txtuserName.Text.Length > 0) errorProvider1.Clear();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text.Length > 0) errorProvider1.Clear();

        }
    }
}
