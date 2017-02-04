<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ScheduleEvents.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.ScheduleEvents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="Ptitle">Events Master</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">
        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
     <div class="form-group">
        <label for="txtEvent" class="control-label">Event</label>

        <asp:TextBox ID="txtEvent" class="validate[required] form-control" runat="server" placeholder="Event"></asp:TextBox>

    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
         <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary validate-skip" OnClick="btnClear_Click" />
    </div>
    <div class="form-group">
        <asp:GridView ID="gvEventMaster" DataKeyNames="ExerciseId" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-hover table-striped" OnRowCommand="gvEventMaster_RowCommand" >
            <Columns>
                <asp:BoundField DataField="ExerciseName" HeaderText="Event" />
                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" class="submit validate-skip" CommandArgument='<%# String.Format("{0}-{1}", Eval("ExerciseId"),Eval("ExerciseName")) %>'
                            CommandName="RowEdit" Text="Edit" Height="16px" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("ExerciseId") %>'
                            CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        

        <asp:HiddenField ID="HfUpdateID" runat="server" Value="0" />
        
    </div>
</asp:Content>
