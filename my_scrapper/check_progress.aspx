<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check_progress.aspx.cs" Inherits="my_scrapper.check_progress" %>

<!DOCTYPE html>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Check Progres</title>
    <link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">
    <link href="css/datepicker3.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">

    <!--Custom Font-->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
	<asp:Literal ID="Literal1" runat="server"></asp:Literal><asp:Literal ID="Literal4" runat="server"></asp:Literal><asp:Literal ID="Literal5" runat="server"></asp:Literal>
</head>
<body>
    
    <form runat="server">
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
                    <div class="profile-usertitle-name">
                        <b>
                            <asp:Literal ID="Literal3" runat="server"></asp:Literal></b>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="divider"></div>
            <ul class="nav menu">
                <li><a href="../user_panel.aspx">&nbsp; Home</a></li>
                <li><a href="../subscription.aspx">&nbsp; Subscription</a></li>
                <li><a href="../free_trial.aspx">&nbsp; Check Url Result Now</a></li>
                <li class="active"><a href="../check_progress.aspx">&nbsp; Check Progress</a></li>
                <li><a href="../edit_keyword.aspx">&nbsp; Edit Keyword</a></li>
                <li><asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" OnClientClick="javascript:return confirm('Are you sure you want to log out?');">&nbsp; Logout</asp:LinkButton></li>
            </ul>
        </div>
        <!--/.sidebar-->

        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">


            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <b><asp:Literal ID="Literal2" runat="server"></asp:Literal></b></h1>
                </div>
            </div>
            <!--/.row-->



            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                        </div>
                        <div class="panel-body">
                            <div class="canvas-wrapper">
                                <canvas class="main-chart" id="keyword1_chart" height="200" width="600"></canvas>
                            </div>
                        </div>
                        <div class="panel-body">
                           <div class="canvas-wrapper" style="text-align:right">
                               <img src="google.png" alt="google" width="15" height="15"><b>Google</b>
                               <img src="bing.png" alt="bing" width="15" height="15"> <b>Bing</b> 
                               <img src="yahoo.png" alt="yahoo" width="15" height="15"><b>Yahoo</b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/.row line chart-->
			<div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Literal ID="Literal7" runat="server"></asp:Literal>
                           <%-- <span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>--%>
                        </div>
                        <div class="panel-body">
                            <div class="canvas-wrapper">
                                <canvas class="main-chart" id="keyword2_chart" height="200" width="600"></canvas>
                            </div>
                        </div>
                        <div class="panel-body">
                           <div class="canvas-wrapper" style="text-align:right">
                               <img src="google.png" alt="Google" width="15" height="15"><b>Google</b>
                               <img src="bing.png" alt="bing" width="15" height="15"> <b>Bing</b> 
                               <img src="yahoo.png" alt="yahoo" width="15" height="15"><b>Yahoo</b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

			<div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
						
							<h4><asp:Literal ID="Literal9" runat="server"></asp:Literal></h4>
						
						<asp:Literal ID="Literal6" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
           
        </div>
        <!--/.main-->
        <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/chart.min.js"></script>
        <%--<script src="js/data-chart.js"></script>--%>
        <script src="js/easypiechart.js"></script>
        <script src="js/easypiechart-data.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script src="js/custom.js"></script>
		<script>
            window.onload = function () {
                var chart1 = document.getElementById("keyword1_chart").getContext("2d");
                window.myLine = new Chart(chart1).Line(kw1, {
                    responsive: true,
                    scaleLineColor: "rgba(0,0,0,.2)",
                    scaleGridLineColor: "rgba(0,0,0,.05)",
                    scaleFontColor: "#c5c7cc"
				});

                var chart2 = document.getElementById("keyword2_chart").getContext("2d");
                window.myLine = new Chart(chart2).Line(kw2, {
                    responsive: true,
                    scaleLineColor: "rgba(0,0,0,.2)",
                    scaleGridLineColor: "rgba(0,0,0,.05)",
                    scaleFontColor: "#c5c7cc"
				});

                var chart3 = document.getElementById("keyword3_chart").getContext("2d");
                window.myLine = new Chart(chart3).Line(kw3, {
                    responsive: true,
                    scaleLineColor: "rgba(0,0,0,.2)",
                    scaleGridLineColor: "rgba(0,0,0,.05)",
                    scaleFontColor: "#c5c7cc"
                });
			};
	</script>
    </form>
</body>
</html>

