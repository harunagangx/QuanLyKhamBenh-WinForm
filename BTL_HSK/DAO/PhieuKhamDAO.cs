using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BTL_HSK.DTO;

namespace BTL_HSK.DAO
{
    public class PhieuKhamDAO
    {
        private static PhieuKhamDAO instance;

        public static PhieuKhamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuKhamDAO();
                return instance;
            }

            private set => instance = value;
        }

        private PhieuKhamDAO() { }

        public List<PhieuKham> getDataPhieuKhamUnchecked()
        {
            List<PhieuKham> list = new List<PhieuKham>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from tblPhieuKham where iTrangThai = 0");

            foreach (DataRow item in dt.Rows)
            {
                PhieuKham phieuKham = new PhieuKham(item);

                list.Add(phieuKham);
            }

            return list;
        }

        public List<PhieuKham> getDataPhieuKhamChecked()
        {
            List<PhieuKham> list = new List<PhieuKham>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from tblPhieuKham where iTrangThai = 1");

            foreach (DataRow item in dt.Rows)
            {
                PhieuKham phieuKham = new PhieuKham(item);

                list.Add(phieuKham);
            }

            return list;
        }

        public void insertPhieuKham(string maBacSi, string maBenhNhan, string maNhanVien)
        {
            DataProvider.Instance.ExecuteNonQuery("spAddPhieuKham @maBacSi , @maBenhNhan , @maNhanVien",
                new object[] { maBacSi, maBenhNhan, maNhanVien });
        }

        public void updatePhieuKham(int soPhieuKham, string maBacSi, string maBenhNhan, string maNhanVien)
        {
            DataProvider.Instance.ExecuteNonQuery("spUpdatePhieuKham @soPhieuKham , @maBacSi , @maBenhNhan , @maNhanVien",
                new object[] { soPhieuKham, maBacSi, maBenhNhan, maNhanVien });
        }

        public void deletePhieuKham(int soPhieuKham)
        {
            DataProvider.Instance.ExecuteNonQuery("spDeletePhieuKham " + soPhieuKham);
        }

        public void thanhToan(int soPhieuKham, float tongTien)
        {
            DataProvider.Instance.ExecuteNonQuery("spThanhToan @soPK , @tongTien",
                new object[] { soPhieuKham, tongTien });
        }
    }
}
