<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forget_psw.aspx.cs" Inherits="my_scrapper.forget_psw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Forget Password</title>
	<link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon"/>
	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="row">
		<div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
			<div class="login-panel panel panel-default">
				<div class="panel-heading" style="height:178px"><img src="fp1.png" alt="logo" height="100%" width="100%" /></div><div class="panel-heading"><b>Forget Password - There's always a 2nd Chance</b></div>
				<div class="panel-body">
						<fieldset>
							<div class="form-group">
								<asp:TextBox ID="email" runat="server" class="form-control" placeholder="ENTER E-mail"></asp:TextBox>
								<%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus="">--%>
								<asp:TextBox ID="otp" runat="server" class="form-control" placeholder="ENTER OTP"></asp:TextBox>
								<%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus="">--%>
								<asp:TextBox ID="new_password" runat="server" class="form-control" placeholder="ENTER New Password"></asp:TextBox>
								<%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus="">--%>
					       <asp:Button runat="server" class="btn btn-primary" ID="submit" Text="Submit" OnClick="submit_Click"/>
							<asp:Button runat="server" class="btn btn-primary" ID="sub" Text="submit" OnClick="otp_Click"/>
                            <asp:Button runat="server" class="btn btn-primary" ID="update" Text="Submit" OnClick="update_Click" OnClientClick="alert('Your password is updated')"/>
							 <asp:Button runat="server" class="btn btn-primary" ID="back" Text="Back to Login" OnClick="back_Click"/> <asp:Literal ID="Literal1" runat="server"></asp:Literal><asp:Literal ID="Literal2" runat="server"></asp:Literal>
								</div>
                       </fieldset>
				</div>
			</div>
		</div><!-- /.col-->
	</div><!-- /.row -->	
   
    </form>
</body>
</html>
