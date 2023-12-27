using BTL_HSK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;

        public static DichVuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuDAO();
                return instance;
            }

            private set => instance = value;
        }

        private DichVuDAO() { }

        public List<DichVu> getDataDichVu()
        {
            List<DichVu> list = new List<DichVu>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from tblDichVu");

            foreach (DataRow item in dt.Rows)
            {
                DichVu dichVu = new DichVu(item);

                list.Add(dichVu);
            }

            return list;
        }

        public void insertDichVu(string tenDichVu, int maDanhMuc, float giaTien)
        {
            DataProvider.Instance.ExecuteNonQuery("spAddDichVu @tenDichVu , @maLoaiDichVu , @giaTien",
                new object[] { tenDichVu, maDanhMuc, giaTien });
        }

        public void updateDichVu(int maDichVu, string tenDichVu, int maDanhMuc, float giaTien)
        {
            DataProvider.Instance.ExecuteNonQuery("spUpdateDichVu @maDichVu , @tenDichVu , @maLoaiDichVu , @giaTien",
                new object[] { maDichVu, tenDichVu, maDanhMuc, giaTien });
        }

        public void deleteDichVu(int maDichVu)
        {
            DataProvider.Instance.ExecuteNonQuery("spDeleteDichVu " + maDichVu);
        }

        public List<DichVu> getDataDichVuTheoDanhMuc(int id)
        {
            List<DichVu> list = new List<DichVu>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("EXEC spDSDichVuTheoDanhMuc " + id);

            foreach (DataRow item in dt.Rows)
            {
                DichVu dichVu = new DichVu(item);

                list.Add(dichVu);
            }

            return list;
        }
    }
}
