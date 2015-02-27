using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcKnolegeStation.Models
{
    public class DownLoadLogContext : DbContext
    {

        public DownLoadLogContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<DownLoadLogModels> DownLoadLogs { get; set; }
    }
    public class DownLoadLogModels
    {
        public int Id { get; set; }
        public int m_iKnolegeModelsId { get; set; }
        public int m_iDownLoadCount { get; set; }
        public string m_strDetail { get; set; }
    }

}