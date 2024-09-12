namespace QLKhachHang
{
    partial class frmLoaiKH
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
            this.lvLoaiKH = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnMacDinh_LoaiKH = new System.Windows.Forms.Button();
            this.btnSua_LoaiKH = new System.Windows.Forms.Button();
            this.btnXoa_LoaiKH = new System.Windows.Forms.Button();
            this.btnThem_LoaiKH = new System.Windows.Forms.Button();
            this.txtGhiChu_LoaiKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID_LKH = new System.Windows.Forms.TextBox();
            this.txtTenLKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLoaiKH
            // 
            this.lvLoaiKH.CheckBoxes = true;
            this.lvLoaiKH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvLoaiKH.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLoaiKH.GridLines = true;
            this.lvLoaiKH.HideSelection = false;
            this.lvLoaiKH.Location = new System.Drawing.Point(41, 97);
            this.lvLoaiKH.Name = "lvLoaiKH";
            this.lvLoaiKH.Size = new System.Drawing.Size(423, 411);
            this.lvLoaiKH.TabIndex = 280;
            this.lvLoaiKH.UseCompatibleStateImageBehavior = false;
            this.lvLoaiKH.View = System.Windows.Forms.View.Details;
            this.lvLoaiKH.SelectedIndexChanged += new System.EventHandler(this.lvLoaiKH_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Loại";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ghi Chú";
            this.columnHeader3.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 24);
            this.label1.TabIndex = 279;
            this.label1.Text = "DANH SÁCH LOẠI KHÁCH HÀNG";
            // 
            // btnMacDinh_LoaiKH
            // 
            this.btnMacDinh_LoaiKH.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMacDinh_LoaiKH.Location = new System.Drawing.Point(630, 441);
            this.btnMacDinh_LoaiKH.Name = "btnMacDinh_LoaiKH";
            this.btnMacDinh_LoaiKH.Size = new System.Drawing.Size(122, 47);
            this.btnMacDinh_LoaiKH.TabIndex = 5;
            this.btnMacDinh_LoaiKH.Text = "Mặc Định";
            this.btnMacDinh_LoaiKH.UseVisualStyleBackColor = true;
            this.btnMacDinh_LoaiKH.Click += new System.EventHandler(this.btnMacDinh_LoaiKH_Click);
            // 
            // btnSua_LoaiKH
            // 
            this.btnSua_LoaiKH.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua_LoaiKH.Location = new System.Drawing.Point(786, 365);
            this.btnSua_LoaiKH.Name = "btnSua_LoaiKH";
            this.btnSua_LoaiKH.Size = new System.Drawing.Size(98, 47);
            this.btnSua_LoaiKH.TabIndex = 4;
            this.btnSua_LoaiKH.Text = "Sửa";
            this.btnSua_LoaiKH.UseVisualStyleBackColor = true;
            this.btnSua_LoaiKH.Click += new System.EventHandler(this.btnSua_LoaiKH_Click);
            // 
            // btnXoa_LoaiKH
            // 
            this.btnXoa_LoaiKH.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa_LoaiKH.Location = new System.Drawing.Point(498, 365);
            this.btnXoa_LoaiKH.Name = "btnXoa_LoaiKH";
            this.btnXoa_LoaiKH.Size = new System.Drawing.Size(93, 47);
            this.btnXoa_LoaiKH.TabIndex = 289;
            this.btnXoa_LoaiKH.Text = "Xoá";
            this.btnXoa_LoaiKH.UseVisualStyleBackColor = true;
            this.btnXoa_LoaiKH.Click += new System.EventHandler(this.btnXoa_LoaiKH_Click);
            // 
            // btnThem_LoaiKH
            // 
            this.btnThem_LoaiKH.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem_LoaiKH.Location = new System.Drawing.Point(646, 365);
            this.btnThem_LoaiKH.Name = "btnThem_LoaiKH";
            this.btnThem_LoaiKH.Size = new System.Drawing.Size(93, 47);
            this.btnThem_LoaiKH.TabIndex = 3;
            this.btnThem_LoaiKH.Text = "Thêm";
            this.btnThem_LoaiKH.UseVisualStyleBackColor = true;
            this.btnThem_LoaiKH.Click += new System.EventHandler(this.btnThem_LoaiKH_Click);
            // 
            // txtGhiChu_LoaiKH
            // 
            this.txtGhiChu_LoaiKH.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu_LoaiKH.Location = new System.Drawing.Point(682, 224);
            this.txtGhiChu_LoaiKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu_LoaiKH.Multiline = true;
            this.txtGhiChu_LoaiKH.Name = "txtGhiChu_LoaiKH";
            this.txtGhiChu_LoaiKH.Size = new System.Drawing.Size(202, 90);
            this.txtGhiChu_LoaiKH.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(493, 227);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 285;
            this.label3.Text = "Ghi chú";
            // 
            // txtID_LKH
            // 
            this.txtID_LKH.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_LKH.Location = new System.Drawing.Point(682, 132);
            this.txtID_LKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtID_LKH.Name = "txtID_LKH";
            this.txtID_LKH.ReadOnly = true;
            this.txtID_LKH.Size = new System.Drawing.Size(202, 27);
            this.txtID_LKH.TabIndex = 0;
            // 
            // txtTenLKH
            // 
            this.txtTenLKH.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLKH.Location = new System.Drawing.Point(682, 176);
            this.txtTenLKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenLKH.Name = "txtTenLKH";
            this.txtTenLKH.Size = new System.Drawing.Size(202, 27);
            this.txtTenLKH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 282;
            this.label2.Text = "ID Khách hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(494, 179);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 19);
            this.label11.TabIndex = 281;
            this.label11.Text = "Tên loại khách hàng";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 28);
            this.menuStrip1.TabIndex = 291;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýLoạiPhòngToolStripMenuItem,
            this.quảnLýLoạiKháchHàngToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // quảnLýLoạiPhòngToolStripMenuItem
            // 
            this.quảnLýLoạiPhòngToolStripMenuItem.Name = "quảnLýLoạiPhòngToolStripMenuItem";
            this.quảnLýLoạiPhòngToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.quảnLýLoạiPhòngToolStripMenuItem.Text = "Quản lý khách hàng";
            // 
            // quảnLýLoạiKháchHàngToolStripMenuItem
            // 
            this.quảnLýLoạiKháchHàngToolStripMenuItem.Name = "quảnLýLoạiKháchHàngToolStripMenuItem";
            this.quảnLýLoạiKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.quảnLýLoạiKháchHàngToolStripMenuItem.Text = "Quản lý loại khách hàng";
            // 
            // frmLoaiKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 563);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvLoaiKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMacDinh_LoaiKH);
            this.Controls.Add(this.btnSua_LoaiKH);
            this.Controls.Add(this.btnXoa_LoaiKH);
            this.Controls.Add(this.btnThem_LoaiKH);
            this.Controls.Add(this.txtGhiChu_LoaiKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtID_LKH);
            this.Controls.Add(this.txtTenLKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Name = "frmLoaiKH";
            this.Text = "Quản lý loại khách hàng";
            this.Load += new System.EventHandler(this.frmLoaiKH_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLoaiKH;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMacDinh_LoaiKH;
        private System.Windows.Forms.Button btnSua_LoaiKH;
        private System.Windows.Forms.Button btnXoa_LoaiKH;
        private System.Windows.Forms.Button btnThem_LoaiKH;
        private System.Windows.Forms.TextBox txtGhiChu_LoaiKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID_LKH;
        private System.Windows.Forms.TextBox txtTenLKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLoạiPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLoạiKháchHàngToolStripMenuItem;
    }
}