using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace share.Model
{
    public class QQOAuth
    {
        public static string appid = "101272516";//换成你自己的
        public static string appkey = "fe74c85c25b6c397a9997281182879e3";
        public static string questadd = "http://openapi.qzone.qq.com/oauth/qzoneoauth_request_token";

        /// <summary>
        /// 请求临时的Token
        /// </summary>
        /// <returns></returns>
        public static string GetTempToken()
        {
            string myrandomnum = oauthnonce(); //随机数
            string unixtime = GenerateTimeStamp();//时间戳
            string token_parameter = "oauth_consumer_key=" + appid + "&oauth_nonce=" + myrandomnum + "&oauth_signature_method=HMAC-SHA1&oauth_timestamp=" + unixtime + "&oauth_version=1.0";
            string code_token_parameter = "GET&" + Uri.EscapeDataString(questadd) + "&" + Uri.EscapeDataString(token_parameter);
            string miyuetemp = appkey + "&";
            string signvl = ToBase64hmac(code_token_parameter, miyuetemp);
            string url = string.Format("{0}?{1}{2}{3}", questadd, token_parameter, "&oauth_signature=", Uri.EscapeDataString(signvl));
            string QQreturnstr = RequestUrl(url);
            return QQreturnstr;
        }


        /// <summary>
        /// 请求ACCESS的Token
        /// </summary>
        /// <param name="oauth_token">获得授权临时Token的时候获得的参数</param>
        /// <param name="oauth_vericode">获得授权临时Token的时候获得的验证代码</param>
        /// <param name="oauth_token_secret">获得授权临时Token的时候获得的密钥</param>
        /// <returns>返回ACCess Token</returns>
        public static string GetAccessToken(string oauth_token, string oauth_vericode, string oauth_token_secret)
        {
            string thisquestadd = "http://openapi.qzone.qq.com/oauth/qzoneoauth_access_token";
            string myrandomnum = oauthnonce(); //随机数
            string unixtime = GenerateTimeStamp();//时间戳
            string token_parameter = "oauth_consumer_key=" + appid + "&oauth_nonce=" + myrandomnum + "&oauth_signature_method=HMAC-SHA1&oauth_timestamp=" + unixtime + "&oauth_token=" + oauth_token + "&oauth_vericode=" + oauth_vericode + "&oauth_version=1.0";
            string code_token_parameter = "GET&" + Uri.EscapeDataString(thisquestadd) + "&" + Uri.EscapeDataString(token_parameter);
            string miyuetemp = appkey + "&" + oauth_token_secret;
            string signvl = ToBase64hmac(code_token_parameter, miyuetemp);
            string url = string.Format("{0}?{1}{2}{3}", thisquestadd, token_parameter, "&oauth_signature=", Uri.EscapeDataString(signvl));
            string QQreturnstr = RequestUrl(url);
            return QQreturnstr;
        }

        /// <summary>
        /// 获得用户信息的API
        /// </summary>
        /// <param name="oauth_token">Access token 请求是返回的</param>
        /// <param name="openid">Access token 请求是返回的 openid</param>
        /// <param name="oauth_token_secret">Access token 请求是返回的动态密钥</param>
        /// <returns>XML</returns>
        public static string GetQQUserInfo(string oauth_token, string openid, string oauth_token_secret)
        {
            string thisquestadd = "http://openapi.qzone.qq.com/user/get_user_info";
            string myrandomnum = oauthnonce(); //随机数
            string unixtime = GenerateTimeStamp();//时间戳
            string token_parameter = "format=xml&oauth_consumer_key=" + appid + "&oauth_nonce=" + myrandomnum + "&oauth_signature_method=HMAC-SHA1&oauth_timestamp=" + unixtime + "&oauth_token=" + oauth_token + "&oauth_version=1.0&openid=" + openid;
            string code_token_parameter = "GET&" + Uri.EscapeDataString(thisquestadd) + "&" + Uri.EscapeDataString(token_parameter);
            string miyuetemp = appkey + "&" + oauth_token_secret;
            string signvl = ToBase64hmac(code_token_parameter, miyuetemp);
            string url = string.Format("{0}?{1}{2}{3}", thisquestadd, token_parameter, "&oauth_signature=", Uri.EscapeDataString(signvl));
            string QQreturnstr = RequestUrl(url);
            return QQreturnstr;
        }





        #region 服务方法

        /// <summary>
        /// hmacSha1算法加密并返回ToBase64String
        /// </summary>
        /// <param name="strText">签名参数字符串</param>
        /// <param name="strKey">密钥</param>
        /// <returns>返回一个签名参数值</returns>
        public static string ToBase64hmac(string strText, string strKey)
        {
            HMACSHA1 myHMACSHA1 = new HMACSHA1(Encoding.UTF8.GetBytes(strKey));
            byte[] byteText = myHMACSHA1.ComputeHash(Encoding.UTF8.GetBytes(strText));
            return System.Convert.ToBase64String(byteText);
        }

        /// <summary>
        /// 请求指定url地址并返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RequestUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 3;
            request.Timeout = 0x2710;
            Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string str = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            return str;
        }

        /// <summary>
        /// Base64编码,此方法的功能同方法ToBase64hmac
        /// 目前内有使用该方法
        /// </summary>
        /// <returns></returns>
        public static string HMACSHA1(string consumer_secret, string oauth_token_secret, string signaturebasestring)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(consumer_secret + "&" + oauth_token_secret);
            byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(signaturebasestring);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            string signature = Convert.ToBase64String(hashBytes);
            return signature;
        }

        /// <summary>
        /// 时间戳返回unix时间戳
        /// </summary>
        /// <returns></returns>
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 随机字符串 
        /// </summary>
        /// <returns></returns>
        public static string oauthnonce()
        {
            int number;
            string checkCode = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                number = random.Next(0, 9);

                checkCode += number.ToString();
            }
            return checkCode;

        }

        /// <summary>
        /// 将认证获得的参数简单转化为哈希表
        /// </summary>
        /// <param name="varstr">获得参数的字符串</param>
        /// <returns></returns>
        public static Hashtable Str2Hash(string varstr)
        {
            Hashtable myhash = new Hashtable();
            if (varstr.Trim() != string.Empty)
            {
                string[] temparr = varstr.Split('&');
                foreach (string onevarstr in temparr)
                {
                    string[] onevararr = onevarstr.Split('=');
                    myhash.Add(onevararr[0], onevararr[1]);
                }
                return myhash;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}