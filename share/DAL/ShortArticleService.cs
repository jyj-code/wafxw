using Greentown.Health.DataAccess;
using share.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using share.log4net1;

namespace share.DAL
{
    /// <summary>
    /// 我爱分享网操作类
    /// </summary>
    public class shareService
    {

        #region 我爱分享网
        /// <summary>
        /// 发布我爱分享网
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Createshare(shareModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ShortArticle(");
            strSql.Append("ArticleID,ArticleContent,CustomerID,ArticleType,GetCount,DataState,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@ArticleID,@ArticleContent,@CustomerID,@ArticleType,@GetCount,@DataState,@CreateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleContent", SqlDbType.VarChar,-1),
					new SqlParameter("@CustomerID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleType", SqlDbType.VarChar,-1),
					new SqlParameter("@GetCount", SqlDbType.Int,4),
					new SqlParameter("@DataState", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.ArticleContent;
            parameters[2].Value = model.CustomerID;
            parameters[3].Value = "微博"; //文字类型默认
            parameters[4].Value = 0; //初始浏览次数0
            parameters[5].Value = 0; //默认状态0
            parameters[6].Value = DateTime.Now;

            int rows = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 发布我爱分享网
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateArea(shareModel model, string _Type)
        {
            int rows = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into ShortArticle(");
                strSql.Append("ArticleID,ArticleContent,CustomerID,ArticleType,GetCount,DataState,CreateDate,Title)");
                strSql.Append(" values (");
                strSql.Append("@ArticleID,@ArticleContent,@CustomerID,@ArticleType,@GetCount,@DataState,@CreateDate,@Title)");
                SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleContent", SqlDbType.VarChar,-1),
					new SqlParameter("@CustomerID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleType", SqlDbType.VarChar,-1),
					new SqlParameter("@GetCount", SqlDbType.Int,4),
					new SqlParameter("@DataState", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@Title", SqlDbType.VarChar,-1)};
                parameters[0].Value = Guid.NewGuid();
                parameters[1].Value = model.ArticleContent;
                parameters[2].Value = model.CustomerID;
                parameters[3].Value = _Type; //文字类型默认0
                parameters[4].Value = 0; //初始浏览次数0
                parameters[5].Value = 0; //默认状态0
                parameters[6].Value = DateTime.Now;
                parameters[7].Value = model.Title;
                rows = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            }
            catch (Exception a)
            {
                Tool.WritrErro(a);
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 获取最新发布我爱分享网
        /// </summary>
        /// <param name="top">显示数量</param>
        /// <returns></returns>
        public List<shareModel> Getshare(int top)
        {
            string strSql = string.Format("SELECT TOP {0} *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT count(1) FROM [ArticleLike] l WHERE l.ArticleID=a.ArticleID) as LikeCount,(SELECT count(1) FROM [ArticleComment] c WHERE c.ArticleID=a.ArticleID) as CommentCount, (SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex FROM dbo.ShortArticle a ORDER BY CreateDate DESC", top);
            List<shareModel> list = new List<shareModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<shareModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception l)
            {
                Tool.WritrErro(l);
            }
            return list;
        }

        /// <summary>
        /// 获取用户自己发布的我爱分享网
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<shareModel> GetshareByMy(Guid customerID)
        {
            string strSql = string.Format("SELECT *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT count(1) FROM [ArticleLike] l WHERE l.ArticleID=a.ArticleID) as LikeCount,(SELECT count(1) FROM [ArticleComment] c WHERE c.ArticleID=a.ArticleID) as CommentCount, (SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex FROM dbo.ShortArticle a WHERE a.CustomerID ='{0}' ORDER BY CreateDate DESC", customerID);
            List<shareModel> list = new List<shareModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<shareModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception w)
            {
                Tool.WritrErro(w);
            }
            return list;
        }

        /// <summary>
        /// 获取用户收藏的我爱分享网
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<shareModel> GetshareByFavorite(Guid customerID)
        {
            string strSql = string.Format("SELECT *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT count(1) FROM [ArticleLike] l WHERE l.ArticleID=a.ArticleID) as LikeCount,(SELECT count(1) FROM [ArticleComment] c WHERE c.ArticleID=a.ArticleID) as CommentCount, (SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex FROM dbo.ShortArticle a WHERE a.ArticleID in (SELECT ArticleID FROM dbo.Favorite WHERE CustomerID='{0}') ORDER BY CreateDate DESC", customerID);
            List<shareModel> list = new List<shareModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<shareModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception eq)
            {
                Tool.WritrErro(eq);
            }
            return list;
        }


        /// <summary>
        /// 获取用户赞过的我爱分享网
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<shareModel> GetshareByLike(Guid customerID)
        {
            string strSql = string.Format("SELECT *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT count(1) FROM [ArticleLike] l WHERE l.ArticleID=a.ArticleID) as LikeCount,(SELECT count(1) FROM [ArticleComment] c WHERE c.ArticleID=a.ArticleID) as CommentCount, (SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex FROM dbo.ShortArticle a WHERE a.ArticleID in (SELECT ArticleID FROM dbo.ArticleLike WHERE CustomerID='{0}') ORDER BY CreateDate DESC", customerID);
            List<shareModel> list = new List<shareModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<shareModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception w)
            {
                Tool.WritrErro(w);
            }
            return list;
        }

        /// <summary>
        /// 获取用户评论过的我爱分享网
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<shareModel> GetshareByComment(Guid customerID)
        {
            string strSql = string.Format("SELECT *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT count(1) FROM [ArticleLike] l WHERE l.ArticleID=a.ArticleID) as LikeCount,(SELECT count(1) FROM [ArticleComment] c WHERE c.ArticleID=a.ArticleID) as CommentCount, (SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex FROM dbo.ShortArticle a WHERE a.ArticleID in (SELECT ArticleID FROM dbo.ArticleComment WHERE CustomerID='{0}') ORDER BY CreateDate DESC", customerID);
            List<shareModel> list = new List<shareModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<shareModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception q1)
            {
                Tool.WritrErro(q1);
            }
            return list;
        }






        /// <summary>
        /// 获取我爱分享网详情
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public shareModel GetshareDetail(Guid articleID)
        {
            string strSql = string.Format("SELECT *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT count(1) FROM [ArticleLike] l WHERE l.ArticleID=a.ArticleID) as LikeCount,(SELECT count(1) FROM [ArticleComment] c WHERE c.ArticleID=a.ArticleID) as CommentCount, (SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex,(SELECT PhotoUrl FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as PhotoUrl  FROM dbo.ShortArticle a where a.ArticleID='{0}' ORDER BY CreateDate DESC", articleID);
            SqlDataReader sqlDataReader = DBHelper.GetDataReader(strSql.ToString());
            shareModel model = sqlDataReader.ReaderToModel<shareModel>();
            sqlDataReader.Close();
            return model;
        }

        /// <summary>
        /// 获取某个用户所有发布的我爱分享网
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public List<shareModel> GetshareByCustomerID(Guid customerID)
        {
            string strSql = string.Format("SELECT * FROM dbo.ShortArticle WHERE CustomerID='{0}' ORDER BY CreateDate DESC", customerID);
            List<shareModel> list = new List<shareModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<shareModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception w1)
            {
                Tool.WritrErro(w1);
            }
            return list;
        }

        /// <summary>
        /// 根据文字ID删除文字
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public bool Deleteshare(Guid articleID)
        {
            int rows = 0;
            try
            {
                string strSql = string.Format("DELETE FROM ShortArticle where ArticleID='{0}'", articleID);
                rows = DBHelper.ExecuteCommand(strSql);
            }
            catch (Exception w2)
            {
                Tool.WritrErro(w2);
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region 评论

        /// <summary>
        /// 获取我爱分享网评论
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public List<ArticleCommentModel> GetArticleCommentList(Guid articleID)
        {
            string strSql = string.Format("SELECT *,(SELECT CustomerName FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerName,(SELECT Sex FROM dbo.Customer c WHERE c.CustomerID=a.CustomerID) as CustomerSex FROM dbo.ArticleComment a WHERE a.ArticleID='{0}' ORDER BY CreateDate DESC", articleID);
            List<ArticleCommentModel> list = new List<ArticleCommentModel>();
            try
            {
                using (SqlDataReader reader = DBHelper.GetDataReader(strSql.ToString()))
                {
                    list = CommconHelper.ReaderToList<ArticleCommentModel>(reader).ToList();
                    reader.Close();
                }
            }
            catch (Exception w3)
            {
                Tool.WritrErro(w3);
            }
            return list;
        }

        /// <summary>
        /// 创建评论
        /// </summary>
        public bool CreateArticleComment(ArticleCommentModel model)
        {
            int rows = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into ArticleComment(");
                strSql.Append("CommentID,ArticleID,CustomerID,ContentDesc,DataState,CreateDate)");
                strSql.Append(" values (");
                strSql.Append("@CommentID,@ArticleID,@CustomerID,@ContentDesc,@DataState,@CreateDate)");
                SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomerID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ContentDesc", SqlDbType.VarChar,-1),
					new SqlParameter("@DataState", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
                parameters[0].Value = Guid.NewGuid();
                parameters[1].Value = model.ArticleID;
                parameters[2].Value = model.CustomerID;
                parameters[3].Value = model.ContentDesc;
                parameters[4].Value = 0;
                parameters[5].Value = DateTime.Now;

                rows = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
            }
            catch (Exception w4)
            {
                Tool.WritrErro(w4);
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 点赞

        /// <summary>
        /// 新增点赞
        /// </summary>
        public bool CreateArticleLike(ArticleLikeModel model)
        {
            int rows = 0;
            //判断重复点赞
            if (DBHelper.GetScaler("SELECT COUNT(1) FROM dbo.ArticleLike WHERE ArticleID='" + model.ArticleID + "' AND CustomerID='" + model.CustomerID + "'") > 0)
            {
                return false;
            }
            else
            {
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into ArticleLike(");
                    strSql.Append("LikeID,ArticleID,CustomerID,CreateDate)");
                    strSql.Append(" values (");
                    strSql.Append("@LikeID,@ArticleID,@CustomerID,@CreateDate)");
                    SqlParameter[] parameters = {
					new SqlParameter("@LikeID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomerID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
                    parameters[0].Value = Guid.NewGuid();
                    parameters[1].Value = model.ArticleID;
                    parameters[2].Value = model.CustomerID;
                    parameters[3].Value = DateTime.Now;

                    rows = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
                }
                catch (Exception w5)
                {
                    Tool.WritrErro(w5);
                }
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region 收藏
        /// <summary>
        /// 新增收藏
        /// </summary>
        public bool CreateFavorite(FavoriteModel model)
        {
            int rows = 0;
            //判断重复收藏
            if (DBHelper.GetScaler("SELECT COUNT(1) FROM dbo.Favorite WHERE ArticleID='" + model.ArticleID + "' AND CustomerID='" + model.CustomerID + "'") > 0)
            {
                return false;
            }
            else
            {
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Favorite(");
                    strSql.Append("FavoriteID,ArticleID,CustomerID,DataState,CreateDate)");
                    strSql.Append(" values (");
                    strSql.Append("@FavoriteID,@ArticleID,@CustomerID,@DataState,@CreateDate)");
                    SqlParameter[] parameters = {
					new SqlParameter("@FavoriteID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ArticleID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomerID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@DataState", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
                    parameters[0].Value = Guid.NewGuid();
                    parameters[1].Value = model.ArticleID;
                    parameters[2].Value = model.CustomerID;
                    parameters[3].Value = 0;
                    parameters[4].Value = DateTime.Now;

                    rows = DBHelper.ExecuteCommand(strSql.ToString(), parameters);
                }
                catch (Exception w6)
                {
                    Tool.WritrErro(w6);
                }
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

    }
}