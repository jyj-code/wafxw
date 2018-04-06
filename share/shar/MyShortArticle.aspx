<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="MyShortArticle.aspx.cs" Inherits="share.shar.MyShortArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBlank" runat="server">
    <%
        share.DAL.shareService service = new share.DAL.shareService();
        List<share.Model.shareModel> list = new List<share.Model.shareModel>();
        share.Model.CustomerModel customer = new share.Model.CustomerModel();
        string typeName = string.Empty;
        if (Session["UserInfo"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            customer = Session["UserInfo"] as share.Model.CustomerModel;
            string operType = Request.QueryString["OperType"];
            if (operType == "My")
            {
                typeName = "我发布的";
                list = service.GetshareByMy(customer.CustomerID);
            }
            else if (operType == "Like")
            {
                typeName = "我赞过的";
                list = service.GetshareByLike(customer.CustomerID);
            }
            else if (operType == "Comment")
            {
                typeName = "我评论过的";
                list = service.GetshareByComment(customer.CustomerID);
            }
            else if (operType == "Favorite")
            {
                typeName = "我收藏过的";
                list = service.GetshareByFavorite(customer.CustomerID);
            }
        }

    %>
    <script>document.write(unescape('%3Cdiv id="hm_t_86056"%3E%3C/div%3E%3Cscript charset="utf-8" src="http://crs.baidu.com/t.js?siteId=c5798d023529c3903b3fc0799b352cd7&planId=86056&async=0&referer=') + encodeURIComponent(document.referrer) + '&title=' + encodeURIComponent(document.title) + '&rnd=' + (+new Date) + unescape('"%3E%3C/script%3E'));</script>
    <script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "1", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "16" }, "slide": { "type": "slide", "bdImg": "6", "bdPos": "right", "bdTop": "97" }, "image": { "viewList": ["qzone", "tsina", "tqq", "renren", "weixin"], "viewText": "分享到：", "viewSize": "16" }, "selectShare": { "bdContainerClass": null, "bdSelectMiniList": ["qzone", "tsina", "tqq", "renren", "weixin"] } }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "//hm.baidu.com/hm.js?493a4ecc837051277c95c708f5095543";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>
    <style>
        .p-banner--weibo
        {
            width: 100%;
            height: 100px;
            background-color: #dddddd;
        }

        .p-user--dropdown
        {
            padding: 4px !important;
        }

        .p-banner--weibo img
        {
            width: 100%;
            height: 100%;
        }

        body
        {
            background-color: #EDEDED;
        }

        .l-footer
        {
            background-color: #F8F8F8;
        }
    </style>
    <script type="text/javascript">
        function DeleteArticle(articleID) {
            if (confirm("确定要删除吗？")) {
                window.location = "DeleteShortArticle.aspx?ArticleID=" + articleID;
            }
        }

        function Exit() {
            if (confirm("确定要退出吗？")) {
                window.location = "Exit.aspx";
            }
        }

        function Like(articleID, customerID, likeCount) {
            if (customerID == "00000000-0000-0000-0000-000000000000") {
                layer.msg('登录后才能点赞哦~');
            }
            else {
                $.ajax({
                    type: 'get',
                    url: 'AjaxLike.ashx', //请求的地址
                    data: { articleID: articleID, customerID: customerID },  //要传的参数
                    dataType: "text",
                    success: function (returnJson) {  //msg的返回结果
                        if (returnJson == "True") {
                            $("#spLike" + articleID).text("(" + (likeCount + 1) + ")"); //更新点赞次数
                            layer.msg('赞 +1');

                        }
                        else {
                            layer.msg('不能重复点赞哦~');
                        }
                    }
                });
            }
        }

        function Favorite(articleID, customerID) {

            if (customerID == "00000000-0000-0000-0000-000000000000") {
                layer.msg('登录后才能收藏哦~');
            }
            else {
                $.ajax({
                    type: 'get',
                    url: 'AjaxFavorite.ashx', //请求的地址
                    data: { articleID: articleID, customerID: customerID },  //要传的参数
                    dataType: "text",
                    success: function (returnJson) {  //msg的返回结果
                        if (returnJson == "True") {
                            layer.msg('该条我爱分享网已放入收藏夹 (*^__^*) ');
                        }
                        else {
                            layer.msg('您已经收藏过了哦 不能重复收藏~');
                        }
                    }
                });
            }
        }

    </script>
    <div class="l-body_wrapper">
        <section class="l-body_wrapper_container">
            <div class="container u-mt--20">
                <section class="c-box">
                    <div class="c-box_content">
                        <div class="p-banner--weibo">
                            <img src="../App_Themes/Image/10525578.gif" />
                        </div>
                        <div class="c-box_content_item">
                            <h1 class="u-m--0 u-fs--24 u-mb--15"><%=typeName%></h1>
                            <div class="row c-row--ib">

                                <%foreach (var item in list)
                                  {
                                %>
                                <div class="col-lg-12">
                                    <div class="c-box c-box--mini">
                                        <header class="c-header c-header--avatar">

                                            <h1 class="c-header_title">
                                                <a href="#">
                                                    <div class="c-avatar u-wh--50">
                                                        <%if (item.CustomerSex.Contains('男'))
                                                          {
                                                              Response.Write("<img src='../App_Themes/Image/av1.png' />");
                                                          }
                                                          else
                                                          {
                                                              Response.Write("<img src='../App_Themes/Image/av6.png' />");
                                                          } 
                                                        %>
                                                    </div>
                                                    <span><%=item.CustomerName %></span>
                                                </a>
                                            </h1>
                                            <span class="label label-success u-f--r u-mt--15"><%=item.CreateDate %></span>
                                        </header>
                                        <div class="c-content u-pb--0">
                                            <p><%=item.ArticleContent %></p>
                                        </div>

                                        <div class="c-footer u-ta--r">
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-default" onclick="Like('<%=item.ArticleID%>','<%=customer.CustomerID%>',<%=item.LikeCount%>)"><span class="glyphicon glyphicon-thumbs-up u-mr--5"></span>赞<span class=" u-ml--5" id="spLike<%=item.ArticleID%>">(<%=item.LikeCount%>)</span></button>
                                                <button type="button" class="btn btn-default" onclick="window.location='ShortArticle.aspx?ArticleID=<%=item.ArticleID%>'"><span class="glyphicon glyphicon-comment u-mr--5"></span>评论<span class=" u-ml--5">(<%=item.CommentCount%>)</span></button>
                                                <button type="button" class="btn btn-default" onclick="Favorite('<%=item.ArticleID%>','<%=customer.CustomerID%>')"><span class="glyphicon glyphicon glyphicon-star-empty u-mr--5"></span>收藏</button>
                                                <%if (item.CustomerID == customer.CustomerID)
                                                  {%>
                                                <button type="button" class="btn btn-default" onclick="DeleteArticle('<%=item.ArticleID%>')"><span class="glyphicon glyphicon glyphicon-trash u-mr--5"></span>删除</button>
                                                <% }%>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%}%>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>
        <footer class="l-body_wrapper_footer u-ml--0">
            <div class="l-footer js-footer u-ml--0">
                <p class="l-footer_text u-ta--c">© <a href="http://wafxw.cn/" target="_blank">我爱分享网</a><small> by<strong>Jyj</strong></small></p>
            </div>
        </footer>
    </div>
</asp:Content>
