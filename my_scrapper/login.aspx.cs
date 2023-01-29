using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace my_scrapper
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal1.Text = "";
        }

        protected void login_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            SqlCommand cm1;
            con.Open();
            //cm1 = new SqlCommand("insert into user_details values(@id,@psw,@name,@company_name,@email,@gender,@contact)", con);
            string s = "select* from user_details where email = " + email.Text;
            cm1 = new SqlCommand(s,con);
            cm1.ExecuteNonQuery();*/
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            try
            {
                string uid = email.Text;
                string pass = psw.Text;
                /*if (uid.Contains("darshantalpada12@gmail.com") && pass.Contains("deadpool77"))
                {
                    Response.Redirect("~/admin_panel.aspx");
                }
                else
                {*/
                    con.Open();
                string qry = "select * from admin where email='" + uid + "' and password='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Session["admin"] = email.Text;
                    Response.Redirect("~/admin_panel.aspx");
                }
                else
                {
                    sdr.Close();
                    //Literal1.Text = "UserId or Password Is not correct Try again..!!";
                    qry = "select * from user_details where email='" + uid + "' and password='" + pass + "'";
                    cmd = new SqlCommand(qry, con);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        Session["user_email"] = email.Text;
                        Session["user_plan"] = sdr["plan_type"].ToString();
                        Response.Redirect("~/user_panel.aspx");
                    }
                    else
                    {
                        Literal1.Text = "User Email or Password Is not correct Try again..!!";
                    }
                }
                con.Close();
                //}
            }
            catch (Exception ex)
            {
                Literal1.Text = "Invalid user email or password";
            }
        }
    }
}