using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanDAO();
                return instance;
            }

            private set => instance = value;
        }

        private TaiKhoanDAO() { }

        public bool validateLogin(string username, string password)
        {
            bool check = false;

            object res = DataProvider.Instance.ExecuteScalar("checkLogin @username , @password",
                new object[] { username, password });

            if (res != null)
                check = true;

            return check;
        }
    }
}
