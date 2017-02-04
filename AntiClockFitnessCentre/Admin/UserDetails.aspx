<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" MasterPageFile="~/Admin/Admin.Master" Inherits="AntiClockFitnessCentre.Admin.UserDetails" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="Content2">
    <%--<script>
         $(document).ready(function () {
            $("#form1").validate({
                
                rules: {
                    <%=txtfirstname.UniqueID %>:  "required",
                    <%=txtlastname.UniqueID %>:"required",

                    <%=txtphonenumber.UniqueID %>:{  
                        required: true,
                        depends: function (element) {
                            return $(<%=rblusername.UniqueID %>).is(":checked");
                        }
                    
                    },
                    <%=txtemailid.UniqueID %>:{
                        required: true,
                        email: {
                            depends: function(element) {
                                return $(<%=rblusername.UniqueID %>).is(":checked");
                            }                       
                        
                        }
                    },
                    messages: {
                        <%=txtfirstname.UniqueID %>: {
                            required : "Username is required"
                        },
                        <%=txtlastname.UniqueID %>: {
                            required : "Password is required"
                        }
                    },
                    success: function() {
                        alert('ooooooooooo');
                    }
                }

             });

            
         });

         jQuery.validator.addMethod("billingRequired", function(value, element) {
             if ($("#bill_to_co").is(":checked"))
                 return $(element).parents(".subTable").length;
             return !this.optional(element);
         }, "");

        
        
        </script>--%>

    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    
    <div class="Ptitle">Add User Details</div>

    <div class="successMsg" id="successMsg" visible="false" runat="server">


        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>

    </div>
    <div class="errorMsg" id="errorMsg" visible="false" runat="server">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>



    <table id="tblRegister" runat="server" style="width: 100%">
         <tr>
            <td>Role</td>
            <td>
                <asp:DropDownList runat="server" class="validate[required] form-control" Width="70%" ID="ddlRole" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="txtfirstname" Width="70%" class="validate[required] text-input" runat="server"></asp:TextBox>
            </td>
            <td rowspan="4" style="">
                <asp:Image runat="server" ID="imgProfilepic" ImageAlign="Top" ImageUrl="~/images/nomale.png" Width="110px" Height="110px" /></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="txtlastname" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Member Number
            </td>
            <td>
                <asp:TextBox ID="txtMemberNumber" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>

            <td>Gender</td>
            <td>
                <asp:RadioButtonList ID="rblgender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>

        <%-- <tr>
            <td colspan="2">
                <table style="width: 70%">
                   
                </table>
            </td>
        </tr>--%>

        <tr>
            <td>Photo</td>
            <td>
                <asp:FileUpload ID="fuldphoto" runat="server" /></td>
        </tr>
        <tr>
            <td>UserName
            </td>
            <td>
                <asp:RadioButtonList ID="rblusername" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">Phone Number</asp:ListItem>
                    <asp:ListItem Value="2">Email-Id</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td>
                <asp:TextBox ID="txtphonenumber" class="validate[condRequired[ContentPlaceHolder1_rblusername_0],custom[phone]] text-input" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email-Id</td>
            <td>
                <asp:TextBox ID="txtemailid" class="validate[condRequired[ContentPlaceHolder1_rblusername_1],custom[email]] text-input" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                Trainer
            </td>
            <td>
                <asp:DropDownList runat="server" class="form-control" Width="70%" ID="ddlTrainer"></asp:DropDownList>
            </td>
        </tr>

       
        <tr>
            <td>Height</td>
            <td>
                <asp:TextBox ID="txtheight" class="validate[custom[integer]] text-input" Width="25%" runat="server"></asp:TextBox>
                CM &nbsp;&nbsp;&nbsp; Weight
                <asp:TextBox ID="txtweight" class="validate[custom[integer]] text-input" Width="25%" runat="server"></asp:TextBox>
                Kg
            </td>

        </tr>

        <tr>
            <td>DOB</td>
            <td>
                <asp:TextBox ID="txtdob" Width="25%" ClientIDMode="Static"  CssClass="m-wrap span12 date form_date" runat="server"></asp:TextBox>
                &nbsp; &nbsp; &nbsp; Active Till            
                <asp:TextBox ID="txtactivetill" Width="25%" ClientIDMode="Static" CssClass="validate[required] m-wrap span12 date form_date" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td>Addressline1</td>
            <td>
                <asp:TextBox ID="txtaddressline1" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>AddressLine2</td>
            <td>
                <asp:TextBox ID="txtaddressline2" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>City</td>
            <td>
                <asp:TextBox ID="txtcity" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>State</td>
            <td>
                <asp:TextBox ID="txtstate" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Country</td>
            <td>
                <asp:TextBox ID="txtcountry" Width="70%" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Goals</td>
            <td>
                <asp:TextBox ID="txtgoals" Height="100px" Width="70%" Style="resize: none" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Problem</td>
            <td>
                <asp:TextBox ID="txtproblems" Height="100px" Width="70%" Style="resize: none" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>

        <tr id="tdSTatus" runat="server">
            <td>Status</td>
            <td>
                <asp:CheckBox ID="ckbActive" runat="server" Text="Active" /></td>
        </tr>
        <tr>

            <td></td>
            <td style="display: block; text-align: center; margin: auto;">
                <table style="width: 50%">
                    <tr>
                        <td>
                            <asp:Button runat="server" class="btn btn-primary btn-block" ID="btnsave" Text="Save" OnClick="btnsave_Click" />
                        </td>
                        <td style="padding-left:5px;">
                            <asp:Button runat="server" class="btn btn-primary btn-block" ID="btnClear" Text="Clear" OnClick="btnClear_Click" /></td>
                    </tr>
                </table>

            </td>

        </tr>
    </table>
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
</script>
</asp:Content>
