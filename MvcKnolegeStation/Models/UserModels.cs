using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcKnolegeStation.Models
{

    public class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserModels> Users { get; set; }
    }

    public class UserModels
    {
        public string ID;

        public string USERID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string UserName;

        public string USERNAME
        {
            get { return UserName; }
            set { UserName = value; }
        }
        private string PassWord;

        public string PASSWORD
        {
            get { return PassWord; }
            set { PassWord = value; }
        }

        private string roleid;

        public string ROLEID
        {
            get { return roleid; }
            set { roleid = value; }
        }
    }
}