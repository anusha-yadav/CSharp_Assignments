using System;
using BusinessModels;
using BusinessLayer;

namespace WebApplication
{
    /// <summary>
    /// Partial Class for Registration
    /// </summary>
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        /// <summary>
        /// RegisterUser Button Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RegisterUser(object sender, EventArgs e)
        {
            User user = new User();
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;
            user.email = txtEmail.Text;
            user.mobile = txtmobile.Text;
            BALFactory factory = new BALFactory();
            IBALAuthentication authentication = factory.GetBALAuthenticationObj();
            int flag = authentication.RegisterUser(user);
            string message = string.Empty;
            switch (flag)
            {
                case -1:
                    message = Literals.usernameExists;
                    break;
                case -2:
                    message = Literals.emailExists;
                    break;
                default:
                    message = Literals.registrationSuccess + flag.ToString();
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }

        /// <summary>
        /// LoginUser Button Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginUser(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}