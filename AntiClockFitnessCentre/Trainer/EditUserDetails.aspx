<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUserDetails.aspx.cs" MasterPageFile="~/Trainer/TrainerNew.Master" Inherits="AntiClockFitnessCentre.Trainer.EditUserDetails" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

     <asp:GridView ID="gvUserDetails" HeaderStyle-BackColor="#cfcfcf" RowStyle-Font-Size="0.75em" DataKeyNames="UserID" runat="server" AutoGenerateColumns="False" Width="90%"   OnRowCancelingEdit="gvUserDetails_RowCancelingEdit" OnRowEditing="gvUserDetails_RowEditing" OnRowUpdating="gvUserDetails_RowUpdating">
        <Columns>
            
             <asp:TemplateField HeaderText="UserId" Visible="false" HeaderStyle-CssClass="title" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbluserid" runat="server" Text='<%# Eval("UserID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
             <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center"   ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblfullname" runat="server" Text='<%# String.Format("{0}  {1}", Eval("FirstName"), Eval("LastName")) %>' />
                            </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Gender" HeaderStyle-HorizontalAlign="Center"   ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblGender" runat="server" Text='<%#  Eval("Gender") %>' />
                            </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Age" HeaderStyle-HorizontalAlign="Center"   ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAge" runat="server" Text='<%#  Eval("Age") %>' />
                            </ItemTemplate>
             </asp:TemplateField>
            
        
             <asp:TemplateField HeaderText="Height" HeaderStyle-HorizontalAlign="Center"  ItemStyle-Width="15%"  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblHeight" runat="server" Text='<%# String.Format("{0} CM", Eval("Height")) %>' />
                            </ItemTemplate>
                 <EditItemTemplate>
                     <asp:TextBox ID="txtHeight" runat="server"  Text='<%# Eval("Height") %>' ></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Weight" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%"  ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblWeight" runat="server" Text='<%# String.Format("{0} KG", Eval("Weight")) %>' />
                            </ItemTemplate>
                  <EditItemTemplate>
                     <asp:TextBox ID="txtWeight" runat="server"  Text='<%# Eval("Weight") %>' ></asp:TextBox>
                 </EditItemTemplate>
             </asp:TemplateField> 
 
           
            <asp:TemplateField HeaderText="Edit" ItemStyle-Width="20%"  ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/edit.png" ID="btnEdit" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="Edit" Text="Edit" Height="16px"  />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                   <asp:LinkButton ID="btnupdate" CommandArgument='<%# Eval("UserID") %>' runat="server" 
			CommandName="Update" Text="Update" ></asp:LinkButton>
                   <asp:LinkButton ID="btncancel" runat="server" 
			CommandName="Cancel" Text="Cancel"></asp:LinkButton>
               </EditItemTemplate>
                                </asp:TemplateField>
                              
        </Columns>

    </asp:GridView>
</asp:Content>
