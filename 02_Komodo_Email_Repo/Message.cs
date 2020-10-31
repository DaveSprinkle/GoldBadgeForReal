using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Email_Repo
{
    public class Message
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public Message() { }

        public Message(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }

    }
}
