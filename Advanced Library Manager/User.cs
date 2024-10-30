using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Library_Manager
{
    internal class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public bool isAdmin { get; set; }

        public User(int iD, string userName, bool isAdmin)
        {
            ID = iD;
            UserName = userName;
            this.isAdmin = isAdmin;
        }
    }
}
