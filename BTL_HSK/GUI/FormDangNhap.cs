using BTL_HSK.DAO;
using BTL_HSK.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private bool validateLogin(string inputTK, string inputMK)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
            }
            else if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
            }
            else
            {
                return true;
            }

            return false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.ToString().Trim();
            string password = txtMatKhau.Text.ToString().Trim();

            if (!validateLogin(username, password))
            {
                return;
            }
            else
            {
                if (TaiKhoanDAO.Instance.validateLogin(username, password))
                {
                    this.Hide();
                    FormMainMenu fMain = new FormMainMenu();
                    fMain.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
