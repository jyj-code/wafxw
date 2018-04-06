<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SharHeader.ascx.cs" Inherits="share.UCControl.SharHeader" %>
<%--<%@ OutputCache Duration="300" VaryByParam="*"%>--%>
<%@ Import Namespace="Combres" %>
<%
    share.DAL.shareService service = new share.DAL.shareService();
    List<share.Model.shareModel> list = service.Getshare(20);
    share.Model.CustomerModel customer = new share.Model.CustomerModel();
    if (Session["UserInfo"] != null)
    {
        customer = Session["UserInfo"] as share.Model.CustomerModel;
    }
%>
<%= WebExtensions.CombresLink("siteCss") %>
<%= WebExtensions.CombresLink("siteJs") %>
<script src="../App_Themes/developer/js/jquery-1.8.3.min.js"></script>
<script src="../App_Themes/developer/bootstrap/js/bootstrap.min.js"></script>
<div class="l-body_wrapper">
    <header class="l-header clearfix" style="height: 51px;">
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container fl" style="float: left; width:60%;">
                <div class="navbar-header">
                    <a class="navbar-brand" onclick="ShowDBI()" style="padding: 2px 0px;">
                        <img src="../App_Themes/Image/shortArticle.png" style="height: 46px;" onclick="window.location='http://www.wafxw.cn/'" />
                    </a>
                    <a class="navbar-brand" href="http://mail.wafxw.cn" title="我爱分享网专属邮箱通道" target="_blank" style="padding-top: 15px; margin-left: 10px">邮箱入口
                    </a>
                    <%if (Request.RawUrl != "/Home.aspx")
                      { %>
                    <%if (Request.RawUrl != "/")
                      { %>
                    <button type="button" class="navbar-right btn btn-default navbar-btn" onclick="window.location='http://wafxw.cn/'">返回主页</button>&nbsp;&nbsp;
                <% } %>
                    <% }%>
                </div>
            </div>
            <div class="fr" style="float: right;margin-right:30px;">
                <%if (Session["UserInfo"] == null)
                  {
                %>
                    <button type="button" class="navbar-right btn btn-default navbar-btn" onclick="window.location='../Register.aspx'">注册</button>&nbsp;&nbsp;
                    <button type="button" class="navbar-right btn btn-success navbar-btn u-mr--10" onclick="window.location='../Login.aspx'">登录</button>
                <%}
                  else
                  {%>
                <ul class="nav navbar-nav navbar-right" style="margin-top: 0px; padding-top: 0px">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle p-user--dropdown" data-toggle="dropdown">
                            <%=customer.CustomerName%><span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="Index.aspx">分享广场</a></li>
                            <li role="separator" class="divider"></li>
                            <li class="dropdown-header u-fs--16 u-fw--b">与我相关</li>
                            <li><a href="../shar/MyShortArticle.aspx?OperType=My">我发布的</a></li>
                            <li><a href="../shar/MyShortArticle.aspx?OperType=Like">我赞过的</a></li>
                            <li><a href="../shar/MyShortArticle.aspx?OperType=Comment">我评论过的文字</a></li>
                            <li><a href="../shar/MyShortArticle.aspx?OperType=Favorite">我收藏过的文字</a></li>
                            <li role="separator" class="divider"></li>
                            <li class="dropdown-header u-fs--16 u-fw--b">系统</li>
                            <li><a href="../shar/ChangePassword.aspx">修改密码</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="javascript:Exit()">退出</a></li>
                        </ul>
                    </li>
                </ul>
                <%}%>
            </div>
            <div style="clear: both"></div>
        </nav>
    </header>
</div>
