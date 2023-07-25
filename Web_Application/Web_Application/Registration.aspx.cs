using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=COGNINE-L13;Initial Catalog=Anusha;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Details" + "(Name,Mobile,Username,Password) values(@Name,@Mobile,@Username,@Password)",conn);
            cmd.Parameters.AddWithValue("@Name",txtName.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.ExecuteNonQuery();
            Response.Redirect("LoginPage.aspx");
        }

        protected void btn_Login(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}