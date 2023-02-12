<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Pages_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2>
            <asp:Label ID="lblAddOrEdit" runat="server" Text="label add or edit"></asp:Label>
        </h2>
    <p>
        &nbsp;</p>
    <p>
    Name:</p>
<p>
    <asp:TextBox ID="txtName" runat="server" CssClass="inputs"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*Product name required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
</p>
<p>
    Type:</p>
<p>
    <asp:DropDownList ID="ddType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TechShopDBConnectionString %>" SelectCommand="SELECT Id, Name FROM ProductTypes WHERE (Name &lt;&gt; 'any')"></asp:SqlDataSource>
</p>
<p>
    Price:</p>
<p>
    <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" CssClass="inputs" min="0"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="*Product price required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
</p>
<p>
    Image:</p>
<p>
    <asp:DropDownList ID="ddImage" runat="server">
    </asp:DropDownList>
</p>
<p>
    Description:</p>
<p>
    <asp:TextBox ID="txtDescription" runat="server" Height="113px" TextMode="MultiLine" Width="305px" CssClass="inputs"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="button30" />
    <asp:Button ID="BtnReset" runat="server" OnClick="BtnReset_Click" Text="Reset" CssClass="button30" />
</p>
<p>
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</p>
</asp:Content>

