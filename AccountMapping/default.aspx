<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AccountMapping._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous" />
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap-theme.min.css" integrity="sha384-6pzBo3FDv/PJ8r2KRkGHifhEocL+1X2rVCTTkUfGk7/0pbek5mMa1upzvWbrUbOZ" crossorigin="anonymous" />
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" integrity="sha384-aJ21OjlMXNL5UyIl/XNwTMqvzeRMZH2w8c5cRVpzpU8Y5bApTppSuUkhZXN0VxHd" crossorigin="anonymous"></script>
    <title>LINE vs 企業用戶帳號 Mapping</title>
    <script>
        //建立LINE Login OAuth 身分驗證頁面並導入
        function LoginAuth() {
            var URL = 'https://access.line.me/oauth2/v2.1/authorize?';
            URL += 'response_type=code';
            URL += '&client_id=';   //TODO:這邊要換成你的client_id
            URL += '&redirect_uri=http://localhost:8752/LineLoginCallback.aspx';   //TODO:要將此redirect url 填回你的 LineLogin後台設定
            URL += '&scope=openid%20profile';
            URL += '&state=abcde';
            window.location.href = URL;
        }

        //建立LINE Notify OAuth 身分驗證頁面並導入
        function NotifyAuth() {
            var URL = 'https://notify-bot.line.me/oauth/authorize?';
            URL += 'response_type=code';
            URL += '&client_id=';   //TODO:這邊要換成你的client_id
            URL += '&redirect_uri=http://localhost:8752/LineNotifyCallback.aspx';   //TODO:要將此redirect url 填回你的 LineNotify後台設定
            URL += '&scope=notify';
            URL += '&state=abcde';
            window.location.href = URL;
        }

        $(function () {
            $('#ButtonLinkLineNotify').click(function (e) {
                NotifyAuth();
            });
        });
        $(function () {
            $('#ButtonLinkLineLogin').click(function (e) {
                LoginAuth();
            });
        });

        $(function () {
            $('#ButtonLogin').click(function (e) {
                window.location.href = 'Login.aspx';
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="margin: 10px">
            <div class="col-md-6">
                <label>當前用戶名稱: <%=CurrentUser.UserName  %></label>
                <br />
                      <label>Bot User ID: <%=CurrentUser.LineUserID  %></label>
                <br />
                      <label>LINE Login User ID: <%=CurrentUser.LineLoginUserID %></label>
                <br />
                      <label>LINE Notify Token : <%=CurrentUser.LineNotifyToken %></label>
                <br />
                <input id="ButtonLogin" type="button" class="btn btn-success" value="登入/登出" />
                <br />
                <br />
                <asp:Button ID="ButtonBind"  OnClick="ButtonBind_Click" CssClass="btn btn-success" runat="server" Text="綁定當前用戶的LINE" /> 
                <input id="ButtonLinkLineNotify" type="button" class="btn btn-success" value="取得當前用戶 LINE Notify Token" />
                <input id="ButtonLinkLineLogin" type="button" class="btn btn-success" value="綁定當前用戶 LINE Login" /><br />
                <br />
                <br />
                <label>要發送的訊息：</label>
                <br />
                <asp:TextBox ID="TextBoxMsg" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="ButtonSendMsgWithNotify" OnClick="ButtonSendMsgWithNotify_Click" CssClass="btn btn-success" runat="server" Text="發送訊息(透過LINE Notify)" />
                <asp:Button ID="ButtonSendMsgWithUserId" CssClass="btn btn-success" runat="server" Text="發送訊息(透過Push Message)" />
            </div>
        </div>
    </form>
</body>
</html>
