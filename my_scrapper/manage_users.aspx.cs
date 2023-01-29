using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace my_scrapper
{
    public partial class manage_users : System.Web.UI.Page
    {
        DataTable dt;
        bool fg = false;
        public void FillGrid()
        {
            try
            {
                if (dt == null || dt.Rows.Count < 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-20O0VSUI;Initial Catalog=scrap_data;Integrated Security=True");
                    con.Open();
                    ///I'm using NorthWind Database
                    ////https://github.com/cjlee/northwind
                    SqlCommand cmd = new SqlCommand("Select * from admin", con);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    cmd.Dispose();
                    con.Close();

                }

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                FillGrid();
                GridView2.PageIndex = e.NewPageIndex;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session["admin"] = "";
            Response.Redirect("login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                //if(fg==true)
                //{
                //    Literal1.Visible = true;
                //}
                //else
                //{
                //    Literal1.Visible = false;
                //}
                

                if (Session["admin"] != null && Session["admin"].ToString() != "")
                {
                    //Literal1.Text = " <div class=\"tab - pane fade in active\" id=\"tab1\">";
                    //Literal1.Text = "in active";
                    //Literal2.Text = "";
                    //Literal3.Text = "";
                    //Literal2.Text= "<div class=\"tab - pane fade\" id=\"tab2\">";
                    // Literal3.Text = "<div class=\"tab - pane fade\" id=\"tab3\">";
                    clk_admin.Visible = false;
                    clk_update_user.Visible = false;
                    clk_url_keyword.Visible = false;
                    user_id.Visible = false;
                    user_company_name.Visible = false;
                    user_contact.Visible = false;
                    user_date.Visible = false;
                    user_email.Visible = false;
                    user_gender.Visible = false;
                    user_name.Visible = false;
                    user_plan.Visible = false;
                    user_psw.Visible = false;
                    admin_email.Visible = false;
                    admin_id.Visible = false;
                    admin_psw.Visible = false;
                    url_keyword_id.Visible = false;
                    url_keyword_url.Visible = false;
                    url_keyword_kw1.Visible = false;
                    url_keyword_kw2.Visible = false;
                    url_keyword_kw3.Visible = false;
                    admin_apply.Visible = false;
                    url_apply.Visible = false;
                    user_apply.Visible = false;
                    delet_url_apply.Visible = false;
                    delet_user_apply.Visible = false;
                    delet_admin_apply.Visible = false;
                    insert_admin_apply.Visible = false;
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }

        }

        protected void update_user_Click(object sender, EventArgs e)
        {
            update_user.Visible = false;
            user_id.Visible = true;
            clk_update_user.Visible = true;

            tab1li.Attributes.Add("class", "active");
            tab1.Attributes.Add("class", "tab-pane fade in active");
            tab2li.Attributes.Add("class", "");
            tab2.Attributes.Add("class", "tab-pane fade");
            tab3li.Attributes.Add("class", "");
            tab3.Attributes.Add("class", "tab-pane fade");
        }

        protected void update_admin_Click(object sender, EventArgs e)
        {
            update_admin.Visible = false;
            admin_id.Visible = true;
            clk_admin.Visible = true;

            tab1li.Attributes.Add("class", "");
            tab1.Attributes.Add("class", "tab-pane fade");
            tab2li.Attributes.Add("class", "active");
            tab2.Attributes.Add("class", "tab-pane fade in active");
            tab3li.Attributes.Add("class", "");
            tab3.Attributes.Add("class", "tab-pane fade");
        }

        protected void update_url_keyword_Click(object sender, EventArgs e)
        {
            update_url_keyword.Visible = false;
            url_keyword_id.Visible = true;
            clk_url_keyword.Visible = true;
            

            tab1li.Attributes.Add("class", "");
            tab1.Attributes.Add("class", "tab-pane fade");
            tab2li.Attributes.Add("class", "");
            tab2.Attributes.Add("class", "tab-pane fade");
            tab3li.Attributes.Add("class", "active");
            tab3.Attributes.Add("class", "tab-pane fade in active");
        }
        protected void delete_user_Click(object sender, EventArgs e)
        {
            user_id.Visible = true;
            delet_user_apply.Visible = true;
            delete_user.Visible = false;

            tab1li.Attributes.Add("class", "active");
            tab1.Attributes.Add("class", "tab-pane fade in active");
            tab2li.Attributes.Add("class", "");
            tab2.Attributes.Add("class", "tab-pane fade");
            tab3li.Attributes.Add("class", "");
            tab3.Attributes.Add("class", "tab-pane fade");
            
        }

        protected void delete_admin_Click(object sender, EventArgs e)
        {
            admin_id.Visible = true;
            delet_admin_apply.Visible = true;
            delete_admin.Visible = false;
            tab1li.Attributes.Add("class", "");
            tab1.Attributes.Add("class", "tab-pane fade");
            tab2li.Attributes.Add("class", "active");
            tab2.Attributes.Add("class", "tab-pane fade in active");
            tab3li.Attributes.Add("class", "");
            tab3.Attributes.Add("class", "tab-pane fade");
        }

        protected void delete_url_keyword_Click(object sender, EventArgs e)
        {
            url_keyword_id.Visible = true;
            delet_url_apply.Visible = true;
            delete_url_keuword.Visible = false;
            
            tab1li.Attributes.Add("class", "");
            tab1.Attributes.Add("class", "tab-pane fade");
            tab2li.Attributes.Add("class", "");
            tab2.Attributes.Add("class", "tab-pane fade");
            tab3li.Attributes.Add("class", "active"); 
            tab3.Attributes.Add("class", "tab-pane fade in active");
        }

        protected void clk_url_keyword_Click(object sender, EventArgs e)
        {
            clk_url_keyword.Visible = false;
            url_apply.Visible = true;
            url_keyword_id.Visible = true;
            url_keyword_id.ReadOnly = true;
            url_keyword_url.Visible = true;
            url_keyword_kw1.Visible = true;
            url_keyword_kw2.Visible = true;
            url_keyword_kw3.Visible = true;
            

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "select * from url_keyword where id='" + url_keyword_id.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            string s = "";
            if (sdr.Read())
            {
                //Literal2.Text = sdr["name"].ToString();
                //Literal3.Text = sdr["company_name"].ToString();
                s = sdr["url"].ToString();
                url_keyword_url.Text = s;
                s = sdr["kw1"].ToString();
                url_keyword_kw1.Text = s;
                s = sdr["kw2"].ToString();
                url_keyword_kw2.Text = s;
                s = sdr["kw3"].ToString();
                url_keyword_kw3.Text = s;
            }
        }
        protected void clk_update_user_Click(object sender, EventArgs e)
        {
            clk_update_user.Visible = false;
            user_apply.Visible = true;
            user_id.Visible = true;
            user_id.ReadOnly = true;
            user_company_name.Visible = true;
            user_contact.Visible = true;
            user_date.Visible = true;
            user_date.ReadOnly = true;
            user_email.Visible = true;
            user_email.ReadOnly = true;
            user_gender.Visible = true;
            user_name.Visible = true;
            user_plan.Visible = true;
            user_psw.Visible = true;
            user_psw.ReadOnly = true;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "select * from user_details where id='" + user_id.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            string s = "";
            if (sdr.Read())
            {
                //Literal2.Text = sdr["name"].ToString();
                //Literal3.Text = sdr["company_name"].ToString();
                s = sdr["company_name"].ToString();
                user_company_name.Text = s;
                s = sdr["contact"].ToString();
                user_contact.Text = s;
                s = sdr["date"].ToString();
                user_date.Text = s;
                s = sdr["email"].ToString();
                user_email.Text = s;
                s = sdr["gender"].ToString();
                user_gender.Text = s;
                s = sdr["name"].ToString();
                user_name.Text = s;
                s = sdr["plan_type"].ToString();
                user_plan.Text = s;
                s = sdr["password"].ToString();
                user_psw.Text = s;
            }
        }

        protected void clk_admin_Click(object sender, EventArgs e)
        {
            admin_apply.Visible = true;
            admin_email.Visible = true;
            admin_id.Visible = true;
            admin_id.ReadOnly = true;
            admin_psw.Visible = true;
            clk_admin.Visible = false;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "select * from admin where id='" + admin_id.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            string s = "";
            if (sdr.Read())
            {
                //Literal2.Text = sdr["name"].ToString();
                //Literal3.Text = sdr["company_name"].ToString();
                s = sdr["email"].ToString();
                admin_email.Text = s;
                s = sdr["password"].ToString();
                admin_psw.Text = s;
            }
        }
        protected void admin_apply_Click(object sender, EventArgs e)
        {
            admin_id.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "UPDATE admin SET email='" + admin_email.Text + "',password='" + admin_psw.Text + "' where id=" + admin_id.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            update_admin.Visible = true;
            Response.Redirect("~/manage_users.aspx");
        }

        protected void user_apply_Click(object sender, EventArgs e)
        {
            url_keyword_id.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "UPDATE user_details SET password = '" + user_psw.Text + "', name = '" + user_name.Text +
                "',company_name ='" + user_company_name.Text + "', email='" + user_email.Text +
                "',gender = '" + user_gender.Text + "' , contact = '" + user_contact.Text +
                 "'  where id =" + user_id.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            update_user.Visible = true;
            Response.Redirect("~/manage_users.aspx");
        }

        protected void url_apply_Click(object sender, EventArgs e)
        {
           // Literal1.Text = "<script>function myFunction(){var txt;if (confirm(\"Press a button!\")){txt = \"You pressed OK!\";}else{txt = \"You pressed Cancel!\";}document.getElementById(\"demo\").innerHTML = txt;}</ script > ";
            url_keyword_id.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry;
            if (url_keyword_kw3.Text=="" || url_keyword_kw3.Text==null)
            {
                 qry = "UPDATE url_keyword SET url='" + url_keyword_url.Text + "' ,kw1 = '" + url_keyword_kw1.Text + "',kw2='" + url_keyword_kw2.Text + "'where id=" + url_keyword_id.Text;
            }
            else
            {
                qry = "UPDATE url_keyword SET url='" + url_keyword_url.Text + "' ,kw1 = '" + url_keyword_kw1.Text + "',kw2='" + url_keyword_kw2.Text + "',kw3='" + url_keyword_kw3.Text + "' where id=" + url_keyword_id.Text;
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            update_url_keyword.Visible = true;
            fg = true;
            
            //Literal1.Text = "<div class=\"alert bg-success\" role=\"alert\" ><em class=\"fa fa-lg fa - warning\">&nbsp;</em>url and keyword updated<a href=\"#\" class=\"pull-right\"><em class=\"fa fa-lg fa-close\"></em></a></div>";
            
            Response.Redirect("~/manage_users.aspx");


        }

        protected void delet_url_apply_Click(object sender, EventArgs e)
        {
            url_keyword_id.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "delete from url_keyword where id = '" + url_keyword_id.Text + "'; ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            qry = "delete from user_details where id = '" + user_id.Text + "'; ";
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("~/manage_users.aspx");
        }

        protected void delet_user_apply_Click(object sender, EventArgs e)
        {
            url_keyword_id.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "delete from user_details where id = '" + user_id.Text + "'; ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            qry = "delete from url_keyword where id = '" + user_id.Text + "'; ";
            cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            //qry= "delete from final_data where "
            Response.Redirect("~/manage_users.aspx");
        }

        protected void delet_admin_apply_Click(object sender, EventArgs e)
        {
            url_keyword_id.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "delete from admin where id = '" + admin_id.Text + "'; ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("~/manage_users.aspx");
        }

        protected void insert_admin_Click(object sender, EventArgs e)
        {
            insert_admin_apply.Visible = true;
            admin_email.Visible = true;
            //admin_id.Visible = true;
            //admin_id.ReadOnly = true;
            admin_psw.Visible = true;
            insert_admin.Visible = false;
            tab1li.Attributes.Add("class", "");
            tab1.Attributes.Add("class", "tab-pane fade");
            tab2li.Attributes.Add("class", "active");
            tab2.Attributes.Add("class", "tab-pane fade in active");
            tab3li.Attributes.Add("class", "");
            tab3.Attributes.Add("class", "tab-pane fade");
        }

        protected void insert_admin_apply_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scrap_dataConnectionString2"].ConnectionString);
            string qry = "SELECT count(*) FROM admin";
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            //admin_id.Text = ++i + "";
            qry = "insert into admin(id,email,password) values(@id,@email,@password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", ++i);
            cmd.Parameters.AddWithValue("@email", admin_email.Text);
            cmd.Parameters.AddWithValue("@password", admin_psw.Text);
            cmd.ExecuteNonQuery();
            insert_admin.Visible = true;
            Response.Redirect("~/manage_users.aspx");

        }

    }
}