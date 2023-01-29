using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace my_scrapper
{

    public partial class Payment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string sess_trail = Convert.ToString(Session["btn_trail"]);
            string sess_basic = Convert.ToString(Session["btn_basic"]);
            string sess_prem = Convert.ToString(Cache["btn_premium"]);

            

            //Txtkey1.Text = Session["btn_trail"].ToString();
            if (Session["btn_trail"]!=null && Session["btn_trail"].ToString()==sess_trail)
            {
                /*lblurl2.Visible = false;
                txturl2.Visible = false;

                lblurl3.Visible = false;
                txturl3.Visible = false;*/
                //--------------xx--------------------x------------------x---------------x
                //L2.Visible = false;
                Txtkey2.Visible = false;
                //L3.Visible = false;
                Txtkey3.Visible = false;
                btn_pay_basic.Visible = false;
                btn_pay_prem.Visible = false;
                pay_ver.Visible = false;
                Button1.Visible = false;
                /*L4.Visible = false;
                Txtkey4.Visible = false;
                L5.Visible = false;
                Txtkey5.Visible = false;*/
                goto basic;
            }
            else if(Session["btn_basic"] != null && Session["btn_basic"].ToString()==sess_basic)
            {
                /*lblurl2.Visible = false;
                txturl2.Visible = false;

                lblurl3.Visible = false;
                txturl3.Visible = false;*/

                //L3.Visible = false;
                Txtkey3.Visible = false;
                btn_pay.Visible = false;
                btn_pay_prem.Visible = false;
                pay_ver.Enabled = false;
                Button1.Enabled = false;
                /*L4.Visible = false;
                Txtkey4.Visible = false;
                L5.Visible = false;
                Txtkey5.Visible = false;*/
                goto basic;
            }

                /*pay_ver.Visible = false;
                Button1.Visible = false;*/
                btn_pay_basic.Visible = false;
                btn_pay.Visible = false;
                pay_ver.Enabled = false;
                Button1.Enabled = false;


        basic:;

        }
       
        protected void btn_pay_Click(object sender, EventArgs e)
        {
            Literal1.Text = Literal2.Text = Literal3.Text = "";
            string sess_trail_pay = Convert.ToString(Session["btn_trail"]);
            //string sess_premium_pay = Convert.ToString(Session["btn_basic"]);
            
            if (Session["btn_trail"] != null && Session["btn_trail"].ToString() == sess_trail_pay)
            {
                //System.Threading.Thread.Sleep(5000);
                string s1 = txturl1.Text;
                //string[] pf = s1.ToString().Split('.');

                string s2 = Txtkey1.Text;
                //string s = "com";
                try
                {
                    ChromeOptions hless = new ChromeOptions();
                    hless.AddArgument("--headless");
                    IWebDriver driver = new ChromeDriver();

                    driver.Navigate().GoToUrl("https://www.google.com");
                    //original/traditional way     //var element = driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[2]/input"));
                    var element = driver.FindElement(By.XPath("//input[@title='Search']"));
                    //var element = driver.FindElement(By.ClassName("LC20lb DKV0Md"));
                    element.SendKeys(s2);
                    element.Submit();
                    int rc = 1;
                    int pg = 2;
                    bool google_flag1 = true;
                    bool google_flag2 = true;
                    int ac = 1;
                    while (google_flag1)
                    {
                        foreach (var disp_url in driver.FindElements(By.CssSelector("div[class='TbwUpd NJjxre']")))
                        {

                            //rc++;
                            // if (disp_url.Text ==  driver.FindElement(By.XPath(".//cite[text()='" + s1 + "']")).Text)
                            if (disp_url.Text.Contains(s1))
                            {

                                Literal1.Text = "Found on Page:1 as Result No: " + rc + " On Google  ";
                                google_flag1 = false;

                            }


                            rc++;

                            // string[] pf = disp_url.Text.ToString().Split('>');
                            // ListBox1.Items.Add(pf[0].ToString());
                            //ListBox1.Items.Add(disp_url.Text);
                            /*int a=ListBox1.Items.Count;*/
                            ac++;
                        }
                        if (ac >= 10)
                        {
                            break;
                        }
                    }
                    if (google_flag1 == false)
                    {
                        goto done;
                    }

                    while (google_flag2)
                    {

                        rc = 1;
                        driver.FindElement(By.XPath("//a[@aria-label=\'Page " + pg++ + "\']")).Click();
                        foreach (var disp_url2 in driver.FindElements(By.CssSelector("div[class='TbwUpd NJjxre']")))
                        {
                            // if (disp_url2.Text == driver.FindElement(By.XPath(".//cite[text()='" + s1 + "']")).Text)
                            if (disp_url2.Text.Contains(s1))
                            {
                                int p = pg - 1;
                                Literal1.Text = "Found on Page:" + p + " as Result No: " + rc + " On Google  ";
                                google_flag2 = false;
                                break;
                            }
                            //ListBox1.Items.Clear();
                            // string[] pf = disp_url2.Text.ToString().Split('>');
                            //ListBox1.Items.Add(pf[0].ToString());
                            // ListBox1.Items.Add(disp_url2.Text);

                            rc++;
                        }
                        if (google_flag2 == false)
                        {
                            break;
                        }
                    }
                done:;
                    // Literal1.Text = "Done";

                    /*Code for Bing starts here*/

                    driver.Navigate().GoToUrl("https://www.bing.com");
                    var search_bar_bing = driver.FindElement(By.XPath("//*[@id=\"sb_form_q\"]"));
                    search_bar_bing.SendKeys(s2);
                    search_bar_bing.Submit();
                    int rc1 = 1;
                    int pg1 = 2;
                    bool bing_flag1 = true;
                    bool bing_flag2 = true;
                    int ac1 = 1;
                    while (bing_flag1)
                    {
                        foreach (var bing_url in driver.FindElements(By.CssSelector("div[class='b_caption']")))
                        {
                            if (bing_url.Text.Contains(s1))
                            //if (bing_url.Text.Contains(pf[1][2]))
                            {
                                Literal2.Text = "Found on Page:1 as Result No: " + rc1 + " On Bing ";
                                bing_flag1 = false;

                            }
                            rc1++;
                            ac1++;
                        }
                        if (ac1 >= 10)
                        {
                            break;
                        }
                    }
                    if (bing_flag1 == false)
                    {
                        goto done1;
                    }
                    while (bing_flag2)
                    {

                        rc1 = 1;

                        // driver2.FindElement(By.XPath("//a[@aria-label=\'Page " + pg1++ + "\']")).Click();
                        driver.FindElement(By.XPath("//a[normalize-space()=\'" + pg1++ + "\']")).Click();
                        foreach (var bing_url2 in driver.FindElements(By.CssSelector("div[class='b_caption']")))
                        {
                            // if (disp_url2.Text == driver.FindElement(By.XPath(".//cite[text()='" + s1 + "']")).Text)
                            if (bing_url2.Text.Contains(s1))
                            //if (bing_url2.Text.Contains(pf[1]))
                            {
                                int p = pg1 - 1;
                                Literal2.Text = "Found on Page:" + p + " as Result No: " + rc1 + " On Bing ";
                                bing_flag2 = false;
                                break;
                            }
                            //ListBox1.Items.Clear();
                            // string[] pf = disp_url2.Text.ToString().Split('>');
                            //ListBox1.Items.Add(pf[0].ToString());
                            // ListBox1.Items.Add(disp_url2.Text);

                            rc1++;
                        }
                        if (bing_flag2 == false)
                        {
                            break;
                        }
                    }
                done1:;
                    //Literal1.Text = "Done";

                    /*Code for Yahoo starts here*/



                    driver.Navigate().GoToUrl("https://in.search.yahoo.com/");
                    var search_bar_yahoo = driver.FindElement(By.XPath("//*[@id=\"yschsp\"]"));
                    //var search_bar_yahoo = driver3.FindElement(By.Id("yschsp"));
                    search_bar_yahoo.SendKeys(s2);
                    search_bar_yahoo.Submit();
                    int rc2 = 1;
                    int pg2 = 2;
                    bool yahoo_flag1 = true;
                    bool yahoo_flag2 = true;
                    int ac2 = 1;
                    while (yahoo_flag1)
                    {
                        foreach (var yahoo_url in driver.FindElements(By.CssSelector("div[class='compTitle options-toggle'")))
                        {
                            if (yahoo_url.Text.Contains(s1))
                            {
                                Literal3.Text = "Found on Page:1 as Result No: " + rc2 + " On Yahoo ";
                                yahoo_flag1 = false;

                            }
                            rc2++;
                            ac2++;
                        }
                        if (ac2 >= 10)
                        {
                            break;
                        }
                    }
                    if (yahoo_flag1 == false)
                    {
                        goto done2;
                    }
                    while (yahoo_flag2)
                    {

                        rc2 = 1;

                        // driver2.FindElement(By.XPath("//a[@aria-label=\'Page " + pg1++ + "\']")).Click();
                        //a[normalize-space()='3']
                        driver.FindElement(By.XPath("//a[normalize-space()=\'" + pg2++ + "\']")).Click();
                        //driver3.FindElement(By.LinkText( pg2++.ToString() )).Click();
                        foreach (var yahoo_url2 in driver.FindElements(By.CssSelector("div[class='compTitle options-toggle")))
                        {
                            // if (disp_url2.Text == driver.FindElement(By.XPath(".//cite[text()='" + s1 + "']")).Text)
                            if (yahoo_url2.Text.Contains(s1))
                            {
                                int p = pg2 - 1;
                                Literal3.Text = "Found on Page:" + p + " as Result No: " + rc2 + " On Yahoo ";
                                yahoo_flag2 = false;
                                break;
                            }


                            rc2++;
                        }
                        if (yahoo_flag2 == false)
                        {
                            break;
                        }
                    }
                done2:;
                    // Literal1.Text = "Done";
                    //-----------------------------------------------DUCK DUCK GO----------------------------
                    //ChromeOptions hless3 = new ChromeOptions();
                    //hless3.AddArgument("--headless");





                }
                catch (Exception)
                {
                    Literal1.Text = "Not Found As Top Result ";
                }
                
            }
             /*  if (Session["btn_trail"] != null && Session["btn_trail"].ToString() == sess_trail_pay)  if (Session["btn_trail"] != null && Session["btn_trail"].ToString() == sess_trail_pay)
                {
                //Session["payment_trail"] = true;
                Session["payment_trail"] = "done_trail";
                Cache["txturl"] = txturl1.Text;
                Cache["keyword1"] = Txtkey1.Text;
                *//* System.Text.StringBuilder url = new System.Text.StringBuilder();
                 string paypalBaseUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                 url.Append(paypalBaseUrl + "?cmd=_xclick&business=" + HttpUtility.UrlEncode("darshan.deadpool7@gmail.com"));
                 //url.AppendFormat("&first_name={0}", "ABC");
                 //url.AppendFormat("&last_name={0}", "XYZ");
                 url.AppendFormat("&item_name={0}", "Trail Version");
                 url.AppendFormat("&amount={0}", "1");
                 url.AppendFormat("&rm={0}", "2");
                 url.AppendFormat("&currency_code={0}", "INR");
                 url.AppendFormat("&return={0}", HttpUtility.UrlEncode("https://localhost:44353/Thankyou.aspx"));
                 Response.Redirect(url.ToString());*//*
                Response.Redirect("~/Thankyou.aspx");
               
            }*/

            /* else if(Session["btn_basic"] != null && Session["btn_basic"].ToString() == sess_premium_pay)
            {*/
                /*Cache["payment_basic"] = "done_basic";
                Cache["txturl"] = txturl1.Text;
                Cache["keyword1"] = Txtkey1.Text;
                Cache["keyword2"] = Txtkey2.Text;*/

                /*System.Text.StringBuilder url = new System.Text.StringBuilder();
                string paypalBaseUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";
     

                url.Append(paypalBaseUrl + "?cmd=_xclick&business=" + HttpUtility.UrlEncode("darshan.deadpool7@gmail.com"));
                //url.AppendFormat("&first_name={0}", "ABC");
                //url.AppendFormat("&last_name={0}", "XYZ");
                url.AppendFormat("&item_name={0}", " Basic Version");
                url.AppendFormat("&amount={0}", "3499");
                url.AppendFormat("&rm={0}", "2");
                url.AppendFormat("&currency_code={0}", "INR");
                url.AppendFormat("&return={0}", HttpUtility.UrlEncode("https://localhost:44353/Thankyou.aspx"));*/

               // Response.Redirect("https://rzp.io/l/coorHKw0");

            //}
           // else
            //{

                // Session["payment_premium"] = true;


                /*Cache["payment_premium"] = "done_premium";
                Cache["txturl"] = txturl1.Text;
                Cache["keyword1"] = Txtkey1.Text;
                Cache["keyword2"] = Txtkey2.Text;
                Cache["keyword3"] = Txtkey3.Text;*/


               /* System.Text.StringBuilder url = new System.Text.StringBuilder();
                string paypalBaseUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                url.Append(paypalBaseUrl + "?cmd=_xclick&business=" + HttpUtility.UrlEncode("darshan.deadpool7@gmail.com"));
                //url.AppendFormat("&first_name={0}", "ABC");
                //url.AppendFormat("&last_name={0}", "XYZ");
                url.AppendFormat("&item_name={0}", " Premium Version");
                url.AppendFormat("&amount={0}", "4999");
                url.AppendFormat("&rm={0}", "2");
                url.AppendFormat("&currency_code={0}", "INR");
                
                url.AppendFormat("&return={0}", HttpUtility.UrlEncode("https://localhost:44353/Thankyou.aspx"));
                Response.Redirect(url.ToString());*/
               // Response.Redirect("https://rzp.io/l/k3hc11c");
           // }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int p = 0;
            p =Convert.ToInt32(pay_ver.Text);
            if(p == 5297)
            {
                Response.Redirect("~/Thankyou.aspx");
            }
        }

        protected void btn_pay_basic_Click(object sender, EventArgs e)
        {
            //string sess_premium_pay = Convert.ToString(Session["btn_basic"]);
            pay_ver.Enabled = true;
            Button1.Enabled = true;

            Cache["payment_basic"] = "done_basic";
                Cache["txturl"] = txturl1.Text;
                Cache["keyword1"] = Txtkey1.Text;
                Cache["keyword2"] = Txtkey2.Text;

            // Response.Redirect("https://rzp.io/l/coorHKw0");

            string url = "https://rzp.io/l/coorHKw0";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type= 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append(url);
            sb.Append("');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());

        }

        protected void btn_pay_prem_Click(object sender, EventArgs e)
        {
            pay_ver.Enabled = true;
            Button1.Enabled = true;
            Cache["payment_premium"] = "done_premium";
            Cache["txturl"] = txturl1.Text;
            Cache["keyword1"] = Txtkey1.Text;
            Cache["keyword2"] = Txtkey2.Text;
            Cache["keyword3"] = Txtkey3.Text;

            // Response.Redirect("https://rzp.io/l/k3hc11c");


            string url = "https://rzp.io/l/k3hc11c";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type= 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append(url);
            sb.Append("');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());
        }
    }
}