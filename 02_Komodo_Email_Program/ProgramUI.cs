using _00_Helpful_Methods;
using _02_Komodo_Email_Repo;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Email_Program
{
    public class ProgramUI
    {
        private List<Recipient> _repo = new List<Recipient>();
        Tools tool = new Tools();

        private List<Message> _message = new List<Message>();

        public void Intro()
        {
            Console.WindowWidth = 130;
            Console.WindowHeight = 35;

            SeedRecipients();
            SeedMessaging();

            tool.MessageBar("KOMODO EMAIL CAMPAIGN", "=", " ", 60);

            Menu();
        }


        public void Menu()
        {
            tool.MenuLine(1, "See Recipient List");
            tool.MenuLine(2, "See Recipients by Type");
            tool.MenuLine(3, "Add Recipients");
            tool.MenuLine(4, "Update Recipients");
            tool.MenuLine(5, "Delete Recipients");
            tool.MenuLine(6, "Exit");

            int menuResponse;

            bool validEntry = false;

            while (validEntry == false)
            {
                menuResponse = tool.GetIntResponse("");
                switch (menuResponse)
                {
                    case 1:
                        ViewAllRecipients();
                        validEntry = true;
                        break;
                    case 2:
                        ViewRecipientByType(SearchByType());
                        validEntry = true;
                        break;
                    case 3:
                        AddRecipient();
                        validEntry = true;
                        break;
                    case 4:
                        UpdateExistingRecipient();
                        validEntry = true;
                        break;
                    case 5:
                        DeleteRecipient();
                        validEntry = true;
                        break;
                    case 6:
                        validEntry = true;
                        break;
                    default:
                        tool.WriteColors("Please make a valid entry.", "Red");

                        validEntry = false;
                        break;
                }
            }
        }


        public void ViewAllRecipients()
        {
            int pad = 20;
            int cols = 5;
            Console.Clear();
            tool.MessageBar("ALL RECIPIENTS", "=", " ", (pad * cols) + pad);

            tool.PadString("First", pad / 2);
            tool.PadString("Last", pad / 2);
            tool.PadString("Type", pad / 2);
            tool.PadString("Email Address", pad);
            tool.PadString("Subject", pad * 2);
            tool.PadString("Message", pad * 2);
            Console.WriteLine();
            tool.RowDivider("=", (pad * cols) + pad);

            foreach (Recipient recipient in _repo)
            {
                tool.PadString(recipient.FirstName, pad / 2);
                tool.PadString(recipient.LastName, pad / 2);
                tool.PadString(GetRecipientType(recipient.Type), pad / 2);
                tool.PadString(recipient.EmailAddress, pad);
                string subject = tool.StringTruncate(GetSubjectLine(recipient.Type), pad * 2);
                tool.PadString(subject, pad * 2);
                string message = tool.StringTruncate(GetMessageLine(recipient.Type), pad * 2);
                tool.PadString(message, pad * 2);
                Console.WriteLine();
                tool.RowDivider("-", (pad * cols) + pad);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }


        public int SearchByType()
        {
            Console.Clear();
            Console.WriteLine("Which customers would you like to see?");
            Console.WriteLine();
            tool.MenuLine(1, "Current");
            tool.MenuLine(2, "Past");
            tool.MenuLine(3, "Potential");
            return tool.GetIntResponse("");
        }



        public void ViewRecipientByType(int rectype)
        {
            Console.Clear();
            int pad = 20;
            int cols = 5;
            Console.Clear();
            tool.MessageBar(GetRecipientType(rectype) + " CUSTOMERS", "=", " ", (pad * cols) + pad);

            tool.PadString("First", pad / 2);
            tool.PadString("Last", pad / 2);
            tool.PadString("Type", pad / 2);
            tool.PadString("Email Address", pad);
            tool.PadString("Subject", pad * 2);
            tool.PadString("Message", pad * 2);
            Console.WriteLine();
            tool.RowDivider("=", (pad * cols) + pad);

            foreach (Recipient recipient in _repo)
            {
                if (recipient.Type == rectype)
                {
                    tool.PadString(recipient.FirstName, pad / 2);
                    tool.PadString(recipient.LastName, pad / 2);
                    tool.PadString(GetRecipientType(recipient.Type), pad / 2);
                    tool.PadString(recipient.EmailAddress, pad);
                    string subject = tool.StringTruncate(GetSubjectLine(recipient.Type), pad * 2);
                    tool.PadString(subject, pad * 2);
                    string message = tool.StringTruncate(GetMessageLine(recipient.Type), pad * 2);
                    tool.PadString(message, pad * 2);
                    Console.WriteLine();
                    tool.RowDivider("-", (pad * cols) + pad);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }


        private void UpdateExistingRecipient()
        {
            Console.Clear();
            Console.WriteLine("Please enter which recipient you want to update:");
            Console.WriteLine();
            PullRecipientMenuFromList();
            
            int selection = tool.GetIntResponse("");

            Console.Clear();

            Recipient oldRecipient = _repo[selection - 1];

            if (oldRecipient == null)
            {
                tool.WriteColors("Recipient not found.  Press any key to continue...", "Red");
                Console.ReadKey();
            }

            Recipient recipient = new Recipient(
                oldRecipient.FirstName,
                oldRecipient.LastName,
                oldRecipient.Type,
                oldRecipient.EmailAddress
                );

            Console.WriteLine("Which property would you like to update:");
            Console.WriteLine();
            tool.MenuLine(1, "First Name");
            tool.MenuLine(2, "Last Name");
            tool.MenuLine(3, "Recipient Type");
            tool.MenuLine(4, "Email Address");

            int propUpdate = tool.GetIntResponse("");

            switch (propUpdate)
            {
                case 1:
                    oldRecipient.FirstName = tool.GetStringResponse("Enter new First Name");
                    break;
                case 2:
                    oldRecipient.LastName = tool.GetStringResponse("Enter new Last Name");
                    break;
                case 3:
                    Console.WriteLine("Enter new Recipient Type");
                    Console.WriteLine();
                    tool.MenuLine(1, "Current Customer");
                    tool.MenuLine(2, "Past Customer");
                    tool.MenuLine(3, "Potential Customer");
                    oldRecipient.Type = tool.GetIntResponse("Enter new Type");
                    break;
                case 4:
                    oldRecipient.EmailAddress = tool.GetStringResponse("Enter new Email Address");
                    break;
                default:
                    break;
            }
            Console.WriteLine();
            tool.WriteColors(oldRecipient.FirstName + " " + oldRecipient.LastName + " updated.", 2);
            tool.KeyForward();
            Console.Clear();
            ViewAllRecipients();
        }



        public string GetRecipientType(int type)
        {
            switch (type)
            {
                case 1:
                    return "Current";
                case 2:
                    return "Past";
                case 3:
                    return "Potential";
                default:
                    return "N/A";
            }
        }


        public string GetSubjectLine(int type)
        {
            return _message[type - 1].Subject;
        }


        public string GetMessageLine(int type)
        {
            return _message[type - 1].Body;
        }



        public void AddRecipient()
        {
            Console.Clear();
            Console.WriteLine("Please enter a customer type:");
            Console.WriteLine();
            tool.MenuLine(1, "Current");
            tool.MenuLine(2, "Past");
            tool.MenuLine(3, "Potential");
            int type = tool.GetIntResponse("");
            Console.Clear();
            string first = tool.GetStringResponse("Please enter first name:");
            Console.Clear();
            string last = tool.GetStringResponse("Please enter last name:");
            Console.Clear();
            string email = tool.GetStringResponse("Please enter an email address:");
            Console.Clear();

            Recipient newRecipient = new Recipient(first, last, type, email);

            _repo.Add(newRecipient);

            tool.WriteColors("Recipient added.", "green");

            Menu();
        }


        public void PullRecipientMenuFromList()
        {
            int menuItem = 1;
            foreach (Recipient recipient in _repo)
            {
                tool.MenuLine(menuItem, recipient.FirstName + " " + recipient.LastName);
                menuItem++;
            }
        }



        public void DeleteRecipient()
        {
            Console.Clear();
            Console.WriteLine("Please enter the recipient you want to delete:");
            Console.WriteLine();
            PullRecipientMenuFromList();
            int selection = tool.GetIntResponse("");

            _repo.RemoveAt(selection - 1);

            tool.WriteColors("Recipient deleted.", "Red");

            tool.KeyForward();
            Menu();
        }



        public void SeedRecipients()
        {
            Recipient newrecipient1 = new Recipient("Dave", "Sprinkle", 1, "dave@somewhere.com");
            Recipient newrecipient2 = new Recipient("Tom", "Ward", 2, "TWard@somewhere.com");
            Recipient newrecipient3 = new Recipient("Simon", "Says", 3, "Simon@SimonSays.com");
            Recipient newrecipient4 = new Recipient("Pat", "De Bunny", 1, "Pat@DeBunny.com");

            _repo.Add(newrecipient1);
            _repo.Add(newrecipient2);
            _repo.Add(newrecipient3);
            _repo.Add(newrecipient4);
        }


        public void SeedMessaging()
        {
            Message newmessage1 = new Message("Thank you for your business!", "Thank you for your work with us.We appreciate your loyalty.Here's a coupon.");
            Message newmessage2 = new Message("We've missed you!", "It's been a long time since we've heard from you, we want you back.");
            Message newmessage3 = new Message("We've got a deal for you!", "We currently have the lowest rates on Helicopter Insurance!");

            _message.Add(newmessage1);
            _message.Add(newmessage2);
            _message.Add(newmessage3);
        }
    }
}
