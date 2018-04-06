using System;
using System.Web;
/// <summary>
///MyHandler 的摘要说明
/// </summary>
public class MyHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext ctx)//方法名固定
    {
        HttpResponse Response;
        ctx.Response.Write("我爱分享网提醒：构建和谐网络空间是您我共同责任，请勿非法访问，http://www.wafxw.cn/  ，Sorry");
    }
    bool IHttpHandler.IsReusable
    {
        get { return false; }
    }

}