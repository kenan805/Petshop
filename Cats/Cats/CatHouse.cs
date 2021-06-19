using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    class CatHouse
    {
        public Cat[] Cats { get; set; }
        public string Name { get; set; }
        public void Add(in Cat newCat)
        {
            if (newCat != null)
            {
                int newCatCount = (Cats == null) ? 1 : Cats.Length + 1;
                Cat[] newCats = new Cat[newCatCount];
                if (Cats != null) Array.Copy(Cats, newCats, Cats.Length);
                newCats[newCatCount - 1] = newCat;
                Cats = newCats;
            }
            else
            {
                Console.WriteLine("New cat is null!");
            }
        }
        public void RemoveByNickname(string nickname)
        {
            if (Array.Exists(Cats, item => item.Nickname == nickname))
            {
                int findIndex = Array.FindIndex(Cats, cat => cat.Nickname == nickname);
                if (findIndex >= 0)
                {
                    Cat[] newCats = new Cat[Cats.Length - 1];
                    if (newCats != null)
                    {
                        Array.Copy(Cats, newCats, findIndex);
                        Array.Copy(Cats, findIndex + 1, newCats, findIndex, Cats.Length - 1 - findIndex);
                    }
                    Cats = newCats;
                }
            }
            else Console.WriteLine("Not find nickname!");
        }
        public void ShowCats()
        {
            Console.WriteLine("\t\t\tCat info");
            foreach (var cat in Cats)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                cat.Show();
            }
        }

        public void ShowCatHouse()
        {
            Console.WriteLine("\t\t\tCat hoise info");
            Console.WriteLine($"Cats count: {Cats.Length}");
            Console.WriteLine($"Price of common cats: {GetCommonPriceCats()}");
            Console.WriteLine($"The quantity of common meals: {GetCommonMealQuantityCats()}");
            Console.WriteLine("------------------------------------------");
        }

        public double GetCommonPriceCats()
        {
            double commonPrice = 0;
            foreach (var cat in Cats)
            {
                commonPrice += cat.Price;

            }
            return commonPrice;
        }

        public double GetCommonMealQuantityCats()
        {
            double commonMealqQuantity = 0;
            foreach (var cat in Cats)
            {
                commonMealqQuantity += cat.MealQuantity;

            }
            return commonMealqQuantity;
        }
    }
}

