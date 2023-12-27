using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DTO
{
    public class TaiKhoan
    {
        private int id;
        private string username;
        private string password;

        public TaiKhoan(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }

        public TaiKhoan(DataRow r)
        {
            this.Id = (int)r["iMaTK"];
            this.Username = (string)r["sTenTaiKhoan"];
            this.Password = (string)r["sMatKhau"];
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
