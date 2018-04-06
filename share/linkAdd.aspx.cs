using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Greentown.Health.DataAccess;
using share.Model;

namespace share
{
    public partial class linkAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserInfo"] == null || Session["UserInfo"].ToString().ToUpper().Contains("ADMIN"))
                {
                    Tool.Alert("您未登录或您不是管理者，不能使用此功能");
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string Url = txtUrl.Text.Trim();
                if (Url.Contains("https://") || Url.Contains("www.") || Url.Contains("http://"))
                {
                    DataTable dt = DBHelper.GetDataTable("select NAME,URL,REMARK from Link");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["URL"].ToString().Contains(Url))
                        {
                            Tool.Alert("此地址【" + Url + "】已经存在，不能添加");
                            return;
                        }
                    }
                    string sql = "INSERT INTO Link(NAME,URL,REMARK)values('{0}','{1}','{2}')";
                    string remark = txtRemark.Text.Trim();
                    remark = remark.Length > 1 ? remark : "爱生活 爱分享,全在我爱分享网";
                    sql = string.Format(sql, txtName.Text.Trim(), Url, remark);
                    if (DBHelper.ExecuteCommand(sql) >0)
                    {
                        txtName.Text = "";
                        txtUrl.Text = "";
                        txtRemark.Text = "";
                        Tool.Alert("添加成功");

                    }
                    else { Tool.Alert("添加失败"); }
                }
                else
                {
                    Tool.Alert("Url不合法");
                }
            }
            catch (Exception es)
            {
                
               Tool.Alert("添加失败：【"+es.Message+"】");
            }
        }

    }
}