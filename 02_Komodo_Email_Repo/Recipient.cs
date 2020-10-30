using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Email_Repo
{
    public class Recipient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Type { get; set; }
        public string Email { get; set; }
        public string Message { get; }

        public Recipient() { }

        public Recipient(string firstname, string lastname, int type, string email, string message)
        {
            FirstName = firstname;
            LastName = lastname;
            Type = type;
            Email = email;
            Message = message;
        }
    }
}
