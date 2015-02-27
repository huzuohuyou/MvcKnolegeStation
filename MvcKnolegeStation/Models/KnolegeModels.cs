using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcKnolegeStation.Models
{
    public class KnolegeContext : DbContext
    {
        public KnolegeContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<KnoledgeModels> Knoleges { get; set; }
    }
    
    public class KnoledgeModels
    {

        // 主键
        public int Id { get; set; }
        // 上传人
        public string m_strUserId { get; set; }
        // 标题
        public string m_strTitle { get; set; }
        // 描述
        public string m_strDesc { get; set; }
        // 附件路径
        public string m_strPath { get; set; }
        // 上传日期
        public DateTime m_dateUploadTime { get; set; }
       
    }

}