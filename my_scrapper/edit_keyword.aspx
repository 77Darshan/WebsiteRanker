<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_keyword.aspx.cs" Inherits="my_scrapper.edit_keyword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Update keyword</title>
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
			<li><a href="../user_panel.aspx">&nbsp; Home</a></li>
			<li><a href="../subscription.aspx">&nbsp; Subscription</a></li>
			<li><a href="../free_trial.aspx">&nbsp; Check Url Result Now</a></li>
			<li><a href="../check_progress.aspx">&nbsp; Check Progress</a></li>
			<li class="active"><a href="../edit_keyword.aspx">&nbsp; Edit Keyword</a></li>
			<li><asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" OnClientClick="javascript:return confirm('Are you sure you want to log out?');">&nbsp; Logout</asp:LinkButton></li>
		</ul>
	</div><!--/.sidebar-->
		
	<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Update keyword</h1>
			</div>
		</div><!--/.row-->
		
			<div class="col-md-6">
				<div class="panel panel-default ">
					<div class="panel-heading">
						Information 
					<span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span></div>
					<div class="panel-body timeline-container">
						<ul class="timeline">
							<li>
								<div class="timeline-badge warning"><em class="glyphicon glyphicon-link"></em></div>
								<div class="timeline-panel">
									<div class="timeline-heading">
										<h4 class="timeline-title"><b><asp:Literal ID="Literal4" runat="server"></asp:Literal></b></h4>
									</div>
								</div>
							</li>
							<li>
								<div class="timeline-badge primary"><em class="glyphicon glyphicon-link"></em></div>
								<div class="timeline-panel">
									<div class="timeline-heading">
										<h4 class="timeline-title"><b><asp:Literal ID="Literal5" runat="server"></asp:Literal></b></h4>
									</div>
								</div>
							</li>
							<li>
								<div class="timeline-badge info"><em class="glyphicon glyphicon-link"></em></div>
								<div class="timeline-panel">
									<div class="timeline-heading">
										<h4 class="timeline-title"><b><asp:Literal ID="Literal6" runat="server" ></asp:Literal></b></h4>
									</div>
								</div>
							</li>
							<li>
								<div class="timeline-badge info"><em class="glyphicon glyphicon-link"></em></div>
								<div class="timeline-panel">
									<div class="timeline-heading">
										<h4 class="timeline-title"><b><asp:Literal ID="Literal7" runat="server"></asp:Literal></b></h4>
									</div>
								</div>
							</li>
						</ul>
					</div>
				</div>
			</div><!--/.col-->
		
		<div class="col-md-6">
				<div class="panel panel-default">
					<div class="panel-heading">
						Keyword Update Form
						<span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span></div>
					<div class="panel-body">
							<fieldset>
								<!-- url input-->
								<div class="form-group">
									<label class="col-md-3 control-label" for="name">Url</label>
									<div class="col-md-9">
										<asp:TextBox id="url" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
									</div>
								</div>
								<!-- keyword -->
									<div class="form-group">
									<label id="lk1" class="col-md-3 control-label">keyword 1</label>
									<div class="col-md-9">
                                <asp:TextBox class="form-control" id="kw1" runat="server"></asp:TextBox>
									</div>
								</div>

								<!-- keyword -->
								<div class="form-group">
									<label id="lk2" class="col-md-3 control-label" >keyword 2</label>
									<div class="col-md-9">
                                <asp:TextBox class="form-control" id="kw2" runat="server"></asp:TextBox>
										<%--<textarea  name="message"></textarea>--%>
									</div>
								</div>

								<div class="form-group">
                                    <div class="col-md-3 control-label"><b><asp:Literal ID="lk3" runat="server"></asp:Literal></b></div>
									<%--<label id="lk3" >keyword 3</label>--%>
									<div class="col-md-9">
                                <asp:TextBox class="form-control" id="kw3" runat="server"></asp:TextBox>
									</div>
								</div>								
								
								<!-- Form actions -->
								<div class="form-group">
									<div class="col-md-12 widget-right">
										<asp:Button ID="Update" runat="server"  class="btn btn-primary btn-md pull-right" Text="Update" OnClick="Update_Click" />
										<%--<button type="submit">Submit</button>--%>
									</div>
								</div>
							</fieldset>
					</div>
				</div>
		</div>
		
	</div>	<!--/.main-->
		<script src="js/jquery-1.11.1.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
	<script src="js/chart.min.js"></script>
	<script src="js/chart-data.js"></script>
	<script src="js/easypiechart.js"></script>
	<script src="js/easypiechart-data.js"></script>
	<script src="js/bootstrap-datepicker.js"></script>
	<script src="js/custom.js"></script>
	</form>
</body>
</html>
