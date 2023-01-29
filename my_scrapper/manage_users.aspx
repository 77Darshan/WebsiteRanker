<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_users.aspx.cs" Inherits="my_scrapper.manage_users" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>FirstPage - Manage User</title>
    <link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/datepicker3.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">

    <!--Custom Font-->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
    <!--[if lt IE 9]>
	<script src="js/html5shiv.js"></script>
	<script src="js/respond.min.js"></script>
	<![endif]-->
    <style>
        .mydatagrid {
            width: 80%;
            border: solid 2px black;
            min-width: 100%;
        }

        .header {
            background-color: #5bc0de;
            font-family: Arial;
            color: White;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
        }

            .rows:hover {
                background-color: #5cb85c;
                color: #fff;
            }

        .mydatagrid a /** FOR THE PAGING ICONS **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #fff;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #5badff;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }
    </style>
    <script>
        function myFunction() {
            
            if (confirm("Press a button!")) {
                
            } else {
               
            }
            document.getElementById("lnklogout");
        }
    </script>
    </head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#"><span>First</span>Page</a>
                </div>
            </div>
            
            <!-- /.container-fluid -->
        </nav>
        <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
            <div class="profile-sidebar">

                <div class="profile-usertitle">
                    <div class="profile-usertitle-name">Admin</div>

                </div>
                <div class="clear"></div>
            </div>
            <div class="divider"></div>

            <ul class="nav menu">
                <li><a href="../admin_panel.aspx"><em class="fa fa-dashboard">&nbsp;</em> Dashboard</a></li>
                <li class="active"><a href="~/manage_users"><em class="fa fa-calendar">&nbsp;</em> Manage Users</a></li>
                <li><asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" OnClientClick="javascript:return confirm('Are you sure you want to log out?');"><em class="fa fa-power-off">&nbsp;</em> Logout</asp:LinkButton></li>
            </ul>
        </div>
        <!--/.sidebar-->

        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">


             <div class="row">
                 <div class="col-lg-12">
                    <h1 class="page-header">Manage User</h1>
                </div>
            </div>
            <!--/.row-->

            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-body tabs">
                            <ul class="nav nav-tabs">
                                <li id="tab1li" runat="server" class="active"><a href="#tab1" data-toggle="tab">User Data</a></li>
                                <li id="tab2li" runat="server"><a href="#tab2" data-toggle="tab">Admin Data</a></li>
                                <li id="tab3li" runat="server"><a href="#tab3" data-toggle="tab">Url , Keywords & result</a></li>

                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="tab1" runat="server">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" />
                                            <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                                            <asp:BoundField DataField="name" HeaderText="User Name" SortExpression="name" />
                                            <asp:BoundField DataField="company_name" HeaderText="Company Name" SortExpression="company_name" />
                                            <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                            <asp:BoundField DataField="gender" HeaderText="Gender" SortExpression="gender" />
                                            <asp:BoundField DataField="contact" HeaderText="Contact" SortExpression="contact" />
                                            <asp:BoundField DataField="plan_type" HeaderText="Plan of User" SortExpression="plan_type" />
                                            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:scrap_dataConnectionString2 %>" SelectCommand="SELECT * FROM [user_details]"></asp:SqlDataSource>
                                    <asp:Button ID="update_user" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="update_user_Click"/>
                                    <asp:Button ID="delete_user" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="delete_user_Click"/>
                                    <asp:Button ID="clk_update_user" runat="server" Text="Show Record Data" CssClass="btn btn-warning" OnClick="clk_update_user_Click"/>
                                    <asp:Button ID="delet_user_apply" runat="server" Text="Delete Record" CssClass="btn btn-warning" OnClick="delet_user_apply_Click" OnClientClick="alert('Deleted Succesfully')"/>
                                    <asp:TextBox ID="user_id" CssClass="form-control" placeholder="Enter User Id " runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_plan" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_psw" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_name" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_company_name" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_email" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_gender" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_contact" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="user_date" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Button ID="user_apply" runat="server" Text="Apply Changes" CssClass="btn btn-success" OnClick="user_apply_Click" OnClientClick="alert('Updated Succesfully')"/>
                                </div>
                                <div class="tab-pane fade" id="tab2" runat="server">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                            <asp:BoundField DataField="email" HeaderText="Admin Email Id" SortExpression="email" />
                                            <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:scrap_dataConnectionString2 %>" SelectCommand="SELECT * FROM [admin]"></asp:SqlDataSource>
                                    <asp:Button ID="insert_admin"  CssClass="btn btn-success" runat="server" Text="Add an Admin" OnClick="insert_admin_Click" />
                                    <asp:Button ID="insert_admin_apply"  CssClass="btn btn-success" runat="server" Text="Apply" OnClick="insert_admin_apply_Click" OnClientClick="alert('Added Succesfully')"/>
                                    <asp:Button ID="update_admin" runat="server" Text="update" CssClass="btn btn-warning" OnClick="update_admin_Click"/>
                                    <asp:Button ID="delet_admin_apply" runat="server" Text="Delete Record" CssClass="btn btn-warning" OnClick="delet_admin_apply_Click" OnClientClick="alert('Deleted Succesfully')"/>
                                    <asp:Button ID="delete_admin" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="delete_admin_Click"/>
                                    <asp:Button ID="clk_admin" runat="server" Text="Show Record Data" CssClass="btn btn-warning" OnClick="clk_admin_Click"/>
                                    <asp:TextBox ID="admin_id" CssClass="form-control" placeholder="Enter Admin Id No" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="admin_email" CssClass="form-control" runat="server" placeholder="Enter Admin email"></asp:TextBox>
                                    <asp:TextBox ID="admin_psw" CssClass="form-control" runat="server" placeholder="Enter Admin password"></asp:TextBox>
                                    <asp:Button ID="admin_apply" runat="server" Text="Apply Changes" CssClass="btn btn-success" OnClick="admin_apply_Click" OnClientClick="alert('Updated Succesfully')"/>
                                </div>
                                <div class="tab-pane fade" id="tab3" runat="server">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                            <asp:BoundField DataField="url" HeaderText="url" SortExpression="url" />
                                            <asp:BoundField DataField="kw1" HeaderText="keyword 1" SortExpression="kw1" />
                                            <asp:BoundField DataField="kw2" HeaderText="keyword 2" SortExpression="kw2" />
                                            <asp:BoundField DataField="kw3" HeaderText="keyword 3" SortExpression="kw3" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:scrap_dataConnectionString2 %>" SelectCommand="SELECT * FROM [url_keyword]"></asp:SqlDataSource>
                                    <asp:Button ID="update_url_keyword" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="update_url_keyword_Click"/>
                                    <asp:Button ID="delete_url_keuword" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="delete_url_keyword_Click"/>
                                    <asp:Button ID="delet_url_apply" runat="server" Text="Deleter Record" CssClass="btn btn-warning" OnClick="delet_url_apply_Click" OnClientClick="alert('Deleted Succesfully')"/>
                                    <asp:Button ID="clk_url_keyword" runat="server" Text="Show Record Data" CssClass="btn btn-warning" OnClick="clk_url_keyword_Click"/>
                                    <asp:TextBox ID="url_keyword_id" CssClass="form-control" placeholder="Enter Id No" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="url_keyword_url" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="url_keyword_kw1" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="url_keyword_kw2" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="url_keyword_kw3" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Button ID="url_apply" runat="server" Text="Apply Changes" CssClass="btn btn-success" OnClick="url_apply_Click" OnClientClick="alert('Updated Succesfully')"/>
                                </div>
                            </div>

                        </div>
                        <!--/.panel-->
                    </div>
                    <!--/.col-->
                </div>
                <!--/.col-->
            </div>
            <!--/.row-->
        </div>
        <!--/.main-->

        <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/chart.min.js"></script>
        <script src="js/chart-data.js"></script>
        <script src="js/easypiechart.js"></script>
        <script src="js/easypiechart-data.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/custom.js"></script>
        <script>
            window.onload = function () {
                var chart1 = document.getElementById("line-chart").getContext("2d");
                window.myLine = new Chart(chart1).Line(lineChartData, {
                    responsive: true,
                    scaleLineColor: "rgba(0,0,0,.2)",
                    scaleGridLineColor: "rgba(0,0,0,.05)",
        
            };
        </script>

    </form>

</body>
</html>
