<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReleaseEditors.aspx.cs" Inherits="share.ReleaseEditors" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="shortcut icon" href="App_Themes/Image/images/log.ico" />
    <title>爱生活,爱分享从这里起航……</title>
    <link href="/ueditor/themes/default/css/ueditor.css" rel="stylesheet" type="text/css" />
    <script src="/ueditor/ueditor.config.js" charset="utf-8" type="text/javascript"></script>
    <script src="/ueditor/ueditor.all.js" charset="utf-8" type="text/javascript"></script>
    <script src="App_Themes/js/jquery-1.9.1.min.js"></script>
    <script>
        ///兼容各种游览器关闭
        function CloseWebPage() {
            if (navigator.userAgent.indexOf("MSIE") > 0) {
                if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
                    window.opener = null;
                    window.close();
                } else {
                    window.open('', '_top');
                    window.top.close();
                }
            }
            else if (navigator.userAgent.indexOf("Firefox") > 0) {
                window.location.href = 'about:blank ';
            } else {
                window.opener = null;
                window.open('', '_self', '');
                window.close();
            }
        }
        function custom_close() {
            if 
(confirm("您确定要关闭本页吗？")) {
                window.opener = null;
                window.open('', '_self');
                window.close();
            }
            else { }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <span style=" float:right"><a class="l-btn" href="javascript:void(0)" onclick="custom_close();"><span class="l-btn-left">
            <img src="App_Themes/Image/images/cancel.png" alt="" />关 闭</span></a></span>
       
        <button type="button" class="navbar-fixed-bottom btn btn-default navbar-btn" 
            onclick="window.location='http://wafxw.cn/'" style="background-color: #000000; font-size: x-large; color: #FFFFFF;">返回主页</button>
        <div style="clear:both"></div>
                <div style="width: 700px; margin: 20px auto;">
                    <asp:DropDownList ID="drpType" runat="server" OnSelectedIndexChanged="drpType_SelectedIndexChanged" OnTextChanged="drpType_TextChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblName" runat="server" Text="" Font-Bold="True" Font-Size="X-Large" ForeColor="#FF5050"></asp:Label><br />
                    <br />
                    <asp:TextBox ID="txtTitle" runat="server" placeholder="              文章标题,限定50字内" MaxLength="50" Width="600px" Height="25px" Font-Size="16px"></asp:TextBox>
                </div>
                <div style="width: 200px; margin: 30px auto;">
                  <span style="margin:0px auto"><asp:Button ID="btnRelease" runat="server" Text="发  布" OnClientClick="return submitcheck();" Width="110px" Font-Bold="True" ForeColor="Blue" Height="30px" Font-Size="Large" OnClick="btnRelease_Click" /></span>
                </div>
        <div id="myEditor" style="width: 900px; height: 400px; margin: 20px auto"></div>
        <asp:HiddenField ID="HidContent" runat="server" />
        <script type="text/javascript">
            var ue = new baidu.editor.ui.Editor();
            ue.render("myEditor");
            ue.ready(function () { ue.setContent(''); })
        </script>
        <script type="text/javascript">
            function GetProDesc(obj) {
                var temp = UE.getEditor(obj).getContent();
                $("#HidContent").val(UE.getEditor(obj).getContent('myEditor'));
                return temp;
            }
            function submitcheck() {
                var content = GetProDesc('myEditor');
                if (content == "") {
                    alert("发表内容不能为空");
                    return false;
                }
                return true;
            }
        </script>
        <script>
            function CheckNull() {
                var lblName = document.getElementById("lblName").value;
                if (lblName == null) {
                    alert("发布栏目不可为空,请选择");
                    return false;
                }
                var txtTitle = document.getElementById("txtTitle").value;
                if (txtTitle == null) {
                    alert("发布标题不可为空,请选择");
                    return false;
                }
                var txtTitle = document.getElementById("txtTitle").value;
                if (txtTitle == null) {
                    alert("发布标题不可为空,请选择");
                    return false;
                }
                if (submitcheck()) {
                    return true;
                }
            }
        </script>
    </form>
</body>
</html>
