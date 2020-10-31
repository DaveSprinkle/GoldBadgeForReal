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
        private List<Message> _message = new List<Message>();

        public void Intro()
        {
            int cbufferh = Console.BufferHeight;
            int cbufferw = Console.BufferWidth;

            Console.WindowWidth = 130;
            Console.WindowHeight = 35;

            SeedRecipients();
            SetMessaging();

            MessageBar("KOMODO EMAIL CAMPAIGN", "=", " ", 60);

            Menu();
            
            KeyForward();
        }


        public void Menu()
        {
            MenuLine(1, "See Recipient List");
            MenuLine(2, "See Recipients by Type");
            MenuLine(3, "Add Recipients");
            MenuLine(4, "Update Recipients");
            MenuLine(5, "Delete Recipients");
            MenuLine(6, "Exit");
            
            int menuResponse;

            bool validEntry = false;

            while(validEntry == false)
            {
                menuResponse = GetIntResponse("");
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
                        WriteColors("Please make a valid entry.", "Red");
                        
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
            MessageBar("ALL RECIPIENTS", "=", " ", (pad * cols) + pad);

            PadString("First Name", pad/2);
            PadString("Last Name", pad/2);
            PadString("Type", pad/2);
            PadString("Email Address", pad);
            PadString("Message", pad*2);
            Console.WriteLine();
            RowDivider("=", (pad * cols)+pad);

            foreach (Recipient recipient in _repo)
            {
                PadString(recipient.FirstName, pad/2);
                PadString(recipient.LastName, pad/2);
                PadString(GetRecipientType(recipient.Type), pad/2);
                PadString(recipient.Email, pad);
                PadString(recipient.Message, pad* 2);
                Console.WriteLine();
                RowDivider("-", (pad * cols) + pad);
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
            MessageBar("ALL RECIPIENTS", "=", " ", (pad * cols) + pad);

            PadString("First Name", pad / 2);
            PadString("Last Name", pad / 2);
            PadString("Type", pad / 2);
            PadString("Email Address", pad);
            PadString("Message", pad * 2);
            Console.WriteLine();
            RowDivider("=", (pad * cols) + pad);

            foreach (Recipient recipient in _repo)
            {
                if(recipient.Type == rectype)
                {
                    PadString(recipient.FirstName, pad / 2);
                    PadString(recipient.LastName, pad / 2);
                    PadString(GetRecipientType(recipient.Type), pad / 2);
                    PadString(recipient.Email, pad);
                    PadString(recipient.Message, pad * 2);
                    Console.WriteLine();
                    RowDivider("-", (pad * cols) + pad);
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
            string first = GetStringResponse("Please enter first name:");
            string last = GetStringResponse("Please enter last name:");
            int type = GetIntResponse("Please enter a type:");
            string email = GetStringResponse("Please enter an email address:");
            string message = "Message here...";

            Recipient newRecipient = new Recipient(first, last, type, email, message);

            _repo.Add(newRecipient);

            WriteColors("Recipient added.", "green");

            Menu();
        }


        public void PullRecipientMenuFromList()
        {
            int menuItem = 1;
            foreach (Recipient recipient in _repo)
            {
                MenuLine(menuItem, recipient.FirstName + " " + recipient.LastName);
                menuItem++;
            }
        }



        public void DeleteRecipient()
        {
            PullRecipientMenuFromList();
            int selection = GetIntResponse("Please enter which recipient you want to delete:");

            _repo.RemoveAt(selection - 1);

            WriteColors("Recipient deleted.", "Red");

            KeyForward();
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






        //===============================================================================================================//
        //                                               COMMON TASKS                                                    //
        //===============================================================================================================//


        //***Write a message bar message blocked in equals signs***//
        public void MessageBar(string message, string border, string filler, int length)
        {
            string newMessage = "";
            string textBumper = "";
            string bar = "";

            if (length - message.Length % 2 == 0) { bar = string.Concat(Enumerable.Repeat(border, length)); }
            else { bar = string.Concat(Enumerable.Repeat(border, length + 1)); }

            int MessageStart = (bar.Length - message.Length) / 2;

            if (bar.Length % 2 == 0) { textBumper = string.Concat(Enumerable.Repeat(filler, bar.Length - message.Length / 2)); }
            else { textBumper = string.Concat(Enumerable.Repeat(filler, ((bar.Length - message.Length) / 2) - 1)); }

            newMessage = textBumper + message;
            textBumper = string.Concat(Enumerable.Repeat(filler, bar.Length - newMessage.Length));

            newMessage = newMessage + textBumper;
            Console.WriteLine(bar);
            Console.WriteLine(newMessage);
            Console.WriteLine(bar);
            Console.WriteLine();
        }


        //***Write a bottom border***//
        public void RowDivider(string character, int length)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat(character, length)));
        }


        //***Write in color without all that pesky code***//
        public void WriteColors(string message, string color)
        {
            string colorLower = color.ToLower();

            switch (colorLower)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }



        //***Converts a string to a number or returns 0***//
        public int StringToNum(string textnumber)
        {
            bool parsed = Int32.TryParse(textnumber, out int newNum);

            if (parsed == true) { return newNum; }
            else { return 0; }
        }



        //***Does a prompt and returns the answer***//
        public string GetStringResponse(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }


        //***Does a prompt and returns the answer as an Int***//
        public int GetIntResponse(string prompt)
        {
            Console.WriteLine(prompt);
            string stringNum = Console.ReadLine();
            bool parsed = Int32.TryParse(stringNum, out int newNum);
            if (parsed == true) { return newNum; }
            else { return 0; }
        }


        //***Does a prompt and returns the answer as an a double***//
        public double GetDoubleResponse(string prompt)
        {
            Console.WriteLine(prompt);
            string stringNum = Console.ReadLine();
            bool parsed = Double.TryParse(stringNum, out double newNum);

            if (parsed == true) { return newNum; }
            else { return 0; }
        }


        //***Pads a string for table writing***//
        public void PadString(string info, int padding)
        {
            Console.Write(info.PadRight(padding));
        }


        //***Pads a double for table writing***//
        public void PadDouble(double info, int padding)
        {
            string stringNum = info.ToString();
            Console.Write(stringNum.PadRight(padding));
        }


        //***Pads an int for table writing***//
        public void PadInt(int info, int padding)
        {
            string stringNum = info.ToString();
            Console.Write(stringNum.PadRight(padding));
        }


        //***Writes a menu number and line***//
        public void MenuLine(int number, string activity)
        {
            Console.WriteLine(number + ".) " + activity);
        }


        //***Waits for a key from user before moving***//
        public void KeyForward()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
