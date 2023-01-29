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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            try
            {
                string uid = txtemail.Text;
                //string pass = psw.Text;
                con.Open();
                string qry = "select * from user_details where email='" + uid + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    literal1.Text = "This Email Id is already registred with us. Please use another one";
                }
                else
                {
                    Cache["txtname"] = txtname.Text;
                    Cache["pass"] = password.Text;
                    Cache["txtcompany_name"] = txtcompany_name.Text;
                    Cache["txtemail"] = txtemail.Text;
                    Cache["gender"] = gender.SelectedItem.Value.ToString();
                    Cache["txtctno"] = txtctno.Text;
                    Response.Redirect("~/price.aspx");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           
            
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}