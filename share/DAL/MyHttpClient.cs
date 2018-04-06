using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Model;

namespace Job.DAL
{
    public class MyHttpClient
    {
        #region HtmlWeb

        public static HtmlWeb htmlWeb
        {
            get
            {
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session["HtmlWeb"] == null)
                        HttpContext.Current.Session["HtmlWeb"] = new HtmlWeb();
                    return HttpContext.Current.Session["HtmlWeb"] as HtmlWeb;
                }
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 获取get请求返回的数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public void GetRequest(ref List<ZhaopinInfo> zpInfoList, string url, ZhaopinType type)
        {
            //List<ZhaopinInfo> zpInfoList = new List<ZhaopinInfo>();

            switch (type)
            {
                case ZhaopinType.猎聘网:
                    htmlWeb.OverrideEncoding = Encoding.GetEncoding("UTF-8");
                    HtmlAgilityPack.HtmlDocument response = htmlWeb.Load(url);
                    #region MyRegion
                    var ulS = response.DocumentNode.SelectNodes("//*[@id='sojob']/div[2]/div/div/ul/li");
                    foreach (var item in ulS)
                    {
                        var xpath = item.XPath;
                        string titleName, infourl, company, city, date, salary, salary_em, source;
                        titleName = item.SelectSingleNode(xpath + "/a").Attributes["title"].Value;
                        infourl = item.SelectSingleNode(xpath + "/a").Attributes["href"].Value;
                        company = item.SelectSingleNode(xpath + "/a/dl/dt[@class='company']").InnerText;
                        city = item.SelectSingleNode(xpath + "/a/dl/dt[@class='city']/span").InnerText;
                        date = item.SelectSingleNode(xpath + "/a/dl/dt[@class='date']/span").InnerText;
                        salary = item.SelectSingleNode(xpath + "/a/dl/dt[@class='salary']/span").InnerText;
                        salary_em = item.SelectSingleNode(xpath + "/a/dl/dt[@class='salary']/em").InnerText;
                        source = "猎聘网";

                        zpInfoList.Add(
                            new ZhaopinInfo()
                            {
                                city = city,
                                company = company,
                                date = date,
                                info_url = infourl,
                                salary = salary,
                                salary_em = salary_em,
                                titleName = titleName,
                                source = source
                            });
                    }
                    #endregion
                    break;
                case ZhaopinType.智联招聘:
                    htmlWeb.OverrideEncoding = Encoding.GetEncoding("UTF-8");
                    response = htmlWeb.Load(url);
                    #region MyRegion
                    ulS = response.DocumentNode.SelectNodes("//*[@id='newlist_list_content_table']/table[@class='newlist']");
                    for (int i = 1; i < ulS.Count; i++)
                    {
                        var item = ulS[i];
                        var xpath = item.XPath;
                        string titleName, infourl, company, city, date, salary, salary_em, source;
                        titleName = item.SelectSingleNode(xpath + "/tr/td[@class='zwmc']/div/a").InnerText;
                        infourl = item.SelectSingleNode(xpath + "/tr/td[@class='zwmc']/div/a").Attributes["href"].Value;
                        company = item.SelectSingleNode(xpath + "/tr/td[@class='gsmc']/a").InnerText;
                        city = item.SelectSingleNode(xpath + "/tr/td[@class='gzdd']").InnerText;
                        date = item.SelectSingleNode(xpath + "/tr/td[@class='gxsj']/span").InnerText;
                        salary = "月薪"; //item.SelectSingleNode(xpath + "/td[@class='gsmc']/a").InnerText;
                        salary_em = item.SelectSingleNode(xpath + "/tr/td[@class='zwyx']").InnerText;
                        source = "智联招聘";

                        zpInfoList.Add(
                            new ZhaopinInfo()
                            {
                                city = city,
                                company = company,
                                date = date,
                                info_url = infourl,
                                salary = salary,
                                salary_em = salary_em,
                                titleName = titleName,
                                source = source
                            });
                    }
                    #endregion
                    break;
                case ZhaopinType.前程无忧:
                    htmlWeb.OverrideEncoding = Encoding.GetEncoding("GBK");
                    response = htmlWeb.Load(url);
                    #region MyRegion
                    ulS = response.DocumentNode.SelectNodes("//*[@id='resultList']/tr[@class='tr0']");
                    for (int i = 1; i < ulS.Count; i++)
                    {
                        var item = ulS[i];
                        var xpath = item.XPath;
                        string titleName, infourl, company, city, date, salary, salary_em, source;
                        titleName = item.SelectSingleNode(xpath + "/td[@class='td1']/a").InnerText;
                        infourl = item.SelectSingleNode(xpath + "/td[@class='td1']/a").Attributes["href"].Value;
                        company = item.SelectSingleNode(xpath + "/td[@class='td2']/a").InnerText;
                        city = item.SelectSingleNode(xpath + "/td[@class='td3']/span").InnerText;
                        date = item.SelectSingleNode(xpath + "/td[@class='td4']/span").InnerText;
                        salary = "月薪"; //item.SelectSingleNode(xpath + "/td[@class='gsmc']/a").InnerText;
                        salary_em = "无";
                        source = "前程无忧";

                        zpInfoList.Add(
                            new ZhaopinInfo()
                            {
                                city = city,
                                company = company,
                                date = date,
                                info_url = infourl,
                                salary = salary,
                                salary_em = salary_em,
                                titleName = titleName,
                                source = source
                            });
                    }
                    #endregion
                    break;
                default:
                    break;
            }

            //return zpInfoList;
        }

    }
}
