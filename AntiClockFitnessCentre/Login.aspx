<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AntiClockFitnessCentre.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!--webfonts-->
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

                    },
                    '#<%=txtPassword.UniqueID %>': {
                        'required': {
                            'message': "Password is required."
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
    <!--//Validation  -->
</head>
<body>
    <!-----start-main---->
    <div class="main">
        <div class="login-form">
            <h1>Member Login</h1>
            <div class="head">
                <img src="images/user.png" alt="" />
            </div>
            <form id="form1" runat="server">
                <div class="errorMsg" id="failedmsg" runat="server" visible="false">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <asp:TextBox runat="server" ID="txtUserName" placeholder="Username" class="validate[required] text-input" data-validation-placeholder="USERNAME"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password" class="validate[required]  text-input" data-validation-placeholder="Password"></asp:TextBox>
                <div class="submit">
                    <asp:Button ID="btnLogin" Text="LOGIN" runat="server" OnClick="btnLogin_Click" />
                </div>
                <p><a href="Register.aspx">New User ?</a></p>
                <p><a href="ForgotPassword.aspx">Forgot Password ?</a></p>
            </form>
        </div>
        <!--//End-login-form-->
    </div>
    <!-----//end-main---->
</body>
</html>
