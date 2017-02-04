<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AntiClockFitnessCentre.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />

    <link href="css/fitness.css" rel='stylesheet' type='text/css' />

    <script src="../js/jquery-1.11.2.min.js"></script>
    <script src="js/jquery.validate.js"></script>
   
    <script type = "text/javascript" >
        function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
           <div class="login-form">
                <article class="contentbox">
                    <div class="Ptitle">Member Register</div>
                    <div class="successMsg" id="successMsg" visible="false" runat="server">
                        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="errorMsg" id="errorMsg" visible="false" runat="server">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group has-feedback">
                        <label for="ddlCompany">Company</label>
                        <div >
                        <asp:DropDownList runat="server" class="form-control" ID="ddlCompany">
                        </asp:DropDownList>
                            </div>
                        <span class="glyphicon form-control-feedback" id="ddlCompany1"></span>
                    </div>


                    <div class="form-group has-feedback">
                        <label for="txtfirstname">First Name</label>
                        <div>
                        <asp:TextBox ID="txtfirstname" MaxLength="30" runat="server" class="form-control" placeholder="First Name"></asp:TextBox>
                             </div>
                        <span class="glyphicon form-control-feedback" id="txtfirstname1"></span>

                    </div>
                    <div class="form-group">
                        <label for="txtlastname">Last Name</label>
                        <asp:TextBox ID="txtlastname" MaxLength="30" runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="rblgender">Gender</label>
                        <asp:RadioButtonList ID="rblgender" CssClass="radio" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                        <label for="txtdob">Date of Birth</label>
                        <asp:TextBox runat="server" MaxLength="30" ClientIDMode="Static" placeholder="DOB" CssClass="form-control form_date" ID="txtdob"></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <label for="rblusername">UserName</label>
                        <asp:RadioButtonList ID="rblusername" runat="server" class="radio" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Phone Number</asp:ListItem>
                            <asp:ListItem Value="2">Email-Id</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group has-feedback">
                        <label for="txtphonenumber">Phone Number</label>
                        <div class="input-group input-group-sm">
                            <span class="input-group-addon ">+91</span>
                            <asp:TextBox ID="txtphonenumber" runat="server" placeholder="Phone Number" MaxLength="10" class="form-control"></asp:TextBox>
                             </div>
                            <span class="glyphicon form-control-feedback" id="txtphonenumber1"></span>
                       
                    </div>
                    <div class="form-group has-feedback">
                        <label for="txtemailid">Email-Id</label>
                        <div class="input-group input-group-sm">
                            <span class="input-group-addon ">@</span>
                            <asp:TextBox ID="txtemailid" runat="server" placeholder="Email-Id" class="form-control"></asp:TextBox>
                            </div>
                            <span class="glyphicon form-control-feedback" id="txtemailid1"></span>
                        
                    </div>

                    <div class="form-group">
                       

                            <label for="txtheight">Height</label>
                            <div class="input-group input-group-sm">
                                 <span class="input-group-addon ">CM</span>
                                <asp:TextBox runat="server" MaxLength="3" class="form-control" placeholder="CM" ID="txtheight"></asp:TextBox>
                               
                            </div>

                        </div>

                    <div class="form-group">
                       
                            <label for="txtweight">Weight</label>
                            <div class="input-group input-group-sm">
                                  <span class="input-group-addon ">KG</span>
                                <asp:TextBox runat="server" MaxLength="3" class="form-control" placeholder="KG" ID="txtweight"></asp:TextBox>
                              
                            </div>

                        </div>              
                 


                    <div class="form-group">
                        <label for="txtaddressline1">Addressline1</label>
                        <asp:TextBox runat="server" class="form-control" MaxLength="50" placeholder="Addressline1" ID="txtaddressline1"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtaddressline2">Addressline2</label>
                        <asp:TextBox runat="server" class="form-control" MaxLength="50" placeholder="Addressline2" ID="txtaddressline2"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtcity">City</label>
                        <asp:TextBox runat="server" class="form-control" MaxLength="50" placeholder="City" ID="txtcity"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtstate">State</label>
                        <asp:TextBox runat="server" class="form-control" MaxLength="30" placeholder="State" ID="txtstate"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtcountry">Country</label>
                        <asp:TextBox runat="server" class="form-control" MaxLength="30" placeholder="Country" ID="txtcountry"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtgoals">Goals</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="200" Style="resize: none" Rows="3" class="form-control" placeholder="Fitness Goals" ID="txtgoals"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtproblems">Problems</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" MaxLength="200" Style="resize: none" Rows="3" class="form-control" placeholder="Health Problems" ID="txtproblems"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary submit validate-skip" OnClick="btnCancel_Click" />
                    </div>
                </article>
            </div>
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

            jQuery.validator.addMethod('heightnumber', function (value, element) {
                return this.optional(element) || /^(1[0-9][0-9])$/.test(value);
            },'Please enter numbers only.');

            jQuery.validator.addMethod('weightnumber', function (value, element) {
                return this.optional(element) || /^([1-9][0-9]|[1-3][0-9][0-9])$/.test(value);
            },'Please enter numbers only.');


            jQuery.validator.addMethod('lettersonly', function(value, element){
                return this.optional(element) || /^[A-Za-z ]+$/.test(value);
            }, ' ');




            $(document).ready(function() {
                $('#form1').validate(
          {
              rules: {
                  <%=ddlCompany.UniqueID %> :{
                       required: true
                   },
                  <%=txtfirstname.UniqueID %> : {
                      required: true,
                      minlength: 3,                    
                      lettersonly: true
                  },     
                  <%=txtphonenumber.UniqueID %> :{
                      required: true,
                      digits: true,
                      minlength: 10,
                      maxlength:10
                  },
                  <%=txtemailid.UniqueID %> :{
                      required: true,
                      email: true
                  } ,
                  <%=txtheight.UniqueID %> :{                       
                      heightnumber : true
                  },
                  <%=txtweight.UniqueID %> :{
                       weightnumber : true
                   }
              },
              messages:
                  {
                      <%=ddlCompany.UniqueID %> : "Select Company",
                     <%=txtfirstname.UniqueID %> :{
                         required : "Please enter a  First Name",
                         lettersonly : "Please enter alphabets only"
                     },
                      <%=txtphonenumber.UniqueID %> : "Please enter a Phone Number",
                      <%=txtemailid.UniqueID %> : "Please enter a valid email address"
                  },
             
              highlight: function(element) {
                  var id_attr = "#" + $( element ).attr("id") + "1";
                  $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
                  $(id_attr).removeClass('glyphicon-ok').addClass('glyphicon-remove');         
              },
              unhighlight: function(element) {
                  var id_attr = "#" + $( element ).attr("id") + "1";
                  $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
                  $(id_attr).removeClass('glyphicon-remove').addClass('glyphicon-ok');         
              },
             
              errorElement: 'span',
              errorClass: 'help-block',
              errorPlacement: function(error, element) {                  
                   if(element.length) {
                       error.insertAfter(element.parent());
                   }
                   else {
                       error.insertAfter(element);
                   }
                  
              } 
          });

               
            });
</script>

    </form>
</body>
</html>
