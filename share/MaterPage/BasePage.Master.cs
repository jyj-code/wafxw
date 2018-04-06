using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Greentown.Health.DataAccess;

namespace UI.MaterPage
{
    public partial class BasePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //<% Response.Expires = 10;%>
        }
        public string keywords { get { return DBHelper.GetMeta("keywords"); } }
        public string description { get { return DBHelper.GetMeta("description"); } }
        public string author { get { return DBHelper.GetMeta("author"); } }
        public string copyright { get { return DBHelper.GetMeta("copyright"); } }
    }
}