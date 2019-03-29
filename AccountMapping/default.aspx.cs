using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountMapping
{
    public partial class _default : System.Web.UI.Page
    {
        public static Models.User CurrentUser = new Models.User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null && !string.IsNullOrEmpty(Session["UserName"].ToString()))
                CurrentUser = Utility.GetUserInfo(Session["UserName"].ToString());
        }

        protected void ButtonSendMsgWithNotify_Click(object sender, EventArgs e)
        {
            Utility.SendLineNotify(Session["UserName"].ToString(), this.TextBoxMsg.Text);
        }

        protected void ButtonBind_Click(object sender, EventArgs e)
        {
            var db = Utility.GetDbContext();

            while (true)
            {
                //建立隨機亂數
                int n = new Random(DateTime.Now.Second).Next(111111, 999999);
                //檢查資料庫中是否有此數字
                var ret = from c in db.User
                          where c.Memo == n.ToString()
                          select c;
                if (ret.Count() <= 0)
                {
                    //將此數值配置給當前用戶
                    Utility.UpdateMemo(Session["UserName"].ToString(), n.ToString());
                    Response.Write($"請加入Line Bot為好友，並且輸入  {n}");
                    break;
                } 
            }
        }
    }
}