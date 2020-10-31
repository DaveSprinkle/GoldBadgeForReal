using _00_Helpful_Methods;
using _03_Komodo_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Cafe
{
    public class ProgramUI
    {
        private List<KMenuItem> _repo = new List<KMenuItem>();

        Tools tools = new Tools();    
        
        public void Intro()
        {
            tools.TestCall();

            int cbufferh = Console.BufferHeight;
            int cbufferw = Console.BufferWidth;

            Console.WindowWidth = 150;
            Console.WindowHeight = 35;

            SeedMenu();

            MessageBar("KOMODO CAFE MENU", "=", " ", 60);

            Menu();

            KeyForward();
        }


        public void Menu()
        {
            MenuLine(1, "See All Menu Items");
            MenuLine(2, "Add Menu Items");
            MenuLine(3, "Delete Recipients");
            MenuLine(4, "Exit");

            int menuResponse;

            bool validEntry = false;

            while (validEntry == false)
            {
                menuResponse = GetIntResponse("");
                switch (menuResponse)
                {
                    case 1:
                        ViewAllMenuItems();
                        validEntry = true;
                        break;

                    case 2:
                        //ViewRecipientByType(1);
                        validEntry = true;
                        break;
                    case 3:
                        //AddMenuItem();
                        validEntry = true;
                        break;
                    case 4:
                        validEntry = true;
                        break;
                    case 5:
                        //DeleteMenuItem();
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


        public void ViewAllMenuItems()
        {
            int pad = 18;
            int cols = 8;
            Console.Clear();
            MessageBar("ALL MENU ITEMS", "=", " ", (pad * cols));

            PadString("#", pad / 2);
            PadString("Name", pad);
            PadString("Description", pad * 3);
            PadString("Ingredients", pad * 3);
            PadString("Price", pad/2);
            Console.WriteLine();
            RowDivider("=", (pad * cols));

            foreach (KMenuItem menuitem in _repo)
            {
                PadString(menuitem.MealNumber.ToString(), pad/4);
                PadString(menuitem.MealName, pad);
                PadString(menuitem.MealDescription, pad * 3);
                PadString(menuitem.MealIngredients, pad * 3);
                PadString(menuitem.MealPrice.ToString(), pad / 2);
                
                Console.WriteLine();
                RowDivider("-", (pad * cols));
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }






        public void SeedMenu()
        {
            KMenuItem newitem1 = new KMenuItem(1, "Spicy Chicken", "Spicy but light chicken sandwich and fruit.", "Chicken, buns, and komodo dragon chilis", 10.95m);
            KMenuItem newitem2 = new KMenuItem(2, "Spicy Burger", "The 'not light at all burger'...and fries.", "Burger, buns, and komodo dragon chilis", 12.95m);
            KMenuItem newitem3 = new KMenuItem(3, "Spicy Fish Tacos", "Wasabi blackened tuna and relish.  BAM!", "Fish, tortilla, and komodo dragon chilis", 15.95m);
            KMenuItem newitem4 = new KMenuItem(4, "Dragon Chilis", "Chilis of death. That'll be all.", "Komodo dragon chilis", 1.00m);

            _repo.Add(newitem1);
            _repo.Add(newitem2);
            _repo.Add(newitem3);
            _repo.Add(newitem4);
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


        public string BrokenString(string content, int pad, int cols)
        {
            int contentLength = content.Length;

            if (contentLength > pad)
            {
                string string1 = content.Substring(0, pad - 3);
                string string2 = content.Substring(pad - 4);
                return string1 + "\n" + string.Concat(Enumerable.Repeat(" ", pad * cols)) + string2;

            }
            else
            {
                return content;
            }
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
