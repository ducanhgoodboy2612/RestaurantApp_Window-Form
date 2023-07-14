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


namespace btlQLnhaHang
{
    public partial class GUI_BanAn : Form
    {
        public GUI_BanAn()
        {
            InitializeComponent();
        }

        string strKetNoi = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;

        BUS_BanAn tb = new BUS_BanAn();
        BUS_FoodMenu bus_menu = new BUS_FoodMenu();

        void Connect()
        {
            conn = new SqlConnection(strKetNoi);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            //MessageBox.Show("Success connection.");
        }
        void disConnect()
        {
            conn = new SqlConnection(strKetNoi);
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        void loadData()
        {
            dgvBanAn.DataSource = tb.getData();


            for (int i = 0; i < 5; ++i)
            {
                dgvBanAn.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvBanAn.EnableHeadersVisualStyles = false;

            dgvBanAn.Columns[0].HeaderText = "Mã Bàn";
            dgvBanAn.Columns[1].HeaderText = "Tên Bàn";
            dgvBanAn.Columns[2].HeaderText = "SL Khách";
            dgvBanAn.Columns[3].HeaderText = "Giá";
            dgvBanAn.Columns[4].HeaderText = "Tình trạng";

            txtMa.Enabled = false;


        }
        void loadcbbBan()
        {

            cbbBanAn.DataSource = tb.loadCbbBan();
            cbbBanAn.DisplayMember = "TenBan";
            cbbBanAn.ValueMember = "MaBan";
            disConnect();
        }
        void loadcbbLoai()
        {
            cbbType.DataSource = tb.loadCbbLoai();
            cbbType.DisplayMember = "TenLoai";
            cbbType.ValueMember = "MaLoai";
        }
        void loadKM()
        {
            cbbKM.DataSource = tb.loadKM();
            cbbKM.DisplayMember = "MaKM";
            cbbKM.ValueMember = "MaKM";
        }
        private void BanAn_Load(object sender, EventArgs e)
        {
            loadData();

            loadKM();
            loadcbbBan();
            loadcbbLoai();
        }
        void loadHD()
        {
            //string sql = "select dv.tenDV, ct.soLuong, dv.donGia, dv.dongia * ct.soLuong as thanhtien from Table_CTHD ct, Table_DV dv where ct.maDV = dv.maDV and maBan = '" + cbbBanAn.SelectedValue + "' ";   /*dv, Table_loaiDV l where l.maLoai = dv.maLoai and l.tenLoai = ' " + cbbType.Text + "' */
            //da = new SqlDataAdapter(sql, conn);
            //dt = new DataTable();
            //da.Fill(dt);
            //dgvBill.DataSource = dt;
            //dgvBill.Columns[0].HeaderText = "Tên DV";
            //dgvBill.Columns[1].HeaderText = "SL";
            //dgvBill.Columns[2].HeaderText = "Đơn giá";
            //dgvBill.Columns[3].HeaderText = "Thành tiền";

            //dgvBill.Columns[0].HeaderCell.Style.BackColor = Color.LightSkyBlue;
            //dgvBill.Columns[1].HeaderCell.Style.BackColor = Color.LightSkyBlue;
            //dgvBill.Columns[2].HeaderCell.Style.BackColor = Color.LightSkyBlue;
            //dgvBill.Columns[3].HeaderCell.Style.BackColor = Color.LightSkyBlue;

            //dgvBill.Columns[0].Width = 180;
            //dgvBill.Columns[1].Width = 50;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connect();

            loadHD();



            disConnect();
        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbSE.DataSource = tb.loadCbbMon(cbbType.SelectedValue.ToString());
            cbbSE.DisplayMember = "TenMon";
            cbbSE.ValueMember = "MaMon";

        }
        SqlCommand cmd;
        void exec(string strSQL)
        {
            Connect();

            cmd = new SqlCommand(strSQL, conn);
            cmd.ExecuteNonQuery();

            disConnect();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btTT.Enabled = false;
            int num = int.Parse(num1.Value.ToString());

            string maBan = cbbBanAn.SelectedValue.ToString();
            string maMon = cbbSE.SelectedValue.ToString();
            if (tb.check_foodID(txtMaHD.Text, maMon) == 0)
            {
                if (tb.addToBill(maMon, maBan, num) == 1)
                {
                    MessageBox.Show("Món đã được thêm", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
                }
            }
            else MessageBox.Show("Món đã được thêm trong hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //string sql1 = "select dongia from Menu where maMon = '" + cbbSE.SelectedValue + "' ";
            //cmd = new SqlCommand(sql1, conn);
            //int gia = (int)cmd.ExecuteScalar();
            //string sql = "insert into CTHD values('" + cbbBanAn.SelectedValue + " ','" + cbbSE.SelectedValue + " ', '"+gia.ToString()+"', '"+num1.Value+" ')";
            //exec(sql);
            //loadHD();

            //disConnect();
        }

        public static string AutoGenerateCode(int counter)
        {
            string prefix = "HD";
            string paddedCounter = counter.ToString().PadLeft(4, '0'); // Đảm bảo counter luôn có đúng 4 chữ số, ví dụ: 0001, 0010, 0100, ...
            return prefix + paddedCounter;
        }

        private void creBill_Click(object sender, EventArgs e)
        {
            //if (txtMaHD.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập mã hóa đơn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            string maHDon;
            try
            {
                int i = 1;
                while (true)
                {
                    string genCode = AutoGenerateCode(i);
                    if (tb.ktmaHD(genCode) == 0)
                    {
                        maHDon = genCode;
                        break;
                    }
                    i += 1;
                }
                string maNV = "NV03";
                string hotenKH = txtTenKH.Text;
                string sdtKH = txtSDT.Text;
                string maKM = "";
                if (cbbKM.Text != "")
                    maKM = cbbKM.SelectedValue.ToString();

                string maHD = txtMaHD.Text;
                string maBan = cbbBanAn.SelectedValue.ToString();

                DateTime currentDate = DateTime.Now;
                string dateString = currentDate.ToString("yyyy-MM-dd");
                HoaDon bill = new HoaDon(maHDon, maNV, hotenKH, sdtKH, maBan, dateString, maKM, 0);
                if (tb.addHD(bill))
                {
                    txtMaHD.Text = maHDon;
                    addAllow(1);

                    MessageBox.Show("Đã thêm hóa đơn", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        public void addAllow(int c)
        {
            if (c == 0)
            {
                btnCreBill.Enabled = true;
                btAddBill.Enabled = false;
                bt_FoodDel.Enabled = false;
                txtTenKH.Text = "";
                txtSDT.Text = "";
                cbbKM.Text = "";
            }
            else
            {
                btnCreBill.Enabled = false;
                btAddBill.Enabled = true;
                bt_FoodDel.Enabled = true;
            }
        }

        private void ExportBillInfo(Microsoft.Office.Interop.Excel.Range info, HoaDon bi, string c)
        {
            //info = oSheet.get_Range("B2", "C2");

            info.MergeCells = true;
            if (c == "maHD")
                info.Value2 = "Mã hóa đơn: " + bi.MaHD;
            if (c == "maNV")
                info.Value2 = "Mã nhân viên lập: " + bi.MaNV;
            if (c == "maBan")
                info.Value2 = "Bàn: " + bi.MaBan;
            if (c == "tenKH")
                info.Value2 = "Tên khách hàng: " + bi.TenKH;
            if (c == "sdtKH")
                info.Value2 = "SĐT khách hàng: " + bi.SdtKH;
            if (c == "ngayLapHD")
            {
                info.Value2 = "Ngày lập: Ngày    tháng    năm    ";
                info.Font.Italic = true;
                info.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            if (c == "ckNV")
            {
                info.Value2 = "Nhân viên";
                info.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            //info.Font.Bold = true;
            info.MergeCells = true;

            info.Font.Name = "Times New Roman";

            info.Font.Size = "13";

            //info.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        public void ExportFile(System.Data.DataTable dataTable, HoaDon bi, string tongHD, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            //
            Microsoft.Office.Interop.Excel.Range resname = oSheet.get_Range("A3", "E3");

            resname.MergeCells = true;

            resname.Value2 = "Nhà hàng Cơm gà Hội An";

            resname.Font.Italic = true;

            resname.Font.Name = "Times New Roman";

            resname.Font.Size = "14";

            resname.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // tt hd
           
            Microsoft.Office.Interop.Excel.Range mahd = oSheet.get_Range("B5", "C5");

            ExportBillInfo(mahd, bi, "maHD");

            Microsoft.Office.Interop.Excel.Range manv = oSheet.get_Range("B6", "C6");

            ExportBillInfo(manv, bi, "maNV");

            Microsoft.Office.Interop.Excel.Range maBan = oSheet.get_Range("B7", "C7");

            ExportBillInfo(maBan, bi, "maBan");

            Microsoft.Office.Interop.Excel.Range tenKH = oSheet.get_Range("B8", "C8");

            ExportBillInfo(tenKH, bi, "tenKH");

            Microsoft.Office.Interop.Excel.Range sdtKH = oSheet.get_Range("B9", "C9");

            ExportBillInfo(sdtKH, bi, "sdtKH");

            //footer


            Microsoft.Office.Interop.Excel.Range ngayLap = oSheet.get_Range("D30", "E30");

            ExportBillInfo(ngayLap, bi, "ngayLapHD");

            Microsoft.Office.Interop.Excel.Range chuki = oSheet.get_Range("D31", "E31");

            ExportBillInfo(chuki, bi, "ckNV");




            //maNV.MergeCells = true;

            //maNV.Value2 = "Mã nhân viên lập: " + bi.MaNV;

            //maNV.Font.Bold = true;

            //maNV.Font.Name = "Times New Roman";

            //maNV.Font.Size = "13";

            //maNV.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A11", "A11");

            cl1.Value2 = "STT";

            cl1.ColumnWidth = 10;



            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B11", "B11");

            cl2.Value2 = "Tên dịch vụ";

            cl2.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C11", "C11");

            cl3.Value2 = "Số lượng";
            cl3.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D11", "D11");

            cl4.Value2 = "Đơn giá";

            cl4.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E11", "E11");

            cl5.Value2 = "Thành tiền";

            cl5.ColumnWidth = 20;



            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A11", "E11");

            rowHead.Font.Bold = true;

            //Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;




            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                   
                }
            }

            //tong HD

            //double sum = 0;
            //for (int row = 0; row < dataTable.Rows.Count; row++)
            //{
            //    double cellValue = Convert.ToDouble(dataTable.Rows[row][4]);
            //    sum += cellValue;
            //}

            


            //Thiết lập vùng điền dữ liệu

            int rowStart = 12;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            //Tong HD

            int sumRowStart = rowEnd + 2;
            int sumRowEnd = sumRowStart;

            
            Microsoft.Office.Interop.Excel.Range sumCell = oSheet.get_Range("D25", "E25");

            sumCell.MergeCells = true;

            sumCell.Font.Bold = true;

            sumCell.Font.Size = 16;

            string thd = tongHD;

            decimal so = decimal.Parse(lbltt.Text, System.Globalization.NumberStyles.Currency);
            
            sumCell.Value2 = "Tổng Hóa đơn: " + so.ToString("#,#") + " VNĐ";
            //sumCell.Value2 = Convert.ToDouble(tongHD);

            //sumCell.Value2 = Convert.ToDouble(tongHD);
            //sumCell.NumberFormat = "#,##0";

            //sumCell.Value2 = tongHD;
            //oSheet.Cells[sumRowStart, 6].Value2 = tongHD;
            //oSheet.Cells[sumRowStart, 6].Font = tongHD;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void InHD(HoaDon bill)
        {
            dt = new DataTable();

            DataColumn c1 = new DataColumn("Thứ tự");

            DataColumn c2 = new DataColumn("tenMon");
            DataColumn c3 = new DataColumn("sLuong");
            DataColumn c4 = new DataColumn("dongia");
            DataColumn c5 = new DataColumn("thanhTien");

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);


            int i = 0;
            foreach (DataGridViewRow row in dgvBillDe.Rows)
            {
                DataRow drow = dt.NewRow();
                drow[0] = ++i;

                drow[1] = row.Cells[0].Value;
                drow[2] = row.Cells[1].Value;
                drow[3] = row.Cells[2].Value;
                drow[4] = row.Cells[3].Value;

                dt.Rows.Add(drow);
            }
            string tongHD = lbltt.Text;
            ExportFile(dt, bill, lbltt.Text, "Hoa don thanh toan", "HÓA ĐƠN THANH TOÁN");
        }

        private void btTT_Click(object sender, EventArgs e)
        {
            HoaDon bill;
            if (txtMaHD.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string maNV = Program.maLogin;
                string hotenKH = txtTenKH.Text;
                string sdtKH = txtSDT.Text;
                string maKM = cbbKM.Text;
                int num = int.Parse(num1.Value.ToString());
                string maHD = txtMaHD.Text;
                string maBan = cbbBanAn.SelectedValue.ToString();
                //string maMon = cbbSE.SelectedValue.ToString();
                DateTime currentDate = DateTime.Now;
                string dateString = currentDate.ToString("yyyy-MM-dd");
                bill = new HoaDon(maHD, maNV, hotenKH, sdtKH, maBan, dateString, maKM, 1);
                if (tb.updBill(bill))
                {
                    txtMaHD.Text = "";
                    addAllow(0);
                    MessageBox.Show("Thanh toán thành công. Đã lưu hóa đơn", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InHD(bill);
                    
                    dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
                }

                //In hd

                

                loadHD();
                loadData();

            }


        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btTinh_Click(object sender, EventArgs e)
        {
            try
            {
                lbltt.Text = tb.tinhTongHD(txtMaHD.Text, cbbBanAn.SelectedValue.ToString(), cbbKM.Text).ToString();
                decimal so = decimal.Parse(lbltt.Text, System.Globalization.NumberStyles.Currency);
                lbltt.Text = so.ToString("#,#");

                btTT.Enabled = true;
            }


            catch
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbBanAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
            dgvBillDe.Columns[0].HeaderText = "Tên món";
            dgvBillDe.Columns[1].HeaderText = "Số lượng";
            dgvBillDe.Columns[2].HeaderText = "Đơn giá";
            dgvBillDe.Columns[3].HeaderText = "Thành tiền";

            for (int i = 0; i < 4; ++i)
            {
                dgvBanAn.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvBanAn.EnableHeadersVisualStyles = false;

            dgvBillDe.Columns[0].Width = 170;
            dgvBillDe.Columns[1].Width = 50;

            //txtcphiBan.Enabled = false;
            txtMaHD.Text = tb.getMaHD(cbbBanAn.SelectedValue.ToString());

            //Lay thong tin hoa don
            string mahd = txtMaHD.Text;
            if (mahd == "")
            {
                btnCreBill.Enabled = true;
                btAddBill.Enabled = false;
                bt_FoodDel.Enabled = false;
            }
            else
            {
                btnCreBill.Enabled = false;
                btAddBill.Enabled = true;
                bt_FoodDel.Enabled = true;

            }
            txtTenKH.Text = tb.getBillInfo(mahd, 0);
            txtSDT.Text = tb.getBillInfo(mahd, 1);
            cbbKM.Text = tb.getBillInfo(mahd, 2);
            //txtcphiBan.Text = tb.getGiaBan(cbbBanAn.SelectedValue.ToString()).ToString();
            btTT.Enabled = false;

            lbltt.Text = "";

        }

        private void txtCK_TextChanged(object sender, EventArgs e)
        {
            //if(txtCK.Text.Length > 0)
            //{
            //    try
            //    {
            //        double c = double.Parse(txtCK.Text);
            //        if (c >= 1 || c < 0)
            //        {
            //            this.errorProvider1.SetError(txtCK, "Chiết khấu nhỏ hơn 1 và lớn hơn hoặc bằng 0 !");
            //            btTinh.Enabled = false;
            //        }
            //        else { btTinh.Enabled = true; errorProvider1.Clear(); }
            //    }
            //    catch
            //    {
            //        this.errorProvider1.SetError(txtCK, "Nhập một số thực");
            //        btTinh.Enabled = false;
            //    }
            //}
        }

        private void dgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dgvBanAn[0, e.RowIndex].Value.ToString();
            txtName.Text = dgvBanAn[1, e.RowIndex].Value.ToString();
            cbbSLK.Text = dgvBanAn[2, e.RowIndex].Value.ToString();
            txtGia.Text = dgvBanAn[3, e.RowIndex].Value.ToString();
            cbbTT.Text = dgvBanAn[4, e.RowIndex].Value.ToString();

        }
        int ktmatrung(string ma)
        {
            Connect();

            string sql = "select count(*) from Table_BanAn where maBan = '" + ma.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);
            int i = (int)cmd.ExecuteScalar();

            disConnect();
            return i;
        }
        int ktmaHD(string ma)
        {
            Connect();

            string sql = "select count(*) from Table_HDBan where maHD = '" + txtMaHD.Text.Trim() + "' ";
            cmd = new SqlCommand(sql, conn);
            int i = (int)cmd.ExecuteScalar();

            disConnect();
            return i;
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    if (ktmatrung(txtMa.Text) == 0)
        //    {
        //        string sql = "insert into Table_BanAn values('" + txtMa.Text + "',N'" + txtName.Text + "','" + cbbSLK.Text + "','" + txtGia.Text + "', '" + cbbTT.Text + "' )";
        //        exec(sql);
        //        loadData();
        //    }
        //    else MessageBox.Show("Mã bàn đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //private void btUpdate_Click(object sender, EventArgs e)
        //{
        //    string sql = "update Table_BanAn set  tenBan =N'" + txtName.Text + "', slKhach = '" + cbbSLK.Text + "', gia = '" + txtGia.Text + "', tinhTrang = '" + cbbTT.Text + "' where maBan = '" + txtMa.Text + "' ";
        //    exec(sql);
        //    loadData();
        //}

        //private void btRefresh_Click(object sender, EventArgs e)
        //{
        //    foreach(Control ctrl in this.Controls)
        //    {
        //        if (ctrl is TextBox) (ctrl as TextBox).Text = "";
        //        if (ctrl is ComboBox) (ctrl as ComboBox).Text = "";
        //    }
        //    txtMa.Enabled = true;
        //}

        //private void btDel_Click(object sender, EventArgs e)
        //{
        //    string strDel = "delete from Table_BanAn where maBan = '" + txtMa.Text + "' ";
        //    DialogResult r;
        //    r = MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Delete",
        //    MessageBoxButtons.YesNo,
        //    MessageBoxIcon.Warning,
        //    MessageBoxDefaultButton.Button1);
        //    if (r == DialogResult.Yes)
        //    {
        //        exec(strDel);
        //        loadData();
        //    }
        //}

        private void btExit_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is TextBox) (ctrl as TextBox).Text = "";
                if (ctrl is ComboBox) (ctrl as ComboBox).Text = "";
            }
            btTT.Enabled = false;
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void foodDel_Click(object sender, EventArgs e)
        {
            if (tb.foDel(txtMaHD.Text, cbbSE.Text) == 1)
            {
                MessageBox.Show("Món đã được xóa khỏi hóa đơn!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvBillDe.DataSource = tb.getDetail(cbbBanAn.SelectedValue.ToString());
            }
            btTT.Enabled = false;

        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cbbSE.Text = dgvBillDe[0, e.RowIndex].Value.ToString();
            num1.Text = dgvBillDe[1, e.RowIndex].Value.ToString();
            txtPrice.Text = dgvBillDe[2, e.RowIndex].Value.ToString();

            int index = e.RowIndex;
            dgvBillDe.Rows[index].Selected = true;
        }

        private void cbbSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSE.Text != "")
                txtPrice.Text = tb.getPrice(cbbSE.SelectedValue.ToString(), 1);
            btTT.Enabled = false;

        }

        private void cbbKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            btTT.Enabled = false;

        }

        private void btExit_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
