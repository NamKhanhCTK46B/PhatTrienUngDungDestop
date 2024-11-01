namespace Lab7_Advanced_Command
{
    partial class OrdersForm
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
            this.dtpBeginDay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDay = new System.Windows.Forms.DateTimePicker();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToTalCost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDiscountCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.btnLoadBills = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // dtpBeginDay
            // 
            this.dtpBeginDay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeginDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeginDay.Location = new System.Drawing.Point(139, 34);
            this.dtpBeginDay.Name = "dtpBeginDay";
            this.dtpBeginDay.Size = new System.Drawing.Size(173, 30);
            this.dtpBeginDay.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(383, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày kết thúc";
            // 
            // dtpEndDay
            // 
            this.dtpEndDay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDay.Location = new System.Drawing.Point(506, 34);
            this.dtpEndDay.Name = "dtpEndDay";
            this.dtpEndDay.Size = new System.Drawing.Size(173, 30);
            this.dtpEndDay.TabIndex = 1;
            // 
            // dgvView
            // 
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(24, 96);
            this.dgvView.Name = "dgvView";
            this.dgvView.RowHeadersWidth = 51;
            this.dgvView.RowTemplate.Height = 24;
            this.dgvView.Size = new System.Drawing.Size(892, 263);
            this.dgvView.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng số tiền chưa giảm giá";
            // 
            // lblToTalCost
            // 
            this.lblToTalCost.AutoSize = true;
            this.lblToTalCost.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToTalCost.Location = new System.Drawing.Point(254, 388);
            this.lblToTalCost.Name = "lblToTalCost";
            this.lblToTalCost.Size = new System.Drawing.Size(25, 22);
            this.lblToTalCost.TabIndex = 0;
            this.lblToTalCost.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tổng số tiền giảm giá";
            // 
            // lblDiscountCost
            // 
            this.lblDiscountCost.AutoSize = true;
            this.lblDiscountCost.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountCost.Location = new System.Drawing.Point(535, 388);
            this.lblDiscountCost.Name = "lblDiscountCost";
            this.lblDiscountCost.Size = new System.Drawing.Size(25, 22);
            this.lblDiscountCost.TabIndex = 0;
            this.lblDiscountCost.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(134, 442);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thực thu doanh thu";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(361, 442);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(30, 25);
            this.lblCost.TabIndex = 0;
            this.lblCost.Text = "...";
            // 
            // btnLoadBills
            // 
            this.btnLoadBills.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBills.Location = new System.Drawing.Point(756, 34);
            this.btnLoadBills.Name = "btnLoadBills";
            this.btnLoadBills.Size = new System.Drawing.Size(160, 35);
            this.btnLoadBills.TabIndex = 3;
            this.btnLoadBills.Text = "Tải danh sách";
            this.btnLoadBills.UseVisualStyleBackColor = true;
            this.btnLoadBills.Click += new System.EventHandler(this.btnLoadBills_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 529);
            this.Controls.Add(this.btnLoadBills);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.dtpEndDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBeginDay);
            this.Controls.Add(this.lblDiscountCost);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblToTalCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "OrdersForm";
            this.Text = "OrdersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBeginDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDay;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToTalCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDiscountCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Button btnLoadBills;
    }
}