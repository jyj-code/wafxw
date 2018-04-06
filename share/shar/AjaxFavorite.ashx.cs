using share.DAL;
using share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace share
{
    /// <summary>
    /// AjaxFavorite 的摘要说明
    /// </summary>
    public class AjaxFavorite : IHttpHandler
    {
        shareService service = new shareService();
        public void ProcessRequest(HttpContext context)
        {
            string customerID = context.Request.QueryString["customerID"];
            string articleID = context.Request.QueryString["articleID"];
            FavoriteModel model = new FavoriteModel();
            model.ArticleID = Guid.Parse(articleID);
            model.CustomerID = Guid.Parse(customerID);
            bool bl = service.CreateFavorite(model);
            context.Response.Write(bl);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}