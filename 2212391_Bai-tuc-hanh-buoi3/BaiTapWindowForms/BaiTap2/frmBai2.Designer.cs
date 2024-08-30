namespace BaiTap2
{
    partial class frmBai2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoThuNhat = new System.Windows.Forms.TextBox();
            this.txtSoThuHai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPhepToan = new System.Windows.Forms.GroupBox();
            this.rbCong = new System.Windows.Forms.RadioButton();
            this.rbTru = new System.Windows.Forms.RadioButton();
            this.rbNhan = new System.Windows.Forms.RadioButton();
            this.rbChia = new System.Windows.Forms.RadioButton();
            this.btnKetQua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.gbPhepToan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số thứ nhất";
            // 
            // txtSoThuNhat
            // 
            this.txtSoThuNhat.Location = new System.Drawing.Point(177, 71);
            this.txtSoThuNhat.Name = "txtSoThuNhat";
            this.txtSoThuNhat.Size = new System.Drawing.Size(176, 26);
            this.txtSoThuNhat.TabIndex = 1;
            this.txtSoThuNhat.Text = "0";
            // 
            // txtSoThuHai
            // 
            this.txtSoThuHai.Location = new System.Drawing.Point(177, 131);
            this.txtSoThuHai.Name = "txtSoThuHai";
            this.txtSoThuHai.Size = new System.Drawing.Size(176, 26);
            this.txtSoThuHai.TabIndex = 3;
            this.txtSoThuHai.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số thứ hai";
            // 
            // gbPhepToan
            // 
            this.gbPhepToan.Controls.Add(this.rbChia);
            this.gbPhepToan.Controls.Add(this.rbNhan);
            this.gbPhepToan.Controls.Add(this.rbTru);
            this.gbPhepToan.Controls.Add(this.rbCong);
            this.gbPhepToan.Location = new System.Drawing.Point(177, 203);
            this.gbPhepToan.Name = "gbPhepToan";
            this.gbPhepToan.Size = new System.Drawing.Size(205, 232);
            this.gbPhepToan.TabIndex = 4;
            this.gbPhepToan.TabStop = false;
            this.gbPhepToan.Text = "Chọn phép toán";
            // 
            // rbCong
            // 
            this.rbCong.AutoSize = true;
            this.rbCong.Location = new System.Drawing.Point(32, 41);
            this.rbCong.Name = "rbCong";
            this.rbCong.Size = new System.Drawing.Size(72, 24);
            this.rbCong.TabIndex = 0;
            this.rbCong.Text = "Cộng";
            this.rbCong.UseVisualStyleBackColor = true;
            // 
            // rbTru
            // 
            this.rbTru.AutoSize = true;
            this.rbTru.Checked = true;
            this.rbTru.Location = new System.Drawing.Point(32, 83);
            this.rbTru.Name = "rbTru";
            this.rbTru.Size = new System.Drawing.Size(57, 24);
            this.rbTru.TabIndex = 0;
            this.rbTru.Text = "Trừ";
            this.rbTru.UseVisualStyleBackColor = true;
            // 
            // rbNhan
            // 
            this.rbNhan.AutoSize = true;
            this.rbNhan.Location = new System.Drawing.Point(32, 129);
            this.rbNhan.Name = "rbNhan";
            this.rbNhan.Size = new System.Drawing.Size(72, 24);
            this.rbNhan.TabIndex = 0;
            this.rbNhan.Text = "Nhân";
            this.rbNhan.UseVisualStyleBackColor = true;
            // 
            // rbChia
            // 
            this.rbChia.AutoSize = true;
            this.rbChia.Location = new System.Drawing.Point(32, 174);
            this.rbChia.Name = "rbChia";
            this.rbChia.Size = new System.Drawing.Size(70, 24);
            this.rbChia.TabIndex = 0;
            this.rbChia.Text = "Chia ";
            this.rbChia.UseVisualStyleBackColor = true;
            // 
            // btnKetQua
            // 
            this.btnKetQua.Location = new System.Drawing.Point(209, 463);
            this.btnKetQua.Name = "btnKetQua";
            this.btnKetQua.Size = new System.Drawing.Size(128, 46);
            this.btnKetQua.TabIndex = 5;
            this.btnKetQua.Text = "Xem kết quả";
            this.btnKetQua.UseVisualStyleBackColor = true;
            this.btnKetQua.Click += new System.EventHandler(this.btnKetQua_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kết quả là: ";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(355, 539);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKetQua.Size = new System.Drawing.Size(27, 29);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "0";
            // 
            // frmBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 613);
            this.Controls.Add(this.btnKetQua);
            this.Controls.Add(this.gbPhepToan);
            this.Controls.Add(this.txtSoThuHai);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoThuNhat);
            this.Controls.Add(this.label1);
            this.Name = "frmBai2";
            this.Text = "Bài 2";
            this.gbPhepToan.ResumeLayout(false);
            this.gbPhepToan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoThuNhat;
        private System.Windows.Forms.TextBox txtSoThuHai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPhepToan;
        private System.Windows.Forms.RadioButton rbTru;
        private System.Windows.Forms.RadioButton rbCong;
        private System.Windows.Forms.RadioButton rbChia;
        private System.Windows.Forms.RadioButton rbNhan;
        private System.Windows.Forms.Button btnKetQua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKetQua;
    }
}