<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
<br />
<br />
<asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
    :<br />
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
<asp:Button ID="btnLogin" runat="server" CssClass="button30" Text="Log In" OnClick="btnRegister_Click" />
<br />
</asp:Content>

