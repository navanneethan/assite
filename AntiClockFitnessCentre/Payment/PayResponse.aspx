<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayResponse.aspx.cs" Inherits="AntiClockFitnessCentre.Payment.PayResponse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/fitness.css" rel="stylesheet" />

    <script src="../js/jquery-1.11.2.min.js"></script>
      <script type="text/javascript">
    function CancelFrm(){        
        window.location = "../Logout.aspx";
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        	<section id="navigation" class="dark-nav">
		<!-- Navigation Inner -->
		<div class="nav-inner">
			<!-- Site Logo -->
			<div class="site-logo">
				<a href="#" id="logo-text" class="scroll logo">
                    <img src="../images/asphealth.png" alt="AtSaiPavi Health" height="72px" />
                   <%-- AtSaiPavi Physio & Fitness--%>
				</a>
			</div><!-- End Site Logo -->
			<a class="mini-nav-button gray2"><i class="fa fa-bars"></i></a>
			<!-- Navigation Menu -->
		   
		</div><!-- End Navigation Inner -->
	</section><!-- End Navigation Section -->

        <div class="container">
            <div id="main" style="min-height: 500px;padding-top:20px;">
                    <div id="paySuccess" class="payment" runat="server">
            <div class="head">
                PAYMENT - SUCCESS</div>
            <div style="display: table; width: 100%;">
                <div class="paymentrow">
                    <div class="paymentleft paymentbottom">
                        Transaction ID</div>
                    <div class="paymentright paymentbottom">
                        <asp:Label runat="server" ID="lblID" /></div>
                </div>
                <div class="paymentrow">
                    <div class="paymentleft paymentbottom">
                        Transaction Amount</div>
                    <div class="paymentright paymentbottom">
                        <asp:Label runat="server" ID="lblAmount" /></div>
                </div>
                <div class="paymentrow">
                    <div class="paymentleft ">
                        Transaction Date</div>
                    <div class="paymentright ">
                        <asp:Label runat="server" ID="lblTransactionDate" /></div>
                </div>
            </div>
        </div>
        <div id="payFailure" class="payment" runat="server">
            <div class="head">
                Transaction Failed :
                <br />
                <asp:Label runat="server" ID="lblResponseMessage" />
            </div>
        </div>
        <div id="paySuccessMes" runat="server" class="payment" style="border: 0px !important;
            margin-top: 20px;">
            We have send you a copy of receipt to your email <b>
            <asp:Label runat="server" ID="lblEmailAddress" /></b>. Thank you for choosing AtSaiPavi.<br/><br/>
            <%--<button id="backHome" runat="server" onserverclick="backHome_Click" class="wpb_button wpb_btn-rounded wpb_btn-small">Back to Home</button>--%>
            <input type="button" class="btn btn-primary" name="btnCancel" value="Back to Login" onclick="CancelFrm(); return false;" />

        </div>

<%--
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    <br />--%>
                    
               </div>
        </div>
    </form>
</body>
</html>
