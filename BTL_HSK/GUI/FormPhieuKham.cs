using BTL_HSK.DAO;
using BTL_HSK.DTO;
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
    public partial class FormPhieuKham : Form
    {
        public FormPhieuKham()
        {
            InitializeComponent();

            loadPhieuKhamUnchecked();

            loadBacSi();

            loadBenhNhan();

            loadNhanVien();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        #region Method
        private void loadPhieuKhamUnchecked()
        {
            List<PhieuKham> listPhieuKham = PhieuKhamDAO.Instance.getDataPhieuKhamUnchecked();

            dtgvPhieuKham.DataSource = listPhieuKham;

            dtgvPhieuKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadBacSi()
        {
            List<BacSi> listBacSi = BacSiDAO.Instance.getDataBacSi();

            cbBacSi.DataSource = listBacSi;
            cbBacSi.DisplayMember = "HoTenBacSi";
        }

        private void loadBenhNhan()
        {
            List<BenhNhan> listBenhNhan = BenhNhanDAO.Instance.getDataBenhNhan();

            cbBenhNhan.DataSource = listBenhNhan;
            cbBenhNhan.DisplayMember = "HoTenBenhNhan";
        }

        private void loadNhanVien()
        {
            List<NhanVien> listNhanVien = NhanVienDAO.Instance.getDataNhanVien();

            cbNhanVien.DataSource = listNhanVien;
            cbNhanVien.DisplayMember = "HoTenNhanVien";
        }

        #endregion

        #region Event
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maBacSi = (cbBacSi.SelectedItem as BacSi).MaBacSi;
            string maBenhNhan = (cbBenhNhan.SelectedItem as BenhNhan).MaBenhNhan;
            string maNhanVien = (cbNhanVien.SelectedItem as NhanVien).MaNhanVien;

            PhieuKhamDAO.Instance.insertPhieuKham(maBacSi, maBenhNhan, maNhanVien);

            loadPhieuKhamUnchecked();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int soPhieuKham = Convert.ToInt32(txtSoPhieuKham.Text);
            string maBacSi = (cbBacSi.SelectedItem as BacSi).MaBacSi;
            string maBenhNhan = (cbBenhNhan.SelectedItem as BenhNhan).MaBenhNhan;
            string maNhanVien = (cbNhanVien.SelectedItem as NhanVien).MaNhanVien;

            if (MessageBox.Show("Bạn muốn sửa thông tin của phiếu khám có mã: " + soPhieuKham, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PhieuKhamDAO.Instance.updatePhieuKham(soPhieuKham, maBacSi, maBenhNhan, maNhanVien);

            loadPhieuKhamUnchecked();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int soPhieuKham = Convert.ToInt32(txtSoPhieuKham.Text);

            if (MessageBox.Show("Bạn muốn xóa thông tin của phiếu khám có mã: " + soPhieuKham, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PhieuKhamDAO.Instance.deletePhieuKham(soPhieuKham);

            loadPhieuKhamUnchecked();
        }

        private void dtgvPhieuKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtSoPhieuKham.Text = dtgvPhieuKham.CurrentRow.Cells["SoPhieuKham"].Value.ToString().Trim();
            string maBacSi = dtgvPhieuKham.CurrentRow.Cells["MaBacSi"].Value.ToString().Trim();
            string maBenhNhan = dtgvPhieuKham.CurrentRow.Cells["MaBenhNhan"].Value.ToString().Trim();
            string maNhanVien = dtgvPhieuKham.CurrentRow.Cells["MaNhanVien"].Value.ToString().Trim();

            foreach (BacSi bacSi in cbBacSi.Items)
            {
                if (bacSi.MaBacSi.Equals(maBacSi))
                    cbBacSi.SelectedItem = bacSi;
            }

            foreach (BenhNhan benhNhan in cbBenhNhan.Items)
            {
                if (benhNhan.MaBenhNhan.Equals(maBenhNhan))
                    cbBenhNhan.SelectedItem = benhNhan;
            }

            foreach (NhanVien nhanVien in cbNhanVien.Items)
            {
                if (nhanVien.MaNhanVien.Equals(maNhanVien))
                    cbNhanVien.SelectedItem = nhanVien;
            }
        }

        private void dtgvPhieuKham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int soPhieuKham = Convert.ToInt32(dtgvPhieuKham.CurrentRow.Cells["SoPhieuKham"].Value.ToString().Trim());
            string ngayLap = dtgvPhieuKham.CurrentRow.Cells["NgayLap"].Value.ToString().Trim();
            string maBacSi = dtgvPhieuKham.CurrentRow.Cells["MaBacSi"].Value.ToString().Trim();
            string maBenhNhan = dtgvPhieuKham.CurrentRow.Cells["MaBenhNhan"].Value.ToString().Trim();
            string maNhanVien = dtgvPhieuKham.CurrentRow.Cells["MaNhanVien"].Value.ToString().Trim();

            FormHoaDon fHoaDon = new FormHoaDon(soPhieuKham, ngayLap, maBacSi, maBenhNhan, maNhanVien);
            fHoaDon.ShowDialog();
            loadPhieuKhamUnchecked();
        }

        #endregion
    }
}
