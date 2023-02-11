using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            litStatus.Text = Context.User.Identity.Name;
        }
        else
        {
            lnkLogIn.Visible = true;
            lnkRegister.Visible = true;

            litStatus.Visible = false;
            lnkLogOut.Visible = false;
        }
    }

    protected void lnkLogOut_Click(object sender, EventArgs e)
    {
        IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        authenticationManager.SignOut();
        Response.Redirect("~/Index.aspx");
    }
}
