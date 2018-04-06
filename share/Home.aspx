<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/MaterPage.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Home" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="CphLeft" runat="server">
    <script language="JavaScript" type="text/javascript">
        function ChangeDiv(divId, divName, zDivCount) {
            for (i = 0; i <= zDivCount; i++) {
                document.getElementById(divName + i).style.display = "none";
            }
            document.getElementById(divName + divId).style.display = "block";
        }
    </script>
    <style type="text/css">
        #tj
        {
            background: url(App_Themes/Image/GIF/13.gif) no-repeat;
            background-position: left;
            padding-left: 40px;
        }

        .InforTbTable
        {
            background: url(App_Themes/Image/C3.gif) no-repeat;
            padding-left: 20px;
        }

        .InforTbTable1
        {
            background: url(App_Themes/Image/c.gif) no-repeat;
            padding-left: 20px;
        }

        .InforTbTable2
        {
            background: url(App_Themes/Image/C5.gif) no-repeat;
            padding-left: 20px;
        }

        .InforTbTable3
        {
            background: url(App_Themes/Image/images/C2.gif) no-repeat;
            padding-left: 20px;
        }

        .InforTbTable4
        {
            background: url(App_Themes/Image/GIF/3.gif) no-repeat;
            padding-left: 40px;
        }

        .InforTbTable5
        {
            background: url(App_Themes/Image/GIF/15.gif) no-repeat;
            padding-left: 20px;
        }

        .InforTbTable6
        {
            background: url(App_Themes/Image/8370091_255.gif) no-repeat;
            padding-left: 20px;
        }

        #news
        {
            background: url(App_Themes/Image/GIF/2.gif) no-repeat;
            background-position: left;
            padding-left: 40px;
        }

        .Home_Div_content
        {
            background: url(App_Themes/Image/GIF/6.gif) no-repeat;
            background-position: left;
            padding-left: 20px;
        }

        .Home_Div_TopTitle
        {
            background: url(App_Themes/Image/5555555555.gif);
            height: 10px;
            border-bottom: #808080;
        }

        .Home_Div_TopMiddle
        {
            background: url(App_Themes/Image/4444444444.gif);
            height: 18px;
            border-bottom: #808080;
        }

        .Home_Div_TopFoolt
        {
            background: url(App_Themes/Image/333333333.gif);
            border-bottom: #808080;
        }

        .Home_Div_li
        {
            background: url(App_Themes/Image/GIF/11.gif);
            background-position: top;
            padding-top: 5px;
        }

        #Home_div_main
        {
            margin-top: 50px;
            background: url(App_Themes/Image/png/1.png) no-repeat;
        }

        .Content_div a:hover
        {
            color: white;
            background-color: black;
        }
    </style>
    <div id="Home_div_main">
        <div class="mt20 mlr25">
            <div class="Home_Div_TopTitle"></div>
            <div class="fl wb50 pt5">
                <asp:Repeater ID="RepRecentUpdates" runat="server">
                    <ItemTemplate>
                        <ul class="mp0">
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li id="news" class="line-height-28">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <%# Eval("CreateDate","{0:yy-MM-dd}") %>
                                </li>
                            </a>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="fr wb50 pt5">
                <div class="RightSwitch" style="border-left: solid 1px #4cff00; border-bottom: solid 1px #4cff00;">
                    <div class="Content_div" style="z-index: 99; height: 35px;">
                        <ul class="mp0">
                            <li>
                                <a id="ctl00$ctl00$cphBlank$CphRight$LinkButton1"  onclick="AInformher_Click" onmousemove="JavaScript:ChangeDiv(&#39;0&#39;,&#39;JKDiv_&#39;,2)" href="javascript:__doPostBack(&#39;ctl00$ctl00$cphBlank$CphRight$LinkButton1&#39;,&#39;&#39;)">通知</a>  </li>
                            <li>
                                <a id="ctl00$ctl00$cphBlank$CphRight$LinkButton2" onclick="AJobher_Click" class="SelectStyle" onmousemove="JavaScript:ChangeDiv(&#39;1&#39;,&#39;JKDiv_&#39;,2)" href="javascript:__doPostBack(&#39;ctl00$ctl00$cphBlank$CphRight$LinkButton2&#39;,&#39;&#39;)">职场</a>
                            </li>
                            <li>
                                <a id="ctl00$ctl00$cphBlank$CphRight$LinkButton3"  onclick="AOtherher_Click" onmousemove="JavaScript:ChangeDiv(&#39;2&#39;,&#39;JKDiv_&#39;,2)" href="javascript:__doPostBack(&#39;ctl00$ctl00$cphBlank$CphRight$LinkButton3&#39;,&#39;&#39;)">其他分享</a>
                            </li>
                        </ul>
                    </div>
                    <div id="Div1" style="margin: 10px; font-size: 22px; line-height: 40px; color: #fff;">
                        <div id="JKDiv_0" class="relative" style="display: none;height: 300px;">
                            <marquee onmouseover="this.stop()" onmouseout="this.start()" scrollamount="3" scrolldelay="7" direction="up"> 
                            <asp:Repeater ID="RepInform" runat="server">
                                <ItemTemplate>
                                    <a href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                            <p class="InforTbTable4 line-height-28">
                                                <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <%# Eval("CreateDate","{0:yy-MM-dd}") %>
                                            </p>
                                        </a>
                                </ItemTemplate>
                            </asp:Repeater>
                                 </marquee>
                        </div>
                        <div id="JKDiv_1" class="relative" style="display: none; height: 300px;">
                            <marquee onmouseover="this.stop()" onmouseout="this.start()" scrollamount="3" scrolldelay="7" direction="up"> 
                            <asp:Repeater ID="Repjob" runat="server">
                                <ItemTemplate>
                                    <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                        <p class="InforTbTable2 line-height-28 f16">
                                            <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                        </p>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                                   </marquee>
                        </div>
                        <div id="JKDiv_2" class="relative" style="display: none; height: 300px; z-index: 2;">
                            <marquee onmouseover="this.stop()" onmouseout="this.start()" scrollamount="3" scrolldelay="7" direction="up"> 
                           <asp:Repeater ID="RepOther" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="InforTbTable6 line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                            </marquee>
                        </div>
                    </div>
                </div>
                <div class="mt5 fl">
                    <asp:Repeater ID="repRecommend" runat="server">
                        <ItemTemplate>
                            <ul class="mp0">

                                <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("ArticleContent") %>">
                                    <li id="tj" class="line-height-28 f16">
                                        <%# Eval("ArticleContent").ToString().Length>18?Eval("ArticleContent").ToString().Substring(0,18)+"...":Eval("ArticleContent").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%></li>
                                </a>

                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="clear">
                <br />
                <div class="clear Home_Div_TopMiddle">
                </div>
            </div>
            <div class="wb45 fl mr5">
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">社会经<a href="MoreDatailed.aspx?TreeType=7"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=3" title="去看更多娱乐经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="Repsociety" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">育儿经<a href="MoreDatailed.aspx?TreeType=7"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=5" title="去看更多娱乐经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepParenting" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">娱乐经<a href="MoreDatailed.aspx?TreeType=7"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=7" title="去看更多娱乐经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepRecreation" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">值得一看<a href="MoreDatailed.aspx?TreeType=12"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=8" title="去看更多值得一看分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepSec" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">程序员其他分享<a href="MoreDatailed.aspx?TreeType=10"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=5" title="去看更多程序员其他分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepProgrammer" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">.NET<a href="MoreDatailed.aspx?TreeType=15"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=5" title="去看更多.NET分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepNet" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">JAVA<a href="MoreDatailed.aspx?TreeType=16"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=6" title="去看更多Java分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepJAVA" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">JavaScript<a href="MoreDatailed.aspx?TreeType=17"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=1" title="去看更多JavaScript分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepJavaScript" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="wb45 fr ml5">
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">学习经<a href="MoreDatailed.aspx?TreeType=4"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=6" title="去看更多教育经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepStudy" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">生活经<a href="MoreDatailed.aspx?TreeType=1"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=4" title="去看更多教育经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="Replife" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">教育经<a href="MoreDatailed.aspx?TreeType=4"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=4" title="去看更多教育经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepEducation" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">理财经<a href="MoreDatailed.aspx?TreeType=8"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=8" title="去看更多理财经验分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"><%--<hr style="border: none; border-top: 5px solid; color: #0094ff; margin:0px;padding:0px"; />--%></li>
                    <asp:Repeater ID="RepMoney" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">心得段子分享<a href="MoreDatailed.aspx?TreeType=11"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=7" title="去看更多心得段子分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepExperience" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">Oracle<a href="MoreDatailed.aspx?TreeType=20"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=6" title="去看更多Oracle分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepOracle" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">SQL Server<a href="MoreDatailed.aspx?TreeType=19"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=6" title="去看更多SQL Server分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="Repsql" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="mp0">
                    <li class="fl Div_Tb_th Home_Div_li_1">CSS<a href="MoreDatailed.aspx?TreeType=18"></a></li>
                    <li class="fr Home_Div_li_2"><a href="MoreDatailed.aspx?TreeType=2" title="去看更多Css分享">更多>></a></li>
                    <li class="clear"></li>
                    <li class="Home_Div_li"></li>
                    <asp:Repeater ID="RepCSS" runat="server">
                        <ItemTemplate>
                            <a class="f16" href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>">
                                <li class="Home_Div_content line-height-28 f16">
                                    <%# Eval("Title").ToString().Length>18?Eval("Title").ToString().Substring(0,18)+"...":Eval("Title").ToString() %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <%# Eval("CreateDate","{0:yy-MM-dd}")%>
                                </li>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <br />
        <div class="clear Home_Div_TopFoolt">
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphContent" runat="server">
</asp:Content>
