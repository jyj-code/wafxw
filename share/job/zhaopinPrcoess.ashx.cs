using UI.job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Job.DAL;

namespace UI.job
{
    /// <summary>
    /// zhaopinPrcoess 的摘要说明
    /// </summary>
    public class zhaopinPrcoess : HttpHandlerBase, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string _result = string.Empty;
            base.InitPostData(context);
            switch (base.OperationCMD)
            {
                //
                case "GETZHAOPININFO":
                    _result = GetZhaoPinInfo(dicData);
                    break;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(_result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string GetZhaoPinInfo(Dictionary<string, Dictionary<string, string>> dicData)
        {
            Dictionary<string, string> dic = dicData["sub"];
            Dictionary<string, string> dic_obj = dicData["obj"];
            var key = ".net";
            if (dic.Keys.Contains("inp_key"))
                key = string.IsNullOrEmpty(dic["inp_key"]) ? key : dic["inp_key"];
            var city = "上海";
            if (dic.Keys.Contains("sel_city"))
                city = string.IsNullOrEmpty(dic["sel_city"]) ? city : dic["sel_city"];
            var index = "1";
            if (dic_obj.Keys.Contains("index"))
                index = string.IsNullOrEmpty(dic_obj["index"]) ? city : dic_obj["index"];

            var chk_zhilian = "False";
            if (dic.Keys.Contains("chk_zhilian"))
                chk_zhilian = string.IsNullOrEmpty(dic["chk_zhilian"]) ? city : dic["chk_zhilian"];
            var chk_liepin = "False";
            if (dic.Keys.Contains("chk_liepin"))
                chk_liepin = string.IsNullOrEmpty(dic["chk_liepin"]) ? city : dic["chk_liepin"];
            var chk_qiancheng = "False";
            if (dic.Keys.Contains("chk_qiancheng"))
                chk_qiancheng = string.IsNullOrEmpty(dic["chk_qiancheng"]) ? city : dic["chk_qiancheng"];

            var city_liepin = DataClass.GetDic_liepin(city);
            var city_qiancheng = DataClass.GetDic_qiancheng(city);
            var city_zhilian = DataClass.GetDic_zhilian(city);

            string url_智联招聘 = string.Format("http://sou.zhaopin.com/jobs/searchresult.ashx?jl={0}&kw={1}&p={2}", city_zhilian, key, index);
            string url_猎聘网 = string.Format("http://www.liepin.com/zhaopin/?key={0}&dqs={1}&curPage={2}", key, city_liepin, index);
            string url_前程无忧 = string.Format("http://search.51com/jobsearch/search_result.php?jobarea={0}&keyword={1}&curr_page={2}", city_qiancheng, key, index);

            List<ZhaopinInfo> zpInfoList = new List<ZhaopinInfo>();
            MyHttpClient client = new MyHttpClient();
            try
            {
                if (chk_zhilian == "True")
                    client.GetRequest(ref zpInfoList, url_智联招聘, ZhaopinType.智联招聘);
                if (chk_liepin == "True")
                    client.GetRequest(ref zpInfoList, url_猎聘网, ZhaopinType.猎聘网);
                if (chk_qiancheng == "True")
                    client.GetRequest(ref zpInfoList, url_前程无忧, ZhaopinType.前程无忧);
            }
            catch (Exception)
            { }

            return zpInfoList.ToJson();
        }
    }
}