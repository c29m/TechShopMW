<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Pages_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="inputs" Width="70%" placeholder="Search.."></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" CssClass="button30" OnClick="btnSearch_Click" Text="Search" />
<asp:DropDownList ID="ddlSearchType" runat="server" AutoPostBack="True" CssClass="inputs" DataSourceID="searchTech" DataTextField="Name" DataValueField="Id">
</asp:DropDownList>
<asp:SqlDataSource ID="searchTech" runat="server" ConnectionString="<%$ ConnectionStrings:TechShopDBConnectionString %>" SelectCommand="SELECT * FROM [ProductTypes]"></asp:SqlDataSource>
<asp:Panel ID="pnlSearchProducts" runat="server">
</asp:Panel>
    <br />
    <div style="clear: both">
        <br /><br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </div>
</asp:Content>

