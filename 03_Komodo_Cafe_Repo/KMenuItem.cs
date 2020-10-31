using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Cafe_Repo
{
    public class KMenuItem
    {
        public int MealNumber { get; set;  }
        public string MealName { get; set;  }
        public string MealDescription { get; set;  }
        public string MealIngredients { get; set;  }
        public decimal MealPrice { get; set;  }

        public KMenuItem() { }


        public KMenuItem(int mealnumber, 
                        string mealname, 
                        string mealdescription, 
                        string mealingredients, 
                        decimal mealprice)
        {
            MealNumber = mealnumber;
            MealName = mealname;
            MealDescription = mealdescription;
            MealIngredients = mealingredients;
            MealPrice = mealprice;
        }

    }
}
