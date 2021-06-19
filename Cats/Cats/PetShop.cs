using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    class PetShop
    {
        public CatHouse[] CatHouses { get; set; }
        public string Name { get; set; }

        public void ShowAllHouse()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var catHouse in CatHouses)
            {
                catHouse.ShowCatHouse();
            }
        }
        public void ShowPetShop()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\tPetshop info");
            Console.WriteLine($"Petshop name: {Name}");
            Console.WriteLine($"Cat houses count: {CatHouses.Length}");
            Console.WriteLine("------------------------------------------");
        }
        public void Add(in CatHouse newCathouse)
        {
            if (newCathouse != null)
            {
                int newCount = (CatHouses == null) ? 1 : CatHouses.Length + 1;
                CatHouse[] newCatHouses = new CatHouse[newCount];
                if (CatHouses != null) Array.Copy(CatHouses, newCatHouses, CatHouses.Length);
                newCatHouses[newCount - 1] = newCathouse;
                CatHouses = newCatHouses;
            }
            else Console.WriteLine("New cat is null!");
        }

        public void RemoveByName(string name)
        {
            if (Array.Exists(CatHouses, item => item.Name == name))
            {
                int findIndex = Array.FindIndex(CatHouses, item => item.Name == name);
                if (findIndex >= 0)
                {
                    CatHouse[] newCatHouses = new CatHouse[CatHouses.Length - 1];
                    if (newCatHouses != null)
                    {
                        Array.Copy(CatHouses, newCatHouses, findIndex);
                        Array.Copy(CatHouses, findIndex + 1, newCatHouses, findIndex, CatHouses.Length - 1 - findIndex);
                    }
                    CatHouses = newCatHouses;
                }
            }
            else Console.WriteLine("Not find cat house name!");
        }
    }
}
