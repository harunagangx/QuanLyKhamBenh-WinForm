using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DTO
{
    public class NhanVien
    {
        private string maNhanVien;
        private string hoTenNhanVien;
        private string sdtNhanVien;
        private DateTime ngaySinh;
        private string gioiTinh;

        public NhanVien(string maNhanVien, string hoTenNhanVien, string sdtNhanVien, DateTime ngaySinh, string gioiTinh)
        {
            this.MaNhanVien = maNhanVien;
            this.HoTenNhanVien = hoTenNhanVien;
            this.SdtNhanVien = sdtNhanVien;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
        }

        public NhanVien(DataRow r)
        {
            this.MaNhanVien = (string)r["sMaNhanVien"];
            this.HoTenNhanVien = (string)r["sTenNhanVien"];
            this.SdtNhanVien = (string)r["sSDT"];
            this.NgaySinh = (DateTime)r["dNgaySinh"];
            this.GioiTinh = (string)r["sGioiTinh"];
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }

        public string HoTenNhanVien { get => hoTenNhanVien; set => hoTenNhanVien = value; }

        public string SdtNhanVien { get => sdtNhanVien; set => sdtNhanVien = value; }

        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

    }
}

