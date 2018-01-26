<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bid.aspx.cs" Inherits="AHWForm.Bid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <tr>
        <td>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="priceTextBox" ErrorMessage="FieldNeeded"/>
            <asp:CompareValidator runat="server" ID="CompareValidatorPrice" />
        </td>
    </tr>
    
    <asp:Label runat="server" ID="priceLabel" /> 
    <asp:Button ID="BidSecond" runat="server" Text="Button" OnClick="BidSecond_Click"/> <asp:RegularExpressionValidator runat="server" ControlToValidate="priceTextBox" ErrorMessage="Only numbers" ValidationExpression="[0-9]"/>
    <asp:TextBox ID="priceTextBox" runat="server"></asp:TextBox>


</asp:Content>