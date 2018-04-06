<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="job.aspx.cs" Inherits="share.job.job" %>

<%@ Register TagPrefix="ShareHader" TagName="ShareHader" Src="~/UCControl/SharHeader.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="我爱分享网,分享,传播,互助,共享,免费,学习平台,求职联盟" />
    <!-- 文档头部区域元数据区关于文档描述的定义 -->
    <meta name="description" content="我爱分享网,分享大招聘网站信息集中起来浏览，第一省了来回切换，第二还不容易重复投简历，我们需要用的的就三个。搜索关键字、地址和页码" />
    <link rel="shortcut icon" href="../App_Themes/Image/images/log.ico" />
    <title>分享大招聘网站信息，求职联盟</title>
    <style type="text/css">
        #content
        {
            margin: 0px auto;
        }

        #Titles
        {
            width: 500px;
            height: 30px;
            margin: 0px auto;
        }
    </style>
    <%--    解决不带www转定向到带www的域名下--%>
    <script language="javascript">
        if (document.domain == 'wafxw.cn')
            this.location = "http://www.wafxw.cn" + this.location.pathname + this.location.search;
    </script>
    <script>document.write(unescape('%3Cdiv id="hm_t_86056"%3E%3C/div%3E%3Cscript charset="utf-8" src="http://crs.baidu.com/t.js?siteId=c5798d023529c3903b3fc0799b352cd7&planId=86056&async=0&referer=') + encodeURIComponent(document.referrer) + '&title=' + encodeURIComponent(document.title) + '&rnd=' + (+new Date) + unescape('"%3E%3C/script%3E'));</script>
    <script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "1", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "16" }, "slide": { "type": "slide", "bdImg": "6", "bdPos": "right", "bdTop": "97" }, "image": { "viewList": ["qzone", "tsina", "tqq", "renren", "weixin"], "viewText": "分享到：", "viewSize": "16" }, "selectShare": { "bdContainerClass": null, "bdSelectMiniList": ["qzone", "tsina", "tqq", "renren", "weixin"] } }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "//hm.baidu.com/hm.js?c5798d023529c3903b3fc0799b352cd7";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ShareHader:ShareHader ID="ShareHader" runat="server" />
        <br />
        <br />
        <div id="content">
            <div id="Titles">
                <input type="text" class="" name="" id="inp_key" subtag="sub" onkeyup="keyupsojob();" value=".net" />
                <select id="sel_city" subtag="sub">
                    <option value="北京">北京</option>
                    <option selected="selected" value="苏州">苏州</option>
                    <option value="上海">上海</option>
                    <option value="广州">广州</option>
                    <option value="深圳">深圳</option>
                    <option value="天津">天津</option>
                    <option value="安康">安康</option>
                    <option value="重庆">重庆</option>
                    <option value="南京">南京</option>
                    <option value="杭州">杭州</option>
                    <option value="大连">大连</option>
                    <option value="成都">成都</option>
                    <option value="武汉">武汉</option>
                </select>
                <input type="button" value="走起……" id="but" onclick="sojob();" />
                <div style="float: left; padding-left: 10px; padding-top: 10px">
                    <input type="checkbox" checked="checked" id="chk_zhilian" value="智联" subtag="sub" /><a href="http://www.zhaopin.com" target="_blank">智联</a>&nbsp;&nbsp;
                    <input type="checkbox" checked="checked" id="chk_liepin" value="猎聘" subtag="sub" /><a href="http://www.liepin.com" target="_blank">猎聘</a>&nbsp;&nbsp;
                    <input type="checkbox" checked="checked" id="chk_qiancheng" value="前程" subtag="sub" /><a href="http://51com" target="_blank">前程</a>
                </div>
            </div>
            <br />
            <hr />
            <div style="width: 90%; margin: 0px auto;">
                <div id="top_div">
                    <table class="mytable mytableTh" style="width: 98%">
                        <tr>
                            <th style="width: 4%;">标记</th>
                            <th style="width: 25%">招聘职位</th>
                            <th style="width: 20%">公司名称</th>
                            <th style="width: 10%">地址</th>
                            <th style="width: 8%">发布时间</th>
                            <th style="width: 5%">方式</th>
                            <th style="width: 8%">薪资</th>
                            <th style="width: 5%">链接</th>
                            <th style="width: 7%">来源</th>
                        </tr>
                    </table>
                </div>
                <div>
                    <table class="mytabledata mytable" style="width: 95%">
                    </table>
                </div>
                <div style="display: none">
                    <img />
                    <script type="text/javascript">var cnzz_protocol = (("https:" == document.location.protocol) ? " https://" : " http://");
                        document.write(unescape("%3Cspan id='cnzz_stat_icon_1254624500'%3E%3C/span%3E%3Cscript src='" +
                            cnzz_protocol + "s95.cnzz.com/z_stat.php%3Fid%3D1254624500' type='text/javascript'%3E%3C/script%3E"));

                    </script>
                </div>
            </div>
            <script src="script/jquery-1.7.1.min.js"></script>
            <script src="script/common/common.js"></script>
            <script src="script/common/MyDataPack.js"></script>
            <script src="script/common/jquery.blockUI.js"></script>
            <script type="text/javascript">
                var index = 0;
                //双击选中的颜色
                var selectOK = "#EDBFF7",
                    //鼠标停留在上面时的颜色
                    selecting = "#C9F0E8";
                //重新搜索
                function sojob() {
                    index = 0;
                    GetZhaoPinInfo(true);
                    window.scrollTo(0, 0);
                }
                function keyupsojob() {
                    if (event.keyCode == 13)
                        sojob();
                }
                //页面加载完成~~
                $(function () {
                    //
                    index = 0;
                    GetZhaoPinInfo(true);
                    //滚动条事件
                    window.onscroll = function () {
                        if ($.getScrollbheight() <= 0) {
                            GetZhaoPinInfo();
                        }
                    }
                });

                //当鼠标移动到某对象范围的上方时触发的事件
                function img_over(obj) {
                    $(obj).attr('src', 'imgs/星星ok.ico');
                }

                //当鼠标离开某对象范围时触发的事件
                function img_out(obj) {
                    if ($(obj).attr('isClick') == "false")
                        $(obj).attr('src', 'imgs/星星no.ico');
                    else
                        $(obj).attr('src', 'imgs/星星ok.ico');
                }
                //鼠标上的按钮被按下了
                function img_down(obj) {
                    if ($(obj).attr('isClick') == "false") {
                        $(obj).attr('isClick', 'true');
                        $(obj).parents("tr").attr("isDbClick", "true");
                        $(obj).parents("tr").css("background-color", selectOK);
                        $(obj).attr('src', 'imgs/星星ok.ico');
                    }
                    else {
                        $(obj).attr('isClick', 'false');
                        $(obj).parents("tr").attr("isDbClick", "false");
                        $(obj).parents("tr").css("background-color", selecting);
                        $(obj).attr('src', 'imgs/星星no.ico');
                    }

                }

                function tr_over(obj) {
                    $(obj).css("background-color", selecting);
                }
                function tr_out(obj) {
                    if ($(obj).attr("isDbClick") == "false")
                        $(obj).css("background-color", "#e7f6e9");
                    else
                        $(obj).css("background-color", selectOK);
                }
                //双击行
                function tr_dblclick(obj) {
                    img_down($(obj).find("img"));
                    img_out($(obj).find("img"));
                }

                function GetZhaoPinInfo(isReload) {
                    index++;
                    var mydata = new MyDataPack("zhaopinPrcoess.ashx", "GetZhaoPinInfo");
                    mydata.getValueSetData("sub");
                    var obj = new Object();
                    obj.index = index;
                    mydata.addValue("obj", obj)
                    $.ajax({
                        type: "post",
                        dataType: 'json',
                        url: mydata.getUrl(),
                        data: mydata.getJsonData(),
                        beforeSend: function (XMLHttpRequest) {
                            $.blockUI({ type: 2 });
                        },
                        complete: function (jqXHR, status, responseText) {
                            $.unblockUI();
                        },
                        success: function (data) {
                            if (mydata.ShowAjaxResult(data)) {
                                var tr_html = "";
                                for (var i = 0; i < data.length; i++) {
                                    tr_html += "<tr isDbClick='false' onmouseover='tr_over(this);' onmouseout='tr_out(this);' ondblclick='tr_dblclick(this);'>";
                                    tr_html += "<td style='width:4%;text-align:center'><img isClick='false' class='img_xin'  onmouseover='img_over(this);' onmouseout='img_out(this);' onmousedown='img_down(this);' src='imgs/星星no.ico' /></td>";
                                    tr_html += "<td style='width:25%'>" + data[i].titleName + "</td>";
                                    tr_html += "<td style='width:20%'>" + data[i].company + "</td>";
                                    tr_html += "<td style='width:10%'>" + data[i].city + "</td>";
                                    tr_html += "<td style='width:8%'>" + data[i].date + "</td>";
                                    tr_html += "<td style='width:5%'>" + data[i].salary + "</td>";
                                    tr_html += "<td style='width:8%'>" + data[i].salary_em + "</td>";
                                    tr_html += "<td style='width:5%'><a href='" + data[i].info_url + "' target='_blank'>详情</a></td>";
                                    tr_html += "<td style='width:7%'>" + data[i].source + "</td>";
                                    tr_html += "</tr>";
                                }
                                if (isReload)
                                    $(".mytabledata").html(tr_html);
                                else
                                    $(".mytabledata").append(tr_html);
                            }
                        },
                        error: function (msg) {
                            debugger;
                            alert(msg.statusText);
                        }
                    });
                }
            </script>
        </div>
    </form>
    <%if (Request.Url.ToString().Contains("wafxw.cn"))
      {%>
    <%--长条广告--%>
    <script type="text/javascript">
        document.write('<a style="display:none!important" id="tanx-a-mm_21895481_12034648_43672510"></a>');
        tanx_s = document.createElement("script");
        tanx_s.type = "text/javascript";
        tanx_s.charset = "gbk";
        tanx_s.id = "tanx-s-mm_21895481_12034648_43672510";
        tanx_s.async = true;
        tanx_s.src = "http://p.tanx.com/ex?i=mm_21895481_12034648_43672510";
        tanx_h = document.getElementsByTagName("head")[0];
        if (tanx_h) tanx_h.insertBefore(tanx_s, tanx_h.firstChild);
    </script>
    <script type="text/javascript">
        document.write('<a style="display:none!important" id="tanx-a-mm_21895481_12034648_43680204"></a>');
        tanx_s = document.createElement("script");
        tanx_s.type = "text/javascript";
        tanx_s.charset = "gbk";
        tanx_s.id = "tanx-s-mm_21895481_12034648_43680204";
        tanx_s.async = true;
        tanx_s.src = "http://p.tanx.com/ex?i=mm_21895481_12034648_43680204";
        tanx_h = document.getElementsByTagName("head")[0];
        if (tanx_h) tanx_h.insertBefore(tanx_s, tanx_h.firstChild);
    </script>
    <%--浮窗--%>
    <script type="text/javascript">
        document.write('<a style="display:none!important" id="tanx-a-mm_21895481_12034648_43678513"></a>');
        tanx_s = document.createElement("script");
        tanx_s.type = "text/javascript";
        tanx_s.charset = "gbk";
        tanx_s.id = "tanx-s-mm_21895481_12034648_43678513";
        tanx_s.async = true;
        tanx_s.src = "http://p.tanx.com/ex?i=mm_21895481_12034648_43678513";
        tanx_h = document.getElementsByTagName("head")[0];
        if (tanx_h) tanx_h.insertBefore(tanx_s, tanx_h.firstChild);
    </script>
    <%--   悬停广告--%>
    <script type="text/javascript">
        document.write('<a style="display:none!important" id="tanx-a-mm_21895481_12034648_43674335"></a>');
        tanx_s = document.createElement("script");
        tanx_s.type = "text/javascript";
        tanx_s.charset = "gbk";
        tanx_s.id = "tanx-s-mm_21895481_12034648_43674335";
        tanx_s.async = true;
        tanx_s.src = "http://p.tanx.com/ex?i=mm_21895481_12034648_43674335";
        tanx_h = document.getElementsByTagName("head")[0];
        if (tanx_h) tanx_h.insertBefore(tanx_s, tanx_h.firstChild);
    </script>
    <%} %>
</body>
</html>
