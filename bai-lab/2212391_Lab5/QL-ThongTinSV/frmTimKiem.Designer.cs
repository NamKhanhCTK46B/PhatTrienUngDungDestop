namespace QL_ThongTinSV
{
    partial class frmTimKiem
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
            this.mtxtMSSV_TK = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen_TK = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLop_TK = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mtxtMSSV_TK
            // 
            this.mtxtMSSV_TK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtMSSV_TK.Location = new System.Drawing.Point(167, 50);
            this.mtxtMSSV_TK.Mask = "0000000";
            this.mtxtMSSV_TK.Name = "mtxtMSSV_TK";
            this.mtxtMSSV_TK.Size = new System.Drawing.Size(227, 27);
            this.mtxtMSSV_TK.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "MSSV";
            // 
            // txtTen_TK
            // 
            this.txtTen_TK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen_TK.Location = new System.Drawing.Point(167, 102);
            this.txtTen_TK.Name = "txtTen_TK";
            this.txtTen_TK.Size = new System.Drawing.Size(227, 27);
            this.txtTen_TK.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 50;
            this.label6.Text = "Tên";
            // 
            // cboLop_TK
            // 
            this.cboLop_TK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLop_TK.FormattingEnabled = true;
            this.cboLop_TK.Items.AddRange(new object[] {
            "CTK45",
            "CTK46",
            "CTK47",
            "CTK48"});
            this.cboLop_TK.Location = new System.Drawing.Point(167, 146);
            this.cboLop_TK.Name = "cboLop_TK";
            this.cboLop_TK.Size = new System.Drawing.Size(144, 28);
            this.cboLop_TK.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "Lớp";
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Location = new System.Drawing.Point(106, 221);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(82, 40);
            this.btn_Tim.TabIndex = 58;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Location = new System.Drawing.Point(273, 221);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(82, 40);
            this.btn_Thoat.TabIndex = 58;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 311);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.cboLop_TK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTen_TK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mtxtMSSV_TK);
            this.Controls.Add(this.label2);
            this.Name = "frmTimKiem";
            this.Text = "Tìm kiếm sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtMSSV_TK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen_TK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLop_TK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_Thoat;
    }
}