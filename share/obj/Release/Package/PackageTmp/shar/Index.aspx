<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="share.shar.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBlank" runat="server">
    <%
        share.DAL.shareService service = new share.DAL.shareService();
        List<share.Model.shareModel> list = service.Getshare(20);
        share.Model.CustomerModel customer = new share.Model.CustomerModel();
        if (Session["UserInfo"] != null)
        {
            customer = Session["UserInfo"] as share.Model.CustomerModel;
        }
    %>
    <div class="l-body_wrapper">
        <section class="l-body_wrapper_container">
            <div class="container u-mt--20">
                <section class="c-box">
                    <div class="c-box_content">
                        <div class="c-box_header">
                            <h5 class="u-f--l">发布我爱分享网</h5>
                        </div>
                        <div class="c-box_content_item">
                            <asp:TextBox ID="txtContent" runat="server" class="c-textarea u-mt--0" TextMode="MultiLine" Height="70px"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtContent" ID="RequiredFieldValidator1" runat="server" ErrorMessage="发布内容不可为空" Font-Bold="True" Font-Size="Small" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                        </div>
                        <div class="c-box_content_footer u-ta--r">
                            <%if (Session["UserInfo"] == null)
                              {
                                  Response.Write("<button class='btn btn-success' type='button' disabled='disabled'>请登录后再发布</button>");
                              }
                              else
                              {
                            %>
                            <asp:Button runat="server" Text="发布" class="btn btn-success" ID="btnPost" OnClick="btnPost_Click"></asp:Button>
                            <%
                                  }
                            %>
                        </div>
                    </div>
                </section>
                <section class="c-box">
                    <div class="c-box_content">
                        <div class="p-banner--weibo">
                            <img src="../App_Themes/Image/10525578.gif" onclick="ShowDBI()" />
                        </div>
                        <div class="c-box_content_item">
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
                <p class="l-footer_text u-ta--c">© <a href="http://wafxw.cn/" target="_blank">我爱分享网</a> <small>by<strong>Jyj</strong></small></p>
            </div>
        </footer>
    </div>
</asp:Content>
