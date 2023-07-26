using System;
using BusinessModels;
using BusinessLayer;

namespace WebApplication
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            User user = new User();
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;
            user.email = txtEmail.Text;
            user.mobile = txtmobile.Text;
            BALFactory factory = new BALFactory();
            IBALAuthentication authentication = new BALAuthentication();
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

        protected void LoginUser(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}