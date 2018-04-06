<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="UI.UCControl.Footer1" %>
<%@ Register TagPrefix="Advertisement" TagName="Advertisement" Src="~/UCControl/Advertisement.ascx" %>
<%@ Import Namespace="Combres" %>
<%= WebExtensions.CombresLink("siteCss") %>
<%= WebExtensions.CombresLink("siteJs") %>
<div style="width: 70%; margin: 0px auto; padding: 0px">
    <div style="color: red">友情链接：</div>
    <div style="color: #0000FF; text-decoration: solid">
        <asp:Repeater ID="RepFootLinks" runat="server">
            <ItemTemplate>
                 <a href="<%#Eval("URL") %>" title="<%#Eval("REMARK") %>" style="color: #0000FF; text-decoration: solid" target="_blank"><%#Eval("NAME") %></a>&nbsp;&nbsp;
            </ItemTemplate>
        </asp:Repeater>
            <br />
        <!-- 360有链-->
        <script type="text/javascript" src="http://links.webscan.360.cn/index/index/6cedbb331ca6d7c46155f71b3cca7e21"></script>
        <br />
        <br />
        <div style="text-align: center">
            <dl>
                <dt>技术支持:<a href="#" title="爱生活 爱分享,全在我爱分享网">admin@wafxw.cn</a>   &nbsp;&nbsp;Or  &nbsp;&nbsp;<a href="#">admin@mmmxa.com</a></dt>
                <dd>域名：<a href="http://wafxw.cn/" title="爱生活 爱分享,全在我爱分享网">mmmxa.com</a>&nbsp;&nbsp;<a href="http://wafxw.cn/">wafxw.cn</a></dd>
                <dd>Copyright &copy;2015<a href="http://www.mmmxa.com/" title="爱生活 爱分享,全在我爱分享网 姜言俊所有" target='_blank'> 我爱分享网</a>
                All Rights Reserved
            </dl>
        </div>
        <hr />
        <br />
        <div style="width: 400px; margin: auto;">
            <!-- 360安全认证-->
            <a href="http://webscan.360.cn/index/checkwebsite/url/wafxw.cn">
                <img border="0" src="http://img.webscan.360.cn/status/pai/hash/5aeb294fe8b8bdc87c929b333a9e8500" alt="爱生活 爱分享,全在我爱分享网" /></a>
            <a href="http://webscan.360.cn/index/checkwebsite/url/mmmxa.com" name="2835ef8ea725d5219f37108c1f71d914" target="_blank"></a>
            <a href="http://tongji.baidu.com/web/welcome/ico?s=c5798d023529c3903b3fc0799b352cd7" title="爱生活 爱分享,全在我爱分享网" target="_blank">百度统计</a>
        </div>
        <hr style="height: 2px;" />
        <br />
        <div style="width: 700px; margin: auto">Powered by 我爱分享网 本站资源来自互联网 ，建议使用Chrome,Firefox,IE11以上游览器和1366*768分辨率游览效果更佳</div>
        <br />
        <div style="text-align: center"><a href="http://www.miitbeian.gov.cn/" title="爱生活 爱分享,全在我爱分享网" target="_blank">陕ICP备15014626号-1</a></div>
        <br />
    </div>
</div>
<script type="text/javascript">
    // 设置为主页 
    function SetHome(obj, vrl) {
        try {
            obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
        }
        catch (e) {
            if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                }
                catch (e) {
                    alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
                }
                var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
                prefs.setCharPref('browser.startup.homepage', vrl);
            } else {
                alert("您的浏览器不支持,请按照下面步骤操作：\n1.打开浏览器设置。\n2.点击设置网页。\n3.输入：" + vrl + "点击确定。");
            }
        }
    }
    // 加入收藏 兼容360和IE6 
    function shoucang(sTitle, sURL) {
        try {
            window.external.addFavorite(sURL, sTitle);
        }
        catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e) {
                alert("加入收藏失败,请使用Ctrl+D进行添加");
            }
        }
    }
</script>

<%if (Request.Url.ToString().Contains("wafxw.cn"))
  {%>
 <Advertisement:Advertisement ID="Advertisements" runat="server" />
<%} %>