using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DTO
{
    public class DichVu
    {
        private int maDichVu;
        private string tenDichVu;
        private int maLoaiDichVu;
        private float giaTien;

        public DichVu(int maDichVu, string tenDichVu, int maLoaiDichVu, float giaTien)
        {
            this.MaDichVu = maDichVu;
            this.TenDichVu = tenDichVu;
            this.MaLoaiDichVu = maLoaiDichVu;
            this.GiaTien = giaTien;
        }

        public DichVu(DataRow r)
        {
            this.MaDichVu = (int)r["iMaDichVu"];
            this.TenDichVu = (string)r["sTenDichVu"];
            this.MaLoaiDichVu = (int)r["iMaLoaiDichVu"];
            this.GiaTien = (float)Convert.ToDouble(r["fGiaTien"].ToString());
        }

        public int MaDichVu { get => maDichVu; set => maDichVu = value; }
        public string TenDichVu { get => tenDichVu; set => tenDichVu = value; }
        public int MaLoaiDichVu { get => maLoaiDichVu; set => maLoaiDichVu = value; }
        public float GiaTien { get => giaTien; set => giaTien = value; }
    }
}
