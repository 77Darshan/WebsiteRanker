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
    public partial class Thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            //bool payment_status = Convert.ToBoolean(Session["payment_status"]);
            string payment_trail = Convert.ToString(Session["payment_trail"]);
            string payment_basic = Convert.ToString(Cache["payment_basic"]);
            string payment_premium = Convert.ToString(Cache["payment_premium"]);
            string url = Convert.ToString(Cache["txturl"]);
            string keyword1 = Convert.ToString(Cache["keyword1"]);
            string keyword2 = Convert.ToString(Cache["keyword2"]);
            string keyword3 = Convert.ToString(Cache["keyword3"]);
            string name = Convert.ToString(Cache["txtname"]);
            string txtcompany_name = Convert.ToString(Cache["txtcompany_name"]);
            string pas = Convert.ToString(Cache["pass"]);
            string txtemail = Convert.ToString(Cache["txtemail"]);
            string gender = Convert.ToString(Cache["gender"]);
            string txtctno = Convert.ToString(Cache["txtctno"]);
            string p="";

            //user entry are submitted to database from here.
           
            /*cmd2 = new SqlCommand("insert into data values(@id,@url)", con);
            cmd2.Parameters.AddWithValue("@id", ++i);
            cmd2.Parameters.AddWithValue("@url", url);*/
            //cmd2.ExecuteNonQuery();
           /* cmd4 = new SqlCommand("Select COUNT(*) from data", con);
            c = Convert.ToInt32(cmd4.ExecuteScalar());*/

            
            //cmd2 = new SqlCommand("insert into url_keyword values(@keyword1,@keyword2,@keyword3)",con);
           /* if (Session["payment_trail"]!=null && Session["payment_trail"].ToString()== "done_trail")
            {
                cmd1 = new SqlCommand("insert into iuk ([id],[url],[kw1]) values(@id,@url,@kw1)", con);
                cmd1.Parameters.AddWithValue("@id", ++i);
                cmd1.Parameters.AddWithValue("@url", url);
                
                cmd1.Parameters.AddWithValue("@kw1", keyword1);
               *//* cmd1.Parameters.AddWithValue("@keyword2", null);
                cmd1.Parameters.AddWithValue("@keyword3", null);*//*
                cmd1.ExecuteNonQuery();
                Label1.Text = "From Trail";
                //Response.Redirect("~/auto.aspx");
                //Session["payment_trail"] = null;
            }*/
             if(Cache["payment_basic"] != null && Cache["payment_basic"].ToString() == "done_basic")
            {
                int z = 0;
                p = "B";
                SqlCommand cm1, cm2;
                con.Open();

                cm2 = new SqlCommand("Select max(id) from user_details", con);
                z = Convert.ToInt32(cm2.ExecuteScalar());
                cm1 = new SqlCommand("insert into user_details values(@id,@password,@name,@company_name,@email,@gender,@contact,@plan_type,@date)", con);
                cm1.Parameters.AddWithValue("@id", ++z);
                cm1.Parameters.AddWithValue("@password", pas);
                cm1.Parameters.AddWithValue("@name", name);
                cm1.Parameters.AddWithValue("@company_name", txtcompany_name);
                cm1.Parameters.AddWithValue("@email", txtemail);
                cm1.Parameters.AddWithValue("@gender", gender);
                cm1.Parameters.AddWithValue("@contact", txtctno);
                cm1.Parameters.AddWithValue("@plan_type", p);
                cm1.Parameters.AddWithValue("@date",DateTime.Now);
                cm1.ExecuteNonQuery();

                // string st = "";
                SqlCommand cmd1, cmd3;
                int i = 0;
                int c = 0;

                cmd3 = new SqlCommand("Select max (id) from url_keyword", con);
                i = Convert.ToInt32(cmd3.ExecuteScalar());
                cmd1 = new SqlCommand("insert into url_keyword ([id],[url],[kw1],[kw2]) values(@id,@url,@kw1,@kw2)", con);
                //cmd1 = new SqlCommand("insert into keyword_tbl values(@id,@keyword1,@keyword2,@keyword3)", con);
                cmd1.Parameters.AddWithValue("@id", ++i);
                cmd1.Parameters.AddWithValue("@url", url);
                cmd1.Parameters.AddWithValue("@kw1", keyword1);
                cmd1.Parameters.AddWithValue("@kw2", keyword2);
                //cmd1.Parameters.AddWithValue("@keyword3", null);
                cmd1.ExecuteNonQuery();
                Label1.Text = "Basic";
                //Response.Redirect("~/auto.aspx");
                // Cache["payment_basic"] = "";
            }
            else if(Cache["payment_premium"] != null && Cache["payment_premium"].ToString() == "done_premium")
            {
                int z = 0;
                SqlCommand cm1, cm2;
                con.Open();
                p = "P";
                cm2 = new SqlCommand("Select max(id) from user_details", con);
                z = Convert.ToInt32(cm2.ExecuteScalar());
                cm1 = new SqlCommand("insert into user_details values(@id,@password,@name,@company_name,@email,@gender,@contact,@plan_type,@date)", con);
                cm1.Parameters.AddWithValue("@id", ++z);
                
                cm1.Parameters.AddWithValue("@password", pas);
                cm1.Parameters.AddWithValue("@name", name);
                cm1.Parameters.AddWithValue("@company_name", txtcompany_name);
                cm1.Parameters.AddWithValue("@email", txtemail);
                cm1.Parameters.AddWithValue("@gender", gender);
                cm1.Parameters.AddWithValue("@contact", txtctno);
                cm1.Parameters.AddWithValue("@plan_type", p);
                cm1.Parameters.AddWithValue("@date", DateTime.Now);
                cm1.ExecuteNonQuery();

                // string st = "";
                SqlCommand cmd1, cmd3;
                int i = 0;
                int c = 0;

                cmd3 = new SqlCommand("Select max (id) from url_keyword", con);
                i = Convert.ToInt32(cmd3.ExecuteScalar());
                cmd1 = new SqlCommand("insert into url_keyword values(@id,@url,@kw1,@kw2,@kw3)", con);
                // cmd1.Parameters.AddWithValue("@id", ++i);
                cmd1.Parameters.AddWithValue("@id", ++i);
                cmd1.Parameters.AddWithValue("@url", url);
                cmd1.Parameters.AddWithValue("@kw1", keyword1);
                cmd1.Parameters.AddWithValue("@kw2", keyword2);
                cmd1.Parameters.AddWithValue("@kw3", keyword3);
                cmd1.ExecuteNonQuery();
                Label1.Text = "Premium";
                //Response.Redirect("~/auto.aspx");
                //Cache["payment_premium"] = null;
            }
            con.Close();
            Session["plan"] = p.ToString();
            
        }
        

    }
}