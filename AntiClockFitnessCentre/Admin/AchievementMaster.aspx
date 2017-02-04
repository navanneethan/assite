<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AchievementMaster.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.AchievementMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle">Achievement Master</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">


        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
    <div class="form-group">
        <label for="txtAchievement" class="control-label">Achievement</label>

        <asp:TextBox ID="txtAchievement" class="form-control" runat="server" placeholder="Achievement"></asp:TextBox>

    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
         <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btnClear_Click" />
    </div>
    <div class="form-group">
        <asp:GridView ID="gvAchevementMaster" DataKeyNames="AchievementID" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-hover table-striped" OnRowCommand="gvAchevementMaster_RowCommand" >
            <Columns>
                <asp:BoundField DataField="AchievementDetails" HeaderText="Achievement" />
                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" class="submit validate-skip" CommandArgument='<%# String.Format("{0}-{1}", Eval("AchievementID"),Eval("AchievementDetails")) %>'
                            CommandName="RowEdit" Text="Edit" Height="16px" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("AchievementID") %>'
                            CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div id="deleteModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="delModalLabel" aria-hidden="true">

            <div class="modal-header">

                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                <h3 id="delModalLabel">Delete Record</h3>

            </div>
            <div class="modal-body">
                Are you sure you want to delete the record?

            </div>
            <div class="modal-footer">

               <%-- <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-info" OnClick="btnDelete_Click" />--%>

                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>

            </div>
        </div>

        <asp:HiddenField ID="HfUpdateID" runat="server" Value="0" />
    </div>
</asp:Content>
