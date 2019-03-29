using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountMapping.Controllers
{
    public class BotController : isRock.LineBot.LineWebHookControllerBase
    {
        //TODO: 換成你自己的channelAccessToken
        const string channelAccessToken = "";
        //TODO: 換成你自己的Admin User Id
        const string AdminUserId = "!!!換成你自己的Admin User Id!!!";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text") //收到文字
                    {
                        //判斷是否為綁定代碼
                        var db = Utility.GetDbContext();
                        var ret = from c in db.User
                                  where c.Memo == LineEvent.message.text
                                  select c;
                        if (ret.Count() == 1)
                        {
                            ret.FirstOrDefault().LineUserID = LineEvent.source.userId;
                            ret.FirstOrDefault().Memo = "";
                            this.ReplyMessage(LineEvent.replyToken, $"您已經將用戶 {LineEvent.source.userId} 綁定於 {ret.FirstOrDefault().UserName}");
                                db.SubmitChanges();
                        }
                        else
                            this.ReplyMessage(LineEvent.replyToken, $"您說了: {LineEvent.message.text}");
                    }
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                //如果收到postback
                if (LineEvent.type == "postback")
                {
                    var msg = $"data : {LineEvent.postback.data}";
                    msg += $"\n Params.date : {LineEvent.postback.Params.date + ""}";
                    msg += $"\n Params.datetime : {LineEvent.postback.Params.datetime + ""}";
                    msg += $"\n Params.time : {LineEvent.postback.Params.time + ""}";
                    this.ReplyMessage(LineEvent.replyToken, msg);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
