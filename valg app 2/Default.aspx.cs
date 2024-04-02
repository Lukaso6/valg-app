using Microsoft.Ajax.Utilities;
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
    public partial class _Default : Page
    {

        /*call all functions*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                Response.Write(Request.QueryString["result"]);
            }

            if (!IsPostBack)
            {
                getFromKommuner();
                getFromPartier();

            }
        }


        /*fyller ut kommune dropdown*/
        private void getFromKommuner()
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from kommune order by knavn", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["knavn"].ToString(), row["kid"].ToString());
                DropDownListKommuner.Items.Add(item);

            }

            DropDownListKommuner.DataBind();

        }

        /*fyller ut parti dropdownen*/
        private void getFromPartier()
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from parti order by pnavn", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["pnavn"].ToString(), row["pid"].ToString());
                DropDownListPartier.Items.Add(item);

            }

            DropDownListPartier.DataBind();

        }

        /*registrere at dropdownsa har en verdi (eventuelt sender ut en feilmelding)*/
        protected void ButtonVote_Click(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;
            if (int.Parse(DropDownListKommuner.SelectedValue) == 0)
            {
                Response.Redirect(Request.Url.AbsolutePath + "?result=Du må velge en kommune");
            }

            if (int.Parse(DropDownListPartier.SelectedValue) == 0)
            {
                Response.Redirect(Request.Url.AbsolutePath + "?result=Du må velge et parti");
            }





            string id;
            id = button.Attributes["data-id"];

            /*inserter "kommune id", "parti id" og "stemmen" i databasen*/

            SqlParameter param;
            var connectionString = ConfigurationManager.ConnectionStrings["ConnCms"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO stemmer (kid,pid,antall) Values(@kid,@pid,1)", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@kid", SqlDbType.Int);
                param.Value = int.Parse(DropDownListKommuner.SelectedValue);
                cmd.Parameters.Add(param);

                param = new SqlParameter("@pid", SqlDbType.Int);
                param.Value = int.Parse(DropDownListPartier.SelectedValue);
                cmd.Parameters.Add(param);

                /*
                param = new SqlParameter("@fnr", SqlDbType.Int);
                param.Value = int.Parse(fnr.SelectedValue);
                cmd.Parameters.Add(param);
                */
                

                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

    }
}



