<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OpinionPoll.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.OpinionPoll" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="Ptitle">Opinion Polls</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">


        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" runat="server" visible="false">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
     <div class="form-group">
        <label for="txtQuestion" class="control-label">Question</label>

        <asp:TextBox ID="txtQuestion" class="form-control" runat="server" placeholder="Question"></asp:TextBox>

    </div>
     <div class="form-group">
        <label for="fuldphoto" class="control-label">Image(Optional)</label>        
        <asp:FileUpload ID="fuldphoto" class="form-control" onChange="ShowPreview(this)" runat="server" />
           
          <asp:Image runat="server" class="form-control" ClientIDMode="Static" ID="imgPollpic" Width="304" Height="236" ImageAlign="Top" />
    </div>
    <div  class="form-group">
         <label for="txtPollStartDate" class="control-label">Start Date</label> 
        <asp:TextBox ID="txtPollStartDate" class="form-control m-wrap span12 date form_datetime" ClientIDMode="Static" runat="server" placeholder="Start Date"></asp:TextBox>
         <label for="txtPollEndDate" class="control-label">End Date</label> 
        <asp:TextBox ID="txtPollEndDate" class="form-control m-wrap span12 date form_datetime" ClientIDMode="Static" runat="server" placeholder="End Date"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtOption1" class="control-label">Choices(User can Select one answer only)</label> 
        <div class="form-group">
         <label for="txtOption1" class="control-label">Option 1</label> 
            <asp:HiddenField ID="hddOp1" runat="server" Value="0" />
        <asp:TextBox ID="txtOption1" class="form-control" runat="server" placeholder="Option 1"></asp:TextBox>
         <label for="txtOption2" class="control-label">Option 2</label> 
              <asp:HiddenField ID="hddOp2" runat="server" Value="0" />
        <asp:TextBox ID="txtOption2" class="form-control" runat="server" placeholder="Option 2"></asp:TextBox>
            <label for="txtOption3" class="control-label">Option 3</label> 
              <asp:HiddenField ID="hddOp3" runat="server" Value="0" />
        <asp:TextBox ID="txtOption3" class="form-control" runat="server" placeholder="Option 3"></asp:TextBox>
            <label for="txtOption4" class="control-label">Option 4</label> 
              <asp:HiddenField ID="hddOp4" runat="server" Value="0" />
        <asp:TextBox ID="txtOption4" class="form-control" runat="server" placeholder="Option 4"></asp:TextBox>
            </div>
    </div>
    <div class="form-group">
         <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
         <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btnClear_Click"  />
        <asp:HiddenField ID="HfUpdateID" runat="server" Value="0" />
    </div>
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
            format: "dd MM yyyy"
        });
</script>
</asp:Content>
