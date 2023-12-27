namespace BTL_HSK.GUI
{
    partial class FormThongKeDoanhThu
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
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.rptThongKeDoanhThu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpNgay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 70);
            this.panel1.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(548, 26);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(102, 24);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(398, 26);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(132, 24);
            this.dtpNgay.TabIndex = 0;
            // 
            // rptThongKeDoanhThu
            // 
            this.rptThongKeDoanhThu.ActiveViewIndex = -1;
            this.rptThongKeDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptThongKeDoanhThu.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptThongKeDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptThongKeDoanhThu.Location = new System.Drawing.Point(0, 70);
            this.rptThongKeDoanhThu.Name = "rptThongKeDoanhThu";
            this.rptThongKeDoanhThu.Size = new System.Drawing.Size(1129, 473);
            this.rptThongKeDoanhThu.TabIndex = 1;
            // 
            // FormThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 543);
            this.Controls.Add(this.rptThongKeDoanhThu);
            this.Controls.Add(this.panel1);
            this.Name = "FormThongKeDoanhThu";
            this.Text = "FormThongKeDoanhThu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptThongKeDoanhThu;
    }
}