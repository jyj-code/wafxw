using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Threading;
using share.log4net1;
using share.Model;
using System.Web;
using System.Security.Cryptography;

namespace Greentown.Health.DataAccess
{
    public static class DBHelper
    {

        public static Dictionary<Thread, SqlConnection> _cache = new Dictionary<Thread, SqlConnection>();
        //public static string connectionString = _str;
        public static string connectionString
        {
            get
            {
                string Id = System.Configuration.ConfigurationManager.AppSettings["keys"].ToString();
                Id = Id.Replace("http://mmmxa.com/=", "Id=");
                string pwd = System.Configuration.ConfigurationManager.AppSettings["vlues"].ToString();
                string str = string.Format("Data Source=.;Initial Catalog=lr;User Id={0};Password={1};Integrated Security=True", Id, pwd);
                return str;
            }
        }
        public static SqlConnection getConnection()
        {
            SqlConnection connection = null;

            _cache.TryGetValue(Thread.CurrentThread, out connection);

            if (connection == null)
            {
                connection = new SqlConnection(connectionString);//建立数据库连接
                _cache.Add(Thread.CurrentThread, connection);
                return connection;
            }
            else if (connection.State == System.Data.ConnectionState.Closed)
            {
                return connection;
            }
            else if (connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Close();
                return connection;
            }

            System.Diagnostics.Trace.WriteLine(_cache.Count);

            expungeStaleEntry();

            //说明连接存在而且是open的
            return connection;
        }
        public static string GetMD5(string str)
        {
            //if (string.IsNullOrEmpty(str))
            //    return string.Empty;
            //var Password = "mmmmxa.com" + str + "wafxw.cn";
            //byte[] result = Encoding.Default.GetBytes(Password);
            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] output = md5.ComputeHash(result);
            //return BitConverter.ToString(output).Replace("-", "");
            return str;
        }
        private static void expungeStaleEntry()
        {
            List<Thread> deadKeys = new List<Thread>();

            foreach (KeyValuePair<Thread, SqlConnection> kvp in _cache)
                if (kvp.Key.IsAlive == false)
                    deadKeys.Add(kvp.Key);

            foreach (Thread key in deadKeys)
                _cache.Remove(key);
        }

        public static void closeConnection(SqlConnection connection)
        {
            if (null != connection)
                connection.Close();
        }

        public static bool isConnectionOpen(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 利用sql语句查询数据集
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "table");

            if (lastState == false)
                conn.Close();
            return ds.Tables["table"];
        }
        public static DataSet Home_DataSet_Load()
        {
            DataSet ds = new DataSet();
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            SqlDataAdapter da;
            if (lastState == false)
                conn.Open();
            #region SQL
            string Oracle = "SELECT TOP 25 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='Oracle' order by CreateDate desc";
            string SQLServer = "SELECT TOP 20 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='SQLServer' order by CreateDate desc";
            string CSS = "SELECT TOP 20 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='CSS' order by CreateDate desc";
            string JavaScript = "SELECT TOP 20 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='JavaScript' order by CreateDate desc";
            string JAVA = "SELECT TOP 20 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='JAVA' order by CreateDate desc";
            string NET = "SELECT TOP 25 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='.NET' order by CreateDate desc";
            string ProcedureOther = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='程序员其他分享' order by CreateDate desc";
            string Sec = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='值得一看' order by CreateDate desc";
            string DZ = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='心得段子分享' order by CreateDate desc";
            string SharOther = "SELECT TOP 100 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='其他经验分享' order by CreateDate desc";
            string money = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='理财经' order by CreateDate desc";
            string recreation = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='娱乐经' order by CreateDate desc";
            string learn = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='学习经' order by CreateDate desc";
            string YE = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='育儿经' order by CreateDate desc";
            string education = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='教育经' order by CreateDate desc";
            string society = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='社会经' order by CreateDate desc";
            string job = "SELECT TOP 100 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='职场经' order by CreateDate desc";
            string Life = "SELECT TOP 5 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='生活经' order by CreateDate desc";
            string Hot = "SELECT top 11 count(a.ArticleID) counts,a.ArticleID,b.ArticleContent,b.CreateDate from ArticleLike a join ShortArticle b on a.ArticleID=b.ArticleID  WHERE ArticleType='微博' group by a.ArticleID,b.ArticleContent,b.CreateDate order by counts desc";
            string Inform = "SELECT TOP 100 ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType='网站公告' order by CreateDate";
            string Update = "select top 23  t.* from ((SELECT ArticleID ,Title,CreateDate FROM ShortArticle  WHERE ArticleType!=N'微博' and ArticleType!=N'网站公告' )" +
                        "union all" +
                        "(SELECT ArticleID ,ArticleContent as Title,CreateDate FROM ShortArticle  WHERE ArticleType='微博')) t " +
                        "order by CreateDate desc"; 
            #endregion
            #region 写入DaTaSet
            da = new SqlDataAdapter(Oracle, conn);
            da.Fill(ds, "Oracle");
            da = new SqlDataAdapter(SQLServer, conn);
            da.Fill(ds, "SQLServer");
            da = new SqlDataAdapter(CSS, conn);
            da.Fill(ds, "CSS");
            da = new SqlDataAdapter(JavaScript, conn);
            da.Fill(ds, "JavaScript");
            da = new SqlDataAdapter(JAVA, conn);
            da.Fill(ds, "JAVA");
            da = new SqlDataAdapter(NET, conn);
            da.Fill(ds, "NET");
            da = new SqlDataAdapter(ProcedureOther, conn);
            da.Fill(ds, "ProcedureOther");
            da = new SqlDataAdapter(Sec, conn);
            da.Fill(ds, "Sec");
            da = new SqlDataAdapter(DZ, conn);
            da.Fill(ds, "DZ");
            da = new SqlDataAdapter(SharOther, conn);
            da.Fill(ds, "SharOther");
            da = new SqlDataAdapter(money, conn);
            da.Fill(ds, "money");
            da = new SqlDataAdapter(recreation, conn);
            da.Fill(ds, "recreation");
            da = new SqlDataAdapter(learn, conn);
            da.Fill(ds, "learn");
            da = new SqlDataAdapter(YE, conn);
            da.Fill(ds, "YE");
            da = new SqlDataAdapter(education, conn);
            da.Fill(ds, "education");
            da = new SqlDataAdapter(society, conn);
            da.Fill(ds, "society");
            da = new SqlDataAdapter(job, conn);
            da.Fill(ds, "job");
            da = new SqlDataAdapter(Life, conn);
            da.Fill(ds, "Life");
            da = new SqlDataAdapter(Hot, conn);
            da.Fill(ds, "Hot");
            da = new SqlDataAdapter(Inform, conn);
            da.Fill(ds, "Inform");
            da = new SqlDataAdapter(Update, conn);
            da.Fill(ds, "Update"); 
            #endregion
            if (lastState == false)
                conn.Close();
            return ds;
        }
        public static DataTable GetDataSet(string sql)
        {
            SqlConnection conn = getConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "table");
            conn.Close();
            return ds.Tables["table"];
        }

        /// <summary>
        /// 获取dataSet 适合多条sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDateTables(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "table");

            if (lastState == false)
                conn.Close();
            return ds;
        }

        /// <summary>
        /// 利用sql语句和参数查询数据集
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddRange(values);
            da.Fill(ds);

            if (lastState == false)
                conn.Close();
            return ds.Tables[0];
        }
        /// <summary>
        /// 利用sql语句执行增、删、改操作
        /// </summary>
        public static int ExecuteCommand(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int num = (int)cmd.ExecuteNonQuery();

            if (lastState == false)
                conn.Close();
            return num;
        }

        /// <summary>
        /// 利用sql语句执行增、删、改操作
        /// </summary>
        public static int saveReturnWithPK(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            //sql += " ; select @@identity";
            sql += " ; select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int num = Convert.ToInt32(cmd.ExecuteScalar());


            if (lastState == false)
                conn.Close();
            return num;
        }

        /// <summary>
        /// 利用sql语句获取主键ID,不加SCOPE_IDENTITY
        /// </summary>
        public static int saveReturnWithPK_NoAppending(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int num = Convert.ToInt32(cmd.ExecuteScalar());

            if (lastState == false)
                conn.Close();
            return num;
        }
        /// <summary>
        /// 执行带参数的增、删、改操作
        /// </summary>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {

            SqlConnection conn = getConnection();
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(values);
            int num = (int)cmd.ExecuteNonQuery();

            if (lastState == false)
                conn.Close();
            return num;
        }
        /// <summary>
        /// 利用存储过程执行增、删、改操作
        /// </summary>
        public static int ExecuteCommand(params SqlParameter[] values)
        {

            SqlConnection conn = getConnection();
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "";//存储过程的名字
            cmd.Parameters.AddRange(values);
            int num = (int)cmd.ExecuteNonQuery();

            if (lastState == false)
                conn.Close();
            return num;
        }

        /// <summary>
        /// 利用存储过程执行增、删、改操作
        /// </summary>
        public static int ExecuteProCommand(string proName, SqlParameter[] values)
        {

            SqlConnection conn = getConnection();
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proName;//存储过程的名字
            cmd.Parameters.AddRange(values);
            int num = (int)cmd.ExecuteNonQuery();

            if (lastState == false)
                conn.Close();
            return num;
        }


        /// <summary>
        /// 查询单个数据（首行首列）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetObjScaler(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            object obj = cmd.ExecuteScalar();

            if (lastState == false)
                conn.Close();
            return obj;
        }

        public static int GetScaler(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            int a = Convert.ToInt32(cmd.ExecuteScalar());

            if (lastState == false)
                conn.Close();
            return a;
        }
        public static object GetObjScaler(string sql, params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(values);
            object obj = cmd.ExecuteScalar();

            if (lastState == false)
                conn.Close();
            return obj;
        }


        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetScaler(string sql, params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(values);
            int a = Convert.ToInt32(cmd.ExecuteScalar());

            if (lastState == false)
                conn.Close();
            return a;
        }

        /// <summary>
        /// 利用存储过程来查询单个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetScaler(params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "";//需要调用的存储过程名称
            cmd.Parameters.AddRange(values);
            int a = Convert.ToInt32(cmd.ExecuteScalar());

            if (lastState == false)
                conn.Close();
            return a;
        }

        /// <summary>
        /// 利用sql语句来读取数据（不带参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sql)
        {
            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 利用sql语句来读取数据（带参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sql, params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(values);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 利用存储过程来读取数据（带参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "";//要调用的存储过程的名字
            cmd.Parameters.AddRange(values);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 利用存储过程来读取数据（带参数）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(SqlParameter[] values, string ProName)
        {
            //foreach (SqlParameter p in values)
            //{
            //    if (p.Value == null)
            //    {
            //        p.Value = DBNull.Value;
            //    }
            //}

            SqlConnection conn = getConnection();
            bool lastState = isConnectionOpen(conn);
            if (lastState == false)
                conn.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProName;//要调用的存储过程的名字
            cmd.Parameters.AddRange(values);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// 利用sql语句和参数查询数据集
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }

            SqlConnection conn = getConnection();
            foreach (SqlParameter p in values)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddRange(values);
            da.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }


        /// <summary>
        /// 执行查询语句,返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        public static DataTable GetMenuList(int Index)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    string sql = "SELECT NAME,URL  FROM lr.dbo.S_Channel where PARENT=(SELECT ID FROM S_Channel WHERE ID ='{0}') ORDER BY ORDERS DESC";
                    sql = string.Format(sql, Index);
                    SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                    command.Fill(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        public static DataTable GetMenu()
        {
            DataTable dt = new DataTable();
            Meues m = new Meues();
            dt.Columns.Add(m.Title);
            dt.Columns.Add(m.Id);
            dt.Columns.Add(m.Name);
            dt.Columns.Add(m.Url);
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("Config/MenuType.xml"));
                XmlNode root = doc.DocumentElement;
                //获取节点列表
                XmlNodeList items = root.ChildNodes;
                //遍历item项
                foreach (XmlNode item in items)
                {
                    DataRow row = dt.NewRow();
                    row[m.Title] = item.Attributes["belong"].InnerText;
                    row[m.Id] = item["ID"].InnerText;
                    row[m.Name] = item["NAME"].InnerText;
                    row[m.Url] = item["url"].InnerText;
                    dt.Rows.Add(row);
                }
            }
            catch (Exception es)
            {
                Tool.WritrErro(es);
            }
            return dt;
        }
        public static string GetMeta(string _str)
        {
            string str = string.Empty;
            Meta mata = new Meta();
            Meues m = new Meues();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("Config/MenuType.xml"));
                XmlNode root = doc.DocumentElement;
                //获取节点列表
                XmlNodeList items = root.ChildNodes;
                //遍历item项
                foreach (XmlNode item in items)
                {
                    //var sss= item.Attributes["belong"].InnerText;
                    str = item[_str].InnerText;
                }
            }
            catch (Exception es)
            {
                Tool.WritrErro(es);
            }
            return str;
        }
        /// <summary>
        /// 获取一级菜单名
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMenu_Title()
        {
            Meues m = new Meues();
            List<string> list = new List<string>();
            DataTable dt = DBHelper.GetMenu();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][m.Title].ToString());
            }
            return list;
        }
        /// <summary>
        /// 返回一级菜单名字和对应Url
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetName(string Name)
        {
            Meues m = new Meues();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < GetMenu().Rows.Count; i++)
            {
                if (GetMenu().Rows[i][m.Title].ToString() == Name)
                {
                    if (!dict.ContainsKey(GetMenu().Rows[i][m.Name].ToString()))
                        dict.Add(GetMenu().Rows[i][m.Name].ToString(), GetMenu().Rows[i][m.Url].ToString());
                }
            }
            return dict;
        }

        public static Dictionary<string, string> GetName()
        {
            Meues m = new Meues();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < GetMenu().Rows.Count; i++)
            {
                if (!dict.ContainsKey(GetMenu().Rows[i][m.Name].ToString()))
                    dict.Add(GetMenu().Rows[i][m.Name].ToString(), GetMenu().Rows[i][m.Url].ToString());
            }
            return dict;
        }
        public static Dictionary<string, string> GetTwoName()
        {
            Meues m = new Meues();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < GetMenu_Title().Count; i++)
            {
                string name = GetMenu_Title()[i].ToString();
                for (int j = 0; j < GetMenu().Rows.Count; j++)
                {
                    if (name == GetMenu().Rows[i][m.Title].ToString())
                    {
                        if (!dict.ContainsKey(name))
                            dict.Add(name, GetMenu().Rows[i][m.Url].ToString());
                        break;
                    }
                }

            }
            return dict;
        }
    }
}
