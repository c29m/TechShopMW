<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
<br />
<br />
<asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
    <br />
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
    <br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputs" ></asp:TextBox>
    <br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
    <br />
    <asp:TextBox ID="txtLastName" runat="server" CssClass="inputs" ></asp:TextBox>
    <br />
    <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs" ></asp:TextBox>
    <br />
    <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code:"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorPostalCode" runat="server" ControlToValidate="txtPostalCode" ErrorMessage="*" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs" TextMode="Number" ></asp:TextBox>
    <br />
<asp:Button ID="btnRegister" runat="server" CssClass="button30" Text="Register" OnClick="btnRegister_Click" />
</asp:Content>

