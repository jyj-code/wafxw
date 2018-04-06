<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/BasePage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="share.shar.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBlank" runat="server">

        <section class="c-screen  c-group-middle" style="background-color: #EDEDED;">
        <div class="p-login-container u-clearfix c-group-middle_content">
            <div class="c-box-login-wrap">
                <div class="p-login-form-links u-bounceInRight">
                    <img src="../App_Themes/Image/shortArticle.png" onclick="window.location='http://www.wafxw.cn/'" />
                </div>
                <div class="c-box-login u-bounceInLeft">
                    <div class="c-box-login_header">
                        <h3>修改密码</h3>
                    </div>
                        <div class="c-box-login_content">

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtold" runat="server" class="form-control" placeholder="原密码" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtnew1" runat="server" class="form-control" placeholder="新密码" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="c-textbox_wrap">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtnew2" runat="server" class="form-control" placeholder="确认新密码" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>



                            <div class="c-box-login_footer">
                                <a href="http://wafxw.cn/">返回</a>
                                <asp:Button ID="btnsubmit" runat="server" Text="提交" class="btn btn-success btn-lg u-f--r" OnClick="btnsubmit_Click" />
                            </div>
                        </div>
                </div>

                <div class="p-login-form-links u-bounceInRight">我爱分享网 by:Jyj 当前时间：<%=DateTime.Now%></div>
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
</asp:Content>
