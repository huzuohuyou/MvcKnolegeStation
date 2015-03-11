using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcKnolegeStation.Models
{

    public class PictureWallContext : DbContext
    {
        public PictureWallContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<PictureWall> PictureWalls { get; set; }
    }
    public class PictureWall
    {
        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string message;

        public string MESSAGE
        {
            get { return message; }
            set { message = value; }
        }
        private string path;

        public string PATH
        {
            get { return path; }
            set { path = value; }
        }
        private string userid;

        public string USERID
        {
            get { return userid; }
            set { userid = value; }
        }
    }
}