using BTL_HSK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return instance;
            }

            private set => instance = value;
        }

        private NhanVienDAO() { }

        public List<NhanVien> getDataNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM tblNhanVien");

            foreach (DataRow item in dt.Rows)
            {
                NhanVien nhanVien = new NhanVien(item);

                list.Add(nhanVien);
            }

            return list;
        }

        public void insertNhanVien(string maNhanVien, string hoTen, string sdt, string gioiTinh, DateTime ngaySinh)
        {
            DataProvider.Instance.ExecuteNonQuery("spAddNhanVien @maNhanVien , @hoTen , @sdt , @gioiTinh , @ngaySinh",
                new object[] { maNhanVien, hoTen, sdt, gioiTinh, ngaySinh });
        }

        public void updateNhanVien(string maNhanVien, string hoTen, string sdt, string gioiTinh, DateTime ngaySinh)
        {
            DataProvider.Instance.ExecuteNonQuery("spUpdateNhanVien @maNhanVien , @hoTen , @sdt , @gioiTinh , @ngaySinh",
                new object[] { maNhanVien, hoTen, sdt, gioiTinh, ngaySinh });
        }

        public void deleteNhanVien(string maNhanVien)
        {
            DataProvider.Instance.ExecuteNonQuery("spDeleteNhanVien " + maNhanVien);
        }
    }
}
