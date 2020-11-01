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

        Tools tool = new Tools();    
        
        public void Intro()
        {
            Console.WindowWidth = 150;
            Console.WindowHeight = 35;

            SeedMenu();

            tool.MessageBar("KOMODO CAFE MENU", "=", " ", 60);

            Menu();

            tool.KeyForward();
        }


        public void Menu()
        {
            tool.MenuLine(1, "See All Menu Items");
            tool.MenuLine(2, "See Specific Menu Item");
            tool.MenuLine(3, "Add Menu Item");
            tool.MenuLine(4, "Update Menu Item");
            tool.MenuLine(5, "Delete Menu Item");
            tool.MenuLine(6, "Exit");

            int menuResponse;

            bool validEntry = false;

            while (validEntry == false)
            {
                menuResponse = tool.GetIntResponse("");
                switch (menuResponse)
                {
                    case 1:
                        ViewAllMenuItems();
                        validEntry = true;
                        break;
                    case 2:
                        GetMenuItemFromUser();
                        validEntry = true;
                        break;
                    case 3:
                        AddMenuItem();
                        validEntry = true;
                        break;
                    case 4:
                        UpdateExistingMenuItem();
                        validEntry = true;
                        break;
                    case 5:
                        DeleteMenuItem();
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


        public void ViewAllMenuItems()
        {
            int pad = 18;
            int cols = 8;
            Console.Clear();
            tool.MessageBar("ALL MENU ITEMS", "=", " ", (pad * cols));

            tool.PadString("#", pad / 2);
            tool.PadString("Name", pad);
            tool.PadString("Description", pad * 3);
            tool.PadString("Ingredients", pad * 3);
            tool.PadString("Price", pad/2);
            Console.WriteLine();
            tool.RowDivider("=", (pad * cols));

            foreach (KMenuItem menuitem in _repo)
            {
                tool.PadString(menuitem.MealNumber.ToString(), pad/4);
                tool.PadString(menuitem.MealName, pad);
                tool.PadString(menuitem.MealDescription, pad * 3);
                tool.PadString(menuitem.MealIngredients, pad * 3);
                tool.PadString(menuitem.MealPrice.ToString(), pad / 2);
                
                Console.WriteLine();
                tool.RowDivider("-", (pad * cols));
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }



        public void GetMenuItemFromUser()
        {
            int pad = 18;
            int cols = 8;
            Console.Clear();

            PullMenuItemFromList();

                int selected = tool.GetIntResponse("");
                KMenuItem item = _repo[selected - 1];

            if (selected == 0)
            {
                tool.WriteColors("Please make a valid entry:", "Red");
                PullMenuItemFromList();
            }
            else
            {
                tool.MessageBar(item.MealName + " ", "=", " ", pad * cols);
                tool.PadString("#", pad / 2);
                tool.PadString("Name", pad);
                tool.PadString("Description", pad * 3);
                tool.PadString("Ingredients", pad * 3);
                tool.PadString("Price", pad / 2);
                Console.WriteLine();
                tool.RowDivider("=", (pad * cols));

                tool.PadInt(item.MealNumber, pad/2);
                tool.PadString(item.MealName, pad);
                tool.PadString(item.MealDescription, pad*3);
                tool.PadString(item.MealIngredients, pad*3);
                tool.PadDecimal(item.MealPrice, pad/2);
                Console.WriteLine();
                tool.RowDivider("-", pad * cols);
            }

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


        public void AddMenuItem()
        {
            KMenuItem newItem = new KMenuItem();

            newItem.MealNumber = _repo.Count + 1;
            newItem.MealName = tool.GetStringResponse("Enter the Name of the new Item:");
            newItem.MealDescription = tool.GetStringResponse("Enter the Decription of the new Item:");
            newItem.MealIngredients = tool.GetStringResponse("Enter the Ingredients of the new Item:");
            newItem.MealPrice = tool.GetDecimalResponse("Enter the Price of the new Item:");

            _repo.Add(newItem);

            tool.WriteColors("Your new item was entered.", "Green");

            Console.WriteLine();

            Menu();
        }


        private void UpdateExistingMenuItem()
        {
            PullMenuItemFromList();
            int selection = tool.GetIntResponse("Please enter which item you want to update:");

            Console.Clear();

            KMenuItem oldItem = _repo[selection - 1];

            if (oldItem == null)
            {
                tool.WriteColors("Item not found.  Press any key to continue...", "Red");
                Console.ReadKey();
            }

            KMenuItem item = new KMenuItem(
                oldItem.MealNumber, 
                oldItem.MealName,
                oldItem.MealDescription,
                oldItem.MealIngredients,
                oldItem.MealPrice
                );

            Console.WriteLine("Which property would you like to update:");

            tool.MenuLine(1, "Item Name");
            tool.MenuLine(2, "Item Descriptioin");
            tool.MenuLine(3, "Item Ingredients");
            tool.MenuLine(4, "Item Price");
            
            int propUpdate = tool.GetIntResponse("");

            switch (propUpdate)
            {
                case 1:
                    oldItem.MealName = tool.GetStringResponse("Enter new Type");
                    break;
                case 2:
                    oldItem.MealDescription = tool.GetStringResponse("Enter new Make");
                    break;
                case 3:
                    oldItem.MealIngredients = tool.GetStringResponse("Enter new Model");
                    break;
                case 4:
                    oldItem.MealPrice = tool.GetIntResponse("Enter new Year");
                    break;
                default:
                    break;
            }
            Menu();
        }





        public void DeleteMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Please enter which menu item number you want to delete:");
            Console.WriteLine();
            PullMenuItemFromList();


            bool validSelection = false;

            while(validSelection == false)
            {
                int selection = tool.GetIntResponse("");
                
                if (selection == 0 || selection + 1 > _repo.Count)
                {
                    tool.WriteColors("Please make a valid selection.", 1);
                }
                else
                {
                    validSelection = true;
                    _repo.RemoveAt(selection - 1);
                }
            }

            tool.WriteColors("Item deleted.", "Red");

            tool.KeyForward();
            Menu();
        }

        public void PullMenuItemFromList()
        {
            int i = 1;
            foreach(KMenuItem menuitem in _repo)
            {
                tool.MenuLine(i, menuitem.MealName);
                i++;
            }
        }
    }
}
