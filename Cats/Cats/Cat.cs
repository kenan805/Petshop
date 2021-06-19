using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cats
{
    class Cat
    {
        public static double maxEnergy = 150;
        public string Nickname { get; set; }
        public bool Gender { get; private set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (age < 0) Console.WriteLine("Exception:Age cannot be less than 0!");
                else age = value;
            }
        }
        public double Energy { get; private set; } = 150;
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (price < 0) Console.WriteLine("Exception:Price cannot be less than 0!");
                else price = value;
            }
        }
        private double mealQuantity;
        public double MealQuantity
        {
            get { return mealQuantity; }
            set
            {
                if (mealQuantity < 0) Console.WriteLine("Exception:Meal quantity cannot be less than 0!");
                else mealQuantity = value;
            }
        }

        public Cat()
        {

        }
        public Cat(in string nickname, in int age, in bool gender, in double price, in double mealQuantity)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Price = price;
            MealQuantity = mealQuantity;
        }
        public void Eat(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Energy >= maxEnergy)
                {
                    Console.WriteLine("The cat isn't hungry.");
                    Console.ReadKey();
                    break;
                }
                else if (Energy < maxEnergy && mealQuantity > 0)
                {
                    Energy += 35;
                    price += 0.39;
                    mealQuantity -= 44;
                    if (mealQuantity <= 0)
                    {
                        mealQuantity = 0;
                        Console.Clear();
                        Show();
                        Console.WriteLine("There is no food left.");
                        Console.ReadKey();
                        break;
                    }
                    if (Energy >= maxEnergy) Energy = maxEnergy;
                    Console.Clear();
                    Show();
                    Thread.Sleep(700);
                }
            }
        }
        public void Sleep()
        {
            if (Energy <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Energy += 35;
                    if (Energy >= maxEnergy)
                    {
                        Energy = maxEnergy;
                        Console.Clear();
                        Show();
                        Console.WriteLine("The cat woke up.");
                        Console.ReadKey();
                        break;
                    }
                    Console.Clear();
                    Show();
                    Thread.Sleep(700);
                }
            }
            else
            {
                Console.WriteLine("The cat has no sleep.");
                Console.ReadKey();
            }
        }
        public void Play(int count)
        {
            if (Energy > 0)
            {

                for (int i = 0; i < count; i++)
                {
                    Energy -= 35;
                    if (Energy <= 0)
                    {
                        Energy = 0;
                        Console.Clear();
                        Show();
                        Console.WriteLine("The cat doesn't have the energy to play.\nThe cat is sleeping.");
                        Console.ReadKey();
                        Sleep();
                        break;
                    }
                    Console.Clear();
                    Show();
                    Thread.Sleep(700);
                }
            }
            else Sleep();
        }
        public void Show()
        {
            string gender = Gender ? "male" : "female";
            Console.WriteLine($"Cat nickname: {Nickname}");
            Console.WriteLine($"Cat age: {Age}");
            Console.WriteLine($"Cat gender: {gender}");
            Console.WriteLine($"Cat energy: {Energy}");
            Console.WriteLine($"Cat price: {Price} $");
            Console.WriteLine($"Cat meal quantity: {MealQuantity} qr");
            Console.WriteLine("------------------------------------------");
        }

    }
}
