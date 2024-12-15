namespace QuanLyDangKyHocPhan
{
    partial class frmQLMonHoc
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdCT2020 = new System.Windows.Forms.RadioButton();
            this.rdCT2017 = new System.Windows.Forms.RadioButton();
            this.rdCT2015 = new System.Windows.Forms.RadioButton();
            this.rdTatCa = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdMa_Ten = new System.Windows.Forms.RadioButton();
            this.rdSTC = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.MaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXemDSSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTinhSoSVDK = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdCT2020);
            this.groupBox1.Controls.Add(this.rdCT2017);
            this.groupBox1.Controls.Add(this.rdCT2015);
            this.groupBox1.Controls.Add(this.rdTatCa);
            this.groupBox1.Location = new System.Drawing.Point(133, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn chương trình đào tạo";
            // 
            // rdCT2020
            // 
            this.rdCT2020.AutoSize = true;
            this.rdCT2020.Location = new System.Drawing.Point(509, 36);
            this.rdCT2020.Name = "rdCT2020";
            this.rdCT2020.Size = new System.Drawing.Size(56, 20);
            this.rdCT2020.TabIndex = 0;
            this.rdCT2020.Text = "2020";
            this.rdCT2020.UseVisualStyleBackColor = true;
            this.rdCT2020.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // rdCT2017
            // 
            this.rdCT2017.AutoSize = true;
            this.rdCT2017.Location = new System.Drawing.Point(353, 36);
            this.rdCT2017.Name = "rdCT2017";
            this.rdCT2017.Size = new System.Drawing.Size(56, 20);
            this.rdCT2017.TabIndex = 0;
            this.rdCT2017.Text = "2017";
            this.rdCT2017.UseVisualStyleBackColor = true;
            this.rdCT2017.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // rdCT2015
            // 
            this.rdCT2015.AutoSize = true;
            this.rdCT2015.Location = new System.Drawing.Point(207, 36);
            this.rdCT2015.Name = "rdCT2015";
            this.rdCT2015.Size = new System.Drawing.Size(56, 20);
            this.rdCT2015.TabIndex = 0;
            this.rdCT2015.Text = "2015";
            this.rdCT2015.UseVisualStyleBackColor = true;
            this.rdCT2015.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // rdTatCa
            // 
            this.rdTatCa.AutoSize = true;
            this.rdTatCa.Location = new System.Drawing.Point(50, 36);
            this.rdTatCa.Name = "rdTatCa";
            this.rdTatCa.Size = new System.Drawing.Size(66, 20);
            this.rdTatCa.TabIndex = 0;
            this.rdTatCa.Text = "Tất cả";
            this.rdTatCa.UseVisualStyleBackColor = true;
            this.rdTatCa.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.rdMa_Ten);
            this.groupBox2.Controls.Add(this.rdSTC);
            this.groupBox2.Location = new System.Drawing.Point(133, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(344, 34);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(247, 22);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // rdMa_Ten
            // 
            this.rdMa_Ten.AutoSize = true;
            this.rdMa_Ten.Checked = true;
            this.rdMa_Ten.Location = new System.Drawing.Point(31, 35);
            this.rdMa_Ten.Name = "rdMa_Ten";
            this.rdMa_Ten.Size = new System.Drawing.Size(128, 20);
            this.rdMa_Ten.TabIndex = 0;
            this.rdMa_Ten.TabStop = true;
            this.rdMa_Ten.Text = "Theo mã/tên MH";
            this.rdMa_Ten.UseVisualStyleBackColor = true;
            // 
            // rdSTC
            // 
            this.rdSTC.AutoSize = true;
            this.rdSTC.Location = new System.Drawing.Point(198, 35);
            this.rdSTC.Name = "rdSTC";
            this.rdSTC.Size = new System.Drawing.Size(99, 20);
            this.rdSTC.TabIndex = 0;
            this.rdSTC.Text = "Theo số TC";
            this.rdSTC.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Controls.Add(this.dgvMonHoc);
            this.groupBox3.Location = new System.Drawing.Point(55, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 250);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách môn học";
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(783, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(45, 31);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "+";
            this.toolTip1.SetToolTip(this.btnThem, "Thêm môn học");
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMH,
            this.TenMH,
            this.CTDT,
            this.SoTC});
            this.dgvMonHoc.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMonHoc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMonHoc.Location = new System.Drawing.Point(3, 56);
            this.dgvMonHoc.MultiSelect = false;
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersWidth = 51;
            this.dgvMonHoc.RowTemplate.Height = 24;
            this.dgvMonHoc.Size = new System.Drawing.Size(843, 191);
            this.dgvMonHoc.TabIndex = 0;
            this.dgvMonHoc.DoubleClick += new System.EventHandler(this.dgvMonHoc_DoubleClick);
            // 
            // MaMH
            // 
            this.MaMH.DataPropertyName = "MaMH";
            this.MaMH.HeaderText = "Mã môn học";
            this.MaMH.MinimumWidth = 6;
            this.MaMH.Name = "MaMH";
            this.MaMH.ReadOnly = true;
            this.MaMH.Width = 125;
            // 
            // TenMH
            // 
            this.TenMH.DataPropertyName = "TenMH";
            this.TenMH.HeaderText = "Tên môn học";
            this.TenMH.MinimumWidth = 6;
            this.TenMH.Name = "TenMH";
            this.TenMH.ReadOnly = true;
            this.TenMH.Width = 200;
            // 
            // CTDT
            // 
            this.CTDT.DataPropertyName = "TenCTDT";
            this.CTDT.HeaderText = "Chương trình đào tạo";
            this.CTDT.MinimumWidth = 6;
            this.CTDT.Name = "CTDT";
            this.CTDT.ReadOnly = true;
            this.CTDT.Width = 170;
            // 
            // SoTC
            // 
            this.SoTC.DataPropertyName = "SoTC";
            this.SoTC.HeaderText = "Số tín chỉ";
            this.SoTC.MinimumWidth = 6;
            this.SoTC.Name = "SoTC";
            this.SoTC.ReadOnly = true;
            this.SoTC.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXoa,
            this.tsmiXemDSSV,
            this.tsmiTinhSoSVDK});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(358, 104);
            // 
            // tsmiXoa
            // 
            this.tsmiXoa.Name = "tsmiXoa";
            this.tsmiXoa.Size = new System.Drawing.Size(357, 24);
            this.tsmiXoa.Text = "Xoá";
            this.tsmiXoa.Click += new System.EventHandler(this.tsmiXoa_Click);
            // 
            // tsmiXemDSSV
            // 
            this.tsmiXemDSSV.Name = "tsmiXemDSSV";
            this.tsmiXemDSSV.Size = new System.Drawing.Size(357, 24);
            this.tsmiXemDSSV.Text = "Xem danh sách sinh viên đăng ký môn học";
            this.tsmiXemDSSV.Click += new System.EventHandler(this.tsmiXemDSSV_Click);
            // 
            // tsmiTinhSoSVDK
            // 
            this.tsmiTinhSoSVDK.Name = "tsmiTinhSoSVDK";
            this.tsmiTinhSoSVDK.Size = new System.Drawing.Size(357, 24);
            this.tsmiTinhSoSVDK.Text = "Tổng số lượng SV đăng ký MH";
            this.tsmiTinhSoSVDK.Click += new System.EventHandler(this.tsmiTinhSoSVDK_Click);
            // 
            // frmQLMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmQLMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý môn học";
            this.Load += new System.EventHandler(this.frmQLMonHoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdCT2015;
        private System.Windows.Forms.RadioButton rdTatCa;
        private System.Windows.Forms.RadioButton rdCT2020;
        private System.Windows.Forms.RadioButton rdCT2017;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rdMa_Ten;
        private System.Windows.Forms.RadioButton rdSTC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiXoa;
        private System.Windows.Forms.ToolStripMenuItem tsmiXemDSSV;
        private System.Windows.Forms.ToolStripMenuItem tsmiTinhSoSVDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTC;
    }
}