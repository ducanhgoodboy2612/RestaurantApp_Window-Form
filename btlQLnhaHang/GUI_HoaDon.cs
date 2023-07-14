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

using Microsoft.Office.Interop.Word;

using System.Reflection;

namespace btlQLnhaHang
{
    public partial class GUI_HoaDon : Form
    {
        public GUI_HoaDon()
        {
            InitializeComponent();
        }
        //string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        //SqlConnection conn;
        //SqlDataAdapter da;
        System.Data.DataTable dt;
        //SqlCommand cmd;
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        ExcelHelper ex = new ExcelHelper();
        BUS_HD bus = new BUS_HD();
        int billTy = 0;
     
        void loadData()
        {
            int c = billTy;
            //dgvBill.DataSource = bus_hd.getData(c);

            if (c == 0)
            {
                dgvBill.DataSource = bus.getAllHDB();

                for (int i = 0; i < 8; ++i)
                {
                    dgvBill.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvBill.EnableHeadersVisualStyles = false;
                dgvBill.Columns[0].HeaderText = "Mã HĐ";
                dgvBill.Columns[1].HeaderText = "Nhân viên lập";
                dgvBill.Columns[2].HeaderText = "Tên Khách hàng";
                dgvBill.Columns[3].HeaderText = "SĐT Khách hàng";
                dgvBill.Columns[4].HeaderText = "Bàn";
                dgvBill.Columns[5].HeaderText = "Ngày lập";
                dgvBill.Columns[6].HeaderText = "Mã khuyến mãi";
                dgvBill.Columns[7].HeaderText = "Tổng hóa đơn";


                dgvBill.Columns[2].Width = 150;
                dgvBill.Columns[1].Width = 150;
                dgvBill.Columns[5].Width = 80;
                dgvBill.Columns[0].Width = 80;
                


            }
            else
            {
                dgvBill.DataSource = bus.getAllHDN();
                for (int i = 0; i < 5; ++i)
                {
                    dgvBill.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvBill.EnableHeadersVisualStyles = false;
                dgvBill.Columns[0].HeaderText = "Mã hóa đơn";
                dgvBill.Columns[1].HeaderText = "Nhân viên lập";
                dgvBill.Columns[2].HeaderText = "Nhà cung cấp";
                dgvBill.Columns[3].HeaderText = "Ngày lập";
                dgvBill.Columns[4].HeaderText = "Tổng Hóa đơn";

                dgvBill.Columns[2].Width = 280;

            }
      
        }
        void tongHD()
        {
            //Connect();
            //string sql = "select sum(tongTien) from HDBan";
            //cmd = new SqlCommand(sql, conn);
            //string dt = cmd.ExecuteScalar().ToString();
            //decimal so;
            //so = decimal.Parse(dt, System.Globalization.NumberStyles.Currency);
            //dt = so.ToString("#,#");
            //lblsum.Text = dt + " VNĐ";
            //disConnect();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            loadData();
            loadcbbBan();
            loadcbbNV();
            
            tongHD();
        }


        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Connect();
            //string sql = "select HotenNV from NhanVien where maNV = '" + dgvBill[1, e.RowIndex].Value.ToString() + "'";
            //cmd = new SqlCommand(sql, conn);

            //string tenNV = (string)cmd.ExecuteScalar();
            //disConnect();
            txtMa.Text = dgvBill[0, e.RowIndex].Value.ToString();
            cbbNV.Text = dgvBill[1, e.RowIndex].Value.ToString();
            if (billTy == 0)
            {
                btnAll.Text = dgvBill[7, e.RowIndex].Value.ToString();
                cbbTable.Text = dgvBill[4, e.RowIndex].Value.ToString();
                //cbb1.Text = dgvBill[7, e.RowIndex].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dgvBill[5, e.RowIndex].Value.ToString());
                txtTenKH.Text = dgvBill[2, e.RowIndex].Value.ToString();
                txtPhone.Text = dgvBill[3, e.RowIndex].Value.ToString();
                cbbKM.Text = dgvBill[6, e.RowIndex].Value.ToString();
                txtMa.Enabled = false;
            }
            else
            {
                btnAll.Text = dgvBill[4, e.RowIndex].Value.ToString();
                cbbNV.Text = dgvBill[1, e.RowIndex].Value.ToString();
                cbbTable.Text = dgvBill[2, e.RowIndex].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dgvBill[3, e.RowIndex].Value.ToString());
                txtMa.Enabled = false;


            }
            int index = e.RowIndex;
            dgvBill.Rows[index].Selected = true;

            decimal so = decimal.Parse(btnAll.Text, System.Globalization.NumberStyles.Currency);
            btnAll.Text = so.ToString("#,#");
        }
        void loadcbbNV()
        {
            //cbbNV.DataSource = bus_hd.loadNV(billTy);
            if(billTy == 0)
                cbbNV.DataSource = bus.getEmp1();
            else
                cbbNV.DataSource = bus.getEmp2();
            cbbNV.DisplayMember = "hotenNV";
            cbbNV.ValueMember = "maNV";
        }
        void loadcbbBan()
        {
            //cbbTable.DataSource = bus_hd.loadBan(billTy);
            if(billTy == 0)
            {
                cbbTable.DataSource = bus.getTab();
                cbbTable.DisplayMember = "tenBan";
                cbbTable.ValueMember = "maBan";
            }
            else
            {
                cbbTable.DataSource = bus.getSup();

                cbbTable.DisplayMember = "tenNCC";
                cbbTable.ValueMember = "maNCC";
            }
            
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (billTy == 0)
            {
                string maHD = txtMa.Text;
                string maNV = cbbNV.SelectedValue.ToString();
                string tenKH = txtTenKH.Text;
                string sdtKH = txtPhone.Text;
                string maBan = cbbTable.SelectedValue.ToString();
                string ngayLap = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string maKM = cbbKM.Text;
                //int daTT = 1;

                HoaDon bi = new HoaDon(maHD, maNV, tenKH, sdtKH, maBan, ngayLap, maKM, 1);
                //if (bus_hd.add(bi) == true)
                if(bus.Insert(bi) == 1)
                {
                    MessageBox.Show("Thêm hóa đơn thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string maHD = txtMa.Text;
                string maNV = cbbNV.SelectedValue.ToString();

                string maNCC = cbbTable.SelectedValue.ToString();
                string ngayLap = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                HoaDonNhap bi = new HoaDonNhap(maHD, maNV, maNCC, ngayLap);
                if (bus_hd.add2(bi) == true)
                {
                    MessageBox.Show("Thêm thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBill.DataSource = bus_hd.getData(1);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if(billTy == 0)
            {
                string maHD = txtMa.Text;
                string maNV = cbbNV.SelectedValue.ToString();
                string tenKH = txtTenKH.Text;
                string sdtKH = txtPhone.Text;
                string maBan = cbbTable.SelectedValue.ToString();
                string ngayLap = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string maKM = cbbKM.Text;
                int daTT = 1;

                HoaDon bi = new HoaDon(maHD, maNV, tenKH, sdtKH, maBan, ngayLap, maKM, daTT);
                //if (bus_hd.upd(bi) == true)
                if(bus.Update(bi) == 1)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dgvBill.DataSource = bus.getAll1();
                    loadData();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string maHD = txtMa.Text;
                string maNV = cbbNV.SelectedValue.ToString();
                
                string maNCC = cbbTable.SelectedValue.ToString();
                string ngayLap = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                HoaDonNhap bi = new HoaDonNhap(maHD, maNV, maNCC, ngayLap);
                if (bus.Update(bi) == 1)
                {
                    MessageBox.Show("Sửa thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //if (bus_hd.del(maHD, billTy) == true)
                if(bus.Delete(maHD, billTy) == 1)
                {
                    MessageBox.Show("Xoá thông tin thành công", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công, vui lòng kiểm tra lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            

            GUI_TimKiemHD f = new GUI_TimKiemHD();
            f.ShowDialog();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btDetail_Click(object sender, EventArgs e)
        {
            //dgvBill.DataSource = bus_hd.loadDetail(txtMa.Text);
            GUI_CTHD f = new GUI_CTHD();
            f.ShowDialog();
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            //dgvBill.DataSource = 

        }

        private void cbbBillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBillType.SelectedIndex == 1)
            {
                billTy = 1;
                label7.Text = "Tên nhà cung cấp";
                label5.Hide();
                label4.Hide();
                label8.Hide();
            
                txtTenKH.Hide();
                txtPhone.Hide();
                //cbb1.Hide();
                cbbKM.Hide();
                loadData();
                loadcbbBan();
                loadcbbNV();
            }
            else
            {
                billTy = 0;
                label7.Text = "Bàn ăn";

                label5.Show();
                label4.Show();
                label8.Show();
             
                txtTenKH.Show();
                txtPhone.Show();
                //cbb1.Show();
                cbbKM.Show();
                loadData();
                loadData();
                loadcbbBan();
                loadcbbNV();
            }
        }
        //public void ExportFile(System.Data.DataTable dataTable, string sheetName, string title)
        //{
        //    //Tạo các đối tượng Excel

        //    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

        //    Microsoft.Office.Interop.Excel.Workbooks oBooks;

        //    Microsoft.Office.Interop.Excel.Sheets oSheets;

        //    Microsoft.Office.Interop.Excel.Workbook oBook;

        //    Microsoft.Office.Interop.Excel.Worksheet oSheet;

        //    //Tạo mới một Excel WorkBook 

        //    oExcel.Visible = true;

        //    oExcel.DisplayAlerts = false;

        //    oExcel.Application.SheetsInNewWorkbook = 1;

        //    oBooks = oExcel.Workbooks;

        //    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

        //    oSheets = oBook.Worksheets;

        //    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

        //    oSheet.Name = sheetName;

        //    // Tạo phần Tiêu đề
        //    Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

        //    head.MergeCells = true;

        //    head.Value2 = title;

        //    head.Font.Bold = true;

        //    head.Font.Name = "Times New Roman";

        //    head.Font.Size = "20";

        //    head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        //    // Tạo tiêu đề cột 
        //    if (billTy == 0)
        //    {

        //        Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

        //        cl1.Value2 = "Mã hóa đơn";

        //        cl1.ColumnWidth = 12;

        //        Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

        //        cl2.Value2 = "Tên nhân viên lập";

        //        cl2.ColumnWidth = 30;

        //        Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

        //        cl3.Value2 = "Tên khách hàng";
        //        cl3.ColumnWidth = 30;

        //        Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

        //        cl4.Value2 = "SĐT khách hàng";

        //        cl4.ColumnWidth = 13;

        //        Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

        //        cl5.Value2 = "Bàn ăn";

        //        cl5.ColumnWidth = 25;

        //        Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

        //        cl6.Value2 = "Ngày lập";

        //        cl6.ColumnWidth = 18.5;

        //        Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

        //        cl7.Value2 = "Mã khuyến mại";

        //        cl7.ColumnWidth = 13;

        //        Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

        //        cl8.Value2 = "Tổng Hóa đơn";

        //        cl8.ColumnWidth = 18;

        //        Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");

        //        rowHead.Font.Bold = true;

        //        // Kẻ viền

        //        rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

        //        // Thiết lập màu nền

        //        rowHead.Interior.ColorIndex = 6;

        //        rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    }
        //    else
        //    {
        //        Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

        //        cl1.Value2 = "Mã hóa đơn";

        //        cl1.ColumnWidth = 12;

        //        Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

        //        cl2.Value2 = "Tên nhân viên lập";

        //        cl2.ColumnWidth = 30;

        //        Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

        //        cl3.Value2 = "Nhà cung cấp";
        //        cl3.ColumnWidth = 30;

        //        Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

        //        cl4.Value2 = "Ngày nhập";

        //        cl4.ColumnWidth = 23;

        //        Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

        //        cl5.Value2 = "Tổng Hóa đơn";

        //        cl5.ColumnWidth = 15;

        //        Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

        //        Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");

        //        rowHead.Font.Bold = true;

        //        // Kẻ viền

        //        rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

        //        // Thiết lập màu nền

        //        rowHead.Interior.ColorIndex = 6;

        //        rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    }

            

        //    // Tạo mảng theo datatable

        //    object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

        //    //Chuyển dữ liệu từ DataTable vào mảng đối tượng

        //    for (int row = 0; row < dataTable.Rows.Count; row++)
        //    {
        //        DataRow dataRow = dataTable.Rows[row];

        //        for (int col = 0; col < dataTable.Columns.Count; col++)
        //        {
        //            arr[row, col] = dataRow[col];
        //        }
        //    }

        //    //Thiết lập vùng điền dữ liệu

        //    int rowStart = 4;

        //    int columnStart = 1;

        //    int rowEnd = rowStart + dataTable.Rows.Count - 2;

        //    int columnEnd = dataTable.Columns.Count;

        //    // Ô bắt đầu điền dữ liệu

        //    Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

        //    // Ô kết thúc điền dữ liệu

        //    Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

        //    // Lấy về vùng điền dữ liệu

        //    Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

        //    //Điền dữ liệu vào vùng đã thiết lập

        //    range.Value2 = arr;

        //    // Kẻ viền

        //    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

        //    // Căn giữa cột mã nhân viên

        //    //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

        //    //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

        //    //Căn giữa cả bảng 
        //    oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //}

        private void ImportExcel(string path)
        {

            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets[0];
                System.Data.DataTable dt = new System.Data.DataTable();
                for (int i = ws.Dimension.Start.Column; i <= ws.Dimension.End.Column; ++i)
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
                dgvBill.DataSource = dt;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            dt = new System.Data.DataTable();
            if (billTy == 0)
            {
                DataColumn c1 = new DataColumn("maHD");
                DataColumn c2 = new DataColumn("maNV");
                DataColumn c3 = new DataColumn("tenKH");
                DataColumn c4 = new DataColumn("sdtKH");
                DataColumn c5 = new DataColumn("maBan");
                DataColumn c6 = new DataColumn("ngayLap");
                DataColumn c7 = new DataColumn("maKM");
                DataColumn c8 = new DataColumn("tongTien");

                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                dt.Columns.Add(c3);
                dt.Columns.Add(c4);
                dt.Columns.Add(c5);
                dt.Columns.Add(c6);
                dt.Columns.Add(c7);
                dt.Columns.Add(c8);

                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    DataRow drow = dt.NewRow();
                    drow[0] = row.Cells[0].Value;
                    drow[1] = row.Cells[1].Value;
                    drow[2] = row.Cells[2].Value;
                    drow[3] = row.Cells[3].Value;
                    drow[4] = row.Cells[4].Value;
                    drow[5] = row.Cells[5].Value;
                    drow[6] = row.Cells[6].Value;
                    drow[7] = row.Cells[7].Value;

                    dt.Rows.Add(drow);
                }
                //ExportFile(dt, "Danh sach", "DANH SÁCH HÓA ĐƠN");

                ExcelHelper ex = new ExcelHelper();
                ex.ExportFileBill(dt, "Danh sach", "DANH SÁCH HÓA ĐƠN", 0);
            }
            else
            {
                DataColumn c1 = new DataColumn("maHD");
                DataColumn c2 = new DataColumn("tenNV");
                DataColumn c3 = new DataColumn("tenNCC");
                DataColumn c4 = new DataColumn("ngayNhap");
                DataColumn c5 = new DataColumn("tongHD");


                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                dt.Columns.Add(c3);
                dt.Columns.Add(c4);              
                dt.Columns.Add(c5);

                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    DataRow drow = dt.NewRow();
                    drow[0] = row.Cells[0].Value;
                    drow[1] = row.Cells[1].Value;
                    drow[2] = row.Cells[2].Value;
                    drow[3] = row.Cells[3].Value;
                    drow[4] = row.Cells[4].Value;


                    dt.Rows.Add(drow);
                }
                ExcelHelper ex = new ExcelHelper();
                ex.ExportFileBill(dt, "Danh sach", "DANH SÁCH HÓA ĐƠN NHẬP", 1);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dgvBill.DataSource = ExcelHelper.ImportExcel(openFileDialog.FileName);
                    MessageBox.Show("Nhập file thành công!");
                    int n = 8;
                    if (billTy == 1) n = 5;
                    for (int i = 0; i < n; ++i)
                    {
                        dgvBill.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }
                    dgvBill.EnableHeadersVisualStyles = false;
                    if(billTy == 0)
                    {
                        dgvBill.Columns[0].HeaderText = "Mã HĐ";
                        dgvBill.Columns[1].HeaderText = "Nhân viên lập";
                        dgvBill.Columns[2].HeaderText = "Tên Khách hàng";
                        dgvBill.Columns[3].HeaderText = "SĐT Khách hàng";
                        dgvBill.Columns[4].HeaderText = "Bàn";
                        dgvBill.Columns[5].HeaderText = "Ngày lập";
                        dgvBill.Columns[6].HeaderText = "Mã khuyến mãi";
                        dgvBill.Columns[7].HeaderText = "Tổng hóa đơn";


                        dgvBill.Columns[2].Width = 150;
                        dgvBill.Columns[1].Width = 150;
                        dgvBill.Columns[5].Width = 80;
                        dgvBill.Columns[0].Width = 80;
                    }
                    else
                    {
                        dgvBill.Columns[0].HeaderText = "Mã hóa đơn";
                        dgvBill.Columns[1].HeaderText = "Nhân viên lập";
                        dgvBill.Columns[2].HeaderText = "Nhà cung cấp";
                        dgvBill.Columns[3].HeaderText = "Ngày lập";
                        dgvBill.Columns[4].HeaderText = "Tổng Hóa đơn";

                        dgvBill.Columns[2].Width = 280;
                    }
          
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhập file không thành công!\n" + ex.Message);
                }
            }
        }

        private void btnExportW_Click(object sender, EventArgs e)
        {
            
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            // Mở tập tin Word đã có sẵn
            Document doc = word.Documents.Open(@"E:\winform\wordDoc.docx");

            // Lấy bảng đầu tiên trong tập tin Word
            Table tbl = doc.Tables[1];

            // Duyệt qua từng dòng của DataGridView và thêm dữ liệu vào bảng trong Word
            for (int i = 0; i < dgvBill.Rows.Count; i++)
            {
                // Lấy giá trị từng ô của dòng hiện tại trong DataGridView
                string col1 = dgvBill.Rows[i].Cells[0].Value.ToString();
                string col2 = dgvBill.Rows[i].Cells[1].Value.ToString();
                string col3 = dgvBill.Rows[i].Cells[2].Value.ToString();

                // Thêm dòng mới vào bảng trong Word
                Row newRow = tbl.Rows.Add();

                // Thiết lập giá trị cho từng ô trong dòng mới
                newRow.Cells[1].Range.Text = col1;
                newRow.Cells[2].Range.Text = col2;
                newRow.Cells[3].Range.Text = col3;
            }

            // Lưu và đóng tập tin Word
            doc.Save();
            doc.Close();

            // Thoát ứng dụng Word
            word.Quit();
        }
    }
}
