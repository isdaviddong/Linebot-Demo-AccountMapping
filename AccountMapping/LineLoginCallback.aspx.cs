using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountMapping
{
    public partial class LineLoginCallback : System.Web.UI.Page
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
            var token =isRock.LineLoginV21.Utility.GetTokenFromCode(code,
                "",  //TODO:請更正為你自己的 client_id
                "", //TODO:請更正為你自己的 client_secret
                "http://localhost:8752/LineLoginCallback.aspx"); //TODO:請更正為正確的call back Url
            //顯示，測試用
            Response.Write("<br/> token : " + token.access_token);
            //利用token取得用戶資料
            var user =isRock.LineLoginV21.Utility.GetUserProfile(token.access_token);

            //把Token存入DB
            Utility.UpdateLoginToken(Session["UserName"].ToString(), user.userId);

            //顯示，測試用
            Response.Write("<br/> user : " + Newtonsoft.Json.JsonConvert.SerializeObject(user));

        }
    }
}