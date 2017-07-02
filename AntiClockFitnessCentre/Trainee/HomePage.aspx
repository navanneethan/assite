<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" MasterPageFile="~/Trainee/TraineeNew.Master" Inherits="AntiClockFitnessCentre.Trainee.HomePage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <div id="myVideo" runat="server" >
        
    </div>
    <%--<div class="image">
        <img src="../images/page-001.jpg" style="width: 100%;" alt="" />
    </div>
    <div class="details">
        <h2>Today's Video</h2>
        <p>Tips and tricks to stay healthy </p>
    </div>--%>
    <script type="text/javascript">
    jQuery(".modal-backdrop, #myModal .close, #myModal .btn").live("click", function() {
        jQuery("#myModal iframe").attr("src", jQuery("#myModal iframe").attr("src"));
    });
        </script>
</asp:Content>
