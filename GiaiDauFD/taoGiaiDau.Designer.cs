namespace QLBDUI.GiaiDauFD
{
    partial class taoGiaiDau
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resetLichBanTCbox = new System.Windows.Forms.CheckBox();
            this.resetDBCbox = new System.Windows.Forms.CheckBox();
            this.okButt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Backbutt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resetLichBanTCbox);
            this.groupBox1.Controls.Add(this.resetDBCbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(400, 179);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn thông tin khởi tạo lại";
            // 
            // resetLichBanTCbox
            // 
            this.resetLichBanTCbox.AutoSize = true;
            this.resetLichBanTCbox.Location = new System.Drawing.Point(37, 110);
            this.resetLichBanTCbox.Margin = new System.Windows.Forms.Padding(2);
            this.resetLichBanTCbox.Name = "resetLichBanTCbox";
            this.resetLichBanTCbox.Size = new System.Drawing.Size(182, 21);
            this.resetLichBanTCbox.TabIndex = 1;
            this.resetLichBanTCbox.Text = " Lịch thi đấu - Bàn thắng";
            this.resetLichBanTCbox.UseVisualStyleBackColor = true;
            // 
            // resetDBCbox
            // 
            this.resetDBCbox.AutoSize = true;
            this.resetDBCbox.Location = new System.Drawing.Point(37, 53);
            this.resetDBCbox.Margin = new System.Windows.Forms.Padding(2);
            this.resetDBCbox.Name = "resetDBCbox";
            this.resetDBCbox.Size = new System.Drawing.Size(154, 21);
            this.resetDBCbox.TabIndex = 0;
            this.resetDBCbox.Text = "Danh sách đội bóng";
            this.resetDBCbox.UseVisualStyleBackColor = true;
            this.resetDBCbox.CheckedChanged += new System.EventHandler(this.ResetDBCbox_CheckedChanged);
            // 
            // okButt
            // 
            this.okButt.Location = new System.Drawing.Point(354, 263);
            this.okButt.Margin = new System.Windows.Forms.Padding(2);
            this.okButt.Name = "okButt";
            this.okButt.Size = new System.Drawing.Size(82, 37);
            this.okButt.TabIndex = 2;
            this.okButt.Text = "Đồng ý";
            this.okButt.UseVisualStyleBackColor = true;
            this.okButt.Click += new System.EventHandler(this.OkButt_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Backbutt);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 315);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tạo giải đấu mới";
            // 
            // Backbutt
            // 
            this.Backbutt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backbutt.Location = new System.Drawing.Point(35, 262);
            this.Backbutt.Margin = new System.Windows.Forms.Padding(2);
            this.Backbutt.Name = "Backbutt";
            this.Backbutt.Size = new System.Drawing.Size(78, 39);
            this.Backbutt.TabIndex = 2;
            this.Backbutt.Text = "Trở về";
            this.Backbutt.UseVisualStyleBackColor = true;
            this.Backbutt.Click += new System.EventHandler(this.Backbutt_Click);
            // 
            // taoGiaiDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 318);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "taoGiaiDau";
            this.Text = "taoGiaiDau";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButt;
        private System.Windows.Forms.CheckBox resetLichBanTCbox;
        private System.Windows.Forms.CheckBox resetDBCbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Backbutt;
        private System.Windows.Forms.Label label1;
    }
}