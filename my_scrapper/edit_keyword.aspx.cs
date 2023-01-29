using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_scrapper
{
    public partial class edit_keyword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] != null && Session["user_email"].ToString() != "")
            {
                kw3.Visible = false;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
                //Literal2.Text = "bye";
                string em = Convert.ToString(Session["user_email"]);
                string qry = "select * from user_details where email='" + em + "'";
                con.Open();
                string plan = "";
                string id;
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Literal3.Text = sdr["company_name"].ToString();
                    plan = sdr["plan_type"].ToString();
                    id = sdr["id"].ToString();
                    if (plan == "B")
                    {
                        sdr.Close();
                        kw3.Visible = false;
                        qry = "select * from url_keyword where id='" + id + "'";
                        cmd = new SqlCommand(qry, con);
                        sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            if (!IsPostBack)
                            {
                                url.Text = sdr["url"].ToString();
                                kw1.Text = sdr["kw1"].ToString();
                                kw2.Text = sdr["kw2"].ToString();
                            }
                            Literal4.Text = "URL: " + sdr["url"].ToString();
                            Literal5.Text = "1st Keyword : " + sdr["kw1"].ToString();
                            Literal6.Text = "2nd Keyword : " + sdr["kw2"].ToString();
                            Literal7.Text = "For 3rd keyword upgrade to premium";
                        }
                    }
                    else
                    {
                        kw3.Visible = true;
                        lk3.Text = "Keyword 3";
                        sdr.Close();
                        qry = "select * from url_keyword where id='" + id + "'";
                        cmd = new SqlCommand(qry, con);
                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            if (!IsPostBack)
                            {
                                url.Text = sdr["url"].ToString();
                                kw1.Text = sdr["kw1"].ToString();
                                kw2.Text = sdr["kw2"].ToString();
                                kw3.Text = sdr["kw3"].ToString();
                            }
                            Literal4.Text = "URL : " + sdr["url"].ToString();
                            Literal5.Text = "1st Keyword : " + sdr["kw1"].ToString();
                            Literal6.Text = "2nd Keyword : " + sdr["kw2"].ToString();
                            Literal7.Text = "3rd Keyword : " + sdr["kw3"].ToString();


                        }
                    }

                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Update_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            //Literal2.Text = "bye";
            string em = Convert.ToString(Session["user_email"]);
            string qry = "select * from user_details where email='" + em + "'";
            con.Open();
            string plan = "";
            string id;
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Literal3.Text = sdr["company_name"].ToString();
                plan = sdr["plan_type"].ToString();
                id = sdr["id"].ToString();
                if (plan == "B")
                {
                    kw3.Visible = false;
                    sdr.Close();
                    qry = "UPDATE url_keyword SET kw1 = '" + kw1.Text + "',kw2='" + kw2.Text + "' where id=" + id;
                    cmd = new SqlCommand(qry, con);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        qry = "select * from url_keyword where id='" + id + "'";
                        cmd = new SqlCommand(qry, con);
                        sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {

                            Literal4.Text = sdr["url"].ToString();
                            Literal5.Text = sdr["kw1"].ToString();
                            Literal6.Text = sdr["kw2"].ToString();
                        }
                    }
                    Response.Redirect("~/edit_keyword.aspx");
                }
                else
                {
                    kw3.Visible = true;
                    lk3.Text = "Keyword 3";
                    sdr.Close();
                    qry = "UPDATE url_keyword SET kw1 = '" + kw1.Text + "',kw2='" + kw2.Text + "',kw3='" + kw3.Text + "' where id=" + id;
                    cmd = new SqlCommand(qry, con);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        qry = "select * from url_keyword where id='" + id + "'";
                        cmd = new SqlCommand(qry, con);
                        sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Literal4.Text = sdr["url"].ToString();
                            Literal5.Text = sdr["kw1"].ToString();
                            Literal6.Text = sdr["kw2"].ToString();
                            Literal7.Text = "<div class=\"timeline-badge\"><em class=\"glyphicon glyphicon-paperclip\"></em></div>"
                                + "<div class=\"timeline-panel\"><div class=\"timeline-heading\">" +
                                "<h4 class=\"timeline-title\" >" + " :" + sdr["kw3"].ToString() + "</h4></div></div>";

                        }
                    }
                    Response.Redirect("~/edit_keyword.aspx");
                }
            }

        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["user_email"] = "";

            Response.Redirect("login.aspx");
        }
    }
}