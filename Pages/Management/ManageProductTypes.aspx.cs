using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ManageProductTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtName.Text = "";
        //lblResult.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductTypeTypeModel model = new ProductTypeTypeModel();
        ProductType pt = createProductType();
        pt.Name = txtName.Text;
        //lblResult.Text = model.InsertProductType(pt);
        lblResult.Text = txtName.Text;
        //Sidekick.Alert(txtName.Text, this);
        txtName.Text = "";
    }

    ProductType createProductType()
    {
        ProductType p = new ProductType();
        p.Name = txtName.Text;
        return p;
    }
}