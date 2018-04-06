<%@ WebHandler Language="C#" Class="getRemoteImage" %>
/**
 * Created by visual studio 2010
 * User: xuheng
 * Date: 12-3-8
 * Time: 下午13:33
 * To get the Remote image.
 */
using System;
using System.Web;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

public class getRemoteImage : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //这种是复制外网的,不需要重新保存本地
        string savePath = context.Server.MapPath("/ueditor/net/ueditorFile/imgFile/");       //保存文件地址
        savePath += DateTime.Now.ToString("yyyy-MM-dd") + "/";
        string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };             //文件允许格式
        int fileSize = 3000;                                                        //文件大小限制,单位kb

        string uri = context.Server.HtmlEncode(context.Request["upfile"]);
        uri = uri.Replace("&amp;", "&");
        string[] imgUrls = Regex.Split(uri, "ue_separate_ue", RegexOptions.IgnoreCase);

        ArrayList tmpNames = new ArrayList();//这里原本是保存本地新路径,然后返回,现在都没保存 就 不用把这个返回给页面了
        WebClient wc = new WebClient();
        HttpWebResponse res;
        String tmpName = String.Empty;
        String imgUrl = String.Empty;
        String currentType = String.Empty;

        try
        {
            for (int i = 0, len = imgUrls.Length; i < len; i++)
            {
                imgUrl = imgUrls[i];

                if (imgUrl.Substring(0, 7) != "http://")
                {
                    tmpNames.Add("error!");
                    continue;
                }

                //格式验证
                int temp = imgUrl.LastIndexOf('.');
                currentType = imgUrl.Substring(temp).ToLower();
                if (Array.IndexOf(filetype, currentType) == -1)
                {
                    tmpNames.Add("error!");
                    continue;
                }

                res = (HttpWebResponse)WebRequest.Create(imgUrl).GetResponse();
                //http检测
                if (res.ResponseUri.Scheme.ToLower().Trim() != "http")
                {
                    tmpNames.Add("error!");
                    continue;
                }
                //大小验证
                if (res.ContentLength > fileSize * 1024)
                {
                    tmpNames.Add("error!");
                    continue;
                }
                //死链验证
                if (res.StatusCode != HttpStatusCode.OK)
                {
                    tmpNames.Add("error!");
                    continue;
                }
                //检查mime类型
                if (res.ContentType.IndexOf("image") == -1)
                {
                    tmpNames.Add("error!");
                    continue;
                }
                res.Close();

                //var weburl = imgUrl;
                //string url = weburl.Split(new string[] { "//" }, 100, StringSplitOptions.RemoveEmptyEntries)[1].Split('/')[0];
                //var adminurl = RM.Busines.DAL.SQLHelper.AdminurlStr;
                //if(adminurl.ToLower().Contains(url.ToLower()))
                ////创建保存位置
                //if (!Directory.Exists(savePath))
                //{
                //    Directory.CreateDirectory(savePath);
                //}

                ////写入文件
                //tmpName =  System.Guid.NewGuid() + currentType;
                //wc.DownloadFile(imgUrl, savePath + tmpName);
                //tmpNames.Add("/ueditor/net/ueditorFile/imgFile/" + DateTime.Now.ToString("yyyy-MM-dd") + "/" + tmpName);
            }
        }
        catch (Exception)
        {
            tmpNames.Add("error!");
        }
        finally
        {
            wc.Dispose();
        }
        context.Response.Write("{url:'" + uri + "',tip:'远程图片抓取成功！',srcUrl:'" + uri + "'}");
    }

    //集合转换字符串
    private string converToString(ArrayList tmpNames)
    {
        String str = String.Empty;
        for (int i = 0, len = tmpNames.Count; i < len; i++)
        {
            str += tmpNames[i] + "ue_separate_ue";
            if (i == tmpNames.Count - 1)
                str += tmpNames[i];
        }
        return str;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}