<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_panel.aspx.cs" Inherits="my_scrapper.user_panel" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>User</title>
	<link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon">
	<link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/font-awesome.min.css" rel="stylesheet">
	<link href="css/datepicker3.css" rel="stylesheet">
	<link href="css/styles.css" rel="stylesheet">
	
	<!--Custom Font-->
	<link href="https://fonts.googleapis.com/css?family=Montserrat:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
</head>
<body>
	<form runat="server" >
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
				<div class="profile-usertitle-name">
						<b><asp:Literal ID="Literal3" runat="server"></asp:Literal></b>
				</div>
			</div>
			<div class="clear"></div>
		</div>
		<div class="divider"></div>
		<ul class="nav menu">
			<li class="active"><a href="../user_panel.aspx">&nbsp; Home</a></li>
			<li><a href="../subscription.aspx">&nbsp; Subscription</a></li>
			<li><a href="../free_trial.aspx">&nbsp; Check Url Result Now</a></li>
			<li><a href="../check_progress.aspx">&nbsp; Check Progress</a></li>
			<li><a href="../edit_keyword.aspx">&nbsp; Edit Keyword</a></li>
			<li><asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" OnClientClick="javascript:return confirm('Are you sure you want to log out?');">&nbsp; Logout</asp:LinkButton></li>
		</ul>
	</div><!--/.sidebar-->
		
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		
		
		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Welcome
        <asp:Literal ID="Literal2" runat="server"></asp:Literal></h1>
			</div>
		</div><!--/.row-->

		<div class="row">
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Name</div>
					<div class="panel-body">
						<p><h4><b><asp:Literal ID="Literal1" runat="server"></asp:Literal></b></h4></p>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Password</div>
					<div class="panel-body">
						<p><h4><b><asp:Literal ID="Literal4" runat="server"></asp:Literal></b></h4></p>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Company Name</div>
					<div class="panel-body">
						<p><h4><b><asp:Literal ID="Literal5" runat="server"></asp:Literal></b></h4></p>
					</div>
				</div>
			</div>
		</div><!-- /.row -->
		<div class="row">
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Email</div>
					<div class="panel-body">
						<p><h4><b><asp:Literal ID="Literal6" runat="server"></asp:Literal></b></h4></p>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Gender</div>
					<div class="panel-body">
						<p><h4><b><asp:Literal ID="Literal7" runat="server"></asp:Literal></b></h4></p>
					</div>
				</div>
			</div>
			<div class="col-md-4">
				<div class="panel panel-primary">
					<div class="panel-heading">Contact</div>
					<div class="panel-body">
						<p><h4><b><asp:Literal ID="Literal8" runat="server"></asp:Literal></b></h4></p>
					</div>
				</div>
			</div>
		</div><!-- /.row -->
				<!--/.col-->
	</div>	<!--/.main-->
	

	</form>
</body>
</html>
