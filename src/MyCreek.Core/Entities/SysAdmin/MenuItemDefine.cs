﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Entities.SysAdmin
{
    /// <summary>
    /// 自定义菜单
    /// </summary>
    public class MenuItemDefine : FullAuditedEntity
    {
        public int ParentMenuId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }


        /// <summary>
        /// 关联数据库表
        /// </summary>
        public string DBTable { get; set; }

        /// <summary>
        /// 关联SQL
        /// </summary>
        public string ExecSQL { get; set; }

        /// <summary>
        /// 关联视图
        /// </summary>
        public string DBView { get; set; }

        /// <summary>
        /// 关联存储过程
        /// </summary>
        public string Procedure { get; set; }

        public string IndexPageTemplate { get; set; }
        public string CreatePageTemplate { get; set; }
        public string UpdatePageTemplate { get; set; }
        public string GeneralPageTemplate { get; set; }


    }
}
