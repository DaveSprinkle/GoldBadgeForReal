using _00_Helpful_Methods;
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

        Tools tool = new Tools();

        public void Intro()
        {
            SeedVehicles();
            Console.ForegroundColor = ConsoleColor.Green;
            tool.MessageBar("KOMODO GREEN INITIATIVE", "=", " ", 50);
            Console.ForegroundColor = ConsoleColor.White;

            Menu();
        }

        public void Menu()
        {
            tool.MenuLine(1, "View All Vehicles ");
            tool.MenuLine(2, "View Vehicles by Criteria");
            tool.MenuLine(3, "Add a Vehicle");
            tool.MenuLine(4, "Update a Vehicle");
            tool.MenuLine(5, "Delete a Vehicle");
            tool.MenuLine(6, "Exit");

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
                        tool.WriteColors("Please enter a valid selection", "Red");
                        break;
                }
            }
        }




        public void ViewAllVehicles()
        {
            int pad = 18;
            int cols = 6;
            Console.Clear();
            tool.MessageBar("ALL VEHICLES", "=", " ", pad * cols);


            ColHeads(pad, cols);
            tool.RowDivider("=", pad * cols);

            int color;
            foreach (Vehicle vehicle in _repo)
            {
                
                if (vehicle.MPG < 30) { Console.ForegroundColor = ConsoleColor.Red; }
                if (vehicle.MPG >= 30 && vehicle.MPG < 50) { Console.ForegroundColor = ConsoleColor.Yellow; }
                if (vehicle.MPG > 50) { Console.ForegroundColor = ConsoleColor.Green; ; }

                tool.PadString(VehicleType(vehicle.Type), pad);
                tool.PadString(vehicle.Make, pad);
                tool.PadString(vehicle.Model, pad);
                tool.PadInt(vehicle.Year, pad);
                tool.PadDouble(vehicle.MPG, pad);
                tool.PadInt(vehicle.Range, pad);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                tool.RowDivider("-", pad * cols);
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
            Console.WriteLine("How would you like to search?");
            Console.WriteLine();
            tool.MenuLine(1, "Search by Type");
            tool.MenuLine(2, "Search by Model");
            tool.MenuLine(3, "Search by Minimum MPG");
            tool.MenuLine(4, "Main Menu");

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
                        Console.Clear();
                        Menu();
                        validEntry = true;
                        break;
                    default:
                        validEntry = false;
                        tool.WriteColors("Please make a valid response", "red");
                        break;
                }
            }
        }

        public void SelectVehicleByType()
        {
            Console.Clear();

            Console.WriteLine("Which vehicles would you like to see?");
            Console.WriteLine();
            tool.MenuLine(1, "Electric");
            tool.MenuLine(2, "Hybrid");
            tool.MenuLine(3, "Gas/Deisel");
            tool.MenuLine(4, "Main Menu");

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
                    case "4":
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        validEntry = false;
                        tool.WriteColors("Please make a valid response", "red");
                        break;
                }
            }
        }


        public void SelectVehicleByModel()
        {

            Console.Clear();
            Console.WriteLine("Which vehicle would you like to see?");
            Console.WriteLine();
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
                tool.MenuLine(menuItem, vehicle.Make + " " + vehicle.Model);
                menuItem++;
            }
        }


        public void GetVehicleChoiceFromUser()
        {
            int pad = 18;
            int cols = 6;
            int selNum;

            int selected = tool.GetIntResponse("");

            Console.Clear();

            if (selected == 0)
            {
                tool.WriteColors("Please make a valid entry:", "Red");
                PullVehicleMenuFromList();
            }
            else
            {
                Vehicle vehicle = _repo[selected - 1];
                tool.MessageBar(vehicle.Make + " " + vehicle.Model,"=", " ", pad * cols);

                ColHeads(pad, cols);
                tool.RowDivider("=", pad * cols);

                tool.PadString(VehicleType(vehicle.Type), pad);
                tool.PadString(vehicle.Make, pad);
                tool.PadString(vehicle.Model, pad);
                tool.PadInt(vehicle.Year, pad);
                tool.PadDouble(vehicle.MPG, pad);
                tool.PadInt(vehicle.Range, pad);
                Console.WriteLine();
                tool.RowDivider("-", pad * cols);
            }
        }




        public void ViewVehicleByType(int type)
        {
            Console.Clear();
            int pad = 18;
            int cols = 6;

            string barType = VehicleType(type);

            tool.MessageBar(barType.ToUpper(), "=", " ", pad * cols);

            ColHeads(pad, cols);
            tool.RowDivider("=", pad * cols);

            foreach (Vehicle vehicle in _repo)
            {
                if (vehicle.Type == type)
                {
                    tool.PadString(VehicleType(vehicle.Type), pad);
                    tool.PadString(vehicle.Make, pad);
                    tool.PadString(vehicle.Model, pad);
                    tool.PadInt(vehicle.Year, pad);
                    tool.PadDouble(vehicle.MPG, pad);
                    tool.PadInt(vehicle.Range, pad);
                    Console.WriteLine();
                    tool.RowDivider("-", pad * cols);
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
            Console.Clear();
            Console.WriteLine("Enter the type of vehicle you'd like to add:");
            Console.WriteLine();
            tool.MenuLine(1, "Electric");
            tool.MenuLine(2, "Hybrid");
            tool.MenuLine(3, "Gas/Deisel");
            tool.MenuLine(4, "Main Menu");
            int type = tool.GetIntResponse("");
            Console.Clear();
            string make = tool.GetStringResponse("Please enter a make:");
            Console.Clear();
            string model = tool.GetStringResponse("Please enter a model:");
            Console.Clear();
            int year = tool.GetIntResponse("Please enter a year:");
            Console.Clear();
            double mpg = tool.GetDoubleResponse("Please enter average MPG:");
            Console.Clear();
            int range = tool.GetIntResponse("Please enter approximate range:");
            Console.Clear();

            Vehicle newVehicle = new Vehicle(type, make, model, year, mpg, range);

            _repo.Add(newVehicle);

            tool.WriteColors("Your vehicle was added.", "green");

            Menu();
        }


        private void UpdateExistingVehicle()
        {
            PullVehicleMenuFromList();
            int selection = tool.GetIntResponse("Please enter which vehicle you want to delete:");

            Console.Clear();

            Vehicle oldVehicle = _repo[selection - 1];

            if (oldVehicle == null)
            {
                tool.WriteColors("Vehicle not found.  Press any key to continue...", "Red");
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

            tool.MenuLine(1, "Vehicle Type");
            tool.MenuLine(2, "Vehicle Make");
            tool.MenuLine(3, "Vehicle Model");
            tool.MenuLine(4, "Vehicle Year");
            tool.MenuLine(5, "Vehicle MPG");
            tool.MenuLine(6, "Vehicle Range");
            tool.MenuLine(7, "No updates needed");

            int propUpdate = tool.GetIntResponse("");

            switch (propUpdate)
            {
                case 1:
                    oldVehicle.Type = tool.GetIntResponse("Enter new Type");
                    break;
                case 2:
                    oldVehicle.Make = tool.GetStringResponse("Enter new Make");
                    break;
                case 3:
                    oldVehicle.Model = tool.GetStringResponse("Enter new Model");
                    break;
                case 4:
                    oldVehicle.Type = tool.GetIntResponse("Enter new Year");
                    break;
                case 5:
                    double mpg = tool.GetDoubleResponse("Enter MPG:");
                    break;
                case 6:
                    oldVehicle.Range = tool.GetIntResponse("Enter new Range");
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
            int selection = tool.GetIntResponse("Please enter which vehicle you want to delete:");

            _repo.RemoveAt(selection - 1);

            tool.WriteColors("Vehicle deleted.", "Red");

            tool.KeyForward();
            Menu();
        }

        public void SeedVehicles()
        {
            Vehicle newVehicle1 = new Vehicle(3, "Honda", "CRV", 2017, 26, 450);
            Vehicle newVehicle2 = new Vehicle(1, "Tesla", "Model 3", 2020, 93, 402);
            Vehicle newVehicle3 = new Vehicle(2, "Ford", "Escape", 2020, 48, 500);
            Vehicle newVehicle4 = new Vehicle(3, "Hummer", "Full Combat", 2020, 6, 300);

            _repo.Add(newVehicle1);
            _repo.Add(newVehicle2);
            _repo.Add(newVehicle3);
            _repo.Add(newVehicle4);
        }

        public void ColHeads(int pad, int cols)
        {
            tool.PadString("Type", pad);
            tool.PadString("Make", pad);
            tool.PadString("Model", pad);
            tool.PadString("Year", pad);
            tool.PadString("MPG", pad);
            tool.PadString("Range", pad);
            Console.WriteLine();
        }

    }
}

