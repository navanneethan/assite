<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="AntiClockFitnessCentre.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <meta charset="utf-8">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!--webfonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css'>
    <!--//webfonts-->
    <!--//Validation  -->
    <link href="css/Validation/customMessages.css" rel="stylesheet" />
    <link href="css/Validation/template.css" rel="stylesheet" />
    <link href="css/Validation/validationEngine.jquery.css" rel="stylesheet" />
    <script src="js/Validations/jquery-1.8.2.min.js"></script>
    <script src="js/Validations/jquery.validationEngine.js"></script>
    <script src="js/Validations/jquery.validationEngine-en.js"></script>
    <link href="css/loginstyle.css" rel='stylesheet' type='text/css' />
    <script>
        $.validationEngine.defaults.autoPositionUpdate = true;
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine({
                'custom_error_messages': {
                    // Custom Error Messages for Validation Types
                    '#<%=txtUserName.UniqueID %>': {
                        'required': {
                            'message': "Username is required."
                        }

                    }

                }
            });

            jQuery("#form1").validationEngine('attach', { autoPositionUpdate: true });
            jQuery('input').attr('data-prompt-position', 'topLeft');
            jQuery('input').data('promptPosition', 'topLeft');
            jQuery('textarea').attr('data-prompt-position', 'topLeft');
            jQuery('textarea').data('promptPosition', 'topLeft');
            jQuery('select').attr('data-prompt-position', 'topLeft');
            jQuery('select').data('promptPosition', 'topLeft');

        });    </script>
</head>
<body>
      <!-----start-main---->
    <div class="main">
        <div class="login-form">
            <h1>Forgot Password</h1>
            <div class="head">
                <img src="images/user.png" alt="" />
            </div>
            <form id="form1" runat="server">

                <div class="errorMsg" id="failedmsg" runat="server" visible="false">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    
                </div>
                <br />
                <h2>Enter Username</h2>
                <asp:TextBox runat="server" ID="txtUserName" Text="USERNAME" onfocus="this.value = '';" class="validate[required] text-input" data-validation-placeholder="USERNAME" onblur="if (this.value == '') {this.value = 'USERNAME';}" ></asp:TextBox>
                <div class="submit">
                    <asp:Button ID="btnSubmit" Text="Submit" Width="45%" runat="server" OnClick="btnSubmit_Click"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" Text="Cancel" Width="45%" runat="server" class="submit validate-skip" OnClick="btnCancel_Click" />
                </div>
                <p><asp:Label ID="lblpassword" runat="server" Visible="false"  CssClass="successMsg" ></asp:Label></p>
                
               
                
               
            </form>
        </div>
        <!--//End-login-form-->

    </div>
    <!-----//end-main---->
</body>
</html>
