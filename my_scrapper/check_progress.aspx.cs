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
    public partial class check_progress : System.Web.UI.Page
    {

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["user_email"] = "";

            Response.Redirect("login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_email"] != null && Session["user_email"].ToString() != "")
            {
                run();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        public void run()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            //Literal2.Text = "bye";
            string em =Convert.ToString(Session["user_email"]);/*"sinrojaprince1201@gmail.com";*/
            string qry = "select * from user_details where email='" + em + "'";
            con.Open();
            string plan = "";
            string id;
            string url = "", kw1 = "", kw2 = "", kw3 = "";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Literal3.Text = sdr["company_name"].ToString();
                plan = sdr["plan_type"].ToString();
                id = sdr["id"].ToString();
                if (plan == "b")
                {
                    sdr.Close();
                    qry = "select * from url_keyword where id='" + id + "'";
                    cmd = new SqlCommand(qry, con);
                    sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        url = sdr["url"].ToString();
                        Literal2.Text = url;
                        kw1 =sdr["kw1"].ToString();
                        Literal8.Text = "KEYWORD 1 : <b>" + kw1 + "</b>";
                        kw2 =sdr["kw2"].ToString();
                        Literal7.Text = "KEYWORD 2 : <b>" + kw2 + "</b>";
                        select(url, kw1, kw2);
                    }
                }
                else
                {
                    sdr.Close();
                    qry = "select * from url_keyword where id='" + id + "'";
                    cmd = new SqlCommand(qry, con);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        url = sdr["url"].ToString();
                        Literal2.Text = url;
                        kw1 = sdr["kw1"].ToString();
                        Literal8.Text = "KEYWORD 1 : <b>" + kw1 + "</b>";
                        kw2 = sdr["kw2"].ToString();
                        Literal7.Text = "KEYWORD 2 : <b>" + kw2 + "</b>";
                        kw3 = sdr["kw3"].ToString();
                        Literal9.Text = "<div class='panel-heading'> KEYWORD 3 : <b>" + kw3 +"</b></div>";
                        Literal6.Text = " <div class=\"panel-body\">" +
                              "<div class=\"canvas-wrapper\">" +
                                "<canvas class=\"main-chart\" id=\"keyword3_chart\" height=\"200\" width=\"600\"></canvas>" +
                            "</div></div>";
                        Literal10.Text= " <div class=\"panel - body\">"+
                              "<div class=\"canvas-wrapper\" style=\"text-align:right\">"+
                               "<img src = \"google.png\" alt=\"google\" width=\"15\" height=\"15\"><b>Google</b>&nbsp;"+
                               "<img src = \"bing.png\" alt=\"bing\" width=\"15\" height=\"15\"> <b>Bing</b>&nbsp;" +
                               "<img src = \"yahoo.png\" alt=\"yahoo\" width=\"15\" height=\"15\"><b>Yahoo</b>&nbsp;"+
                            "</div>"+
                        "</div>";
                        select(url, kw1, kw2, kw3);
                    }
                }

            }
        }
        public void select(string url,string kw1,string kw2,string kw3)
        {
            firstkeyword(url, kw1);
            secoundkeyword(url, kw2);
            thirdkeyworkd(url, kw3);
        }

        public void select(string url, string kw1, string kw2)
        {
            firstkeyword(url, kw1);
            secoundkeyword(url, kw2);
        }

        public void firstkeyword(string url, string kw)
        {
            string google_data = "",bing_data="",yahoo_data="",count="";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string q = "select * from final_data where url='"+url+ "' and keyword='"+kw+"'";
            SqlCommand cmd;
            SqlDataReader reader;
            cmd = new SqlCommand(q, con);
            con.Open();
            DateTime disp_date;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                google_data += reader["googlepage"].ToString() + "." + reader["googleresult"].ToString() + ",";
                bing_data += reader["bingpage"].ToString() + "." + reader["bingresult"].ToString() + ",";
                yahoo_data += reader["yahoopage"].ToString() + "." + reader["yahooresult"].ToString() + ",";
                disp_date = Convert.ToDateTime((reader["date"]));
               // disp_date.Date = Convert.ToDateTime();
                count += "'" + Convert.ToString(disp_date) + "',";
            }
           /* for(int i=1;i<=count;i++)
            {
                if (i == count)
                    d += i;
                else
                    d += i +",";
            }*/
            Literal1.Text = "<script>var kw1 = {" +
                                " labels:["+count+"], datasets:[ " +
                                "{ label: 'Google', fillColor: 'rgba(63, 191, 63, 0.5)', strokeColor: 'rgb(63, 191, 63)', pointColor: 'rgba(40, 244, 0, 0.52)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(38, 229, 0, 0.24)', data:[" + google_data + "] }" +
                                ",{ label: 'Bing', fillColor: 'rgba(220,220,220,0.2)', strokeColor: 'rgba(220,220,220,1)', pointColor: 'rgba(220,220,220,1)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(220,220,220,1)', data:[" + bing_data + "] }" +
                                ", { label: 'yahoo', fillColor: 'rgba(48, 164, 255, 0.2)', strokeColor: 'rgba(48, 164, 255, 1)', pointColor: 'rgba(48, 164, 255, 1)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(48, 164, 255, 1)', data:[" + yahoo_data + "] } ] }</script>";
        }
        public void secoundkeyword(string url, string kw)
        {
            string google_data = "", bing_data = "", yahoo_data = "";
            string count = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string q = "select * from final_data where url='" + url + "' and keyword='" + kw + "'";
            SqlCommand cmd;
            SqlDataReader reader;
            cmd = new SqlCommand(q, con);
            con.Open();
            DateTime disp_date;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                google_data += reader["googlepage"].ToString() + "." + reader["googleresult"].ToString() + ",";
                bing_data += reader["bingpage"].ToString() + "." + reader["bingresult"].ToString() + ",";
                yahoo_data += reader["yahoopage"].ToString() + "." + reader["yahooresult"].ToString() + ",";
                disp_date = Convert.ToDateTime((reader["date"]));
                // disp_date.Date = Convert.ToDateTime();
                count += "'" + Convert.ToString(disp_date) + "',";
            }
            /*for (int i = 1; i <= count; i++)
            {
                if (i == count)
                    d += i;
                else
                    d += i + ",";
            }*/
            Literal4.Text = "<script>var kw2 = {" +
                                " labels:[" + count + "], datasets:[ " +
                                "{ label: 'Google', fillColor: 'rgba(63, 191, 63, 0.5)', strokeColor: 'rgb(63, 191, 63)', pointColor: 'rgba(40, 244, 0, 0.52)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(38, 229, 0, 0.24)', data:[" + google_data + "] }" +
                                ",{ label: 'Bing', fillColor: 'rgba(220,220,220,0.2)', strokeColor: 'rgba(220,220,220,1)', pointColor: 'rgba(220,220,220,1)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(220,220,220,1)', data:[" + bing_data + "] }" +
                                ", { label: 'yahoo', fillColor: 'rgba(48, 164, 255, 0.2)', strokeColor: 'rgba(48, 164, 255, 1)', pointColor: 'rgba(48, 164, 255, 1)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(48, 164, 255, 1)', data:[" + yahoo_data + "] } ] }</script>";

        }

        public void thirdkeyworkd(string url, string kw)
        {
            string google_data = "", bing_data = "", yahoo_data = "";
            string count = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string q = "select * from final_data where url='" + url + "' and keyword='" + kw + "'";
            SqlCommand cmd;
            SqlDataReader reader;
            cmd = new SqlCommand(q, con);
            con.Open();
            DateTime disp_date;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                google_data += reader["googlepage"].ToString() + "." + reader["googleresult"].ToString() + ",";
                bing_data += reader["bingpage"].ToString() + "." + reader["bingresult"].ToString() + ",";
                yahoo_data += reader["yahoopage"].ToString() + "." + reader["yahooresult"].ToString() + ",";
                disp_date = Convert.ToDateTime((reader["date"]));
                // disp_date.Date = Convert.ToDateTime();
                count += "'" + Convert.ToString(disp_date) + "',";
            }
           /* for (int i = 1; i <= count; i++)
            {
                if (i == count)
                    d += i;
                else
                    d += i + ",";
            }*/
            Literal5.Text = "<script>var kw3 = {" +
                                " labels:[" + count + "], datasets:[ " +
                                "{ label: 'Google', fillColor: 'rgba(63, 191, 63, 0.5)', strokeColor: 'rgb(63, 191, 63)', pointColor: 'rgba(40, 244, 0, 0.52)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(38, 229, 0, 0.24)', data:[" + google_data + "] }" +
                                ",{ label: 'Bing', fillColor: 'rgba(220,220,220,0.2)', strokeColor: 'rgba(220,220,220,1)', pointColor: 'rgba(220,220,220,1)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(220,220,220,1)', data:[" + bing_data + "] }" +
                                ", { label: 'yahoo', fillColor: 'rgba(48, 164, 255, 0.2)', strokeColor: 'rgba(48, 164, 255, 1)', pointColor: 'rgba(48, 164, 255, 1)', pointStrokeColor: '#fff', pointHighlightFill: '#fff', pointHighlightStroke: 'rgba(48, 164, 255, 1)', data:[" + yahoo_data + "] } ] }</script>";
        }
       
    }
}