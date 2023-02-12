using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage(17);
    }

    void FillPage(int n)
    {
        //Get all products from db
        ProductModel productModel = new ProductModel();
        List<Product> products = productModel.GetAllProducts();
        products = Sidekick.ShuffleList(products);

        //Make sure product exists
        if (products != null)
        {
            //Create a new panel with an ImageButton and 2 Labels for each product
            int i = 0;
            foreach(Product product in products)
            {
                Panel productPanel= new Panel();
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
                pnlProducts.Controls.Add(productPanel);

                i++;
                if (i == n) break;
            }
        }
        else
        {
            //No products found
            pnlProducts.Controls.Add(new Literal { Text = "No products found." });
        }
    }
}