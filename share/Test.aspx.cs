using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace share
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             // Cache["date"]=要缓存的数据;   这里是自定义缓存的简单声明使用
            //string datastr = Label1.Text;
            //Response.Write("第一个输出时间:" + datastr + "</br>");  //这里读取的当前的时间，刷新页面时，这里的时间会随着变化。

            //if (Cache["date"] == null) //判断是否存在value值为date的缓存是否存在
            //{
            //    Cache["date"] = datastr;
            //    Response.Write("第二个输出时间为：" + Cache["date"] + "这里读取的当前的时间");   //这里读取的当前的时间，刷新页面时，这里的时间会随着变化。
            //}
            //else
            //{
            //    Response.Write(Cache["date"] + "这里是从缓存中读取的时间");//这里读取的缓存中的时间，刷新页面时，这里的随着时间变化，不会变化。
            //}


            string ids = Label1.Text;
            ids = ids + "完";  //这里的ids为从数据库中读取表中的id值然后用--链接起来的一个字符串
            if (Cache["key"] == null)
            {
                Cache.Insert("key", ids, null, DateTime.Now.AddSeconds(10), System.Web.Caching.Cache.NoSlidingExpiration);  //这里给数据加缓存，设置缓存时间
                //"key"为缓存的键，ids为缓存起来的值,null为缓存依赖项，这里没有使用缓存依赖项，所以为null，下面会详细介绍缓存依赖项
                //null后面为缓存的时间为40秒
                //最后一个参数为设置时间的格式，ASP.NET允许你设置一个绝对过期时间或滑动过期时间，但不能同时使用，
                //我们这里设置的为绝对过期时间，也就是没刷新一次页面后缓存数据为40秒，40秒后会从数据库中重新获取。 
                Response.Write("cache加载为---" + Cache["key"] + "</br>");
            }
            else
            {
                Response.Write("cache加载为---" + Cache["key"] + "</br>");
            }
            Response.Write("直接加载为---" + ids + "</br>");


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text += 1;
        }
    }
}