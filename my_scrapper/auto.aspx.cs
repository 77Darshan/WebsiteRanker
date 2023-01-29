using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Net.Mail;
using System.Net;
using System.Timers;
namespace my_scrapper
{
    public partial class auto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*ChromeOptions op = new ChromeOptions();
            op.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver();*/
            /*int p = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select max (id) from iuk", con);
            con.Open();
            p = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();*/
            getdata();

            //Forfun(3);
            /*scrip("www.bmw.com", "bmw");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 120000;//7 days conversion on milisecound 604800000
            timer.Elapsed += tm_Tick;
            timer.Enabled = true;*/
        }
        void tm_Tick(object sender, ElapsedEventArgs e)
        {
            // Forfun(3);
            //scrip("www.bmw.com", "bmw");
        }
        public void getdata()
        {
            int p = 0, s = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("select min (id) from url_keyword", con);
            con.Open();
            p = Convert.ToInt32(cmd.ExecuteScalar());
            cmd = new SqlCommand("select max (id) from url_keyword", con);
            s = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            for (int j = p; j <= s; j++)
            {
                string uurl = null, kw1 = null, kw2 = null, kw3 = null;
                /* SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
                 SqlCommand cmd = new SqlCommand();*/
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlDataReader dr;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from url_keyword where id=" + j;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    uurl = dr["url"].ToString();
                    kw1 = dr["kw1"].ToString();
                    kw2 = dr["kw2"].ToString();
                    kw3 = dr["kw3"].ToString();

                }
                con.Close();
                if (kw2 == "" && kw3 == "")
                {
                    Forfun(uurl, kw1);
                }
                else if (kw3 == "")
                {
                    Forfun(uurl, kw1, kw2);
                }
                else if (uurl == null)
                { }
                else
                {
                    Forfun(uurl, kw1, kw2, kw3);
                }
            }
        }

        public void Forfun(string u, string k1)
        {
            scrip(u, k1,true,true,true);
        }
        public void Forfun(string u, string k1, string k2)
        {
            int i = 0;
            bool g = true, b = true, y = true;
            for (i = 1; i <= 2; i++)
            {
                if (i == 1)
                {
                    scrip(u, k1, g, b, y);
                }
                else
                {
                    scrip(u, k2, g, b, y);
                }
            }

        }
        public void Forfun(string u, string k1, string k2, string k3)
        {
            int i = 0;
            bool g = true, b = true, y = true;
            for (i = 1; i <= 3; i++)
            {
                if (i == 1)
                {
                    scrip(u, k1, g, b, y);
                }
                else if (i == 2)
                {
                    scrip(u, k2, g, b, y);
                }
                else
                {
                    scrip(u, k3, g, b, y);
                }
            }
        }

        public void scrip(string url, string keyword, bool g, bool b, bool y)
        {
            bool google = g, bing = b, yahoo = y;
            string s1 = url;
            string s2 = keyword;
            int s3 = 0, s4 = 0, s5 = 0, s6 = 0, s7 = 0, s8 = 0;
            ChromeOptions op = new ChromeOptions();
            op.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver();
            if (google == true)
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.google.com");
                    var element = driver.FindElement(By.XPath("//*[@title='Search']"));
                    element.SendKeys(s2);
                    element.Submit();
                    //string s = "page and result";
                    int rc = 1;
                    int pg = 2;
                    bool flag = true;
                    bool flag2 = true;
                    int ac = 1;
                    while (flag)
                    {
                        foreach (var disp_url in driver.FindElements(By.CssSelector("div[class='TbwUpd NJjxre']")))
                        {
                            if (disp_url.Text.Contains(s1))
                            {
                                s3 = 1;
                                s4 = rc;
                                //Literal1.Text =s3+s+s4;
                                flag = false;
                            }
                            rc++;
                            ac++;
                        }
                        if (ac >= 10)
                        {
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        google = false;
                        goto done;
                    }
                    while (flag2)
                    {
                        rc = 1;
                        driver.FindElement(By.XPath("//a[@aria-label=\'Page " + pg++ + "\']")).Click();
                        if (pg > 10)
                        {
                            break;
                        }
                        else
                        {
                            foreach (var disp_url2 in driver.FindElements(By.CssSelector("div[class='TbwUpd NJjxre']")))
                            {
                                if (disp_url2.Text.Contains(s1))
                                {
                                    int p = pg - 1;
                                    s3 = p;
                                    s4 = rc;
                                    //Literal1.Text = s3 + s + s4;
                                    flag2 = false;
                                    break;
                                }
                                rc++;
                            }
                            if (flag2 == false)
                            {
                                break;
                            }
                            //Literal1.Text = "web site is not in first 15 pages";
                        }
                    }
                    google = false;
                done:;
                }
                catch (Exception e)
                {
                    google = true;
                    scrip(url, keyword, google, bing, yahoo);
                }
            }
            if (bing == true)
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.bing.com/");
                    var element = driver.FindElement(By.XPath("//*[@id=\"sb_form_q\"]"));
                    element.SendKeys(s2);
                    element.Submit();
                    int rc1 = 1;
                    int pg1 = 2;
                    bool bflag = true;
                    bool bflag2 = true;
                    int ac1 = 1;
                    while (bflag)
                    {
                        foreach (var bing_url in driver.FindElements(By.CssSelector("div[class='b_caption']")))
                        {
                            if (bing_url.Text.Contains(s1))
                            {
                                s5 = 1;
                                s6 = rc1;
                                //Literal2.Text =s5+s+s6;
                                bflag = false;
                            }
                            rc1++;
                            ac1++;
                        }
                        if (ac1 >= 10)
                        {
                            break;
                        }
                    }
                    if (bflag == false)
                    {
                        bing = false;
                        goto done1;
                    }
                    while (bflag2)
                    {
                        rc1 = 1;
                        driver.FindElement(By.XPath("//a[normalize-space()=\'" + pg1++ + "\']")).Click();
                        if (pg1 > 10)
                        {
                            break;
                        }
                        else
                        {
                            foreach (var bing_url2 in driver.FindElements(By.CssSelector("div[class='b_caption']")))
                            {
                                if (bing_url2.Text.Contains(s1))
                                {
                                    int p1 = pg1 - 1;
                                    s5 = p1;
                                    s6 = rc1;
                                    //Literal2.Text = s5+s+s6;
                                    bflag2 = false;
                                    break;
                                }
                                rc1++;
                            }
                            if (bflag2 == false)
                            {
                                break;
                            }
                            //Literal2.Text = "web site is not in first 15 pages bing";
                        }
                    }
                    bing = false;
                done1:;
                }
                catch (Exception r)
                {
                    bing = true;
                    scrip(url, keyword, google, bing, yahoo);
                }
            }
            if (yahoo == true)
            {
                try
                {
                    driver.Navigate().GoToUrl("https://in.search.yahoo.com/");
                    var element = driver.FindElement(By.XPath("//*[@id=\"yschsp\"]"));
                    element.SendKeys(s2);
                    element.Submit();
                    int rc2 = 1;
                    int pg2 = 2;
                    bool yflag = true;
                    bool yflag2 = true;
                    int ac2 = 1;
                    while (yflag)
                    {
                        foreach (var yahoo_url in driver.FindElements(By.CssSelector("div[class='compTitle options-toggle'")))
                        {
                            if (yahoo_url.Text.Contains(s1))
                            {
                                s7 = 1; s8 = rc2;
                                //Literal3.Text = s7+s+s8;
                                yflag = false;
                            }
                            rc2++;
                            ac2++;
                        }
                        if (ac2 >= 10)
                        {
                            break;
                        }
                    }
                    if (yflag == false)
                    {
                        yahoo = false;
                        goto done2;
                    }
                    while (yflag2)
                    {
                        rc2 = 1;
                        driver.FindElement(By.XPath("//a[normalize-space()=\'" + pg2++ + "\']")).Click();
                        if (pg2 > 10)
                        {
                            break;
                        }
                        else
                        {
                            foreach (var yahoo_url2 in driver.FindElements(By.CssSelector("div[class='compTitle options-toggle'")))
                            {
                                if (yahoo_url2.Text.Contains(s1))
                                {
                                    int p2 = pg2 - 1;
                                    s7 = p2; s8 = rc2;
                                    //Literal3.Text = s7+s+s8;
                                    yflag2 = false;
                                    break;
                                }
                                rc2++;
                            }
                            if (yflag2 == false)
                            {
                                break;
                            }
                            // Literal3.Text = "web site is not in first 15 pages";
                        }
                    }
                    yahoo = false;
                done2:;
                }
                catch (Exception e)
                {
                    yahoo = true;
                    scrip(url, keyword, google, bing, yahoo);
                }

            }

            driver.Close();
            senddata(s1, s2, s3, s4, s5, s6, s7, s8);
        }
        public void senddata(string urll, string keywordd, int gp, int gr, int bp, int br, int yp, int yr)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            SqlCommand cm = new SqlCommand("Insert into final_data values(@url,@keyword,@googlepage,@googleresult,@bingpage,@bingresult,@yahoopage,@yahooresult,@date)", con);
            con.Open();
            cm.Parameters.AddWithValue("@url", urll);
            cm.Parameters.AddWithValue("@keyword", keywordd);
            cm.Parameters.AddWithValue("@googlepage", gp);
            cm.Parameters.AddWithValue("@googleresult", gr);
            cm.Parameters.AddWithValue("@bingpage", bp);
            cm.Parameters.AddWithValue("@bingresult", br);
            cm.Parameters.AddWithValue("@yahoopage", yp);
            cm.Parameters.AddWithValue("@yahooresult", yr);
            cm.Parameters.AddWithValue("@date", DateTime.Now);
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}