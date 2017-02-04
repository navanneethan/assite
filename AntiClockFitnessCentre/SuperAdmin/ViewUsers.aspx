<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Master.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="AntiClockFitnessCentre.SuperAdmin.ViewUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle">View User Deatsils</div>
    <div class="errorMsg" id="errorMsg" visible="false" runat="server">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <asp:GridView ID="gvUserDetails" runat="server" CssClass="table table-hover table-striped" PageSize="10" AllowPaging="true" AutoGenerateColumns="False"  OnRowDataBound="gvUserDetails_RowDataBound" OnRowCommand="gvUserDetails_RowCommand" OnPageIndexChanging="gvUserDetails_PageIndexChanging">
           <%-- <HeaderStyle CssClass="HeaderStyle" />
            <FooterStyle CssClass="FooterStyle" />
            <RowStyle CssClass="RowStyle" />
            <AlternatingRowStyle CssClass="AlternatingRowStyle" />--%>
            
            <PagerStyle  CssClass="PagerStyle" />
            <Columns>
                <asp:TemplateField HeaderText="UserId" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbluserid" runat="server" Text='<%# Eval("UserID") %>' />
                    </ItemTemplate>

                   
                </asp:TemplateField>
                <asp:BoundField DataField="CompanyName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Company" > 
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblfullname" runat="server" Text='<%# String.Format("{0}  {1}", Eval("FirstName"), Eval("LastName")) %>' />
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="Gender" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Gender">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="UserName" ItemStyle-HorizontalAlign="Center" HeaderText="Username">

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Role" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblrole" runat="server" Text='<%#Eval("RoleName")%>' />
                    </ItemTemplate>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" CommandArgument='<%# Eval("UserID") %>'
                            CommandName="RowEdit" Text="Edit" Height="16px" />
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" CommandArgument='<%# Eval("UserID") %>'
                            CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            
            

        </asp:GridView>
    </div>
</asp:Content>
