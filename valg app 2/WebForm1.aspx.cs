using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace valg_app_2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataTable dt = getFromPersoner();

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        private DataTable getFromPersoner()
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT parti.leder, parti.pnavn, COUNT(stemmer.antall) AS 'antall' FROM stemmer JOIN kommune ON kommune.kid = stemmer.kid JOIN parti ON parti.pid = stemmer.pid GROUP BY parti.leder, parti.pnavn";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
                return dt;
            }
        }
    }
}