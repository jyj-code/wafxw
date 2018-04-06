using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace share.job
{
    public partial class job : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region 日志模块
        public string IsMobileDevice
        {
            get
            {
                System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
                return ((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice ? "MD" : "PC";
            }
        }
        //public string CheckIp()
        //{
        //    string ip = null; string ip1 = null; string ip2 = null; string ip3 = null; string ip4 = null;
        //    try
        //    {
        //        ip1 = CheckIP.IsIPAddress(CheckIP.GetIP()) ? IpHelper.Get(CheckIP.GetIP().ToString(), null).Country == null ? null : CheckIP.GetIP().ToString() : null;
        //        ip2 = CheckIP.IsIPAddress(Page.Request.UserHostAddress) ? IpHelper.Get(Page.Request.UserHostAddress, null).Country == null ? null : Page.Request.UserHostAddress : null;
        //        ip3 = CheckIP.IsIPAddress(CheckIP.GetIPAddress) ? IpHelper.Get(CheckIP.GetIPAddress, null).Country == null ? null : CheckIP.GetIPAddress : null;
        //        ip4 = CheckIP.IsIPAddress(CheckIP.GetNetIP()) ? IpHelper.Get(CheckIP.GetNetIP(), null).Country == null ? null : CheckIP.GetNetIP() : null;
        //        ip = ip1 != null ? ip1 : ip2 != null ? ip2 : ip3 != null ? ip3 : ip4 != null ? ip4 : null;
        //    }
        //    catch (Exception cp)
        //    {
        //        WritrBug(System.Reflection.MethodBase.GetCurrentMethod().Name, cp.Message);
        //    }
        //    return ip;
        //}
        //public void GetIp()
        //{
        //    try
        //    {
        //        if (CheckIp() != null && CheckIp().Length > 0)
        //        {
        //            string sip = Session["ip"] == null ? null : Session["ip"].ToString();
        //            if (sip != CheckIp())
        //            {
        //                string Address = null;
        //                string USER = Page.User.ToString();
        //                string Comput = System.Net.Dns.GetHostName();
        //                string kIP = Page.Request.UserHostAddress;
        //                string os = CheckIP.GetOSVersion();
        //                string Brorser = CheckIP.GetBrowser();
        //                IpDetail ipDetail = IpHelper.Get(CheckIp(), null);
        //                String Country = ipDetail.Country;
        //                String Province = ipDetail.Province;
        //                String City = ipDetail.City;
        //                String District = ipDetail.District;
        //                String Ret = ipDetail.Ret;
        //                String Start = ipDetail.Start;
        //                String Ends = ipDetail.End;
        //                String Isp = ipDetail.Isp;
        //                String Type = ipDetail.Type;
        //                String Desc = ipDetail.Desc;
        //                string CREATEDATE = DateTime.Now.ToString();
        //                string remark = CheckIP.Get();
        //                string sql = "insert into IPOPERATION(Country, Province, City, District,IsMobileDevice, Comput, kIP, os, Brorser, ip,Ret, Start,Ends, Isp,USERS,remark,CREATEDATE) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')";
        //                sql = string.Format(sql, Country, Province, City, District, IsMobileDevice, Comput, kIP, os, Brorser, CheckIp(), Ret, Start, Ends, Isp, USER, remark, CREATEDATE);
        //                Tools.Insert(sql);
        //                Address = Country + Province + City + District;
        //                Address += " " + IsMobileDevice + "    " + kIP + "    游览器：" + Brorser + " 系统：" + os + "    " + CheckIp() + "  " + CheckIP.Get();
        //                WriteTxt(Address);
        //                Session["ip"] = CheckIp();
        //            }
        //        }
        //    }
        //    catch (Exception saa)
        //    {
        //        WritrBug(System.Reflection.MethodBase.GetCurrentMethod().Name, saa.Message);
        //    }
        //}
        //public void WritrBug(string meth, string Message)
        //{
        //    try
        //    {
        //        string d = DateTime.Now.ToString("yyyyMM");
        //        string name = d + "BugLog.txt";
        //        string m_LogName = Server.MapPath(name);
        //        if (!System.IO.File.Exists(m_LogName))
        //        {

        //            System.IO.FileStream fsnew = System.IO.File.Create(m_LogName);
        //            fsnew.Close();
        //        }
        //        using (System.IO.FileStream fs = System.IO.File.Open(m_LogName, System.IO.FileMode.Append, System.IO.FileAccess.Write))
        //        {
        //            using (System.IO.StreamWriter w = new System.IO.StreamWriter(fs))
        //            {
        //                string Value = "    发生错误页面：" + HttpContext.Current.Request.Url.PathAndQuery + "    发生错误方法：" + meth + " 错误讯息：" + Message;
        //                var _user = Session["username"] == null ? "用户未知" : Session["username"].ToString();
        //                w.WriteLine("记录时间:{0}", DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss 开始：") + " " + "+" + CheckIP.GetIPAddress + "   " + _user + " " + Value);
        //                w.Flush();
        //                w.Close();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}
        //public void WriteTxt(string value)
        //{
        //    try
        //    {
        //        string d = DateTime.Now.ToString("yyyyMM");
        //        string name = d + "-logServer.txt";
        //        string m_LogName = Server.MapPath(name);
        //        if (!System.IO.File.Exists(m_LogName))
        //        {

        //            System.IO.FileStream fsnew = System.IO.File.Create(m_LogName);
        //            fsnew.Close();
        //        }
        //        using (System.IO.FileStream fs = System.IO.File.Open(m_LogName, System.IO.FileMode.Append, System.IO.FileAccess.Write))
        //        {
        //            using (System.IO.StreamWriter w = new System.IO.StreamWriter(fs))
        //            {
        //                w.WriteLine("记录时间:{0}", DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss 开始：") + value);
        //                w.Flush();
        //                w.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ms)
        //    {
        //        WritrBug(System.Reflection.MethodBase.GetCurrentMethod().Name, ms.Message);
        //    }

        //}
        #endregion
    }
}