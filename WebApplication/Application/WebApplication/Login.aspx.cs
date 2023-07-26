using System;
using System.Web.UI;
using BusinessLayer;
using BusinessModels;

namespace WebApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LoginUser(object sender, EventArgs e)
        {
            User user = new User();
            user.username = txtuname.Text;
            user.password = txtpasswd.Text;
            BALFactory factory = new BALFactory();
            IBALAuthentication authentication = new BALAuthentication();
            if (authentication.LoginUser(user))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Login Sucessfull')</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
            }
        }

        protected void ForgotPassword_Button(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}