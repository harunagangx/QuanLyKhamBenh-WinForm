namespace BTL_HSK.GUI
{
    partial class FormMainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýBácSĩToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýBệnhNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýDịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpPhiếuKhámToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýToolStripMenuItem,
            this.lậpPhiếuKhámToolStripMenuItem,
            this.thôngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1147, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýBácSĩToolStripMenuItem,
            this.quảnLýBệnhNhânToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýDịchVụToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // quảnLýBácSĩToolStripMenuItem
            // 
            this.quảnLýBácSĩToolStripMenuItem.Name = "quảnLýBácSĩToolStripMenuItem";
            this.quảnLýBácSĩToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quảnLýBácSĩToolStripMenuItem.Text = "Quản lý bác sĩ";
            this.quảnLýBácSĩToolStripMenuItem.Click += new System.EventHandler(this.quảnLýBácSĩToolStripMenuItem_Click);
            // 
            // quảnLýBệnhNhânToolStripMenuItem
            // 
            this.quảnLýBệnhNhânToolStripMenuItem.Name = "quảnLýBệnhNhânToolStripMenuItem";
            this.quảnLýBệnhNhânToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quảnLýBệnhNhânToolStripMenuItem.Text = "Quản lý bệnh nhân";
            this.quảnLýBệnhNhânToolStripMenuItem.Click += new System.EventHandler(this.quảnLýBệnhNhânToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýDịchVụToolStripMenuItem
            // 
            this.quảnLýDịchVụToolStripMenuItem.Name = "quảnLýDịchVụToolStripMenuItem";
            this.quảnLýDịchVụToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quảnLýDịchVụToolStripMenuItem.Text = "Quản lý dịch vụ";
            this.quảnLýDịchVụToolStripMenuItem.Click += new System.EventHandler(this.quảnLýDịchVụToolStripMenuItem_Click);
            // 
            // lậpPhiếuKhámToolStripMenuItem
            // 
            this.lậpPhiếuKhámToolStripMenuItem.Name = "lậpPhiếuKhámToolStripMenuItem";
            this.lậpPhiếuKhámToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.lậpPhiếuKhámToolStripMenuItem.Text = "Lập phiếu khám";
            this.lậpPhiếuKhámToolStripMenuItem.Click += new System.EventHandler(this.lậpPhiếuKhámToolStripMenuItem_Click);
            // 
            // thôngKêToolStripMenuItem
            // 
            this.thôngKêToolStripMenuItem.Name = "thôngKêToolStripMenuItem";
            this.thôngKêToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.thôngKêToolStripMenuItem.Text = "Thống kê";
            this.thôngKêToolStripMenuItem.Click += new System.EventHandler(this.thôngKêToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 546);
            this.panel1.TabIndex = 1;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainMenu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýBácSĩToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýBệnhNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpPhiếuKhámToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngKêToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýDịchVụToolStripMenuItem;
    }
}