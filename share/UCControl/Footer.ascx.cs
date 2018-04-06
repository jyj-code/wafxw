using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Greentown.Health.DataAccess;

namespace UI.UCControl
{
    public partial class Footer1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetOmitVaryStar(true);
            RepFootLinks.DataSource = DBHelper.GetDataTable("select NAME,URL,REMARK from Link");
            RepFootLinks.DataBind();
        }
    }
}