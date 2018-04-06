<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="share.Login" %>

<%@ Import Namespace="Combres" %>
<!DOCTYPE html>
<!-- 声明文档结构类型 -->
<html lang="zh-cn">
<!-- 声明文档文字区域 -->
<head>
    <!-- 文档头部区域 -->
    <meta charset="UTF-8">
    <!-- 文档的头部区域中元数据区的字符集定义,这里是UTF-8,表示国际通用的字符集编码 -->
    <link rel="shortcut icon" href="App_Themes/Image/images/log.ico" />
    <title>登录，我爱分享网，分享从这里起航……</title>
    <!-- 文档的头部区域的标题。这里要注意,这个tittle的内容对于SEO来说极其重要 -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1 ">
    <!--[if IE 9]>
		<meta name=ie content=9>
	<![endif]-->
    <!--[if IE 8]>
		<meta name=ie content=8>
	<![endif]-->
    <!--[if IE 7]>
		<meta name=ie content=7>
	<![endif]-->
    <!-- 文档头部区域元数据区关于网站的关键字 -->
    <meta name="keywords" content="传播分享,互助共享,免费学习平台,求职联盟" />
    <!-- 文档头部区域元数据区关于文档描述的定义 -->
    <meta name="author" content="分享更懂生活,分享世界各地有趣,有爱,有价值的故事,微笑生活,快乐分享,分享最震撼心灵的智慧,最励志的人生感悟,这里是你经典的成功法则,这里是华人首富商学院,这里是你环游世界的好导游,这里是你居家养生好帮手,这里是男人的加油站,这里是女人的美容院,小孩的游乐园,老人的养生馆,这里是你学习,工作生活的加油站减压舱">
    <!-- 文档头部区域元数据区关于开发人员姓名的定义 -->
    <meta name="author" content="姜言俊" />
    <!-- 文档头部区域元数据区关于版权的定义 -->
    <link rel="short icon" href="favicon.ico">
    <!-- 文档头部区域的兼容性写法 -->
    <link rel="apple-touch-icon" href="custom_icon.png">
    <!-- 文档头部区域的apple设备的图标的引用 -->
    <meta name="viewport" content="width=device-width,user-scalable=no">
    <!-- 文档头部区域对于不同接口设备的特殊声明。宽=设备宽,用户不能自行缩放 -->
    <!-- Loading Bootstrap -->

    <script type="text/ecmascript">
        function ChenkIput() {
            if ($("#txtLoginName").val() == "")
            { alert("用户名不可为空！"); $("#txtLoginName").focus(); return false; }
            if ($("#txtLoginPassword").val() == "")
            { alert("用户密码不可为空！"); $("#txtLoginPassword").focus(); return false; }
        }
    </script>
    <script type="text/javascript" src="http://qzonestyle.gtimg.cn/qzone/openapi/qc_loader.js" data-appid="101272516" data-redirecturi="http://www.wafxw.cn/qq_back.html" charset="utf-8"></script>
    <script type="text/javascript">
        //调用QC.Login方法，指定btnId参数将按钮绑定在容器节点中
        QC.Login({
            //btnId：插入按钮的节点id，必选
            btnId: "qqLoginBtn",
            //用户需要确认的scope授权项，可选，默认all
            scope: "all",
            //按钮尺寸，可用值[A_XL| A_L| A_M| A_S|  B_M| B_S| C_S]，可选，默认B_S
            size: "A_M"
        }, function (reqData, opts) {//登录成功
            //根据返回数据，更换按钮显示状态方法
            var dom = document.getElementById(opts['btnId']),
            _logoutTemplate = [
                 //头像
                 '<span><img src="{figureurl}" class="{size_key}"/></span>',
                 //昵称
                 '<span>{nickname}</span>',
                 //退出
                 '<span><a href="javascript:QC.Login.signOut();">退出</a></span>'
            ].join("");
            dom && (dom.innerHTML = QC.String.format(_logoutTemplate, {
                nickname: QC.String.escHTML(reqData.nickname), //做xss过滤
                figureurl: reqData.figureurl
            }));
            document.cookie = "flag=2";
            var s = reqData.nickname + ";" + reqData.gender + ";" + reqData.figureurl;
            //window.location.href = "Home.aspx?nickname=" + s + "";
        }, function (opts) {//注销成功
            alert('QQ登录 注销成功');
        }
     );
    </script>
    <style>
        #Log_qq_Content
        {
            height: 30px;
            margin-left: 20px;
        }
    </style>
    <%= WebExtensions.CombresLink("siteCss") %>
    <%= WebExtensions.CombresLink("siteJs") %>
</head>
<body>
    <section class="c-screen  c-group-middle" style="background-color: #EDEDED;">
        <div class="p-login-container u-clearfix c-group-middle_content">
            <div class="c-box-login-wrap">
                <div class="p-login-form-links u-bounceInRight">
                    <img src="App_Themes/Image/shortArticle.png" onclick="window.location='http://www.wafxw.cn/'" />
                </div>
                <div class="c-box-login u-bounceInLeft">
                    <div class="c-box-login_header">
                        <h3>登录</h3>
                    </div>
                    <form id="frm1" runat="server">
                        <div class="c-box-login_content">
                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtLoginName" runat="server" class="form-control" placeholder="用户名"></asp:TextBox>
                                </div>
                            </div>
                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtLoginPassword" runat="server" class="form-control" placeholder="密码" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div id="Log_qq_Content">
                                <span id="qqLoginBtn"> <img src="App_Themes/Image/png/Connect_logo_3.png" /></span>
                               <%-- <img src="App_Themes/Image/png/Connect_logo_3.png" onclick="toQzoneLogin()" />
                                <script>
                                    function toQzoneLogin() {
                                        //以下为按钮点击事件的逻辑。注意这里要重新打开窗口
                                        //否则后面跳转到QQ登录，授权页面时会直接缩小当前浏览器的窗口，而不是打开新窗口
                                        var A = window.open("oauth/QQlogin.aspx", "TencentLogin", "width=450,height=320,menubar=0,scrollbars=1,resizable=1,status=1,titlebar=0,toolbar=0,location=1");
                                    }
                                </script>--%>
                            </div>
                            <div class="c-box-login_footer">
                                <a href="Register.aspx">没有帐号？点我注册</a>
                                <asp:Button ID="btnLogin" runat="server" Text="登录" class="btn btn-success btn-lg u-f--r" OnClientClick="return ChenkIput()" OnClick="btnLogin_Click" />
                            </div>

                        </div>
                    </form>
                </div>

                <div class="p-login-form-links u-bounceInRight"><a href="http://wafxw.cn/" target="_blank">The current time 当前时间：<%=DateTime.Now%></a></div>
            </div>
        </div>
    </section>

    <script type="text/javascript" src="App_Themes/developer/flatUi/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="App_Themes/developer/icheck/icheck.min.js"></script>
    <script>
        $(function () {
            $(":input").focus(function () {
                $(this).closest(".c-textbox_wrap").addClass("focused");
            }).blur(function () {
                $(this).closest(".c-textbox_wrap").removeClass("focused");
            });
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    </script>
</body>
</html>
