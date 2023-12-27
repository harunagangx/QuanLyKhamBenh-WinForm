using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DTO
{
    public class HoaDon
    {
        private int maDichVu;
        private string tenDichVu;
        private int soLuong;
        private float thanhTien;

        public HoaDon(int maDichVu, string tenDichVu, int soLuong, float thanhTien)
        {
            this.MaDichVu = maDichVu;
            this.TenDichVu = tenDichVu;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
        }

        public HoaDon(DataRow r)
        {
            this.MaDichVu = (int)r["iMaDichVu"];
            this.TenDichVu = (string)r["sTenDichVu"];
            this.SoLuong = (int)r["iSoLuong"];
            this.ThanhTien = (float)Convert.ToDouble(r["fDonGia"].ToString());
        }

        public int MaDichVu { get => maDichVu; set => maDichVu = value; }
        public string TenDichVu { get => tenDichVu; set => tenDichVu = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
