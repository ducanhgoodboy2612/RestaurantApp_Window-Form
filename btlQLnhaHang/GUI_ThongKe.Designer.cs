
namespace btlQLnhaHang
{
    partial class GUI_ThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbNV = new System.Windows.Forms.ComboBox();
            this.rbem = new System.Windows.Forms.RadioButton();
            this.cbbHD = new System.Windows.Forms.ComboBox();
            this.cbbM = new System.Windows.Forms.ComboBox();
            this.rbse = new System.Windows.Forms.RadioButton();
            this.lblBillTotal = new System.Windows.Forms.Label();
            this.rbbill = new System.Windows.Forms.RadioButton();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.rbDe = new System.Windows.Forms.RadioButton();
            this.dgvSort = new System.Windows.Forms.DataGridView();
            this.btSort = new System.Windows.Forms.Button();
            this.cbbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbMo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1065, 146);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::btlQLnhaHang.Properties.Resources.tải_xuống__6__removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(856, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::btlQLnhaHang.Properties.Resources.grow_up_removebg_preview;
            this.pictureBox5.Location = new System.Drawing.Point(108, 36);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 62);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SVN-Genica Pro", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(446, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 44);
            this.label6.TabIndex = 16;
            this.label6.Text = "THỐNG KÊ\n";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.cbbNV);
            this.panel2.Controls.Add(this.rbem);
            this.panel2.Controls.Add(this.cbbHD);
            this.panel2.Controls.Add(this.cbbM);
            this.panel2.Controls.Add(this.rbse);
            this.panel2.Controls.Add(this.lblBillTotal);
            this.panel2.Controls.Add(this.rbbill);
            this.panel2.Location = new System.Drawing.Point(1, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 511);
            this.panel2.TabIndex = 1;
            // 
            // cbbNV
            // 
            this.cbbNV.FormattingEnabled = true;
            this.cbbNV.Items.AddRange(new object[] {
            "Tổng lương",
            "Điểm danh"});
            this.cbbNV.Location = new System.Drawing.Point(42, 343);
            this.cbbNV.Name = "cbbNV";
            this.cbbNV.Size = new System.Drawing.Size(121, 24);
            this.cbbNV.TabIndex = 2;
            // 
            // rbem
            // 
            this.rbem.AutoSize = true;
            this.rbem.Font = new System.Drawing.Font("SVN-Avo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbem.Location = new System.Drawing.Point(42, 305);
            this.rbem.Name = "rbem";
            this.rbem.Size = new System.Drawing.Size(120, 32);
            this.rbem.TabIndex = 1;
            this.rbem.TabStop = true;
            this.rbem.Text = "Nhân viên";
            this.rbem.UseVisualStyleBackColor = true;
            this.rbem.CheckedChanged += new System.EventHandler(this.rbem_CheckedChanged);
            // 
            // cbbHD
            // 
            this.cbbHD.FormattingEnabled = true;
            this.cbbHD.Items.AddRange(new object[] {
            "Tổng hóa đơn bán",
            "Tổng hóa đơn nhập",
            "Tổng hóa đơn trong ngày"});
            this.cbbHD.Location = new System.Drawing.Point(40, 134);
            this.cbbHD.Name = "cbbHD";
            this.cbbHD.Size = new System.Drawing.Size(121, 24);
            this.cbbHD.TabIndex = 2;
            this.cbbHD.SelectedIndexChanged += new System.EventHandler(this.cbbHD_SelectedIndexChanged);
            // 
            // cbbM
            // 
            this.cbbM.FormattingEnabled = true;
            this.cbbM.Items.AddRange(new object[] {
            "Số lượng đã bán"});
            this.cbbM.Location = new System.Drawing.Point(42, 236);
            this.cbbM.Name = "cbbM";
            this.cbbM.Size = new System.Drawing.Size(121, 24);
            this.cbbM.TabIndex = 2;
            // 
            // rbse
            // 
            this.rbse.AutoSize = true;
            this.rbse.Font = new System.Drawing.Font("SVN-Avo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbse.Location = new System.Drawing.Point(42, 197);
            this.rbse.Name = "rbse";
            this.rbse.Size = new System.Drawing.Size(75, 32);
            this.rbse.TabIndex = 1;
            this.rbse.TabStop = true;
            this.rbse.Text = "Món ";
            this.rbse.UseVisualStyleBackColor = true;
            this.rbse.CheckedChanged += new System.EventHandler(this.rbse_CheckedChanged);
            // 
            // lblBillTotal
            // 
            this.lblBillTotal.AutoSize = true;
            this.lblBillTotal.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillTotal.ForeColor = System.Drawing.Color.Brown;
            this.lblBillTotal.Location = new System.Drawing.Point(9, 38);
            this.lblBillTotal.Name = "lblBillTotal";
            this.lblBillTotal.Size = new System.Drawing.Size(167, 29);
            this.lblBillTotal.TabIndex = 11;
            this.lblBillTotal.Text = "Thống kê theo";
            this.lblBillTotal.Click += new System.EventHandler(this.lbl1_Click);
            // 
            // rbbill
            // 
            this.rbbill.AutoSize = true;
            this.rbbill.Font = new System.Drawing.Font("SVN-Avo", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbbill.Location = new System.Drawing.Point(42, 96);
            this.rbbill.Name = "rbbill";
            this.rbbill.Size = new System.Drawing.Size(107, 32);
            this.rbbill.TabIndex = 0;
            this.rbbill.TabStop = true;
            this.rbbill.Text = "Hóa đơn";
            this.rbbill.UseVisualStyleBackColor = true;
            this.rbbill.CheckedChanged += new System.EventHandler(this.rbbill_CheckedChanged);
            // 
            // rbIn
            // 
            this.rbIn.AutoSize = true;
            this.rbIn.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIn.Location = new System.Drawing.Point(728, 211);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(103, 27);
            this.rbIn.TabIndex = 3;
            this.rbIn.Text = "Tăng dần";
            this.rbIn.UseVisualStyleBackColor = true;
            // 
            // rbDe
            // 
            this.rbDe.AutoSize = true;
            this.rbDe.Checked = true;
            this.rbDe.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDe.Location = new System.Drawing.Point(848, 213);
            this.rbDe.Name = "rbDe";
            this.rbDe.Size = new System.Drawing.Size(107, 27);
            this.rbDe.TabIndex = 4;
            this.rbDe.TabStop = true;
            this.rbDe.Text = "Giảm dần";
            this.rbDe.UseVisualStyleBackColor = true;
            // 
            // dgvSort
            // 
            this.dgvSort.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSort.Location = new System.Drawing.Point(240, 323);
            this.dgvSort.Name = "dgvSort";
            this.dgvSort.Size = new System.Drawing.Size(781, 255);
            this.dgvSort.TabIndex = 5;
            this.dgvSort.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSort_CellClick);
            // 
            // btSort
            // 
            this.btSort.BackColor = System.Drawing.Color.LimeGreen;
            this.btSort.Location = new System.Drawing.Point(408, 273);
            this.btSort.Name = "btSort";
            this.btSort.Size = new System.Drawing.Size(141, 36);
            this.btSort.TabIndex = 9;
            this.btSort.Text = "Hiển thị";
            this.btSort.UseVisualStyleBackColor = false;
            this.btSort.Click += new System.EventHandler(this.btSort_Click);
            // 
            // cbbYear
            // 
            this.cbbYear.FormattingEnabled = true;
            this.cbbYear.Items.AddRange(new object[] {
            "2023",
            "2022",
            "Tất cả"});
            this.cbbYear.Location = new System.Drawing.Point(520, 210);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(76, 24);
            this.cbbYear.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 214);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Năm";
            // 
            // cbbMo
            // 
            this.cbbMo.FormattingEnabled = true;
            this.cbbMo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "Tất cả"});
            this.cbbMo.Location = new System.Drawing.Point(347, 211);
            this.cbbMo.Name = "cbbMo";
            this.cbbMo.Size = new System.Drawing.Size(76, 24);
            this.cbbMo.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 213);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tháng";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(650, 599);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(66, 25);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Tổng ";
            this.lblTotal.Click += new System.EventHandler(this.lbl1_Click);
            // 
            // lblTotalVal
            // 
            this.lblTotalVal.AutoSize = true;
            this.lblTotalVal.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVal.ForeColor = System.Drawing.Color.Red;
            this.lblTotalVal.Location = new System.Drawing.Point(806, 599);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(64, 25);
            this.lblTotalVal.TabIndex = 11;
            this.lblTotalVal.Text = "Value";
            this.lblTotalVal.Click += new System.EventHandler(this.lbl1_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.LimeGreen;
            this.btExit.Location = new System.Drawing.Point(811, 273);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(141, 36);
            this.btExit.TabIndex = 9;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.Location = new System.Drawing.Point(604, 274);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(121, 35);
            this.btnExport.TabIndex = 82;
            this.btnExport.Text = "Xuất file Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // GUI_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 654);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cbbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbMo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSort);
            this.Controls.Add(this.lblTotalVal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvSort);
            this.Controls.Add(this.rbDe);
            this.Controls.Add(this.rbIn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GUI_ThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sapxep";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbse;
        private System.Windows.Forms.RadioButton rbbill;
        private System.Windows.Forms.RadioButton rbIn;
        private System.Windows.Forms.RadioButton rbDe;
        private System.Windows.Forms.DataGridView dgvSort;
        private System.Windows.Forms.Button btSort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbMo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBillTotal;
        private System.Windows.Forms.ComboBox cbbNV;
        private System.Windows.Forms.RadioButton rbem;
        private System.Windows.Forms.ComboBox cbbHD;
        private System.Windows.Forms.ComboBox cbbM;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btnExport;
    }
}