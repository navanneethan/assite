<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Master.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="AntiClockFitnessCentre.SuperAdmin.Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type='text/javascript'>
        $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();

        $("#form1").validate({
            rules:{
                "#txtCompanyName": {
                    required: true,
                    minlength: 3
                }
            },
            messages: {
                "#txtCompanyName": "Enter a Company Name"
            }
            
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="Ptitle">Company</div>
    <div class="successMsg" id="successMsg" runat="server" visible="false">
        <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
    </div>
    <div class="errorMsg" id="errorMsg" runat="server" style="display:none">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <label for="txtCompanyName" class="control-label">Company Name</label>
        <asp:TextBox ID="txtCompanyName" runat="server" ClientIDMode="Static" class="validate[required] form-control" placeholder="Company Name" ></asp:TextBox>  
    </div>
    <div class="form-group">
        <label for="txtCompanyCode" class="">Company Code</label>
        <asp:TextBox ID="txtCompanyCode" runat="server" ClientIDMode="Static" class="validate[required] form-control" MaxLength="3" placeholder="Company Name"></asp:TextBox>
    </div>   
     <div class="form-group">
        <label for="fupCompanyLogo" class="control-label">Company Logo</label>
        <asp:FileUpload ID="fupCompanyLogo" class="btn btn-primary btn-block" runat="server"  />
    </div>
     <div class="form-group">            
        <img id="imgLogoPreview" runat="server"  data-toggle="tooltip" class="img-responsive" />
              
    </div>
     <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary submit validate-skip" OnClick="btnClear_Click" />
    </div>
    <div class="form-group">
        <asp:GridView ID="gvCompany" DataKeyNames="CompanyId" runat="server" PageSize="10"  AllowPaging="true" AutoGenerateColumns="false" OnRowCommand="gvCompany_RowCommand" OnRowDataBound="gvCompany_RowDataBound" OnPageIndexChanging="gvCompany_PageIndexChanging" CssClass="table table-hover table-striped">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="CompanyName" />
                 <asp:BoundField HeaderText="Code" DataField="CompanyCode" />
                <asp:TemplateField ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderTemplate>
                        Logo
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkLogo" runat="server" ClientIDMode="static" Text="View" data-toggle="modal" data-target='<%# Eval("CompanyId","#Model{0}") %>' ></asp:LinkButton>
                        <asp:Label ID="lblNoLogo" runat="server" Visible="false" Text="No Logo"></asp:Label>
                        <!-- /.modal -->
                        <div id='Model<%# Eval("CompanyId") %>' class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <!-- /.modal-dialog -->
                                <div class="modal-content">
                                    <!-- /.modal-content -->
                                    <div class="modal-header">
                                        Company Logo
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <img src='<%# Eval("CompanyLogo","../Uploads/{0}") %>' id="imgmlogo" runat="server" class="img-responsive" />
                                    </div>
                                    <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            </div>
                            <!-- /.modal -->
                        </ItemTemplate>
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                      
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" class="submit validate-skip" runat="server"  CommandArgument='<%# Eval("CompanyId") %>'
                            CommandName="RowEdit" Text="Edit" Height="16px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" class="submit validate-skip" runat="server"  CommandArgument='<%# Eval("CompanyId") %>'
                            CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    <asp:HiddenField ID="hddId" Value="0" runat="server"  />
    <asp:HiddenField ID="hddMode" Value="Save" runat="server" />
    <asp:HiddenField ID="hddLogo"  runat="server" />

    <%--<script>

        function centerModal() {
            $(this).css('display', 'block');
            var $dialog = $(this).find(".modal-dialog");
            var offset = ($(window).height() - $dialog.height()) / 2;
            // Center modal vertically in window
            $dialog.css("margin-top", offset);
        }

        $('.modal').on('show.bs.modal', centerModal);
        $(window).on("resize", function () {
            $('.modal:visible').each(centerModal);
        });
    </script>


     <script >

         $(document).ready(function () {
             

             //$('#form1').validate({
             //    rules: {
             //    }
             //});
         });
         </script>--%>
</asp:Content>
