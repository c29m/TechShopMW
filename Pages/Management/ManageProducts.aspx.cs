using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack) GetImages();
    }

    void GetImages()
    {
        try
        {
            //Get all filepaths
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            //Get all filenames and add them to list
            List<string> imageList = new List<string>();
            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }

            //set the imagelist as dropdown list's data source and refresh
            ddImage.DataSource = imageList;
            ddImage.AppendDataBoundItems = true;
            ddImage.DataBind();
        }
        catch(Exception ex)
        {
            lblResult.Text = ex.Message;
        }
    }

    Product createProduct()
    {
        Product product = new Product();
        product.Name = txtName.Text;
        product.Price=int.Parse(txtPrice.Text);
        product.TypeId = int.Parse(ddType.SelectedValue);
        product.Description = txtDescription.Text;
        product.Image = ddImage.SelectedValue;
        return product;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        ProductModel model = new ProductModel();
        Product p = createProduct();
        lblResult.Text = model.InsertProduct(p);
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        txtName.Text = null;
        txtDescription.Text = null;
        txtPrice.Text = null;
        ddType.SelectedIndex = 0;
        ddImage.SelectedIndex = 0;
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}