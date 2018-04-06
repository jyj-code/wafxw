using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace share.Model
{
    /// <summary>
    /// share:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class shareModel
    {
        public shareModel()
        { }
        #region Model
        private Guid _articleid;
        private string _articlecontent;
        private string _Title;
        private Guid _customerid;
        private string _articletype;
        private int? _getcount;
        private int? _datastate;
        private DateTime? _createdate;
        private string _photoUrl;
        /// <summary>
        /// 用户图像
        /// </summary>
        public string PhotoUrl
        {
            set { _photoUrl = value; }
            get { return _photoUrl; }
        }
        /// <summary>
        /// 文字ID
        /// </summary>
        public Guid ArticleID
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 文字内容
        /// </summary>
        public string ArticleContent
        {
            set { _articlecontent = value; }
            get { return _articlecontent; }
        }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        /// <summary>
        /// 用户ID（外键）
        /// </summary>
        public Guid CustomerID
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 文字类型（外键）
        /// </summary>
        public string ArticleType
        {
            set { _articletype = value; }
            get { return _articletype; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int? GetCount
        {
            set { _getcount = value; }
            get { return _getcount; }
        }
        /// <summary>
        /// 数据状态 0默认1删除
        /// </summary>
        public int? DataState
        {
            set { _datastate = value; }
            get { return _datastate; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        //public string PhotoUrl { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户性别
        /// </summary>
        public string CustomerSex { get; set; }

        /// <summary>
        /// 用户点赞数
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 用户评论数
        /// </summary>
        public int CommentCount { get; set; }


        #endregion Model

    }
}