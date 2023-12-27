using BTL_HSK.Report;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_HSK.GUI
{
    public partial class FormThongKeDoanhThu : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["sqlQuanLyKhamBenh"].ConnectionString;


        public FormThongKeDoanhThu()
        {
            InitializeComponent();


        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtpNgay.Value;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spThongKeDoanhThu";
                    cmd.Parameters.AddWithValue("@ngay", ngay);

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;

                        DataTable dt = new DataTable();
                        ad.Fill(dt);

                        rptThongKeDoanhThu rpt = new rptThongKeDoanhThu();
                        rpt.SetDataSource(dt);
                        rptThongKeDoanhThu.ReportSource = rpt;
                        rptThongKeDoanhThu.Refresh();
                    }
                }
            }

        }
    }
}
