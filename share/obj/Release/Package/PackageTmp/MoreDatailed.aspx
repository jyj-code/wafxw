<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/MaterPage.master" AutoEventWireup="true" CodeBehind="MoreDatailed.aspx.cs" Inherits="share.MoreDatailed" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphContent" runat="server">
    <style type="text/css">
        #MenuLeft
        {
            font-family: 华文琥珀;
            color: black;
            line-height: 10px;
            font-size: 30px;
            font-weight: 800;
            border-right: 5px solid red;
            width: 150px;
        }

        .anpager .cpb
        {
            background: #1F3A87 none repeat scroll 0 0;
            border: 1px solid #CCCCCC;
            color: #FFFFFF;
            font-weight: bold;
            margin: 5px 4px 0 0;
            padding: 4px 5px 0;
        }

        .anpager a
        {
            background: #FFFFFF none repeat scroll 0 0;
            border: 1px solid #CCCCCC;
            color: #1F3A87;
            margin: 5px 4px 0 0;
            padding: 4px 5px 0;
            text-decoration: none;
        }

            .anpager a:hover
            {
                background: #1F3A87 none repeat scroll 0 0;
                border: 1px solid #1F3A87;
              
            }
        #Content_DIv
        { background-color:#FEFAFE;
         background-image:url(App_Themes/Image/images/Carousel/0002.gif); background-repeat:no-repeat; background-position:right;
        }
    </style>
   <div id="Content_DIv" class="mlr mt20">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="w100 fl">
                    <asp:Repeater ID="RelLeft" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li id="MenuLeft">
                                    <asp:LinkButton ID="linkMenuLeft" CommandArgument='<%# Container.DataItem %>'
                                        OnClick="linkMenuLeft_Click" runat="server"><%# Container.DataItem %></asp:LinkButton></li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="fl ml10 pl10" style="padding-left: 100px;">
                    <table>
                        <thead>
                            <asp:Label ID="lblHEader" runat="server" Font-Bold="False" Font-Size="Medium" Font-Underline="True" ForeColor="black" EnableTheming="True"></asp:Label>
                        </thead>
                        <asp:Repeater ID="RepContent" runat="server">
                            <ItemTemplate>
                                <tr class="Div_Mor_Content">
                                    <td style="width: 60%; font-size: 18px; font-family: 仿宋; color: blue; line-height: 30px; padding-left: 10px; font-weight: 600">
                                        <a href="shar/ShortArticle.aspx?ArticleID=<%#Eval("ArticleID") %>" target="_blank" title="<%#Eval("Title") %>" style="font-family: 仿宋; color: #0000FF; font-size: 18px;">
                                            <%# Eval("Title").ToString().Length>20?Eval("Title").ToString().Substring(0,20)+"...":Eval("Title").ToString() %></a>
                                    </td>
                                    <td style="width: 200px"><%# Eval("CreateDate","{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="2">
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>
                                    <webdiyer:AspNetPager ID="AspNetPager1"
                                        CssClass="anpager" CurrentPageButtonClass="cpb" PagingButtonSpacing="0"
                                        runat="server" PageSize="10" AlwaysShow="True" OnPageChanged="AspNetPager1_PageChanged" ShowCustomInfoSection="Left" ShowPageIndexBox="always" PageIndexBoxType="DropDownList">
                                    </webdiyer:AspNetPager>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear"></div>
    </div>
</asp:Content>
