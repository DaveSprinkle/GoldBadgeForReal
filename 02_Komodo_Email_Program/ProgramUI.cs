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
            SetMessaging();

            tool.MessageBar("KOMODO EMAIL CAMPAIGN", "=", " ", 60);

            Menu();
            
            tool.KeyForward();
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

            while(validEntry == false)
            {
                menuResponse = tool.GetIntResponse("");
                switch (menuResponse)
                {
                    case 1:
                        ViewAllRecipients();
                        validEntry = true;
                        break;

                    case 2:
                        ViewRecipientByType(1);
                        validEntry = true;
                        break;
                    case 3:
                        AddRecipient();
                        validEntry = true;
                        break;
                    case 4:
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

            tool.PadString("First Name", pad/2);
            tool.PadString("Last Name", pad/2);
            tool.PadString("Type", pad/2);
            tool.PadString("Email Address", pad);
            tool.PadString("Message", pad*2);
            Console.WriteLine();
            tool.RowDivider("=", (pad * cols)+pad);

            foreach (Recipient recipient in _repo)
            {
                tool.PadString(recipient.FirstName, pad/2);
                tool.PadString(recipient.LastName, pad/2);
                tool.PadString(GetRecipientType(recipient.Type), pad/2);
                tool.PadString(recipient.Email, pad);
                tool.PadString(recipient.Message, pad* 2);
                Console.WriteLine();
                tool.RowDivider("-", (pad * cols) + pad);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }


        public void ViewRecipientByType(int rectype)
        {
            int pad = 20;
            int cols = 5;
            Console.Clear();
            tool.MessageBar("ALL RECIPIENTS", "=", " ", (pad * cols) + pad);

            tool.PadString("First Name", pad / 2);
            tool.PadString("Last Name", pad / 2);
            tool.PadString("Type", pad / 2);
            tool.PadString("Email Address", pad);
            tool.PadString("Message", pad * 2);
            Console.WriteLine();
            tool.RowDivider("=", (pad * cols) + pad);

            foreach (Recipient recipient in _repo)
            {
                if(recipient.Type == rectype)
                {
                    tool.PadString(recipient.FirstName, pad / 2);
                    tool.PadString(recipient.LastName, pad / 2);
                    tool.PadString(GetRecipientType(recipient.Type), pad / 2);
                    tool.PadString(recipient.Email, pad);
                    tool.PadString(recipient.Message, pad * 2);
                    Console.WriteLine();
                    tool.RowDivider("-", (pad * cols) + pad);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }


        public string GetRecipientType(int type)
        {
            switch (type)
            {
                case 1:
                    return "Current";
                    break;
                case 2:
                    return "Past";
                    break;
                case 3:
                    return "Potential";
                    break;
                default:
                    return "N/A";
                    break;
            }
        }


        public void AddRecipient()
        {
            string first = tool.GetStringResponse("Please enter first name:");
            string last = tool.GetStringResponse("Please enter last name:");
            int type = tool.GetIntResponse("Please enter a type:");
            string email = tool.GetStringResponse("Please enter an email address:");
            string message = "Message here...";

            Recipient newRecipient = new Recipient(first, last, type, email, message);

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
            PullRecipientMenuFromList();
            int selection = tool.GetIntResponse("Please enter which recipient you want to delete:");

            _repo.RemoveAt(selection - 1);

            tool.WriteColors("Recipient deleted.", "Red");

            tool.KeyForward();
            Menu();
        }

       

        public void SeedRecipients()
        {
            Recipient newrecipient1 = new Recipient("Dave", "Sprinkle", 1, "dave@somewhere.com", "Some message");
            Recipient newrecipient2 = new Recipient("Tom", "Sprinkle", 2, "dave@somewhere.com", "Some message");
            Recipient newrecipient3 = new Recipient("Abraham", "Sprinkle", 3, "dave@somewhere.com", "Some message");
            Recipient newrecipient4 = new Recipient("Matt", "Sprinkle", 1, "dave@somewhere.com", "Some message");

            _repo.Add(newrecipient1);
            _repo.Add(newrecipient2);
            _repo.Add(newrecipient3);
            _repo.Add(newrecipient4);
        }


        public void SetMessaging()
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
