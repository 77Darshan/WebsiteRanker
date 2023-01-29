<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_info.aspx.cs" Inherits="my_scrapper.Payment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Informaiton</title>
    <link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon">
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
                    <div class="panel-heading">Add Details</div>
                    <div class="panel-body">

                        <fieldset>
                            <div class="form-group">
                                 <asp:TextBox runat="server" class="form-control" placeholder="Enter URL" ID="txturl1" required="required"></asp:TextBox>
                                <%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus="">--%>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" placeholder="Keyword 1" ID="Txtkey1" required="required"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" placeholder="Keyword 2" ID="Txtkey2" required="required"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" placeholder="Keyword 3" ID="Txtkey3" required="required"></asp:TextBox>
                            </div>
                            <div class="text-left">
                                 <asp:Button runat="server" CssClass="btn btn-primary" Text="SUBMIT & Proceed" ID="btn_pay" OnClick="btn_pay_Click"  />
                                <%-- ------------------------------------------------------ --%>
                                <br />
                                <asp:Button ID="btn_pay_basic" runat="server" CssClass="btn btn-primary" Text="SUBMIT & Proceed"  class="razorpay-embed-btn" data-url="https://pages.razorpay.com/pl_GxBKfeWfXIXN8C/view" data-text="Submit and Proceed to Payment" data-color="#528FF0" data-size="large" OnClick="btn_pay_basic_Click" />
                                 <script>
                                     (function () {
                                        var d = document; var x = !d.getElementById('razorpay-embed-btn-js')
                                        if (x) {
                                             var s = d.createElement('script'); s.defer = !0; s.id = 'razorpay-embed-btn-js';
                                            s.src = 'https://cdn.razorpay.com/static/embed_btn/bundle.js'; d.body.appendChild(s);
                                        } else {
                                            var rzp = window['__rzp__'];
                                            rzp && rzp.init && rzp.init()
                                        }
                                     })();
                                 </script>

                                <%-- -------------------------------------------- --%>
                                <br />
                                
                               <asp:Button ID="btn_pay_prem" CssClass="btn btn-primary" runat="server" Text="SUBMIT & Proceed" class="razorpay-embed-btn" data-url="https://pages.razorpay.com/pl_GxBUdu2N3Ip6PJ/view" data-text="Pay Now" data-color="#528FF0" data-size="large" OnClick="btn_pay_prem_Click" />
                                 <script>
                                      (function () {
                                          var d = document; var x = !d.getElementById('razorpay-embed-btn-js')
                                          if (x) {
                                              var s = d.createElement('script'); s.defer = !0; s.id = 'razorpay-embed-btn-js';
                                              s.src = 'https://cdn.razorpay.com/static/embed_btn/bundle.js'; d.body.appendChild(s);
                                          } else {
                                              var rzp = window['__rzp__'];
                                              rzp && rzp.init && rzp.init()
                                          }
                                      })();
                                  </script>
                            <div>
                                 <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                 <br />
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                 <br />
                                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                 <br />
                                 <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                                 <br />
                                <asp:TextBox runat="server" class="form-control" placeholder="Enter Secret code here" ID="pay_ver" required="required"></asp:TextBox>
                                 <br />
                                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Proceed" OnClick="Button1_Click" />
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
       
    </form>
</body>
</html>
