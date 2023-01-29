using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace my_scrapper
{
    public partial class free_trial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] != null && Session["user_email"].ToString() != "")
            {
                Literal1.Text = Literal2.Text = Literal3.Text = "";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
                string em = Convert.ToString(Session["user_email"]);
                int id;
                string qry = "select * from user_details where email='" + em + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    id = Convert.ToInt32(sdr["id"].ToString());
                    Literal4.Text = sdr["company_name"].ToString();
                    sdr.Close();
                    qry = "select * from url_keyword where id =" + id;
                    cmd = new SqlCommand(qry, con);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        url.Text = sdr["url"].ToString();
                        url.ReadOnly = true;
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user_panel.aspx");
        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["user_email"] = "";

            Response.Redirect("login.aspx");
        }

        protected void check_Click(object sender, EventArgs e)
        {
            scrip(true,true,true,0,0,0);    
        }

        public void scrip(bool go,bool bi,bool ya,int ig,int ib,int iy)
        {
            bool g=go, b=bi, y=ya;
            int int_g = ig, int_b = ib, int_y = iy;
            string s1 = url.Text;
            string s2 = kw1.Text;
            ChromeOptions op = new ChromeOptions();
            op.AddArguments("--headless" , "--disable - gpu", "--window - size = 1920, 1200","--ignore - certificate - errors","--disable - extensions","--no - sandbox","--disable - dev - shm - usage");
            IWebDriver driver = new ChromeDriver();
            try
            {
                
                if (g==true && int_g<2)
                {
                    driver.Navigate().GoToUrl("https://www.google.com");
                    var element = driver.FindElement(By.XPath("//input[@title='Search']"));
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

                            if (disp_url.Text.Contains(s1))
                            {
                                Literal1.Text = "Found on Page:1 as Result No: " + rc + " On Google ";
                                google_flag1 = false;
                            }
                            rc++;
                            ac++;
                        }
                        if (ac >= 10)
                        {
                            break;
                        }
                    }
                    if (google_flag1 == false)
                    {
                        g = false;
                        goto done;
                    }

                    while (google_flag2)
                    {

                        rc = 1;
                        driver.FindElement(By.XPath("//a[@aria-label=\'Page " + pg++ + "\']")).Click();
                        if (pg > 10)
                        {
                            Literal1.Text = "Not Found in First 10 pages in google";
                            break;
                        }
                        else
                        {
                            foreach (var disp_url2 in driver.FindElements(By.CssSelector("div[class='TbwUpd NJjxre']")))
                            {
                                if (disp_url2.Text.Contains(s1))
                                {
                                    int p = pg - 1;
                                    Literal1.Text = "Found on Page:" + p + " as Result No: " + rc + " On Google ";
                                    google_flag2 = false;
                                    break;
                                }
                                rc++;
                            }
                            if (google_flag2 == false)
                            {
                                break;
                            }
                        }
                    }
                    g = false;
                done:;
                }
                if (b==true && int_b<4)
                {
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
                        b = false;
                        goto done1;
                    }
                    while (bing_flag2)
                    {
                        rc1 = 1;
                        driver.FindElement(By.XPath("//a[normalize-space()=\'" + pg1++ + "\']")).Click();
                        if (pg1 > 10)
                        {
                            Literal2.Text = "Not Found in First 10 pages in bing";
                            break;
                        }
                        else
                        {
                            foreach (var bing_url2 in driver.FindElements(By.CssSelector("div[class='b_caption']")))
                            {
                                if (bing_url2.Text.Contains(s1))
                                {
                                    int p = pg1 - 1;
                                    Literal2.Text = "Found on Page:" + p + " as Result No: " + rc1 + " On Bing ";
                                    bing_flag2 = false;
                                    break;
                                }
                                rc1++;
                            }
                            if (bing_flag2 == false)
                            {
                                break;
                            }
                        }
                    }
                    b = false;
                done1:;
                }
                if (y==true && int_y<6)
                {
                    driver.Navigate().GoToUrl("https://in.search.yahoo.com/");
                    var search_bar_yahoo = driver.FindElement(By.XPath("//*[@id=\"yschsp\"]"));
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
                        y = false;
                        goto done2;
                    }
                    while (yahoo_flag2)
                    {

                        rc2 = 1;

                        driver.FindElement(By.XPath("//a[normalize-space()=\'" + pg2++ + "\']")).Click();
                        if (pg2 > 10)
                        {
                            Literal3.Text = "Not Found in First 10 pages in yahoo";
                            break;
                        }
                        else
                        {
                            foreach (var yahoo_url2 in driver.FindElements(By.CssSelector("div[class='compTitle options-toggle")))
                            {
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
                    }
                    b = false;
                done2:;
                }
                driver.Close();
            }
            catch (Exception)
            {
                driver.Close();
                scrip(g, b, y,++int_g,++int_b,++int_y);
                if(int_y>=6)
                    Literal1.Text = "Something went wrong please try again later";
            }
            if(g)
                Literal1.Text = "Not Found in First 10 pages in google";
            if(b)
                Literal2.Text = "Not Found in First 10 pages in bing";
            if(y)
                Literal3.Text = "Not Found in First 10 pages in yahoo";
        }
    }
}