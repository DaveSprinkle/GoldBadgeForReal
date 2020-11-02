﻿using System;
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
        public string EmailAddress { get; set; }


        public Recipient() { }


        public Recipient(string firstname, string lastname, int type, string emailaddress)
        {
            FirstName = firstname;
            LastName = lastname;
            Type = type;
            EmailAddress = emailaddress;
        }
    }
}
