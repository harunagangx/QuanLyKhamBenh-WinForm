using BTL_HSK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BTL_HSK.DAO
{
    public class DanhMucDAO
    {
        private static DanhMucDAO instance;

        public static DanhMucDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhMucDAO();
                return instance;
            }

            private set => instance = value;
        }

        private DanhMucDAO() { }

        public List<DanhMuc> getDataDanhMuc()
        {
            List<DanhMuc> list = new List<DanhMuc>();

            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from tblLoaiDichVu");

            foreach (DataRow item in dt.Rows)
            {
                DanhMuc danhMuc = new DanhMuc(item);

                list.Add(danhMuc);
            }

            return list;
        }
    }
}
