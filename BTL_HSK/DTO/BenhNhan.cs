using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BTL_HSK.DTO
{
    public class BenhNhan
    {
        private string maBenhNhan;
        private string hoTenBenhNhan;
        private string sdtBenhNhan;
        private DateTime ngaySinh;
        private string gioiTinh;

        public BenhNhan(string maBenhNhan, string hoTen, string sdt, DateTime ngaySinh, string gioiTinh)
        {
            this.MaBenhNhan = maBenhNhan;
            this.HoTenBenhNhan = hoTen;
            this.SdtBenhNhan = sdt;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
        }

        public BenhNhan(DataRow r)
        {
            this.MaBenhNhan = (string)r["sMaBenhNhan"];
            this.HoTenBenhNhan = (string)r["sTenBenhNhan"];
            this.SdtBenhNhan = (string)r["sSDT"];
            this.GioiTinh = (string)r["sGioiTinh"];
            this.NgaySinh = (DateTime)r["dNgaySinh"];
        }

        public string MaBenhNhan { get => maBenhNhan; set => maBenhNhan = value; }

        public string HoTenBenhNhan { get => hoTenBenhNhan; set => hoTenBenhNhan = value; }

        public string SdtBenhNhan { get => sdtBenhNhan; set => sdtBenhNhan = value; }

        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}