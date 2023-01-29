<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_panel.aspx.cs" Inherits="my_scrapper.admin_panel" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html>
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title><%--<img src="fp_logo.png" alt="FP_logo"></img>--%>FirstPage -Admin Panel</title>
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
</head>
<body>
	<form id="form1" runat="server">
	<nav class="navbar navbar-custom navbar-fixed-top" role="navigation">
		<div class="container-fluid">
			<div class="navbar-header">
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse"><span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span></button>
				<a class="navbar-brand" href="#"><span>First</span>Page</a>
			
			</div>
		</div><!-- /.container-fluid -->
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
			<li class="active"><a href="~/admin_panel.aspx"><em class="fa fa-dashboard">&nbsp;</em> Dashboard</a></li>
			<li><a href="../manage_users.aspx"><em class="fa fa-calendar">&nbsp;</em> Manage Users</a></li>
			<li><asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" OnClientClick="javascript:return confirm('Are you sure you want to log out?');"><em class="fa fa-power-off" >&nbsp;</em> Logout</asp:LinkButton></li>
		</ul>
	</div><!--/.sidebar-->
		
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		
		
		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Dashboard</h1>
			</div>
		</div><!--/.row-->
		
		<div class="panel panel-container">
			<div class="row">
				<div class="col-xs-8 col-md-4 col-lg-4 no-padding">
					<div class="panel panel-teal panel-widget border-right">
						<div class="row no-padding"><em class="fa fa-xl fa-users color-blue"></em>
							<div class="large"><asp:Literal runat="server" id="literal1"></asp:Literal></div>
							<div class="text-muted">ADMINS</div>
						</div>
					</div>
				</div>
				<div class="col-xs-8 col-md-4 col-lg-4 no-padding">
					<div class="panel panel-orange panel-widget border-right">
						<div class="row no-padding"><em class="fa fa-xl fa-users color-teal"></em>
							<div class="large"><asp:Literal runat="server" id="literal3"></asp:Literal></div>
							<div  class="text-muted" >USERS</div>
						</div>
					</div>
				</div>
				<div class="col-xs-8 col-md-4 col-lg-4 no-padding">
					<div class="panel panel-pink panel-widget ">
						<div class="row no-padding"><em class="fa fa-xl fa-search color-red"></em>
							<div class="large"><asp:Literal runat="server" id="literal2"></asp:Literal></div>
							<div class="text-muted">Total Keywords Registred</div>
						</div>
					</div>
				</div>
			</div><!--/.row-->
		</div>
		
	
		
		<div class="row">
			<div class="col-md-6">
				<div class="panel panel-default">
					<div class="panel-body tabs">
						<ul class="nav nav-tabs">
							<li class="active"><a href="#tab1" data-toggle="tab">Interact With USERS</a></li>
							<li><a href="#tab2" data-toggle="tab">Interact With ADMINS</a></li>
							
						</ul>
						<div class="tab-content">
							<div class="tab-pane fade in active" id="tab1">
								<h4>Message to Users</h4>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
								<asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Send" OnClick="Button1_Click" OnClientClick="alert('Message will be Sent to All Users')" />
							</div>
							<div class="tab-pane fade" id="tab2">
								<h4>Message to Admins</h4>
								 <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
								<asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Send" OnClick="Button2_Click" OnClientClick="alert('Message will be Sent to All Users')"/>
							</div>
							
						</div>
					
				</div><!--/.panel-->
			</div><!--/.col-->
		</div><!--/.col-->

			
			
			<div class="col-md-6">
				<div class="panel panel-default ">
					<div class="panel-heading">
						Timeline
<%--						<ul class="pull-right panel-settings panel-button-tab-right">
							<li class="dropdown"><a class="pull-right dropdown-toggle" data-toggle="dropdown" href="#">
								<em class="fa fa-cogs"></em>
							</a>
								<%--<ul class="dropdown-menu dropdown-menu-right">
									<li>
										<ul class="dropdown-settings">
											<li><a href="#">
												<em class="fa fa-cog"></em> Settings 1
											</a></li>
											<li class="divider"></li>
											<li><a href="#">
												<em class="fa fa-cog"></em> Settings 2
											</a></li>
											<li class="divider"></li>
											<li><a href="#">
												<em class="fa fa-cog"></em> Settings 3
											</a></li>
										</ul>
									</li>
								</ul>--%
							</li>
						</ul>--%>
						<span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span></div>
					<div class="panel-body timeline-container">
						<ul class="timeline">
							<li>
								<div class="timeline-badge primary"><em class="glyphicon glyphicon-paperclip"></em></div>
								<div class="timeline-panel">
									<div class="timeline-heading">
										<h4 class="timeline-title">
                                            
										   <b> <asp:Literal ID="Literal4" runat="server"></asp:Literal> </b>
                                            
										</h4>
									</div>
									<div class="timeline-body">
										<p>
											Registered  
                                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
											Days Ago..
										</p>
									</div>
								</div>
							</li>
							<li>
								<div class="timeline-badge primary"><em class="glyphicon glyphicon-paperclip"></em></div>
								<div class="timeline-panel">
									<div class="timeline-heading">
										<h4 class="timeline-title">
											<b> <asp:Literal ID="Literal6" runat="server"></asp:Literal> </b>
										</h4>
									</div>
									<div class="timeline-body">
										<p>
											Registered  
											 <asp:Literal ID="Literal7" runat="server"></asp:Literal>
											Days Ago..
										</p>
									</div>
								</div>
							</li>
							
							
						</ul>
					</div>
				</div>
			</div><!--/.col-->
			
			
		</div><!--/.row-->
		
		
		
	</div>	<!--/.main-->
	
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
	scaleFontColor: "#c5c7cc"
	});
};
    </script>
		
    </form>
		
</body>
</html>
