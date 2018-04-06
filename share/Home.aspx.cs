using System;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using Greentown.Health.DataAccess;
using share.log4net1;
using share.Model;
using System.Collections.Generic;
using System.Data;
using share.DAL;

namespace UI
{
    public partial class Home : System.Web.UI.Page
    {
        Stopwatch sw = new Stopwatch();
        public class ColGroup
        {
            /// <summary>
            /// 文章唯一编号
            /// </summary>
            public string ArticleID { get; set; }
            /// <summary>
            /// 文章标题
            /// </summary>
            public string Title { set; get; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public string CreateDate { get; set; }
            /// <summary>
            /// 文章内容
            /// </summary>
            public string ArticleContent { get; set; }
        }
        private readonly CustomerService customerService = new CustomerService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                 string nickname =string.Empty;
                 string gender = string.Empty;
                 string figureurl = string.Empty;
                if (Request.QueryString["nickname"] != null)
                {
                    var vs = Request.QueryString["nickname"].ToString();
                    for (int i = 0; i < vs.Split(';').Length; i++)
                    {
                         nickname = vs[0].ToString();
                         gender = vs[1].ToString();
                         figureurl = vs[2].ToString();
                    }
                    CustomerModel customer = new CustomerModel(); //创建用户对象
                    customer.Birthday = DateTime.Now; //设置生日 设置为空 此功能暂不开发
                    customer.CustomerName = nickname; //设置姓名
                    customer.LoginName = nickname; //设置登录名
                    customer.LoginPassword = gender; //设置密码
                    customer.Sex = gender; //设置性别
                    customer.PhotoUrl = figureurl; //用户头像 设置为空 此功能暂不开发
                    customerService.CreateCustomer(customer); //将用户信息 插入至数据库
                    Session["UserInfo"] = customer;
                }

                Response.Cache.SetOmitVaryStar(true);
                //var sss = DBHelper.GetMD5("admin");
                try
                {
                    Dbing();
                }
                catch (Exception es)
                {
                    Tool.WritrErro(es);
                }
            }

        }
        protected void AInformher_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("MoreDatailed.aspx?TreeType=13");
        }
        protected void AJobher_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("MoreDatailed.aspx?TreeType=2");
        }
        protected void AOtherher_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("MoreDatailed.aspx?TreeType=9");
        }
        void Dbing()
        {
            try
            {
                //最近更新
                RepRecentUpdates.DataSource = DBHelper.Home_DataSet_Load().Tables["Update"];
                RepRecentUpdates.DataBind();
                //网站通告
                RepInform.DataSource = DBHelper.Home_DataSet_Load().Tables["Inform"];
                RepInform.DataBind();
                //站长推荐
                repRecommend.DataSource = DBHelper.Home_DataSet_Load().Tables["Hot"];
                repRecommend.DataBind();
                //生活经
                Replife.DataSource = DBHelper.Home_DataSet_Load().Tables["Life"];
                Replife.DataBind();
                //职场经
                Repjob.DataSource = DBHelper.Home_DataSet_Load().Tables["job"];
                Repjob.DataBind();
                //社会经
                Repsociety.DataSource = DBHelper.Home_DataSet_Load().Tables["society"];
                Repsociety.DataBind();
                //教育经
                RepEducation.DataSource = DBHelper.Home_DataSet_Load().Tables["education"];
                RepEducation.DataBind();
                //育儿经
                RepParenting.DataSource = DBHelper.Home_DataSet_Load().Tables["YE"];
                RepParenting.DataBind();
                //学习经
                RepStudy.DataSource = DBHelper.Home_DataSet_Load().Tables["learn"];
                RepStudy.DataBind();
                //娱乐经
                RepRecreation.DataSource = DBHelper.Home_DataSet_Load().Tables["recreation"];
                RepRecreation.DataBind();
                //理财经
                RepMoney.DataSource = DBHelper.Home_DataSet_Load().Tables["money"];
                RepMoney.DataBind();
                //其他经验分享
                RepOther.DataSource = DBHelper.Home_DataSet_Load().Tables["SharOther"];
                RepOther.DataBind();
                //心得段子分享
                RepExperience.DataSource = DBHelper.Home_DataSet_Load().Tables["DZ"];
                RepExperience.DataBind();
                //值得一看
                RepSec.DataSource = DBHelper.Home_DataSet_Load().Tables["Sec"];
                RepSec.DataBind();
                //程序员其他分享
                RepProgrammer.DataSource = DBHelper.Home_DataSet_Load().Tables["ProcedureOther"];
                RepProgrammer.DataBind();
                //>net
                RepNet.DataSource = DBHelper.Home_DataSet_Load().Tables["NET"];
                RepNet.DataBind();
                //Java
                RepJAVA.DataSource = DBHelper.Home_DataSet_Load().Tables["JAVA"];
                RepJAVA.DataBind();
                //JavaScript
                RepJavaScript.DataSource = DBHelper.Home_DataSet_Load().Tables["JavaScript"];
                RepJavaScript.DataBind();
                //CSS
                RepCSS.DataSource = DBHelper.Home_DataSet_Load().Tables["CSS"];
                RepCSS.DataBind();
                //SQL Server
                Repsql.DataSource = DBHelper.Home_DataSet_Load().Tables["SQLServer"];
                Repsql.DataBind();
                //Oracle
                RepOracle.DataSource = DBHelper.Home_DataSet_Load().Tables["Oracle"];
                RepOracle.DataBind();
            }
            catch (Exception we)
            {
                Tool.WritrErro(we);
            }
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
        public string CheckIp()
        {
            string ip = null; string ip1 = null; string ip2 = null; string ip3 = null; string ip4 = null;
            try
            {
                ip1 = CheckIP.IsIPAddress(CheckIP.GetIP()) ? IpHelper.Get(CheckIP.GetIP().ToString(), null).Country == null ? null : CheckIP.GetIP().ToString() : null;
                ip2 = CheckIP.IsIPAddress(Page.Request.UserHostAddress) ? IpHelper.Get(Page.Request.UserHostAddress, null).Country == null ? null : Page.Request.UserHostAddress : null;
                ip3 = CheckIP.IsIPAddress(CheckIP.GetIPAddress) ? IpHelper.Get(CheckIP.GetIPAddress, null).Country == null ? null : CheckIP.GetIPAddress : null;
                ip4 = CheckIP.IsIPAddress(CheckIP.GetNetIP()) ? IpHelper.Get(CheckIP.GetNetIP(), null).Country == null ? null : CheckIP.GetNetIP() : null;
                ip = ip1 != null ? ip1 : ip2 != null ? ip2 : ip3 != null ? ip3 : ip4 != null ? ip4 : null;
            }
            catch (Exception cp)
            {
                WritrBug(System.Reflection.MethodBase.GetCurrentMethod().Name, cp.Message);
            }
            return ip;
        }
        public void GetIp()
        {
            try
            {
                string CheckIps = CheckIp();
                if (CheckIps != null && CheckIps.Length > 0)
                {
                    string sip = Session["ip"] == null ? null : Session["ip"].ToString();
                    if (sip != CheckIps)
                    {
                        string kIP = Page.Request.UserHostAddress;
                        string os = CheckIP.GetOSVersion();
                        string Brorser = CheckIP.GetBrowser();
                        IpDetail ipDetail = IpHelper.Get(CheckIps, null);
                        String Country = ipDetail.Country;
                        String Province = ipDetail.Province;
                        String City = ipDetail.City;
                        String District = ipDetail.District;
                        String Type = ipDetail.Type;
                        String Desc = ipDetail.Desc;
                        string CREATEDATE = DateTime.Now.ToString();
                        string remark = CheckIP.Get();
                        string sql = "insert into IPOPERATION(Country, Province, City, District,IsMobileDevice, kIP, os, Brorser, ip,remark,CREATEDATE) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";
                        sql = string.Format(sql, Country, Province, City, District, IsMobileDevice, kIP, os, Brorser, CheckIps, remark, CREATEDATE);
                        DBHelper.ExecuteCommand(sql);
                        Session["ip"] = CheckIps;
                    }
                }
            }
            catch (Exception saa)
            {
                Tool.WritrErro(saa);
            }
        }
        public void WritrBug(string meth, string Message)
        {
            try
            {
                string d = DateTime.Now.ToString("yyyyMM");
                string name = d + "BugLog.txt";
                string m_LogName = Server.MapPath(name);
                if (!System.IO.File.Exists(m_LogName))
                {

                    System.IO.FileStream fsnew = System.IO.File.Create(m_LogName);
                    fsnew.Close();
                }
                using (System.IO.FileStream fs = System.IO.File.Open(m_LogName, System.IO.FileMode.Append, System.IO.FileAccess.Write))
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(fs))
                    {
                        string Value = "    发生错误页面：" + HttpContext.Current.Request.Url.PathAndQuery + "    发生错误方法：" + meth + " 错误讯息：" + Message;
                        var _user = Session["username"] == null ? "用户未知" : Session["username"].ToString();
                        w.WriteLine("记录时间:{0}", DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss 开始：") + " " + "+" + CheckIP.GetIPAddress + "   " + _user + " " + Value);
                        w.Flush();
                        w.Close();
                    }
                }
            }
            catch (Exception)
            {
            }

        }
        public void WriteTxt(string value)
        {
            try
            {
                string d = DateTime.Now.ToString("yyyyMM");
                string name = d + "-logServer.txt";
                string m_LogName = Server.MapPath(name);
                if (!System.IO.File.Exists(m_LogName))
                {

                    System.IO.FileStream fsnew = System.IO.File.Create(m_LogName);
                    fsnew.Close();
                }
                using (System.IO.FileStream fs = System.IO.File.Open(m_LogName, System.IO.FileMode.Append, System.IO.FileAccess.Write))
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(fs))
                    {
                        w.WriteLine("记录时间:{0}", DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss 开始：") + value);
                        w.Flush();
                        w.Close();
                    }
                }
            }
            catch (Exception ms)
            {
                Tool.WritrErro(ms);
            }

        }
        #endregion
    }
}