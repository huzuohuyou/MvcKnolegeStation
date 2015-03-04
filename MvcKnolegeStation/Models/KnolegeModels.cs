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
        private int Id;
        // 上传人
        private string m_strUserId;
        // 标题
        private string m_strTitle;
        // 描述
        private string m_strDesc;
        // 热度
        private int m_strHot;
        // 上传日期
        private DateTime m_dateUploadTime;

        public void SetID(string p_iId)
        {
            Id = int.Parse(p_iId);
        }

        public void SetM_STRUSERID(string p_strUserId)
        {
            m_strUserId = p_strUserId;
        }

        public void SetM_STRTITLE(string p_strTitle)
        {
            m_strTitle = p_strTitle;
        }

        public void SetM_STRDESC(string p_strDesc)
        {
            m_strDesc = p_strDesc;
        }

        public void SetM_STRHOT(string p_strHot)
        {
            m_strHot =int.Parse(p_strHot);
        }

        public void SetM_DATEUPLOADTIME(string p_dateUploadTime)
        {
            DateTime _dt = DateTime.Now;
            DateTime.TryParse(p_dateUploadTime,out _dt);
            m_dateUploadTime = _dt;
        }
    }

}