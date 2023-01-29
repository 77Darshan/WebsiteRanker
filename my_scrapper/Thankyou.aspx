<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thankyou.aspx.cs" Inherits="my_scrapper.Thankyou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
    <title>Thank you</title>
    <link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon">
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <div class="jumbotron text-center">
  <h1 class="display-3">Thank You!</h1>
  <p class="lead">
      Your subscription of 
      <strong><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </strong>
      &nbsp;is successful.
  </p>
  <hr />
  <p class="lead">
    <a class="btn btn-primary btn-sm" href="https://localhost:44353/login.aspx" role="button">Continue to Login</a>
  </p>
</div>
        </div>
    </form>
</body>
</html>
