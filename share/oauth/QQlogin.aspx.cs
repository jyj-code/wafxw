using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using share.Model;
public partial class oauth_QQlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string QQreturnstr = QQOAuth.GetTempToken();
        if (QQreturnstr.IndexOf("error_code") < 0)
        {
            //获得临时令牌成功
           string[] temps= QQreturnstr.Split('&','=');
           Session["oauth_token_secret"] = temps[3];
           Response.Redirect("https://graph.qq.com/user/get_user_info?oauth_consumer_key=" + QQOAuth.appid + "&oauth_token=" + temps[1] + "&oauth_callback=http://www.wafxw.cn/oauth/GetRightQQTonken.aspx");
        }
    }


    

}
