using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        lblPriceRngStatus.Text = "";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //var productType = ddlSearchType.SelectedValue;
        //var productType = ddlSearchType.SelectedItem.Value;
        //var productType = ddlSearchType.SelectedItem.Text;
        //Sidekick.Alert(productType, this);
        FillPage();
    }

    void FillPage()
    {
        //Get all products from db
        ProductModel productModel = new ProductModel();
        int productType = Convert.ToInt32(ddlSearchType.SelectedItem.Value);
        int mn, mx;
        List<Product> products;

        try
        {
            mn = Convert.ToInt32(txtPriceRngMin.Text);
            mx = Convert.ToInt32(txtPriceRngMax.Text);
        }
        catch
        {
            mn = 0;
            mx = 600000;
            txtPriceRngMin.Text = $"{mn}";
            txtPriceRngMax.Text = $"{mx}";
        }

        if (chkPriceRng.Checked && mx < mn)
        {
            lblPriceRngStatus.Text = $"*Min must be greater than Max";
            return;
        }

        if (string.IsNullOrEmpty(txtSearch.Text) || string.IsNullOrWhiteSpace(txtSearch.Text))//No Name
        {
            if (productType == 1)//No Type
            {
                if(chkPriceRng.Checked)//Price
                {
                    products = productModel.GetProductsByPrice(mn, mx);
                }
                else//No Price
                {
                    products = productModel.GetAllProducts();
                    products = Sidekick.ShuffleList(products);
                }
            }
            else//Type
            {
                if (chkPriceRng.Checked)//Price
                {
                    products = productModel.GetProductsByTypeAndPrice(productType, mn, mx);
                }
                else//No Price
                {
                    products = productModel.GetProductsByType(productType);
                }
            }
        }
        else//Name
        {
            if (productType == 1)//No Type
            {
                if (chkPriceRng.Checked)//Price
                {
                    products = productModel.GetProductsByNameAndPrice(txtSearch.Text, mn, mx);
                }
                else//No Price
                {
                    products = productModel.GetProductsByName(txtSearch.Text);
                }
            }
            else//Type
            {
                if (chkPriceRng.Checked)//Price
                {
                    products = productModel.GetProductsByTypeAndPrice(productType, mn, mx);
                }
                else//No Price
                {
                    products = productModel.GetProductsByNameAndType(txtSearch.Text, productType);
                }
            }
        }

        int i = 0;
        //Make sure product exists
        if (products != null)
        {
            if (chkPriceSort.Checked) products = Sidekick.SortProductList(products);
            
            //Create a new panel with an ImageButton and 2 Labels for each product
            foreach (Product product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //Set childControls's properties
                imageButton.ImageUrl = $"~/Images/Products/{product.Image}";
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = $"~/Pages/Product.aspx?id={product.Id}";

                lblName.Text = product.Name;
                lblName.CssClass = "productName";

                lblPrice.Text = $"TK {product.Price}";
                lblPrice.CssClass = "productPrice";

                //Add child controls to panel
                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblPrice);

                //Add dynamic productPanel to static parent panel
                pnlSearchProducts.Controls.Add(productPanel);
                i++;
            }
        }
        lblStatus.Text = $"{i} results found.";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        ddlSearchType.SelectedIndex = 0;
        chkPriceRng.Checked = false;
        txtPriceRngMin.Text = "";
        txtPriceRngMax.Text = "";
        lblPriceRngStatus.Text = "";
        chkPriceSort.Checked = false;
    }
}