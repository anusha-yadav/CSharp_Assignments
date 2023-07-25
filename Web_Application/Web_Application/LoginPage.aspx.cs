using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_Application
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btton_Login(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=COGNINE-L13;Initial Catalog=Anusha;Integrated Security=True");
            string username = txtuname.Text;
            string passwd = txtpasswd.Text;
            conn.Open();
            string query = "select * from Details where Username = '"+username+"' and Password = '"+passwd+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Label3.Text = "Login Successfull!!!";
                Label3.ForeColor = System.Drawing.Color.DarkGreen;
                Label3.Font.Bold = true;
            }
            else
            {
                Label3.Text = "Incorrect credentials";
                Label3.ForeColor = System.Drawing.Color.DarkRed;
                Label3.Font.Bold= true;
            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}