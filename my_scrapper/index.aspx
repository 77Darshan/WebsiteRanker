<%@ page language="c#" autoeventwireup="true" codebehind="index.aspx.cs" inherits="my_scrapper.register" %>

<!doctype html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>regester</title>
	<link rel = "icon" href = "free_sample_by_wix1.jpg" type = "image/x-icon">
	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
		<div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
			<div class="login-panel panel panel-default">
				<div class="panel-heading" style="height:178px"><img src="fp1.png" alt="logo" height="100%" width="100%"></div><div class="panel-heading"><b>registration form</b></div>
				<div class="panel-body">
					
						<fieldset>
							<div class="form-group">
								<asp:textbox id="txtname" runat="server" class="form-control" placeholder="name"></asp:textbox>
                                <asp:requiredfieldvalidator id="name_val" runat="server" validationgroup="validationsummary1" controltovalidate="txtname" errormessage="" forecolor="red" setfocusonerror="true"></asp:requiredfieldvalidator>
							</div>
							<div class="form-group">
								<asp:textbox id="txtcompany_name" runat="server" class="form-control" placeholder="company name" ></asp:textbox>
								<asp:requiredfieldvalidator id="com_val" runat="server"  validationgroup="validationsummary1" controltovalidate="txtcompany_name" errormessage="" forecolor="red" setfocusonerror="true"></asp:requiredfieldvalidator>
							</div>
                            <div class="form-group">
								<asp:textbox id="txtemail" runat="server" class="form-control" placeholder="e-mail"></asp:textbox>
								<asp:requiredfieldvalidator id="email_val" runat="server" validationgroup="validationsummary1" controltovalidate="txtemail" errormessage="" forecolor="red" setfocusonerror="true"></asp:requiredfieldvalidator>
								<asp:regularexpressionvalidator id="email_reg_exp_val" validationgroup="validationsummary1" controltovalidate="txtemail" setfocusonerror="true" runat="server" forecolor="red" validationexpression="^([a-za-z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-za-z0-9\-]+\.)+))([aza-z]{2,4}|[0-9]{1,3})(\]?)$" errormessage="enter vaild email"></asp:regularexpressionvalidator>
							</div>
							<div class="form-group">
								<asp:label runat="server" cssclass="label" text="gender" forecolor="black" font-size="medium">gender</asp:label>        
                                      <asp:dropdownlist id="gender" runat="server">
                                             <asp:listitem>male</asp:listitem>
                                             <asp:listitem>female</asp:listitem>
                                      </asp:dropdownlist>
							</div>
                            <div class="form-group">
								<asp:textbox id="txtctno" runat="server" class="form-control" placeholder="contact number" maxlength="10"></asp:textbox>
								<asp:requiredfieldvalidator id="con_val" runat="server" validationgroup="validationsummary1" controltovalidate="txtctno" errormessage="" forecolor="red" setfocusonerror="true"></asp:requiredfieldvalidator>
								<asp:regularexpressionvalidator id="conregexpval" validationgroup="validationsummary1" controltovalidate="txtctno" runat="server" setfocusonerror="true" forecolor="red" validationexpression="^[0-9]{0,10}$" errormessage="enter vaild number">*</asp:regularexpressionvalidator>
							
							</div>
                            <div class="form-group">
								<asp:textbox id="password" runat="server" class="form-control" placeholder="password" TextMode="Password"></asp:textbox>
								<asp:requiredfieldvalidator id="pass_val" runat="server" validationgroup="validationsummary1" controltovalidate="password" errormessage="" setfocusonerror="true" forecolor="red"></asp:requiredfieldvalidator>
								<asp:regularexpressionvalidator id="regularexpressionvalidator1"  validationgroup="validationsummary1" setfocusonerror="true" controltovalidate="password" runat="server" forecolor="red" validationexpression="(?!^[0-9]*$)(?!^[a-za-z]*$)^([a-za-z0-9]{8,15})$" errormessage="password must contain alphabets(at least one lowercase and one uppercase) with number(s) and must contain at least 8 characters"></asp:regularexpressionvalidator>
							
							</div>
                            <div class="text-left">
                                <asp:button runat="server" class="btn btn-primary" id="Submit" text="submit" OnClick="submit_Click" validationgroup="validationsummary1"/>
								<asp:button runat="server" class="btn btn-primary" id="back" text="back to login" onclick="back_Click"/>
                                <asp:literal id="literal1" runat="server"></asp:literal>
								<asp:validationsummary id="validationsummary1" runat="server" forecolor="red"/>
                            </div>
					</fieldset>
				</div>
			</div>
		</div>
	</div>
</form>
</body>
</html>