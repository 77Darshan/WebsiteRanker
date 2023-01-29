<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="my_scrapper.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/styles.css" rel="stylesheet" />
    <script type="text/javascript">
        window.history.forward();
        function noBack() {
            window.history.forward();
        }
    </script>
</head>
<body onload="noBack();" onpageshow="if (event.persisted) noBack();" onunload="">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading" style="height:178px"><img src="fp1.png" alt="logo" height="100%" width="100%" /></div><div class="panel-heading"><b>Log in</b></div>
                    <div class="panel-body">

                        <fieldset>
                            <div class="form-group">
                                <asp:TextBox ID="email" runat="server" class="form-control" placeholder="E-mail"></asp:TextBox>
                                <%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus="">--%>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="psw" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="checkbox">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </div>
                            <div class="text-left">
                                <asp:Button runat="server" class="btn btn-primary" ID="submit" Text="Login" OnClick="login_Click" />
                            </div>
                            <div class="text-right">
                                <a href="forget_psw.aspx">Forget Password</a>&nbsp;
                                <a href="index.aspx">Register New User</a>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
       
    </form>
</body>
</html>
