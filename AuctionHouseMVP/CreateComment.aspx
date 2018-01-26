<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateComment.aspx.cs" Inherits="AHWForm.CreateComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainCreateAuction">
        <div class="upperBar">
            <div class="AuctionCreateTitleDiv">
                <asp:Label runat="server" ID="CommentCreateTitleLabel" Font-Size="X-Large" Font-Bold="True"/>
            </div>
        </div>
        <div class="middle">
            <div class="LeftMiddleBar">
                <asp:RadioButtonList runat="server" ID="CreateCommentRate"/>
                <asp:Label runat="server" ID="DescriptionTextBoxLabel"></asp:Label><br>
                <asp:TextBox runat="server" ID="DescriptionTextBox"></asp:TextBox>
            </div>
        </div>
        <div class="downBar">
            <asp:TextBox runat="server" TextMode="MultiLine" ID="DescriptionLongTextBox"></asp:TextBox><br/>
            <asp:Button runat="server" ID="PassNewAuctionButton" OnClick="PassNewAuctionButton_OnClick"/>

        </div>
    </div>

</asp:Content>