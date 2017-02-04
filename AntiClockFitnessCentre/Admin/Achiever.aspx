<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Achiever.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.Achiever" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle">Manage Achievements</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">
        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
    <div class="form-group">
        <label for="ddlAchievement">Achievement</label>
        <asp:DropDownList ID="ddlAchievement" class="form-control" runat="server"></asp:DropDownList>
        <%--<asp:TextBox ID="txtAchievement" class="form-control" runat="server" placeholder="Achievement"></asp:TextBox>--%>
    </div>
    <div class="form-group">
        <label for="ddlAchiever">Achiever</label>
        <asp:DropDownList ID="ddlAchiever" class="form-control" runat="server"></asp:DropDownList>
        <%--<asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Achievement"></asp:TextBox>--%>
    </div>
    <div class="form-group">
        <label for="txtMonthFor">Month For</label>
        <asp:TextBox ID="txtMonthFor" ClientIDMode="Static" class="form-control m-wrap span12 date form_date" runat="server" placeholder="Achievement"></asp:TextBox>
    </div>
    <div class="form-group" >
        <label for="txtNumber" >Record</label>
        <asp:TextBox ID="txtNumber" ClientIDMode="Static" class="form-control" runat="server" placeholder="Record"></asp:TextBox>
    </div>
    <div class="form-group">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
         <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary submit validate-skip" OnClick="btnClear_Click" />
         <asp:HiddenField ID="HfUpdateID" runat="server" Value="0" />
        </div>
    <div class="form-group">
         <asp:GridView ID="gvAchiever" DataKeyNames="AchieverId" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-hover table-striped" OnRowCommand="gvAchiever_RowCommand" >
            <Columns>
                 <asp:BoundField DataField="AchieverMasterDetails" HeaderText="Achievement" />
                 <asp:BoundField DataField="FullName" HeaderText="Achiever" />
                 <asp:BoundField DataField="AchievedMonthFor" DataFormatString="{0:MMMM/yyyy}" HeaderText="Achieved Month" />
                 <asp:BoundField DataField="AchievedNumber" HeaderText="Record" />
                 <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("AchieverId") %>'
                            CommandName="RowEdit" Text="Edit" Height="16px" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("AchieverId") %>'
                            CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
             </asp:GridView>
    </div>
    
    <script src="../js/bootstrap-datetimepicker.js"></script>
 
    <script type="text/javascript">
       
        $('.form_date').datetimepicker({
            autoclose: 1,           
            startView: "year",
            minView: 'year',
            viewselect: 'year',
            
            viewMode: 'years',
            format: 'MM/yyyy'          

        });
        
        </script>
</asp:Content>
