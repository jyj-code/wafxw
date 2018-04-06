using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Greentown.Health.DataAccess;
using share.Model;

namespace share.UCControl
{
    public partial class NavigationMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetOmitVaryStar(true);
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }
        public void BindRepeater()
        {
            repHome.DataSource = DBHelper.GetMenuList(1);
            repHome.DataBind();
            repjy.DataSource = DBHelper.GetMenuList(2);
            repjy.DataBind();
            repwb.DataSource = DBHelper.GetMenuList(3);
            repwb.DataBind();
            repJob.DataSource = DBHelper.GetMenuList(4);
            repJob.DataBind();
            repvio.DataSource = DBHelper.GetMenuList(5);
            repvio.DataBind();
            repsec.DataSource = DBHelper.GetMenuList(6);
            repsec.DataBind();
            repinfor.DataSource = DBHelper.GetMenuList(7);
            repinfor.DataBind();
            Repmanager.DataSource = DBHelper.GetMenuList(8);
            Repmanager.DataBind();
        }
    }
}