using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    void FillPage()
    {
        //Get selected product data
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductModel model = new ProductModel();
            Product product = model.GetProduct(id);

            //Fill page with data
            lblTitle.Text = product.Name;
            lblDescription.Text = product.Description;
            lblPrice.Text = $"Price per unit:<br/>TK {product.Price}";
            imgProduct.ImageUrl = $"~/Images/Products/{product.Image}";
            lblItemNumber.Text = product.Id.ToString();

            //Fill amount list with numbers 1-100
            int[] amount = Enumerable.Range(1, 100).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();

            //If manager logs in then hide and disable add button and dropdown list.
            string clientId = Context.User.Identity.GetUserId();
            if (clientId=="manager")
            {
                btnAdd.Visible = btnAdd.Enabled = false;
                ddlAmount.Visible = ddlAmount.Enabled = false;
                lblQuantity.Visible = false;
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            string clientId = Context.User.Identity.GetUserId();

            if (clientId == "manager")
            {
                lblResult.Text = "Manager Cannot Buy Items From Manager Account.";
                return;
            }

            if(clientId!=null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                Cart cart = new Cart
                {
                    Amount = amount,
                    ClientId = clientId,
                    DatePurchased = DateTime.Now,
                    IsInCart = true,
                    ProductId = id
                };

                //If same product already is in cart for same client then just update its amount. Else insert it in cart
                CartModel cartModel = new CartModel();
                var c = cartModel.FindItemInClientCart(id, clientId);
                if (c != null)
                {
                    cart.Amount += c.Amount;
                    lblResult.Text = cartModel.UpdateCart(c.Id, cart);
                }
                else lblResult.Text = cartModel.InsertCart(cart);
            }
            else
            {
                lblResult.Text = "Please log in to order items.";
            }
        }
        ddlAmount.SelectedIndex = 0;
    }
}