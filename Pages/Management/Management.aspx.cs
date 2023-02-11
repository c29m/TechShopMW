using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Get selected row
        GridViewRow row = grdProducts.Rows[e.NewEditIndex];

        //Get id of row
        int rowId = Convert.ToInt32(row.Cells[1].Text);

        //Redirect users to ManageProducts page with the selected rowId
        Response.Redirect($"~/Pages/Management/ManageProducts.aspx?id={rowId}");
    }
}