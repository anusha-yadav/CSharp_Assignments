using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_Passwd(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=COGNINE-L13;Initial Catalog=Anusha;Integrated Security=True");
            conn.Open();
            int flag = 0;
            string username = txtuname.Text;
            string newpasswd = txtnewpasswd.Text;
            string confirm_passwd = txtconfirmpasswd.Text;
            SqlCommand cmd = new SqlCommand("select Password from Details where Username='"+username+"'",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (newpasswd == confirm_passwd)
                {
                    flag = 1;                    
                }
            }
            reader.Close();
            conn.Close();
            if( flag == 1 ) 
            {
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Details SET Password = '"+newpasswd+"' WHERE Username = '"+username+"'",conn);
                command.ExecuteNonQuery();
                Label4.Text = "Password updated sucessfully!!";
                Label4.ForeColor = System.Drawing.Color.Red;
                conn.Close();
            }
        }

        protected void LinkButton2(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}