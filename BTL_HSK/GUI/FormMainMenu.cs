using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK.GUI
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void quảnLýBácSĩToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBacSi fBacSi = new FormBacSi();
            fBacSi.Show();
        }

        private void quảnLýBệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBenhNhan fBenhNhan = new FormBenhNhan();
            fBenhNhan.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien fNhanVien = new FormNhanVien();
            fNhanVien.Show();
        }

        private void lậpPhiếuKhámToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhieuKham fPhieuKham = new FormPhieuKham();
            fPhieuKham.Show();
        }

        private void quảnLýDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDichVu fDichVu = new FormDichVu();
            fDichVu.Show();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void thôngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongKeDoanhThu fThongKe = new FormThongKeDoanhThu();
            fThongKe.Show();
        }
    }
}
