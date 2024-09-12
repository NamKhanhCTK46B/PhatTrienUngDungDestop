namespace BaiTap3
{
    partial class frmChinh
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
            this.btnBai1 = new System.Windows.Forms.Button();
            this.btnBai2 = new System.Windows.Forms.Button();
            this.btnBai3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBai1
            // 
            this.btnBai1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBai1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBai1.FlatAppearance.BorderSize = 2;
            this.btnBai1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnBai1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnBai1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBai1.Location = new System.Drawing.Point(76, 105);
            this.btnBai1.Name = "btnBai1";
            this.btnBai1.Size = new System.Drawing.Size(107, 53);
            this.btnBai1.TabIndex = 0;
            this.btnBai1.Text = "Bài 1";
            this.btnBai1.UseVisualStyleBackColor = false;
            this.btnBai1.Click += new System.EventHandler(this.btnBai1_Click);
            // 
            // btnBai2
            // 
            this.btnBai2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBai2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBai2.FlatAppearance.BorderSize = 2;
            this.btnBai2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnBai2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnBai2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBai2.Location = new System.Drawing.Point(231, 105);
            this.btnBai2.Name = "btnBai2";
            this.btnBai2.Size = new System.Drawing.Size(107, 53);
            this.btnBai2.TabIndex = 0;
            this.btnBai2.Text = "Bài 2";
            this.btnBai2.UseVisualStyleBackColor = false;
            this.btnBai2.Click += new System.EventHandler(this.btnBai2_Click);
            // 
            // btnBai3
            // 
            this.btnBai3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBai3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBai3.FlatAppearance.BorderSize = 2;
            this.btnBai3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnBai3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnBai3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBai3.Location = new System.Drawing.Point(382, 105);
            this.btnBai3.Name = "btnBai3";
            this.btnBai3.Size = new System.Drawing.Size(107, 53);
            this.btnBai3.TabIndex = 0;
            this.btnBai3.Text = "Bài 3";
            this.btnBai3.UseVisualStyleBackColor = false;
            this.btnBai3.Click += new System.EventHandler(this.btnBai3_Click);
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(575, 245);
            this.Controls.Add(this.btnBai3);
            this.Controls.Add(this.btnBai2);
            this.Controls.Add(this.btnBai1);
            this.Name = "frmChinh";
            this.Text = "Chương trình chính";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBai1;
        private System.Windows.Forms.Button btnBai2;
        private System.Windows.Forms.Button btnBai3;
    }
}

