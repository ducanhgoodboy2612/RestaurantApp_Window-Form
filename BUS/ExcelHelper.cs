using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace BUS
{
    public class ExcelHelper
    {
        private void ExportBillInfo(Microsoft.Office.Interop.Excel.Range info, int c, string mon, string yea)
        {
            //info = oSheet.get_Range("B2", "C2");


            if (c == 0)
                info.Value2 = "Tháng: " + mon;
            if (c == 1)
                info.Value2 = "Năm: " + yea;

            if (c == 3)
            {
                info.Value2 = "Ngày lập báo cáo: Ngày    tháng    năm    ";
                info.Font.Italic = true;
                info.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            if (c == 4)
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

        public void ExportFileReport(System.Data.DataTable dataTable, string sheetName, string title, int c, string m, string y)
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

           

            //
            Microsoft.Office.Interop.Excel.Range mon = oSheet.get_Range("B4", "C4");

            ExportBillInfo(mon, 0, m, y);

            Microsoft.Office.Interop.Excel.Range year = oSheet.get_Range("B5", "C5");

            ExportBillInfo(year, 1, m, y);

            string endCell = "";
            string endCell2 = "";

            // Tạo tiêu đề cột

            if (c == 0)
            {

                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A7", "A7");

                cl1.Value2 = "Mã hóa đơn";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B7", "B7");

                cl2.Value2 = "Mã nhân viên lập";

                cl2.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C7", "C7");

                cl3.Value2 = "Bàn";
                cl3.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D7", "D7");

                cl4.Value2 = "SĐT khách hàng";

                cl4.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E7", "E7");

                cl5.Value2 = "Mã khuyến mãi";

                cl5.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F7", "F7");

                cl6.Value2 = "Ngày lập";

                cl6.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G7", "G7");

                cl7.Value2 = "Tổng HĐ";

                cl7.ColumnWidth = 20;

                endCell = "G1";
                endCell2 = "G3";

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A7", "G7");

                rowHead.Font.Bold = true;

                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            if (c == 1)
            {
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A7", "A7");

                cl1.Value2 = "Mã hóa đơn";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B7", "B7");

                cl2.Value2 = "Tên nhân viên lập";

                cl2.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C7", "C7");

                cl3.Value2 = "Nhà cung cấp";
                cl3.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D7", "D7");

                cl4.Value2 = "Ngày nhập";

                cl4.ColumnWidth = 23;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E7", "E7");

                cl5.Value2 = "Tổng Hóa đơn";

                cl5.ColumnWidth = 15;

                endCell = "E1";
                endCell2 = "E3";

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A7", "E7");

                rowHead.Font.Bold = true;

                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            if (c == 2)
            {
                //head = oSheet.get_Range("A1", "D1");

                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A7", "A7");

                cl1.Value2 = "Mã món";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B7", "B7");

                cl2.Value2 = "Tên món";

                cl2.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C7", "C7");

                cl3.Value2 = "Đơn giá";
                cl3.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D7", "D7");

                cl4.Value2 = "Số lượng bán";

                cl4.ColumnWidth = 20;

                endCell = "D1";
                endCell2 = "D3";


                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A7", "D7");

                rowHead.Font.Bold = true;

                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            if (c == 3)
            {
                

                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A7", "A7");

                cl1.Value2 = "Mã NV";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B7", "B7");

                cl2.Value2 = "Tháng";

                cl2.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C7", "C7");

                cl3.Value2 = "Năm";
                cl3.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D7", "D7");

                cl4.Value2 = "Lương";

                cl4.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E7", "E7");

                cl5.Value2 = "Thưởng";

                cl5.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F7", "F7");

                cl6.Value2 = "Điểm danh";

                cl6.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G7", "G7");

                cl7.Value2 = "Tổng lương";

                cl7.ColumnWidth = 15;

                endCell = "G1";
                endCell2 = "G3";



                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A7", "G7");

                rowHead.Font.Bold = true;

                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", endCell);


            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //
            Microsoft.Office.Interop.Excel.Range resname = oSheet.get_Range("A3", endCell2);

            resname.MergeCells = true;

            resname.Value2 = "Nhà hàng Cơm gà Hội An";

            resname.Font.Italic = true;

            resname.Font.Name = "Times New Roman";

            resname.Font.Size = "14";

            resname.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


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

            //Thiết lập vùng điền dữ liệu

            int rowStart = 8;

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

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            DateTime currentDate = DateTime.Now;

            Microsoft.Office.Interop.Excel.Range dateRange = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnEnd - 1];

            //Microsoft.Office.Interop.Excel.Range dateRange = oSheet.get_Range(oSheet.Cells[lastRow, columnEnd-1], oSheet.Cells[lastRow, columnEnd]);

            dateRange.Value2 = "Ngày " + currentDate.Day.ToString("00") + " tháng " + currentDate.Month.ToString("00") + " năm " + currentDate.Year.ToString();

            dateRange.MergeCells = true;



            dateRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range emp = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 4, columnEnd - 1];



            emp.Value2 = "Nhân viên báo cáo";

            emp.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void ExportFileBill(System.Data.DataTable dataTable, string sheetName, string title, int billTy)
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            if (billTy == 0)
            {

                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

                cl1.Value2 = "Mã hóa đơn";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

                cl2.Value2 = "Tên nhân viên lập";

                cl2.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

                cl3.Value2 = "Tên khách hàng";
                cl3.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

                cl4.Value2 = "SĐT khách hàng";

                cl4.ColumnWidth = 13;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

                cl5.Value2 = "Bàn ăn";

                cl5.ColumnWidth = 25;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

                cl6.Value2 = "Ngày lập";

                cl6.ColumnWidth = 18.5;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

                cl7.Value2 = "Mã khuyến mại";

                cl7.ColumnWidth = 13;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

                cl8.Value2 = "Tổng Hóa đơn";

                cl8.ColumnWidth = 18;

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");

                rowHead.Font.Bold = true;

                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }
            else
            {
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

                cl1.Value2 = "Mã hóa đơn";

                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

                cl2.Value2 = "Tên nhân viên lập";

                cl2.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

                cl3.Value2 = "Nhà cung cấp";
                cl3.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

                cl4.Value2 = "Ngày nhập";

                cl4.ColumnWidth = 23;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

                cl5.Value2 = "Tổng Hóa đơn";

                cl5.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");

                rowHead.Font.Bold = true;

                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

                rowHead.Interior.ColorIndex = 6;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            
                
            }



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

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

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

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            DateTime currentDate = DateTime.Now;

            Microsoft.Office.Interop.Excel.Range dateRange = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnEnd - 1];

            //Microsoft.Office.Interop.Excel.Range dateRange = oSheet.get_Range(oSheet.Cells[lastRow, columnEnd-1], oSheet.Cells[lastRow, columnEnd]);

            dateRange.Value2 = "Ngày " + currentDate.Day.ToString("00") + " tháng " + currentDate.Month.ToString("00") + " năm " + currentDate.Year.ToString();

            dateRange.MergeCells = true;



            dateRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range emp = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 4, columnEnd - 1];



            emp.Value2 = "Nhân viên báo cáo";

            emp.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }


        public static void ExportFileEmp(System.Data.DataTable dataTable, string sheetName, string title)
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            //subtitle
            Microsoft.Office.Interop.Excel.Range subtit = oSheet.get_Range("A3", "G3");

            subtit.MergeCells = true;

            subtit.Value2 = "Nhà hàng Cơm gà Hội An";

            subtit.Font.Italic = true;

            subtit.Font.Name = "Times New Roman";

            head.Font.Size = "16";

            subtit.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 


            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A5", "A5");

            cl1.Value2 = "Mã nhân viên";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B5", "B5");

            cl2.Value2 = "Họ tên nhân viên";

            cl2.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C5", "C5");

            cl3.Value2 = "Giới tính";
            cl3.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D5", "D5");

            cl4.Value2 = "Mã loại";

            cl4.ColumnWidth = 13;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E5", "E5");

            cl5.Value2 = "Năm sinh";

            cl5.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F5", "F5");

            cl6.Value2 = "Địa chỉ";

            cl6.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G5", "G5");

            cl7.Value2 = "SĐT";

            cl7.ColumnWidth = 13;

               

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A5", "G5");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

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

            //Thiết lập vùng điền dữ liệu

            int rowStart = 6;

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

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            DateTime currentDate = DateTime.Now;

            Microsoft.Office.Interop.Excel.Range dateRange = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnEnd - 1];

            //Microsoft.Office.Interop.Excel.Range dateRange = oSheet.get_Range(oSheet.Cells[lastRow, columnEnd-1], oSheet.Cells[lastRow, columnEnd]);

            dateRange.Value2 = "Ngày " + currentDate.Day.ToString("00") + " tháng " + currentDate.Month.ToString("00") + " năm " + currentDate.Year.ToString();

            dateRange.MergeCells = true;

            

            dateRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            
            Microsoft.Office.Interop.Excel.Range emp = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 4, columnEnd - 1];

            

            emp.Value2 = "Nhân viên báo cáo";

            emp.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        //public void addFooter(int rowEnd)
        //{
        //    DateTime currentDate = DateTime.Now;

        //    Microsoft.Office.Interop.Excel.Range dateRange = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnEnd - 1];

        //    //Microsoft.Office.Interop.Excel.Range dateRange = oSheet.get_Range(oSheet.Cells[lastRow, columnEnd-1], oSheet.Cells[lastRow, columnEnd]);

        //    dateRange.Value2 = "Ngày " + currentDate.Day.ToString("00") + " tháng " + currentDate.Month.ToString("00") + " năm " + currentDate.Year.ToString();

        //    dateRange.MergeCells = true;



        //    dateRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


        //    Microsoft.Office.Interop.Excel.Range emp = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 4, columnEnd - 1];



        //    emp.Value2 = "Nhân viên báo cáo";

        //    emp.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //}

        public static DataTable ImportExcel(string path)
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
                        string cellValue = ws.Cells[i, j].Value?.ToString() ?? "";
                        lstRows.Add(cellValue);

                        //lstRows.Add(ws.Cells[i, j].Value.ToString());
                    }
                    dt.Rows.Add(lstRows.ToArray());
                }
                return dt;
            }
        }
        public static DataTable ReadFromExcelFile(string path, int headerRow, out string messageError)
        {
            DataTable result = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path).ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var workBook = package.Workbook;
                    if (workBook == null || workBook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }
                    var workSheet = workBook.Worksheets.First();
                    //Read all header column from first row in file excel    
                    int columnCount = 0;
                    foreach (var firstRowCell in workSheet.Cells[headerRow, 1, headerRow, workSheet.Dimension.End.Column])
                    {
                        string columnName = "" + firstRowCell.Text.Trim();
                        if (string.IsNullOrEmpty(columnName))
                            break;
                        columnCount++;
                        result.Columns.Add(firstRowCell.Text.Trim());
                    }
                    //Read data into datatable from second row in file excel

                    for (var rowNumber = headerRow + 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, columnCount];
                        var newRow = result.NewRow();
                        bool isRowData = false;
                        string str = "";
                        //Read and check row data not Empty
                        foreach (var cell in row)
                        {
                            if (cell != null)
                                isRowData = true;

                            newRow[cell.Start.Column - 1] = cell.Value;
                            str += cell.Value != null ? cell.Value : "";
                        }
                        //Add row data to Datatable
                        if (isRowData && !string.IsNullOrEmpty(str.Trim()))
                            result.Rows.Add(newRow);
                        if (string.IsNullOrEmpty(str.Trim())) break;
                    }
                }
                messageError = "";
            }
            catch (Exception ex) { messageError = "ERROR:" + ex.Message; }

            return result;
        }
        public static DataTable ReadFromExcelFile(string path, string sheetName, int headerRow, out string messageError)
        {
            DataTable result = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path).ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var workBook = package.Workbook;
                    if (workBook == null || workBook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }

                    var workSheet = workBook.Worksheets.FirstOrDefault(x => x.Name == sheetName);
                    if (!string.IsNullOrEmpty(sheetName) && workSheet == null)
                    {
                        messageError = "WRONG_TEMPLATE";
                        return null;
                    }

                    //Read all header column from first row in file excel                   
                    foreach (var firstRowCell in workSheet.Cells[headerRow, 1, headerRow, workSheet.Dimension.End.Column])
                    {
                        string columnName = "" + firstRowCell.Text.Trim();
                        if (string.IsNullOrEmpty(columnName))
                            break;
                        result.Columns.Add(firstRowCell.Text);
                    }
                    //Read data into datatable from second row in file excel
                    for (var rowNumber = headerRow + 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                        var newRow = result.NewRow();

                        bool isRowData = false;

                        //Read and check row data not Empty
                        foreach (var cell in row)
                        {
                            //string textValue = ("" + cell.Text).Trim();
                            if (cell != null)
                                isRowData = true;

                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        //Add row data to Datatable
                        if (isRowData)
                            result.Rows.Add(newRow);
                    }
                }
                messageError = "";
            }
            catch (Exception ex) { messageError = "ERROR:" + ex.Message; }

            return result;
        }
        public static DataTable ReadFromExcelFile(string path, string sheetName, int headerRow, List<Type> types, out string messageError)
        {
            DataTable result = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    messageError = "FILE_NOT_EXISTS";
                    return null;
                }

                if (!string.IsNullOrEmpty(path) && Path.HasExtension(path) && Path.GetExtension(path).ToLower() != ".xlsx")
                {
                    messageError = "WRONG_FORMAT_FILE";
                    return null;
                }
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var workBook = package.Workbook;
                    if (workBook == null || workBook.Worksheets.Count == 0)
                    {
                        messageError = "EMPTY_DATA";
                        return null;
                    }

                    var workSheet = workBook.Worksheets.First();
                    if (!string.IsNullOrEmpty(sheetName) && workSheet.Name != sheetName)
                    {
                        messageError = "WRONG_TEMPLATE";
                        return null;
                    }

                    //Read all header column from first row in file excel
                    int typeIndex = -1;
                    foreach (var firstRowCell in workSheet.Cells[headerRow, 1, headerRow, workSheet.Dimension.End.Column])
                    {
                        typeIndex++;

                        string columnName = "" + firstRowCell.Text.Trim();
                        if (string.IsNullOrEmpty(columnName))
                            break;
                        if (types != null && types.Count > typeIndex)
                            result.Columns.Add(firstRowCell.Text, types[typeIndex]);
                        else result.Columns.Add(firstRowCell.Text);
                    }
                    //Read data into datatable from second row in file excel
                    for (var rowNumber = headerRow + 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                        var newRow = result.NewRow();

                        bool isRowData = false;

                        //Read and check row data not Empty
                        foreach (var cell in row)
                        {
                            //string textValue = ("" + cell.Text).Trim();
                            if (cell != null)
                                isRowData = true;

                            //Catch error when data input cannot mapping with type column
                            try
                            {
                                newRow[cell.Start.Column - 1] = cell.Value == null ? DBNull.Value : cell.Value;
                            }
                            catch (Exception ex)
                            {
                                newRow[cell.Start.Column - 1] = DBNull.Value;
                            }
                        }
                        //Add row data to Datatable
                        if (isRowData)
                            result.Rows.Add(newRow);
                    }
                }
                messageError = "";
            }
            catch (Exception ex) { messageError = "ERROR:" + ex.StackTrace; }

            return result;
        }

        public static string ExportInsuranceChronicCelling(string pathFileTemplate, string pathFileExport, DataTable data, int tableDataStartColumn, int tableDataStartRow, string timeRange, string formatDateTime = "", string formatNumber = "", bool default_number = false)
        {

            try
            {
                string pathTemplateFolder = Path.GetDirectoryName(pathFileTemplate);
                if (!File.Exists(pathFileTemplate))
                    pathFileTemplate = pathTemplateFolder + @"\EMPTY_TEMPLATE.xlsx";

                if (data == null || data.Rows.Count == 0)
                    return "DATA_EXPORT_EMPTY";

                File.Copy(pathFileTemplate, pathFileExport, true);
                var existingFile = new FileInfo(pathFileExport);
                if (!existingFile.Exists)
                    return "PATH_FILE_EXPORT_NOT_EXISTS";
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(existingFile))
                {
                    //Get the work book in the file
                    var workBook = package.Workbook;
                    if (workBook != null)
                        if (workBook.Worksheets.Count > 0)
                        {
                            //Get the first worksheet
                            var worksheet = workBook.Worksheets.First();
                            var indexRow = tableDataStartRow;
                            var indexColumn = tableDataStartColumn;
                            int columnCount = data.Columns.Count;
                            worksheet.Cells[tableDataStartRow - 2, tableDataStartColumn, tableDataStartRow - 2, tableDataStartColumn + columnCount - 1].Merge = true;
                            worksheet.Cells[tableDataStartRow - 2, tableDataStartColumn, tableDataStartRow - 2, tableDataStartColumn + columnCount - 1].Value = timeRange;
                            worksheet.Cells[tableDataStartRow - 2, tableDataStartColumn, tableDataStartRow - 2, tableDataStartColumn + columnCount - 1].Style.Font.Italic = true;
                            worksheet.Cells[tableDataStartRow - 2, tableDataStartColumn, tableDataStartRow - 2, tableDataStartColumn + columnCount - 1].Style.Font.Bold = true;
                            worksheet.Cells[tableDataStartRow - 2, tableDataStartColumn, tableDataStartRow - 2, tableDataStartColumn + columnCount - 1].Style.Font.Size -= 2;
                            // Fill data header static data to file excel
                            foreach (DataRow row in data.Rows)
                            {
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn + 1].Merge = true;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn + 1].Value = row["title"];
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn + 1].Style.Font.Bold = true;
                                indexRow++;
                                for (int i = 1; i < columnCount; i++)
                                {
                                    object value = ParseCellValue(row[i], formatNumber, formatDateTime, default_number);
                                    worksheet.Cells[indexRow, i + 1, indexRow, i + 1].Value = (value + "") == "" ? 0 : value;
                                }
                                indexRow++;
                            }
                            indexRow--;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, columnCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, columnCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, columnCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, columnCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }
                    // save our new workbook and we are done!
                    package.Save();
                }

            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "";
        }


        public static string ExportInsuranceCelling(string pathFileTemplate, string pathFileExport, DataTable opd_data, DataTable ipd_data, int tableDataStartColumn, int tableDataStartRow, string timeRange, string formatDateTime = "", string formatNumber = "", bool default_number = false)
        {

            try
            {
                string pathTemplateFolder = Path.GetDirectoryName(pathFileTemplate);
                if (!File.Exists(pathFileTemplate))
                    pathFileTemplate = pathTemplateFolder + @"\EMPTY_TEMPLATE.xlsx";

                if (opd_data == null || opd_data.Rows.Count == 0)
                    return "DATA_EXPORT_EMPTY";

                File.Copy(pathFileTemplate, pathFileExport, true);
                var existingFile = new FileInfo(pathFileExport);
                if (!existingFile.Exists)
                    return "PATH_FILE_EXPORT_NOT_EXISTS";
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(existingFile))
                {
                    //Get the work book in the file
                    var workBook = package.Workbook;
                    if (workBook != null)
                        if (workBook.Worksheets.Count > 0)
                        {
                            //Get the first worksheet
                            var worksheet = workBook.Worksheets.First();
                            var indexRow = tableDataStartRow;


                            int columnCount = opd_data.Columns.Count - 1;
                            worksheet.Cells[tableDataStartRow - 3, tableDataStartColumn, tableDataStartRow - 3, tableDataStartColumn + columnCount + 4].Merge = true;
                            worksheet.Cells[tableDataStartRow - 3, tableDataStartColumn, tableDataStartRow - 3, tableDataStartColumn + columnCount + 4].Value = timeRange;
                            worksheet.Cells[tableDataStartRow - 3, tableDataStartColumn, tableDataStartRow - 3, tableDataStartColumn + columnCount + 4].Style.Font.Italic = true;
                            worksheet.Cells[tableDataStartRow - 3, tableDataStartColumn, tableDataStartRow - 3, tableDataStartColumn + columnCount + 4].Style.Font.Bold = true;
                            worksheet.Cells[tableDataStartRow - 3, tableDataStartColumn, tableDataStartRow - 3, tableDataStartColumn + columnCount + 4].Style.Font.Size -= 2;

                            string col4 = GetExcelColumnName(tableDataStartColumn + 4);
                            string col5 = GetExcelColumnName(tableDataStartColumn + 5);
                            string col6 = GetExcelColumnName(tableDataStartColumn + 6);
                            string col7 = GetExcelColumnName(tableDataStartColumn + 7);
                            string col8 = GetExcelColumnName(tableDataStartColumn + 8);
                            string col9 = GetExcelColumnName(tableDataStartColumn + 9);
                            string col10 = GetExcelColumnName(tableDataStartColumn + 10);
                            string col11 = GetExcelColumnName(tableDataStartColumn + 11);
                            string col12 = GetExcelColumnName(tableDataStartColumn + 12);

                            // Fill data header static data to file excel
                            foreach (DataRow row in opd_data.Rows)
                            {

                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Value = row["display_name"];
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Style.Font.Bold = true;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                for (int i = 2; i < columnCount; i++)
                                {
                                    object value = ParseCellValue(row[i], formatNumber, formatDateTime, default_number);
                                    worksheet.Cells[indexRow, i, indexRow, i].Value = (value + "") == "" ? 0 : value;

                                }
                                var indexColumn = tableDataStartColumn + columnCount - 1;
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}-{2}{1}", col6, indexRow, col4);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}-{2}{1}", col7, indexRow, col5);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}+{2}{1}", col4, indexRow, col5);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}+{2}{1}", col6, indexRow, col7);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}-{2}{1}", col11, indexRow, col10);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}/{2}{1}", col12, indexRow, col11);
                                indexRow++;
                            }
                            indexRow++;
                            foreach (DataRow row in ipd_data.Rows)
                            {
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Merge = true;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Value = row["display_name"];
                                if (row["clinical_code"] + "" == "")
                                {
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Style.Font.Bold = true;
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                }
                                else
                                {
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, tableDataStartColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                }
                                for (int i = 2; i < columnCount; i++)
                                {
                                    object value = ParseCellValue(row[i], formatNumber, formatDateTime, default_number);
                                    worksheet.Cells[indexRow, i, indexRow, i].Value = (value + "") == "" ? 0 : value;
                                }
                                var indexColumn = tableDataStartColumn + columnCount - 1;
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}-{2}{1}", col6, indexRow, col4);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}-{2}{1}", col7, indexRow, col5);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}+{2}{1}", col4, indexRow, col5);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}+{2}{1}", col6, indexRow, col7);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}-{2}{1}", col11, indexRow, col10);
                                worksheet.Cells[indexRow, indexColumn, indexRow, indexColumn++].Formula = string.Format("{0}{1}/{2}{1}", col12, indexRow, col11);
                                indexRow++;
                            }
                            indexRow--;
                            var endcol = tableDataStartColumn + columnCount + 4;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            worksheet.Calculate();
                        }
                    // save our new workbook and we are done!
                    package.Save();
                }

            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "";
        }

        public static string ExportPatientRevenue(string pathFileTemplate, string pathFileExport, string sheetName, DataTable data, int tableDataStartColumn, int tableDataStartRow, string timeRange, string formatDateTime = "", string formatNumber = "", bool default_number = false, bool copy_file = true)
        {

            try
            {
                string pathTemplateFolder = Path.GetDirectoryName(pathFileTemplate);
                if (!File.Exists(pathFileTemplate))
                    pathFileTemplate = pathTemplateFolder + @"\EMPTY_TEMPLATE.xlsx";

                if (data == null || data.Rows.Count == 0)
                    return "DATA_EXPORT_EMPTY";
                if (copy_file)
                    File.Copy(pathFileTemplate, pathFileExport, true);
                var existingFile = new FileInfo(pathFileExport);
                if (!existingFile.Exists)
                    return "PATH_FILE_EXPORT_NOT_EXISTS";
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(existingFile))
                {
                    //Get the work book in the file
                    var workBook = package.Workbook;
                    if (workBook != null)
                        if (workBook.Worksheets.Count > 0)
                        {
                            //Get the first worksheet

                            var worksheet = workBook.Worksheets.FirstOrDefault(x => x.Name == sheetName);
                            if (worksheet == null)
                                throw new Exception("Sheet name not exists");


                            int columnCount = data.Columns.Count - 1;
                            string col2 = GetExcelColumnName(tableDataStartColumn + 3);
                            string col3 = GetExcelColumnName(tableDataStartColumn + 4);
                            string col4 = GetExcelColumnName(tableDataStartColumn + 5);
                            string col5 = GetExcelColumnName(tableDataStartColumn + 6);
                            string col6 = GetExcelColumnName(tableDataStartColumn + 7);
                            string col7 = GetExcelColumnName(tableDataStartColumn + 8);
                            string col8 = GetExcelColumnName(tableDataStartColumn + 9);
                            string col9 = GetExcelColumnName(tableDataStartColumn + 10);
                            string col10 = GetExcelColumnName(tableDataStartColumn + 11);

                            // Fill data header static data to file excel
                            string group_name = "";
                            int group_idx_before = 0;
                            var indexRow = tableDataStartRow + 1;

                            var colidx = tableDataStartColumn + 3;

                            worksheet.Cells[tableDataStartRow - 6, tableDataStartColumn, tableDataStartRow - 6, tableDataStartColumn + columnCount + 9].Merge = true;
                            worksheet.Cells[tableDataStartRow - 6, tableDataStartColumn, tableDataStartRow - 6, tableDataStartColumn + columnCount + 9].Value = timeRange;
                            worksheet.Cells[tableDataStartRow - 6, tableDataStartColumn, tableDataStartRow - 6, tableDataStartColumn + columnCount + 9].Style.Font.Italic = true;
                            worksheet.Cells[tableDataStartRow - 6, tableDataStartColumn, tableDataStartRow - 6, tableDataStartColumn + columnCount + 9].Style.Font.Bold = true;
                            worksheet.Cells[tableDataStartRow - 6, tableDataStartColumn, tableDataStartRow - 6, tableDataStartColumn + columnCount + 9].Style.Font.Size -= 2;
                            worksheet.Cells[tableDataStartRow - 6, tableDataStartColumn, tableDataStartRow - 6, tableDataStartColumn + columnCount + 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            List<int> group_row_idxs = new List<int>();
                            foreach (DataRow row in data.Rows)
                            {
                                string current_group_name = row["short_code"].ToString() + " - " + row["clinical_specialty_name"].ToString();

                                // check is first row of group

                                if (group_name != current_group_name)
                                {
                                    group_name = current_group_name;
                                    group_row_idxs.Add(indexRow);
                                    worksheet.Cells[indexRow, tableDataStartColumn + 1, indexRow, tableDataStartColumn + 2].Value = current_group_name;
                                    worksheet.Cells[indexRow, tableDataStartColumn + 1, indexRow, tableDataStartColumn + 2].Merge = true;
                                    worksheet.Cells[indexRow, tableDataStartColumn + 1, indexRow, tableDataStartColumn + 2].Style.Font.Bold = true;
                                    if (group_idx_before != 0)
                                    {
                                        // sum value for group row
                                        worksheet.Cells[group_idx_before, tableDataStartColumn, indexRow - 1, tableDataStartColumn].Merge = true;
                                        worksheet.Cells[group_idx_before + 1, tableDataStartColumn + 1, indexRow - 1, tableDataStartColumn + 1].Merge = true;
                                        colidx = tableDataStartColumn + 3;

                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                                        worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                                        colidx = AddFormulaPatientRevenue(worksheet, col2, col3, col4, col5, col6, col7, col8, col9, group_idx_before, colidx, true);
                                    }

                                    var indexCol = tableDataStartColumn + 3;
                                    // add formula for summary row
                                    worksheet.Cells[tableDataStartRow, indexCol, tableDataStartRow, indexCol].Formula += string.Format("+{0}{1}", GetExcelColumnName(indexCol), indexRow); indexCol++;
                                    worksheet.Cells[tableDataStartRow, indexCol, tableDataStartRow, indexCol].Formula += string.Format("+{0}{1}", GetExcelColumnName(indexCol), indexRow); indexCol++;
                                    worksheet.Cells[tableDataStartRow, indexCol, tableDataStartRow, indexCol].Formula += string.Format("+{0}{1}", GetExcelColumnName(indexCol), indexRow); indexCol++;
                                    worksheet.Cells[tableDataStartRow, indexCol, tableDataStartRow, indexCol].Formula += string.Format("+{0}{1}", GetExcelColumnName(indexCol), indexRow); indexCol++;
                                    worksheet.Cells[tableDataStartRow, indexCol, tableDataStartRow, indexCol].Formula += string.Format("+{0}{1}", GetExcelColumnName(indexCol), indexRow); indexCol++;


                                    group_idx_before = indexRow;
                                    indexRow++;
                                    colidx = tableDataStartColumn + 3;
                                    object value = ParseCellValue(row[3], formatNumber, formatDateTime, default_number);
                                    worksheet.Cells[indexRow, 3, indexRow, 3].Value = value;

                                    for (int i = 4; i <= columnCount; i++)
                                    {
                                        value = ParseCellValue(row[i], formatNumber, formatDateTime, default_number);
                                        worksheet.Cells[indexRow, i, indexRow, i].Value = (value + "") == "" ? 0 : value;
                                        colidx++;
                                    }
                                    colidx = AddFormulaPatientRevenue(worksheet, col2, col3, col4, col5, col6, col7, col8, col9, indexRow, colidx, false);
                                }
                                else
                                {
                                    colidx = tableDataStartColumn + 3;
                                    object value = ParseCellValue(row[3], formatNumber, formatDateTime, default_number);
                                    worksheet.Cells[indexRow, 3, indexRow, 3].Value = value;
                                    for (int i = 4; i <= columnCount; i++)
                                    {
                                        value = ParseCellValue(row[i], formatNumber, formatDateTime, default_number);
                                        worksheet.Cells[indexRow, i, indexRow, i].Value = (value + "") == "" ? 0 : value;
                                        colidx++;
                                    }
                                    colidx = AddFormulaPatientRevenue(worksheet, col2, col3, col4, col5, col6, col7, col8, col9, indexRow, colidx, false);
                                }



                                indexRow++;
                            }
                            worksheet.Cells[group_idx_before, tableDataStartColumn, indexRow - 1, tableDataStartColumn].Merge = true;
                            worksheet.Cells[group_idx_before + 1, tableDataStartColumn + 1, indexRow - 1, tableDataStartColumn + 1].Merge = true;
                            colidx = tableDataStartColumn + 3;
                            // sum value for last group row
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("SUM({0}{1}:{0}{2})", GetExcelColumnName(colidx), group_idx_before + 1, indexRow - 1);
                            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = true; colidx++;
                            colidx = AddFormulaPatientRevenue(worksheet, col2, col3, col4, col5, col6, col7, col8, col9, group_idx_before, colidx, true);
                            indexRow--;
                            var endcol = tableDataStartColumn + columnCount + 9;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow, endcol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                            worksheet.Calculate();
                        }
                    // save our new workbook and we are done!
                    package.Save();
                }

            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "";
        }

        private static int AddFormulaPatientRevenue(ExcelWorksheet worksheet, string col2, string col3, string col4, string col5, string col6, string col7, string col8, string col9, int group_idx_before, int colidx, bool isBold)
        {
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}+{2}{1}", col3, group_idx_before, col5);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}+{2}{1}", col4, group_idx_before, col6);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}+{2}{1}", col7, group_idx_before, col8);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col3, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col4, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col5, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col6, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col7, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col8, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Formula = string.Format("{0}{1}/{2}{1}", col9, group_idx_before, col2);
            worksheet.Cells[group_idx_before, colidx, group_idx_before, colidx].Style.Font.Bold = isBold; colidx++;
            return colidx;
        }

        public static string ExportDataTableToExcel(string pathFileExport, string pathFileTemplate, DataTable data, int tableDataStartColumn, int tableDataStartRow,
            List<ExcelDataExtention> reportStaticValue, bool fistColumnIsOrdNumber, string formatDateTime, string formatNumber, bool endRowIsSumValue, string sumValueText, int headerRowSpan = 1, bool contentDashBottomBorder = false, double dataRowHeight = 14.0, DataTable data2 = null, int isBoldGroup = 0, int fontSizeGroup = 0, int heightGroup = 0, List<ColumnColor> columnColors = null, bool default_number = false, bool coppy_file = true, string sheet_name = null)
        {
            try
            {
                string pathTemplateFolder = Path.GetDirectoryName(pathFileTemplate);
                if (!File.Exists(pathFileTemplate))
                    pathFileTemplate = pathTemplateFolder + @"\EMPTY_TEMPLATE.xlsx";

                if (data == null || data.Rows.Count == 0)
                    return "DATA_EXPORT_EMPTY";
                if (coppy_file)
                    File.Copy(pathFileTemplate, pathFileExport, true);
                var existingFile = new FileInfo(pathFileExport);
                if (!existingFile.Exists)
                    return "PATH_FILE_EXPORT_NOT_EXISTS";
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(existingFile))
                {
                    //Get the work book in the file
                    var workBook = package.Workbook;
                    if (workBook != null)
                        if (workBook.Worksheets.Count > 0)
                        {
                            //Get the first worksheet
                            var worksheet = workBook.Worksheets.First();
                            if (sheet_name + "" != "")
                            {
                                var sheet = workBook.Worksheets.FirstOrDefault(x => x.Name == sheet_name);
                                if (sheet != null)
                                    worksheet = sheet;
                            }

                            var indexRow = tableDataStartRow;
                            var indexColumn = tableDataStartColumn;
                            // Fill data header static data to file excel
                            var listHeaderReport = reportStaticValue.Where(x => x.IsEnd == false).ToList();
                            foreach (var headerItem in listHeaderReport)
                            {
                                if (headerItem.IsMerge)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Merge = true;

                                if (headerItem.TextRotation != null)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.TextRotation = headerItem.TextRotation.Value;

                                if (headerItem.FontBold)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Bold = true;

                                if (headerItem.FontUnderline)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.UnderLine = true;

                                if (headerItem.FontItalic)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Italic = true;

                                if (headerItem.FontSize > 0)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Size = headerItem.FontSize;

                                if (!string.IsNullOrEmpty(headerItem.FontName))
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.Font.Name = headerItem.FontName;

                                if (headerItem.AlignmentCenter)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                if (headerItem.AlignmentLeft)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                if (headerItem.AlignmentRight)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                                if (headerItem.IsDirectTextRotation90)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Style.TextRotation = 90;

                                if (headerItem.Value != null)
                                    worksheet.Cells[headerItem.StartColumnName + headerItem.StartRowIndex + ":" + (headerItem.EndColumnName ?? headerItem.StartColumnName) + headerItem.EndRowIndex].Value = headerItem.Value;
                                if (headerItem.WidthColumn > 0)
                                    worksheet.Column(GetExcelColumnIndex(headerItem.StartColumnName)).Width = headerItem.WidthColumn;
                                if (headerItem.WidthColumn == -1)
                                    worksheet.Column(GetExcelColumnIndex(headerItem.StartColumnName)).Width = 0;

                            }
                            //Fill dataTable to file excel
                            int ord = 1;
                            int columnCount = data.Columns.Count;
                            int columnTableCount = data.Columns.Count + (tableDataStartColumn - 1);
                            if (fistColumnIsOrdNumber)
                                columnTableCount++;
                            foreach (DataRow dr in data.Rows)
                            {
                                int startColumnIndex = tableDataStartColumn;

                                //Set Row Height
                                if (dataRowHeight > 0)
                                    worksheet.Row(indexRow).Height = dataRowHeight;

                                if (fistColumnIsOrdNumber)
                                {
                                    worksheet.Cells[indexRow, tableDataStartColumn].Value = ord;
                                    startColumnIndex = startColumnIndex + 1;
                                }
                                //
                                int indColumn = 0;
                                bool isBoldValue = false;

                                for (int c = startColumnIndex; c < columnCount + startColumnIndex; c++)
                                {
                                    object value = ParseCellValue(dr[indColumn], formatNumber, formatDateTime, default_number);
                                    if (isBoldGroup > 0 && c == startColumnIndex && string.IsNullOrEmpty(value + ""))
                                    {
                                        isBoldValue = true;
                                        c = c + isBoldGroup;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Merge = true;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Font.Bold = isBoldValue;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.WrapText = true;
                                        indColumn++;
                                        value = ParseCellValue(dr[indColumn], formatNumber, formatDateTime, default_number) + "";
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Value = value;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                                        //worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));
                                        if (fontSizeGroup > 0)
                                            worksheet.Cells[indexRow, c - isBoldGroup, indexRow, c].Style.Font.Size = fontSizeGroup;
                                        if (heightGroup > 0)
                                        {
                                            worksheet.Row(indexRow).Height = heightGroup;
                                        }
                                        indColumn += isBoldGroup;
                                        continue;
                                    }
                                    worksheet.Cells[indexRow, c].Value = value;
                                    worksheet.Cells[indexRow, c].Style.Font.Bold = isBoldValue;
                                    if (columnColors != null && columnColors.Count > 0)
                                    {
                                        var col = columnColors.FindIndex(x => x.ColumnIdx == c);
                                        if (col >= 0)
                                        {
                                            var color = columnColors[col];
                                            worksheet.Cells[indexRow, c].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                            worksheet.Cells[indexRow, c].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(color.R, color.G, color.B));
                                        }
                                    }
                                    indColumn++;
                                }
                                //
                                ord++;
                                indexRow++;
                            }
                            bool fisrtMatch = false;
                            //If EndRowTable is Sum Value
                            if (endRowIsSumValue)
                            {
                                int mergeIndex = 0;
                                for (int cl = 0; cl < columnCount; cl++)
                                {
                                    if (!IsColumnDataTypeNumber(data.Columns[cl].DataType))
                                    {
                                        if (!fisrtMatch)
                                            mergeIndex++;
                                    }
                                    else
                                    {
                                        fisrtMatch = true;
                                        string columnName = GetExcelColumnName(cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn));
                                        worksheet.Cells[indexRow, cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn)].Formula = string.Format("SUM({0}{1}:{2}{3})", columnName, tableDataStartRow, columnName, indexRow - 1);
                                    }
                                }

                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Merge = true;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Value = sumValueText;
                                worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Style.Font.Bold = true;
                            }
                            //Fill border to table
                            if (!contentDashBottomBorder)
                            {
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                            }
                            else
                            {
                                // Thin header                                                      
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                if (endRowIsSumValue)
                                {
                                    // Dash bottom content
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    // Thin sum row
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                }
                                else
                                {
                                    // Dash bottom content
                                    if (indexRow - tableDataStartRow >= 2)
                                    {
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    }
                                    // Thin last row
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                }
                                if (isBoldGroup > 0)
                                {
                                    for (int idx = 0; idx < data.Rows.Count; idx++)
                                    {
                                        if ((data.Rows[idx][0] + "") == "")
                                        {
                                            worksheet.Cells[tableDataStartRow + idx, tableDataStartColumn, tableDataStartRow + idx, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                            worksheet.Cells[tableDataStartRow + idx, tableDataStartColumn, tableDataStartRow + idx, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        }
                                    }
                                }

                            }

                            if (data2 != null)
                            {
                                //Fill Middle Static Value
                                var listMiddleReport = reportStaticValue.Where(x => x.IsEnd == null).OrderByDescending(x => x.StartRowIndex).ToList();
                                foreach (var middleItem in listMiddleReport)
                                {
                                    if (middleItem.IsMerge)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Merge = true;
                                    if (middleItem.TextRotation != null)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.TextRotation = middleItem.TextRotation.Value;
                                    if (middleItem.FontBold)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Bold = true;

                                    if (middleItem.FontUnderline)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.UnderLine = true;

                                    if (middleItem.FontItalic)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Italic = true;

                                    if (middleItem.FontSize > 0)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Size = middleItem.FontSize;

                                    if (!string.IsNullOrEmpty(middleItem.FontName))
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.Font.Name = middleItem.FontName;

                                    if (middleItem.AlignmentCenter)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                    if (middleItem.AlignmentLeft)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                                    if (middleItem.AlignmentRight)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                                    if (middleItem.IsDirectTextRotation90)
                                        worksheet.Cells[middleItem.StartColumnName + middleItem.StartRowIndex + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + middleItem.EndRowIndex].Style.TextRotation = 90;

                                    if (middleItem.Value != null)
                                        worksheet.Cells[middleItem.StartColumnName + (middleItem.StartRowIndex + indexRow) + ":" + (middleItem.EndColumnName ?? middleItem.StartColumnName) + (middleItem.EndRowIndex + indexRow)].Value = middleItem.Value;
                                }
                                ord = 1;
                                columnCount = data2.Columns.Count;
                                columnTableCount = data2.Columns.Count + (tableDataStartColumn - 1);
                                if (fistColumnIsOrdNumber)
                                    columnTableCount++;

                                indexRow = indexRow + (listMiddleReport.Count > 0 ? listMiddleReport[0].StartRowIndex : 0) + 1;
                                tableDataStartRow = indexRow - 1;
                                foreach (DataRow dr in data2.Rows)
                                {
                                    int startColumnIndex = tableDataStartColumn;

                                    //Set Row Height
                                    if (dataRowHeight > 0)
                                        worksheet.Row(indexRow).Height = dataRowHeight;
                                    if (fistColumnIsOrdNumber)
                                    {
                                        worksheet.Cells[indexRow, tableDataStartColumn].Value = ord;
                                        startColumnIndex = startColumnIndex + 1;
                                    }
                                    //
                                    int indColumn = 0;
                                    for (int c = startColumnIndex; c < columnCount + startColumnIndex; c++)
                                    {
                                        worksheet.Cells[indexRow, c].Value = ParseCellValue(dr[indColumn], formatNumber, formatDateTime, default_number);
                                        indColumn++;
                                    }
                                    ord++;
                                    indexRow++;
                                }

                                fisrtMatch = false;
                                //If EndRowTable 2 is Sum Value
                                if (endRowIsSumValue)
                                {
                                    int mergeIndex = 0;
                                    for (int cl = 0; cl < columnCount; cl++)
                                    {
                                        if (!IsColumnDataTypeNumber(data2.Columns[cl].DataType))
                                        {
                                            if (!fisrtMatch)
                                                mergeIndex++;
                                        }
                                        else
                                        {
                                            fisrtMatch = true;
                                            string columnName = GetExcelColumnName(cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn));
                                            worksheet.Cells[indexRow, cl + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn)].Formula = string.Format("SUM({0}{1}:{2}{3})", columnName, tableDataStartRow, columnName, indexRow - 1);

                                            //string columnName = GetExcelColumnName(cl + 1 + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn + 1));
                                            //worksheet.Cells[indexRow, cl + 1 + (fistColumnIsOrdNumber == true ? tableDataStartColumn : tableDataStartColumn + 1)].Formula = string.Format("SUM({0}{1}:{2}{3})", columnName, tableDataStartRow, columnName, indexRow - 1);
                                        }
                                    }
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Merge = true;
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Value = sumValueText;
                                    worksheet.Cells[indexRow, tableDataStartColumn, indexRow, mergeIndex + tableDataStartColumn - 1].Style.Font.Bold = true;
                                }

                                //Fill border to table 2
                                if (!contentDashBottomBorder)
                                {
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, endRowIsSumValue == true ? indexRow : indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                }
                                else
                                {
                                    // Thin header
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    worksheet.Cells[tableDataStartRow - headerRowSpan, tableDataStartColumn, tableDataStartRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    if (endRowIsSumValue)
                                    {
                                        // Dash bottom content
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));


                                        // Thin sum row
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    }
                                    else
                                    {
                                        // Dash bottom content
                                        if (indexRow - tableDataStartRow >= 2)
                                        {
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                            worksheet.Cells[tableDataStartRow, tableDataStartColumn, indexRow - 2, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        }
                                        // Thin last row
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Left.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Right.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Top.Color.SetColor(Color.FromArgb(128, 128, 128));
                                        worksheet.Cells[indexRow - 1, tableDataStartColumn, indexRow - 1, columnTableCount].Style.Border.Bottom.Color.SetColor(Color.FromArgb(128, 128, 128));
                                    }
                                }

                            }

                            //Fill Footer Static Value
                            var listFooterReport = reportStaticValue.Where(x => x.IsEnd == true).ToList();
                            foreach (var footerItem in listFooterReport)
                            {
                                if (footerItem.IsMerge)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Merge = true;

                                if (footerItem.FontBold)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Bold = true;

                                if (footerItem.FontUnderline)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.UnderLine = true;

                                if (footerItem.FontItalic)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Italic = true;

                                if (footerItem.FontSize > 0)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Size = footerItem.FontSize;

                                if (!string.IsNullOrEmpty(footerItem.FontName))
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.Font.Name = footerItem.FontName;

                                if (footerItem.AlignmentCenter)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                if (footerItem.AlignmentLeft)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                                if (footerItem.AlignmentRight)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                if (footerItem.IsDirectTextRotation90)
                                    worksheet.Cells[footerItem.StartColumnName + footerItem.StartRowIndex + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + footerItem.EndRowIndex].Style.TextRotation = 90;


                                if (footerItem.Value != null)
                                    worksheet.Cells[footerItem.StartColumnName + (footerItem.StartRowIndex + indexRow) + ":" + (footerItem.EndColumnName ?? footerItem.StartColumnName) + (footerItem.EndRowIndex + indexRow)].Value = footerItem.Value;
                            }
                        }
                    // save our new workbook and we are done!
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "";
        }

        #region Helper method
        public static object ParseCellValue(object dataValue, string formatedNumber, string formatedDateTime, bool defaul_number)
        {
            if (dataValue == null || dataValue is string)
                return dataValue;

            if (dataValue is int || dataValue is double || dataValue is float || dataValue is long)
            {
                if (dataValue == null && defaul_number)
                {
                    return "0";
                }
                else
                {
                    if (!string.IsNullOrEmpty(formatedNumber))
                        return ((double)dataValue).ToString(formatedNumber);
                    else return dataValue;
                }

            }

            if (dataValue is DateTime)
            {
                if (!string.IsNullOrEmpty(formatedDateTime))
                    return ((DateTime)dataValue).ToString(formatedDateTime);
                else return dataValue;
            }

            if (dataValue is bool)
                return ((bool)dataValue == true) ? "x" : "";

            return dataValue;
        }
        public static bool IsColumnDataTypeNumber(Type dataValue)
        {
            if (dataValue == typeof(System.Int16) || dataValue == typeof(System.Int32) || dataValue == typeof(System.Int64) || dataValue == typeof(System.Single) || dataValue == typeof(System.Double) || dataValue == typeof(System.Decimal))
                return true;

            return false;
        }
        public static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        public static int GetExcelColumnIndex(string colAdress)
        {
            int[] digits = new int[colAdress.Length];
            for (int i = 0; i < colAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(colAdress[i]) - 64;
            }
            int mul = 1; int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }
            return res;
        }
        public static List<ExcelDataExtention> AddTextColumnName(DataTable dt, int start_row, bool to_upper_text = false)
        {
            int i = -1;
            List<ExcelDataExtention> list = new List<ExcelDataExtention>();
            foreach (DataColumn c in dt.Columns)
            {
                string columnName = GetColumnNameExcel()[++i];
                list.Add(new ExcelDataExtention()
                {
                    IsEnd = false,
                    StartColumnName = columnName,
                    EndColumnName = columnName,
                    StartRowIndex = start_row,
                    EndRowIndex = start_row,
                    Value = to_upper_text ? c.ColumnName.ToUpper() : c.ColumnName
                });
            }
            return list;
        }
        public static string[] GetColumnNameExcel()
        {
            string columnNameExcel = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z," +
                "AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,AS,AT,AU,AV,AW,AY,AZ,AY,AZ," +
                "BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BO,BP,BQ,BR,BS,BT,BU,BV,BW,BY,BZ,BY,BZ,";
            return columnNameExcel.Split(',');
        }
        #endregion
    }

    public class ExcelDataExtention
    {
        public Guid Id { get; set; }
        public bool SetBackgroupColor { get; set; } = false;
        public List<string> ListSumColumnName { get; set; }
        public bool IsMerge { get; set; } = false;
        public bool? IsEnd { get; set; } = false;
        public bool FontUnderline { get; set; } = false;
        public bool FontBold { get; set; } = false;
        public bool FontItalic { get; set; } = false;
        public float FontSize { get; set; } = 0;
        public string FontName { get; set; }
        public string StartColumnName { get; set; }
        public string EndColumnName { get; set; }
        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }
        public bool AlignmentCenter { get; set; } = false;
        public double WidthColumn { get; set; } = 0;
        public bool AlignmentLeft { get; set; } = false;
        public bool AlignmentRight { get; set; } = false;
        public string Value { get; set; }
        public bool IsDirectTextRotation90 { get; set; } = false;
        public int? TextRotation { get; set; } = 0;
    }
    public class ColumnColor
    {
        public int ColumnIdx { get; set; }
        public int R { get; set; } = 0;
        public int G { get; set; } = 0;
        public int B { get; set; } = 0;
    }
}
