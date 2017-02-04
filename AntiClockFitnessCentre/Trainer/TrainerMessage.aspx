<%@ Page Title="" Language="C#" MasterPageFile="~/Trainer/TrainerNew.Master" AutoEventWireup="true" CodeBehind="TrainerMessage.aspx.cs" Inherits="AntiClockFitnessCentre.Trainer.TrainerMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
        #files1 {
            width: 14px;
            height: 16px;
            overflow: hidden;
            position: absolute;
            -moz-opacity: 0;
            filter: alpha(opacity: 0);
            opacity: 0;
            top: 0px;
        }

        .multiline{
            overflow:auto;
            resize:none;
        }



    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="details">
        <div class="form-group">
            <h2>Update Post</h2>
            <asp:TextBox ID="txtContent" TextMode="MultiLine" CssClass="form-control multiline"  runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <ul id="selectedFiles1" clientidmode="static" class="list-inline" runat="server"></ul>
        </div>
        <div class="form-inline">
            <div class="form-group">
                <div>
                    <span class="glyphicon glyphicon-camera" aria-hidden="true">        
                         <input type="file" id="files1" clientidmode="static" name="files" runat="server" multiple="multiple" accept="image/*" />             
                    </span>
                     <asp:Button ID="btnButton" CssClass="btn btn-primary btn-xs" runat="server" Text="Post" OnClick="btnButton_Click" />
                </div>
              
               
            </div>
        </div>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>

        <asp:DataList ID="dalstPost" runat="server" DataKeyField="PostId" Width="100%" OnItemCommand="dalstPost_ItemCommand" OnItemDataBound="dalstPost_ItemDataBound">
            <ItemTemplate>
                <div class="details">
                    <table>

                        <tr>
                            <td>
                                <img src="../images/nofemale.png" style="height: 40px; width: 40px" />

                                <asp:Label ID="lblPostedBy" Style="font-weight: bold; color: orange;" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                                Posted On        
         <asp:Label ID="lblPostedOnDate" Style="color: grey; font-size: 12px;" runat="server"  Text='<%#Eval("PostCreatedOn") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblPostContent" Text='<%#Eval("PostContent") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hddStoeimg" runat="server" Value='<%#Eval("PostContentImage") %>' />

                                <div id="DivImages" runat="server"></div>
                                <div id="push"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbtnLike" runat="server" Text="Like" OnClick="lbtnLike_Click" CommandArgument='<%#Eval("PostId") %>'></asp:LinkButton>

                                <asp:LinkButton ID="LinkCommentLike" runat="server" OnClick="LinkCommentLike_Click" CommandArgument='<%#Eval("PostId") %>' Text="Comment"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="RepDetails" runat="server">
                                    <ItemTemplate>

                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCommentedBy" Style="font-weight: bold; color: orange;" runat="server" Text='<%#Eval("FullNameComment") %>'></asp:Label>
                                Commented On        
         <asp:Label ID="lblCommentedOnDate" Style="color: grey; font-size: 12px;" runat="server"  Text='<%#Eval("CommentCreatedOn") %>'></asp:Label>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td>
                                                     <p>  <asp:Label runat="server" ID="lblcomments" Text='<%#Eval("CommentContent") %>'></asp:Label></p>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="1" Columns="40" CssClass="form-control multiline" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmitComment" CssClass="btn btn-primary btn-xs" runat="server" Text="Submit" CommandArgument='<%#Eval("PostId") %>' CommandName="SubmitComment" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <asp:HiddenField ID="hddimg" runat="server" />
</asp:Content>
