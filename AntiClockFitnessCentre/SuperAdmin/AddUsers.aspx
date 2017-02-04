<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Master.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="AntiClockFitnessCentre.SuperAdmin.AddUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowPreview(input) {
            //var fileExtension = ['jpeg', 'jpg', 'png', 'gif', 'bmp'];
            //if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
            //    alert("Only '.jpeg','.jpg', '.png', '.gif', '.bmp' formats are allowed.");
            //}
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    $('#imgPreview').attr('border-radius', '50%');
                    $('#imgPreview').attr('src', e.target.result);
                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle"> <asp:Label ID="lblPtitle" runat="server"></asp:Label></div>
    <div class="successMsg" id="successMsg" visible="false" runat="server">
        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
    </div>
    <div class="errorMsg" id="errorMsg" visible="false" runat="server">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label for="ddlCompany">Company</label>
        <asp:DropDownList runat="server" class="validate[required] form-control"  ID="ddlCompany" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
    </div>
     <div class="form-group">
        <label for="ddlRole">Role</label>
        <asp:DropDownList runat="server" class="validate[required] form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" ID="ddlRole"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtfirstname">First Name</label>
        <asp:TextBox ID="txtfirstname" runat="server" class="validate[required] text-input" placeholder="First Name"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtlastname">Last Name</label>
        <asp:TextBox ID="txtlastname" runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtMemberNumber">Member Number</label>
        <asp:TextBox ID="txtMemberNumber" runat="server" class="form-control" placeholder="Member Number" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="rblgender">Gender</label>
        <asp:RadioButtonList ID="rblgender" CssClass="radio" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="form-group">
        <label for="fuldphoto">Photo</label>
        <asp:FileUpload ID="fuldphoto" class="btn btn-primary btn-block" onChange="ShowPreview(this)" runat="server" />
    </div>
    <div class="form-group">
        <asp:Image ID="imgPreview" ClientIDMode="Static" data-toggle="tooltip" title="Logo Preview" CssClass="img-responsive" runat="server" />
        <%--<img id="imgLogoPreview"   runat="server"  data-toggle="tooltip" title="Logo Preview"  />--%>
    </div>
    <div class="form-group">
        <label for="rblusername">UserName</label>
        <asp:RadioButtonList ID="rblusername" runat="server" class="radio" AutoPostBack="true" RepeatDirection="Horizontal">
            <asp:ListItem Value="1" Selected="True">Phone Number</asp:ListItem>
            <asp:ListItem Value="2">Email-Id</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="form-group">
        <label for="txtphonenumber">Phone Number</label>
        <asp:TextBox ID="txtphonenumber" runat="server" placeholder="Phone Number" class="validate[condRequired[ContentPlaceHolder1_rblusername_0],custom[phone]] text-input"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtemailid">Email-Id</label>
        <asp:TextBox ID="txtemailid" runat="server" placeholder="Email-Id" class="validate[condRequired[ContentPlaceHolder1_rblusername_1],custom[email]] text-input"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="ddlTrainer">Trainer</label>
        <asp:DropDownList runat="server" class="form-control" ID="ddlTrainer"></asp:DropDownList>
    </div>   
    <div class="form-group">
       <div class="col-xs-6">          
                
                 <label for="txtheight">Height</label>
           <div class="input-group input-group-sm">          
                <asp:TextBox runat="server" class="validate[custom[integer]] text-input form-control" placeholder="CM" ID="txtheight"></asp:TextBox>
               <span class="input-group-addon " >CM</span>
               </div>
             
            </div>
       
   
        <div class="col-xs-6">
           <label for="txtweight">Weight</label>
               <div class="input-group input-group-sm">        
                <asp:TextBox runat="server" class="form-control validate[custom[integer]] text-input" placeholder="KG" ID="txtweight"></asp:TextBox>
                 <span class="input-group-addon " >KG</span>
               </div>
            
            </div>
        
    </div>
   
        <div class="form-group">
        <div class="col-xs-6">
             <label for="txtdob">DOB</label>           
                <asp:TextBox runat="server" ClientIDMode="Static" placeholder="DOB" CssClass="form-control m-wrap span12 date form_date" ID="txtdob"></asp:TextBox>
           
        </div>
        
        <div class="col-xs-6">
            <label for="txtactivetill">Active Till</label>
            
                <asp:TextBox runat="server" ClientIDMode="Static" placeholder="Active Till" CssClass=" form-control validate[required] m-wrap span12 date form_date" ID="txtactivetill"></asp:TextBox>
           
       </div>
    </div>
   
    <div class="form-group">
        <label for="txtaddressline1">Addressline1</label>
        <asp:TextBox runat="server" class="form-control" placeholder="Addressline1" ID="txtaddressline1"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtaddressline2">Addressline2</label>
        <asp:TextBox runat="server" class="form-control" placeholder="Addressline2" ID="txtaddressline2"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtcity">City</label>
        <asp:TextBox runat="server" class="form-control" placeholder="City" ID="txtcity"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtstate">State</label>
        <asp:TextBox runat="server" class="form-control" placeholder="State" ID="txtstate"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtcountry">Country</label>
        <asp:TextBox runat="server" class="form-control" placeholder="Country" ID="txtcountry"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtgoals">Goals</label>
        <asp:TextBox runat="server" class="form-control" placeholder="Fitness Goals" ID="txtgoals"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtproblems">Problems</label>
        <asp:TextBox runat="server" class="form-control" placeholder="Health Problems" ID="txtproblems"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnsave_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary submit validate-skip" OnClick="btnClear_Click" />
    </div>

    <asp:HiddenField ID="hddID" Value="0" runat="server" />
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

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();


        });
</script>
</asp:Content>
