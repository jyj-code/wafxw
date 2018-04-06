using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace share.Model
{
    public class Meta
    {
        /// <summary>
        /// 属性
        /// </summary>
        public string belong { get; set; }
        /// <summary>
        /// 网站关键字
        /// </summary>
        public string keywords { get; set; }
        /// <summary>
        /// 关键字定义
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 版权所有者
        /// </summary>
        public string copyright { get; set; }

    }
}