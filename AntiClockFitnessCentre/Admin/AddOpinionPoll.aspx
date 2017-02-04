<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddOpinionPoll.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.AddOpinionPoll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowPreview(input) {
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    $('#imgPollpic').attr('class', 'img-thumbnail');
                    //$('#imgPollpic').attr('width', '304');
                    //$('#imgPollpic').attr('height', '236');
                    $('#imgPollpic').attr('src', e.target.result);
                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../js/jquery.validate.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server"   ></asp:ScriptManager>
    <div class="Ptitle">Opinion Polls</div>

    <div class="successMsg" id="successMsg" runat="server" visible="false">


        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
   
    <div class="form-group">
        <label for="txtQuestion" class="control-label">Question</label>

        <asp:TextBox ID="txtQuestion" class="validate[required] form-control" runat="server" placeholder="Question" ></asp:TextBox>

    </div>
    <div class="form-group">
        <label for="fuldphoto" class="control-label">Image(Optional)</label>
        <asp:FileUpload ID="fuldphoto" class="btn btn-primary btn-block" onChange="ShowPreview(this)" runat="server" />

        <asp:Image runat="server" class="form-control" ClientIDMode="Static" ID="imgPollpic" Width="304" Height="236" ImageAlign="Top" />
    </div>
    <div class="form-group">
        <label for="txtPollStartDate" class="control-label">Start Date</label>
        <input type="text" readonly="readonly" runat="server" id="txtPollStartDate" class="validate[required] form-control m-wrap span12 date form_date" placeholder="Start Date" clientidmode="Static" required/>
        <%--<asp:TextBox ID="txtPollStartDate" class="form-control m-wrap span12 date form_datetime" ReadOnly="true" ClientIDMode="Static" runat="server" placeholder="Start Date"></asp:TextBox>--%>
        <label for="txtPollEndDate" class="control-label">End Date</label>
         <input type="text" readonly="readonly" runat="server" id="txtPollEndDate" class="validate[required] form-control m-wrap span12 date form_date" placeholder="End Date" clientidmode="Static" required/>
        <%--<asp:TextBox ID="txtPollEndDate" class="form-control m-wrap span12 date form_datetime" ClientIDMode="Static" runat="server" placeholder="End Date"></asp:TextBox>--%>
    </div>
    
            <div class="form-group">
                <label for="txtOption1" class="control-label">Choices(User can Select one answer only)</label>
                <div class="form-group">
                     <asp:UpdatePanel ID="upPanael" runat="server" >
        <ContentTemplate>
                    <asp:Repeater runat="server" ID="repOptions">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:Label ID="lblRowNumber" class="control-label" Text='<%# Eval("RowNumer", "Option {0}") %>' runat="server" />
                                <%-- <label for="txtOption" id="lblOption"  class="control-label">Option 1</label>--%>
                                <asp:TextBox ID="txtOption" class="form-control" runat="server" placeholder="Option" Text='<%# Eval("PollOptionName") %>' ></asp:TextBox>
                                <asp:Button ID="btnAddO" runat="server" Text="Add" CssClass="btn btn-info btn-sm" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnDeleteO" runat="server" Text="Delete" CssClass="btn btn-info btn-sm submit validate-skip" CommandArgument='<%# Eval("RowNumer") %>'  OnClick="btnDeleteO_Click" />
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                    </ContentTemplate>
    </asp:UpdatePanel>
                </div>
            </div>
             <div class="form-group">
         <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
         <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary submit validate-skip" OnClick="btnClear_Click"  />
        <asp:HiddenField ID="HfUpdateID" runat="server" Value="0" />
    </div>
       
     <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">
        $('.form_date').datetimepicker({
            language: 'fr',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: "dd MM yyyy"
        });
</script>
</asp:Content>
