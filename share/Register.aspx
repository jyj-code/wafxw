<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="share.Register" %>

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
    <title>注册</title>
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
        function ChenInput() {
            if ($("#txtCustomerName").val().trim() == "") {
                alert('真实名字不可为空！');
                $("#txtCustomerName").focus();
                return false;
            }
            if ($("#ddSex").options[index].val().trim() != -1) {
                alert("请选择性别");
                return false;
            }
            if ($("#txtLoginName").val().trim() == "") {
                alert('登录用户名不可为空！');
                $("#txtLoginName").focus();
                return false;
            }
            if ($("#txtLoginPassword1").val().trim() == "") {
                alert('请输入密码');
                $("#txtLoginPassword1").focus();
                return false;
            }
            if ($("#txtLoginPassword2").val().trim() == "") {
                alert('请再次输入密码');
                $("#txtLoginPassword2").focus();
                return false;
            }
            if ($("txtLoginPassword1").val().trim() != $("txtLoginPassword2").val().trim()) {
                alert('两次密码输入不一致,请重新输入');
                $("txtLoginPassword1").val() = "";
                $("txtLoginPassword1").focus();
                $("txtLoginPassword2").val() = "";
                return false;
            }
            return true;
        }
    </script>
    <%= WebExtensions.CombresLink("siteCss") %>
    <%= WebExtensions.CombresLink("siteJs") %>
</head>
<body>
    <section class="c-screen  c-group-middle" style="background-color: #EDEDED;">
        <div class="p-login-container u-clearfix c-group-middle_content">
            <div class="c-box-login-wrap">
                <div class="p-login-form-links u-bounceInRight">
                    <img src="../App_Themes/Image/shortArticle.png" onclick="window.location='http://www.wafxw.cn/'" />
                </div>
                <div class="c-box-login u-bounceInLeft">
                    <div class="c-box-login_header">
                        <h3>用户注册</h3>
                    </div>
                    <form id="frm1" runat="server">
                        <div class="c-box-login_content">

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtCustomerName" runat="server" class="form-control" placeholder="姓名"></asp:TextBox>
                                </div>
                            </div>

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:DropDownList ID="ddSex" runat="server" class="form-control">
                                        <asp:ListItem Value="">请选择性别</asp:ListItem>
                                        <asp:ListItem Value="0">男</asp:ListItem>
                                        <asp:ListItem Value="1">女</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtLoginName" runat="server" class="form-control" placeholder="登录名"></asp:TextBox>
                                </div>
                            </div>

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtLoginPassword1" runat="server" class="form-control" placeholder="密码" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtLoginPassword2" runat="server" class="form-control" placeholder="确认密码" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>



                            <div class="c-box-login_footer">
                                <a href="Login.aspx">已有帐号？点我登录</a>
                                <asp:Button ID="btnReg" runat="server" Text="注册" class="btn btn-success btn-lg u-f--r" OnClientClick="return ChenInput()" OnClick="btnReg_Click" />
                            </div>
                        </div>
                    </form>
                </div>

                <div class="p-login-form-links u-bounceInRight"><a href="mmmxa.com" target="_blank">by:我爱分享网,分享从这里起航…… 当前时间：<%=DateTime.Now%></a></div>
            </div>
        </div>
    </section>
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
