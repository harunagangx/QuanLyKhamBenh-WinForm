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

namespace BTL_HSK.GUI
{
    public partial class FormNhanVien : Form
    {
        string gender;

        public FormNhanVien()
        {
            InitializeComponent();

            loadNhanVien();
        }

        #region Method
        private void loadNhanVien()
        {
            List<NhanVien> list = NhanVienDAO.Instance.getDataNhanVien();

            dtgvNhanVien.DataSource = list;

            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Event

        private void rbNam_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Nam";
        }

        private void rbNu_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Nữ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id = txtMaNhanVien.Text;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string gioiTinh = gender;
            DateTime ngaySinh = dtpNgaySinh.Value;

            NhanVienDAO.Instance.insertNhanVien(id, hoTen, sdt, gioiTinh, ngaySinh);

            loadNhanVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaNhanVien.Text;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;

            if (rbNam.Checked)
            {
                gender = "Nam";
            }
            else if (rbNu.Checked)
            {
                gender = "Nữ";
            }

            string gioiTinh = gender;

            if (MessageBox.Show("Bạn muốn sửa thông tin của nhân viên có mã " + id, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                NhanVienDAO.Instance.updateNhanVien(id, hoTen, sdt, gioiTinh, ngaySinh);

            loadNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaNhanVien.Text;

            if (MessageBox.Show("Bạn muốn xóa thông tin của nhân viên có mã " + id, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                NhanVienDAO.Instance.deleteNhanVien(id);

            loadNhanVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSdt.Clear();
            rbNam.Checked = false;
            rbNu.Checked = false;
        }

        private void dtgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhanVien.Text = dtgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString().Trim();
            txtHoTen.Text = dtgvNhanVien.CurrentRow.Cells["HoTenNhanVien"].Value.ToString().Trim();
            txtSdt.Text = dtgvNhanVien.CurrentRow.Cells["SdtNhanVien"].Value.ToString().Trim();
            dtpNgaySinh.Text = dtgvNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString().Trim();

            gender = dtgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString().Trim();
            if (gender == "Nam") rbNam.Checked = true;
            else rbNu.Checked = true;
        }

        #endregion
    }
}
