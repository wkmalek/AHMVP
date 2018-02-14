<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="AHWForm.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr/>
                <dl class="dl-horizontal">
                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server"/>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server"/>
                    </dd>
                    <dt>External Logins:</dt>
                    <dd>
                        <%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server"/>
                    </dd>

                    <dt>MainCurrency:</dt>
                    <dd>
                        <asp:DropDownList runat="server" ID="CurrencyDropDown" OnSelectedIndexChanged="CurrencyDropDown_OnSelectedIndexChanged" AutoPostBack="true"/>
                    </dd>
                    <dt>Language:</dt>
                    <dd>
                        <asp:DropDownList runat="server" ID="LanguageDropDown" OnSelectedIndexChanged="LanguageDropDown_OnSelectedIndexChanged" AutoPostBack="true"/>
                    </dd>
                    <dt>PublicApiKey</dt>
                    <dd>
                        <asp:Label runat="server" ID="PublicApiKey"/>
                    </dd>
                    <dt>PrivateApiKey</dt>
                    <dd>
                        <asp:Label runat="server" ID="PrivateApiKey"/>
                    </dd>

                </dl>
            </div>
        </div>
    </div>

</asp:Content>