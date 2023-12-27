using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DTO
{
    public class BacSi
    {
        private string maBacSi;
        private string hoTenBacSi;
        private string sdtBacSi;
        private string gioiTinh;
        private DateTime ngaySinh;

        public BacSi(string maBacSi, string hoTenBacSi, string sdtBacSi, DateTime ngaySinh, string gioiTinh)
        {
            this.MaBacSi = maBacSi;
            this.HoTenBacSi = hoTenBacSi;
            this.SdtBacSi = sdtBacSi;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
        }

        public BacSi(DataRow r)
        {
            this.MaBacSi = (string)r["sMaBacSi"];
            this.HoTenBacSi = (string)r["sTenBacSi"];
            this.SdtBacSi = (string)r["sSDT"];
            this.NgaySinh = (DateTime)r["dNgaySinh"];
            this.GioiTinh = (string)r["sGioiTinh"];
        }

        public string MaBacSi { get => maBacSi; set => maBacSi = value; }
        public string HoTenBacSi { get => hoTenBacSi; set => hoTenBacSi = value; }
        public string SdtBacSi { get => sdtBacSi; set => sdtBacSi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
    }
}

