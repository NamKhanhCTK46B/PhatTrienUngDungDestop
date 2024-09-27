namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btnDocFileJson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDocFileJson
            // 
            this.btnDocFileJson.Location = new System.Drawing.Point(126, 70);
            this.btnDocFileJson.Name = "btnDocFileJson";
            this.btnDocFileJson.Size = new System.Drawing.Size(112, 61);
            this.btnDocFileJson.TabIndex = 0;
            this.btnDocFileJson.Text = "Đọc file Json";
            this.btnDocFileJson.UseVisualStyleBackColor = true;
            this.btnDocFileJson.Click += new System.EventHandler(this.btnDocFileJson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDocFileJson);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDocFileJson;
    }
}

