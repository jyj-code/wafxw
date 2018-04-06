<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMenu.ascx.cs" Inherits="share.UCControl.NavigationMenu" %>
<%@ OutputCache Duration="30" VaryByParam="none"%>
<%@ Import Namespace="Combres" %>
<style type="text/css">
 #header{width:900px;margin:5px auto 10px auto}.nav_WXW{margin-top:0;position:absolute;width:900px;height:33px;background:url(../App_Themes/Image/navbg.gif) repeat-x}.nav_WXW li{position:relative;float:left}.nav_WXW .bg{background:url(../App_Themes/Image/nav_xian.gif) no-repeat;width:2px;height:33px;padding:0;display:block}.nav_WXW li a{line-height:30px;padding:0 21px;float:left;height:33px;color:#fff;font-size:14px}.nav_WXW li a:hover{background:url(../App_Themes/Image/navbg_a.gif) repeat-x;color:#fff}.nav_WXW li .nav-w{z-index:21;position:absolute;display:none;float:left;clear:both;overflow:hidden;top:33px;background:#fff;border:#faa651 1px solid;left:-1px}.nav_WXW li:hover a{background:url(../App_Themes/Image/navbg_a.gif) repeat-x;color:#fff}.nav_WXW li .section-nav1{padding:10px;height:auto;overflow:hidden}.nav_WXW li .section-nav1 ul{position:static;padding:0;margin:0;width:160px;overflow:hidden}.nav_WXW li .section-nav1 ul li{position:static;padding:0;margin-bottom:3px;width:100%;background:0;float:left}.nav_WXW li .section-nav1 ul li a{border:#f0f0f0 1px solid;text-align:left;padding:0;line-height:22px;width:auto;padding-left:3px;display:block;background:0;float:none;height:auto;color:#3167a5;font-size:12px;overflow:hidden;cursor:pointer}.nav_WXW li .section-nav1 ul li a:hover{border:#faa651 1px solid;background:0;color:#faa651}.Div_Mor_Content{font-size:18px;font-family:方正舒体}
</style>
<%= WebExtensions.CombresLink("siteCss") %>
 <%= WebExtensions.CombresLink("siteJs") %>
<div id="header">
    <ul class="nav_WXW">
        <li class="first">
            <a href="http://wafxw.cn/">Home</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repHome" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
        <li class="bg"></li>
        <li>
            <a href="../MoreDatailed.aspx">经验广场</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repjy" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
        <li class="bg"></li>
        <li>
            <a href="../shar/Index.aspx">微博广场</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repwb" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
        <li class="bg"></li>
        <li>
            <a href="../job/job.aspx">求职广场</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repJob" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
        <li class="bg"></li>
        <li>
            <a href="MoreDatailed.aspx?TreeType=12">值得一看</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repsec" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
        <li class="bg"></li>
        <li>
            <a href="MoreDatailed.aspx?TreeType=10">程序员家园</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repvio" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
        <li class="bg"></li>
        <li><a href="MoreDatailed.aspx?TreeType=13">网站公告</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="repinfor" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
         <li><a href="http://www.mmmxa.com/">分享综合平台</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
         <li><a href="MoreDatailed.aspx?TreeType=13">后台管理</a>
            <div class="nav-w">
                <div class="section-nav1">
                    <asp:Repeater ID="Repmanager" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><a href="<%#Eval("URL") %>"><%#Eval("NAME") %></a></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </li>
    </ul>
</div>
<script type="text/javascript">
    function initMenu() { var _speed = 400; var _hold = $("#header ul.nav_WXW"); var _t = null; if (_hold.length) { var _list = _hold.children(); _list.each(function () { var _el = $(this); var _box = _el.children("div.nav-w"); var _sub = _box.children(); _box.show().width(_sub.outerWidth()).hide(); _el.mouseenter(function () { var _this = this; _t = setTimeout(function () { $(_this).css("zIndex", 10); _el.addClass("hover"); if (_box.is(":hidden")) { _box.show(); _sub.css("marginTop", -_sub.outerHeight()) } _sub.stop().animate({ marginTop: 0 }, _speed) }, 300) }).mouseleave(function () { if (_t) { clearTimeout(_t) } var _this = $(this); $(this).css("zIndex", 5); if (_sub.length) { _sub.stop().animate({ marginTop: -_sub.outerHeight() }, _speed, function () { _box.hide(); _el.removeClass("hover"); _this.css("zIndex", 1) }) } else { _el.removeClass("hover") } }) }) } } $(document).ready(function () { initMenu() });
</script>
