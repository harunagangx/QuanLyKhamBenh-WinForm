using BTL_HSK.DTO;
using BTL_HSK.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace BTL_HSK.GUI
{
    public partial class FormDichVu : Form
    {
        public FormDichVu()
        {
            InitializeComponent();

            loadDichVu();

            loadDanhMuc();
        }

        #region Method

        private void loadDichVu()
        {
            List<DichVu> listDichVu = DichVuDAO.Instance.getDataDichVu();

            dtgvDichVu.DataSource = listDichVu;

            dtgvDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadDanhMuc()
        {
            List<DanhMuc> listDanhMuc = DanhMucDAO.Instance.getDataDanhMuc();

            cbDanhMuc.DataSource = listDanhMuc;
            cbDanhMuc.DisplayMember = "TenLoaiDichVu";
        }

        #endregion

        #region Event

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDichVu = txtTenDichVu.Text;
            int maDanhMuc = (cbDanhMuc.SelectedItem as DanhMuc).MaLoaiDichVu;
            float giaTien = float.Parse(txtGiaTien.Text);

            DichVuDAO.Instance.insertDichVu(tenDichVu, maDanhMuc, giaTien);

            loadDichVu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maDichVu = int.Parse(txtMaDichVu.Text);
            string tenDichVu = txtTenDichVu.Text;
            int maDanhMuc = (cbDanhMuc.SelectedItem as DanhMuc).MaLoaiDichVu;
            float giaTien = float.Parse(txtGiaTien.Text);

            if (MessageBox.Show("Bạn muốn sửa thông tin của dịch vụ có mã " + maDichVu, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DichVuDAO.Instance.updateDichVu(maDichVu, tenDichVu, maDanhMuc, giaTien);

            loadDichVu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maDichVu = int.Parse(txtMaDichVu.Text);

            if (MessageBox.Show("Bạn muốn xóa thông tin của dịch vụ có mã " + maDichVu, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DichVuDAO.Instance.deleteDichVu(maDichVu);

            loadDichVu();

        }

        private void dtgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDichVu.Text = dtgvDichVu.CurrentRow.Cells["MaDichVu"].Value.ToString().Trim();
            txtTenDichVu.Text = dtgvDichVu.CurrentRow.Cells["TenDichVu"].Value.ToString().Trim();
            txtGiaTien.Text = dtgvDichVu.CurrentRow.Cells["GiaTien"].Value.ToString().Trim();

            int maDanhMuc = int.Parse(dtgvDichVu.CurrentRow.Cells["MaLoaiDichVu"].Value.ToString().Trim());

            foreach (DanhMuc danhMuc in cbDanhMuc.Items)
            {
                if (danhMuc.MaLoaiDichVu == maDanhMuc)
                    cbDanhMuc.SelectedItem = danhMuc;
            }
        }

        #endregion

    }
}
