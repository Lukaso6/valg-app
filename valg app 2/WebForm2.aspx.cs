using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace valg_app_2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*setter sammen pid og getKid*/
            if (!IsPostBack)
            {
                string countValues = "";
                int[] pids = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                foreach (var item in pids)
                {
                    countValues += getKid(item) + ",";
                }

                count.Value = countValues.ToString();
            }

        }

        /*henter informasjon fra DB(kid)*/
        private int getKid(int pid)
        {
            int count = 0;

            var connString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(antall) FROM parti, stemmer  WHERE parti.pid = stemmer.pid AND parti.pid = @pid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                var param = new SqlParameter("@pid", SqlDbType.Int);
                param.Value = pid;
                cmd.Parameters.Add(param);


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }

                reader.Close();
                conn.Close();

            }

            return count;
        }

    }
}