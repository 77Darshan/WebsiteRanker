using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace my_scrapper
{
    public partial class user_panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] != null && Session["user_email"].ToString() != "")
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
                //Literal2.Text = "bye";
                string em = Convert.ToString(Session["user_email"]);
                string qry = "select * from user_details where email='" + em + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Literal2.Text = sdr["name"].ToString();
                    Literal3.Text = sdr["company_name"].ToString();
                    Literal1.Text = sdr["name"].ToString();
                    Literal4.Text = sdr["password"].ToString();
                    Literal5.Text = sdr["company_name"].ToString();
                    Literal6.Text = sdr["email"].ToString();
                    Literal7.Text = sdr["gender"].ToString();
                    Literal8.Text = sdr["contact"].ToString();
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["user_email"] = "";

            Response.Redirect("login.aspx");
        }
    }
}