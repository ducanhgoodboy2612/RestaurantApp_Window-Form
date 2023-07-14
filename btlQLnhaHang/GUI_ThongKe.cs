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
    public partial class GUI_ThongKe : Form
    {
        public GUI_ThongKe()
        {
            InitializeComponent();
        }
        
        DataTable dt;
        BUS_Menu bus_menu = new BUS_Menu();
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_Luong_DiemDanh bus_sal = new BUS_Luong_DiemDanh();
        BUS_NhanVien bus_emp = new BUS_NhanVien();
        BUS_HD bus_hd2 = new BUS_HD();
       

        private void btSort_Click(object sender, EventArgs e)
        {
            if (rbse.Checked)
            {
                
                string mon, yea;
                if (cbbMo.SelectedIndex == 12 || cbbMo.Text == "")
                {
                    mon = "all";
                }
                else mon = cbbMo.Text;
                if (cbbYear.SelectedIndex == 2 || cbbYear.Text == "")
                {
                    yea = "all";
                }
                else yea = cbbYear.Text;


                if (cbbM.SelectedIndex == 0 && rbIn.Checked)
                {


                    if (cbbMo.Text == "" || cbbYear.Text == "")
                    {
                        MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                        dgvSort.DataSource = bus_menu.foodStatistic(0, mon, yea);
                        //dgvSort.Columns[2].HeaderText = "Số lượng đã bán";
                        //dgvSort.Columns[2].HeaderText = "Đơn giá";

                    }
                }


                if (cbbM.SelectedIndex == 0 && rbDe.Checked)
                {
                    if (cbbMo.Text == "" || cbbYear.Text == "")
                    {
                        MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                        dgvSort.DataSource = bus_menu.foodStatistic(1, mon, yea);
                        dgvSort.Columns[3].HeaderText = "Số lượng đã bán";
                        dgvSort.Columns[2].HeaderText = "Đơn giá";


                    }

                }
                if (cbbM.SelectedIndex == 1 && rbIn.Checked)
                {
                    dgvSort.DataSource = bus_menu.foodStatistic2(0);
                    dgvSort.Columns[2].HeaderText = "Đơn giá";

                }
                if (cbbM.SelectedIndex == 1 && rbDe.Checked)
                {
                    dgvSort.DataSource = bus_menu.foodStatistic2(1);
                    dgvSort.Columns[2].HeaderText = "Đơn giá";

                }
                for (int i = 0; i < 4; ++i)
                {
                    dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                }
                dgvSort.EnableHeadersVisualStyles = false;
                dgvSort.Columns[3].HeaderText = "Số lượng đã bán";


            }
            if (rbem.Checked)
            {
                
                int mon, yea;
                if (cbbMo.SelectedIndex == 12 || cbbMo.Text == "")
                {
                    mon = 0;
                }
                else mon = int.Parse(cbbMo.Text);
                if (cbbYear.SelectedIndex == 2 || cbbYear.Text == "")
                {
                    yea = 0;
                }
                else yea = int.Parse(cbbYear.Text);


                if (cbbNV.SelectedIndex == 0)
                {
                    if (rbIn.Checked)
                    {

                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_sal.SalStatistic(0, mon, yea);
                        }
                    }
                    else
                    {
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_sal.SalStatistic(1, mon, yea);
                        }
                    }

                    int total = 0;

                    for (int i = 0; i < dgvSort.Rows.Count; i++)
                    {
                        // Kiểm tra giá trị của ô trong cột tương ứng và cộng vào tổng
                        if (dgvSort.Rows[i].Cells[6].Value != null)
                        {
                            int cellValue;
                            if (int.TryParse(dgvSort.Rows[i].Cells[6].Value.ToString(), out cellValue))
                            {
                                total += cellValue;
                            }
                        }
                        lblTotalVal.Text = total.ToString();
                        decimal so = decimal.Parse(lblTotalVal.Text, System.Globalization.NumberStyles.Currency);
                        lblTotalVal.Text = so.ToString("#,#") + " VNĐ";

                    }
                    dgvSort.Columns[6].HeaderText = "Tổng lương";
                    for (int i = 0; i < 7; ++i)
                    {
                        dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }
                }


                if (cbbNV.SelectedIndex == 1)
                {
                    
                    if (rbIn.Checked)
                    {

                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_sal.RollCallStatistic(0, mon, yea);
                        }
                    }
                    else
                    {
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị lương", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_sal.RollCallStatistic(1, mon, yea);
                        }
                    }

                    for (int i = 0; i < 7; ++i)
                    {
                        dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }

                }
                
                lblTotal.Text = "Tổng lương: ";

                dgvSort.Columns[0].HeaderText = "Mã NV";
                dgvSort.Columns[1].HeaderText = "Tháng";
                dgvSort.Columns[2].HeaderText = "Năm";
                dgvSort.Columns[3].HeaderText = "Lương";
                dgvSort.Columns[4].HeaderText = "Thưởng";
                dgvSort.Columns[5].HeaderText = "Điểm danh";
                dgvSort.Columns[6].HeaderText = "Tổng lương";



                dgvSort.EnableHeadersVisualStyles = false;
                //if (cbbM.SelectedIndex == 1 && rbIn.Checked)
                //{
                //    dgvSort.DataSource = bus_menu.foodStatistic2(0);
                //}
                //if (cbbM.SelectedIndex == 1 && rbDe.Checked)
                //{
                //    dgvSort.DataSource = bus_menu.foodStatistic2(1);

                //}

            }
            if (rbbill.Checked)
            {
                int totalCol;
                
                string mon, yea;
                if (cbbMo.SelectedIndex == 12 || cbbMo.Text == "")
                {
                    mon = "all";
                }
                else mon = cbbMo.Text;
                if (cbbYear.SelectedIndex == 2 || cbbYear.Text == "")
                {
                    yea = "all";
                }
                else yea = cbbYear.Text;


                if (cbbHD.SelectedIndex == 0)
                {
                    if (rbIn.Checked)
                    {

                        totalCol = 6;
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_hd.BillStatistic(0, mon, yea);
                        }
                    }
                    else if(rbDe.Checked)
                    {
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị  hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_hd.BillStatistic(1, mon, yea);
                        }
                    }
                    else
                    {
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị  hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_hd.BillStatistic(2, mon, yea);
                        }
                    }

                    for (int i = 0; i < 7; ++i)
                    {
                        dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }
                    dgvSort.Columns[6].HeaderText = "Tổng hóa đơn";
                    dgvSort.EnableHeadersVisualStyles = false;

                    lblTotalVal.Text = hthiTongHD(6).ToString() ;
                    decimal so = decimal.Parse(lblTotalVal.Text, System.Globalization.NumberStyles.Currency);
                    lblTotalVal.Text = so.ToString("#,#") + "VNĐ";
                }

                //hd trong ngay

                if(cbbHD.SelectedIndex == 2)
                {
                    dgvSort.DataSource = bus_hd.DailyBill();

                    dgvSort.Columns[6].HeaderText = "Tổng hóa đơn";
                    for (int i = 0; i < 7; ++i)
                    {
                        dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }
                    dgvSort.EnableHeadersVisualStyles = false;

                    lblTotalVal.Text = hthiTongHD(6).ToString() ;
                    decimal so = decimal.Parse(lblTotalVal.Text, System.Globalization.NumberStyles.Currency);
                    lblTotalVal.Text = so.ToString("#,#") + " VNĐ";
                }


               


                //hdnhap

                if (cbbHD.SelectedIndex == 1)
                {

                    totalCol = 4;

                    if (rbIn.Checked)
                    {
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_hd.ImBillStatistic(0, mon, yea);
                        }
                    }
                    else if (rbDe.Checked)
                    {

                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị  hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_hd.ImBillStatistic(1, mon, yea);
                        }
                    }
                    else
                    {
                        if (cbbMo.Text == "" || cbbYear.Text == "")
                        {
                            MessageBox.Show("Chọn tháng và năm cần hiển thị  hóa đơn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            //dgvLuong.DataSource = bus_sal.getTable(((string)cbbMo.SelectedItem, (string)cbbYear.SelectedItem));
                            dgvSort.DataSource = bus_hd.ImBillStatistic(2, mon, yea);
                        }
                    }

                    for (int i = 0; i < 5; ++i)
                    {
                        dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

                    }
                    dgvSort.Columns[4].HeaderText = "Tổng hóa đơn";
                    dgvSort.EnableHeadersVisualStyles = false;

                   

                    lblTotalVal.Text = hthiTongHD(4).ToString();
                    decimal so = decimal.Parse(lblTotalVal.Text, System.Globalization.NumberStyles.Currency);
                    lblTotalVal.Text = so.ToString("#,#") + " VNĐ";
                }


               

                 int hthiTongHD(int x) {

                    int total = 0;

                    for (int i = 0; i < dgvSort.Rows.Count; i++)
                    {
                        // Kiểm tra giá trị của ô trong cột tương ứng và cộng vào tổng
                        if (dgvSort.Rows[i].Cells[x].Value != null)
                        {
                            int cellValue;
                            if (int.TryParse(dgvSort.Rows[i].Cells[x].Value.ToString(), out cellValue))
                            {
                                total += cellValue;
                                
                            }
                        }
                    }
                    return total;
                    
                }

                
                lblTotal.Text = "Tổng hóa đơn: ";
                
                //if (cbbM.SelectedIndex == 1 && rbIn.Checked)
                //{
                //    dgvSort.DataSource = bus_menu.foodStatistic2(0);
                //}
                //if (cbbM.SelectedIndex == 1 && rbDe.Checked)
                //{
                //    dgvSort.DataSource = bus_menu.foodStatistic2(1);

                //}

            }
        }

        private void rbse_CheckedChanged(object sender, EventArgs e)
        {
            //panel4.Visible = true;
            //lbl1.Visible = true;
            //lblBillTotal.Visible = false;
            dgvSort.DataSource = bus_menu.getData();
            cbbM.Enabled = true;
            cbbNV.Enabled = false;
            cbbHD.Enabled = false;
            lblTotal.Visible = false;
            lblTotalVal.Visible = false;

        

            dgvSort.Columns[0].HeaderText = "Mã món";
            dgvSort.Columns[1].HeaderText = "Tên món";
            dgvSort.Columns[2].HeaderText = "Mã loại";
            dgvSort.Columns[3].HeaderText = "Đơn giá";
            dgvSort.Columns[4].HeaderText = "Chi phí nguyên liệu";

            dgvSort.Columns[1].Width = 150;

            for (int i = 0; i < 5; ++i)
            {
                dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvSort.EnableHeadersVisualStyles = false;

        }
        private void rbem_CheckedChanged(object sender, EventArgs e)
        {
            cbbM.Enabled = false;
            cbbNV.Enabled = true;
            cbbHD.Enabled = false;
            lblTotal.Visible = true;
            lblTotalVal.Visible = true;

            dgvSort.DataSource = bus_emp.getAll();

            dgvSort.Columns[0].HeaderText = "Mã NV";
            dgvSort.Columns[1].HeaderText = "Họ tên NV";
            dgvSort.Columns[2].HeaderText = "Giới tính";
            dgvSort.Columns[3].HeaderText = "Loại";
            dgvSort.Columns[4].HeaderText = "Năm sinh";
            dgvSort.Columns[5].HeaderText = "Địa chỉ";
            dgvSort.Columns[6].HeaderText = "SĐT";

            for (int i = 0; i < 7; ++i)
            {
                dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }


            dgvSort.EnableHeadersVisualStyles = false;

            dgvSort.Columns[1].Width = 150;
            dgvSort.Columns[2].Width = 70;
            dgvSort.Columns[3].Width = 70;
            dgvSort.Columns[4].Width = 70;
            dgvSort.Columns[5].Width = 300;
        }




        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dgvSort.Rows[index].Selected = true;
        }

        private void rbbill_CheckedChanged(object sender, EventArgs e)
        {
            cbbM.Enabled = false;
            cbbNV.Enabled = false;
            cbbHD.Enabled = true;
            lblTotal.Visible = true;
            lblTotalVal.Visible = true;

            dgvSort.DataSource = bus_hd2.getAllHDB();

            for (int i = 0; i < 8; ++i)
            {
                dgvSort.Columns[i].HeaderCell.Style.BackColor = Color.LightGreen;

            }
            dgvSort.EnableHeadersVisualStyles = false;
            dgvSort.Columns[0].HeaderText = "Mã HĐ";
            dgvSort.Columns[1].HeaderText = "Nhân viên lập";
            dgvSort.Columns[2].HeaderText = "Tên Khách hàng";
            dgvSort.Columns[3].HeaderText = "SĐT Khách hàng";
            dgvSort.Columns[4].HeaderText = "Bàn";
            dgvSort.Columns[5].HeaderText = "Ngày lập";
            dgvSort.Columns[6].HeaderText = "Mã khuyến mãi";
            dgvSort.Columns[7].HeaderText = "Tổng hóa đơn";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes) this.Close();
        }

        private void cbbHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbHD.SelectedIndex == 2)
            {
                cbbMo.Enabled = false;
                cbbYear.Enabled = false;
                rbIn.Enabled = false;
                rbDe.Enabled = false;
            }
            else
            {
                cbbMo.Enabled = true;
                cbbYear.Enabled = true;
                rbIn.Enabled = true;
                rbDe.Enabled = true;
            }
        }

        

        private void btnExport_Click(object sender, EventArgs e)
        {
            dt = new System.Data.DataTable();
            if (rbbill.Checked && cbbHD.SelectedIndex == 0)
            {
                DataColumn c1 = new DataColumn("maHD");
                DataColumn c2 = new DataColumn("maNV");
                //DataColumn c3 = new DataColumn("tenKH");
                DataColumn c4 = new DataColumn("sdtKH");
                DataColumn c5 = new DataColumn("maBan");
                DataColumn c6 = new DataColumn("ngayLap");
                DataColumn c7 = new DataColumn("maKM");
                DataColumn c8 = new DataColumn("tongTien");

                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                //dt.Columns.Add(c3);
                dt.Columns.Add(c4);
                dt.Columns.Add(c5);
                dt.Columns.Add(c6);
                dt.Columns.Add(c7);
                dt.Columns.Add(c8);

                foreach (DataGridViewRow row in dgvSort.Rows)
                {
                    DataRow drow = dt.NewRow();
                    drow[0] = row.Cells[0].Value;
                    drow[1] = row.Cells[1].Value;
                    drow[2] = row.Cells[2].Value;
                    drow[3] = row.Cells[3].Value;
                    drow[4] = row.Cells[4].Value;
                    drow[5] = row.Cells[5].Value;
                    drow[6] = row.Cells[6].Value;
                    //drow[7] = row.Cells[7].Value;

                    dt.Rows.Add(drow);
                }
                ExcelHelper ex = new ExcelHelper();
                ex.ExportFileReport(dt, "danh sach", "BÁO CÁO DANH SÁCH HÓA ĐƠN", 0, cbbMo.Text, cbbYear.Text);
                //ExportFile(dt, "Danh sach", "BÁO CÁO DANH SÁCH HÓA ĐƠN", 0);
            }
            if (rbbill.Checked && cbbHD.SelectedIndex == 1)
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

                foreach (DataGridViewRow row in dgvSort.Rows)
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
                ex.ExportFileReport(dt, "danh sach", "BÁO CÁO DANH SÁCH HÓA ĐƠN NHẬP", 1, cbbMo.Text, cbbYear.Text);
                //ExportFile(dt, "Danh sach", "BÁO CÁO DANH SÁCH HÓA ĐƠN NHẬP", 1);
            }
            if (rbse.Checked)
            {
                DataColumn c1 = new DataColumn("maMon");
                DataColumn c2 = new DataColumn("tenMon");
                DataColumn c3 = new DataColumn("donGia");
                DataColumn c4 = new DataColumn("tongSoLuong");


                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                dt.Columns.Add(c3);
                dt.Columns.Add(c4);

                foreach (DataGridViewRow row in dgvSort.Rows)
                {
                    DataRow drow = dt.NewRow();
                    drow[0] = row.Cells[0].Value;
                    drow[1] = row.Cells[1].Value;
                    drow[2] = row.Cells[2].Value;
                    drow[3] = row.Cells[3].Value;


                    dt.Rows.Add(drow);
                }
                ExcelHelper ex = new ExcelHelper();
                ex.ExportFileReport(dt, "danh sach", "BÁO CÁO SỐ LƯỢNG MÓN BÁN", 2, cbbMo.Text, cbbYear.Text);
                //ExportFile(dt, "Danh sach", "BÁO CÁO SỐ LƯỢNG ĐÃ BÁN", 2);
            }

            if (rbem.Checked)
            {
                DataColumn c1 = new DataColumn("maNV");
                DataColumn c2 = new DataColumn("thang");
                DataColumn c3 = new DataColumn("nam");
                DataColumn c4 = new DataColumn("luong");
                DataColumn c5 = new DataColumn("thuong");
                DataColumn c6 = new DataColumn("diemDanh");
                DataColumn c7 = new DataColumn("tongLuong");


                dt.Columns.Add(c1);
                dt.Columns.Add(c2);
                dt.Columns.Add(c3);
                dt.Columns.Add(c4);
                dt.Columns.Add(c5);
                dt.Columns.Add(c6);
                dt.Columns.Add(c7);

                foreach (DataGridViewRow row in dgvSort.Rows)
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
                ExcelHelper ex = new ExcelHelper();
                ex.ExportFileReport(dt, "danh sach", "BÁO CÁO LƯƠNG - ĐIỂM DANH NHÂN VIÊN", 3, cbbMo.Text, cbbYear.Text);
                //ExportFile(dt, "Danh sach", "BÁO CÁO LƯƠNG - ĐIỂM DANH NHÂN VIÊN", 3);
            }
        }
    }
}
