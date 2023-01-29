using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;

namespace my_scrapper
{
    public partial class admin_panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() != "")
            {
                loadpage();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        public void loadpage()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            con.Open();
            SqlCommand cm1;
            SqlDataReader sdr, sdr2;
            cm1 = new SqlCommand("Select COUNT(id) from admin", con);
            int i = 0;
            i = Convert.ToInt32(cm1.ExecuteScalar());
            cm1.ExecuteNonQuery();
            literal1.Text = i.ToString();

            int col1, col2, col3 = 0;
            cm1 = new SqlCommand("Select  Count(kw1) from url_keyword", con);
            //cm1=new SqlCommand("SELECT SUM(CASE WHEN kw1 IS NOT NULL THEN 1 ELSE 0 END) AS column1_count , SUM(CASE WHEN kw2 IS NOT NULL THEN 1 ELSE 0 END) AS column2_count , SUM(CASE WHEN kw3 IS NOT NULL THEN 1 ELSE 0 END) AS column3_count FROM url_keyword",con);
            // cm1 = new SqlCommand("SELECT * FROM(SELECT COUNT(kw1), kw1 FROM url_keyword GROUP BY kw1 UNION ALL SELECT COUNT(kw2), kw2 FROM url_keyword GROUP BY kw2 UNION ALL SELECT COUNT(kw3), kw3 FROM url_keyword GROUP BY kw3) s", con);
            col1 = Convert.ToInt32(cm1.ExecuteScalar());
            cm1 = new SqlCommand("Select  COUNT(kw2) from url_keyword ", con);
            col2 = Convert.ToInt32(cm1.ExecuteScalar());
            cm1 = new SqlCommand("Select  Count(kw3) from url_keyword", con);

            col3 = Convert.ToInt32(cm1.ExecuteScalar());
            cm1.ExecuteNonQuery();
            literal2.Text = (col1 + col2 + col3).ToString();

            int tot_user = 0;
            cm1 = new SqlCommand("Select COUNT(id) from user_details", con);
            tot_user = Convert.ToInt32(cm1.ExecuteScalar());
            cm1.ExecuteNonQuery();
            literal3.Text = tot_user.ToString();

            /* Details about total (users,admins,searches,etc*/
            string last_user = "";
            string qry = "SELECT * FROM user_details WHERE id=(SELECT max(id) FROM user_details)";
            cm1 = new SqlCommand(qry, con);
            sdr = cm1.ExecuteReader();
            DateTime reg_date = DateTime.Now;

            while (sdr.Read())
            {
                last_user = sdr["name"].ToString();
                reg_date = Convert.ToDateTime(sdr["date"]).Date;
            }
            sdr.Close();
            Literal4.Text = last_user;

            Literal5.Text = Convert.ToString((DateTime.Now.Date - reg_date).Days);

            //Got access to the last User data and added it to the admin dashboard

            string second_last_user = "";
            string qry1 = "SELECT * FROM user_details WHERE id=(SELECT max(id)-1 FROM user_details)";
            cm1 = new SqlCommand(qry1, con);
            sdr2 = cm1.ExecuteReader();
            DateTime reg_date1 = DateTime.Now;

            while (sdr2.Read())
            {
                second_last_user = sdr2["name"].ToString();
                reg_date1 = Convert.ToDateTime(sdr2["date"]).Date;
            }
            Literal6.Text = second_last_user;

            Literal7.Text = Convert.ToString((DateTime.Now.Date - reg_date1).Days);

        }
        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["admin"] = "";

            Response.Redirect("login.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "select * from user_details";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                sendml(TextBox1.Text, sdr["email"].ToString());
            }
            TextBox1.Text = "";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "select * from admin";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                sendml(TextBox2.Text, sdr["admin"].ToString());
            }
            TextBox2.Text = "";
        }
        public void sendml(string mssg,string email)
        {
            string em = Convert.ToString(Session["user_email"]);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("unverctiyincanada1323@gmail.com", "#####12Pr");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Important Message";
            msg.Body =  mssg;
            string toadd = email;
            msg.To.Add(toadd);
            string frmadd = "bca48sem5ddu@gmail.com";
            msg.From = new MailAddress(frmadd);
            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {
                sendml(mssg, email);
            }
        }
    }
}