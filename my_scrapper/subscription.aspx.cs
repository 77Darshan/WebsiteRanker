using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace my_scrapper
{
    public partial class subscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["user_email"] != null &&  Session["user_email"].ToString() != "" )
            {
                if (!IsPostBack)
                {

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
                    //Literal2.Text = "bye";
                    string em = Convert.ToString(Session["user_email"]);
                    string qry = "select * from user_details where email='" + em + "'";
                    con.Open();
                    string plan = "";
                    string id;
                    DateTime d;
                    DateTime rem;
                    string p;
                    float c = 0;
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        Literal2.Text = sdr["name"].ToString();
                        Literal3.Text = sdr["company_name"].ToString();
                        plan = sdr["plan_type"].ToString();
                        id = sdr["id"].ToString();
                        if (plan == "B")
                        {
                            d = Convert.ToDateTime(sdr["date"]);
                            rem = d.AddMonths(+3);
                            p = Convert.ToString((rem - DateTime.Now).Days);
                            c = Convert.ToInt32(p);
                            Literal8.Text = "" + d.ToShortDateString();
                            Literal9.Text = "" + rem.ToShortDateString();
                            Literal10.Text = "" + p;
                            Literal12.Text = Literal11.Text = "" + (int)((c / 92) * 100);

                            sdr.Close();
                            qry = "select * from url_keyword where id='" + id + "'";
                            cmd = new SqlCommand(qry, con);
                            sdr = cmd.ExecuteReader();

                            if (sdr.Read())
                            {
                                Literal1.Text = "Basic Plan";
                                Literal4.Text = "URL : " + sdr["url"].ToString();
                                Literal5.Text = "1st Keyword : " + sdr["kw1"].ToString();
                                Literal6.Text = "2nd Keyword : " + sdr["kw2"].ToString();
                                Literal7.Text = "For 3rd keyword upgrade to premium";
                            }
                        }
                        else
                        {
                            d = Convert.ToDateTime(sdr["date"]);
                            rem = d.AddMonths(+7);
                            p = Convert.ToString((rem - DateTime.Now).Days);
                            c = Convert.ToInt32(p);
                            Literal8.Text = "" + d.ToShortDateString();
                            Literal9.Text = "" + rem.ToShortDateString();
                            Literal10.Text = "" + p;
                            Literal12.Text = Literal11.Text = "" + (int)((c / 213) * 100);
                            //d = Convert.ToDateTime(sdr["date"]);
                            //rem = d.AddMonths(+7);
                            //Literal8.Text = "" + d.ToShortDateString();
                            //Literal9.Text = "" + rem.ToShortDateString();
                            //Literal10.Text = "" + (rem-DateTime.Now ).Days;
                            sdr.Close();
                            qry = "select * from url_keyword where id='" + id + "'";
                            cmd = new SqlCommand(qry, con);
                            sdr = cmd.ExecuteReader();
                            if (sdr.Read())
                            {
                                Literal1.Text = "Premium Plan";
                                Literal4.Text = "URL : " + sdr["url"].ToString();
                                Literal5.Text = "1st Keyword : " + sdr["kw1"].ToString();
                                Literal6.Text = "2nd Keyword : " + sdr["kw2"].ToString();
                                Literal7.Text = "3rd Keyword : " + sdr["kw3"].ToString();
                            }
                        }
                    }

                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            sendml();
        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["user_email"] = "";

            Response.Redirect("login.aspx");
        }

        public void sendml()
        {
            string em = Convert.ToString(Session["user_email"]);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("unverctiyincanada1323@gmail.com", "#####12Pr");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = name.Text;
            msg.Body = message.Text;
            string toadd = "unverctiyincanada1323@gmail.com";
            msg.To.Add(toadd);
            string frmadd = "bca48sem5ddu@gmail.com";
            msg.From = new MailAddress(frmadd);
            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}