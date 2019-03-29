<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineNotifyCallback.aspx.cs" Inherits="AccountMapping.LineNotifyCallback" %>

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
    <script>
        $(function () {
            $('#ButtonBack').click(function (e) {
                window.location.href = 'default.aspx';
            });
        });
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="margin: 10px">
            <div class="col-md-6">
                <label>LINE Notify Token:</label>
                <asp:TextBox ID="TextBoxToken" CssClass="form-control" runat="server"></asp:TextBox>
                <br />
                <input id="ButtonBack" class="btn btn-success" type="button" value="回首頁" />
            </div>
        </div>
    </form>
</body>
</html>
