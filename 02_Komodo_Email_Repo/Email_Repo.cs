using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Email_Repo
{
    public class Email_Repo
    {
        List<Recipient> _recipients = new List<Recipient>();

        List<Message> _message = new List<Message>();

        public bool AddRecipientToList(Recipient recipient)
        {
            int startingCount = _recipients.Count;
            _recipients.Add(recipient);

            bool wasAdded = (_recipients.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Recipient> GetRecipients()
        {
            return _recipients;
        }

        public Recipient GetRecipientByLastName(string lastname)
        {
            foreach (Recipient recipient in _recipients)
            {
                if (recipient.LastName.ToLower() == lastname.ToLower())
                {
                    return recipient;
                }
            }
            return null;
        }

        public bool UpdateExistingRecipient(string originalRecipient, Recipient newRecipient)
        {
            Recipient recipient = GetRecipientByLastName(originalRecipient);

            if (recipient != null)
            {
                recipient.FirstName = newRecipient.FirstName;
                recipient.LastName = newRecipient.FirstName;
                recipient.Type = newRecipient.Type;
                recipient.Email = newRecipient.Email;
                //recipient.Message = newRecipient.Message;
                
                return true;
            }
            else { return false; }
        }


        public bool DeleteRecipient(Recipient recipient)
        {
            int startingCount = _recipients.Count;
            _recipients.Remove(recipient);

            bool wasDeleted = (_recipients.Count < startingCount) ? true : false;
            return wasDeleted;
        }
    }
}
