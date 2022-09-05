using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication_Zach
{
    internal class People
    {
        private string firstname;
        private string lastname;
        private string eMail;
        private string gender;
        private DateTime birthdate;

        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string EMail { get { return eMail; } set { eMail = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public DateTime Birthdate { get { return birthdate; } set {birthdate = value; } }



    }
}
