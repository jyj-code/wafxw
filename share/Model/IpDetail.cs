using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace share.Model
{
    public class IpDetail
    {
        public String Ret { get; set; }

        public String Start { get; set; }

        public String End { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public String Country { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public String Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public String City { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public String District { get; set; }
        /// <summary>
        /// 网络服务提供商
        /// </summary>
        public String Isp { get; set; }

        public String Type { get; set; }

        public String Desc { get; set; }
    }
}