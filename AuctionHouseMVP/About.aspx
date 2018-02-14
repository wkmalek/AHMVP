<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AHWForm.About" meta:resourcekey="PageResource1" culture="auto" uiculture="auto"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3><asp:Label runat="server" meta:resourcekey="LabelResource1" /></h3>
    <p><asp:Label runat="server" meta:resourcekey="LabelResource2" /></p>
</asp:Content>