using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Repo
{
    public class Vehicle
    {
        public int Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double MPG { get; set; }
        public int Range { get; set; }

        public Vehicle() { }

        public Vehicle(int type, string make, string model, int year, double mpg, int range)
        {
            Type = type;
            Make = make;
            Model = model;
            Year = year;
            MPG = mpg;
            Range = range;
        }
    }
}
