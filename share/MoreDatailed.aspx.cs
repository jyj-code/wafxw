using Greentown.Health.DataAccess;
using share.log4net1;
using share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace share
{
    public partial class MoreDatailed : System.Web.UI.Page
    {
        public DataTable Dt()
        {
            string sql = string.Empty;
            switch (QueryFilter)
            {
                case "全部":
                    sql = "select * from ((SELECT ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType!=N'微博')" +
                         "union all" +
                         "(SELECT ArticleID ,ArticleContent as Title,CreateDate FROM ShortArticle  WHERE ArticleType='微博')) t " +
                         "order by CreateDate desc";
                    break;
                case "微博":
                    sql = "SELECT ArticleID ,ArticleContent as Title,CreateDate FROM ShortArticle  WHERE ArticleType='微博' order by CreateDate";
                    break;
                default: sql = "SELECT ArticleID ,Title as Title,CreateDate FROM ShortArticle  WHERE ArticleType='" + QueryFilter + "' order by CreateDate";
                    break;
            }
            return DBHelper.GetDataTable(sql);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TreeLeft();
                BindView(QueryFilter);
            }
        }
        private void TreeLeft()
        {
            try
            {
                RelLeft.DataSource = GetNavetionNameTree;
                RelLeft.DataBind();
            }
            catch (Exception ss)
            {
                Tool.WritrErro(ss);
            }
        }
        private string[] GetNavetionNameTree
        {
            get
            {
                if (ViewState["NavetionNameTree"] == null)
                {
                    Dictionary<string, string> dict = DBHelper.GetName();
                    dict.Remove("发布系统");
                    dict.Remove("求职广场");
                    foreach (var item in dict)
                    {
                        if (item.Key.ToString() == "Home")
                        {
                            dict.Remove(item.Key.ToString());
                            dict.Add("全部", "全部");
                            break;
                        }
                    }
                    ViewState["NavetionNameTree"] = dict.Keys.ToArray();
                    return dict.Keys.ToArray(); ;
                }
                else
                {
                    return ViewState["NavetionNameTree"] as string[];
                }
            }

        }

        public string QueryFilter
        {
            get
            {
                if (Request.QueryString["TreeType"] != null)
                {
                    switch (Request.QueryString["TreeType"].ToString().Trim())
                    {
                        case "1": return "生活经";
                        case "2": return "职场经";
                        case "3": return "社会经";
                        case "4": return "教育经";
                        case "5": return "育儿经";
                        case "6": return "学习经";
                        case "7": return "娱乐经";
                        case "8": return "理财经";
                        case "9": return "其他经验分享";
                        case "10": return "程序员其他分享";
                        case "11": return "心得段子分享";
                        case "12": return "值得一看";
                        case "13": return "网站公告";
                        case "14": return "微博";
                        case "15": return ".NET";
                        case "16": return "JAVA";
                        case "17": return "JavaScript";
                        case "18": return "CSS";
                        case "19": return "SQLServer";
                        case "20": return "Oracle";

                        default: return "全部";
                    }

                }
                else
                {
                    return "全部";
                }
            }
        }
        protected void linkMenuLeft_Click(object sender, EventArgs e)
        {
            string TreeType = string.Empty;
            switch (((LinkButton)sender).CommandArgument.ToString().Trim())
            {
                case "生活经": TreeType = "1"; break;
                case "职场经": TreeType = "2"; break;
                case "社会经": TreeType = "3"; break;
                case "教育经": TreeType = "4"; break;
                case "育儿经": TreeType = "5"; break;
                case "学习经": TreeType = "6"; break;
                case "娱乐经": TreeType = "7"; break;
                case "理财经": TreeType = "8"; break;
                case "其他经验分享": TreeType = "9"; break;
                case "码农分享": TreeType = "10"; break;
                case "心得段子分享": TreeType = "11"; break;
                case "值得一看": TreeType = "12"; break;
                case "网站公告": TreeType = "13"; break;
                case "微博广场": TreeType = "14"; break;
                case ".NET": TreeType = "15"; break;
                case "JAVA": TreeType = "16"; break;
                case "JavaScript": TreeType = "17"; break;
                case "CSS": TreeType = "18"; break;
                case "SQLServer": TreeType = "19"; break;
                case "Oracle": TreeType = "20"; break;

                default: TreeType = "0"; break;
            }
            Response.Redirect("MoreDatailed.aspx?TreeType=" + TreeType);
        }
        ///// <summary>
        ///// 总页数
        ///// </summary>
        protected int PageCurrent { get { return Dt().Rows.Count; } }
        public void BindView(string str)
        {
            string sql = string.Empty;
            switch (QueryFilter)
            {
                case "全部" :
                    sql = "select * from ((SELECT ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType!=N'微博')" +
                         "union all" +
                         "(SELECT ArticleID ,[ArticleContent],CreateDate FROM ShortArticle  WHERE ArticleType='微博')) t " +
                         "order by CreateDate desc";
                    break;
                case "微博":
                    sql = "SELECT ArticleID ,ArticleContent as Title,CreateDate FROM ShortArticle  WHERE ArticleType='微博' order by CreateDate";
                    break;
                default: sql = "SELECT ArticleID ,Title as Title,CreateDate FROM ShortArticle  WHERE ArticleType='" + QueryFilter + "' order by CreateDate";
                    break;
            }
            int recordcount;
            DataSet ds = GetPage(sql, this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageSize, out recordcount);
            this.AspNetPager1.RecordCount = recordcount;
            this.RepContent.DataSource = ds;
            this.RepContent.DataBind();
            AspNetPager1.CustomInfoHTML = "总【" + AspNetPager1.RecordCount.ToString() +"】条</b>&nbsp;";
            AspNetPager1.CustomInfoHTML += " 共【" + AspNetPager1.PageCount.ToString() + "】页</b>&nbsp;";
            AspNetPager1.CustomInfoHTML += " 当前页：<font color=\"red\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b></font>";
            lblHEader.Text = str;
        }

        public DataSet GetPage(string sql, int currentPage, int pagesize, out int recordcount)
        {
            SqlDataAdapter ada = new SqlDataAdapter(sql, DBHelper.getConnection());
            DataSet ds = new DataSet();
            int startRow = (currentPage - 1) * pagesize;
            ada.Fill(ds, startRow, pagesize, "table");
            recordcount = PageCurrent;
            return ds;
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindView(QueryFilter);

        }
    }
}