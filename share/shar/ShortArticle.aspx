<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="ShortArticle.aspx.cs" Inherits="share.shar.ShortArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlank" runat="server">
    <%
        share.DAL.shareService service = new share.DAL.shareService();
        Guid articleID = Guid.Empty;
        if (Request.QueryString["ArticleID"] != null)
        {
            articleID = Guid.Parse(Request.QueryString["ArticleID"]);
        }
        share.Model.shareModel article = service.GetshareDetail(articleID);
        List<share.Model.ArticleCommentModel> articleCommentList = service.GetArticleCommentList(articleID);
        share.Model.CustomerModel customer = new share.Model.CustomerModel();
        if (Session["UserInfo"] != null)
        {
            customer = Session["UserInfo"] as share.Model.CustomerModel;
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
                        <div class="c-box_content_item">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="c-box c-box--mini u-mb--0">
                                        <header class="c-header c-header--avatar">

                                            <h1 class="c-header_title">
                                                <a href="#">
                                                    <div class="c-avatar u-wh--50">
                                                        <%if (article.PhotoUrl == null)
                                                          {%>
                                                        <%if (article.CustomerSex.Contains('男'))
                                                          {
                                                              Response.Write("<img src='../App_Themes/Image/av1.png' />");
                                                          }
                                                          else
                                                          {
                                                              Response.Write("<img src='../App_Themes/Image/av6.png' />");
                                                          } 
                                                        %>
                                                        <%}
                                                          else
                                                          { %>
                                                        <img src="<%=article.PhotoUrl %>" />
                                                        <%} %>
                                                    </div>
                                                    <span><%=article.CustomerName%></span>
                                                </a>
                                            </h1>
                                            <p class="u-mt--15" style="margin-left:200px; font-size:20px; color:#0026ff; margin-top:10px";><%=article.Title%></p>
                                            <span class="label label-success u-f--r u-mt--15"><%=article.CreateDate%></span>
                                        </header>
                                        <div class="c-content u-pb--0">
                                            <p><%=article.ArticleContent%></p>
                                        </div>
                                        <div class="c-footer u-ta--r">
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-default" onclick="Like('<%=article.ArticleID%>','<%=customer.CustomerID%>',<%=article.LikeCount%>)"><span class="glyphicon glyphicon-thumbs-up u-mr--5"></span>赞<span class=" u-ml--5" id="spLike<%=article.ArticleID%>">(<%=article.LikeCount%>)</span></button>
                                                <button type="button" class="btn btn-default" onclick="Favorite('<%=article.ArticleID%>','<%=customer.CustomerID%>')"><span class="glyphicon glyphicon glyphicon-star-empty u-mr--5"></span>收藏</button>
                                                <%if (article.CustomerID == customer.CustomerID || article.ArticleID.ToString() == "8F5FC401-2DD2-4490-A062-2B92361D3182")
                                                  {%>
                                                <button type="button" class="btn btn-default" onclick="DeleteArticle('<%=article.ArticleID%>')"><span class="glyphicon glyphicon glyphicon-trash u-mr--5"></span>删除</button>
                                                <% }%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">

                                    <div class="u-pl--15 u-pr--15">
                                        <h1 class="u-fs--20">评论列表(<%=articleCommentList.Count%>)</h1>
                                        <hr class="c-hr">

                                        <%if (articleCommentList.Count == 0)
                                          { %>
                                        <div align="center">
                                            <h1>还没有人发表评论  来坐第一个沙发</h1>
                                        </div>
                                        <%}
                                          else
                                          {%>


                                        <ul class="media-list">

                                            <%foreach (var item in articleCommentList)
                                              {
                                            %>
                                            <li class="media u-bt--d u-pt--10">
                                                <div class="media-left">
                                                    <a class="c-avatar u-wh--50" href="#">
                                                        <%if (item.CustomerSex == 0)
                                                          {
                                                              Response.Write("<img src='../App_Themes/Image/av1.png' />");
                                                          }
                                                          else
                                                          {
                                                              Response.Write("<img src='../App_Themes/Image/av6.png' />");
                                                          } 
                                                        %>
                                                    </a>
                                                </div>
                                                <div class="media-body">
                                                    <h1 class="media-heading u-fs--14 u-c--grey"><%=item.CustomerName%></h1>
                                                    <p><%=item.ContentDesc%></p>
                                                    <div class="u-ta--l">
                                                        <span class="u-d--ib u-va--m u-c--grey u-fs--14"><%=item.CreateDate%></span>
                                                    </div>

                                                </div>
                                            </li>

                                            <%}%>
                                        </ul>

                                        <%}%>
                                            <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" class="c-textarea" Height="70px"></asp:TextBox>
                                            <div class="u-pt--10 u-ta--r">
                                                <%if (Session["UserInfo"] == null)
                                                  {
                                                      Response.Write("<button class='btn btn-success' type='button' disabled='disabled'>登录后才可以评论哦~</button>");
                                                  }
                                                  else
                                                  {
                                                %>
                                                <asp:Button runat="server" Text="评论" class="btn btn-lg btn-primary" ID="btnPost" OnClick="btnPost_Click"></asp:Button>
                                                <%
                                                  }
                                                %>
                                            </div>
                                    </div>
                                </div>
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