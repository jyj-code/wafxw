using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using share.DAL;

namespace share
{
    public partial class Deleteshare : System.Web.UI.Page
    {
        private readonly shareService service = new shareService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string articleID = Request.QueryString["ArticleID"];
                if (string.IsNullOrWhiteSpace(articleID))
                {
                    Response.Write("参数错误");
                }
                else 
                {
                    bool bl = service.Deleteshare(Guid.Parse(articleID));
                    if (bl)
                    {
                        Response.Redirect("Index.aspx");
                    }
                    else {
                        Response.Write("DataAccess Error");
                    }
                }
            }
        }
    }
}