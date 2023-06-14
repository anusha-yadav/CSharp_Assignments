using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using BuisnessLogic;

namespace Three_Tier_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserBL ba = new UserBL();
        UserDA da = new UserDA();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            da.username = txtuname.Text;
            da.password = txtpassword.Text;
            dt = ba.loginuser(da);
            if(dt.Rows.Count > 0)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                Response.Write("<script>alert('invalid username and password')</script>");
            }
        }
    }
}