using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Repo;

namespace Komodo_Green.repo
{
    public class ProgramUI
    {
        private List<Vehicle> _repo = new List<Vehicle>();

        public void Intro()
        {
            SeedVehicles();
            MessageBar("KOMODO GREEN INITIATIVE", "=", " ", 50);
            Menu();
        }

        public void Menu()
        {
            MenuLine(1, "View All Vehicles ");
            MenuLine(2, "View Vehicles by Criteria");
            MenuLine(3, "Add a Vehicle");
            MenuLine(4, "Update a Vehicle");
            MenuLine(5, "Delete a Vehicle");
            MenuLine(6, "Exit");

            bool validEntry = false;

            while (validEntry == false)
            {
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        validEntry = true;
                        ViewAllVehicles();
                        break;
                        break;
                    case "2":
                        validEntry = true;
                        ViewSpecificVehicles();
                        break;
                    case "3":
                        validEntry = true;
                        AddVehicle();
                        break;
                    case "4":
                        validEntry = true;
                        UpdateExistingVehicle();
                        break;
                    case "5":
                        validEntry = true;
                        DeleteVehicle();
                        break;
                    case "6":
                        validEntry = true;
                        break;
                    default:
                        validEntry = false;
                        WriteColors("Please enter a valid selection", "Red");
                        break;
                }
            }
        }


        public void SeedVehicles()
        {
            Vehicle newVehicle1 = new Vehicle(3, "Honda", "CRV", 2017, 26, 450);
            Vehicle newVehicle2 = new Vehicle(1, "Tesla", "Model 3", 2020, 93, 402);
            Vehicle newVehicle3 = new Vehicle(2, "Ford", "Escape", 2020, 54, 500);
            Vehicle newVehicle4 = new Vehicle(3, "Hummer", "Full Combat", 2020, 6, 300);

            _repo.Add(newVehicle1);
            _repo.Add(newVehicle2);
            _repo.Add(newVehicle3);
            _repo.Add(newVehicle4);
        }


        public void ViewAllVehicles()
        {
            int pad = 18;
            int cols = 6;
            Console.Clear();
            MessageBar("ALL VEHICLES", "=", " ", pad * cols);

            PadString("Type", pad);
            PadString("Make", pad);
            PadString("Model", pad);
            PadString("Year", pad);
            PadString("MPG", pad);
            PadString("Range", pad);
            Console.WriteLine();
            RowDivider("=", pad * cols);

            foreach (Vehicle vehicle in _repo)
            {
                PadString(VehicleType(vehicle.Type), pad);
                PadString(vehicle.Make, pad);
                PadString(vehicle.Model, pad);
                PadInt(vehicle.Year, pad);
                PadDouble(vehicle.MPG, pad);
                PadInt(vehicle.Range, pad);
                Console.WriteLine();
                RowDivider("-", pad * cols);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Menu();
        }


        public void ViewSpecificVehicles()
        {
            Console.Clear();

            MenuLine(1, "View by Type");
            MenuLine(2, "View by Model");
            MenuLine(3, "View by Minimum MPG");
            MenuLine(4, "Main Menu");

            bool validEntry = false;

            while (validEntry == false)
            {
                string getResponse = Console.ReadLine();

                switch (getResponse)
                {
                    case "1":
                        SelectVehicleByType();
                        validEntry = true;
                        break;
                    case "2":
                        SelectVehicleByModel();
                        validEntry = true;
                        break;
                    case "3":
                        validEntry = true;
                        break;
                    case "4":
                        validEntry = true;
                        break;
                    default:
                        validEntry = false;
                        WriteColors("Please make a valid response", "red");
                        break;
                }
            }
        }

        public void SelectVehicleByType()
        {
            Console.Clear();

            MenuLine(1, "Electric");
            MenuLine(2, "Hybrid");
            MenuLine(3, "Gas/Deisel");
            MenuLine(4, "Main Menu");

            bool validEntry = false;

            while (validEntry == false)
            {
                string getResponse = Console.ReadLine();

                switch (getResponse)
                {
                    case "1":
                        ViewVehicleByType(1);
                        validEntry = true;
                        break;
                    case "2":
                        ViewVehicleByType(2);
                        validEntry = true;
                        break;
                    case "3":
                        ViewVehicleByType(3);
                        validEntry = true;
                        break;
                    default:
                        validEntry = false;
                        WriteColors("Please make a valid response", "red");
                        break;
                }
            }
        }


        public void SelectVehicleByModel()
        {
            Console.Clear();
            PullVehicleMenuFromList();
            GetVehicleChoiceFromUser();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Menu();
        }



        public void PullVehicleMenuFromList()
        {
            int menuItem = 1;
            foreach (Vehicle vehicle in _repo)
            {
                MenuLine(menuItem, vehicle.Make + " " + vehicle.Model);
                menuItem++;
            }
        }


        public void GetVehicleChoiceFromUser()
        {
            int pad = 18;
            int cols = 6;
            int selNum;

            int selected = GetIntResponse("Enter the number of model you'd like to see:");

            if (selected == 0)
            {
                WriteColors("Please make a valid entry:", "Red");
                PullVehicleMenuFromList();
            }
            else
            {
                Vehicle vehicle = _repo[selected - 1];
                PadString(VehicleType(vehicle.Type), pad);
                PadString(vehicle.Make, pad);
                PadString(vehicle.Model, pad);
                PadInt(vehicle.Year, pad);
                PadDouble(vehicle.MPG, pad);
                PadInt(vehicle.Range, pad);
                Console.WriteLine();
                RowDivider("-", pad * cols);
            }
        }




        public void ViewVehicleByType(int type)
        {
            Console.Clear();
            int pad = 18;
            int cols = 5;

            string barType = VehicleType(type);

            MessageBar(barType.ToUpper(), "=", " ", pad * cols);

            foreach (Vehicle vehicle in _repo)
            {
                if (vehicle.Type == type)
                {
                    //PadString(VehicleType(vehicle.Type), pad);
                    PadString(vehicle.Make, pad);
                    PadString(vehicle.Model, pad);
                    PadInt(vehicle.Year, pad);
                    PadDouble(vehicle.MPG, pad);
                    PadInt(vehicle.Range, pad);
                    Console.WriteLine();
                    RowDivider("-", pad * cols);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Menu();

        }


        public string VehicleType(int intType)
        {
            string type;

            switch (intType)
            {
                case 1:
                    type = "Electric";
                    break;
                case 2:
                    type = "Hybrid";
                    break;
                case 3:
                    type = "Gas/Deisel";
                    break;
                default:
                    type = "N/A";
                    break;
            }
            return type;
        }


        public void AddVehicle()
        {
            int type = GetIntResponse("Please enter a type:");
            string make = GetStringResponse("Please enter a make:");
            string model = GetStringResponse("Please enter a model:");
            int year = GetIntResponse("Please enter a year:");
            double mpg = GetDoubleResponse("Please enter average MPG:");
            int range = GetIntResponse("Please enter approximate range:");

            Vehicle newVehicle = new Vehicle(type, make, model, year, mpg, range);

            _repo.Add(newVehicle);

            WriteColors("Your vehicle was added.", "green");

            Menu();
        }


        private void UpdateExistingVehicle()
        {
            PullVehicleMenuFromList();
            int selection = GetIntResponse("Please enter which vehicle you want to delete:");

            Console.Clear();

            Vehicle oldVehicle = _repo[selection - 1];

            if (oldVehicle == null)
            {
                WriteColors("Vehicle not found.  Press any key to continue...", "Red");
                Console.ReadKey();
            }

            Vehicle vehicle = new Vehicle(
                oldVehicle.Type,
                oldVehicle.Make,
                oldVehicle.Model,
                oldVehicle.Year,
                oldVehicle.MPG,
                oldVehicle.Range
            );

            Console.WriteLine("Which property would you like to update:");

            MenuLine(1, "Vehicle Type");
            MenuLine(2, "Vehicle Make");
            MenuLine(3, "Vehicle Model");
            MenuLine(4, "Vehicle Year");
            MenuLine(5, "Vehicle MPG");
            MenuLine(6, "Vehicle Range");
            MenuLine(7, "No updates needed");

            int propUpdate = GetIntResponse("");

            switch (propUpdate)
            {
                case 1:
                    oldVehicle.Type = GetIntResponse("Enter new Type");
                    break;
                case 2:
                    oldVehicle.Make = GetStringResponse("Enter new Make");
                    break;
                case 3:
                    oldVehicle.Model = GetStringResponse("Enter new Model");
                    break;
                case 4:
                    oldVehicle.Type = GetIntResponse("Enter new Year");
                    break;
                case 5:
                    double mpg = GetDoubleResponse("Enter MPG:");
                    break;
                case 6:
                    oldVehicle.Range = GetIntResponse("Enter new Range");
                    break;
                case 7:
                    break;
                default:
                    break;
            }
            Menu();
        }


        public void DeleteVehicle()
        {
            PullVehicleMenuFromList();
            int selection = GetIntResponse("Please enter which vehicle you want to delete:");

            _repo.RemoveAt(selection - 1);

            WriteColors("Vehicle deleted.", "Red");

            KeyForward();
            Menu();
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

