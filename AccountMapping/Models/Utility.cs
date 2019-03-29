using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountMapping
{
    public  class Utility
    {
        public static Models.MainDBDataContext GetDbContext()
        {
            Models.MainDBDataContext db = new Models.MainDBDataContext();
            return db;
        }

        public static bool CheckAccountPwd(string account, string pwd)
        {
            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == account.ToLower() && c.Pwd == pwd
                      select c;

            if (ret.Count() == 1)
                return true;
            return false;
        }

        public static void SendLineNotify(string UserName, string text)
        {
            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == UserName.ToLower()
                      select c;

            if (ret.Count() == 1)
            {
                if (string.IsNullOrEmpty(ret.FirstOrDefault().LineNotifyToken.Trim()))
                    throw new Exception($"用戶'{UserName}'沒有Token....");
                else
                {
                    isRock.LineNotify.Utility.SendNotify(
                        ret.FirstOrDefault().LineNotifyToken, text);
                }
            }
            else
                throw new Exception($"找不到用戶'{UserName}'....");
        }

        public static Models.User GetUserInfo(string UserName)
        {
            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == UserName.ToLower()
                      select c;

            if (ret.Count() == 1)
                return ret.FirstOrDefault();
            else
                throw new Exception($"找不到用戶'{UserName}'....");
        }

        public static void SendPushMessage(string UserName, string text)
        {
            var ChannelAccessToken = System.Configuration.ConfigurationManager.AppSettings["ChannelAccessToken"].ToString();

            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == UserName.ToLower()
                      select c;

            if (ret.Count() == 1)
            {
                if (string.IsNullOrEmpty(ret.FirstOrDefault().LineLoginUserID.Trim()))
                    throw new Exception($"用戶'{UserName}'沒有Login User ID....");
                else
                {
                    isRock.LineBot.Utility.PushMessage(
                        ret.FirstOrDefault().LineLoginUserID, text, ChannelAccessToken);
                }
            }
            else
                throw new Exception($"找不到用戶'{UserName}'....");
        }

        public static void UpdateLoginToken(string UserName, string UserID)
        {
            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == UserName.ToLower()
                      select c;

            if (ret.Count() == 1)
            {
                ret.FirstOrDefault().LineLoginUserID = UserID;
                db.SubmitChanges();
            }
            else
                throw new Exception($"找不到用戶'{UserName}'....");
        }

        public static void UpdateMemo(string UserName, string Memo)
        {
            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == UserName.ToLower()
                      select c;

            if (ret.Count() == 1)
            {
                ret.FirstOrDefault().Memo = Memo;
                db.SubmitChanges();
            }
            else
                throw new Exception($"找不到用戶'{UserName}'....");
        }
        public static void UpdateNotifyToken(string UserName, string access_token)
        {
            var db = GetDbContext();
            var ret = from c in db.User
                      where c.UserName.ToLower() == UserName.ToLower()
                      select c;

            if (ret.Count() == 1)
            {
                ret.FirstOrDefault().LineNotifyToken = access_token;
                db.SubmitChanges();
            }
            else
                throw new Exception($"找不到用戶'{UserName}'....");
        }
    }
}