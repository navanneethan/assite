<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewOpinionPoll.aspx.cs" Inherits="AntiClockFitnessCentre.Admin.ViewOpinionPoll" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Ptitle">View Opinion Polls</div>
      <div class="errorMsg" id="errorMsg" runat="server" visible="false">


        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>
<%--     <asp:Chart ID="chart1" runat="server" Style="height: 200px; width: 300px;">
                                            <Titles>
                                                <asp:Title ShadowOffset="3" Name="Items" />
                                            </Titles>
                                            <Series>
                                                <asp:Series Color="#F2622D">
                                                </asp:Series>
                                            </Series>
                                            <Legends>
                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                                            </Legends>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1">
                                                    <AxisY Title="Poll Users" />
                                                </asp:ChartArea>

                                            </ChartAreas>

                                        </asp:Chart>--%>
    <asp:GridView runat="server" ID="gvOpinionPoll" DataKeyNames="PollId" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped" OnPageIndexChanging="gvOpinionPoll_PageIndexChanging" OnRowDataBound="gvOpinionPoll_RowDataBound" OnRowCommand="gvOpinionPoll_RowCommand">
        <Columns>
            <asp:BoundField DataField="PollQuestion" ItemStyle-Wrap="true" HeaderText="Question" />
            <asp:BoundField DataField="PollStartDate" DataFormatString="{0: dd MMMM yyyy}" ItemStyle-Width="18%" HeaderText="Start Date" />
            <asp:BoundField DataField="PollEndDate" DataFormatString="{0: dd MMMM yyyy}" ItemStyle-Width="18%" HeaderText="End Date" />
           <%-- <asp:BoundField DataField="PollOptions" ItemStyle-Wrap="true" HeaderText="Choices" />--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    Choices
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPollChart" runat="server" ClientIDMode="static" Text="View" data-toggle="modal" CommandArgument='<%# Eval("PollId") %>' data-target='<%# Eval("PollId","#Model{0}") %>'></asp:LinkButton>

                    <!-- /.modal -->
                    <div id='Model<%# Eval("PollId") %>' class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <!-- /.modal-dialog -->
                            <div class="modal-content">
                                <!-- /.modal-content -->
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4>Poll Choices (%)</h4>
                                </div>
                                <div class="modal-body">
                                        <asp:Chart ID="crtPollUsers" runat="server" Style="height: 250px; width: 500px;">
                                            <Titles>
                                                <asp:Title ShadowOffset="3" Name="Items" />
                                            </Titles>
                                            <Series>
                                                <asp:Series Color="#F2622D">
                                                </asp:Series>
                                            </Series>
                                            <Legends>
                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                                            </Legends>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1">
                                                    <AxisY Title="Poll Users" IntervalType="Number"  />
                                                </asp:ChartArea>

                                            </ChartAreas>

                                        </asp:Chart>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>

                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                        <!-- /.modal -->
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("PollId") %>'
                        CommandName="RowEdit" Text="Edit" Height="16px" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/images/delete.png" ID="btnDelete" runat="server" class="submit validate-skip" CommandArgument='<%# Eval("PollId") %>'
                        CommandName="RowDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
