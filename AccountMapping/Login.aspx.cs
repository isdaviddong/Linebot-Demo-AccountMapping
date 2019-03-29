using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountMapping
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //登出
            Session["UserName"] = ""; 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Utility.CheckAccountPwd(TextBox_Account.Text.Trim(), TextBox_Pwd.Text))
            {
                Session["UserName"] = TextBox_Account.Text.Trim();
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("登入失敗!");
            }
        }
    }
}