using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString = 
            System.Configuration.ConfigurationManager.ConnectionStrings["TechShopDBConnectionString"].ConnectionString;

        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        if (txtUserName.Text == "manager")
        {
            lblStatus.Text = "This user name cannot be used.";
            return;
        }

        //Create new user and store in db
        IdentityUser user = new IdentityUser();
        user.UserName = txtUserName.Text;

        if(txtPassword.Text.Length < 6) lblStatus.Text = "*Password must be atleast 6 characters long.";
        else if (txtPassword.Text==txtConfirmPassword.Text)
        {
            try
            {
                //Create user object.
                //Database will be created / expanded automatically.
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    UserInformation info = new UserInformation
                    {
                        Address = txtAddress.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        PostalCode = Convert.ToInt32(txtPostalCode.Text),
                        GUID = user.Id
                    };

                    UserInfoModel model = new UserInfoModel();
                    model.InsertUserInformation(info);

                    //Store in db.
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                    //Set to log in new user by Cookie.
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //Log in the new user and redirect to homepage
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    Response.Redirect("~/Index.aspx");
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
        else
        {
            lblStatus.Text = "*Passwords must match";
        }
    }
}