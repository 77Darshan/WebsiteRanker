using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;

namespace my_scrapper
{
    public partial class forget_psw : System.Web.UI.Page
    {
        int n = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal1.Text = "";
            otp.Visible = false;
            sub.Visible = false;
            new_password.Visible = false;
            update.Visible = false;
            email.Visible = true;
            submit.Visible = true;
            Literal2.Visible = false;
        }

        
        protected void submit_Click(object sender, EventArgs e)
        {
            //Label8.Text = "OTP Sent to your email address";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            try
            {
                string uid = email.Text;
                //string pass = psw.Text;
                con.Open();
                string qry = "select * from user_details where email='" + uid + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string iid = sdr["id"].ToString();
                    otp.Visible = true;
                    sub.Visible = true;
                    Literal2.Visible = true;
                    new_password.Visible = false;
                    update.Visible = false;
                    email.Visible = false;
                    submit.Visible = false;
                    sendml(iid);
                    Literal2.Text = "An Otp is Sent to your EmailId";
                }
                else
                {
                    Literal1.Text = "Please Enter valid EmailId";

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
        }

        protected void otp_Click(object sender, EventArgs e)
        {
            int i = int.Parse(otp.Text);
            int OTP = Convert.ToInt32(Session["VerifyOTP"]);
            if (i == OTP)
            {
                otp.Visible = false;
                sub.Visible = false;
                new_password.Visible = true;
                update.Visible = true;
                email.Visible = false;
                submit.Visible = false;
            }
            else
            {
                Literal1.Text = "Invalid OTP";
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            try
            {
                //SqlDataReader sdr;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                string url = Convert.ToString(Cache["eemail"]);
                //string uid = email.Text;
                //string pass = psw.Text;

                //string qry = "select * from user_details where email='" + uid + "'";
                //string qry= "UPDATE user_detail(id,psw,name,company_name,email,gender,contact) VALUES(@id,@psw,@name,@company_name,@email,@gender,@contact) WHERE email = '" + eemail + "' AND psw='" + passwordd + "'";
                //string qry = "UPDATE user_details SET psw = '" + new_password.Text + "' where id=2";//" + url;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "UPDATE user_details SET password = '" + new_password.Text + "' where id="+ url;
                if (cmd.ExecuteNonQuery() != 0)
                {
                    Response.Redirect("https://localhost:44353/login.aspx");
                }
                /*SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Response.Redirect("https://localhost:44353/login.aspx");
                }*/
                /*else
                {
                    Literal1.Text = "Please Enter valide Email";

                }*/
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void sendml(string id)
        {
            Otp ob = new Otp();
            Session["VerifyOTP"] = n = ob.gen_otp();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("unverctiyincanada1323@gmail.com", "#####12Pr");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Your generated OTP for form";
            msg.Body = "Your OTP is " + n + "to submit form enter this OTP.";
            string toadd = email.Text;
            msg.To.Add(toadd);
            string frmadd = "unverctiyincanada1323@gmail.com";
            msg.From = new MailAddress(frmadd);
            try
            {
                smtp.Send(msg);
                Cache["eemail"] = id;
            }
            catch (Exception)
            {
                sendml(id);
            }
        }
        public class Otp
        {
            public int gen_otp()
            {
                Random otp = new Random();
                int num = otp.Next(10000, 99999);
                return num;
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}