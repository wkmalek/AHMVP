<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionListPage.aspx.cs" Inherits="AHWForm.AuctionListPage" meta:resourcekey="PageResource1" %>
<%@ Register Src="SortControl.ascx" TagName="SortControl" TagPrefix="uc" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    
    <uc:SortControl runat="server" ID="sortControl" meta:resourcekey="SortControl" />
    
    <asp:ListView ID="AuctionList" runat="server" ItemType="AHWForm.Models.AuctionListSingleElemVM" >
        
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr runat="server">
                    <td runat="server"><asp:Label runat="server"/></td>
                </tr>
            </table>
        </EmptyDataTemplate>

        <ItemTemplate>
            <tr style="background-color: #f2fbfc; color: #333333;">

                <td>
                    <asp:HyperLink runat="server" ID="AuctionLink" NavigateUrl='<%# Eval("AuctionUrl") %>' meta:resourcekey="AuctionLinkResource1"></asp:HyperLink>
                </td>
                
                <td>
                    <%# Eval("ActualPrice") %>
                </td>
                
                <td>
                    <%# Eval("DateEnd") %>
                </td>

                <td>
                    <%# Eval("DateCreated") %>
                </td>

                <td>
                    <%# Eval("ShortDescription") %>
                </td>

            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server" class="auctionList">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="width: 100%; background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #f2fbfc; color: #333333;">
                                <th runat="server"><asp:Label runat="server" meta:resourcekey="AuctionTitle"/></th>
                                <th runat="server"><asp:Label runat="server" meta:resourcekey="AuctionPrice"/></th>
                                <th runat="server"><asp:Label runat="server" meta:resourcekey="AuctionDateBegin"/></th>
                                <th runat="server"><asp:Label runat="server" meta:resourcekey="AuctionDateEnd"/></th>
                                <th runat="server"><asp:Label runat="server" meta:resourcekey="AuctionDescription"/></th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #f2fbfc; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="25">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" meta:resourcekey="ButtonFirst"/>
                                <asp:NumericPagerField/>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" meta:resourcekey="ButtonLast"/>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    

</asp:Content>