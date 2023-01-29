using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace my_scrapper
{
    public partial class price : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                //Session["payment_status"] = false;
        }
        /*string sess1 = "clicked_trail";
        string sess2 = "clicked_basic";*/
        protected void btn_trail_Click(object sender, EventArgs e)
        {

            Session["btn_trail"] = "clicked_trail";
            Session["btn_basic"] = null;
            Cache["btn_premium"] = "";

            //string fname = Session["txtname"].ToString();
            //string cname = Session["txtcompany_name"].ToString();
            //string a = (Session["p"].ToString());
            Response.Redirect("https://localhost:44353/Add_info.aspx");


            // Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=darshan.deadpool7@gmail.com&item_name=Trail_Version&amount="+Session["p"]+"&currency_code=USD&return=https://localhost:44353/Payment.aspx");
        }

        protected void btn_premium_Click(object sender, EventArgs e)
        {
            Session["btn_trail"] = null;
            Session["btn_basic"] = null;
            Cache["btn_premium"] = "clicked_premium";
            Response.Redirect("https://localhost:44353/Add_info.aspx");
        }

        protected void btn_basic_Click(object sender, EventArgs e)
        {
            Session["btn_basic"] = "clicked_basic";
            Session["btn_trial"] = null;
            Cache["btn_premium"] = "";
            Response.Redirect("https://localhost:44353/Add_info.aspx");
          
        }
    }
}