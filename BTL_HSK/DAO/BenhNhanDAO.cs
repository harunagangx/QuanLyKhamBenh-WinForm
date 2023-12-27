using BTL_HSK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    public class BenhNhanDAO
    {
        private static BenhNhanDAO instance;

        public static BenhNhanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BenhNhanDAO();
                return instance;
            }

            private set => instance = value;
        }

        public List<BenhNhan> getDataBenhNhan()
        {
            List<BenhNhan> list = new List<BenhNhan>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from tblBenhNhan");

            foreach (DataRow item in dt.Rows)
            {
                BenhNhan benhNhan = new BenhNhan(item);

                list.Add(benhNhan);
            }

            return list;
        }

        public void insertBenhNhan(string maBenhNhan, string hoTenBenhNhan, string sdt, string gioiTinh, DateTime ngaySinh)
        {
            DataProvider.Instance.ExecuteNonQuery("spAddBenhNhan @maBenhNhan , @hoTenBenhNhan , @sdt , @gioiTinh , @ngaySinh",
                new object[] { maBenhNhan, hoTenBenhNhan, sdt, gioiTinh, ngaySinh });
        }

        public void updateBenhNhan(string maBenhNhan, string hoTenBenhNhan, string sdt, string gioiTinh, DateTime ngaySinh)
        {
            DataProvider.Instance.ExecuteNonQuery("spUpdateBenhNhan @maBenhNhan , @hoTenBenhNhan , @sdt , @gioiTinh , @ngaySinh",
                new object[] { maBenhNhan, hoTenBenhNhan, sdt, gioiTinh, ngaySinh });
        }

        public void deleteBenhNhan(string maBenhNhan)
        {
            DataProvider.Instance.ExecuteNonQuery("spDeleteBenhNhan " + maBenhNhan);
        }
    }
}
