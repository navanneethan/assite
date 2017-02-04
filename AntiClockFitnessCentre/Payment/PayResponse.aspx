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
        <div class="container">
            <div class="login-form">
                <article class="contentbox">
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
                    <br />
                    <input type="button" class="btn btn-primary" name="btnCancel" value="Back to Login" onclick="CancelFrm(); return false;" />
                </article>
            </div>
        </div>
    </form>
</body>
</html>
