<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionDetails.aspx.cs" Inherits="AHWForm.AuctionDetails" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Import Namespace="AHWForm.ExtMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="MainContainer">
        <div class="UpperInfo">
            <div class="Title">
                <asp:Label ID="AuctionTitleLabel" runat="server" Font-Size="34pt" meta:resourcekey="AuctionTitleResource1"/>
            </div>
            <div class="PhotoAndRightBar">
                <div class="Photo">
                    <asp:Image runat="server" ID="ThumbnailImg"/>

                </div>
                <div class="BasicInfo">
                    <div class="Price">
                        <asp:Label ID="PriceLabel" runat="server" Font-Size="24pt" meta:resourcekey="PriceLabel"/>
                        <asp:Label ID="AuctionPrice" runat="server" Font-Size="24pt" meta:resourcekey="PriceResource1"/>
                        <asp:Label ID="CurrencyLabel" runat="server" Font-Size="24pt" meta:resourcekey="Currency"/>
                    </div>

                    <div class="Creator">
                        <div class="CreatorName">
                            <asp:Label ID="CreatorNameLabel" runat="server" Font-Size="24pt" meta:resourcekey="UserNameLabel"/>
                            <asp:Label ID="AuctionCreatorName" runat="server" Font-Size="24pt" meta:resourcekey="CreatorNameResource1"/>
                        </div>

                    </div>

                    <div class="Description">
                        <asp:Label ID="AuctionShortDescription" Font-Size="16pt" runat="server" meta:resourcekey="AuctionShortDescriptionResource1"/>
                    </div>

                    <div class="DateCreated">
                        <asp:Label ID="AuctionCreated" runat="server" Font-Size="24pt" meta:resourcekey="AuctionCreated"/>
                        <asp:Label ID="AuctionCreatedLabel" Font-Size="24pt" runat="server"/>
                    </div>

                    <div class="DateExpires">
                        <asp:Label ID="AuctionExpires" runat="server" Font-Size="24pt" meta:resourcekey="AuctionEndsAt"/>
                        <asp:Label ID="AuctionExpiresLabel" Font-Size="24pt" runat="server"/>
                    </div>

                    <div class="BidButtonContainer">
                        <asp:Button ID="Bid" runat="server" CssClass="BidButton" OnClick="Bid_Click" meta:resourcekey="BidResource1"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="MiddleInfo">
            <asp:TextBox runat="server" ID="AuctionLongDescription" CssClass="AuctionText" TextMode="MultiLine" ReadOnly="true"/>
            <asp:DataList runat="server" ID="ImageGallery" RepeatLayout="Table" RepeatColumns="5" CellPadding="2" CellSpacing="20">
                <ItemTemplate>
                    <table class="GalleryItem" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td align="center" class="body">
                                <img class="image" src='<%# ImageHelper.GetUrlForImage(Eval("Id").ToString(), Eval("Extension").ToString(), ver: false) %>' alt=""/>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="LowerInfo">
            <div class="Bidders">
                <asp:ListView runat="server" ID="BidsList" ItemType="AHWForm.Models.AuctionBidViewModel">
                    <ItemTemplate>
                        <tr style="background-color: #FFFBD6; color: #333333;" >
                            <td>
                                <%# Eval("Bidder") %>
                            </td>
                            <td>
                                <%# Eval("Value") %>
                            </td>
                            <td>
                                <%# Eval("DateCreated") %>
                            </td>
                                      

                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color: #FFFBD6; color: #333333;">
                                            <th runat="server">Bidder</th>
                                            <th runat="server">Value</th>
                                            <th runat="server">DataCreated</th>
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
            </div>
        </div>
    </div>


</asp:Content>