<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/TraineeNew.Master" AutoEventWireup="true" CodeBehind="TraineeMessages.aspx.cs" Inherits="AntiClockFitnessCentre.Trainee.TraineeMessages" %>

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

        .multiline {
            overflow: auto;
            resize: none;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="details">
        <div class="form-group">
            <h3>Update Post</h3>
            <asp:TextBox ID="txtContent" TextMode="MultiLine" CssClass="form-control multiline" placeholder="what is in your mind?" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <ul id="selectedFiles1" clientidmode="static" class="list-inline" runat="server"></ul>
        </div>
        <div class="form-inline message-buttons">
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
                <div class="post-details">
                    <table>

                        <tr>
                            <td>
                                <asp:Image ID="imgUser" runat="server" ImageUrl='<%# Eval("PostFromId","~/Admin/ProfileImage.ashx?ID={0}") %>' Width="40px" Height="40px" />

                                <asp:Label ID="lblPostedBy" Style="font-weight: bold; color: orange;" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                                Posted On        
                             <asp:Label ID="lblPostedOnDate" Style="color: grey; font-size: 12px;" runat="server" Text='<%#Eval("PostCreatedOn") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="message-post">
                                    <asp:Label runat="server" ID="lblPostContent" Text='<%#Eval("PostContent") %>'></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hddStoeimg" runat="server" Value='<%#Eval("PostContentImage") %>' />
                                <div id="DivImages" runat="server"></div>
                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-body">
                                            </div>
                                        </div>
                                        <!-- /.modal-content -->
                                    </div>
                                    <!-- /.modal-dialog -->
                                </div>
                                <!-- /.modal -->
                                <div id="push"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbtnLike" CssClass="post-likes" runat="server" Text="Like" OnClick="lbtnLike_Click" CommandArgument='<%#Eval("PostId") %>'></asp:LinkButton>

                                <asp:LinkButton ID="LinkCommentLike" CssClass="post-likes" runat="server" OnClick="LinkCommentLike_Click" CommandArgument='<%#Eval("PostId") %>' Text="Comment"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="RepDetails" runat="server">
                                    <ItemTemplate>
                                        <div class="post-comments">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div class="post-comments-text">
                                                            <asp:Label ID="lblCommentedBy" CssClass="post-comments-text-name" runat="server" Text='<%#Eval("FullNameComment") %>'></asp:Label>
                                                            Commented On        
         <asp:Label ID="lblCommentedOnDate" Style="color: grey; font-size: 12px;" runat="server" Text='<%#Eval("CommentCreatedOn") %>'></asp:Label>
                                                        </div>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <p>
                                                            <asp:Label runat="server" CssClass="post-comments-text" ID="lblcomments" Text='<%#Eval("CommentContent") %>'></asp:Label>
                                                        </p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </td>
                        </tr>


                        <tr>
                            <td>
                                <div class="post-comments">
                                    <asp:TextBox ID="txtComment" Placeholder="Comments" TextMode="MultiLine" Rows="1" Columns="40" CssClass="multiline " runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="post-comments">
                                    <asp:Button ID="btnSubmitComment" CssClass="btn btn-primary btn-xs" runat="server" Text="Submit" CommandArgument='<%#Eval("PostId") %>' CommandName="SubmitComment" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <asp:HiddenField ID="hddimg" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.delRow').on('click', function () {
                var src = $(this).attr('src');
                var img = '<img src="' + src + '" class="img-responsive"/>';
                $('#myModal').modal();
                $('#myModal').on('shown.bs.modal', function () {
                    $('#myModal .modal-body').html(img);
                });
                $('#myModal').on('hidden.bs.modal', function () {
                    $('#myModal .modal-body').html('');
                });
            });
        })
    </script>
</asp:Content>
