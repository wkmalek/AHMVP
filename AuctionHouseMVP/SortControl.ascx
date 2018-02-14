<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SortControl.ascx.cs" Inherits="AHWForm.SortControl"  %>
<div id="AuctionListSearchFilters">
    <asp:Label runat="server" ID="FilterByPriceLabel" meta:resourcekey="FilterByPriceLabelResource1"/>
    <asp:LinkButton runat="server" Text="&#8595;" ID="FilterByPriceAscending" OnClick="FilterByPriceAscending_OnClick" />
    <asp:LinkButton runat="server" Text="&#8593;" ID="FilterByPriceDescending" OnClick="FilterByPriceDescending_OnClick" />

    <asp:Label runat="server" ID="FilterByDateLabel" meta:resourcekey="FilterByDateLabelResource1"/>
    <asp:LinkButton runat="server" Text="&#8595;" ID="FilterByDateAscending" OnClick="FilterByDateAscending_OnClick"/>
    <asp:LinkButton runat="server" Text="&#8593;" ID="FilterByDateDescending" OnClick="FilterByDateDescending_OnClick" />

    <asp:Label runat="server" ID="FilterByDescriptionLabel" meta:resourcekey="FilterByDescriptionLabelResource1"/>
    <asp:LinkButton runat="server" Text="&#8595;" ID="FilterByDescriptionAscending" OnClick="FilterByDescriptionAscending_OnClick" />
    <asp:LinkButton runat="server" Text="&#8593;" ID="FilterByDescriptionDescending" OnClick="FilterByDescriptionDescending_OnClick" />
        
    <asp:Label runat="server" ID="WithEndedAuctionsLabel" meta:resourcekey="WithEndedAuctionsLabelResource1" />
    <asp:CheckBox runat="server" ID="WithEndedAuctions" OnCheckedChanged="WithEndedAuctions_OnCheckedChanged" AutoPostBack="True" />
</div>