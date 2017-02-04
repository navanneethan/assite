<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EvalutionResult.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.EvalutionResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">


        (function ($) {
            $.fn.checkFileType = function (options) {
                var defaults = {
                    allowedExtensions: [],
                    success: function () { },
                    error: function () { },

                };
                options = $.extend(defaults, options);

                return this.each(function () {

                    $(this).on('change', function () {
                        var value = $(this).val(),
                            file = value.toLowerCase(),
                            extension = file.substring(file.lastIndexOf('.') + 1);


                        if ($.inArray(extension, options.allowedExtensions) == -1) {
                            options.error();
                            $(this).focus();
                        } else {
                            options.success();

                        }

                    });

                });
            };

        })(jQuery);


        $(function () {

            $('#<%=fupEvalutionResult.ClientID %>').checkFileType({
                allowedExtensions: ['pdf'],
                success: function () {
                    $('#<%=errorMsg.ClientID %>').css('display', 'none');
                },
                error: function () {
                    $('#<%=errorMsg.ClientID %>').css('display', 'block');
                    $('#<%= lblError.ClientID %>').html("Only '.pdf' format is allowed.");
                    $('.errorMsg').show('slide', callback);
                    function callback() { setTimeout(function () { $('.errorMsg').fadeOut(); }, 2500); };

                }

            });
           

        });
    </script>
   <script type = "text/javascript">

       function ConfirmDelete() {
           var count = document.getElementById("<%=hfCount.ClientID %>").value;
           var gv = document.getElementById("<%=gvEvaluation.ClientID%>");
           var chk = gv.getElementsByTagName("input");
           for (var i = 0; i < chk.length; i++) {
               if (chk[i].checked && chk[i].id.indexOf("chkAll") == -1) {
                   count++;
               }
           }
           if (count == 0) {
               alert("No records to delete.");
               return false;
           }
           else {
               return confirm("Do you want to delete " + count + " record(s).");
           }
       }

       function Check_Click(objRef) {
           //Get the Row based on checkbox
           var row = objRef.parentNode.parentNode;
           if (objRef.checked) {
               //If checked change color to Aqua
               row.style.backgroundColor = "red";
           }
           else {
               //If not checked change back to original color
               row.style.backgroundColor = "#f9f9f9";
               if (row.rowIndex % 2 == 0) {
                   //Alternating Row Color
                  // row.style.backgroundColor = "#C2D69B";
               }
               else {
                  // row.style.backgroundColor = "white";
               }
           }

           //Get the reference of GridView
           var GridView = row.parentNode;

           //Get all input elements in Gridview
           var inputList = GridView.getElementsByTagName("input");

           for (var i = 0; i < inputList.length; i++) {
               //The First element is the Header Checkbox
               var headerCheckBox = inputList[0];

               //Based on all or none checkboxes
               //are checked check/uncheck Header Checkbox
               var checked = true;
               if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                   if (!inputList[i].checked) {
                       checked = false;
                       break;
                   }
               }
           }
           headerCheckBox.checked = checked;

       }

       function checkAll(objRef) {
          
           var GridView = objRef.parentNode.parentNode.parentNode.parentNode;
          
           var inputList = GridView.getElementsByTagName("input");
          
           for (var i = 0; i < inputList.length; i++) {
               //Get the Cell To find out ColumnIndex
               var row = inputList[i].parentNode.parentNode;
              // alert(objRef);
               if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                   if (objRef.checked) {
                      
                       //If the header checkbox is checked
                       //check all checkboxes
                       //and highlight all rows
                       row.style.backgroundColor = "red";
                       
                       inputList[i].checked = true;
                   }
                   else {
                       //If the header checkbox is checked
                       //uncheck all checkboxes
                       //and change rowcolor back to original
                       //if (row.rowIndex % 2 == 0) {
                       //    //Alternating Row Color
                       //    row.style.backgroundColor = "#C2D69B";
                       //}
                       //else {
                       row.style.backgroundColor = "#f9f9f9";
                       //}
                       inputList[i].checked = false;
                   }
               }
           }
       }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle">Evalution Results</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">
        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
    </div>
    <div class="errorMsg" id="errorMsg" runat="server" style="display: none">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label for="ddlUsers" class="control-label">User</label>
        <asp:DropDownList class="validate[required] form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" ID="ddlUsers" ></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="fupEvalutionResult" class="control-label">Evalution PDF</label>
        <asp:FileUpload ID="fupEvalutionResult" class="validate[required] btn btn-primary btn-block" runat="server" />
        <%--<div class="progress">
		<div class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;">
			<span class="sr-only">0% completespan</span>
		</div>
	</div>--%>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary submit validate-skip" OnClick="btnClear_Click" />
    </div>
    <div class="form-group">
        <asp:GridView ID="gvEvaluation" DataKeyNames="EvaluationId" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table table-hover table-striped" OnRowDataBound="gvEvaluation_RowDataBound" OnPageIndexChanging="gvEvaluation_PageIndexChanging" OnRowCommand="gvEvaluation_RowCommand">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="Trainee" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        Result
                    </HeaderTemplate>
                    <ItemTemplate>

                        <asp:LinkButton ID="lnkResult" runat="server" ClientIDMode="static" Text="View" data-toggle="modal" data-target='<%# Eval("EvaluationId","#Model{0}") %>' data-local='<%# Eval("EvaluationId","#Carousel{0}") %>'></asp:LinkButton>
                        <div id='Carousel<%# Eval("EvaluationId") %>' class="carousel slide carousel-fit" data-ride="carousel" data-interval="60000" style="display: none;height:90%">

                            <!-- Wrapper for slides -->
                            <div class="carousel-inner" clientidmode="static" id="divslider" runat="server" style='height:100%;'>
                            </div>


                            <!-- Controls -->
                            <%--<a class="left carousel-control" href='#Carousel<%# Eval("EvaluationId") %>' data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                            </a>
                            <a class="right carousel-control" href='#Carousel<%# Eval("EvaluationId") %>' data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right"></span>
                            </a>--%>

                        </div>
                        <!-- /.modal -->
                        <div id='Model<%# Eval("EvaluationId") %>' class="modal fade" tabindex="-1" role="dialog" aria-labelledby="evaluationPDFModalLabel" aria-hidden="true">
                            <div class="modal-dialog" style='width:90%;height:100%;'>
                                <!-- /.modal-dialog -->
                                <div class="modal-content" style='height:91%;'>
                                    <!-- /.modal-content -->
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 id="evaluationPDFModalLabel">Evaluation PDF</h4>
                                    </div>
                                    <div class="modal-body" style='height:90%;'>
                                    </div>
                                    <%--<div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>--%>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            </div>
                            <!-- /.modal -->
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("EvaluationId") %>'
                            CommandName="RowEdit" Text="Edit" Height="16px" />
                    </ItemTemplate>

                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Select" ItemStyle-Width="5%">
                            <HeaderTemplate>
            <asp:CheckBox ID="chkAll" runat="server" data-toggle="tooltip" title="Select All"
             onclick = "checkAll(this);" />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="chk" runat="server"
             onclick = "Check_Click(this)"/>
        </ItemTemplate>
                        </asp:TemplateField>
              <%--  <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("EvaluationId") %>'
                            CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
    <asp:HiddenField ID="hdID" runat="server" Value="0" />
    <asp:HiddenField ID="hdFile" runat="server" />
    <asp:HiddenField ID="hdMode" runat="server" Value="Save" />
      <asp:HiddenField ID="hfCount" runat="server" Value = "0" />
<asp:Button ID="btnDelete" runat="server" Width="30%"   class="btn btn-primary btn-block submit validate-skip" Text="Delete Checked Records"
   OnClientClick = "return ConfirmDelete();" OnClick="btnDelete_Click" />
        <script type='text/javascript'>

            $(document).ready(function () {
                $('[data-toggle="tooltip"]').tooltip();
                
                $('.modal').on('show.bs.modal', function (e) {
                    $(this).css('display', 'block');
                    var id = $(this).attr('id');

                    var len = id.length;
                    var idnum = id.substr(5, len);
                    $('#Carousel' + idnum).css('display', 'block');



                });

                $('.modal').on('hidden.bs.modal', function (e) {
                    var id = $(this).attr('id');

                    var isdisplay = $('#lnkResult').attr('data-local');

                    if (typeof isdisplay !== typeof undefined && isdisplay !== false) {
                        var len = id.length;
                        var idnum = id.substr(5, len);
                        $('#Carousel' + idnum).css('display', 'none');
                    }
                    else {

                    }


                })

            });

    </script>

</asp:Content>


