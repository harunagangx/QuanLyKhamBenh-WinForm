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
    public partial class FormBacSi : Form
    {
        string gender;

        public FormBacSi()
        {
            InitializeComponent();

            loadBacSi();
        }

        #region Method
        private void loadBacSi()
        {
            List<BacSi> list = BacSiDAO.Instance.getDataBacSi();

            dtgvBacSi.DataSource = list;

            dtgvBacSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string id = txtMaBacSi.Text;
            string hoTen = txtHoTen.Text;
            string sdt = txtSdt.Text;
            string gioiTinh = gender;
            DateTime ngaySinh = dtpNgaySinh.Value;

            BacSiDAO.Instance.insertBacSi(id, hoTen, sdt, gioiTinh, ngaySinh);

            loadBacSi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string id = txtMaBacSi.Text;
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

            if (MessageBox.Show("Bạn muốn sửa thông tin của bác sĩ có mã " + id, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                BacSiDAO.Instance.updateBacSi(id, hoTen, sdt, gioiTinh, ngaySinh);

            loadBacSi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtMaBacSi.Text;

            if (MessageBox.Show("Bạn muốn xóa thông tin của bác sĩ có mã " + id, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                BacSiDAO.Instance.deleteBacSi(id);
            
            loadBacSi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaBacSi.Clear();
            txtHoTen.Clear();
            txtSdt.Clear();
            rbNam.Checked = false;
            rbNu.Checked = false;
        }

        private void dtgvBacSi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBacSi.Text = dtgvBacSi.CurrentRow.Cells["MaBacSi"].Value.ToString().Trim();
            txtHoTen.Text = dtgvBacSi.CurrentRow.Cells["HoTenBacSi"].Value.ToString().Trim();
            txtSdt.Text = dtgvBacSi.CurrentRow.Cells["SdtBacSi"].Value.ToString().Trim();
            dtpNgaySinh.Text = dtgvBacSi.CurrentRow.Cells["NgaySinh"].Value.ToString().Trim();
            gender = dtgvBacSi.CurrentRow.Cells["GioiTinh"].Value.ToString().Trim();

            if (gender == "Nam") rbNam.Checked = true;
            else rbNu.Checked = true;
        }

        #endregion
    }
}



        //private void btnThongKe_Click(object sender, EventArgs e)
        //{
        //    FormThongKeBacSi fBaoCao = new FormThongKeBacSi();
        //    fBaoCao.Show();
        //}