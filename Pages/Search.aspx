<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Pages_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="inputs" Width="70%" placeholder="Search.."></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" CssClass="button30" OnClick="btnSearch_Click" Text="Search" />
<asp:DropDownList ID="ddlSearchType" runat="server" AutoPostBack="True" CssClass="inputs" DataSourceID="searchTech" DataTextField="Name" DataValueField="Id" style="float: right;" Font-Bold="True">
</asp:DropDownList>
    <div style="float:right;">
        <asp:CheckBox ID="chkPriceRng" runat="server" />
        <asp:Label ID="lblPrice" runat="server" Text="Price:" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtPriceRngMin" runat="server" TextMode="Number" min="0" max="600000" placeholder="min" ></asp:TextBox>
        <asp:TextBox ID="txtPriceRngMax" runat="server" TextMode="Number" min="0" max="600000" placeholder="max" ></asp:TextBox>
        <br />
        <asp:Label ID="lblPriceRngStatus" runat="server"></asp:Label>
        <br />
        <asp:CheckBox ID="chkPriceSort" runat="server" />
        <asp:Label ID="lblPriceSort" runat="server" Text="Sort by Price" Font-Bold="True"></asp:Label>
        <br /><br />
        <asp:Button ID="btnReset" runat="server" Text="Reset All" OnClick="btnReset_Click"  CssClass="button31" />
        <br />
    </div>
    <br /><br /><br />
    <br /><br /><br />
    <br /><br /><br />
<asp:SqlDataSource ID="searchTech" runat="server" ConnectionString="<%$ ConnectionStrings:TechShopDBConnectionString %>" SelectCommand="SELECT * FROM [ProductTypes]"></asp:SqlDataSource>

<asp:Panel ID="pnlSearchProducts" runat="server">
</asp:Panel>
    <br />
    <div style="clear: both">
        <br /><br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </div>
</asp:Content>

