using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BTL_HSK.DTO
{
    public class PhieuKham
    {
        private int soPhieuKham;
        private DateTime ngayLap;
        private int trangThai;
        private string maBacSi;
        private string maBenhNhan;
        private string maNhanVien;
        private float tongTien;

        public PhieuKham(int soPhieuKHam, DateTime ngayLap, int trangThai, string maBacSi, string maBenhNhan, string maNhanVien, float tongTien)
        {
            this.SoPhieuKham = soPhieuKHam;
            this.NgayLap = ngayLap;
            this.TrangThai = trangThai;
            this.MaBacSi = maBacSi;
            this.MaBenhNhan = maBenhNhan;
            this.MaNhanVien = maNhanVien;
            this.TongTien = tongTien;

        }

        public PhieuKham(DataRow r)
        {
            this.SoPhieuKham = (int)r["iSoPK"];
            this.NgayLap = (DateTime)r["dNgayLap"];
            this.TrangThai = (int)r["iTrangThai"];
            this.MaBacSi = (string)r["sMaBacSi"];
            this.MaBenhNhan = (string)r["sMaBenhNhan"];
            this.MaNhanVien = (string)r["sMaNhanVien"];
            this.TongTien = (float)Convert.ToDouble(r["fTongTien"].ToString());
        }

        public int SoPhieuKham { get => soPhieuKham; set => soPhieuKham = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string MaBacSi { get => maBacSi; set => maBacSi = value; }
        public string MaBenhNhan { get => maBenhNhan; set => maBenhNhan = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
    }
}
