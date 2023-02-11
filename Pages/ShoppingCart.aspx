<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Pages_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlEmptyCart" runat="server" Enabled="False" Visible="False">
        <asp:Label ID="lblEmptyCart" runat="server" Text="Your cart is empty."></asp:Label>
        <asp:LinkButton ID="lnkGotoShop" runat="server" PostBackUrl="~/Index.aspx">Go to Shop</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="pnlShoppingCart" runat="server">
        <table>
            <tr>
                <td>
                    <b>Total: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
                </td>
            </tr>

            <tr>
                <td>
                    <b>Vat: </b>
                </td>
                <td>
                    <asp:Literal ID="litVat" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Delivery: </b>
                </td>
                <td>
                    TK 1500
                </td>
            </tr>

            <tr>
                <td>
                    <b>Total Amount: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotalAmount" runat="server" Text="" />
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:LinkButton ID="lnkContinue" runat="server" PostBackUrl="~/Index.aspx">Continue Shopping</asp:LinkButton> &nbsp;&nbsp; <b>OR</b>
                    <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="button30" Width="250px" PostBackUrl="~/Pages/Success.aspx" />

                    <br />
                    <br />
                    <br />

                    <asp:LinkButton ID="litPaypal" Text="" runat="server" />
                </td>
            </tr>

        </table>
    </asp:Panel>
</asp:Content>

