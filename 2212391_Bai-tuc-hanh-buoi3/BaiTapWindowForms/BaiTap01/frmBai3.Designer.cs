namespace BaiTap01
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoA = new System.Windows.Forms.TextBox();
            this.txtSoB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTongN = new System.Windows.Forms.RadioButton();
            this.rbTongAB = new System.Windows.Forms.RadioButton();
            this.btnXemKQ = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số a =";
            // 
            // txtSoA
            // 
            this.txtSoA.Location = new System.Drawing.Point(178, 67);
            this.txtSoA.Name = "txtSoA";
            this.txtSoA.Size = new System.Drawing.Size(134, 26);
            this.txtSoA.TabIndex = 0;
            this.txtSoA.Text = "0";
            // 
            // txtSoB
            // 
            this.txtSoB.Location = new System.Drawing.Point(178, 128);
            this.txtSoB.Name = "txtSoB";
            this.txtSoB.Size = new System.Drawing.Size(134, 26);
            this.txtSoB.TabIndex = 1;
            this.txtSoB.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số b = ";
            // 
            // txtSoN
            // 
            this.txtSoN.Location = new System.Drawing.Point(178, 189);
            this.txtSoN.Name = "txtSoN";
            this.txtSoN.Size = new System.Drawing.Size(134, 26);
            this.txtSoN.TabIndex = 2;
            this.txtSoN.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số n = ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTongN);
            this.groupBox1.Controls.Add(this.rbTongAB);
            this.groupBox1.Location = new System.Drawing.Point(121, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn phép toán";
            // 
            // rbTongN
            // 
            this.rbTongN.AutoSize = true;
            this.rbTongN.Location = new System.Drawing.Point(37, 95);
            this.rbTongN.Name = "rbTongN";
            this.rbTongN.Size = new System.Drawing.Size(175, 24);
            this.rbTongN.TabIndex = 1;
            this.rbTongN.Text = "Tính tổng từ 1 đến n";
            this.rbTongN.UseVisualStyleBackColor = true;
            // 
            // rbTongAB
            // 
            this.rbTongAB.AutoSize = true;
            this.rbTongAB.Checked = true;
            this.rbTongAB.Location = new System.Drawing.Point(37, 46);
            this.rbTongAB.Name = "rbTongAB";
            this.rbTongAB.Size = new System.Drawing.Size(126, 24);
            this.rbTongAB.TabIndex = 0;
            this.rbTongAB.TabStop = true;
            this.rbTongAB.Text = "Tính tổng a,b";
            this.rbTongAB.UseVisualStyleBackColor = true;
            // 
            // btnXemKQ
            // 
            this.btnXemKQ.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXemKQ.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXemKQ.Location = new System.Drawing.Point(178, 420);
            this.btnXemKQ.Name = "btnXemKQ";
            this.btnXemKQ.Size = new System.Drawing.Size(126, 48);
            this.btnXemKQ.TabIndex = 4;
            this.btnXemKQ.Text = "Xem kết quả";
            this.btnXemKQ.UseVisualStyleBackColor = false;
            this.btnXemKQ.Click += new System.EventHandler(this.btnXemKQ_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kết quả là:";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(254, 495);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(25, 26);
            this.lblKetQua.TabIndex = 8;
            this.lblKetQua.Text = "0";
            // 
            // frmBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 580);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXemKQ);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSoN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoA);
            this.Controls.Add(this.label1);
            this.Name = "frmBai3";
            this.Text = "Bài 3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoA;
        private System.Windows.Forms.TextBox txtSoB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTongN;
        private System.Windows.Forms.RadioButton rbTongAB;
        private System.Windows.Forms.Button btnXemKQ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKetQua;
    }
}