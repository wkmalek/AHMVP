<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionListPage.aspx.cs" Inherits="AHWForm.AuctionListPage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="AuctionListSearchFilters">
        <asp:Label runat="server" ID="FilterByPriceLabel" Text="ByPrice"/>
        <asp:LinkButton runat="server" Text="&#8595;" ID="FilterByPriceAscending" OnClick="FilterByPriceAscending_OnClick"/>
        <asp:LinkButton runat="server" Text="&#8593;" ID="FilterByPriceDescending" OnClick="FilterByPriceDescending_OnClick"/>

        <asp:Label runat="server" ID="FilterByDateLabel" Text="ByDate"/>
        <asp:LinkButton runat="server" Text="&#8595;" ID="FilterByDateAscending" OnClick="FilterByDateAscending_OnClick"/>
        <asp:LinkButton runat="server" Text="&#8593;" ID="FilterByDateDescending" OnClick="FilterByDateDescending_OnClick"/>

        <asp:Label runat="server" ID="FilterByDescriptionLabel" Text="ByDescription"/>
        <asp:LinkButton runat="server" Text="&#8595;" ID="FilterByDescriptionAscending" OnClick="FilterByDescriptionAscending_OnClick"/>
        <asp:LinkButton runat="server" Text="&#8593;" ID="FilterByDescriptionDescending" OnClick="FilterByDescriptionDescending_OnClick"/>
        
        <asp:Label runat="server" ID="WithEndedAuctionsLabel" Text="With ended auctions"></asp:Label>
        <asp:CheckBox runat="server" ID="WithEndedAuctions" Checked="False" OnCheckedChanged="WithEndedAuctions_OnCheckedChanged" AutoPostBack="true"/>
    </div>

    <asp:ListView ID="AuctionList" runat="server" ItemType="AHWForm.Models.AuctionListSingleElemVM" OnSorting="AuctionList_OnSorting">

        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>

        <ItemTemplate>
            <tr style="background-color: #f2fbfc; color: #333333;">

                <td>
                    <asp:HyperLink runat="server" ID="AuctionLink" NavigateUrl='<%# Eval("AuctionUrl") %>'>
                        <%# Eval("AuctionTitle") %>
                    </asp:HyperLink>
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
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #f2fbfc; color: #333333;">
                                <th runat="server">Title</th>
                                <th runat="server">ActualPrice</th>
                                <th runat="server">DateEnd</th>
                                <th runat="server">DateCreated</th>
                                <th runat="server">Description</th>
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