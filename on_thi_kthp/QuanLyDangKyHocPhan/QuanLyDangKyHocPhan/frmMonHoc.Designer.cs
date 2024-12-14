namespace QuanLyDangKyHocPhan
{
    partial class frmMonHoc
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
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCTDT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSoTC = new System.Windows.Forms.NumericUpDown();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã môn học";
            // 
            // txtMaMH
            // 
            this.txtMaMH.Location = new System.Drawing.Point(168, 43);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.ReadOnly = true;
            this.txtMaMH.Size = new System.Drawing.Size(239, 22);
            this.txtMaMH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên môn học";
            // 
            // txtTenMH
            // 
            this.txtTenMH.Location = new System.Drawing.Point(168, 95);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(239, 22);
            this.txtTenMH.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chương trình ĐT";
            // 
            // cboCTDT
            // 
            this.cboCTDT.FormattingEnabled = true;
            this.cboCTDT.Location = new System.Drawing.Point(168, 150);
            this.cboCTDT.Name = "cboCTDT";
            this.cboCTDT.Size = new System.Drawing.Size(239, 24);
            this.cboCTDT.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số tín chỉ";
            // 
            // nudSoTC
            // 
            this.nudSoTC.Location = new System.Drawing.Point(168, 204);
            this.nudSoTC.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudSoTC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoTC.Name = "nudSoTC";
            this.nudSoTC.Size = new System.Drawing.Size(239, 22);
            this.nudSoTC.TabIndex = 3;
            this.nudSoTC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(209, 265);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(86, 31);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 332);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.nudSoTC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCTDT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaMH);
            this.Controls.Add(this.label1);
            this.Name = "frmMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Môn học";
            this.Load += new System.EventHandler(this.frmMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCTDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSoTC;
        private System.Windows.Forms.Button btnLuu;
    }
}

