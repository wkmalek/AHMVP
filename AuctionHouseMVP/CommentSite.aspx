<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommentSite.aspx.cs" Inherits="AHWForm.CommentSite" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="CommentList" runat="server" DataKeyNames="Id" OnItemCommand="CommentList_OnItemCommand">
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr runat="server">
                    <td runat="server"><asp:Label Text="No data was returned."/></td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="background-color: #FFFBD6; color: #333333;">
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("AuctionUrl") %>' meta:resourcekey="HyperLinkResource1"><%# Eval("AuctionTitle") %></asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("BuyerUrl") %>' meta:resourcekey="HyperLinkResource2"><%# Eval("BuyerName") %></asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("SellerUrl") %>' meta:resourcekey="HyperLinkResource3"><%# Eval("SellerName") %></asp:HyperLink>
                </td>
                <td><%# Eval("Rate") %></td>
                <td><%# Eval("Description") %></td>
                <td>
                    <asp:Button runat="server" CommandName="Go" CommandArgument='<%# Eval("WriteCommentUrl") %>' Visible=<%# Eval("CommentGranted") %> meta:resourcekey="ButtonResource1"/>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #FFFBD6; color: #333333;">

                                <th runat="server">Title</th>

                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #FFCC66; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"/>
                                <asp:NumericPagerField/>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"/>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>