﻿using System;
using BusinessLayer;
using BusinessModels;

namespace WebApplication
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ForgotPassword_Button(object sender, EventArgs e)
        {
            User user = new User();
            if (txtnewpasswd.Text == txtconfirmpasswd.Text)
            {
                user.username = txtuname.Text;
                user.new_passwd = txtnewpasswd.Text;
                user.confirm_passwd = txtconfirmpasswd.Text;
                BALFactory factory = new BALFactory();
                IBALAuthentication authentication = new BALAuthentication();
                int flag = authentication.ForgotPassword(user);
                if (flag != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "validation", "<script language='javascript'>alert('Password Updated Sucessfully!!')</script>");
                }
            }
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}