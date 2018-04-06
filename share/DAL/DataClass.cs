using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job.DAL
{
    public class DataClass
    {
        #region dic_zhilian
        public static Dictionary<string, string> dic_zhilian = new Dictionary<string, string>();
        public static string GetDic_zhilian(string key)
        {
            if (dic_zhilian.Count <= 0)
            {
                dic_zhilian.Add("北京", "北京");
                dic_zhilian.Add("上海", "上海");
                dic_zhilian.Add("广州", "广州");
                dic_zhilian.Add("深圳", "深圳");
                dic_zhilian.Add("天津", "天津");
                dic_zhilian.Add("苏州", "苏州");
                dic_zhilian.Add("重庆", "重庆");
                dic_zhilian.Add("南京", "南京");
                dic_zhilian.Add("杭州", "杭州");
                dic_zhilian.Add("大连", "大连");
                dic_zhilian.Add("成都", "成都");
                dic_zhilian.Add("武汉", "武汉");
            }
            if (dic_zhilian.Keys.Contains(key))
                return dic_zhilian[key];
            return string.Empty;
        } 
        #endregion

        #region dic_qiancheng
        public static Dictionary<string, string> dic_qiancheng = new Dictionary<string, string>();
        public static string GetDic_qiancheng(string key)
        {
            if (dic_qiancheng.Count <= 0)
            {
                dic_qiancheng.Add("北京", "010000");
                dic_qiancheng.Add("上海", "020000");
                dic_qiancheng.Add("广州", "030200");
                dic_qiancheng.Add("深圳", "040000");
                dic_qiancheng.Add("天津", "050000");
                dic_qiancheng.Add("苏州", "070300");
                dic_qiancheng.Add("重庆", "060000");
                dic_qiancheng.Add("南京", "070200");
                dic_qiancheng.Add("杭州", "080200");
                dic_qiancheng.Add("大连", "230300");
                dic_qiancheng.Add("成都", "090200");
                dic_qiancheng.Add("武汉", "180200");
            }
            if (dic_qiancheng.Keys.Contains(key))
                return dic_qiancheng[key];
            return string.Empty;
        } 
        #endregion

        #region dic_liepin
        public static Dictionary<string, string> dic_liepin = new Dictionary<string, string>();
        public static string GetDic_liepin(string key)
        {
            if (dic_liepin.Count <= 0)
            {
                dic_liepin.Add("北京", "010");
                dic_liepin.Add("上海", "020");
                dic_liepin.Add("广州", "050020");
                dic_liepin.Add("深圳", "050090");
                dic_liepin.Add("天津", "030");
                dic_liepin.Add("苏州", "060080");
                dic_liepin.Add("重庆", "040");
                dic_liepin.Add("南京", "060020");
                dic_liepin.Add("杭州", "070020");
                dic_liepin.Add("大连", "210040");
                dic_liepin.Add("成都", "280020");
                dic_liepin.Add("武汉", "170020");
            }
            if (dic_liepin.Keys.Contains(key))
                return dic_liepin[key];
            return string.Empty;
        }  
        #endregion
    }
}
