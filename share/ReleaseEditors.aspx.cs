using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Greentown.Health.DataAccess;
using share.DAL;
using share.log4net1;
using share.Model;

namespace share
{
    public partial class ReleaseEditors : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserInfo"] == null)
                    {
                        Response.Write("<script>alert('您未登录,正在为您跳转登录界面');window.location='Login.aspx';</script>");
                    }
                    Initializa();
                }
            }
            catch (Exception es)
            {
                Tool.WritrErro(es);
            }
        }
        shareService service = new shareService();
        private void Initializa()
        {
            try
            {
                lblName.Visible = false;
                lblName.Text = "";
                txtTitle.Visible = false;
                drpType.DataSource = DBHelper.GetName();
                drpType.DataValueField = "Key";
                drpType.DataTextField = "Key";
                drpType.DataBind();
                drpType.Items.Insert(0, "---请选择发布栏目-----");
                drpType.Items.Remove("Home");
                drpType.Items.Remove("求职广场");
                drpType.Items.Remove("微博广场");
                drpType.Items.Remove("发布系统");
            }
            catch (Exception ss)
            {
                Tool.WritrErro(ss);
            }
        }
        protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblName.Visible = true;
            txtTitle.Visible = true;
        }
        public static void ShowWindows(System.Web.UI.Control controlName, string title, int width, int height, string showID)
        {
            string cc = "px";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(controlName, typeof(System.Web.UI.UpdatePanel), "", "layer.open({type:1,title: '" + title + "',skin: 'layui-layer-rim',area:['" + width + cc + "','" + height + cc + "'],content:$('#" + showID + "')});", true);
        }
        protected void drpType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string a = drpType.Text.ToString();
                if (drpType.Text.ToString().Contains("---请选择发布栏目-----"))
                {
                    lblName.Visible = false;
                    txtTitle.Visible = false;
                }
                else
                {
                    lblName.Visible = true;
                    txtTitle.Visible = true;
                    lblName.Text = drpType.Text.ToString();
                }
            }
            catch (Exception ds)
            {
                Tool.WritrErro(ds);
            }
        }
        protected void btnRelease_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(HidContent.Value.Trim()))
                {
                    Tool.Alert("发布内容不可为空!"); return;
                }
                if (string.IsNullOrEmpty(lblName.Text.Trim()))
                {
                    Tool.Alert("请选择发布栏目!"); return;
                }
                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    Tool.Alert("请选择发布标题!"); return;
                }
                CustomerModel customer = Session["UserInfo"] as CustomerModel;
                shareModel model = new shareModel(); //创建文字对象
                model.CustomerID = customer.CustomerID; //文字发布人设置为当前登录用户
                model.ArticleContent = HidContent.Value.Trim();
                model.ArticleType = lblName.Text.Trim();
                model.Title = txtTitle.Text.Trim();
                bool bl = service.CreateArea(model, lblName.Text); //提交至数据库
                if (bl)
                {
                    //var CloseWebPage = "<script language='javascript' type='text/javascript'> CloseWebPage()</script>";
                    //Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "CloseWebPage", CloseWebPage);
                    Tool.Alert("发布成功");
                    txtTitle.Text = null;
                }
                else
                {
                    Tool.Alert("发布失败,请重试");
                }
            }
            catch (Exception r)
            {
                Tool.WritrErro(r);
                Tool.Alert("发布失败,错误讯息【" + r.Message + "】");
            }
        }
    }
}