using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountMapping
{
    public partial class LineNotifyCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得返回的code
            var code = Request.QueryString["code"];
            if (code == null)
            {
                Response.Write("沒有正確回應code");
                Response.End();
            }
            //顯示，測試用
            Response.Write("<br/> code : " + code);
            //從Code取回toke
            var token = isRock.LineNotify.Utility.GetTokenFromCode(code,
                "",  //TODO:請更正為你自己的 client_id
                "", //TODO:請更正為你自己的 client_secret
                "http://localhost:8752/LineNotifyCallback.aspx"); //TODO:請更正為正確的call back Url
            //顯示，測試用
            TextBoxToken.Text = token.access_token;
            //利用token發各測試訊息
            isRock.LineNotify.Utility.SendNotify(token.access_token, "msg test - " + System.DateTime.Now.ToString());

            //把Token存入DB
            Utility.UpdateNotifyToken(Session["UserName"].ToString(), token.access_token);
        }
    }
}