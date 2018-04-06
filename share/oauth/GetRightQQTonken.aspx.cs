using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using share.Model;
namespace share.oauth
{
    public partial class GetRightQQTonken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //QQOAuth QQOAuth = new QQOAuth();
            if (Request.QueryString["oauth_token"] != null)
            {
                string oauth_token = Request.QueryString["oauth_token"].Trim();
                string oauth_vericode = Request.QueryString["oauth_vericode"].Trim();
                string accesstokenstr = QQOAuth.GetAccessToken(oauth_token, oauth_vericode, Session["oauth_token_secret"].ToString());
                if (accesstokenstr.IndexOf("error_code") < 0)
                {
                    Hashtable myvar = QQOAuth.Str2Hash(accesstokenstr);
                    Session["oauth_token_secret"] = myvar["oauth_token_secret"].ToString();
                    string usernickname = "QQ用户";
                    #region 通过API获得用户的昵称，存储到变量usernick中
                    string xmlstr = QQOAuth.GetQQUserInfo(myvar["oauth_token"].ToString(), myvar["openid"].ToString(), Session["oauth_token_secret"].ToString());
                    DataSet dsxml = new DataSet();
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlstr));
                    dsxml.ReadXml(ms, XmlReadMode.InferSchema);
                    foreach (DataRow dr in dsxml.Tables[0].Rows)
                    {
                        if (dr["ret"].ToString() == "0")
                        {
                            usernickname = dr["nickname"].ToString();
                        }
                    }



                    #endregion
                    //绑定帐户
                    //if (JVBox.DAL.AD_MyHandCode.Exists(myvar["openid"].ToString()))
                    //{
                    //    #region 账号已经存在自动登陆
                    //    DataSet ds = JVBox.DAL.AD_MyHandCode.LoginData(myvar["openid"].ToString(), myvar["openid"].ToString());
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        JVBoxAppCode.Session.Add("UserName", ds.Tables[0].Rows[0]["username"].ToString(), 120);
                    //        JVBoxAppCode.Session.Add("UserId", ds.Tables[0].Rows[0]["userid"].ToString(), 120);
                    //        JVBoxAppCode.Session.Add("NickName", ds.Tables[0].Rows[0]["NickName"].ToString(), 120);
                    //        Response.Redirect("../index.aspx");
                    //    }
                    //    #endregion
                    //}
                    //else
                    //{
                    //    #region 绑定注册 并且自动登录不存在就绑定
                    //    JVBox.DAL.SYS_SystemUsers dal = new JVBox.DAL.SYS_SystemUsers();
                    //    JVBox.Model.SYS_SystemUsers mod = new JVBox.Model.SYS_SystemUsers();
                    //    mod.UserName = myvar["openid"].ToString();
                    //    mod.PassWord = myvar["openid"].ToString();
                    //    mod.Email = "";
                    //    mod.Integral = 1;
                    //    mod.Address = "";
                    //    mod.HisMoney = 10;
                    //    mod.IsLocked = false;
                    //    mod.Mobile = "";
                    //    mod.NickName = usernickname;
                    //    mod.OrgId = 1;
                    //    mod.RealName = "";
                    //    mod.Status = 1;
                    //    mod.LastLoginIp = IPHelp.ClientIP;
                    //    mod.LastLoginTime = DateTime.Now.ToString();
                    //    mod.RegTime = DateTime.Now;
                    //    mod.Status = 1;
                    //    int vl = dal.Add(mod);
                    //    if (vl > 0)
                    //    {
                    //        DataSet ds = JVBox.DAL.AD_MyHandCode.LoginData(myvar["openid"].ToString(), myvar["openid"].ToString());
                    //        if (ds.Tables[0].Rows.Count > 0)
                    //        {
                    //            JVBoxAppCode.Session.Add("UserName", ds.Tables[0].Rows[0]["username"].ToString(), 120);
                    //            JVBoxAppCode.Session.Add("UserId", ds.Tables[0].Rows[0]["userid"].ToString(), 120);
                    //            JVBoxAppCode.Session.Add("NickName", ds.Tables[0].Rows[0]["NickName"].ToString(), 120);
                    //            Response.Redirect("../index.aspx");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        JScript.Alert("帮定帐号失败", this.Page);
                    //    }
                    //    #endregion
                    //}
                }
            }
        }
    }
}