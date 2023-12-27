namespace BTL_HSK.GUI
{
    partial class FormXuatHoaDon
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
            this.rptHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptHoaDon
            // 
            this.rptHoaDon.ActiveViewIndex = -1;
            this.rptHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rptHoaDon.Name = "rptHoaDon";
            this.rptHoaDon.Size = new System.Drawing.Size(939, 528);
            this.rptHoaDon.TabIndex = 0;
            // 
            // FormXuatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 528);
            this.Controls.Add(this.rptHoaDon);
            this.Name = "FormXuatHoaDon";
            this.Text = "FormXuatHoaDon";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptHoaDon;
    }
}