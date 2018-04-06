using share.log4net1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Text.RegularExpressions;

namespace share.Model
{
    public class Tool
    {
        //弹出框   
        public static void Alert(string str_Message)
        {
            ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
            scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="value"></param>
        public static void Writr(string FileName, string value)
        {
            try
            {
                string m_LogName = HttpContext.Current.Server.MapPath(FileName);
                if (!System.IO.File.Exists(m_LogName))
                {
                    System.IO.FileStream fsnew = System.IO.File.Create(m_LogName);
                    fsnew.Close();
                }
                using (System.IO.FileStream fs = System.IO.File.Open(m_LogName, System.IO.FileMode.Append, System.IO.FileAccess.Write))
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(fs))
                    {
                        w.WriteLine("【记录时间:{0}", DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss 记录信息：】    ") + value);
                        w.Flush();
                        w.Close();
                    }
                }
            }
            catch (Exception ms)
            {
                LogHelper.WriteLog(typeof(LogHelper), ms.Message);
            }
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="Content"></param>
        public static void WritrErro(Exception Content)
        {
            try
            {
                StackTrace ss = new StackTrace(true);
                MethodBase mb = ss.GetFrame(1).GetMethod();
                string name = "LogErro" + DateTime.Now.ToString("yyMM") + ".txt";
                string Value = "【Class：" + mb.DeclaringType.Name + "   Method：" + mb.Name +"】【Erro："+Content.Message+"】";
                Writr(name, Value);
            }
            catch (Exception s)
            {
                LogHelper.WriteLog(typeof(LogHelper),s);
            }
        }
        /// <summary>
        /// XML文件公共方法
        /// </summary>
        /// <param name="Target">节点</param>
        /// <param name="Path">配置文件的路径</param>
        /// <returns></returns>
        public static string GetXMLValue(string Target, string Path)
        {
            try
            {
                string XmlPath = HttpContext.Current.Server.MapPath(Path);
                System.Xml.XmlDocument xdoc = new XmlDocument();
                xdoc.Load(XmlPath);
                XmlElement root = xdoc.DocumentElement;
                XmlNode node = root.SelectSingleNode(Target);
                if (node != null)
                {
                    return node.InnerXml;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch { return string.Empty; }
        }
        public static string GetCharset(string input, string lanpack)
        {
            try
            {
                return GetXMLValue(input, lanpack);
            }
            catch { return string.Empty; }
        }
        /// <summary>
        /// 替换文本中的空格和换行
        /// </summary>
        public static string ReplaceSpace(string str)
        {
            string s = str;
            s = s.Replace(" ", "&nbsp;");
            s = s.Replace("\n", "<BR />");
            return s;
        }

        /// <summary>
        /// 过滤关键字，查看是否是禁用姓名
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="flag">true：关键字 false：姓名</param>
        /// <returns></returns>
        //public static string CheckKey(string key, bool flag)
        //{
        //    string fg = "";
        //    string strKey = "";
        //    if (flag)
        //    {
        //        strKey = Config.SysConfig.KeyWord;
        //    }
        //    else
        //    {
        //        strKey = JuSNS.Config.SysConfig.UserName;
        //    }

        //    string[] Str = strKey.Split('|');
        //    for (int i = 0; i < Str.Length; i++)
        //    {
        //        try
        //        {
        //            if (key.Contains(Str[i].ToString()))
        //            {
        //                fg = Str[i].ToString();
        //                break;
        //            }
        //        }
        //        catch { }
        //    }
        //    return fg;
        //}

        /// <summary>
        /// 取得文件扩展名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>扩展名</returns>
        public static string GetFileEXT(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return "";
            }
            if (filename.IndexOf(@".") == -1)
            {
                return "";
            }
            int pos = -1;
            if (!(filename.IndexOf(@"\") == -1))
            {
                pos = filename.LastIndexOf(@"\");
            }
            string[] s = filename.Substring(pos + 1).Split('.');
            return s[1];
        }
        /// <summary>
        /// 新文件名
        /// </summary>
        /// <returns></returns>
        //public static string GetNewFileName()
        //{
        //    return DateTime.Now.ToString("yyMMdd-hhmmss") + "-" + Common.Rand.Str(6);
        //}
        /// <summary>
        /// 转换头像路径为缩略路径
        /// </summary>
        /// <param name="orgHeadPicPath">原始路径</param>
        /// <param name="size">缩小级别</param>
        /// <returns></returns>
        //public static string GetSmallHeadPic(object orgHeadPicPath, int size)
        //{
        //    if (orgHeadPicPath == null || orgHeadPicPath == DBNull.Value)
        //        return GetSmallHeadPic((object)"default.jpg", size);
        //    if (orgHeadPicPath.ToString().Trim() == "")
        //        return GetSmallHeadPic((object)"default.jpg", size);
        //    string name = size.ToString();

        //    Dictionary<string, PicConfigInfo> _portrait = PicConfig.Portrait;
        //    string rvalue = string.Empty;
        //    string dir = string.Empty;
        //    dir += PicConfig.ProtraitServer + "/";
        //    if (dir.StartsWith("~/"))
        //    {
        //        dir = dir.Substring(2);
        //    }
        //    try
        //    {
        //        rvalue = (string)orgHeadPicPath;
        //    }
        //    catch { }

        //    if (rvalue.Trim() == string.Empty)
        //        return string.Empty;


        //    if (_portrait[name].Directory.EndsWith("/"))
        //    {
        //        rvalue = _portrait[name].Directory + rvalue;
        //    }
        //    else
        //    {
        //        rvalue = _portrait[name].Directory + "/" + rvalue;
        //    }
        //    rvalue = dir + rvalue;
        //    if (rvalue.StartsWith("/"))
        //    {
        //        return rootDir + rvalue;
        //    }
        //    if (rvalue.StartsWith("http"))
        //    {
        //        return rvalue;
        //    }
        //    return rootDir + "/" + rvalue;
        //}
        /// <summary>
        /// 取得原始头像路径
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        //public static string GetOrgHeadPic(string filename)
        //{
        //    if (string.IsNullOrEmpty(filename) || filename.Trim() == "")
        //        return GetOrgHeadPic("default.jpg");
        //    string dir = "";
        //    dir += PicConfig.ProtraitServer + "/";
        //    dir += PicConfig.ProtraitRoot;
        //    if (dir.StartsWith("~/"))
        //    {
        //        dir = dir.Substring(2);
        //    }
        //    string rvalue = filename;
        //    rvalue = dir + "/" + filename;
        //    if (rvalue.StartsWith("http") || rvalue.StartsWith("/"))
        //    {
        //        return rvalue;
        //    }
        //    return rootDir + "/" + rvalue;
        //}
        /// <summary>
        /// 取得原始照片路径
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        //static public string GetOrgPic(string filename)
        //{
        //    if (string.IsNullOrEmpty(filename))
        //    {
        //        return GetOrgPic("default.jpg");
        //    }
        //    string dir = string.Empty;
        //    dir += PicConfig.PhotoServer + "/";
        //    dir += PicConfig.PhotoRoot;
        //    string rvalue = filename;
        //    if (dir.StartsWith("~/"))
        //    {
        //        dir = dir.Substring(2);
        //    }
        //    rvalue = dir + "/" + filename;
        //    if (rvalue.StartsWith("http") || rvalue.StartsWith("/"))
        //    {
        //        return rvalue;
        //    }
        //    return rootDir + "/" + rvalue;
        //}
        /// <summary>
        /// 转换照片路径为缩略图路径
        /// </summary>
        /// <param name="orgPicPath">原始路径</param>
        /// <param name="size">缩小级别</param>
        /// <returns></returns>
        //static public string GetSmallPic(string orgPicPath, int size)
        //{
        //    if (string.IsNullOrEmpty(orgPicPath) || orgPicPath.Trim() == "")
        //        return GetSmallPic("default.jpg", size);
        //    string name = size.ToString();
        //    Dictionary<string, PicConfigInfo> _photo = PicConfig.Photo;
        //    if (string.IsNullOrEmpty(orgPicPath))
        //    {
        //        return string.Empty;
        //    }
        //    if (orgPicPath.StartsWith(rootDir + "/template/" + JuSNS.Config.UiConfig.SkinStyle + "/images"))
        //    {
        //        return orgPicPath.Substring(0);
        //    }
        //    string rvalue = string.Empty;
        //    string dir = string.Empty;
        //    dir += PicConfig.PhotoServer + "/";
        //    if (dir.StartsWith("~/"))
        //    {
        //        dir = dir.Substring(2);
        //    }
        //    try
        //    {
        //        rvalue = (string)orgPicPath;
        //    }
        //    catch { }

        //    if (rvalue.Trim() == string.Empty)
        //        return string.Empty;


        //    if (_photo[name].Directory.EndsWith("/"))
        //    {
        //        rvalue = _photo[name].Directory + rvalue;
        //    }
        //    else
        //    {
        //        rvalue = _photo[name].Directory + "/" + rvalue;
        //    }
        //    rvalue = dir + rvalue;
        //    if (rvalue.StartsWith("http") || rvalue.StartsWith("/"))
        //    {
        //        return rvalue;
        //    }
        //    return rootDir + "/" + rvalue;
        //}
 /// <summary>
        /// 取得所有图片地址
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        //static public string GetFilePath(object path, object filename)
        //{
        //    string filepath_endfix = path + "/" + filename;
        //    string filestr = "";
        //    string httpserver = Config.PicConfig.OtherServer;
        //    if (httpserver.ToLower().StartsWith("http"))
        //    {
        //        filestr = httpserver + "/" + filepath_endfix;
        //    }
        //    else
        //    {
        //        filestr = (rootDir + "/" + filepath_endfix).Replace("//", "/");
        //    }
        //    return filestr;
        //}

        /// <summary>
        /// 得到本地文件，并上传
        /// </summary>
        /// <param name="hpf"></param>
        /// <param name="allowExt"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        //static public string GetFile(HttpPostedFile hpf, string allowExt, string path)
        //{
        //    string filename = Common.Input.GetNewFileName();
        //    return GetFile(hpf, allowExt, path, filename);
        //}

        /// <summary>
        /// 得到本地文件，并上传
        /// </summary>
        /// <param name="hpf"></param>
        /// <param name="allowExt"></param>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        //static public string GetFile(HttpPostedFile hpf, string allowExt, string path, string filename)
        //{
        //    try
        //    {
        //        int PicSize = hpf.ContentLength;
        //        if (PicSize > 0)
        //        {
        //            if (Config.PicConfig.OtherServer != "~" && Config.PicConfig.OtherServer.StartsWith("http"))
        //            {
        //                #region 上传到远程
        //                int AllowSize = Convert.ToInt32(GetXMLValue("picsize")) * 1024 * 1024;
        //                if (PicSize > AllowSize) return string.Empty;
        //                string ext = Common.Input.GetFileExt(hpf.FileName);
        //                if (allowExt.IndexOf(ext) > -1)
        //                {
        //                    string newpath = path + "/" + filename + "." + ext;
        //                    UploadPic up = new UploadPicture();
        //                    up.server = Config.PicConfig.OtherServer;
        //                    byte[] data = new byte[hpf.ContentLength];
        //                    hpf.InputStream.Read(data, 0, (int)hpf.InputStream.Length);
        //                    up.UploadService(data, newpath);
        //                    return filename + "." + ext;
        //                }
        //                else
        //                {
        //                    return string.Empty;
        //                }
                        
        //                #endregion
        //            }
        //            else
        //            {
        //                #region 上传到本地
        //                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(path)))
        //                {
        //                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
        //                }
        //                int AllowSize = Convert.ToInt32(GetXMLValue("picsize")) * 1024 * 1024;
        //                if (PicSize > AllowSize) return string.Empty;
        //                string ext = Common.Input.GetFileExt(hpf.FileName);
        //                if (allowExt.IndexOf(ext) > -1)
        //                {
        //                    string newpath = path + "/" + filename + "." + ext;
        //                    newpath = HttpContext.Current.Server.MapPath(newpath);
        //                    hpf.SaveAs(newpath);
        //                    return filename + "." + ext;
        //                }
        //                else
        //                {
        //                    return string.Empty;
        //                }
        //            }
        //            #endregion 
                   
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //    catch { return string.Empty; }
        //}

        /// <summary>
        /// 获取图片的高或宽
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="Flag">0宽，1高度</param>
        /// <returns>返回尺寸</returns>
        static public int GetSize(string path,int Flag)
        {
            int n = 0;
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(path));
                if (Flag == 0)
                {
                    n=image.Width;
                }
                else
                {
                    n = image.Height;
                }
                image.Dispose();
            }
            catch
            {
                return 0;
            }
            return n;
        }

        static public string ShowPlayer(string FlvSource)
        {
            if (FlvSource.ToLower().IndexOf(".swf") > -1 || FlvSource.ToLower().IndexOf(".flv") > -1)
            {
                return Player(FlvSource);
            }
            else
            {
                string flvid = string.Empty;
                if (FlvSource.IndexOf("v.youku.com") > -1)
                {
                    flvid = Regex.Match(FlvSource, @"\/id_(?<content>[^\/]*?)\.html$", RegexOptions.Compiled | RegexOptions.IgnoreCase).Groups["content"].Value;
                    return Player("http://player.youku.com/player.php/sid/"+flvid+"/v.swf");
                }
                else if (FlvSource.IndexOf("tudou.com")>-1)
                {
                    flvid = Regex.Match(FlvSource, @"\/(?<content>[^\/]*?)\/$", RegexOptions.Compiled | RegexOptions.IgnoreCase).Groups["content"].Value;
                    return Player("http://www.tudou.com/v/" + flvid + "");
                }
                else if (FlvSource.IndexOf("v.ku6.com") > -1)
                {
                    flvid = Regex.Match(FlvSource, @"\/(?<content>[^\/]*?)\.html$", RegexOptions.Compiled | RegexOptions.IgnoreCase).Groups["content"].Value;
                    return Player("http://player.ku6.com/refer/" + flvid + "/v.swf");
                }
            }
            return string.Empty;
        }

        static public string Player(string FlvSource)
        {
            string listSTR = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"225\" height=\"200\">";
            listSTR += "<param name=\"movie\" value=\"" + FlvSource + "\" />";
            listSTR += "<param name=\"quality\" value=\"high\" />";
            listSTR += "<param name=\"allowFullScreen\" value=\"true\" />";
            listSTR += "<embed src=\"" + FlvSource + "\" allowfullscreen=\"true\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"225\" height=\"200\"></embed>";
            listSTR += "</object>";
            return listSTR;
        }




         public void ProcessRequest (HttpContext context) {
         string path = context.Server.MapPath(context.Request.QueryString[0]);
         string suffix = path.Split('.')[path.Split('.').Length-1];
         context.Response.ContentType = string.Format("image/{0}",suffix.ToLower().Equals("png")?"x-png":suffix);//设置MIME，如果是png文件，MIME信息为text/x-png
         context.Response.Expires = 60*24*30;//设置图片30天过期
         ImageFormat ift = ImageFormat.Jpeg;//设置默认文件格式
         Image img = Image.FromFile(path);
         if(suffix.ToLower().Equals("gif"))
         {
             ift = ImageFormat.Gif;
         }else if(suffix.ToLower().Equals("png"))
         {
             ift = ImageFormat.Png;
         }
         MemoryStream ms = new MemoryStream();
         img.Save(ms,ift);
         //context.Response.OutputStream.Write(ms.GetBuffer(),0,ms.Length);
　　　　　 ms.Close();
　　　　　 ms.Dispose();
　　　　　 img.Dispose();
 }


        //public IList<string> QueryFilter
        //{
        //    get
        //    {
        //        if (ViewState["NavetionNameTree"] == null)
        //        {
        //            ViewState["NavetionNameTree"] = new List<string>();
        //        }
        //        return (IList<string>)ViewState["NavetionNameTree"];
        //    }
        //    set
        //    {
        //        ViewState["NavetionNameTree"] = value;
        //    }

        //}
    }
}