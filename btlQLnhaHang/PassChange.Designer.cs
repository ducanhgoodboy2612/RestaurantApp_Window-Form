
namespace btlQLnhaHang
{
    partial class PassChange
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCur = new System.Windows.Forms.TextBox();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.txtche = new System.Windows.Forms.TextBox();
            this.btAcc = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btRe = new System.Windows.Forms.Button();
            this.ckbShow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::btlQLnhaHang.Properties.Resources.reset_password;
            this.pictureBox1.Location = new System.Drawing.Point(158, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SVN-Bango", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(92, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu hiện tại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu mớii";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Xác nhận lại\r\n";
            // 
            // txtCur
            // 
            this.txtCur.Location = new System.Drawing.Point(223, 231);
            this.txtCur.Name = "txtCur";
            this.txtCur.PasswordChar = '*';
            this.txtCur.Size = new System.Drawing.Size(208, 22);
            this.txtCur.TabIndex = 6;
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(223, 283);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '*';
            this.txtNew.Size = new System.Drawing.Size(208, 22);
            this.txtNew.TabIndex = 7;
            // 
            // txtche
            // 
            this.txtche.Location = new System.Drawing.Point(223, 334);
            this.txtche.Name = "txtche";
            this.txtche.PasswordChar = '*';
            this.txtche.Size = new System.Drawing.Size(208, 22);
            this.txtche.TabIndex = 8;
            // 
            // btAcc
            // 
            this.btAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btAcc.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAcc.ForeColor = System.Drawing.Color.White;
            this.btAcc.Location = new System.Drawing.Point(59, 429);
            this.btAcc.Name = "btAcc";
            this.btAcc.Size = new System.Drawing.Size(115, 36);
            this.btAcc.TabIndex = 10;
            this.btAcc.Text = "Xác nhận";
            this.btAcc.UseVisualStyleBackColor = false;
            this.btAcc.Click += new System.EventHandler(this.btAcc_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.Red;
            this.btExit.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.White;
            this.btExit.Location = new System.Drawing.Point(365, 429);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(66, 36);
            this.btExit.TabIndex = 12;
            this.btExit.Text = "Hủy";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btRe
            // 
            this.btRe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btRe.Font = new System.Drawing.Font("SVN-Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRe.ForeColor = System.Drawing.Color.White;
            this.btRe.Location = new System.Drawing.Point(210, 429);
            this.btRe.Name = "btRe";
            this.btRe.Size = new System.Drawing.Size(115, 36);
            this.btRe.TabIndex = 11;
            this.btRe.Text = "Làm mới";
            this.btRe.UseVisualStyleBackColor = false;
            this.btRe.Click += new System.EventHandler(this.btRe_Click);
            // 
            // ckbShow
            // 
            this.ckbShow.AutoSize = true;
            this.ckbShow.Location = new System.Drawing.Point(273, 383);
            this.ckbShow.Name = "ckbShow";
            this.ckbShow.Size = new System.Drawing.Size(128, 20);
            this.ckbShow.TabIndex = 9;
            this.ckbShow.Text = "Hiển thị mật khẩu";
            this.ckbShow.UseVisualStyleBackColor = true;
            this.ckbShow.CheckedChanged += new System.EventHandler(this.ckbShow_CheckedChanged);
            // 
            // PassChange
            // 
            this.AcceptButton = this.btAcc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 554);
            this.Controls.Add(this.ckbShow);
            this.Controls.Add(this.btRe);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btAcc);
            this.Controls.Add(this.txtche);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtCur);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PassChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PassChange";
            this.Load += new System.EventHandler(this.PassChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCur;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtche;
        private System.Windows.Forms.Button btAcc;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btRe;
        private System.Windows.Forms.CheckBox ckbShow;
    }
}