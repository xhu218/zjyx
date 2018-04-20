using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Entities
{
    public class MeetingRoom : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string Doorplate { get; set; }
    }
}
