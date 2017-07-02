<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayDetails.aspx.cs" Inherits="AntiClockFitnessCentre.Payment.PayDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <div class="container">
            <div class="login-form">
                <article class="contentbox">
                    <br />
                    <p><b>Rs.499</b> per month for your health and fitness program. It covers free personal trainer,dietician and physiotherapy once a month</p>
                    <br />
                    <asp:Button ID="btnPaynow" runat="server" CssClass="btn btn-primary" Text="Pay Now" OnClick="btnPaynow_Click" />
                    <input type="button" class="btn btn-primary" name="btnCancel" value="Cancel" onclick="CancelFrm(); return false;" />
                  
                    <br /><br />
                </article>
            </div>
        </div>
    </form>
</body>
</html>



