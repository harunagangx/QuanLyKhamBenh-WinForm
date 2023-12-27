using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DTO
{
    public class DanhMuc
    {
        private int maLoaiDichVu;
        private string tenLoaiDichVu;

        public DanhMuc(int maLoaiDichVu, string tenLoaiDichVu)
        {
            this.MaLoaiDichVu = maLoaiDichVu;
            this.TenLoaiDichVu = tenLoaiDichVu;
        }

        public DanhMuc(DataRow r)
        {
            this.MaLoaiDichVu = (int)r["iMaLoaiDichVu"];
            this.TenLoaiDichVu = (string)r["sTenLoaiDichVu"];
        }

        public int MaLoaiDichVu { get => maLoaiDichVu; set => maLoaiDichVu = value; }
        public string TenLoaiDichVu { get => tenLoaiDichVu; set => tenLoaiDichVu = value; }
    }
}
