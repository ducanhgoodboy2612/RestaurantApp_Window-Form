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
using System.IO;
using OfficeOpenXml;

using Excel = Microsoft.Office.Interop.Excel;

namespace btlQLnhaHang
{
    public partial class GUI_NhanVien : Form
    {
        public GUI_NhanVien()
        {
            InitializeComponent();
        }
        BUS_NhanVien bus_emp = new BUS_NhanVien();

        public void Loadcbb()
        {
            cbbType.DataSource = bus_emp.getAllType();
            cbbType.DisplayMember = "tenLoai";
            cbbType.ValueMember = "maLoai";
        }


        private void Nhanvien_Load(object sender, EventArgs e)
        {

            Loadcbb();
            //dgvNhanvien.DataSource = bus_emp.getEmp();
            dgvNhanvien.DataSource = bus_emp.getAll();

            dgvNhanvien.Columns[0].HeaderText = "Mã NV";
            dgvNhanvien.Columns[1].HeaderText = "Họ tên NV";
            dgvNhanvien.Columns[2].HeaderText = "Giới tính";
            dgvNhanvien.Columns[3].HeaderText = "Loại";
            dgvNhanvien.Columns[4].HeaderText = "Năm sinh";
            dgvNhanvien.Columns[5].HeaderText = "Địa chỉ";
            dgvNhanvien.Columns[6].HeaderText = "SĐT";
            
            for(int i = 0; i < 7; ++i)
            {
                dgvNhanvien.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


            dgvNhanvien.EnableHeadersVisualStyles = false;

            dgvNhanvien.Columns[1].Width = 150;
            dgvNhanvien.Columns[2].Width = 70;
            dgvNhanvien.Columns[3].Width = 70;
            dgvNhanvien.Columns[4].Width = 70;
            dgvNhanvien.Columns[5].Width = 300;
            title.TextAlign = ContentAlignment.MiddleCenter;
            panel1.Controls.Add(title);
            
        }




        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is TextBox) (ctrl as TextBox).Text = "";
                if( ctrl is ComboBox) (ctrl as ComboBox).Text = "";
            }
            txtMa.Enabled = true;

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }

       
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMa.Text;
                string ten = txtName.Text;

                string loai = cbbType.SelectedValue.ToString();
                if (cbbType.Text == "") loai = "L04";
                string gioiTinh = cbbGen.Text;
                //string ngaysinh = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                int nsinh = int.Parse(txtNamSinh.Text);
                string dc = txtAdd.Text;
                string sdt = txtPhone.Text;
                NhanVien emp = new NhanVien(ma, ten, gioiTinh, loai, nsinh, dc, sdt);
                //if(bus_emp.addEmp(emp) == true)
                if (bus_emp.Insert(emp) == 1)
                {
                    MessageBox.Show("Thêm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanvien.DataSource = bus_emp.getAll();
                }
                else
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã mới!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMa.Text;
                string ten = txtName.Text;
                string loai = cbbType.SelectedValue.ToString();
                string gioiTinh = cbbGen.Text;
                //string ngaysinh = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                int nsinh = int.Parse(txtNamSinh.Text);

                string dc = txtAdd.Text;
                string sdt = txtPhone.Text;
                NhanVien emp = new NhanVien(ma, ten, gioiTinh, loai, nsinh, dc, sdt);
                if (bus_emp.Update(emp) == 1)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanvien.DataSource = bus_emp.getAll();
                }
               
            }
            catch
            {
                MessageBox.Show("Sửa không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

       

        private void dgvNhanvien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvNhanvien[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvNhanvien[1, e.RowIndex].Value.ToString();
            cbbGen.Text = dgvNhanvien[2, e.RowIndex].Value.ToString();

            cbbType.Text = bus_emp.getType(dgvNhanvien[3, e.RowIndex].Value.ToString());
            //dateTimePicker1.Value = DateTime.Parse(dgvNhanvien[4, e.RowIndex].Value.ToString());
            txtNamSinh.Text = dgvNhanvien[4, e.RowIndex].Value.ToString();
            txtAdd.Text = dgvNhanvien[5, e.RowIndex].Value.ToString();
            txtPhone.Text = dgvNhanvien[6, e.RowIndex].Value.ToString();
           
            txtMa.Enabled = false;
            int index = e.RowIndex;
            dgvNhanvien.Rows[index].Selected = true;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            //string strDel = "delete from NhanVien where maNV = '" + txtMa.Text + "' ";
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                try
                {
                    string manv = txtMa.Text;
                    if (bus_emp.Delete(manv) == 1)
                    {
                        MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvNhanvien.DataSource = bus_emp.getAll();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Xoá không thành công. Vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            dgvNhanvien.DataSource = bus_emp.getAll();
            

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            //if (txtSalary.Text == "" || txtSalary.Text == "0") return;
            //decimal so;
            //so = decimal.Parse(txtSalary.Text, System.Globalization.NumberStyles.Currency);
            //txtSalary.Text = so.ToString("#,#");
            //txtSalary.SelectionStart = txtSalary.Text.Length;
        }

        private void txtTh_TextChanged(object sender, EventArgs e)
        {
            //if (txtTh.Text == "" || txtTh.Text == "0") return;
            //decimal so;
            //so = decimal.Parse(txtTh.Text, System.Globalization.NumberStyles.Currency);
            //txtTh.Text = so.ToString("#,#");
            //txtTh.SelectionStart = txtTh.Text.Length;
        }

        private void btSalary_Click(object sender, EventArgs e)
        {
            if(txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần hiển thị lương ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string maNhanVien = txtMa.Text;
                GUI_Luong_DiemDanh lu = new GUI_Luong_DiemDanh();
                lu.maNhanVien = maNhanVien;
                lu.ShowDialog();
            }

            
        }

        private void btFind_Click_1(object sender, EventArgs e)
        {
            //if (rbten.Checked)
            //{
            //    dgvNhanvien.DataSource = bus_emp.find(txtFind.Text, 0);
            //}
            //else
            //    dgvNhanvien.DataSource = bus_emp.find(txtFind.Text, 1);
            NhanVien nv = new NhanVien();
            nv.MaNV = txtFind.Text.Trim();
            nv.HotenNV = txtFindName.Text.Trim();
          
            dgvNhanvien.DataSource = bus_emp.SearchLinq(nv);
        }

        private void ExportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dgvNhanvien.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvNhanvien.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvNhanvien.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNhanvien.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvNhanvien.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }
        private void ImportExcel(string path)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets[0];
                DataTable dt = new DataTable();
                for(int i = ws.Dimension.Start.Column; i <= ws.Dimension.End.Column; ++i)
                {
                    dt.Columns.Add(ws.Cells[1, i].Value.ToString());
                }
                for (int i = ws.Dimension.Start.Row + 1; i <= ws.Dimension.End.Row; ++i)
                {
                    List<string> lstRows = new List<string>();
                    for (int j = ws.Dimension.Start.Column; j <= ws.Dimension.End.Column; ++j)
                    {
                        lstRows.Add(ws.Cells[i, j].Value.ToString());
                    }
                    dt.Rows.Add(lstRows.ToArray());
                }
                dgvNhanvien.DataSource = dt;
            }
        }
        DataTable dt;

        private void btExport_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            DataColumn c1 = new DataColumn("maNV");
            DataColumn c2 = new DataColumn("hotenNV");
            DataColumn c3 = new DataColumn("gioiTinh");
            DataColumn c4 = new DataColumn("maLoai");
            DataColumn c5 = new DataColumn("namSinh");
            DataColumn c6 = new DataColumn("diaChi");
            DataColumn c7 = new DataColumn("sdt");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            dt.Columns.Add(c7);

            foreach (DataGridViewRow row in dgvNhanvien.Rows)
            {
                DataRow drow = dt.NewRow();
                drow[0] = row.Cells[0].Value;
                drow[1] = row.Cells[1].Value;
                drow[2] = row.Cells[2].Value;
                drow[3] = row.Cells[3].Value;
                drow[4] = row.Cells[4].Value;
                drow[5] = row.Cells[5].Value;
                drow[6] = row.Cells[6].Value;
                

                dt.Rows.Add(drow);
            }
            try
            {
                ExcelHelper.ExportFileEmp(dt, "Danh sach nhan vien", "DANH SÁCH NHÂN VIÊN");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nhập dữ liệu không thành công!\n" + ex.Message);
            }




            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Title = "Export Excel";
            //saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        ExportExcel(saveFileDialog.FileName);
            //        MessageBox.Show("Xuất file thành công!");
            //        for (int i = 0; i < 7; ++i)
            //        {
            //            dgvNhanvien.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            //        }


            //        dgvNhanvien.EnableHeadersVisualStyles = false;

            //        dgvNhanvien.Columns[1].Width = 150;
            //        dgvNhanvien.Columns[2].Width = 70;
            //        dgvNhanvien.Columns[3].Width = 70;
            //        dgvNhanvien.Columns[4].Width = 70;
            //        dgvNhanvien.Columns[5].Width = 300;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Xuất file không thành công!\n" + ex.Message);
            //    }
            //}
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dgvNhanvien.DataSource = ExcelHelper.ImportExcel(openFileDialog.FileName);
                    MessageBox.Show("Nhập file thành công!");
                    for (int i = 0; i < 7; ++i)
                    {
                        dgvNhanvien.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }


                    dgvNhanvien.EnableHeadersVisualStyles = false;

                    dgvNhanvien.Columns[1].Width = 150;
                    dgvNhanvien.Columns[2].Width = 70;
                    dgvNhanvien.Columns[3].Width = 70;
                    dgvNhanvien.Columns[4].Width = 70;
                    dgvNhanvien.Columns[5].Width = 300;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhập file không thành công!\n" + ex.Message);
                }
            }
        }
    }
}
