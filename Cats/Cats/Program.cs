using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cats
{
    class Program
    {
        static void Start()
        {
            Cat cat1 = new(nickname: "Agatha", age: 3, gender: false, price: 65, mealQuantity: 350);
            Cat cat2 = new(nickname: "Bubba", age: 5, gender: true, price: 80, mealQuantity: 248);
            CatHouse catHouse = new()
            {
                Name = "House Agatha"
            };
            catHouse.Add(cat1);
            catHouse.Add(cat2);
            //catHouse.RemoveByNickname("Agatha");
            //catHouse.ShowCats();
            PetShop petShop = new()
            {
                Name = "We Love Pets"
            };
            petShop.Add(catHouse);
            petShop.ShowPetShop();
            petShop.ShowAllHouse();
            catHouse.ShowCats();
            Console.ReadKey(); // readkey etdikden sonra pisikler oynuyur,yemek yeyir ve yatir.
            foreach (var house in petShop.CatHouses)
            {
                foreach (var cat in house.Cats)
                {
                    cat.Play(4);
                    cat.Eat(7);
                    cat.Play(8);
                }
            }

        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
