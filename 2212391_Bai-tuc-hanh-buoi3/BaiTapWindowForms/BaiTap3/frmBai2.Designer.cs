namespace BaiTap3
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
            this.txtSoN = new System.Windows.Forms.TextBox();
            this.btnKetQua = new System.Windows.Forms.Button();
            this.rbTong = new System.Windows.Forms.RadioButton();
            this.gbCongViec = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.gbCongViec.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập một số nguyên dương N";
            // 
            // txtSoN
            // 
            this.txtSoN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoN.Location = new System.Drawing.Point(317, 59);
            this.txtSoN.Name = "txtSoN";
            this.txtSoN.Size = new System.Drawing.Size(175, 27);
            this.txtSoN.TabIndex = 1;
            // 
            // btnKetQua
            // 
            this.btnKetQua.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnKetQua.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btnKetQua.FlatAppearance.BorderSize = 2;
            this.btnKetQua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnKetQua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnKetQua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetQua.Location = new System.Drawing.Point(264, 276);
            this.btnKetQua.Name = "btnKetQua";
            this.btnKetQua.Size = new System.Drawing.Size(149, 42);
            this.btnKetQua.TabIndex = 2;
            this.btnKetQua.Text = "Xem kết quả";
            this.btnKetQua.UseVisualStyleBackColor = false;
            this.btnKetQua.Click += new System.EventHandler(this.btnKetQua_Click);
            // 
            // rbTong
            // 
            this.rbTong.AutoSize = true;
            this.rbTong.Checked = true;
            this.rbTong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTong.Location = new System.Drawing.Point(32, 41);
            this.rbTong.Name = "rbTong";
            this.rbTong.Size = new System.Drawing.Size(189, 23);
            this.rbTong.TabIndex = 3;
            this.rbTong.TabStop = true;
            this.rbTong.Text = "Tính tổng 1+2+3+...+N";
            this.rbTong.UseVisualStyleBackColor = true;
            // 
            // gbCongViec
            // 
            this.gbCongViec.Controls.Add(this.radioButton1);
            this.gbCongViec.Controls.Add(this.rbTong);
            this.gbCongViec.Location = new System.Drawing.Point(210, 120);
            this.gbCongViec.Name = "gbCongViec";
            this.gbCongViec.Size = new System.Drawing.Size(258, 132);
            this.gbCongViec.TabIndex = 4;
            this.gbCongViec.TabStop = false;
            this.gbCongViec.Text = "Chọn công việc";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(32, 86);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(171, 23);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tính N giai thừa (N!)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kết quả là: ";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(312, 362);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(23, 26);
            this.lblKetQua.TabIndex = 0;
            this.lblKetQua.Text = "0";
            // 
            // frmBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 444);
            this.Controls.Add(this.gbCongViec);
            this.Controls.Add(this.btnKetQua);
            this.Controls.Add(this.txtSoN);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBai2";
            this.Text = "frmBai2";
            this.gbCongViec.ResumeLayout(false);
            this.gbCongViec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoN;
        private System.Windows.Forms.Button btnKetQua;
        private System.Windows.Forms.RadioButton rbTong;
        private System.Windows.Forms.GroupBox gbCongViec;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKetQua;
    }
}