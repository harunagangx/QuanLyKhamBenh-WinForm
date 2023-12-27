using BTL_HSK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    public class BacSiDAO
    {
        private static BacSiDAO instance;

        public static BacSiDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BacSiDAO();
                return instance;
            }

            private set => instance = value;
        }

        public List<BacSi> getDataBacSi()
        {
            List<BacSi> list = new List<BacSi>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from tblBacSi");

            foreach (DataRow item in dt.Rows)
            {
                BacSi bacSi = new BacSi(item);

                list.Add(bacSi);
            }

            return list;
        }

        public void insertBacSi(string maBacSi, string hoTenBacSi, string sdt, string gioiTinh, DateTime ngaySinh)
        {
            DataProvider.Instance.ExecuteNonQuery("spAddBacSi @maBacSi , @tenBacSi , @sdt , @gioiTinh , @ngaySinh",
                new object[] { maBacSi, hoTenBacSi, sdt, gioiTinh, ngaySinh });
        }

        public void updateBacSi(string maBacSi, string hoTenBacSi, string sdt, string gioiTinh, DateTime ngaySinh)
        {
            DataProvider.Instance.ExecuteNonQuery("spUpdateBacSi @maBacSi , @tenBacSi , @sdt , @gioiTinh , @ngaySinh",
                new object[] { maBacSi, hoTenBacSi, sdt, gioiTinh, ngaySinh });
        }

        public void deleteBacSi(string maBacSi)
        {
            DataProvider.Instance.ExecuteNonQuery("spDeleteBacSi " + maBacSi);
        }
    }
}
