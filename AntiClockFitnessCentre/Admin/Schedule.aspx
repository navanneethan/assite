<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.Schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle">Schedule</div>

     <div class="successMsg" id="successMsg" runat="server" visible="false">


        <asp:Label ID="lblSucess"  runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">

       
            <asp:Label ID="lblError"  runat="server" Text=""></asp:Label>
        
    </div>
    <div class="form-group">
        <label for="ddlUser">Users</label>
        <asp:DropDownList ID="ddlUser" runat="server" CssClass="validate[required] form-control"></asp:DropDownList>
    </div>
     <div class="form-group">
        <label for="ddlExercise">Event</label>
         <asp:DropDownList ID="ddlExercise" runat="server" CssClass="validate[required] form-control"></asp:DropDownList>
    </div>
     <div class="form-group">
        <label for="txtVenu">Venu</label>
        <asp:TextBox ID="txtVenu" runat="server" CssClass="validate[required] form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="ddlTrainer">Trainer</label>
        <asp:DropDownList ID="ddlTrainer" runat="server" CssClass="validate[required] form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtScheduleDate">Start Date</label>
       <asp:TextBox ID="txtScheduleDate"  ClientIDMode="Static" runat="server" CssClass="validate[required] m-wrap span12 date form_datetime" ></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtEndDate">End Date</label>
       <asp:TextBox ID="txtEndDate" ClientIDMode="Static" runat="server" CssClass="validate[required] m-wrap span12 date form_datetime" ></asp:TextBox>
    </div>
   <%-- <div class="form-group">
        <label for="ckbStatus">Status</label>
         <asp:CheckBox ID="ckbStatus" runat="server"  />
    </div>--%>
    <div class="form-group">
        <asp:Button ID="btnSave" class="btn btn-primary"  runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnclear" class="btn btn-primary submit validate-skip"  runat="server" Text="Clear" OnClick="btnclear_Click" />
    </div>
   <div class="form-group">  
   
                <asp:GridView ID="gvSchedule" CssClass="table table-hover table-striped"  runat="server" OnPageIndexChanging="gvSchedule_PageIndexChanging" AutoGenerateColumns="False" OnRowCommand="gvSchedule_RowCommand">
                   <%-- <HeaderStyle CssClass="HeaderStyle" />
             <FooterStyle CssClass="FooterStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
             <PagerStyle CssClass="PagerStyle" /> --%>
                    <Columns>
                        <asp:TemplateField HeaderText="ScheduleId" Visible="false" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblScheduleId" runat="server" Text='<%# Eval("ScheduleID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="ExerciseDetails" HeaderText="Event" />
                          <asp:BoundField DataField="Venu" HeaderText="Venu" />
                        <asp:TemplateField HeaderText="Start Date" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblScheduleStartDate" runat="server" Text='<%# Eval("StartDate", "{0:dd MMMM yyyy}")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblScheduleEndDate" runat="server" Text='<%# Eval("EndDate", "{0:dd MMMM yyyy}")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("ScheduleID") %>'
                                    CommandName="RowEdit" Text="Edit" Height="16px" />
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("ScheduleID") %>'
                                    CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
          </div>
    <asp:HiddenField ID="hdID" runat="server" />
    <asp:HiddenField ID="hdMode" runat="server" Value="Save" />
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">
        $('.form_datetime').datetimepicker({
            //language:  'fr',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            forceParse: 0,
            showMeridian: 1,
            format: "dd MM yyyy - HH:ii p"
        });
</script>

</asp:Content>
