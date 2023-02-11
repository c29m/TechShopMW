using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Pages_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetImages();

            //Check if url contains id parameter
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
                lblAddOrEdit.Text = "Edit Product";
            }
            else lblAddOrEdit.Text = "Add Product";
        }
    }

    void FillPage(int id)
    {
        //Get selected product from db
        ProductModel productModel = new ProductModel();
        Product product = productModel.GetProduct(id);

        //Fill the textboxes and dropdown lists
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString();

        //txtDescription.Text = Sidekick.SeparateLongWords(product.Description);
        txtDescription.Text = product.Description;

        ddType.SelectedValue = product.TypeId.ToString();
        ddImage.SelectedValue = product.Image;
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
        product.Price = int.Parse(txtPrice.Text);
        product.TypeId = int.Parse(ddType.SelectedValue);
        product.Image = ddImage.SelectedValue;
        product.Description = Sidekick.SeparateLongWords(txtDescription.Text);
        if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrWhiteSpace(txtDescription.Text)) product.Description = "No description";
        return product;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            ProductModel model = new ProductModel();
            Product p = createProduct();

            //Check if url contains id parameter
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                lblResult.Text = model.InsertProduct(p);
                //lblResult.Text = p.Name;
                reset();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblResult.Text = model.UpdateProduct(id, p);
            }
        }
        //else lblResult.Text = "Invalid data.";
    }

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        reset();
        //Response.Redirect(Request.RawUrl);
    }

    void reset()
    {
        txtName.Text = null;
        txtDescription.Text = null;
        txtPrice.Text = null;
        ddType.SelectedIndex = 0;
        ddImage.SelectedIndex = 0;
    }
}