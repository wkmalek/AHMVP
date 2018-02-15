<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bid.aspx.cs" Inherits="AHWForm.Bid" meta:resourcekey="PageResource1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <tr>
        <td>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="priceTextBox" ErrorMessage="FieldNeeded" meta:resourcekey="RequiredFieldValidatorResource1"/>
            <asp:CustomValidator runat="server" ID="CustomValidatorPrice"  ControlToValidate="priceTextBox" OnServerValidate="CustomValidatorPrice_OnServerValidate" ErrorMessage="Price to low" meta:resourcekey="CustomValidatorPriceResource1"/>
        </td>
    </tr>
    
    <asp:Label runat="server" ID="priceLabel" meta:resourcekey="priceLabelResource1" /> 
    <asp:Button ID="BidSecond" runat="server" Text="Button" OnClick="BidSecond_Click" meta:resourcekey="BidSecondResource1"/> <asp:RegularExpressionValidator runat="server" ControlToValidate="priceTextBox" ErrorMessage="Only numbers" ValidationExpression="^[0-9]+$" meta:resourcekey="RegularExpressionValidatorResource1"/>
    <asp:TextBox ID="priceTextBox" runat="server" meta:resourcekey="priceTextBoxResource1"></asp:TextBox>


</asp:Content>