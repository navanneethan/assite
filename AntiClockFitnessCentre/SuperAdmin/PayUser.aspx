<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Master.Master" AutoEventWireup="true" CodeBehind="PayUser.aspx.cs" Inherits="AntiClockFitnessCentre.SuperAdmin.PayUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="successMsg" id="successMsg" runat="server" visible="false">
        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
    <div class="form-group">
        <label for="ddlCompany">Company</label>
        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="validate[required] form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlUser">Users</label>
        <asp:DropDownList ID="ddlUser" runat="server" CssClass="validate[required] form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlMonths">Months</label>
        <asp:DropDownList ID="ddlMonths" runat="server" CssClass="validate[required] form-control">
            <asp:ListItem Text="One month" Value="1"></asp:ListItem>
            <asp:ListItem Text="Three months" Value="3"></asp:ListItem>
            <asp:ListItem Text="Six months" Value="6"></asp:ListItem>
            <asp:ListItem Text="One year" Value="12"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        </div>
</asp:Content>
