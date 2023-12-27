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
    public partial class FormBenhNhan : Form
    {
        string gender;

        public FormBenhNhan()
        {
            InitializeComponent();

            loadBenhNhan();
        }

        #region Method
        private void loadBenhNhan()
        {
            List<BenhNhan> list = BenhNhanDAO.Instance.getDataBenhNhan();

            dtgvBenhNhan.DataSource = list;

            dtgvBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string id = txtMaBenhNhan.Text;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = gender;

            BenhNhanDAO.Instance.insertBenhNhan(id, hoTen, sdt, gioiTinh, ngaySinh);

            loadBenhNhan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaBenhNhan.Text;
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

            if (MessageBox.Show("Bạn muốn sửa thông tin của bệnh nhân có mã: " + id, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                BenhNhanDAO.Instance.updateBenhNhan(id, hoTen, sdt, gioiTinh, ngaySinh);

            loadBenhNhan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaBenhNhan.Text;
            
            if (MessageBox.Show("Bạn muốn xóa thông tin của bệnh nhân có mã: " + id, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                BenhNhanDAO.Instance.deleteBenhNhan(id);


            loadBenhNhan();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaBenhNhan.Clear();
            txtHoTen.Clear();
            txtSdt.Clear();
            rbNam.Checked = false;
            rbNu.Checked = false;

        }

        private void dtgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBenhNhan.Text = dtgvBenhNhan.CurrentRow.Cells["MaBenhNhan"].Value.ToString().Trim();
            txtHoTen.Text = dtgvBenhNhan.CurrentRow.Cells["HoTenBenhNhan"].Value.ToString().Trim();
            txtSdt.Text = dtgvBenhNhan.CurrentRow.Cells["SdtBenhNhan"].Value.ToString().Trim();
            dtpNgaySinh.Text = dtgvBenhNhan.CurrentRow.Cells["NgaySinh"].Value.ToString().Trim();
            gender = dtgvBenhNhan.CurrentRow.Cells["GioiTinh"].Value.ToString().Trim();
            if (gender == "Nam") rbNam.Checked = true;
            else rbNu.Checked = true;
        }
        #endregion

    }
}
