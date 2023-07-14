using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Word;
using System.Reflection;
namespace BUS
{
    class WordExport
    {
        public void exportword(object dgvName)
        {
            Application word = new Application();

            Document doc = word.Documents.Open("path_to_your_word_file");

            // Lấy bảng đầu tiên trong tập tin Word
            Table tbl = doc.Tables[1];

            // Duyệt qua từng dòng của DataGridView và thêm dữ liệu vào bảng trong Word
            //for (int i = 0; i < dgvName.Rows.Count; i++)
            //{
                // Lấy giá trị từng ô của dòng hiện tại trong DataGridView
                //string col1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                //string col2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                //string col3 = dataGridView1.Rows[i].Cells[2].Value.ToString();

                // Thêm dòng mới vào bảng trong Word
                Row newRow = tbl.Rows.Add();

                // Thiết lập giá trị cho từng ô trong dòng mới
                //newRow.Cells[1].Range.Text = col1;
                //newRow.Cells[2].Range.Text = col2;
                //newRow.Cells[3].Range.Text = col3;
            //}

            // Lưu và đóng tập tin Word
            doc.Save();
            doc.Close();

            // Thoát ứng dụng Word
            word.Quit();
        }
    }

}
