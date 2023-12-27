using BTL_HSK.Report;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_HSK.GUI
{
    public partial class FormXuatHoaDon : Form
    {

        string constr = ConfigurationManager.ConnectionStrings["sqlQuanLyKhamBenh"].ConnectionString;

        public FormXuatHoaDon(int soPhieuKham)
        {
            InitializeComponent();

            showHoaDon(soPhieuKham);
        }

        private void showHoaDon(int id)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInHoaDon";
                    cmd.Parameters.AddWithValue("@soPK", id);

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;

                        DataTable dt = new DataTable();
                        ad.Fill(dt);

                        rptHoaDonXuat rpt = new rptHoaDonXuat();
                        rpt.SetDataSource(dt);
                        rptHoaDon.ReportSource = rpt;
                        rptHoaDon.Refresh();
                    }
                }
            }
        }
    }
}
