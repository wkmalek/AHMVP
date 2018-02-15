<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateComment.aspx.cs" Inherits="AHWForm.CreateComment" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainCreateAuction">
        <div class="upperBar">
            <div class="AuctionCreateTitleDiv">
                <asp:Label runat="server" ID="CommentCreateTitleLabel" Font-Size="X-Large" Font-Bold="True" meta:resourcekey="CommentCreateTitleLabelResource1"/>
            </div>
        </div>
        <div class="middle">
            <div class="LeftMiddleBar">
                <asp:RadioButtonList runat="server" ID="CreateCommentRate" meta:resourcekey="CreateCommentRateResource1"/>
                <asp:Label runat="server" ID="DescriptionTextBoxLabel" meta:resourcekey="DescriptionTextBoxLabelResource1"></asp:Label><br>
                <asp:TextBox runat="server" ID="DescriptionTextBox" meta:resourcekey="DescriptionTextBoxResource1"></asp:TextBox>
            </div>
        </div>
        <div class="downBar">
            <asp:TextBox runat="server" TextMode="MultiLine" ID="DescriptionLongTextBox" meta:resourcekey="DescriptionLongTextBoxResource1"></asp:TextBox><br/>
            <asp:Button runat="server" ID="PassNewAuctionButton" OnClick="PassNewAuctionButton_OnClick" meta:resourcekey="PassNewAuctionButtonResource1"/>

        </div>
    </div>

</asp:Content>