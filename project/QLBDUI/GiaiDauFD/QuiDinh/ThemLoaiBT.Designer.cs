namespace QLBDUI.GiaiDauFD.QuiDinh
{
    partial class ThemLoaiBT
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddButt = new System.Windows.Forms.Button();
            this.CancelButt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ThemLBTLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddButt);
            this.panel1.Controls.Add(this.CancelButt);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.ThemLBTLabel);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 178);
            this.panel1.TabIndex = 0;
            // 
            // AddButt
            // 
            this.AddButt.Location = new System.Drawing.Point(265, 105);
            this.AddButt.Name = "AddButt";
            this.AddButt.Size = new System.Drawing.Size(102, 44);
            this.AddButt.TabIndex = 2;
            this.AddButt.Text = "Thêm";
            this.AddButt.UseVisualStyleBackColor = true;
            this.AddButt.Click += new System.EventHandler(this.AddButt_Click);
            // 
            // CancelButt
            // 
            this.CancelButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButt.Location = new System.Drawing.Point(93, 105);
            this.CancelButt.Name = "CancelButt";
            this.CancelButt.Size = new System.Drawing.Size(102, 43);
            this.CancelButt.TabIndex = 2;
            this.CancelButt.Text = "Hủy";
            this.CancelButt.UseVisualStyleBackColor = true;
            this.CancelButt.Click += new System.EventHandler(this.CancelButt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(200, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 27);
            this.textBox1.TabIndex = 1;
            // 
            // ThemLBTLabel
            // 
            this.ThemLBTLabel.AutoSize = true;
            this.ThemLBTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThemLBTLabel.Location = new System.Drawing.Point(21, 36);
            this.ThemLBTLabel.Name = "ThemLBTLabel";
            this.ThemLBTLabel.Size = new System.Drawing.Size(151, 20);
            this.ThemLBTLabel.TabIndex = 0;
            this.ThemLBTLabel.Text = "Loại bàn thắng mới";
            // 
            // ThemLoaiBT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 183);
            this.Controls.Add(this.panel1);
            this.Name = "ThemLoaiBT";
            this.Text = "ThemLoaiBT";
            this.Load += new System.EventHandler(this.ThemLoaiBT_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddButt;
        private System.Windows.Forms.Button CancelButt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ThemLBTLabel;
    }
}