<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="price.aspx.cs" Inherits="my_scrapper.price" %>

<!DOCTYPE html>

<html>
	
<head>
	<title>Select Plan</title>
	<link rel = "icon" href = "Free_Sample_By_Wix1.jpg" type = "image/x-icon">
	<link rel="stylesheet" href="price_1.css"/>
</head>
	<body>
		<form runat="server" >
	<div class="pricing-wrapper clearfix">
		<!-- Title-->
		<h1 class="pricing-table-title">Here are our OFFERS..<a href="http://creaticode.com"></a></h1>

		<div class="pricing-table">
			<h3 class="pricing-title">Free Demo</h3>
			<div class="price">FREE<sup></sup></div>
			<!-- List the Charateristics / Properties -->
			<ul class="table-list">
				<li>1 URL <span></span></li>
				<li>1 keyword <span></span></li>
				<li>On the Spot Results. <span></span></li>
				<li>Demonstration <span class="unlimited">Free</span></li>
				<li>Search Engine <span class="unlimited">Google</span><span class="unlimited">Bing</span><span class="unlimited">Yahoo</span></li>
				<%--<li>CPanel <span>incluido</span></li>--%>
			</ul>
			<!-- Button -->
			<div class="table-buy">
				<p>FREE!!<sup></sup></p>
				<%--<a href="#" class="pricing-action">START TRAIL NOW!</a>--%>
				 
					<div>
					<asp:Button class="pricing-action" runat="server" Text="START TRAIL NOW!" ID="btn_trail" OnClick="btn_trail_Click"></asp:Button>
					</div>
				 
				
			</div>
		</div>
		
		<div class="pricing-table recommended">
			<h3 class="pricing-title">Premium</h3>
			<div class="price">Rs 4999<sup></sup></div>
			<!-- List the Charateristics / Properties -->
			<ul class="table-list">
				<li>1 URL <span></span></li>
				<li>3 Keyword <span></span></li>
				<li>1 Year <span></span></li>
				<li>Chart, Mailing Facility <span class="unlimited2">Free</span></li>
				<li>Search Engine<span class="unlimited2">Google</span><span class="unlimited2">Bing</span><span class="unlimited2">Yahoo</span></li>
				<%--<li>CPanel <span>incluido</span></li>--%>
			</ul>
			<!-- Button -->
			<div class="table-buy">
				<p>Rs 4999<sup></sup></p>
				<%--<a href="#" class="pricing-action">BUY NOW!</a>--%>
				<asp:Button class="pricing-action" runat="server" Text="BUY NOW!" ID="btn_premium" OnClick="btn_premium_Click"></asp:Button>
			</div>
		</div>

		<div class="pricing-table">
			<h3 class="pricing-title">Basic</h3>
			<div class="price">Rs 3499<sup></sup></div>
			<!-- List the Charateristics / Properties -->
			<ul class="table-list">
				<li>1 URL <span></span></li>
				<li>2 Keywords <span></span></li>
				<li>6 Months <span></span></li>
				<li>Chart, Mailing Facility<span class="unlimited">Free</span></li>
				<li>Search Engine <span class="unlimited">Google</span><span class="unlimited">Bing</span><span class="unlimited">Yahoo</span></li>
				<%--<li>CPanel <span>incluido</span></li>--%>
			</ul>
			<!-- Button -->
			<div class="table-buy">
				<p>Rs 3499<sup></sup></p>
				<%--<a href="#" class="pricing-action">BUY NOW!</a>--%>
				<asp:Button class="pricing-action" runat="server" Text="BUY NOW!" ID="btn_basic" OnClick="btn_basic_Click"></asp:Button>
			</div>
		</div>
	</div>
			</form>
		</body>
	</html>
