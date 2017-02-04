<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Trainee/TraineeNew.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="AntiClockFitnessCentre.ChangePassword" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="Content2">
    <style>
        .thcp {
            color: #7d7d7d;
        }
    </style>

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <div class="Ptitle">Change Password</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">
        <asp:Label ID="lblSucess" ForeColor="White" runat="server" Text=""></asp:Label>
    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">
        <p>
            <asp:Label ID="lblError" ForeColor="White" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <table style="width: 70%; align-content: center">
        <tr>
            <th class="thcp">Old Password</th>
            <td>
                <p>
                    <span>
                        <asp:TextBox ID="txtOldPassword" placeholder="Old Password" class="validate[required] text-input" runat="server"></asp:TextBox></span>
                </p>
            </td>
        </tr>
        <tr>
            <th class="thcp">New Password</th>
            <td>
                <p>
                    <input class="validate[required] text-input" placeholder="New Password" type="text" name="password" id="password" />
                </p>
            </td>
        </tr>
        <tr>
            <th class="thcp">Confirm Password</th>
            <td>
                <p>
                    <asp:TextBox ID="txtConfirmPassword" placeholder="Confirm Password" class="validate[required,equals[password]] text-input" runat="server"></asp:TextBox>
                </p>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" class="btn btn-primary btn-block" ID="btnsave" Style="width:75%" Text="Save" OnClick="btnsave_Click" />
            </td>
            <td>
                <asp:Button runat="server" class="btn btn-primary btn-block" ID="btnClear" Style="width:50%" Text="Clear" OnClick="btnClear_Click" /></td>
        </tr>
    </table>
</asp:Content>
