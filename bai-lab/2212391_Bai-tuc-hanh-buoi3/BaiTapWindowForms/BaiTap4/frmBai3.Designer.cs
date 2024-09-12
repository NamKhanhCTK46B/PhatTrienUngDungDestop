namespace BaiTap4
{
    partial class frmBai3
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
            this.gbChaoHoi = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.gbGioiTinh = new System.Windows.Forms.GroupBox();
            this.gbUSCLN = new System.Windows.Forms.GroupBox();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.rbNu = new System.Windows.Forms.RadioButton();
            this.btnChaoHoi = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.txtSoM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTinhToan = new System.Windows.Forms.Button();
            this.txtUSCLN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbChaoHoi.SuspendLayout();
            this.gbGioiTinh.SuspendLayout();
            this.gbUSCLN.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbChaoHoi
            // 
            this.gbChaoHoi.Controls.Add(this.btnChaoHoi);
            this.gbChaoHoi.Controls.Add(this.gbGioiTinh);
            this.gbChaoHoi.Controls.Add(this.txtHoTen);
            this.gbChaoHoi.Controls.Add(this.lblThongBao);
            this.gbChaoHoi.Controls.Add(this.label1);
            this.gbChaoHoi.Location = new System.Drawing.Point(37, 60);
            this.gbChaoHoi.Name = "gbChaoHoi";
            this.gbChaoHoi.Size = new System.Drawing.Size(358, 347);
            this.gbChaoHoi.TabIndex = 0;
            this.gbChaoHoi.TabStop = false;
            this.gbChaoHoi.Text = "Chào hỏi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(124, 45);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(189, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // gbGioiTinh
            // 
            this.gbGioiTinh.Controls.Add(this.rbNu);
            this.gbGioiTinh.Controls.Add(this.rbNam);
            this.gbGioiTinh.Location = new System.Drawing.Point(57, 110);
            this.gbGioiTinh.Name = "gbGioiTinh";
            this.gbGioiTinh.Size = new System.Drawing.Size(246, 81);
            this.gbGioiTinh.TabIndex = 1;
            this.gbGioiTinh.TabStop = false;
            this.gbGioiTinh.Text = "Giới tính";
            // 
            // gbUSCLN
            // 
            this.gbUSCLN.Controls.Add(this.txtUSCLN);
            this.gbUSCLN.Controls.Add(this.label4);
            this.gbUSCLN.Controls.Add(this.btnTinhToan);
            this.gbUSCLN.Controls.Add(this.txtSoN);
            this.gbUSCLN.Controls.Add(this.label3);
            this.gbUSCLN.Controls.Add(this.txtSoM);
            this.gbUSCLN.Controls.Add(this.label2);
            this.gbUSCLN.Location = new System.Drawing.Point(486, 60);
            this.gbUSCLN.Name = "gbUSCLN";
            this.gbUSCLN.Size = new System.Drawing.Size(261, 347);
            this.gbUSCLN.TabIndex = 1;
            this.gbUSCLN.TabStop = false;
            this.gbUSCLN.Text = "Tìm ước số chung lớn nhất";
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Location = new System.Drawing.Point(31, 36);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(57, 20);
            this.rbNam.TabIndex = 0;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Location = new System.Drawing.Point(146, 36);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new System.Drawing.Size(45, 20);
            this.rbNu.TabIndex = 0;
            this.rbNu.TabStop = true;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // btnChaoHoi
            // 
            this.btnChaoHoi.Location = new System.Drawing.Point(105, 216);
            this.btnChaoHoi.Name = "btnChaoHoi";
            this.btnChaoHoi.Size = new System.Drawing.Size(123, 37);
            this.btnChaoHoi.TabIndex = 2;
            this.btnChaoHoi.Text = "Chào hỏi";
            this.btnChaoHoi.UseVisualStyleBackColor = true;
            this.btnChaoHoi.Click += new System.EventHandler(this.btnChaoHoi_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblThongBao.Location = new System.Drawing.Point(64, 279);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(23, 25);
            this.lblThongBao.TabIndex = 0;
            this.lblThongBao.Text = "_";
            // 
            // txtSoM
            // 
            this.txtSoM.Location = new System.Drawing.Point(99, 48);
            this.txtSoM.Name = "txtSoM";
            this.txtSoM.Size = new System.Drawing.Size(143, 22);
            this.txtSoM.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số m";
            // 
            // txtSoN
            // 
            this.txtSoN.Location = new System.Drawing.Point(99, 95);
            this.txtSoN.Name = "txtSoN";
            this.txtSoN.Size = new System.Drawing.Size(143, 22);
            this.txtSoN.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số n";
            // 
            // btnTinhToan
            // 
            this.btnTinhToan.Location = new System.Drawing.Point(70, 154);
            this.btnTinhToan.Name = "btnTinhToan";
            this.btnTinhToan.Size = new System.Drawing.Size(123, 37);
            this.btnTinhToan.TabIndex = 2;
            this.btnTinhToan.Text = "Tính toán";
            this.btnTinhToan.UseVisualStyleBackColor = true;
            this.btnTinhToan.Click += new System.EventHandler(this.btnTinhToan_Click);
            // 
            // txtUSCLN
            // 
            this.txtUSCLN.Location = new System.Drawing.Point(99, 242);
            this.txtUSCLN.Name = "txtUSCLN";
            this.txtUSCLN.ReadOnly = true;
            this.txtUSCLN.Size = new System.Drawing.Size(143, 22);
            this.txtUSCLN.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "USCLN";
            // 
            // frmBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbUSCLN);
            this.Controls.Add(this.gbChaoHoi);
            this.Name = "frmBai3";
            this.Text = "frmBai3";
            this.gbChaoHoi.ResumeLayout(false);
            this.gbChaoHoi.PerformLayout();
            this.gbGioiTinh.ResumeLayout(false);
            this.gbGioiTinh.PerformLayout();
            this.gbUSCLN.ResumeLayout(false);
            this.gbUSCLN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbChaoHoi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbGioiTinh;
        private System.Windows.Forms.RadioButton rbNu;
        private System.Windows.Forms.RadioButton rbNam;
        private System.Windows.Forms.GroupBox gbUSCLN;
        private System.Windows.Forms.Button btnChaoHoi;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.TextBox txtSoN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUSCLN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTinhToan;
    }
}