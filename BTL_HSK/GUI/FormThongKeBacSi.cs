using BTL_HSK.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK.GUI
{

    public partial class FormThongKeBacSi : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["sqlQuanLyKhamBenh"].ConnectionString;


        public FormThongKeBacSi()
        {
            InitializeComponent();

            loadBacSi();
        }

        private void loadBacSi()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDSBacSi";

                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;

                        DataTable dt = new DataTable();
                        ad.Fill(dt);

                        rptBacSi rpt = new rptBacSi();
                        rpt.SetDataSource(dt);
                        rptBacSi.ReportSource = rpt;
                        rptBacSi.Refresh();
                    }
                }
            }
        }
    }
}
