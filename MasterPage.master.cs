using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var user = Context.User.Identity;

        if (user.IsAuthenticated)
        {
            lnkLogIn.Visible = false;
            lnkRegister.Visible = false;

            litStatus.Visible = true;
            lnkLogOut.Visible = true;

            CartModel model = new CartModel();
            string userId = HttpContext.Current.User.Identity.GetUserId();
            litStatus.Text = $"{Context.User.Identity.Name} ({model.GetAmountOfOrders(userId)})";

            if(user.GetUserId() == "manager")
            {
                litStatus.Text = $"{Context.User.Identity.Name} [@]";
                litStatus.Enabled = false;
                litStatus.Style.Add("cursor: ", "pointer");
                HyperLink4.Enabled = HyperLink4.Visible = true;
            }
            else HyperLink4.Enabled = HyperLink4.Visible = false;
        }
        else
        {
            lnkLogIn.Visible = true;
            lnkRegister.Visible = true;

            litStatus.Visible = false;
            lnkLogOut.Visible = false;

            HyperLink4.Enabled = HyperLink4.Visible = false;
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();
        Response.Redirect("~/Index.aspx");
    }
}
