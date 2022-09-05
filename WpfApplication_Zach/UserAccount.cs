using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Zach
{
    internal class UserAccount
    {
        private string username;
        private string password;
        private int permission;

        public string UserName { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int Permission { get { return permission; } set { permission = value; } }

        public UserAccount(string username, string password, int permission)
        {
            this.username = username;
            this.password = password;
            this.permission = permission;
        }
    }


}
