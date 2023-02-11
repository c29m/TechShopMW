<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 107px;
        }
        .Meh {
            display: table;
            width: 100%;
            float: right;
            position: relative;
            overflow: hidden;
            display: table-row;
            height: 100%;
            background-color: #f5f5f5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td rowspan="4" class="auto-style1">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" />
            </td>
            <td>
                <h2>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                <hr />
            </td>
        </tr>

        <tr>
            <td >
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription" ></asp:Label>
            </td>
        </tr>

        <tr>
            <td >
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label><br />
                <asp:Label ID="lblQuantity" runat="server" >Quantity:</asp:Label><br /><asp:DropDownList ID="ddlAmount" runat="server" CssClass="inputs"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" CssClass="button30" OnClick="btnAdd_Click" Text="Add Product" />
                <br />
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Product ID:
                <br />
                <asp:Label ID="lblItemNumber" runat="server" Style="font-style: italic"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblAvailable" runat="server" CssClass="productPrice">Available!</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

