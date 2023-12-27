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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BTL_HSK.GUI
{
    public partial class FormHoaDon : Form
    {
        private string constr = ConfigurationManager.ConnectionStrings["sqlQuanLyKhamBenh"].ConnectionString;

        public FormHoaDon(int soPhieuKham, string ngayLap, string maBacSi, string maBenhNhan, string maNhanVien)
        {
            InitializeComponent();

            txtSoPhieuKham.Text = soPhieuKham.ToString();
            txtNgayLap.Text = ngayLap;
            txtMaBacSi.Text = maBacSi;
            txtMaBenhNhan.Text = maBenhNhan;
            txtMaNhanVien.Text = maNhanVien;

            loadDanhMuc();

            showHoaDon(soPhieuKham);

        }



        #region Method
        private void showHoaDon(int id)
        {
            float tongTien = 0;

            List<HoaDon> listHoaDon = HoaDonDAO.Instance.getHoaDonTheoPHieuKham(id);

            foreach (HoaDon i in listHoaDon)
            {
                tongTien += i.ThanhTien;
            }

            dtgvChiTietHoaDon.DataSource = listHoaDon;

            lbTongTien.Text = tongTien.ToString();

            dtgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadDanhMuc()
        {
            List<DanhMuc> listDanhMuc = DanhMucDAO.Instance.getDataDanhMuc();

            cbDanhMuc.DataSource = listDanhMuc;
            cbDanhMuc.DisplayMember = "TenLoaiDichVu";
        }

        private void loadDichVuTheoDanhMuc(int id)
        {
            List<DichVu> listDichVu = DichVuDAO.Instance.getDataDichVuTheoDanhMuc(id);

            cbDichVu.DataSource = listDichVu;
            cbDichVu.DisplayMember = "TenDichVu";
        }

        private void loadGiaTienDichVu(int id)
        {
            foreach (DichVu dichVu in cbDichVu.Items)
            {
                if (dichVu.MaDichVu == id)
                {
                    lbGiaTien.Text = dichVu.GiaTien.ToString();
                }
            }
        }


        #endregion

        #region Event
        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedIndex == null)
                return;

            DanhMuc selected = cb.SelectedItem as DanhMuc;

            id = selected.MaLoaiDichVu;

            loadDichVuTheoDanhMuc(id);
        }

        private void cbDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedIndex == null)
                return;

            DichVu selected = cb.SelectedItem as DichVu;

            id = selected.MaDichVu;

            loadGiaTienDichVu(id);
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            int soPhieuKham = int.Parse(txtSoPhieuKham.Text);
            int maDichVu = (cbDichVu.SelectedItem as DichVu).MaDichVu;
            int soLuong = (int)nmSoLuong.Value;
            float giaTien = float.Parse(lbGiaTien.Text);
            float donGia = giaTien * soLuong;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spThemChiTietHoaDon";
                    cmd.Parameters.AddWithValue("@soPK", soPhieuKham);
                    cmd.Parameters.AddWithValue("@maDichVu", maDichVu);
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.Parameters.AddWithValue("@donGia", donGia);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            showHoaDon(soPhieuKham);
        }
        private void dtgvChiTietHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int soPhieuKham = int.Parse(txtSoPhieuKham.Text);
            int maDichVu = int.Parse(dtgvChiTietHoaDon.CurrentRow.Cells["MaDichVu"].Value.ToString().Trim());
            string tenDichVu = dtgvChiTietHoaDon.CurrentRow.Cells["TenDichVu"].Value.ToString().Trim();

            if (MessageBox.Show("Bạn muốn xóa dịch vụ: " + tenDichVu, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                HoaDonDAO.Instance.deletDichVuHoaDon(soPhieuKham, maDichVu);

            showHoaDon(soPhieuKham);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int soPhieuKham = int.Parse(txtSoPhieuKham.Text);
            double tongTien = Convert.ToDouble(lbTongTien.Text);

            if (MessageBox.Show("Bạn muốn thanh toán hóa đơn: " + soPhieuKham, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PhieuKhamDAO.Instance.thanhToan(soPhieuKham, (float)tongTien);

            this.Close();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            int soPhieuKham = int.Parse(txtSoPhieuKham.Text);

            FormXuatHoaDon fXuatHoaDon = new FormXuatHoaDon(soPhieuKham);
            fXuatHoaDon.ShowDialog();
        }

        #endregion
    }
}
















//private void loadPhieuKham()
//{
//    List<PhieuKham> listPhieuKham = PhieuKhamDAO.Instance.getDataPhieuKhamUnchecked();

//    cbSoPhieuKham.DataSource = listPhieuKham;
//    cbSoPhieuKham.DisplayMember = "SoPhieuKham";
//}

//private void btnTimKiem_Click(object sender, EventArgs e)
//{
//    int id = (cbSoPhieuKham.SelectedValue as PhieuKham).SoPhieuKham;

//    string ngayLap = (cbSoPhieuKham.SelectedValue as PhieuKham).NgayLap.ToString();
//    string maBacSi = (cbSoPhieuKham.SelectedValue as PhieuKham).MaBacSi;
//    string maBenhNhan = (cbSoPhieuKham.SelectedValue as PhieuKham).MaBenhNhan;
//    string maNhanVien = (cbSoPhieuKham.SelectedValue as PhieuKham).MaNhanVien;

//    showHoaDon(id);

//    txtSoPhieuKham.Text = id.ToString();
//    txtNgayLap.Text = ngayLap;
//    txtMaBacSi.Text = maBacSi;
//    txtMaBenhNhan.Text = maBenhNhan;
//    txtMaNhanVien.Text = maNhanVien;
//}