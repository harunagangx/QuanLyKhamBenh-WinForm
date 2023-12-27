using BTL_HSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BTL_HSK.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonDAO();
                return instance;
            }

            private set => instance = value;
        }

        public List<HoaDon> getHoaDonTheoPHieuKham(int id)
        {
            List<HoaDon> list = new List<HoaDon>();

            float tongTien = 0;

            DataTable dt = DataProvider.Instance.ExecuteQuery("exec spShowHoaDon " + id);

            foreach (DataRow item in dt.Rows)
            {
                HoaDon hoaDon = new HoaDon(item);

                list.Add(hoaDon);

                tongTien += hoaDon.ThanhTien;
            }

            return list;
        }

        public void insertDichVuHoaDon(int soPhieuKham, int maDichVu, int soLuong, float donGia)
        {
            DataProvider.Instance.ExecuteNonQuery("spThemChiTietHoaDon @soPK , @maDichVu , @soLuong , @donGia",
                new object[] {soPhieuKham, maDichVu, soPhieuKham, donGia});
        }

        public void deletDichVuHoaDon(int soPhieuKham, int maDichVu)
        {
            DataProvider.Instance.ExecuteNonQuery("spDeleteChiTietHoaDon @soPK , @maDichVu",
                new object[] { soPhieuKham, maDichVu });
        }
    }
}
